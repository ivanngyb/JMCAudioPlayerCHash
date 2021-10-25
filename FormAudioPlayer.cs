using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using CsvHelper;
using System.IO;
using System.Globalization;

//Student ID: 30031552
//Student Name: Yang Beng Ng(Ivan)
//Date: 25/10/2021
//Description: An advance audio player with login capabilities and song saving

namespace JMCAudioPlayer
{
    public partial class FormAudioPlayer : Form
    {
        LinkedList<Song> songs = new LinkedList<Song>();
        MergeSorter mergeSorter = new MergeSorter();
        BinarySearcher binarySearcher = new BinarySearcher();
        Song curSong;
        string usersSongsPath = "Users Songs";
        bool isPlaying = false;
        double pos = 0;

        public FormAudioPlayer()
        {
            InitializeComponent();
            WindowsMediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(WindowsMediaPlayer_PlayStateChange);
        }

        //Stage change for Windows Media Player
        private void WindowsMediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            //If paused or stopped
            if (e.newState == 1 || e.newState == 2)
            {
                LabelCurrentSong.Text = "Nothing playing";
                ButtonPlay.Text = "4";
                ListBoxSongs.SelectedIndex = -1;
                isPlaying = false;
            }
            //If playing
            else if (e.newState == 3)
            {
                isPlaying = true;
                ButtonPlay.Text = ";";
                ListBoxSongs.SelectedIndex = GetLinkedListIndex<Song>(songs, curSong);
            }
            //When media has ended
            else if (e.newState == 8)
            {
                BeginInvoke(new Action(() => {
                    if (songs.Find(curSong).Next != null)
                    {
                        WindowsMediaPlayer.URL = songs.Find(curSong).Next.Value.SongURL;
                        curSong = songs.Find(curSong).Next.Value;
                        PlaySong(curSong, 0);
                    }
                    else
                    {
                        WindowsMediaPlayer.URL = songs.First.Value.SongURL;
                        curSong = songs.First();
                        PlaySong(curSong, 0);
                    }
                }));
            }
        }

        //Custom method:
        //Sorts songs on linkedlist
        private void SortSongs()
        {
            Song[] sortedSongs = mergeSorter.MergeSort(songs.ToArray());
            songs.Clear();
            songs = new LinkedList<Song>(sortedSongs);
            DisplaySong();
        }

        //Custom method:
        //Displays songs onto list box
        private void DisplaySong()
        {
            ListBoxSongs.Items.Clear();
            foreach (Song song in songs)
            {
                ListBoxSongs.Items.Add(song.ToString());
            }
        }

        //Custom method:
        //Plays song from position given. If pos = 0 song starts from beginning
        private void PlaySong(Song song, double pos)
        {
            curSong = song;
            WindowsMediaPlayer.URL = song.SongURL;
            WindowsMediaPlayer.Ctlcontrols.currentPosition = pos;
            WindowsMediaPlayer.Ctlcontrols.play();
            LabelCurrentSong.Text = song.ToString();
        }

        //Custom method
        //Plays and pauses media player
        private void PlayPause()
        {
            try
            {
                if (songs.Count > 0)
                {
                    if (isPlaying == false)
                    {
                        if (curSong == null)
                        {
                            PlaySong(songs.First(), 0);
                            isPlaying = true;
                        }
                        else
                        {
                            PlaySong(curSong, pos);
                            isPlaying = true;
                        }
                    }
                    else
                    {
                        pos = WindowsMediaPlayer.Ctlcontrols.currentPosition;
                        WindowsMediaPlayer.Ctlcontrols.pause();
                        isPlaying = false;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Custom method:
        //Gets the index of song in linked list
        private int GetLinkedListIndex<Song>(LinkedList<Song> songs, Song item) 
        {
            var count = 0;
            for (var node = songs.First; node != null; node = node.Next, count++)
            {
                if (item.Equals(node.Value))
                    return count;
            }
            return -1;
        }

        //Custom method:
        //Writes songs into CSV file
        private void WriteSongs(string user)
        {
            string fileName = user + ".csv";
            if (!File.Exists(usersSongsPath))
            {
                Directory.CreateDirectory(usersSongsPath);
            }

            fileName = Path.Combine(usersSongsPath, fileName);
            

            using (var writer = new StreamWriter(fileName))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(songs);
            }
        }

        //When form closes. Sends a message to server to disconnect user
        private void FormAudioPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            FormManager.pipeClient.SendMessage(encoder.GetBytes("DISCONNECT " + FormManager.CurrentUserName));
            WriteSongs(FormManager.CurrentUserName);
            Application.Exit();
        }

        //Load songs and sorts them before displaying
        private void ButtonLoadSong_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(OpenFileDialog.FileName))
                {
                    foreach (string s in OpenFileDialog.FileNames)
                    {
                        Song song = new Song(s);
                        songs.AddLast(song);
                    }

                    SortSongs();
                }
            }
        }

        //Play button to play and pause songs
        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            PlayPause();
        }

        //Next button for playing next song in linked list. Goes back to first item when end is reached
        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (songs.Find(curSong).Next != null)
            {
                PlaySong(songs.Find(curSong).Next.Value, 0);
            }
            else
            {
                PlaySong(songs.First(), 0);
            }
        }

        //Previous button for playing previous song. Goes to end of list when song is on first item
        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            if (songs.Find(curSong).Previous != null)
            {
                PlaySong(songs.Find(curSong).Previous.Value, 0);
            }
            else
            {
                PlaySong(songs.Last(), 0);
            }
        }

        //Search text box to search for songs
        private void TextBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                (Song, bool) result = binarySearcher.BinarySearch(songs.ToArray<Song>(), TextBoxSearch.Text);
                if (result.Item2)
                {
                    ListBoxSongs.SelectedIndex = GetLinkedListIndex<Song>(songs, result.Item1);
                    ListBoxSongs.Focus();
                    curSong = result.Item1;
                    PlaySong(curSong, 0);
                    TextBoxSearch.Text = "Enter to search";
                }
                else
                {
                    MessageBox.Show("Song title not found");
                    TextBoxSearch.Focus();
                }
            }
        }

        //When space is pressed play/pause songs
        private void FormAudioPlayer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                PlayPause();
            }
        }

        //On load use third party library to read CSV file
        private void FormAudioPlayer_Load(object sender, EventArgs e)
        {
            FormManager.currentForm = this;
            string fileName = FormManager.CurrentUserName + ".csv";
            if (!File.Exists(usersSongsPath))
            {
                Directory.CreateDirectory(usersSongsPath);
            }

            fileName = Path.Combine(usersSongsPath, fileName);

            if (File.Exists(fileName))
            {
                List<Song> records;

                using (var reader = new StreamReader(fileName))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    records = csv.GetRecords<Song>().ToList();
                }

                bool songExist = true;
                for (int i = 0; i < records.Count(); i++)
                {
                    Song song = new Song(records[i].SongURL);
                    if (File.Exists(song.SongURL))
                    {
                        songs.AddLast(song);
                    }
                    else
                    {
                        songExist = false;
                    }
                }

                SortSongs();

                if (songExist == false)
                {
                    MessageBox.Show("Some songs were not found on URL and not added to list");
                }
            }
        }

        //Play song when song is double clicked in list box
        private void ListBoxSongs_DoubleClick(object sender, EventArgs e)
        {
            int index = ListBoxSongs.Items.IndexOf(ListBoxSongs.SelectedItem);
            curSong = songs.ElementAt(index);
            PlaySong(curSong, 0);
        }

        //Change placeholder text
        private void TextBoxSearch_Enter(object sender, EventArgs e)
        {
            if (TextBoxSearch.Text.Equals("Enter to search"))
                TextBoxSearch.Text = "";
        }

        private void TextBoxSearch_Leave(object sender, EventArgs e)
        {
            TextBoxSearch.Text = "Enter to search";
        }
    }
}
