using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Student ID: 30031552
//Student Name: Yang Beng Ng(Ivan)
//Date: 25/10/2021
//Description: An advance audio player with login capabilities and song saving

namespace JMCAudioPlayer
{
    class BinarySearcher
    {
        public (Song, bool) BinarySearch(Song[] songs, string key)
        {
            int min = 0;
            int max = songs.Length - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;
                
                if (songs[mid].SongTitle.ToLower().CompareTo(key) == 0)
                {
                    return (songs[mid], true);
                }
                else if (songs[mid].SongTitle.ToLower().CompareTo(key) > 0)
                {
                    if (songs[mid].SongTitle.ToLower().Contains(key))
                    {
                        return (songs[mid], true);
                    }
                    max = mid - 1;
                }
                else
                {
                    if (songs[mid].SongTitle.ToLower().Contains(key))
                    {
                        return (songs[mid], true);
                    }
                    min = mid + 1;
                }
            }
            return (null, false);
        }
    }
}
