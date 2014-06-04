using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace AudioBookConverter {
	class ProjectXml {
		private SortableBindingList<FileEntryClass> file_entries;
		private OutputMetadata output_metadata;
		private string filename;

		public ProjectXml(string FileName) {
			filename = FileName;
		}

		public void Write (SortableBindingList<FileEntryClass> FileEntries, OutputMetadata OutputMetaData) {

			file_entries = FileEntries;
			output_metadata = OutputMetaData;

			XDocument doc = new XDocument();
			XElement Container = new XElement("SaveData");
			XElement OutputData = new XElement("OutputData",
				new XElement("OutputFile",output_metadata.OutputFile),
				new XElement("Album",output_metadata.Album),
				new XElement("AlbumSort",output_metadata.AlbumSort),
				new XElement("Artist",output_metadata.Artist),
				new XElement("ArtistSort",output_metadata.ArtistSort),
				new XElement("Comment",output_metadata.Comment),
				new XElement("Composer",output_metadata.Composer),
				new XElement("ComposerSort",output_metadata.ComposerSort),
				new XElement("Disc",output_metadata.Disc),
				new XElement("DiscTotal",output_metadata.DiscTotal),
				new XElement("Title",output_metadata.Title),
				new XElement("TitleSort",output_metadata.TitleSort),
				new XElement("Track",output_metadata.Track),
				new XElement("TrackTotal",output_metadata.TrackTotal),
				new XElement("Year",output_metadata.Year)
				);
			if (output_metadata.Image != null) {
				OutputData.Add (new XElement("Artwork", Convert.ToBase64String(output_metadata.Image, Base64FormattingOptions.InsertLineBreaks)));
			}
			Container.Add(OutputData);
			
			//XElement Configuration = new XElement("Configuration");
			//XElement BitRate = new XElement("BitRate",
			
			
			XElement Files = new XElement("FileEntries");
			int x = 0;
			foreach (FileEntryClass entry in file_entries) {
				
				XElement FileEnt = new XElement("FileEntry", new XAttribute("Index",entry.AdHocSort),
					new XElement("FileName",entry.FileName),
					new XElement("FilePath",entry.FilePath),
					new XElement("Chapter",entry.Chapter),
					new XElement("ChapterTitle",entry.ChapterTitle),
					new XElement("Title",entry.Title),
					new XElement("Duration",entry.Duration.TotalMilliseconds),
					new XElement("TrackNum",entry.TrackNum)
					);
				

				Files.Add(FileEnt);


				x++;
			}
			Container.Add(Files);
			doc.Add(Container);
			doc.Save(filename);
		}

		public void Read (out SortableBindingList<FileEntryClass> FileEntries, out OutputMetadata OutputMetaData) {
			file_entries = new SortableBindingList<FileEntryClass>();
			output_metadata = new OutputMetadata();

			XDocument doc = XDocument.Load(filename);

			var outputinfo = from outputdat in (doc.Descendants("OutputData"))
							 select new {
								 OutputFile = (string)outputdat.Element("OutputFile"),
								 Album = (string)outputdat.Element("Album"),
								 AlbumSort = (string)outputdat.Element("AlbumSort"),
								 Artist = (string)outputdat.Element("Artist"),
								 ArtistSort = (string)outputdat.Element("ArtistSort"),
								 Comment = (string)outputdat.Element("Comment"),
								 Composer = (string)outputdat.Element("Composer"),
								 ComposerSort = (string)outputdat.Element("ComposerSort"),
								 Disc = outputdat.Element("Disc").Value,
								 DiscTotal = outputdat.Element("DiscTotal").Value,
								 Title = (string)outputdat.Element("Title"),
								 TitleSort = (string)outputdat.Element("TitleSort"),
								 Track = outputdat.Element("Track").Value,
								 TrackTotal = outputdat.Element("TrackTotal").Value,
								 Year = outputdat.Element("Year").Value,
								 Artwork = (string)outputdat.Element("Artwork")
							 };
			var fileinfo = from filedat in (doc.Descendants("FileEntry"))
						   select new {
							   AdHocSort = filedat.Attribute("Index").Value,
							   FileName = (string)filedat.Element("FileName"),
							   FilePath = (string)filedat.Element("FilePath"),
							   Chapter = (bool)filedat.Element("Chapter"),
							   ChapterTitle = (string)filedat.Element("ChapterTitle"),
							   Title = (string)filedat.Element("Title"),
							   Duration = filedat.Element("Duration").Value,
							   TrackNum = filedat.Element("TrackNum").Value
						   };
			var output = outputinfo.First();
			output_metadata.Album = output.Album;
			output_metadata.AlbumSort = output.AlbumSort;
			output_metadata.Artist = output.Artist;
			output_metadata.ArtistSort = output.ArtistSort;
			output_metadata.Comment = output.Comment;
			output_metadata.Composer = output.Composer;
			output_metadata.ComposerSort = output.ComposerSort;
			output_metadata.Disc = Convert.ToInt32(output.Disc);
			output_metadata.DiscTotal = Convert.ToInt32(output.DiscTotal);
			output_metadata.OutputFile = output.OutputFile;
			output_metadata.Title = output.Title;
			output_metadata.TitleSort = output.TitleSort;
			output_metadata.Track = Convert.ToInt32(output.Track);
			output_metadata.TrackTotal = Convert.ToInt32(output.TrackTotal);
			output_metadata.Year = Convert.ToInt32(output.Year);
			if (output.Artwork != null) {
				output_metadata.Image = Convert.FromBase64String(output.Artwork);
			}
			foreach (var singlefile in fileinfo) {
				FileEntryClass listfile = new FileEntryClass(singlefile.FilePath);
				listfile.AdHocSort = Convert.ToInt32(singlefile.AdHocSort);
				listfile.Chapter = singlefile.Chapter;
				listfile.ChapterTitle = singlefile.ChapterTitle;
				listfile.Duration =  TimeSpan.FromMilliseconds(Convert.ToInt32(singlefile.Duration));
				listfile.FileName = singlefile.FileName;
				listfile.FilePath = singlefile.FilePath;
				listfile.Title = singlefile.Title;
				listfile.TrackNum = Convert.ToInt32(singlefile.TrackNum);
				file_entries.Add(listfile);




			}


			FileEntries = file_entries;
			OutputMetaData = output_metadata;
		}
	}
}
