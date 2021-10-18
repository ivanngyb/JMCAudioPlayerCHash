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
    }
}
