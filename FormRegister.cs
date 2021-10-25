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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
            FormManager.pipeClient.MessageReceived += PipeClient_MessageReceived;
        }

        private void PipeClient_MessageReceived(byte[] message)
        {
            Invoke(new PipeClient.MessageReceivedHandler(MessageReceived), new object[] { message });
        }

        //Gets message from server and if register is success user gets created
        void MessageReceived(byte[] message)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            string str = encoder.GetString(message, 0, message.Length);
            Console.WriteLine("Message Received: " + str);

            if (str.Equals("REGISTER_SUCCESS"))
            {
                DialogResult userCreated = MessageBox.Show("Thanks for registering!", "User successfully created", MessageBoxButtons.OK);
                if (userCreated == DialogResult.OK)
                {
                    FormManager.pipeClient.MessageReceived -= PipeClient_MessageReceived;
                    this.Hide();
                }
            }
            else if (str.Equals("REGISTER_FAILED1"))
            {
                DialogResult userCreated = MessageBox.Show("User already exist", "User failed created", MessageBoxButtons.OK);
            }
        }

        //Hides form when cancel is clicked
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            FormManager.pipeClient.MessageReceived -= PipeClient_MessageReceived;
            this.Hide();
        }

        //Attempts to registers user
        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();

            FormManager.pipeClient.SendMessage(encoder.GetBytes("REGISTER " + TextBoxUsername.Text + " " + FormManager.GenerateSHA512String(TextBoxPassword.Text)));
            
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            FormManager.currentForm = this;
        }
    }
}
