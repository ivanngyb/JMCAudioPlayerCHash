using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JMCAudioPlayer
{
    class FormManager : ApplicationContext
    {

        Form formPlayer;
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
            FormReconnect formReconnect = CreateForm<FormReconnect>();
            formReconnect.StartPosition = FormStartPosition.Manual;
            formReconnect.Location = currentForm.Location;
            formReconnect.ShowDialog();
        }

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
