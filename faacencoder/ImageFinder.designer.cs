namespace AudioBookConverter
{
	partial class ImageFinder
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.picimgpreview = new System.Windows.Forms.PictureBox();
			this.lstimgfiles = new System.Windows.Forms.ListBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.lblartistalbum = new System.Windows.Forms.Label();
			this.lblorigres = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnok = new System.Windows.Forms.Button();
			this.btnOpenPic = new System.Windows.Forms.Button();
			this.btnGoogleImages = new System.Windows.Forms.Button();
			this.btnalbumartorg = new System.Windows.Forms.Button();
			this.lblInetStatus = new System.Windows.Forms.Label();
			this.nudgpage = new System.Windows.Forms.NumericUpDown();
			this.LLeditsearch = new System.Windows.Forms.LinkLabel();
			this.ofd1 = new System.Windows.Forms.OpenFileDialog();
			this.fldb1 = new System.Windows.Forms.FolderBrowserDialog();
			((System.ComponentModel.ISupportInitialize)(this.picimgpreview)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudgpage)).BeginInit();
			this.SuspendLayout();
			// 
			// picimgpreview
			// 
			this.picimgpreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.picimgpreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picimgpreview.Location = new System.Drawing.Point(382, 60);
			this.picimgpreview.Name = "picimgpreview";
			this.picimgpreview.Size = new System.Drawing.Size(300, 300);
			this.picimgpreview.TabIndex = 0;
			this.picimgpreview.TabStop = false;
			// 
			// lstimgfiles
			// 
			this.lstimgfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lstimgfiles.FormattingEnabled = true;
			this.lstimgfiles.HorizontalScrollbar = true;
			this.lstimgfiles.Location = new System.Drawing.Point(18, 60);
			this.lstimgfiles.Name = "lstimgfiles";
			this.lstimgfiles.Size = new System.Drawing.Size(301, 303);
			this.lstimgfiles.TabIndex = 2;
			this.lstimgfiles.SelectedIndexChanged += new System.EventHandler(this.lstimgfiles_SelectedIndexChanged);
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(16, 23);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(104, 13);
			this.Label1.TabIndex = 5;
			this.Label1.Text = "Possible Images For:";
			// 
			// lblartistalbum
			// 
			this.lblartistalbum.AutoSize = true;
			this.lblartistalbum.Location = new System.Drawing.Point(19, 41);
			this.lblartistalbum.Name = "lblartistalbum";
			this.lblartistalbum.Size = new System.Drawing.Size(10, 13);
			this.lblartistalbum.TabIndex = 10;
			this.lblartistalbum.Text = "-";
			// 
			// lblorigres
			// 
			this.lblorigres.AutoSize = true;
			this.lblorigres.Location = new System.Drawing.Point(360, 42);
			this.lblorigres.Name = "lblorigres";
			this.lblorigres.Size = new System.Drawing.Size(98, 13);
			this.lblorigres.TabIndex = 12;
			this.lblorigres.Text = "Original Resolution:";
			// 
			// Label2
			// 
			this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(78, 417);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(65, 13);
			this.Label2.TabIndex = 14;
			this.Label2.Text = "Result Page";
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(584, 426);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(90, 23);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Cancel";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnok
			// 
			this.btnok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnok.Location = new System.Drawing.Point(488, 426);
			this.btnok.Name = "btnok";
			this.btnok.Size = new System.Drawing.Size(90, 23);
			this.btnok.TabIndex = 3;
			this.btnok.Text = "Ok";
			this.btnok.UseVisualStyleBackColor = true;
			this.btnok.Click += new System.EventHandler(this.btnok_Click);
			// 
			// btnOpenPic
			// 
			this.btnOpenPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpenPic.Location = new System.Drawing.Point(592, 366);
			this.btnOpenPic.Name = "btnOpenPic";
			this.btnOpenPic.Size = new System.Drawing.Size(90, 23);
			this.btnOpenPic.TabIndex = 7;
			this.btnOpenPic.Text = "Open Image";
			this.btnOpenPic.UseVisualStyleBackColor = true;
			this.btnOpenPic.Click += new System.EventHandler(this.btnOpenPic_Click);
			// 
			// btnGoogleImages
			// 
			this.btnGoogleImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGoogleImages.Location = new System.Drawing.Point(20, 376);
			this.btnGoogleImages.Name = "btnGoogleImages";
			this.btnGoogleImages.Size = new System.Drawing.Size(90, 23);
			this.btnGoogleImages.TabIndex = 8;
			this.btnGoogleImages.Text = "Google Images";
			this.btnGoogleImages.UseVisualStyleBackColor = true;
			this.btnGoogleImages.Click += new System.EventHandler(this.btnGoogleImages_Click);
			// 
			// btnalbumartorg
			// 
			this.btnalbumartorg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnalbumartorg.Location = new System.Drawing.Point(117, 376);
			this.btnalbumartorg.Name = "btnalbumartorg";
			this.btnalbumartorg.Size = new System.Drawing.Size(90, 23);
			this.btnalbumartorg.TabIndex = 8;
			this.btnalbumartorg.Text = "AlbumArt.org Search";
			this.btnalbumartorg.UseVisualStyleBackColor = true;
			this.btnalbumartorg.Click += new System.EventHandler(this.btnalbumartorg_Click);
			// 
			// lblInetStatus
			// 
			this.lblInetStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblInetStatus.AutoSize = true;
			this.lblInetStatus.Location = new System.Drawing.Point(415, 401);
			this.lblInetStatus.Name = "lblInetStatus";
			this.lblInetStatus.Size = new System.Drawing.Size(0, 13);
			this.lblInetStatus.TabIndex = 11;
			// 
			// nudgpage
			// 
			this.nudgpage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.nudgpage.Location = new System.Drawing.Point(145, 415);
			this.nudgpage.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudgpage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudgpage.Name = "nudgpage";
			this.nudgpage.Size = new System.Drawing.Size(29, 20);
			this.nudgpage.TabIndex = 13;
			this.nudgpage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// LLeditsearch
			// 
			this.LLeditsearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LLeditsearch.AutoSize = true;
			this.LLeditsearch.Location = new System.Drawing.Point(234, 381);
			this.LLeditsearch.Name = "LLeditsearch";
			this.LLeditsearch.Size = new System.Drawing.Size(94, 13);
			this.LLeditsearch.TabIndex = 15;
			this.LLeditsearch.TabStop = true;
			this.LLeditsearch.Text = "Edit Search Terms";
			this.LLeditsearch.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLeditsearch_LinkClicked);
			// 
			// ofd1
			// 
			this.ofd1.Filter = "Images|*.jpg;*.jpeg;*.gif;*.png;*.bmp";
			this.ofd1.Title = "Select an Image";
			// 
			// fldb1
			// 
			this.fldb1.Description = "Select a Path to Display in TreeView";
			this.fldb1.ShowNewFolderButton = false;
			// 
			// ImageFinder
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(694, 470);
			this.Controls.Add(this.LLeditsearch);
			this.Controls.Add(this.lstimgfiles);
			this.Controls.Add(this.nudgpage);
			this.Controls.Add(this.lblorigres);
			this.Controls.Add(this.lblInetStatus);
			this.Controls.Add(this.picimgpreview);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.btnalbumartorg);
			this.Controls.Add(this.lblartistalbum);
			this.Controls.Add(this.btnGoogleImages);
			this.Controls.Add(this.btnOpenPic);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnok);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "ImageFinder";
			this.Text = "ImageFinder";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.TagzImageFinder_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.TagzImageFinder_DragEnter);
			((System.ComponentModel.ISupportInitialize)(this.picimgpreview)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudgpage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.PictureBox picimgpreview;
		internal System.Windows.Forms.ListBox lstimgfiles;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label lblartistalbum;
		internal System.Windows.Forms.Label lblorigres;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Button btnClose;
		internal System.Windows.Forms.Button btnok;
		internal System.Windows.Forms.Button btnOpenPic;
		internal System.Windows.Forms.Button btnGoogleImages;
		internal System.Windows.Forms.Button btnalbumartorg;
		internal System.Windows.Forms.Label lblInetStatus;
		internal System.Windows.Forms.NumericUpDown nudgpage;
		internal System.Windows.Forms.LinkLabel LLeditsearch;
		private System.Windows.Forms.OpenFileDialog ofd1;
		private System.Windows.Forms.FolderBrowserDialog fldb1;
	}
}