using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace AudioBookConverter {
	public class OutputMetadata {

		private string outputfile;
		private string title;
		private string artist;
		private string album;
		private string comment;
		private byte[] image;
		private int year;
		private string composer;
		private string titlesort;
		private string artistsort;
		private string albumsort;
		private string composersort;
		private int track;
		private int tracktotal;
		private int disc;
		private int disctotal;

		public string OutputFile {
			get { return outputfile; }
			set { outputfile = value; }
		}
		public string Title {
			get { return title; }
			set { title = value; }
		}

		public string Artist {
			get { return artist; }
			set { artist = value; }
		}
		public string Album {
			get { return album; }
			set { album = value; }
		}
		public string Comment {
			get { return comment; }
			set { comment = value; }
		}
		public byte[] Image {
			get { return image; }
			set { image = value; }
		}
		public int Year {
			get { return year; }
			set { year = value; }
		}
		public string Composer {
			get { return composer; }
			set { composer = value; }
		}

		public string TitleSort {
			get { return titlesort; }
			set { titlesort = value; }
		}
		public string AlbumSort {
			get { return albumsort; }
			set { albumsort = value; }
		}
		public string ArtistSort {
			get { return artistsort; }
			set { artistsort = value; }
		}
		public string ComposerSort {
			get { return composersort; }
			set { composersort = value; }
		}

		public int Track {
			get { return track; }
			set { track = value; }
		}

		public int TrackTotal {
			get { return tracktotal; }
			set { tracktotal = value; }
		}

		public int Disc {
			get { return disc; }
			set { disc = value; }
		}

		public int DiscTotal {
			get { return disctotal; }
			set { disctotal = value; }
		}


	}
}
