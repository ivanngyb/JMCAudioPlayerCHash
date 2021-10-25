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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            //Attempts to connect to pipe client
            if (!FormManager.pipeClient.Connect("jmcaudio"))
            {
                Console.WriteLine("Server not started");
                ButtonLogin.Enabled = false;
                ButtonRegister.Enabled = false;
                DialogResult failToConnect = MessageBox.Show("Failed to connect to server. Turn on server and restart application", "Fail", MessageBoxButtons.OK);
                
            }
            else
            {
                FormManager.pipeClient.MessageReceived += PipeClient_MessageReceived;
            }
            

        }

        //Message receiving handler
        private void PipeClient_MessageReceived(byte[] message)
        {
            Invoke(new PipeClient.MessageReceivedHandler(MessageReceived), new object[] { message });
        }

        //Checks to see if login is correct
        void MessageReceived(byte[] message)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            string str = encoder.GetString(message, 0, message.Length);
            Console.WriteLine("Message Received: " + str);
            if (str.Equals("LOGIN_SUCCESS"))
            {
                Console.WriteLine("Login success!");
                FormManager.CurrentUserName = TextBoxUsername.Text;
                FormAudioPlayer audioPlayer = new FormAudioPlayer();
                audioPlayer.StartPosition = FormStartPosition.Manual;
                audioPlayer.Location = this.Location;
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

        //Opens register form
        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            formRegister.StartPosition = FormStartPosition.Manual;
            formRegister.Location = this.Location;
            formRegister.ShowDialog();
        }

        //Exits application
        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //Sends login info to server to verify. Password gets hashed before being sent
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();

            FormManager.pipeClient.SendMessage(encoder.GetBytes("LOGIN " + TextBoxUsername.Text + " " + FormManager.GenerateSHA512String(TextBoxPassword.Text)));
        }

        //If enter is pressed while password text box is selected attempt login
        private void TextBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ASCIIEncoding encoder = new ASCIIEncoding();

                FormManager.pipeClient.SendMessage(encoder.GetBytes("LOGIN " + TextBoxUsername.Text + " " + FormManager.GenerateSHA512String(TextBoxPassword.Text)));
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            FormManager.currentForm = this;
        }
    }
}
