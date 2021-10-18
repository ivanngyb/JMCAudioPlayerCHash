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
        string curValue;

        public FormAudioPlayer()
        {
            InitializeComponent();
            FormManager.pipeClient.ServerDisconnected += PipeClient_ServerDisconnected;
        }

        private void DisplaySong()
        {
            ListBoxSongs.Items.Clear();
            foreach (Song song in songs)
            {
                ListBoxSongs.Items.Add(song.ToString());
            }
        }

        private void PlaySong(Song song)
        {
            Console.WriteLine(song.SongURL);
            WindowsMediaPlayer.URL = song.SongURL;
            LabelCurrentSong.Text = song.ToString();
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
                string filePath = OpenFileDialog.FileName;

                if (!string.IsNullOrEmpty(filePath))
                {
                    Song newSong = new Song(filePath);
                    songs.AddLast(newSong);
                    DisplaySong();
                }
            }
        }

        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (string.IsNullOrEmpty(curValue))
                {
                    PlaySong(songs.First());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
