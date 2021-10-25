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
    class MergeSorter
    {
        //Recursively merge sort 
        public Song[] MergeSort(Song[] songs)
        {
            Song[] left;
            Song[] right;
            Song[] result = new Song[songs.Length];

            if (songs.Length <= 1)
            {
                return songs;
            }

            //Split at midpoint
            int midPoint = songs.Length / 2;

            left = new Song[midPoint];

            //Checks if it's even or odd to decide midpoint
            if (songs.Length % 2 == 0)
            {
                right = new Song[midPoint];
            }
            else
            {
                right = new Song[midPoint + 1];
            }

            for (int i = 0; i < midPoint; i++)
            {
                left[i] = songs[i];
            }

            int x = 0;

            for (int i = midPoint; i < songs.Length; i++)
            {
                right[x] = songs[i];
                x++;
            }

            //Recursive sorting
            left = MergeSort(left);

            right = MergeSort(right);

            //Merges at the end
            result = Merge(left, right);
            return result;
        }

        private Song[] Merge(Song[] left, Song[] right)
        {
            int resultLength = right.Length + left.Length;
            Song[] result = new Song[resultLength];

            int indexLeft = 0;
            int indexRight = 0;
            int indexResult = 0;

            while (indexLeft < left.Length || indexRight < right.Length) 
            {
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    //Using custom operands in Song class to compare size
                    if (left[indexLeft] <= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            //Returns merged array
            return result;
        }
    }
}
