using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AudioBookConverter
{
	public partial class EditImageSearch : Form
	{
		private ImageFinder _ParentForm;
		public EditImageSearch(ImageFinder parent)
		{
			InitializeComponent();
			_ParentForm = parent;
			txtsearchstring.Text = _ParentForm.EditSearchString;

		}

		private void OK_Button_Click(object sender, EventArgs e)
		{
			_ParentForm.EditSearchString = txtsearchstring.Text;
			this.Close();
		}

		private void Cancel_Button_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnrevert_Click(object sender, EventArgs e)
		{
			txtsearchstring.Text = _ParentForm.EditSearchString;
		}
	}
}
