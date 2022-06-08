using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chart.Client
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FrmLogin login = new FrmLogin();
            if (login.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Application.Run(new FrmMain(login.GetUserId()));
           
        }

        class ChartContext : ApplicationContext
        {
            public ChartContext(string userId)
            {
                FrmMain mform = new FrmMain(userId);
                mform.Show();
            }
        };
    }
}
