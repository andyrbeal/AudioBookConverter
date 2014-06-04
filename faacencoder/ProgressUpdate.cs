using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AudioBookConverter {
	public class ProgressUpdate {
		private int totalfiles;
		private int currentfile;
		private int totalkbytes;
		private int currentkbyte;
		private string currentfilename;
		private bool bentoworking;
		public string CurrentFilename {
			set { currentfilename = value; }
			get { return currentfilename; }
		}
		public bool BentoWorking {
			get { return bentoworking; }
			set { bentoworking = value; }
		}
		public int TotalFiles {
			get { return totalfiles; }
			set { totalfiles = value; }
		}
		public int CurrentFile {
			get { return currentfile; }
			set { currentfile = value; }
		}
		public int TotalKbytes {
			get { return totalkbytes; }
			set { totalkbytes = value; }
		}
		public int CurrentKbyte {
			get { return currentkbyte; }
			set { currentkbyte = value; }
		}
	}
}
