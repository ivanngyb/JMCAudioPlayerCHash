using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JMCAudioPlayer
{
    class FormManager : ApplicationContext
    {

        Form formPlayer;
        Form formLogin;
        public static PipeClient pipeClient = new PipeClient();

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
            formPlayer = CreateForm<FormAudioPlayer>();
            formPlayer.Show();
            formLogin = CreateForm<FormLogin>();
            formLogin.ShowDialog();
        }
    }
}
