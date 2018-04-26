using System;
using System.Windows.Forms;

[assembly: CLSCompliant(true)]
namespace Move
{
    partial class MoveTaskbar : ApplicationContext
    {
        private NotifyIcon TrayIcon;
        private ContextMenuStrip TrayIconContextMenu;
        private ToolStripMenuItem ResetMenuItem;
        private ToolStripMenuItem PauseMenuItem;
        private ToolStripMenuItem SettingsMenuItem;
        private ToolStripMenuItem CloseMenuItem;
        private FlashScreenForm FlashScreen;
        private SettingsForm SettingsForm;

        public MoveTaskbar()
        {
            InitializeComponent();
            StartMoveTimer();
        }

        private void InitializeComponent()
        {
            // before initialising, load any previous user configuration
            Properties.Settings.Default.Reload();

            // taskbar icon
            TrayIcon = new NotifyIcon()
            {
                Text = "",
                Icon = Properties.Resources.Icon,
                Visible = true
            };

            // tray icon context menu
            TrayIconContextMenu = new ContextMenuStrip();
            TrayIconContextMenu.SuspendLayout();

            ResetMenuItem = new ToolStripMenuItem()
            {
                Text = Properties.Resources.ResetMenuItem_Text
            };

            PauseMenuItem = new ToolStripMenuItem()
            {
                Text = Properties.Resources.PauseMenuItem_TextPause
            };

            SettingsMenuItem = new ToolStripMenuItem()
            {
                Text = Properties.Resources.SettingsMenuItem_Text
            };

            CloseMenuItem = new ToolStripMenuItem()
            {
                Text = Properties.Resources.CloseMenuItem_Text
            };

            TrayIconContextMenu.Items.AddRange(new ToolStripItem[] {
                ResetMenuItem,
                PauseMenuItem,
                SettingsMenuItem,
                CloseMenuItem
            });

            TrayIcon.ContextMenuStrip = TrayIconContextMenu;
 
            TrayIconContextMenu.ResumeLayout();

            // event handlers
            TrayIcon.DoubleClick += new EventHandler(TrayIcon_DoubleClick);
            TrayIcon.MouseMove += new MouseEventHandler(TrayIcon_MouseMove);
            MoveTimer.Tick += new EventHandler(MoveTimer_Tick);
            TaskbarIconFlashTimer.Tick += new EventHandler(TaskbarIconFlashTimer_Tick);
            SystemBeepTimer.Tick += new EventHandler(SystemBeepTimer_Tick);
            TrayIcon.BalloonTipClicked += new EventHandler(TrayIcon_BalloonTipClicked);
            TrayIcon.BalloonTipClosed += new EventHandler(TrayIcon_BalloonTipClosed);
            ResetMenuItem.Click += new EventHandler(ResetMenuItem_Click);
            PauseMenuItem.Click += new EventHandler(PauseMenuItem_Click);
            SettingsMenuItem.Click += new EventHandler(SettingsMenuItem_Click);
            CloseMenuItem.Click += new EventHandler(CloseMenuItem_Click);
            Application.ApplicationExit += new EventHandler(Application_Exit);
            // allows reset on screen lock return
            Microsoft.Win32.SystemEvents.SessionSwitch += new Microsoft.Win32.SessionSwitchEventHandler(SystemEvents_SessionSwitch);

        }

        private void TrayIcon_MouseMove(object sender, EventArgs e)
        {
            if (PauseMenuItem.Text == Properties.Resources.PauseMenuItem_TextPause)
            {
                // only display the time left if it is valid to do so
                if (MoveTimer.Interval >= stopwatch.ElapsedMilliseconds)
                {
                    TrayIcon.Text =
                        TimeSpan.FromMilliseconds
                         (MoveTimer.Interval - stopwatch.ElapsedMilliseconds).ToString
                          (@"hh\:mm\:ss", System.Globalization.CultureInfo.CurrentCulture);
                }
                // otherwise just display nothing
                else
                {
                    TrayIcon.Text = "";
                }
            }
            else
            {
                TrayIcon.Text = "Paused";
            }
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            Action_Accepted(sender, e);
        }

        private void TrayIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            Action_Accepted(sender, e);
        }

        private void TrayIcon_BalloonTipClosed(object sender, EventArgs e)
        {
            Action_Accepted(sender, e);
        }

        private void ResetMenuItem_Click(object sender, EventArgs e)
        {
            Action_Accepted(sender, e);
        }

        private void PauseMenuItem_Click(object sender, EventArgs e)
        {
            if (PauseMenuItem.Text == Properties.Resources.PauseMenuItem_TextPause)
            {
                StopMoveTimer();
                PauseMenuItem.Text = Properties.Resources.PauseMenuItem_TextResume;
                TrayIcon.Icon = Properties.Resources.IconPaused;
            }
            else
            {
                StartMoveTimer();
                PauseMenuItem.Text = Properties.Resources.PauseMenuItem_TextPause;
                TrayIcon.Icon = Properties.Resources.Icon;
            }
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            StopMoveTimer();

            if (SettingsForm == null || SettingsForm.IsDisposed)
            {
                using (SettingsForm = new SettingsForm())
                {
                    SettingsForm.ShowDialog();
                }
            }

            StartMoveTimer();
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Application_Exit(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();

            // ensure the icon is removed when the application is closed
            TrayIcon.Visible = false;
        }
    }
}
