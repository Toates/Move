using System;
using System.Windows.Forms;

namespace Move
{
    partial class MoveTaskbar : ApplicationContext
    {
        internal static class NativeMethods
        {
            // pinvoke for locking the workstation
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
            internal static extern bool LockWorkStation();
        }

        // the timing elements
        private Timer MoveTimer = new Timer();
        private Timer TaskbarIconFlashTimer = new Timer();
        private Timer SystemBeepTimer = new Timer();

        // move timer not able to return current status so stopwatch used to display the time until expiry
        private System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        
        void MoveTimer_Tick(object sender, EventArgs e)
        {
            TrayIconContextMenu.Close();
            PauseMenuItem.Enabled = false;
            StopMoveTimer();
            StartActions();
        }

        void StartMoveTimer()
        {
            MoveTimer.Stop();
            MoveTimer.Interval = (int)TimeSpan.FromMinutes(Properties.Settings.Default.MoveIntervalMinutes).TotalMilliseconds;
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
            bool MachineLocked = false;
            
            //LockMachine
            if (Properties.Settings.Default.ActionLockMachineEnabled)
            {
                MachineLocked = NativeMethods.LockWorkStation();
            }

            // if the machine has been locked, no point triggering any other actions
            if (!MachineLocked)
            {
                //TaskbarIconFlash
                if (Properties.Settings.Default.ActionFlashIconEnabled)
                {
                    TaskbarIconFlashTimer.Interval = Properties.Settings.Default.ActionFlashIconSpeed;
                    TaskbarIconFlashTimer.Start();
                }

                //SystemBeep
                if (Properties.Settings.Default.ActionSystemBeepEnabled)
                {
                    SystemBeepTimer.Interval = Properties.Settings.Default.ActionSystemBeepSpeed;
                    SystemBeepTimer.Start();
                }
                
                //BalloonTip 
                if (Properties.Settings.Default.ActionBalloonTipEnabled)
                {
                    // does not use the timeout value given and will close itself after ~5 seconds
                    // balloontipclosed is triggered on both user and system closures with no way of differentiating 
                    // so either we stop actions on all closures, limiting its effectiveness
                    // or we do not react to closure, leaving the user to have to double click to stop
                    // stopping on closure is the least worse, just need to make clear in settings and allow disabling
                    // also single click on icon is treated as a click on the balloontip when displayed for some reason
                    TrayIcon.ShowBalloonTip(60000, "", Properties.Settings.Default.ActionBalloonTipText, ToolTipIcon.None);
                }

                //FlashScreen
                if (Properties.Settings.Default.ActionFlashScreenEnabled)
                {
                    if (FlashScreen == null || FlashScreen.IsDisposed)
                    {
                        using (FlashScreen = new FlashScreenForm())
                        {
                            FlashScreen.ShowDialog();
                        }
                    }
                }
            }
        }

        void StopActions()
        {
            //TaskbarIconFlash
            if (Properties.Settings.Default.ActionFlashIconEnabled)
            {
                TaskbarIconFlashTimer.Stop();
            }

            //SystemBeep
            if (Properties.Settings.Default.ActionSystemBeepEnabled)
            {
                SystemBeepTimer.Stop();
            }
            
            //BalloonTip
            if (Properties.Settings.Default.ActionBalloonTipEnabled)
            {
                // this forces the BalloonTip to close
                TrayIcon.Visible = true;
            }

            //FlashScreen
            if (Properties.Settings.Default.ActionFlashScreenEnabled)
            {
                FlashScreen.Close();
            }

            //LockMachine - nothing to disable as if this was enabled, 
            // the machine would have been locked
        }
        
        void Action_Accepted(object sender, EventArgs e)
        {
            StopActions();
            StartMoveTimer();

            PauseMenuItem.Enabled = true;
            PauseMenuItem.Text = Properties.Resources.PauseMenuItem_TextPause;

            TrayIcon.Icon = Properties.Resources.Icon;
        }

        private bool SwitchIcon = true;
        void TaskbarIconFlashTimer_Tick(object sender, EventArgs e)
        {
            if (SwitchIcon)
            {
                TrayIcon.Icon = Properties.Resources.IconBlank;
            }
            else
            {
                TrayIcon.Icon = Properties.Resources.Icon;
            }

            SwitchIcon = !SwitchIcon;
        }

        void SystemBeepTimer_Tick(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
        }

        void SystemEvents_SessionSwitch(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
        {
            switch (e.Reason)
            {
                case Microsoft.Win32.SessionSwitchReason.SessionLock:
                    // when the screen is locked, stop everything as no point trying anything
                    StopMoveTimer();
                    break;
                case Microsoft.Win32.SessionSwitchReason.SessionUnlock:
                    StartMoveTimer();
                    break;
                default:
                    //do nothing for any other session change
                    break;
            }
        }
    }
}
