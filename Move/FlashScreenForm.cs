using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Move
{
    public partial class FlashScreenForm : Form
    {
        private Random r = new Random();

        public FlashScreenForm()
        {
            InitializeComponent();
        }

        private void FlashScreenForm_Load(object sender, EventArgs e)
        {
            // displays the form over the entire screen except for the taskbar 
            // to allow access to the icon in order to disable
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;

            FlashScreenFormTimer.Enabled = true;
        }

        private void FlashScreenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FlashScreenFormTimer.Enabled = false;
        }

        private void FlashScreenFormTimer_Tick(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
        }
    }
}
