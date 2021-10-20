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

namespace JMCAudioPlayer
{
    public partial class FormAudioPlayer : Form
    {
        LinkedList<Song> songs = new LinkedList<Song>();
        MergeSorter mergeSorter = new MergeSorter();
        BinarySearcher binarySearcher = new BinarySearcher();
        Song curSong;
        bool isPlaying = false;
        double pos = 0;

        public FormAudioPlayer()
        {
            InitializeComponent();
            WindowsMediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(WindowsMediaPlayer_PlayStateChange);
        }

        private void WindowsMediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 1)
            {
                if (songs.Find(curSong).Next != null)
                {
                    WindowsMediaPlayer.URL = songs.Find(curSong).Next.Value.SongURL;
                    WindowsMediaPlayer.Ctlcontrols.play();
                    curSong = songs.Find(curSong).Next.Value;
                    //PlaySong(songs.Find(curSong).Next.Value, 0);
                }
                else
                {
                    PlaySong(songs.First(), 0);
                }
            }
            else if (e.newState == 1) 
            { 
                isPlaying = false;
            }
        }

        private void SortSongs()
        {
            Song[] sortedSongs = mergeSorter.MergeSort(songs.ToArray());
            songs.Clear();
            songs = new LinkedList<Song>(sortedSongs);
            DisplaySong();
        }

        private void DisplaySong()
        {
            ListBoxSongs.Items.Clear();
            foreach (Song song in songs)
            {
                ListBoxSongs.Items.Add(song.ToString());
            }
        }

        private void PlaySong(Song song, double pos)
        {
            curSong = song;
            WindowsMediaPlayer.URL = song.SongURL;
            WindowsMediaPlayer.Ctlcontrols.currentPosition = pos;
            WindowsMediaPlayer.Ctlcontrols.play();
            LabelCurrentSong.Text = song.ToString();
        }

        private void PlayPause()
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }

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

        void ServerDisconnected()
        {
            MessageBox.Show("Lost connection to server!");
        }

        private void FormAudioPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

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

        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            PlayPause();
        }

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

        private void TextBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                (Song, bool) result = binarySearcher.BinarySearch(songs.ToArray<Song>(), TextBoxSearch.Text);
                if (result.Item2)
                {
                    ListBoxSongs.SelectedIndex = GetLinkedListIndex<Song>(songs, result.Item1);
                    TextBoxSearch.Clear();
                }
                else
                {
                    MessageBox.Show("Song title not found");
                    TextBoxSearch.Focus();
                }
            }
        }

        private void FormAudioPlayer_KeyPress(object sender, KeyPressEventArgs e)
        {
            PlayPause();
        }

        private void FormAudioPlayer_Load(object sender, EventArgs e)
        {
            FormManager.currentForm = this;
        }
    }
}
