using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TagLib;

namespace AudioBookConverter {
	public class FileEntryClass {

		private string filename;
		private bool chapter;
		private string chaptertitle;
		private string filepath;
		private TimeSpan duration;
		private int adhocsort;

		public string FilePath {
			get { return filepath; }
			set { filepath = value; }
		}

		public string FileName {
			get { return filename; }
			set { filename = value; }
		}
		public bool Chapter {
			get { return chapter; }
			set { chapter = value; }
		}
		public string ChapterTitle {
			get {
				return chaptertitle; }
			set { chaptertitle = value; }
		}
		public string ChapterTitleResolver {
			get {
				if (chaptertitle == null || chaptertitle == "") return Title;
				return chaptertitle;
			}
		}

		public TimeSpan Duration {
			get { return duration; }
			set { duration = value; }
		}

		public int TrackNum {
			get { return (int)Tag.Track; }
			set { Tag.Track = (uint)value; }
		}
		public string Title {
			get {
				if (Tag.Title == null || Tag.Title == "") return Path.GetFileNameWithoutExtension(filepath); 
				return Tag.Title; }
			set { Tag.Title = value; }
		}


		public int AdHocSort {
			get {return adhocsort;}
			set { adhocsort = value;}
		}
		public byte[] Picture {
			get {
				TagLib.IPicture[] filepics = Tag.Pictures;
				if (filepics.Length > 0) return Tag.Pictures[0].Data.Data;
				return null;
			}
		}
		public TagLib.Tag Tag;

		public FileEntryClass (string file) {
			TagLib.File audiofile = TagLib.File.Create(file);
			Tag = audiofile.Tag;
			filename = Path.GetFileName(file);
			filepath = file;
			duration = audiofile.Properties.Duration;
			

		}
	}
}
