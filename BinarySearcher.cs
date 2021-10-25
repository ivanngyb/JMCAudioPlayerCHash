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
        //Custom function: 
        //For searching songs using binary search method
        //Returns a tuple. If song is found returns the song and bool for true if found
        public (Song, bool) BinarySearch(Song[] songs, string key)
        {
            int min = 0;
            int max = songs.Length - 1;

            while (min <= max)
            {
                //Gets middle poistion
                int mid = (min + max) / 2;
                
                //Compares and changes midpoint accordingly recursively
                if (songs[mid].SongTitle.ToLower().CompareTo(key) == 0)
                {
                    return (songs[mid], true);
                }
                else if (songs[mid].SongTitle.ToLower().CompareTo(key) > 0)
                {
                    //If song title contains part search return true
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

            //If not found returns false
            return (null, false);
        }
    }
}
