namespace AudioBookConverter {
	partial class AudioBookConverterMain {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent () {
			this.dgvFiles = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.ofdAdd = new System.Windows.Forms.OpenFileDialog();
			this.sfdOutput = new System.Windows.Forms.SaveFileDialog();
			this.bgAACEncoder = new System.ComponentModel.BackgroundWorker();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnDelItem = new System.Windows.Forms.Button();
			this.btnSort = new System.Windows.Forms.Button();
			this.radFileName = new System.Windows.Forms.RadioButton();
			this.radTitle = new System.Windows.Forms.RadioButton();
			this.radTrack = new System.Windows.Forms.RadioButton();
			this.GrpSort = new System.Windows.Forms.GroupBox();
			this.Other = new System.Windows.Forms.TabPage();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.txtComposerSort = new System.Windows.Forms.TextBox();
			this.txtAlbumSort = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txtTitleSort = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.txtComposer = new System.Windows.Forms.TextBox();
			this.txtArtistSort = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cboUseTNS = new System.Windows.Forms.ComboBox();
			this.cboQuantizer = new System.Windows.Forms.ComboBox();
			this.cboBitRate = new System.Windows.Forms.ComboBox();
			this.General = new System.Windows.Forms.TabPage();
			this.btnImageFinder = new System.Windows.Forms.Button();
			this.CopyMetadata = new System.Windows.Forms.LinkLabel();
			this.picOutput = new System.Windows.Forms.PictureBox();
			this.txtYear = new System.Windows.Forms.TextBox();
			this.txtoutputfile = new System.Windows.Forms.TextBox();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.txtDiscTotal = new System.Windows.Forms.TextBox();
			this.txtAlbum = new System.Windows.Forms.TextBox();
			this.txtTrackTotal = new System.Windows.Forms.TextBox();
			this.txtArtist = new System.Windows.Forms.TextBox();
			this.txtTrack = new System.Windows.Forms.TextBox();
			this.txtDisc = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSaveFile = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.tcOutputFields = new System.Windows.Forms.TabControl();
			this.btnallchapters = new System.Windows.Forms.Button();
			this.btnCopyTitles = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.ofdProject = new System.Windows.Forms.OpenFileDialog();
			this.sfdProject = new System.Windows.Forms.SaveFileDialog();
			this.btnLoadProject = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.browseOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startConversionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
			this.panel1.SuspendLayout();
			this.GrpSort.SuspendLayout();
			this.Other.SuspendLayout();
			this.General.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picOutput)).BeginInit();
			this.tcOutputFields.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvFiles
			// 
			this.dgvFiles.AllowUserToOrderColumns = true;
			this.dgvFiles.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvFiles.Location = new System.Drawing.Point(0, 0);
			this.dgvFiles.MultiSelect = false;
			this.dgvFiles.Name = "dgvFiles";
			this.dgvFiles.RowHeadersVisible = false;
			this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvFiles.Size = new System.Drawing.Size(751, 355);
			this.dgvFiles.TabIndex = 0;
			this.dgvFiles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiles_CellContentClick);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.dgvFiles);
			this.panel1.Location = new System.Drawing.Point(6, 28);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(751, 355);
			this.panel1.TabIndex = 1;
			// 
			// btnStart
			// 
			this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnStart.Location = new System.Drawing.Point(17, 562);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(103, 23);
			this.btnStart.TabIndex = 3;
			this.btnStart.Text = "Begin Conversion";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(778, 562);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(84, 23);
			this.btnClose.TabIndex = 4;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// ofdAdd
			// 
			this.ofdAdd.Filter = "MP3 Files|*.mp3";
			this.ofdAdd.Multiselect = true;
			this.ofdAdd.Title = "Select MP3 files to add";
			// 
			// sfdOutput
			// 
			this.sfdOutput.DefaultExt = "m4b";
			this.sfdOutput.Filter = "AudioBook|*.m4b";
			this.sfdOutput.Title = "Select Ouput File";
			// 
			// bgAACEncoder
			// 
			this.bgAACEncoder.WorkerReportsProgress = true;
			this.bgAACEncoder.WorkerSupportsCancellation = true;
			this.bgAACEncoder.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgAACEncoder_DoWork);
			this.bgAACEncoder.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgAACEncoder_Finished);
			this.bgAACEncoder.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgAACEncoder_ProgressUpdate);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Location = new System.Drawing.Point(769, 26);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(91, 23);
			this.btnAdd.TabIndex = 5;
			this.btnAdd.Text = "Add Files";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClear.Location = new System.Drawing.Point(770, 56);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(91, 23);
			this.btnClear.TabIndex = 9;
			this.btnClear.Text = "Clear List";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnDelItem
			// 
			this.btnDelItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelItem.Location = new System.Drawing.Point(769, 85);
			this.btnDelItem.Name = "btnDelItem";
			this.btnDelItem.Size = new System.Drawing.Size(91, 23);
			this.btnDelItem.TabIndex = 17;
			this.btnDelItem.Text = "Remove";
			this.btnDelItem.UseVisualStyleBackColor = true;
			this.btnDelItem.Click += new System.EventHandler(this.btnDelItem_Click);
			// 
			// btnSort
			// 
			this.btnSort.Location = new System.Drawing.Point(6, 89);
			this.btnSort.Name = "btnSort";
			this.btnSort.Size = new System.Drawing.Size(86, 23);
			this.btnSort.TabIndex = 10;
			this.btnSort.Text = "Sort";
			this.btnSort.UseVisualStyleBackColor = true;
			this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
			// 
			// radFileName
			// 
			this.radFileName.AutoSize = true;
			this.radFileName.Location = new System.Drawing.Point(7, 20);
			this.radFileName.Name = "radFileName";
			this.radFileName.Size = new System.Drawing.Size(69, 17);
			this.radFileName.TabIndex = 11;
			this.radFileName.TabStop = true;
			this.radFileName.Text = "FileName";
			this.radFileName.UseVisualStyleBackColor = true;
			// 
			// radTitle
			// 
			this.radTitle.AutoSize = true;
			this.radTitle.Location = new System.Drawing.Point(7, 43);
			this.radTitle.Name = "radTitle";
			this.radTitle.Size = new System.Drawing.Size(45, 17);
			this.radTitle.TabIndex = 11;
			this.radTitle.TabStop = true;
			this.radTitle.Text = "Title";
			this.radTitle.UseVisualStyleBackColor = true;
			// 
			// radTrack
			// 
			this.radTrack.AutoSize = true;
			this.radTrack.Location = new System.Drawing.Point(7, 66);
			this.radTrack.Name = "radTrack";
			this.radTrack.Size = new System.Drawing.Size(63, 17);
			this.radTrack.TabIndex = 11;
			this.radTrack.TabStop = true;
			this.radTrack.Text = "Track #";
			this.radTrack.UseVisualStyleBackColor = true;
			// 
			// GrpSort
			// 
			this.GrpSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.GrpSort.Controls.Add(this.radTrack);
			this.GrpSort.Controls.Add(this.radTitle);
			this.GrpSort.Controls.Add(this.radFileName);
			this.GrpSort.Controls.Add(this.btnSort);
			this.GrpSort.Location = new System.Drawing.Point(764, 222);
			this.GrpSort.Name = "GrpSort";
			this.GrpSort.Size = new System.Drawing.Size(98, 118);
			this.GrpSort.TabIndex = 11;
			this.GrpSort.TabStop = false;
			this.GrpSort.Text = "Sort Option";
			// 
			// Other
			// 
			this.Other.BackColor = System.Drawing.SystemColors.Control;
			this.Other.Controls.Add(this.label15);
			this.Other.Controls.Add(this.label14);
			this.Other.Controls.Add(this.txtComposerSort);
			this.Other.Controls.Add(this.txtAlbumSort);
			this.Other.Controls.Add(this.label13);
			this.Other.Controls.Add(this.txtTitleSort);
			this.Other.Controls.Add(this.label17);
			this.Other.Controls.Add(this.label16);
			this.Other.Controls.Add(this.label12);
			this.Other.Controls.Add(this.txtComment);
			this.Other.Controls.Add(this.txtComposer);
			this.Other.Controls.Add(this.txtArtistSort);
			this.Other.Controls.Add(this.label18);
			this.Other.Controls.Add(this.label9);
			this.Other.Controls.Add(this.label5);
			this.Other.Controls.Add(this.cboUseTNS);
			this.Other.Controls.Add(this.cboQuantizer);
			this.Other.Controls.Add(this.cboBitRate);
			this.Other.Location = new System.Drawing.Point(4, 22);
			this.Other.Name = "Other";
			this.Other.Padding = new System.Windows.Forms.Padding(3);
			this.Other.Size = new System.Drawing.Size(847, 141);
			this.Other.TabIndex = 1;
			this.Other.Text = "Other";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(6, 119);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(76, 13);
			this.label15.TabIndex = 3;
			this.label15.Text = "Composer Sort";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(24, 93);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(58, 13);
			this.label14.TabIndex = 3;
			this.label14.Text = "Album Sort";
			// 
			// txtComposerSort
			// 
			this.txtComposerSort.Location = new System.Drawing.Point(88, 116);
			this.txtComposerSort.Name = "txtComposerSort";
			this.txtComposerSort.Size = new System.Drawing.Size(237, 20);
			this.txtComposerSort.TabIndex = 2;
			this.txtComposerSort.TextChanged += new System.EventHandler(this.outputdetails_TextChanged);
			// 
			// txtAlbumSort
			// 
			this.txtAlbumSort.Location = new System.Drawing.Point(88, 90);
			this.txtAlbumSort.Name = "txtAlbumSort";
			this.txtAlbumSort.Size = new System.Drawing.Size(237, 20);
			this.txtAlbumSort.TabIndex = 2;
			this.txtAlbumSort.TextChanged += new System.EventHandler(this.outputdetails_TextChanged);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(33, 67);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(49, 13);
			this.label13.TabIndex = 3;
			this.label13.Text = "Title Sort";
			// 
			// txtTitleSort
			// 
			this.txtTitleSort.Location = new System.Drawing.Point(88, 64);
			this.txtTitleSort.Name = "txtTitleSort";
			this.txtTitleSort.Size = new System.Drawing.Size(237, 20);
			this.txtTitleSort.TabIndex = 2;
			this.txtTitleSort.TextChanged += new System.EventHandler(this.outputdetails_TextChanged);
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(340, 15);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(51, 13);
			this.label17.TabIndex = 3;
			this.label17.Text = "Comment";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(28, 15);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(54, 13);
			this.label16.TabIndex = 3;
			this.label16.Text = "Composer";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(30, 41);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(52, 13);
			this.label12.TabIndex = 3;
			this.label12.Text = "Artist Sort";
			// 
			// txtComment
			// 
			this.txtComment.Location = new System.Drawing.Point(397, 12);
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.Size = new System.Drawing.Size(223, 98);
			this.txtComment.TabIndex = 2;
			this.txtComment.TextChanged += new System.EventHandler(this.outputdetails_TextChanged);
			// 
			// txtComposer
			// 
			this.txtComposer.Location = new System.Drawing.Point(88, 12);
			this.txtComposer.Name = "txtComposer";
			this.txtComposer.Size = new System.Drawing.Size(237, 20);
			this.txtComposer.TabIndex = 2;
			this.txtComposer.TextChanged += new System.EventHandler(this.outputdetails_TextChanged);
			// 
			// txtArtistSort
			// 
			this.txtArtistSort.Location = new System.Drawing.Point(88, 38);
			this.txtArtistSort.Name = "txtArtistSort";
			this.txtArtistSort.Size = new System.Drawing.Size(237, 20);
			this.txtArtistSort.TabIndex = 2;
			this.txtArtistSort.TextChanged += new System.EventHandler(this.outputdetails_TextChanged);
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(735, 67);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(51, 13);
			this.label18.TabIndex = 1;
			this.label18.Text = "Use TNS";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(666, 39);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(120, 13);
			this.label9.TabIndex = 1;
			this.label9.Text = "Quantizer Quality Factor";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(661, 12);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(125, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "Bitrate Per Channel Kbps";
			// 
			// cboUseTNS
			// 
			this.cboUseTNS.FormattingEnabled = true;
			this.cboUseTNS.Items.AddRange(new object[] {
            "No",
            "Yes"});
			this.cboUseTNS.Location = new System.Drawing.Point(792, 63);
			this.cboUseTNS.Name = "cboUseTNS";
			this.cboUseTNS.Size = new System.Drawing.Size(42, 21);
			this.cboUseTNS.TabIndex = 0;
			this.cboUseTNS.SelectedValueChanged += new System.EventHandler(this.cboUseTNS_SelectedIndexChanged);
			// 
			// cboQuantizer
			// 
			this.cboQuantizer.FormattingEnabled = true;
			this.cboQuantizer.Items.AddRange(new object[] {
            "100",
            "90",
            "80",
            "70",
            "60",
            "50"});
			this.cboQuantizer.Location = new System.Drawing.Point(792, 36);
			this.cboQuantizer.Name = "cboQuantizer";
			this.cboQuantizer.Size = new System.Drawing.Size(42, 21);
			this.cboQuantizer.TabIndex = 0;
			this.cboQuantizer.SelectedValueChanged += new System.EventHandler(this.cboQuantizer_SelectedIndexChanged);
			// 
			// cboBitRate
			// 
			this.cboBitRate.FormattingEnabled = true;
			this.cboBitRate.Items.AddRange(new object[] {
            "64",
            "32",
            "16",
            "8"});
			this.cboBitRate.Location = new System.Drawing.Point(792, 9);
			this.cboBitRate.Name = "cboBitRate";
			this.cboBitRate.Size = new System.Drawing.Size(42, 21);
			this.cboBitRate.TabIndex = 0;
			this.cboBitRate.SelectedValueChanged += new System.EventHandler(this.cboBitRate_SelectedIndexChanged);
			// 
			// General
			// 
			this.General.BackColor = System.Drawing.SystemColors.Control;
			this.General.Controls.Add(this.btnImageFinder);
			this.General.Controls.Add(this.CopyMetadata);
			this.General.Controls.Add(this.picOutput);
			this.General.Controls.Add(this.txtYear);
			this.General.Controls.Add(this.txtoutputfile);
			this.General.Controls.Add(this.txtTitle);
			this.General.Controls.Add(this.txtDiscTotal);
			this.General.Controls.Add(this.txtAlbum);
			this.General.Controls.Add(this.txtTrackTotal);
			this.General.Controls.Add(this.txtArtist);
			this.General.Controls.Add(this.txtTrack);
			this.General.Controls.Add(this.txtDisc);
			this.General.Controls.Add(this.label6);
			this.General.Controls.Add(this.label1);
			this.General.Controls.Add(this.btnSaveFile);
			this.General.Controls.Add(this.label2);
			this.General.Controls.Add(this.label3);
			this.General.Controls.Add(this.label11);
			this.General.Controls.Add(this.label4);
			this.General.Controls.Add(this.label10);
			this.General.Controls.Add(this.label8);
			this.General.Controls.Add(this.label7);
			this.General.Location = new System.Drawing.Point(4, 22);
			this.General.Name = "General";
			this.General.Padding = new System.Windows.Forms.Padding(3);
			this.General.Size = new System.Drawing.Size(847, 141);
			this.General.TabIndex = 0;
			this.General.Text = "General";
			// 
			// btnImageFinder
			// 
			this.btnImageFinder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnImageFinder.Location = new System.Drawing.Point(633, 112);
			this.btnImageFinder.Name = "btnImageFinder";
			this.btnImageFinder.Size = new System.Drawing.Size(75, 23);
			this.btnImageFinder.TabIndex = 17;
			this.btnImageFinder.Text = "Find Artwork";
			this.btnImageFinder.UseVisualStyleBackColor = true;
			this.btnImageFinder.Click += new System.EventHandler(this.btnImageFinder_Click);
			// 
			// CopyMetadata
			// 
			this.CopyMetadata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.CopyMetadata.AutoSize = true;
			this.CopyMetadata.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.CopyMetadata.Location = new System.Drawing.Point(187, 122);
			this.CopyMetadata.Name = "CopyMetadata";
			this.CopyMetadata.Size = new System.Drawing.Size(204, 13);
			this.CopyMetadata.TabIndex = 16;
			this.CopyMetadata.TabStop = true;
			this.CopyMetadata.Text = "Copy Tag Data from Selected MP3 - Click";
			this.CopyMetadata.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CopyMetadata_LinkClicked);
			// 
			// picOutput
			// 
			this.picOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.picOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picOutput.Location = new System.Drawing.Point(714, 5);
			this.picOutput.Name = "picOutput";
			this.picOutput.Size = new System.Drawing.Size(130, 130);
			this.picOutput.TabIndex = 15;
			this.picOutput.TabStop = false;
			this.picOutput.Click += new System.EventHandler(this.picOutput_Click);
			// 
			// txtYear
			// 
			this.txtYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtYear.Location = new System.Drawing.Point(467, 35);
			this.txtYear.Name = "txtYear";
			this.txtYear.Size = new System.Drawing.Size(46, 20);
			this.txtYear.TabIndex = 14;
			this.txtYear.TextChanged += new System.EventHandler(this.outputdetails_TextChanged);
			// 
			// txtoutputfile
			// 
			this.txtoutputfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtoutputfile.Location = new System.Drawing.Point(102, 6);
			this.txtoutputfile.Name = "txtoutputfile";
			this.txtoutputfile.Size = new System.Drawing.Size(501, 20);
			this.txtoutputfile.TabIndex = 6;
			this.txtoutputfile.TextChanged += new System.EventHandler(this.outputdetails_TextChanged);
			// 
			// txtTitle
			// 
			this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTitle.Location = new System.Drawing.Point(69, 32);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(339, 20);
			this.txtTitle.TabIndex = 14;
			this.txtTitle.TextChanged += new System.EventHandler(this.outputdetails_TextChanged);
			// 
			// txtDiscTotal
			// 
			this.txtDiscTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDiscTotal.Location = new System.Drawing.Point(543, 87);
			this.txtDiscTotal.Name = "txtDiscTotal";
			this.txtDiscTotal.Size = new System.Drawing.Size(46, 20);
			this.txtDiscTotal.TabIndex = 14;
			this.txtDiscTotal.TextChanged += new System.EventHandler(this.outputdetails_TextChanged);
			// 
			// txtAlbum
			// 
			this.txtAlbum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAlbum.Location = new System.Drawing.Point(69, 58);
			this.txtAlbum.Name = "txtAlbum";
			this.txtAlbum.Size = new System.Drawing.Size(339, 20);
			this.txtAlbum.TabIndex = 14;
			this.txtAlbum.TextChanged += new System.EventHandler(this.outputdetails_TextChanged);
			// 
			// txtTrackTotal
			// 
			this.txtTrackTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTrackTotal.Location = new System.Drawing.Point(543, 61);
			this.txtTrackTotal.Name = "txtTrackTotal";
			this.txtTrackTotal.Size = new System.Drawing.Size(46, 20);
			this.txtTrackTotal.TabIndex = 14;
			this.txtTrackTotal.TextChanged += new System.EventHandler(this.outputdetails_TextChanged);
			// 
			// txtArtist
			// 
			this.txtArtist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtArtist.Location = new System.Drawing.Point(69, 84);
			this.txtArtist.Name = "txtArtist";
			this.txtArtist.Size = new System.Drawing.Size(339, 20);
			this.txtArtist.TabIndex = 14;
			this.txtArtist.TextChanged += new System.EventHandler(this.outputdetails_TextChanged);
			// 
			// txtTrack
			// 
			this.txtTrack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTrack.Location = new System.Drawing.Point(467, 61);
			this.txtTrack.Name = "txtTrack";
			this.txtTrack.Size = new System.Drawing.Size(46, 20);
			this.txtTrack.TabIndex = 14;
			this.txtTrack.TextChanged += new System.EventHandler(this.outputdetails_TextChanged);
			// 
			// txtDisc
			// 
			this.txtDisc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDisc.Location = new System.Drawing.Point(467, 87);
			this.txtDisc.Name = "txtDisc";
			this.txtDisc.Size = new System.Drawing.Size(46, 20);
			this.txtDisc.TabIndex = 14;
			this.txtDisc.TextChanged += new System.EventHandler(this.outputdetails_TextChanged);
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(431, 38);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(29, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "Year";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Output Filename:";
			// 
			// btnSaveFile
			// 
			this.btnSaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveFile.Location = new System.Drawing.Point(609, 3);
			this.btnSaveFile.Name = "btnSaveFile";
			this.btnSaveFile.Size = new System.Drawing.Size(75, 23);
			this.btnSaveFile.TabIndex = 7;
			this.btnSaveFile.Text = "Browse";
			this.btnSaveFile.UseVisualStyleBackColor = true;
			this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(36, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(27, 13);
			this.label2.TabIndex = 13;
			this.label2.Text = "Title";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(27, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(36, 13);
			this.label3.TabIndex = 13;
			this.label3.Text = "Album";
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(519, 90);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(18, 13);
			this.label11.TabIndex = 13;
			this.label11.Text = "Of";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(33, 90);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 13);
			this.label4.TabIndex = 13;
			this.label4.Text = "Artist";
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(519, 64);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(18, 13);
			this.label10.TabIndex = 13;
			this.label10.Text = "Of";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(431, 90);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(28, 13);
			this.label8.TabIndex = 13;
			this.label8.Text = "Disc";
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(431, 64);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(35, 13);
			this.label7.TabIndex = 13;
			this.label7.Text = "Track";
			// 
			// tcOutputFields
			// 
			this.tcOutputFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tcOutputFields.Controls.Add(this.General);
			this.tcOutputFields.Controls.Add(this.Other);
			this.tcOutputFields.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
			this.tcOutputFields.Location = new System.Drawing.Point(6, 389);
			this.tcOutputFields.Name = "tcOutputFields";
			this.tcOutputFields.SelectedIndex = 0;
			this.tcOutputFields.Size = new System.Drawing.Size(855, 167);
			this.tcOutputFields.TabIndex = 16;
			this.tcOutputFields.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tcOutputFields_DrawItem);
			// 
			// btnallchapters
			// 
			this.btnallchapters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnallchapters.Location = new System.Drawing.Point(771, 144);
			this.btnallchapters.Name = "btnallchapters";
			this.btnallchapters.Size = new System.Drawing.Size(91, 23);
			this.btnallchapters.TabIndex = 18;
			this.btnallchapters.Text = "All Files Chapter";
			this.btnallchapters.UseVisualStyleBackColor = true;
			this.btnallchapters.Click += new System.EventHandler(this.btnallchapters_Click);
			// 
			// btnCopyTitles
			// 
			this.btnCopyTitles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCopyTitles.Location = new System.Drawing.Point(771, 173);
			this.btnCopyTitles.Name = "btnCopyTitles";
			this.btnCopyTitles.Size = new System.Drawing.Size(91, 23);
			this.btnCopyTitles.TabIndex = 18;
			this.btnCopyTitles.Text = "Title -> Chapter";
			this.btnCopyTitles.UseVisualStyleBackColor = true;
			this.btnCopyTitles.Click += new System.EventHandler(this.btnCopyTitles_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(259, 562);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(84, 23);
			this.btnSave.TabIndex = 19;
			this.btnSave.Text = "Save Project";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// ofdProject
			// 
			this.ofdProject.DefaultExt = "xml";
			this.ofdProject.Filter = "ProjectFiles|*.xml";
			this.ofdProject.Title = "Open and Existing Project";
			// 
			// sfdProject
			// 
			this.sfdProject.DefaultExt = "xml";
			this.sfdProject.Filter = "ProjectFiles|*.xml";
			this.sfdProject.Title = "Save Project";
			// 
			// btnLoadProject
			// 
			this.btnLoadProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLoadProject.Location = new System.Drawing.Point(362, 562);
			this.btnLoadProject.Name = "btnLoadProject";
			this.btnLoadProject.Size = new System.Drawing.Size(84, 23);
			this.btnLoadProject.TabIndex = 19;
			this.btnLoadProject.Text = "Load Project";
			this.btnLoadProject.UseVisualStyleBackColor = true;
			this.btnLoadProject.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(873, 24);
			this.menuStrip1.TabIndex = 20;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.addFilesToolStripMenuItem,
            this.browseOutputToolStripMenuItem,
            this.startConversionToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openProjectToolStripMenuItem
			// 
			this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
			this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.openProjectToolStripMenuItem.Text = "Open Project";
			this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
			// 
			// saveProjectToolStripMenuItem
			// 
			this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
			this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.saveProjectToolStripMenuItem.Text = "Save Project";
			this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
			// 
			// addFilesToolStripMenuItem
			// 
			this.addFilesToolStripMenuItem.Name = "addFilesToolStripMenuItem";
			this.addFilesToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.addFilesToolStripMenuItem.Text = "Add Files";
			this.addFilesToolStripMenuItem.Click += new System.EventHandler(this.addFilesToolStripMenuItem_Click);
			// 
			// browseOutputToolStripMenuItem
			// 
			this.browseOutputToolStripMenuItem.Name = "browseOutputToolStripMenuItem";
			this.browseOutputToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.browseOutputToolStripMenuItem.Text = "Browse Output";
			this.browseOutputToolStripMenuItem.Click += new System.EventHandler(this.browseOutputToolStripMenuItem_Click);
			// 
			// startConversionToolStripMenuItem
			// 
			this.startConversionToolStripMenuItem.Name = "startConversionToolStripMenuItem";
			this.startConversionToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.startConversionToolStripMenuItem.Text = "Start Conversion";
			this.startConversionToolStripMenuItem.Click += new System.EventHandler(this.startConversionToolStripMenuItem_Click);
			// 
			// AudioBookConverterMain
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(873, 597);
			this.Controls.Add(this.btnLoadProject);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnCopyTitles);
			this.Controls.Add(this.btnallchapters);
			this.Controls.Add(this.btnDelItem);
			this.Controls.Add(this.tcOutputFields);
			this.Controls.Add(this.GrpSort);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "AudioBookConverterMain";
			this.Text = "AudioBook Converter";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ABC_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ABC_DragEnter);
			((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
			this.panel1.ResumeLayout(false);
			this.GrpSort.ResumeLayout(false);
			this.GrpSort.PerformLayout();
			this.Other.ResumeLayout(false);
			this.Other.PerformLayout();
			this.General.ResumeLayout(false);
			this.General.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picOutput)).EndInit();
			this.tcOutputFields.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvFiles;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.OpenFileDialog ofdAdd;
		private System.Windows.Forms.SaveFileDialog sfdOutput;
		public System.ComponentModel.BackgroundWorker bgAACEncoder;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnDelItem;
		private System.Windows.Forms.Button btnSort;
		private System.Windows.Forms.RadioButton radFileName;
		private System.Windows.Forms.RadioButton radTitle;
		private System.Windows.Forms.RadioButton radTrack;
		private System.Windows.Forms.GroupBox GrpSort;
		private System.Windows.Forms.TabPage Other;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cboQuantizer;
		private System.Windows.Forms.ComboBox cboBitRate;
		private System.Windows.Forms.TabPage General;
		private System.Windows.Forms.Button btnImageFinder;
		private System.Windows.Forms.LinkLabel CopyMetadata;
		private System.Windows.Forms.PictureBox picOutput;
		private System.Windows.Forms.TextBox txtYear;
		private System.Windows.Forms.TextBox txtoutputfile;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.TextBox txtDiscTotal;
		private System.Windows.Forms.TextBox txtAlbum;
		private System.Windows.Forms.TextBox txtTrackTotal;
		private System.Windows.Forms.TextBox txtArtist;
		private System.Windows.Forms.TextBox txtTrack;
		private System.Windows.Forms.TextBox txtDisc;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSaveFile;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TabControl tcOutputFields;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtComposerSort;
		private System.Windows.Forms.TextBox txtAlbumSort;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtTitleSort;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtComposer;
		private System.Windows.Forms.TextBox txtArtistSort;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox txtComment;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.ComboBox cboUseTNS;
		private System.Windows.Forms.Button btnallchapters;
		private System.Windows.Forms.Button btnCopyTitles;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.OpenFileDialog ofdProject;
		private System.Windows.Forms.SaveFileDialog sfdProject;
		private System.Windows.Forms.Button btnLoadProject;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addFilesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem browseOutputToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem startConversionToolStripMenuItem;
	}
}