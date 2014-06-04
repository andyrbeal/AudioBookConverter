using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AudioBookConverter {
	public partial class PerformingConversion : Form {
		private AudioBookConverterMain owner;
		private int totalfiles;
		private int currentfile;
		private int totalkbytes;
		private int currentkbyte;
		private string currentfilename;

		public PerformingConversion (AudioBookConverterMain _owner) {
			owner = _owner;
			InitializeComponent();
		}

		public string CurrentFilename {
			get { return currentfilename; }
			set {
				currentfilename = value;
				lblFile.Text = currentfilename;
			}
		}

		public int TotalFiles {
			get { return totalfiles; }
			set { totalfiles = value;
			pbTotalFiles.Maximum = value;
			updateprogresslabel();
			}
		}
		public int CurrentFile {
			get { return currentfile; }
			set { currentfile = value;
			pbTotalFiles.Value = value;
				updateprogresslabel();
			}
		}
		public void updateprogresslabel () {
			lblFileProgress.Text = "File " + CurrentFile + " of " + TotalFiles;

		}
		public int TotalKbytes {
			get { return totalkbytes; }
			set { totalkbytes = value;
			pbFileConversion.Maximum = value;
			}
		}
		public int CurrentKbyte {
			get { return currentkbyte; }
			set { currentkbyte = value;
			pbFileConversion.Value = value;
			}
		}
		public bool BentoMode {
			set {
				pbFileConversion.Visible = false;
				lblFile.Visible = false;
				lblMain.Text = "Packaging MPEG4 file";
				btnCancel.Enabled = false;
			}
		}

		private void btnCancel_Click (object sender, EventArgs e) {
			lblMain.Text = "Cancelling Process";
			owner.CancelProcessing = true;
		}
	}
}
