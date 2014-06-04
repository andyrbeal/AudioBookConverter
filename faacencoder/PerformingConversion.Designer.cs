namespace AudioBookConverter {
	partial class PerformingConversion {
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
			this.lblMain = new System.Windows.Forms.Label();
			this.lblFileProgress = new System.Windows.Forms.Label();
			this.pbFileConversion = new System.Windows.Forms.ProgressBar();
			this.lblFile = new System.Windows.Forms.Label();
			this.pbTotalFiles = new System.Windows.Forms.ProgressBar();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblMain
			// 
			this.lblMain.AutoSize = true;
			this.lblMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMain.Location = new System.Drawing.Point(194, 27);
			this.lblMain.Name = "lblMain";
			this.lblMain.Size = new System.Drawing.Size(169, 20);
			this.lblMain.TabIndex = 0;
			this.lblMain.Text = "Performing Conversion";
			// 
			// lblFileProgress
			// 
			this.lblFileProgress.AutoSize = true;
			this.lblFileProgress.Location = new System.Drawing.Point(33, 133);
			this.lblFileProgress.Name = "lblFileProgress";
			this.lblFileProgress.Size = new System.Drawing.Size(71, 13);
			this.lblFileProgress.TabIndex = 1;
			this.lblFileProgress.Text = "File 0 of Total";
			// 
			// pbFileConversion
			// 
			this.pbFileConversion.Location = new System.Drawing.Point(36, 90);
			this.pbFileConversion.Name = "pbFileConversion";
			this.pbFileConversion.Size = new System.Drawing.Size(510, 23);
			this.pbFileConversion.TabIndex = 2;
			// 
			// lblFile
			// 
			this.lblFile.AutoSize = true;
			this.lblFile.Location = new System.Drawing.Point(33, 63);
			this.lblFile.Name = "lblFile";
			this.lblFile.Size = new System.Drawing.Size(49, 13);
			this.lblFile.TabIndex = 3;
			this.lblFile.Text = "Filename";
			// 
			// pbTotalFiles
			// 
			this.pbTotalFiles.Location = new System.Drawing.Point(36, 159);
			this.pbTotalFiles.Name = "pbTotalFiles";
			this.pbTotalFiles.Size = new System.Drawing.Size(510, 23);
			this.pbTotalFiles.TabIndex = 4;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(420, 206);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(148, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel Process";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// PerformingConversion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(580, 241);
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.pbTotalFiles);
			this.Controls.Add(this.lblFile);
			this.Controls.Add(this.pbFileConversion);
			this.Controls.Add(this.lblFileProgress);
			this.Controls.Add(this.lblMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "PerformingConversion";
			this.Text = "PerformingConversion";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblMain;
		private System.Windows.Forms.Label lblFileProgress;
		private System.Windows.Forms.ProgressBar pbFileConversion;
		private System.Windows.Forms.Label lblFile;
		private System.Windows.Forms.ProgressBar pbTotalFiles;
		private System.Windows.Forms.Button btnCancel;
	}
}