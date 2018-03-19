using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Move
{
    partial class MoveTaskbar : ApplicationContext
    {
        internal static class NativeMethods
        {
            // pinvoke for locking the workstation
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            internal static extern bool LockWorkStation();
        }

        // the timing elements
        private Timer MoveTimer = new Timer();
        private Timer TaskbarIconFlashTimer = new Timer();
        private Timer SystemBeepTimer = new Timer();

        // move timer not able to return current status so stopwatch used to display the time until expiry
        private System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

        private Boolean SwitchIcon = true;

        void MoveTimer_Tick(object sender, EventArgs e)
        {
            //this.TrayIconContextMenu.Enabled = false;
            this.TrayIconContextMenu.Close();
            StopMoveTimer();
            StartActions();
        }

        void StartMoveTimer()
        {
            MoveTimer.Stop();
            //#if DEBUG
            //            MoveTimer.Interval = 10000;
            //#else
            MoveTimer.Interval = (int)TimeSpan.FromMinutes(Properties.Settings.Default.IntervalMinutes).TotalMilliseconds;
//#endif

            MoveTimer.Enabled = true;
            MoveTimer.Start();

            stopwatch.Restart();
        }

        void StopMoveTimer()
        {
            MoveTimer.Enabled = false;
            MoveTimer.Stop();

            stopwatch.Stop();
        }
        
        void StartActions()
        {
            // enable eventhandler for each action here so any action can trigger acceptance
            //ActionManager.StartActions();

            bool MachineLocked = false;
            //LockMachine
            if (Properties.Settings.Default.LockMachineEnabled)
            {
                MachineLocked = NativeMethods.LockWorkStation();
            }

            if (!MachineLocked)
            {
                //TaskbarIconFlash
                if (Properties.Settings.Default.FlashIconEnabled)
                {
                    TaskbarIconFlashTimer.Interval = 100;
                    TaskbarIconFlashTimer.Start();
                }

                //SystemBeep
                if (Properties.Settings.Default.SystemBeepEnabled)
                {
                    SystemBeepTimer.Interval = 2000;
                    SystemBeepTimer.Start();
                }

                //MessageBox
                if (Properties.Settings.Default.MessageBoxEnabled)
                {
                    // not a clean way to close the messagebox if user stops action thru another route
                    // also seems to conflict with balloontip
                    // TODO: need to user a basic dialog window or overload messagebox?
                    // MessageBox.Show("Time to move!"); // TODO: add string and timeout to settings
                    // Form.ShowDialog // we are not a form here so probably cannot use this
                }

                //BalloonTip 
                if (Properties.Settings.Default.BalloonTipEnabled)
                {
                    // does not use the timeout value given and will close itself after ~5 seconds
                    // balloontipclosed is triggered on both user and system closures with no way of differentiating 
                    // so either we stop actions on all closures, limiting its effectiveness
                    // or we do not react to closure, leaving the user to have to double click to stop
                    // based on the two options, stopping on closure is the least worse, just need to make clear in settings and allow disabling
                    // also single click on icon is treated as a click on the balloontip when displayed for some reason
                    this.TrayIcon.ShowBalloonTip(60000, "", "Time to move!", ToolTipIcon.None); // TODO: add string to settings
                }

                //FlashScreen
                if (Properties.Settings.Default.FlashScreenEnabled)
                {
                    if (FlashScreen == null || FlashScreen.IsDisposed)
                    {
                        FlashScreen = new FlashScreenForm();
                    }

                    FlashScreen.ShowDialog();
                }
            }
        }

        void StopActions()
        {
            //TaskbarIconFlash
            if (Properties.Settings.Default.FlashIconEnabled)
            {
                TaskbarIconFlashTimer.Stop();
                this.TrayIcon.Icon = Properties.Resources.Icon;
            }

            //SystemBeep
            if (Properties.Settings.Default.SystemBeepEnabled)
            {
                SystemBeepTimer.Stop();
            }

            //MessageBox
            if (Properties.Settings.Default.MessageBoxEnabled)
            {
            }

            //BalloonTip
            if (Properties.Settings.Default.BalloonTipEnabled)
            {
                this.TrayIcon.Visible = true; // this will force the tooltip to close
            }

            //FlashScreen
            if (Properties.Settings.Default.FlashScreenEnabled)
            {
                FlashScreen.Close();
            }

            //LockMachine - nothing required as if this was enabled, the machine would have been locked
            //if (Properties.Settings.Default.LockMachineEnabled)
            //{
            //}
        }
        
        void Action_Accepted(object sender, EventArgs e)
        {
            StopActions();
            StartMoveTimer();
        }

        void TaskbarIconFlashTimer_Tick(object sender, EventArgs e)
        {
            if (SwitchIcon)
            {
                this.TrayIcon.Icon = Properties.Resources.NoIcon;
            }
            else
            {
                this.TrayIcon.Icon = Properties.Resources.Icon;
            }

            SwitchIcon = !SwitchIcon;
        }

        void SystemBeepTimer_Tick(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
        }

        // handler for screen lock/unlock
        void SystemEvents_SessionSwitch(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
        {
            switch (e.Reason)
            {
                case Microsoft.Win32.SessionSwitchReason.SessionLock:
                    // when the screen is locked, stop everything as no point trying anything
                    StopMoveTimer();
                    break;
                case Microsoft.Win32.SessionSwitchReason.SessionUnlock:
                    // when the screen is unlocked, restart all the timers from new
                    StartMoveTimer();
                    break;
                default:
                    //do nothing for any other session change
                    break;
            }
        }
    }
}
