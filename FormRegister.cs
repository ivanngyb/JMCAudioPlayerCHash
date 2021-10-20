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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();

            FormManager.pipeClient.SendMessage(encoder.GetBytes("REGISTER " + TextBoxUsername.Text + " " + FormManager.GenerateSHA512String(TextBoxPassword.Text)));
            MessageBox.Show("User Created!");
            this.Hide();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            FormManager.currentForm = this;
        }
    }
}
