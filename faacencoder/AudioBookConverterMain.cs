using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AudioBookConverter {
	public partial class AudioBookConverterMain : Form {
		public SortableBindingList<FileEntryClass> FileList;
		public OutputMetadata OutputTags;
		public PerformingConversion busyform;
		//public ProgressUpdate procprogress;
		private int _PlayerUpdate;
		private int BitRate;
		private int Quantizer;
		private int UseTNS;
		private PlayerClass MediaPlayer;
		private bool drawing;

		public AudioBookConverterMain () {
			InitializeComponent();
			FileList = new SortableBindingList<FileEntryClass>();
			OutputTags = new OutputMetadata();
			cboBitRate.SelectedIndex = 2;
			cboQuantizer.SelectedIndex = 0;
			cboUseTNS.SelectedIndex = 0;
			GenDGV();
		}

		private void GenDGV () {
			dgvFiles.AutoGenerateColumns = false;
			dgvFiles.DataSource = FileList;

			dgvFiles.ShowEditingIcon = false;
			dgvFiles.Columns.Clear();

			//dgvFiles.RowCount = 20;
			DataGridViewCellStyle CellIconStyle = new DataGridViewCellStyle();


			DataGridViewImageButtonDeleteColumn DelItem = new DataGridViewImageButtonDeleteColumn();
			
			dgvFiles.Columns.Add(DelItem);
			//up

			DataGridViewImageButtonUpColumn ItemUp = new DataGridViewImageButtonUpColumn();
			//ItemUp.FlatStyle = FlatStyle.Flat;
			dgvFiles.Columns.Add(ItemUp);


			//down
			DataGridViewImageButtonDownColumn ItemDown = new DataGridViewImageButtonDownColumn();
			dgvFiles.Columns.Add(ItemDown);

			//play/pause
			DataGridViewImageButtonPlayColumn Mplay = new DataGridViewImageButtonPlayColumn();
			dgvFiles.Columns.Add(Mplay);

			//stop
			DataGridViewImageButtonStopColumn Mstop = new DataGridViewImageButtonStopColumn();
			dgvFiles.Columns.Add(Mstop);

			DataGridViewCheckBoxColumn chapchk = new DataGridViewCheckBoxColumn(false);
			dgvFiles.Columns.Add(chapchk);
			dgvFiles.Columns[5].HeaderText = "Chap Start";
			dgvFiles.Columns[5].DataPropertyName = "Chapter";


			dgvFiles.Columns.Add("ChapterTitle", "Chapter Title");
			dgvFiles.Columns["ChapterTitle"].DataPropertyName = "ChapterTitle";

			dgvFiles.Columns.Add("Title", "MP3 Title");
			dgvFiles.Columns["Title"].DataPropertyName = "Title";

			dgvFiles.Columns.Add("FileName", "Filename");
			dgvFiles.Columns["FileName"].DataPropertyName = "FileName";

			dgvFiles.Columns.Add("TrackNum", "Track #");
			dgvFiles.Columns["TrackNum"].DataPropertyName = "TrackNum";

			dgvFiles.Columns.Add("Duration", "Duration");
			dgvFiles.Columns["Duration"].DataPropertyName = "Duration";

			dgvFiles.Columns.Add("AdHocSort", "AdHocSort");
			dgvFiles.Columns["AdHocSort"].DataPropertyName = "AdHocSort";
			dgvFiles.Columns["AdHocSort"].Visible = false;

			for (int colnum = 0; colnum < dgvFiles.Columns.Count; colnum++)
				dgvFiles.AutoResizeColumn(colnum);


			int gridsize = 0;
			for (int x = 0; x < dgvFiles.Columns.Count; x++)
				if (dgvFiles.Columns[x].Visible)
					gridsize += dgvFiles.Columns[x].Width;

			if (gridsize < dgvFiles.ClientSize.Width) dgvFiles.Columns["ChapterTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


		}

		private int dgvRowSelected {
			get {
				DataGridViewSelectedRowCollection SelectedRows = dgvFiles.SelectedRows;
				if (SelectedRows.Count > 0) return SelectedRows[0].Index;
				return -1;
			}
			set {
				if (value == -1) {
					foreach (DataGridViewRow dgrow in dgvFiles.Rows)
						dgrow.Selected = false;
				}
				else {
					dgvFiles.Rows[value].Selected = true;
				}
			}

		}

		private void ABC_DragEnter (object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				e.Effect = DragDropEffects.Copy;
			}
			else {
				e.Effect = DragDropEffects.None;
			}
		}

		private void ABC_DragDrop (object sender, DragEventArgs e) {
			//if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;
			try {
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				foreach (string file in files) {
					FileEntryClass newfile = new FileEntryClass(file);
					FileList.Add(newfile);
				}
				GenDGV();
			}
			catch { return; }
		}

		private void btnClose_Click (object sender, EventArgs e) {
			MPlayerStop();
			this.Close();
		}

		private void btnStart_Click (object sender, EventArgs e) {
			StartConversion();
		}
		private void StartConversion(){
			if (txtoutputfile.Text == null || txtoutputfile.Text == "") {
				MessageBox.Show( "Please Enter an Output Filename!","No Valid Filename", MessageBoxButtons.OK);
				return;
			}
			DateTime start_time = DateTime.Now;

			bgAACEncoder.RunWorkerAsync();

			busyform = new PerformingConversion(this);
			busyform.ShowDialog();

			TimeSpan time_working = DateTime.Now - start_time;
			MessageBox.Show("Conversion Complete\nTime: " + time_working.ToString(), "Process Complete", MessageBoxButtons.OK);

		}

		private void btnAdd_Click (object sender, EventArgs e) {
			AddFiles();
		}

		private void AddFiles () {
			if (ofdAdd.ShowDialog() == DialogResult.OK) {
				string[] files = ofdAdd.FileNames;
				foreach (string file in files) {
					FileEntryClass newfile = new FileEntryClass(file);
					FileList.Add(newfile);
				}
				GenDGV();

			}
		}

		private void btnSaveFile_Click (object sender, EventArgs e) {
			if (sfdOutput.ShowDialog() == DialogResult.OK && sfdOutput.FileName != null)
				txtoutputfile.Text = sfdOutput.FileName;
		}


		private FileEntryClass GetSelectedEntry {
			get {
				foreach (DataGridViewRow selectedrow in dgvFiles.SelectedRows) {
					foreach (FileEntryClass file in FileList)
						if (file == selectedrow.DataBoundItem)
							return file;
				}
				return null;
			}
		}

		private void btnSort_Click (object sender, EventArgs e) {
			if (!radFileName.Checked && !radTitle.Checked && !radTrack.Checked) return;

			if (radTrack.Checked) {
				dgvFiles.Sort(dgvFiles.Columns["TrackNum"], ListSortDirection.Ascending);
			}
			if (radTitle.Checked) {
				dgvFiles.Sort(dgvFiles.Columns["Title"], ListSortDirection.Ascending);
			}
			if (radFileName.Checked) {
				dgvFiles.Sort(dgvFiles.Columns["FileName"], ListSortDirection.Ascending);
			}

		}

		private void tcOutputFields_DrawItem (object sender, DrawItemEventArgs e) {
			//Firstly we'll define some parameters.

			TabPage CurrentTab = tcOutputFields.TabPages[e.Index];
			Rectangle ItemRect = tcOutputFields.GetTabRect(e.Index);
			SolidBrush FillBrush = new SolidBrush(Color.LightGray);
			SolidBrush TextBrush = new SolidBrush(Color.Black);
			StringFormat sf = new StringFormat();

			sf.Alignment = StringAlignment.Center;
			sf.LineAlignment = StringAlignment.Center;

			//if drawing selected, use these colors, else it will use colors from above
			if (tcOutputFields.SelectedIndex == e.Index) {

				FillBrush.Color = Color.FromKnownColor(KnownColor.Control);
				TextBrush.Color = Color.Black;
				ItemRect.Inflate(2, 2);

			}

			e.Graphics.FillRectangle(FillBrush, ItemRect);

			//Now draw the text.
			e.Graphics.DrawString(CurrentTab.Text, e.Font, TextBrush, ItemRect, sf);

			//Reset any Graphics rotation
			e.Graphics.ResetTransform();

			//Finally, we should Dispose of our brushes.
			FillBrush.Dispose();
			TextBrush.Dispose();


		}



		private void UpdateChapterTitlesfromMp3 () {
			foreach (FileEntryClass item in FileList)
				if (item.Chapter)
					item.ChapterTitle = item.Title;
			dgvFiles.Refresh();
		}
		private void SetAllChapters () {
			foreach (FileEntryClass item in FileList)
				item.Chapter = true;
			dgvFiles.Refresh();
		}

		private void outputdetails_TextChanged (object sender, EventArgs e) {
			UpdateOutputData();
		}

		private void CopyTagsFrom (FileEntryClass sourcefile) {
			if (sourcefile == null) return;
			txtAlbum.Text = sourcefile.Tag.Album;
			txtArtist.Text = sourcefile.Tag.FirstPerformer;
			txtDisc.Text = sourcefile.Tag.Disc.ToString();
			txtDiscTotal.Text = sourcefile.Tag.DiscCount.ToString();
			txtTitle.Text = sourcefile.Tag.Title;
			txtTrack.Text = sourcefile.Tag.Track.ToString();
			txtTrackTotal.Text = sourcefile.Tag.TrackCount.ToString();
			txtYear.Text = sourcefile.Tag.Year.ToString();



		}

		private void UpdateOutputData () {
			if (drawing) return;
			OutputTags.Album = txtAlbum.Text;
			OutputTags.AlbumSort = txtAlbumSort.Text;
			OutputTags.Artist = txtArtist.Text;
			OutputTags.ArtistSort = txtArtistSort.Text; 
			OutputTags.Comment = txtComment.Text;
			OutputTags.Composer = txtComposer.Text;
			OutputTags.ComposerSort = txtComposerSort.Text;
			OutputTags.Disc = ParsetoInt(txtDisc.Text);
			OutputTags.DiscTotal = ParsetoInt(txtDiscTotal.Text);
			OutputTags.Title = txtTitle.Text;
			OutputTags.TitleSort = txtTitleSort.Text;
			OutputTags.Track = ParsetoInt(txtTrack.Text);
			OutputTags.TrackTotal = ParsetoInt(txtTrackTotal.Text);
			OutputTags.Year = ParsetoInt(txtYear.Text);
			OutputTags.OutputFile = txtoutputfile.Text;
		}
		private void UpdateTextOutput () {
			drawing = true;
			txtAlbum.Text = OutputTags.Album;
			txtAlbumSort.Text = OutputTags.AlbumSort;
			txtArtist.Text = OutputTags.Artist;
			txtArtistSort.Text = OutputTags.ArtistSort;
			txtComment.Text = OutputTags.Comment;
			txtComposer.Text = OutputTags.Composer;
			txtComposerSort.Text = OutputTags.ComposerSort;
			txtDisc.Text = OutputTags.Disc.ToString();
			txtDiscTotal.Text = OutputTags.DiscTotal.ToString();
			txtoutputfile.Text = OutputTags.OutputFile;
			txtTitle.Text = OutputTags.Title;
			txtTitleSort.Text = OutputTags.TitleSort;
			txtTrack.Text = OutputTags.Track.ToString();
			txtTrackTotal.Text = OutputTags.TrackTotal.ToString();
			txtYear.Text = OutputTags.Year.ToString();
			drawing = false;


		}

		public int ParsetoInt (string instring) {
			int x = 0;
			Int32.TryParse(instring, out x);
			return x;

		}

		private void CopyMetadata_LinkClicked (object sender, LinkLabelLinkClickedEventArgs e) {
			CopyTagsFrom(GetSelectedEntry);
		}

		public string GetArtistName {
			get { return txtArtist.Text; }
		}
		public string GetAlbumName {
			get { return txtAlbum.Text; }
		}
		public string GetTitle {
			get { return txtTitle.Text; }
		}

		public byte[] ArtWork {
			set {
				OutputTags.Image = value;
				picOutput.Image = Utility.ResizeImage(Utility.BytestoImg(value), 130, 130);
			}
			get {
				if (OutputTags.Image == null) return null;
				return OutputTags.Image;
			}
		}

		public IEnumerable<FileEntryClass> ROFileList {
			get { return FileList as IEnumerable<FileEntryClass>; }


		}

		private void btnImageFinder_Click (object sender, EventArgs e) {
			ImageFinder IFForm = new ImageFinder(this);
			IFForm.ShowDialog();
		}

		private void picOutput_Click (object sender, EventArgs e) {
			ImageFinder IFForm = new ImageFinder(this);
			IFForm.ShowDialog();
		}

		private void bgAACEncoder_DoWork (object sender, DoWorkEventArgs e) {

			if (BitRate == 0) BitRate = 16;
			if (Quantizer == 0) Quantizer = 100;
			ProgressUpdate progressobject = new ProgressUpdate();
			Util.FileEncode(FileList, OutputTags.OutputFile, BitRate, Quantizer,UseTNS, progressobject, this);
			Util.ApplyTags(OutputTags, progressobject, this);
			
		}

		private void bgAACEncoder_Finished (object sender, RunWorkerCompletedEventArgs e) {
			busyform.Close();
		}

		private void bgAACEncoder_ProgressUpdate (object sender, ProgressChangedEventArgs e) {
			ProgressUpdate progressobject = (ProgressUpdate)e.UserState;
			busyform.TotalFiles = progressobject.TotalFiles;
			if (progressobject.CurrentKbyte > busyform.TotalKbytes) busyform.CurrentKbyte = 1;
			busyform.TotalKbytes = progressobject.TotalKbytes;
			busyform.CurrentFile = progressobject.CurrentFile;
			busyform.CurrentKbyte = progressobject.CurrentKbyte;
			busyform.CurrentFilename = progressobject.CurrentFilename;
			if (progressobject.BentoWorking) busyform.BentoMode = true;
		}

		public bool CancelProcessing {
			set { bgAACEncoder.CancelAsync(); }
		}

		private void btnClear_Click (object sender, EventArgs e) {
			FileList.Clear();
			dgvFiles.Refresh();

		}

		private void cboBitRate_SelectedIndexChanged (object sender, EventArgs e) {
			BitRate = ParsetoInt(cboBitRate.SelectedItem.ToString());
		}
		private void cboQuantizer_SelectedIndexChanged (object sender, EventArgs e) {
			Quantizer = ParsetoInt(cboQuantizer.SelectedItem.ToString());
		}
		public int PlayerUpdate {
			get { return _PlayerUpdate; }
			set {
				_PlayerUpdate = value;


			}
		}
		public void MPlayerPlay (int row) {
			if (row < 0) return;
			if (PlayerUpdate != 2) {
				if (MediaPlayer != null) MediaPlayer.Stop();
				FileEntryClass RowFile = (FileEntryClass)dgvFiles.Rows[row].DataBoundItem;
				MediaPlayer = new PlayerClass(this, RowFile.FilePath);
			}
			MediaPlayer.play();
		}


		private void MPlayerPause () {
			if (MediaPlayer == null) return;
			MediaPlayer.Pause();
		}

		private void MPlayerStop () {
			if (MediaPlayer == null) return;
			MediaPlayer.Stop();
			MediaPlayer = null;
		}

		private void dgvFiles_CellContentClick (object sender, DataGridViewCellEventArgs e) {
			//if (e.ColumnIndex ==0)
			if (e.ColumnIndex == 3) MPlayerPlay(e.RowIndex);
			if (e.ColumnIndex == 4) MPlayerStop();
			if (e.ColumnIndex == 1) ChangeSort(true, e.RowIndex);
			if (e.ColumnIndex == 2) ChangeSort(false, e.RowIndex);
			if (e.ColumnIndex == 0) DelItem(e.RowIndex);
		}

		//up=0 moving down, up = 1 moving up
		private void ChangeSort (bool up, int RowIndex) {
			//escape out if its row 0 going up or last row going down
			if (RowIndex == 0 && up) return;
			if (RowIndex == dgvFiles.Rows.Count - 1 && !up) return;

			//setup the sort values
			AssignSortVal();

			

			int switchrow;
			if (up) { switchrow = RowIndex - 1; } else { switchrow = RowIndex + 1; }

			int thirdhand;

			FileEntryClass moving_row = (FileEntryClass)dgvFiles.Rows[RowIndex].DataBoundItem;
			FileEntryClass other_row = (FileEntryClass)dgvFiles.Rows[switchrow].DataBoundItem;

			thirdhand = moving_row.AdHocSort;
			moving_row.AdHocSort = other_row.AdHocSort;
			other_row.AdHocSort = thirdhand;


			dgvFiles.Sort(dgvFiles.Columns["AdHocSort"], ListSortDirection.Ascending);
			dgvRowSelected = switchrow;

		}
		//assigns the adhoc sort values, ran each time a sortup/down is clicked
		private void AssignSortVal () {
			for (int x = 0; x < dgvFiles.Rows.Count; x++) {
				FileEntryClass item = (FileEntryClass)dgvFiles.Rows[x].DataBoundItem;
				item.AdHocSort = x;
			}
		}

		private void DelItem (int RowIndex) {
			if (dgvRowSelected == -1) return; 
			FileEntryClass removeitem = (FileEntryClass)dgvFiles.Rows[RowIndex].DataBoundItem;

				FileList.Remove(removeitem);
			dgvFiles.Refresh();

		}

		private void btnDelItem_Click (object sender, EventArgs e) {
			DelItem(dgvRowSelected);
		}

		private void cboUseTNS_SelectedIndexChanged (object sender, EventArgs e) {
			UseTNS = cboUseTNS.SelectedIndex;
		}

		private void btnallchapters_Click (object sender, EventArgs e) {
			SetAllChapters();
		}

		private void btnCopyTitles_Click (object sender, EventArgs e) {
			UpdateChapterTitlesfromMp3();
		}

		private void btnSave_Click (object sender, EventArgs e) {
			SaveProject();
		}
		private void SaveProject () {
			if (sfdProject.ShowDialog() == DialogResult.OK && sfdProject.FileName != null) {
				AssignSortVal();
				ProjectXml filesave = new ProjectXml(sfdProject.FileName);
				filesave.Write(FileList, OutputTags);
			}
		}
		private void LoadProject () {
			if (ofdProject.ShowDialog() == DialogResult.OK && ofdProject.FileName != null) {
				ProjectXml fileread = new ProjectXml(ofdProject.FileName);
				fileread.Read(out FileList, out OutputTags);
				UpdateTextOutput();
				GenDGV();
				dgvFiles.Sort(dgvFiles.Columns["AdHocSort"], ListSortDirection.Ascending);
				picOutput.Image = Utility.ResizeImage(Utility.BytestoImg(OutputTags.Image), 130, 130);
				//dgvFiles.Refresh();
			}

		}

		private void btnLoad_Click (object sender, EventArgs e) {
			LoadProject();
		}

		private void openProjectToolStripMenuItem_Click (object sender, EventArgs e) {
			LoadProject();
		}

		private void saveProjectToolStripMenuItem_Click (object sender, EventArgs e) {
			SaveProject();
		}

		private void addFilesToolStripMenuItem_Click (object sender, EventArgs e) {
			AddFiles();
		}

		private void browseOutputToolStripMenuItem_Click (object sender, EventArgs e) {
			if (sfdOutput.ShowDialog() == DialogResult.OK && sfdOutput.FileName != null)
				txtoutputfile.Text = sfdOutput.FileName;
		}

		private void startConversionToolStripMenuItem_Click (object sender, EventArgs e) {
			StartConversion();
		}
	}
}
