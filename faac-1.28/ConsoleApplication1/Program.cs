using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using faacdotnet;
using Yeti.MMedia;
using Yeti.WMFSdk;


namespace ConsoleApplication1 {
	class Program {
		static void Main (string[] args) {

			uint samplerate = 44100;
			uint numchannels = 2;
			long inputsamples = 0;
			long maxbytes = 0;


			string file = "c:\\sandbox\\testfile.mp3";
			WmaStream wavfile = new WmaStream(file);
			samplerate = (uint)wavfile.Format.nSamplesPerSec;
			

			FileStream outputfile = new FileStream("c:\\mp4utils\\faactest.aac", FileMode.Create);

			faac encoder = new faac(samplerate, 2);
			inputsamples = encoder.InputSamples;
			maxbytes = encoder.MaxBytes;
			encoder.BitRate=16000;
			encoder.InputFormat=1;
			encoder.BandWidth=22050;
			encoder.UseTNS = 0;
			int read = 0;
			uint decoderspeclength = 0;
			byte[] decoderspecificinfo = encoder.DecoderSpecInfo;

			DateTime start = DateTime.Now;
			long totalsamples = 0;
			while (wavfile.Position < wavfile.Length && read != -1) {
				short[] isamples = new short[inputsamples];
				byte[] wavbytes = new byte[inputsamples * 2];
				int bytes = 0;
				
				if (wavfile.Position < wavfile.Length)
					bytes = wavfile.Read(wavbytes, 0, (int)inputsamples * 2);

				int z = 0;
				for (int x = 0; x < bytes; x += 2) {
					isamples[z] = (short)((wavbytes[x + 1] << 8) | wavbytes[x] << 0);
					z++;
					
				}

				byte[] output = new byte[maxbytes];
				uint buffersize = 0;
				int inputsam = (int)inputsamples;


				read = encoder.Encode(isamples, inputsam, out output, out buffersize);

				outputfile.Write(output, 0, (int)read);
				totalsamples += bytes / 2;
				
			}
			Console.WriteLine(DateTime.Now - start);
			Console.WriteLine("Audio Duration: " + TimeSpan.FromSeconds((totalsamples / samplerate)/numchannels));
			outputfile.Close();
		}
	}
}
