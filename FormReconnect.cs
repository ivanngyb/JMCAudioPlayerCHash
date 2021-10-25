using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Student ID: 30031552
//Student Name: Yang Beng Ng(Ivan)
//Date: 25/10/2021
//Description: An advance audio player with login capabilities and song saving

namespace JMCAudioPlayer
{
    public partial class FormReconnect : Form
    {
        int timeLeft = 5;
        public FormReconnect()
        {
            InitializeComponent();
            FormManager.pipeClient.StreamReady += PipeClient_StreamReady;
        }

        private void PipeClient_StreamReady()
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            FormManager.pipeClient.SendMessage(encoder.GetBytes("RECONNECT " + FormManager.CurrentUserName));
            FormManager.pipeClient.StreamReady -= PipeClient_StreamReady;
            BeginInvoke(new Action(() => {
                this.Close();
            }));
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                LabelCountdown.Text = timeLeft.ToString();
            }
            else
            {
                if (!FormManager.pipeClient.Connect("jmcaudio"))
                {
                    timeLeft = 5;
                    LabelCountdown.Text = timeLeft.ToString();
                }
            }
        }
    }
}
