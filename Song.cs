using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMCAudioPlayer
{
    class Song
    {
        private string songTitle;
        private string[] songArtist;
        private string songURL;

        public string SongTitle { get => songTitle; set => songTitle = value; }
        public string SongURL { get => songURL; set => songURL = value; }

        public string[] SongArtist { get => songArtist; set => songArtist = value; }

        public override string ToString()
        {
            if (SongArtist.Length > 1)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string s in SongArtist)
                {
                    sb.Append(", " + s);
                }
                return sb.ToString() + " - " + SongTitle;
            }

            return SongArtist[0] + " - " + SongTitle;
        }

        public Song(string url)
        {
            var tfile = TagLib.File.Create(@url);
            SongTitle = tfile.Tag.Title;
            SongArtist = tfile.Tag.AlbumArtists;
        }
    }
}
