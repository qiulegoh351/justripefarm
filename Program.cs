using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI___Multi_From_and_Panel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Login());

            var main = new Login();
            main.FormClosed += new FormClosedEventHandler(FormClosed);
            main.Show();
            Application.Run();

            singleton.Instance.print();
            Console.ReadLine();
        }

        static void FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form)sender).FormClosed -= FormClosed;
            if (Application.OpenForms.Count == 0) Application.ExitThread();
            else Application.OpenForms[0].FormClosed += FormClosed;
        }

        private static void Program_FormClosed(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
