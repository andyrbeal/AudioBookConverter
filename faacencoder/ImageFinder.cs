using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Security.Cryptography;


namespace AudioBookConverter
{
	public partial class ImageFinder : Form
	{
		//ClassWideVars
		private string searchstring = null;
		
		//CallingForm sets Mainform = this  before opening, setting object reference
		
		
		//Main list of images, including cached images

		List<ImageData> ImgSelect = new List<ImageData>();
		private AudioBookConverterMain MainForm;

		public ImageFinder(AudioBookConverterMain form)
		{
			
			InitializeComponent();
			MainForm = form;

			picimgpreview.Image = null;
			lblartistalbum.Text = MainForm.GetArtistName  + " - " + MainForm.GetAlbumName;

			//MyTreeView.Nodes[0].Expand();
			lblorigres.Text = "Original Resolution:";
			searchstring = MainForm.GetArtistName + " " + MainForm.GetAlbumName;
			if (searchstring.Replace(" ", "").Length == 0) searchstring = MainForm.GetTitle;
			//ImgSelect = new List<ImageData>();
			CurrentImages();
		}

		public void CurrentImages () {

			if (MainForm.ArtWork != null) {
				ImageData imageinfo = new ImageData();

				imageinfo.path = "Current";
				imageinfo.source = "current";
				imageinfo.name = "Current";
				imageinfo.image = MainForm.ArtWork;
				imageinfo.imagehash = new MD5CryptoServiceProvider().ComputeHash(imageinfo.image);
				ImgSelect.Add(imageinfo);
				lstimgfiles.Items.Add(imageinfo.name);

			}

			foreach (FileEntryClass fileitem in MainForm.ROFileList)
				if (fileitem.Picture != null) {

					if (!SearchDuplicateImages(fileitem.Picture)) {
						ImageData imageinfo = new ImageData();

						imageinfo.path = "FileList";
						imageinfo.source = "FileList";
						imageinfo.name = fileitem.FileName;
						imageinfo.image = Utility.ImgtoBytes(Utility.ResizeImage(Utility.BytestoImg(fileitem.Picture),300,300));
						imageinfo.imagehash = new MD5CryptoServiceProvider().ComputeHash(fileitem.Picture);
						ImgSelect.Add(imageinfo);
						lstimgfiles.Items.Add(imageinfo.name);
					}
				}

		}

		private bool SearchDuplicateImages (byte[] newimg) {
			bool duplicate = false;
			byte[] newimagehash = new MD5CryptoServiceProvider().ComputeHash(newimg);
			foreach (ImageData currentimage in ImgSelect) {
				for (int x = 0; x < newimagehash.Length; x++)
					if (newimagehash[x] != currentimage.imagehash[x]) {
						duplicate = false;
						break;
					}
					else { duplicate = true; }
			}
			
			
			
			return duplicate;

		}

		public string EditSearchString {
			get { return searchstring; }
			set { searchstring = value; }
		}




		private ImageData ImageParse(string path, string source) {
			ImageData imageinfo = new ImageData();

			imageinfo.path = path;
			imageinfo.name = Path.GetFileName(path);
			imageinfo.source = source;
			try {
				Image imageholder = Image.FromFile(path);
			

			if (imageholder == null) {
				imageinfo.origres = "Original Resolution: Invalid";
			}
			else {
				imageinfo.origres = "Original Resolution: " + imageholder.Width + "x" + imageholder.Height;
			}
			imageinfo.image = Utility.ImgtoBytes(Utility.ResizeImage(imageholder, 300, 300));

			imageholder.Dispose();
				}
			catch { return null;  }
			return imageinfo;
			
		}

		

		private void BuildListofURL(List<string> imgtags) {
			//First remove existing entries from array
			
			int x = 0; //counter x will equal number of tree elements
			foreach (ImageData img in ImgSelect)
				if (img.source == "url") x++;
			int remove = ImgSelect.Count - 1;
			int y = 0;//Inside loop finds the real current index to be removed
			int z = 0;//Controls Loop only run x times
			for (z = 1; z <= x; z++) {
				//Loop through the contents to find the last entry
				for (y = 0; y < ImgSelect.Count; y++) {
					if (ImgSelect[y].source == "url")
						remove = y;
				}
				ImgSelect.RemoveAt(remove);
			}

			//Removed all urls

			if (imgtags.Count == 0) return;

			foreach (string url in imgtags) {
				ImageData imageinfo = new ImageData();

				imageinfo.path = url;
				imageinfo.source = "url";
				int index = url.LastIndexOf(@"/");
				imageinfo.name = url.Substring(index + 1, url.Length - index - 1);

				ImgSelect.Add(imageinfo);
			}

			lstimgfiles.Items.Clear();

			foreach (ImageData img in ImgSelect)
				lstimgfiles.Items.Add(img.name);

		}
		
		

		private void lstimgfiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Cache building happens in here
			picimgpreview.Image = null;
			if (lstimgfiles.SelectedIndex == -1) return;

			int index = lstimgfiles.SelectedIndex;  //Make it easier, just use index from here out

			//If it's in the array, just output it and return
			if (ImgSelect[index].image != null) {
				lblorigres.Text = ImgSelect[index].origres;
				picimgpreview.Image = Utility.ResizeImage(Utility.BytestoImg(ImgSelect[index].image), 300, 300);
				return;
			}

			//Only thing left should be a url, make sure that's all we process
			if (ImgSelect[index].source != "url") return;

			
			Image original = GetWebImage(ImgSelect[index].path, 10);
			
			if (original == null) {
				ImgSelect[index].origres = "Original Resolution: Invalid";
				if (index == ImgSelect.Count -1) {
					lstimgfiles.SelectedIndex = index -1;
				} else { lstimgfiles.SelectedIndex = index +1; }

				ImgSelect.RemoveAt(index);
				lstimgfiles.Items.RemoveAt(index);

				return;
			}else{
				ImgSelect[index].origres = "Original Resolution: " + original.Width + "x" + original.Height;
				ImgSelect[index].image = Utility.ImgtoBytes(Utility.ResizeImage(original,300, 300));
				picimgpreview.Image = Utility.ResizeImage(Utility.BytestoImg(ImgSelect[index].image),300,300);
				lblorigres.Text = ImgSelect[index].origres;
			}

		}

		public Image GetWebImage(string URL, int TimeOutSecs) {

			lblInetStatus.Text = "Acquiring Image";
			Application.DoEvents();

			WebRequest objRequest;
			WebResponse objResponse;
			Stream objStreamReceive;

			try {
				objRequest = WebRequest.Create(URL);
				objRequest.Timeout = TimeOutSecs * 1000;
				objResponse = objRequest.GetResponse();
				objStreamReceive = objResponse.GetResponseStream();
				//StreamReader objStreamRead = new StreamReader(objStreamReceive);

				Image img = Image.FromStream(objStreamReceive);
				lblInetStatus.Text = null;
				return img;
			}
			catch { }
			lblInetStatus.Text = null;
			return null;
		}
		private string GetPageHTML(string URL, int TimeOutSecs) {

			
			lblInetStatus.Text = "Searching Images";
			Application.DoEvents();

			WebRequest objRequest;
			WebResponse objResponse;
			Stream objStreamReceive;
			StreamReader objStreamRead;
			Encoding objEncoding;

			objRequest = WebRequest.Create(URL);
			objRequest.Timeout = TimeOutSecs * 1000;
			objResponse = objRequest.GetResponse();
			objStreamReceive = objResponse.GetResponseStream();
			objEncoding = Encoding.GetEncoding("utf-8");
			objStreamRead = new StreamReader(objStreamReceive, objEncoding);

			string Page = objStreamRead.ReadToEnd();

			lblInetStatus.Text = null;

			if (objResponse == null) return null;

			return Page;

		}

		private List<string> ParseImages(string HTML, string expression) {

			Regex objRegEx;
			Match objMatch;
			List<string> LinkList = new List<string>();

			HTML = HTML.Replace(@"\x3d", "=");
			HTML = HTML.Replace(@"\x26", "&");

			objRegEx = new Regex(expression, RegexOptions.IgnoreCase);
			objMatch = objRegEx.Match(HTML);

			do {
				string strMatch = objMatch.Groups[1].ToString();
				LinkList.Add(strMatch);
				objMatch = objMatch.NextMatch();

			} while (objMatch.Success);

			return LinkList;

		}
		private void DoGoogleSearch() {

			string regexpression = @"\?imgurl\s*=\s*(?<1>http://.*?[jpg|gif])&";
			string wurl;

			if (nudgpage.Value == 1) {
				wurl = @"http://images.google.com/images?hl=en&q=" + searchstring.Replace(" ", "+");
			}
			else {
				wurl = @"http://images.google.com/images?hl=en&start=" + (nudgpage.Value - 1) * 20 + "&q=" + searchstring.Replace(" ", "+");
			}

			BuildListofURL(GenericSearch(wurl, regexpression));

		}
		private void DoAlbumArtorgSearch() {

			string regexpression = "href.*(?<1>http://[^" + (char)34 + "]*?[jpg|gif])" + (char)34;
			string wurl;

			if (nudgpage.Value == 1) {
				wurl = @"http://albumart.org/index.php?itempage=1&searchindex=Music&srchkey=" + searchstring.Replace(" ", "+");
			}
			else {
				wurl = @"http://albumart.org/index.php?itempage=" + nudgpage.Value + "&searchindex=Music&srchkey=" + searchstring.Replace(" ", "+");
			}

			BuildListofURL(GenericSearch(wurl, regexpression));

		}

		private List<string> GenericSearch(string url, string expression) {
			return ParseImages(GetPageHTML(url, 10), expression);
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnok_Click(object sender, EventArgs e)
		{
			if (picimgpreview.Image == null) this.Close();

			//Set the current displayed picture to the main form
			if (ImgSelect.Count > 0&& lstimgfiles.SelectedIndex !=-1)MainForm.ArtWork = ImgSelect[lstimgfiles.SelectedIndex].image;
			// close the form
			this.Close();


		}

		private void btnOpenPic_Click(object sender, EventArgs e)
		{
			if (ofd1.ShowDialog() != DialogResult.OK) return;

			ImageData img = new ImageData();
			Image original = Image.FromFile(ofd1.FileName);
			byte[] imgbytes = Utility.ImgtoBytes(Utility.ResizeImage(original, 300, 300));
			if (original != null) {
				img.origres = "Original Resolution: " + original.Width + "x" + original.Height;
			}
			else {
				img.origres = "Original Resolution: Invalid";
			}
			img.image = imgbytes;
			img.name = Path.GetFileName(ofd1.FileName);
			img.source = "file";

			ImgSelect.Insert(0, img);
			lstimgfiles.Items.Insert(0, img.name);
			if (lstimgfiles.SelectedIndex ==0) lstimgfiles.SelectedIndex = -1;
			lstimgfiles.SelectedIndex = 0;
		}

		private void btnGoogleImages_Click(object sender, EventArgs e)
		{
			DoGoogleSearch();
		}

		private void btnalbumartorg_Click(object sender, EventArgs e)
		{
			DoAlbumArtorgSearch();
		}

		private void LLeditsearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			EditImageSearch EditSearch = new EditImageSearch(this);
			EditSearch.ShowDialog();

		}


		private void TagzImageFinder_DragEnter(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop)){
				e.Effect = DragDropEffects.Copy;
			}else{
				e.Effect = DragDropEffects.None;
			}

		}

		private void TagzImageFinder_DragDrop(object sender, DragEventArgs e) {
			if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;
			try {
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				byte[] imgbytes =Utility.ImgtoBytes(Utility.ResizeImage(Image.FromFile(files[0]), 300, 300));

				ImageData img = new ImageData();

				img.image = imgbytes;
				img.name = "Dragged&Drop";
				img.source = "file";
				ImgSelect.Insert(0, img);
				lstimgfiles.Items.Insert(0, img.name);
				if (lstimgfiles.SelectedIndex == 0) lstimgfiles.SelectedIndex = -1;
				lstimgfiles.SelectedIndex = 0;
			}
			catch { return; }
		}
	}
}
