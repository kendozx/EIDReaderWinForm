using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EIDReaderWinForm
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
            using (ProcessIcon pi = new ProcessIcon())
            {
                CardReader cardReader = new CardReader(pi, Properties.Settings.Default.Card);
                pi.Display();
                Application.Run();
            }
        }
    }
}
