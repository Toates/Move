using System;
using System.Windows.Forms;

namespace Move
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
            using (MoveTaskbar moveTaskbar = new MoveTaskbar())
            {
                Application.Run(moveTaskbar);
            }
        }
    }
}
