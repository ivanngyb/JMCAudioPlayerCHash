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
    public partial class FormLogin : Form
    {
        

        public FormLogin()
        {
            InitializeComponent();
            if (!FormManager.pipeClient.Connect("jmcaudio"))
            {
                Console.WriteLine("Server not started");
                ButtonLogin.Enabled = false;
                ButtonRegister.Enabled = false;
            }
            FormManager.pipeClient.MessageReceived += PipeClient_MessageReceived;

        }

        private void PipeClient_MessageReceived(byte[] message)
        {
            Invoke(new PipeClient.MessageReceivedHandler(MessageReceived), new object[] { message });
        }

        void MessageReceived(byte[] message)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            string str = encoder.GetString(message, 0, message.Length);
            Console.WriteLine("Message Received: " + str);
            if (str.Equals("LOGIN_SUCCESS"))
            {
                Console.WriteLine("Login success!");
                FormAudioPlayer audioPlayer = new FormAudioPlayer();
                audioPlayer.Show();
                this.Hide();
            }
            else if (str.Equals("LOGIN_FAILED1"))
            {
                LabelFeedback.Visible = true;
                LabelFeedback.Text = "Incorrect username or password";
            }
            else if (str.Equals("LOGIN_FAILED2"))
            {
                LabelFeedback.Visible = true;
                LabelFeedback.Text = "User already logged in";
            }
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            formRegister.ShowDialog();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();

            FormManager.pipeClient.SendMessage(encoder.GetBytes("LOGIN " + TextBoxUsername.Text + " " + FormManager.GenerateSHA512String(TextBoxPassword.Text)));
        }


    }
}
