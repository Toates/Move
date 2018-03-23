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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            MoveTimerIntervalLabel.Text = 
                MoveTimerIntervalTrackBar.Value.ToString(System.Globalization.CultureInfo.CurrentCulture) 
                + GetMoveTimerIntervalLabelEnding();
        }

        private void MoveTimerInterval_Scroll(object sender, EventArgs e)
        {
            MoveTimerIntervalLabel.Text = 
                MoveTimerIntervalTrackBar.Value.ToString(System.Globalization.CultureInfo.CurrentCulture) 
                + GetMoveTimerIntervalLabelEnding();
        }
        
        private string GetMoveTimerIntervalLabelEnding()
        {
            string end;
            if (MoveTimerIntervalTrackBar.Value == 1)
            {
                end = " minute";
            }
            else
            {
                end = " minutes";
            }
            return end;
        }

        private void FlashScreenTransparencyTrackBar_Scroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.ActionFlashScreenTransparency = (double)FlashScreenTransparencyTrackBar.Value / 100;
            //Opacity = (double)FlashScreenTransparencyTrackBar.Value / 100;// TODO: remove
        }
    }
}
