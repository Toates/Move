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

            FlashScreenOpacityTrackBar.Value = (int)(Properties.Settings.Default.ActionFlashScreenOpacity * 100);

            FlashScreenBehaviourComboBox.SelectedItem = Properties.Settings.Default.ActionFlashScreenBehaviour;

            MoveTimerIntervalLabel.Text = GetMinuteLabelString(MoveTimerIntervalTrackBar.Value);
            FlashIconSpeedIntervalLabel.Text = GetSecondLabelString((double)FlashIconSpeedTrackBar.Value / 1000);
            FlashScreenSpeedIntervalLabel.Text = GetSecondLabelString((double)FlashScreenSpeedTrackBar.Value / 1000);
            SystemBeepSpeedIntervalLabel.Text = GetSecondLabelString((double)SystemBeepSpeedTrackBar.Value / 1000);

            FlashScreenOpacityValueLabel.Text = GetPercentageLabelString(FlashScreenOpacityTrackBar.Value);
            
            if ((string)FlashScreenBehaviourComboBox.SelectedItem == "Custom")
            {
                FlashScreenColourCustomValueLabel.Text = Properties.Settings.Default.ActionFlashScreenColourCustom.Name.ToString();
            }
            else
            {
                FlashScreenColourCustomValueLabel.Text = "";
            }
        }
        
        private void MoveTimerInterval_Scroll(object sender, EventArgs e)
        {
            MoveTimerIntervalLabel.Text = GetMinuteLabelString(MoveTimerIntervalTrackBar.Value);
        }

        private void FlashIconSpeedTrackBar_Scroll(object sender, EventArgs e)
        {
            FlashIconSpeedIntervalLabel.Text = GetSecondLabelString((double)FlashIconSpeedTrackBar.Value / 1000);
        }

        private void FlashScreenSpeedTrackBar_Scroll(object sender, EventArgs e)
        {
            FlashScreenSpeedIntervalLabel.Text = GetSecondLabelString((double)FlashScreenSpeedTrackBar.Value / 1000);
        }

        private void FlashScreenTransparencyTrackBar_Scroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.ActionFlashScreenOpacity = (double)FlashScreenOpacityTrackBar.Value / 100;
            FlashScreenOpacityValueLabel.Text = GetPercentageLabelString(FlashScreenOpacityTrackBar.Value);
        }

        private void SystemBeepSpeedTrackBar_Scroll(object sender, EventArgs e)
        {
            SystemBeepSpeedIntervalLabel.Text = GetSecondLabelString((double)SystemBeepSpeedTrackBar.Value / 1000);
        }

        private void FlashScreenColourComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ActionFlashScreenBehaviour = (string)FlashScreenBehaviourComboBox.SelectedItem;

            if (Visible)
            {
                if (Properties.Settings.Default.ActionFlashScreenBehaviour == "Custom")
                {
                    if (FlashScreenCustomColorDialog.ShowDialog() == DialogResult.OK)
                    {
                        Properties.Settings.Default.ActionFlashScreenColourCustom = FlashScreenCustomColorDialog.Color;
                        FlashScreenColourCustomValueLabel.Text = FlashScreenCustomColorDialog.Color.Name.ToString();
                    }
                }
                else
                {
                    FlashScreenColourCustomValueLabel.Text = "";
                }
            }
        }

        private void RunOnStartupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                if (RunOnStartupCheckBox.Checked)
                {
                    key.SetValue(Application.ProductName, "\"" + Application.ExecutablePath + "\"");
                }
                else
                {
                    key.DeleteValue(Application.ProductName, false);
                }
            }
            // an alternative is to create a shortcut/copy executable to Environment.SpecialFolder.Startup
        }

        private void LockMachineEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (LockMachineEnabledCheckBox.Checked)
            {
                DialogResult result = MessageBox.Show
                    ("Enabling Lock Machine will disable all other actions\n\nAre you sure?", 
                     "Confirmation", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    FlashIconEnabledCheckBox.Checked = false;
                    FlashScreenEnabledCheckBox.Checked = false;
                    SystemBeepEnabledCheckBox.Checked = false;
                    BalloonTipEnabledCheckBox.Checked = false;
                }
                else
                {
                    LockMachineEnabledCheckBox.Checked = false;
                }
            }

            Properties.Settings.Default.ActionLockMachineEnabled = LockMachineEnabledCheckBox.Checked;
        }
        
        private static string GetMinuteLabelString(int value)
        {
            string end = value.ToString(System.Globalization.CultureInfo.CurrentCulture);
            if (value == 1)
            {
                end = end + " minute";
            }
            else
            {
                end = end + " minutes";
            }
            return end;
        }

        private static string GetSecondLabelString(int value)
        {
            string end = value.ToString(System.Globalization.CultureInfo.CurrentCulture);
            if (value == 1)
            {
                end = end + " second";
            }
            else
            {
                end = end + " seconds";
            }
            return end;
        }

        private static string GetSecondLabelString(double value)
        {
            string end = value.ToString(System.Globalization.CultureInfo.CurrentCulture);
            if (value == 1.0)
            {
                end = end + " second";
            }
            else
            {
                end = end + " seconds";
            }
            return end;
        }

        private static string GetPercentageLabelString(int value)
        {
            return value.ToString(System.Globalization.CultureInfo.CurrentCulture) + "%";
        }
    }
}
