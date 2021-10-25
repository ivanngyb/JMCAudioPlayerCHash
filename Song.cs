using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

//Student ID: 30031552
//Student Name: Yang Beng Ng(Ivan)
//Date: 25/10/2021
//Description: An advance audio player with login capabilities and song saving

namespace JMCAudioPlayer
{
    class Song : IComparable<Song>
    {

        private string songTitle;
        private string[] songArtist;
        private string songURL;
        private bool unknownArtist = false;

        public string SongTitle { get => songTitle; set => songTitle = value; }
        public string SongURL { get => songURL; set => songURL = value; }
        public string[] SongArtist { get => songArtist; set => songArtist = value; }

        //Override ToString for showing in ListBox
        public override string ToString()
        {
            if (unknownArtist == true)
            {
                return "Unknown Artist - " + SongTitle;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(SongArtist[0]);
                for (int i = 1; i < SongArtist.Length; i++)
                {
                    sb.Append(", " + SongArtist[i]);
                }
                return sb.ToString() + " - " + SongTitle;
            }
            
        }

        public Song() { }

        public Song(string url)
        {
            //Using TagLib(Third Party Library) to get Metadata from songs
            if (File.Exists(url))
            {
                var tfile = TagLib.File.Create(@url);
                if (!string.IsNullOrEmpty(tfile.Tag.Title))
                {
                    SongTitle = tfile.Tag.Title;
                }
                else
                {
                    SongTitle = "Unknown Title";
                }

                if (tfile.Tag.AlbumArtists != null)
                {
                    if (tfile.Tag.AlbumArtists.Length == 0)
                    {
                        unknownArtist = true;
                    }
                    else
                    {
                        SongArtist = tfile.Tag.AlbumArtists;
                    }
                }
                else
                {
                    unknownArtist = true;
                }
                SongURL = url;
            }
        }

        //IComparable methods for comparing and custom operators
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
