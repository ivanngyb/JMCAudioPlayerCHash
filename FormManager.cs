using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Student ID: 30031552
//Student Name: Yang Beng Ng(Ivan)
//Date: 25/10/2021
//Description: An advance audio player with login capabilities and song saving

namespace JMCAudioPlayer
{
    class FormManager : ApplicationContext
    {
        //FormManager manages the form overall. Holds the pipeclient and handles disconnection

        Form formLogin;
        public static Form currentForm { get; set; }
        public static PipeClient pipeClient = new PipeClient();
        public static string CurrentUserName;

        private void onFormClosed(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                ExitThread();
            }
        }

        //Creates a new form
        public T CreateForm<T>() where T : Form, new()
        {
            var ret = new T();
            ret.FormClosed += onFormClosed;
            return ret;
        }

        private static Lazy<FormManager> _current = new Lazy<FormManager>();
        public static FormManager Current => _current.Value;

        public FormManager() {
            FormManager.pipeClient.ServerDisconnected += PipeClient_ServerDisconnected;
            formLogin = CreateForm<FormLogin>();
            formLogin.Show();
        }

        private void PipeClient_ServerDisconnected()
        {
            pipeClient.Disconnect();
            FormReconnect formReconnect = CreateForm<FormReconnect>();
            formReconnect.StartPosition = FormStartPosition.Manual;
            formReconnect.Location = currentForm.Location;
            formReconnect.ShowDialog();
        }

        //Generates hashing for password
        public static string GenerateSHA512String(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }

            return result.ToString();
        }

    }
}
