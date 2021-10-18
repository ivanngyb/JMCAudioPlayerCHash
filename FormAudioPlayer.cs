using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JMCAudioPlayer
{
    public partial class FormAudioPlayer : Form
    {
        LinkedList<Song> songs = new LinkedList<Song>();
        Song curSong;
        bool isPlaying = false;
        double pos = 0;

        public FormAudioPlayer()
        {
            InitializeComponent();
            FormManager.pipeClient.ServerDisconnected += PipeClient_ServerDisconnected;
            WindowsMediaPlayer.PlayStateChange += WindowsMediaPlayer_PlayStateChange;
        }

        private void WindowsMediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 1)
            {
                if (songs.Find(curSong).Next.Value != null)
                {
                    PlaySong(songs.Find(curSong).Next.Value, 0);
                    curSong = songs.Find(curSong).Next.Value;
                }
            }
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
            Console.WriteLine(song.SongURL);
            WindowsMediaPlayer.URL = song.SongURL;
            LabelCurrentSong.Text = song.ToString();
            WindowsMediaPlayer.Ctlcontrols.currentPosition = pos;
            WindowsMediaPlayer.Ctlcontrols.play();
        }

        private void PipeClient_ServerDisconnected()
        {
            Invoke(new PipeClient.ServerDisconnectedHandler(ServerDisconnected));
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
                foreach (string s in OpenFileDialog.FileNames)
                {
                    Song song = new Song(s);
                    songs.AddLast(song);
                }

                DisplaySong();
            }
        }

        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (isPlaying == false)
                {
                    if (curSong == null)
                    {
                        PlaySong(songs.First(), 0);
                        curSong = songs.First();
                        isPlaying = true;
                        ButtonPlay.Text = ";";
                    }
                    else
                    {
                        PlaySong(curSong, pos);
                        isPlaying = true;
                        ButtonPlay.Text = ";";
                    }
                }
                else
                {
                    pos = WindowsMediaPlayer.Ctlcontrols.currentPosition;
                    WindowsMediaPlayer.Ctlcontrols.pause();
                    ButtonPlay.Text = "4";
                    isPlaying = false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
