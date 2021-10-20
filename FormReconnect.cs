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
    public partial class FormReconnect : Form
    {
        int timeLeft = 5;
        public FormReconnect()
        {
            InitializeComponent();
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
                if (FormManager.pipeClient.Connect("jmcaudio"))
                {
                    this.Close();
                }
                else
                {
                    timeLeft = 5;
                    LabelCountdown.Text = timeLeft.ToString();
                }
            }
        }
    }
}
