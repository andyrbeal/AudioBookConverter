using System;
using System.Collections.Generic;
using System.Text;
using faacdotnet;
using Yeti.MMedia;
using Yeti.WMFSdk;
using System.IO;
using BentoSharp;
using TagLib;


namespace AudioBookConverter {


	static class Util {
		public static AudioBookConverterMain Owner;
		public static void FileEncode (SortableBindingList<FileEntryClass> workinglist, string m4boutputfile,
										int TargetRate, int Quant, int usetns,
										ProgressUpdate procprogress,AudioBookConverterMain _owner) {
			Owner = _owner;
			long inputsamples = 0;
			long maxbytes = 0;
			ulong filesamples = 0;
			ulong totalms = 0;
			ulong filems;
			int read;
			int fileindex = 0;
			int lastupdate = 0;
			bool havechapters=false;
			int bufferfactor = 256;
			
			//scan the files, see if we need chapter processing
			foreach (FileEntryClass listitem in workinglist)
				if (listitem.Chapter) {
					havechapters = true;
					if (listitem.ChapterTitle == null)
						if (listitem.Title != null) {
							listitem.ChapterTitle = listitem.Title;
						}
						else {
							listitem.ChapterTitle = Path.GetFileNameWithoutExtension(listitem.FilePath);
						}
				}
			
			WmaStream wavfile = new WmaStream(workinglist[fileindex].FilePath);
			uint samplerate = (uint)wavfile.Format.nSamplesPerSec;
			uint numchannels = (uint)wavfile.Format.nChannels;

			string tempfile = Path.GetTempFileName();
			//FileStream outputfile = new FileStream(tempfile, FileMode.Create);
			Bento4Writer mp4writer = new Bento4Writer(m4boutputfile, tempfile);
			// Faac Settings
			faac encoder = new faac(samplerate, numchannels);
			inputsamples = encoder.InputSamples;
			maxbytes = encoder.MaxBytes;
			encoder.QuantQual = Quant;
			encoder.InputFormat = 1;
			//encoder.BandWidth = 8000;// (int)samplerate / 6;
			encoder.UseTNS = usetns;
			encoder.UseLFE = 0;
			encoder.BitRate = TargetRate * 1000;

			byte[] decoderspecific = encoder.DecoderSpecInfo;

			string[] chaptitles = new string[255];
			ulong[] chapstart = new ulong[255];
			uint totalchapters = 0;

			if (havechapters) {
				chapstart[0] = 0;
				totalchapters = 0;
				if (!workinglist[fileindex].Chapter) {
					chaptitles[0] = "Begin";
				}
				else {
					chaptitles[0] = workinglist[fileindex].ChapterTitleResolver;
				}
			}

			procprogress.TotalFiles = workinglist.Count;
			procprogress.TotalKbytes = (int)wavfile.Length / 1024;
			procprogress.CurrentFile = fileindex + 1;
			procprogress.CurrentFilename = workinglist[fileindex].FilePath;

			read = 0;
			//setup buffer for data coming from faac
			byte[] aac_buffer = new byte[maxbytes * bufferfactor];
			int aac_buffer_offset = 0;
			int aac_buffer_frames = 0;

			//DateTime start = DateTime.Now;
			while (fileindex < workinglist.Count && read != -1) {
				if (Owner.bgAACEncoder.CancellationPending) {
					wavfile.Close();
					//outputfile.Close();
					//System.IO.File.Delete(tempfile);
					return;
				}

				short[] isamples = new short[inputsamples];
				byte[] wavbytes = new byte[inputsamples * 2];
				int bytes = 0;


				//read from source file
				bytes = wavfile.Read(wavbytes, 0, (int)inputsamples * 2);
				//update filesamples with number of samples
				filesamples += (ulong)bytes / (numchannels * 2);

				if (wavfile.Position >= wavfile.Length || bytes < inputsamples*2) {
					
					filems = filesamples * 1000 / samplerate;

					workinglist[fileindex].Duration = TimeSpan.FromMilliseconds(filems);
					//if that file we just ran was flagged as a chapter start, finalize the last and create a new
					if (workinglist[fileindex].Chapter && fileindex != 0) {
						chapstart[totalchapters] = totalms;
						totalchapters++;
						chaptitles[totalchapters] = workinglist[fileindex].ChapterTitleResolver;

					}

					//accumulate the total millisecond counter
					totalms += filems;
					fileindex++;

					//out of data, move to next file
					wavfile.Close();
					if (fileindex < workinglist.Count) {
						wavfile = new WmaStream(workinglist[fileindex].FilePath);

						//need to read more to get required number of input samples
						if (bytes < inputsamples * 2) {
							int requiredbytes = (int)(inputsamples * 2) - bytes;
							byte[] extrawavbytes = new byte[requiredbytes];
							int extrabytes;

							extrabytes = wavfile.Read(extrawavbytes, 0, requiredbytes);
							Array.Copy(extrawavbytes, 0, wavbytes, bytes, extrabytes);
							bytes += extrabytes;
							filesamples = (ulong)extrabytes / (numchannels * 2);

						}
						else {

							filesamples = 0;
						}



						procprogress.CurrentFile = fileindex + 1;
						procprogress.CurrentKbyte = 1;
						procprogress.TotalKbytes = (int)wavfile.Length / 1024;
						procprogress.CurrentFilename = workinglist[fileindex].FilePath;
						Owner.bgAACEncoder.ReportProgress(0, procprogress);
						lastupdate = 0;
					}
				}

				//Notification to user front-end

				if (lastupdate > 200) {
					if (bytes == inputsamples * 2) {
						procprogress.CurrentKbyte = (int)wavfile.Position / 1024;
					}
					else { procprogress.CurrentKbyte = procprogress.TotalKbytes; }

					lastupdate = 0;
					Owner.bgAACEncoder.ReportProgress(0, procprogress);
				}
				lastupdate++;

				//convert the byte[] into a short[]
				int z = 0;
				for (int x = 0; x < bytes; x += 2) {
					isamples[z] = (short)((wavbytes[x + 1] << 8) | wavbytes[x] << 0);
					z++;
				}

				byte[] output = new byte[maxbytes];
				uint buffersize = 0;
				int inputsam = isamples.Length;

				//feed the samples to the aac encoder
				read = encoder.Encode(isamples, inputsam, out output, out buffersize);

				//if the encoder encoded, write it out to the aac buffer
				if (read > 0) {
					Array.Copy(output, 0, aac_buffer, aac_buffer_offset, read);
					aac_buffer_offset += read;
					aac_buffer_frames++;
					//if the buffer is full, write it out to bento
					if (aac_buffer_frames == bufferfactor) {
						mp4writer.Write(aac_buffer, aac_buffer_frames);
						aac_buffer_frames = 0;
						aac_buffer_offset = 0;

					}
					

				}

			} //end sample processing loop

			//flush the sample_buffer
			if (aac_buffer_frames > 0) {
				mp4writer.Write(aac_buffer, aac_buffer_frames);
						
			}
			encoder.Close();
			encoder.Dispose();
			wavfile.Close();
			wavfile.Dispose();
			

			if (havechapters) {
				chapstart[totalchapters] = totalms;
				totalchapters++;

				mp4writer.WriteChapters(chaptitles, chapstart, totalchapters);
				
			}
			////fake chapter data
			//for (int fx = 0; fx < 35; fx++) {
			//    chaptitles[fx] = "Chapter " + fx;
			//    chapstart[fx] = (ulong)((2500 * fx) + fx);
			//}
			

			//totalchapters = 35;
			if (Owner.bgAACEncoder.CancellationPending) {
				return;
			}
			

			procprogress.CurrentFilename = "Packaging Mpeg4 Audiobook File";
			procprogress.TotalFiles = 1;
			procprogress.CurrentFile = 1;
			procprogress.BentoWorking = true;
			Owner.bgAACEncoder.ReportProgress(0, procprogress);
			
			//tempfile = "c:\\mp4utils\\file.aac";
			//chapdata = "c:\\mp4utils\\chapdata.txt";
			//BentoSharp.Bento4 BentoClass = new Bento4();
			//int bentoerror = BentoClass.aac2mp4(tempfile, m4boutputfile, decoderspecific, chapdata, chapstart, totalchapters);
			//bentoerror = BentoClass.mp4chapter("c:\\mp4utils\\bentoout.m4b","c:\\mp4utils\\chapout.m4b",chapdata,chaptimes,totalchapters);
			//BentoClass = null;
			mp4writer.Save();
			
			//System.IO.File.Delete(tempfile);
			//System.IO.File.Delete(chapdata);
			mp4writer.Dispose();
		}

		
		public static void ApplyTags (OutputMetadata tagdata, ProgressUpdate procprogress,AudioBookConverterMain _owner ) {
			if (Owner.bgAACEncoder.CancellationPending) return;
			
			Owner = _owner;
			procprogress.CurrentFilename = "Writing MetaData";
			procprogress.TotalFiles = 1;
			procprogress.CurrentFile = 1;
			procprogress.BentoWorking = true;
			Owner.bgAACEncoder.ReportProgress(0, procprogress);
			TagLib.File Mp4File = TagLib.File.Create(tagdata.OutputFile);

			if (tagdata.Album != null)Mp4File.Tag.Album = tagdata.Album;
			if (tagdata.AlbumSort != null)Mp4File.Tag.AlbumSort = tagdata.AlbumSort;
			if (tagdata.Composer != null) Mp4File.Tag.Composers = tagdata.Composer.Split(';');
			if (tagdata.ComposerSort != null)Mp4File.Tag.ComposersSort = tagdata.ComposerSort.Split(';');
			Mp4File.Tag.Disc = (uint)tagdata.Disc;
			Mp4File.Tag.DiscCount = (uint)tagdata.DiscTotal;
			Mp4File.Tag.Kind = 2;
			if (tagdata.Artist != null)Mp4File.Tag.Performers = tagdata.Artist.Split(';');
			if (tagdata.ArtistSort != null) Mp4File.Tag.PerformersSort = tagdata.ArtistSort.Split(';');
			if (tagdata.Title != null)Mp4File.Tag.Title = tagdata.Title;
			if (tagdata.TitleSort != null)Mp4File.Tag.TitleSort = tagdata.TitleSort;
			Mp4File.Tag.Track = (uint)tagdata.Track;
			Mp4File.Tag.Track = (uint)tagdata.TrackTotal;
			Mp4File.Tag.Year = (uint)tagdata.Year;
			if (tagdata.Comment != null) Mp4File.Tag.Comment = tagdata.Comment;
			if (tagdata.Image != null) {

				TagLib.Picture ipic = new TagLib.Picture();
				TagLib.ByteVector picdata = new TagLib.ByteVector();

				picdata.Add(tagdata.Image);
				ipic.Data = picdata;
				ipic.MimeType = "image/jpeg";
				ipic.Type = PictureType.FrontCover;
				ipic.Description = "Front Cover";
			
				Picture[] PictFrames = { ipic };
				Mp4File.Tag.Pictures = PictFrames;
			}
			Mp4File.Save();
			

		}

	}
	

}