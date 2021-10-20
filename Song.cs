using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMCAudioPlayer
{
    class Song : IComparable<Song>
    {
        private string songTitle;
        private string[] songArtist;
        private string songURL;

        public string SongTitle { get => songTitle; set => songTitle = value; }
        public string SongURL { get => songURL; set => songURL = value; }

        public string[] SongArtist { get => songArtist; set => songArtist = value; }

        public override string ToString()
        {
            if (SongArtist.Length > 0)
            {
                return SongArtist[0] + " - " + SongTitle;
            }
            else if (string.IsNullOrEmpty(SongArtist[1]))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(SongArtist[0]);
                for (int i = 1; i < SongArtist.Length; i++)
                {
                    sb.Append(", " + SongArtist[i]);
                }
                return sb.ToString() + " - " + SongTitle;
            }
            else
            {
                return "Unknown Artist - " + SongTitle;
            }
            
        }

        public Song(string url)
        {
            var tfile = TagLib.File.Create(@url);
            SongTitle = tfile.Tag.Title;
            SongArtist = tfile.Tag.AlbumArtists;
            SongURL = url;
        }

        public int CompareTo(Song obj)
        {
            return SongTitle.CompareTo(obj.SongTitle);
        }

        public static bool operator >(Song operand1, Song operand2)
        {
            return operand1.CompareTo(operand2) > 0;
        }

        public static bool operator <(Song operand1, Song operand2)
        {
            return operand1.CompareTo(operand2) < 0;
        }

        public static bool operator >=(Song operand1, Song operand2)
        {
            return operand1.CompareTo(operand2) >= 0;
        }
        public static bool operator <=(Song operand1, Song operand2)
        {
            return operand1.CompareTo(operand2) <= 0;
        }
    }
}
