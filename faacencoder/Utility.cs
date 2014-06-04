using System.Drawing.Imaging;
using System.Text;
using System.IO;
using System;
using System.Drawing;

namespace AudioBookConverter {
	public static class Utility {

		public static byte[] ImgtoBytes (Image imageToConvert) {
			byte[] Ret;

			try {
				using (MemoryStream ms = new MemoryStream()) {
					imageToConvert.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
					Ret = ms.ToArray();
				}
			}
			catch (Exception) { return null; }

			return Ret;
		}

		public static Image BytestoImg (byte[] bmpbytes) {
			if (bmpbytes == null) return null;
			ImageConverter conv = new ImageConverter();
			return conv.ConvertFrom(bmpbytes) as Image;

		}

		public static Image ResizeImage (System.Drawing.Image poImage, int wSize, int hSize) {
			try {
				using (Image Original = (Image)poImage) {
					Image ResizedImage = new Bitmap(wSize, hSize, Original.PixelFormat);
					Graphics oGraphic = Graphics.FromImage(ResizedImage);
					oGraphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
					oGraphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
					oGraphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
					Rectangle oRectangle = new Rectangle(0, 0, wSize, hSize);
					oGraphic.DrawImage(Original, oRectangle);
					oGraphic.Dispose();
					Original.Dispose();
					poImage.Dispose();
					return ResizedImage;
				}
			}
			catch (Exception) { return null; }

		}

	}
}