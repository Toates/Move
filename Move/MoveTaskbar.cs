using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

// TODO: - Add change of logo
//- Add more configuration e.g.flicker speed, etc
//- disable until restart (close)
//- disable until xxx
//- personalised alerts

[assembly: CLSCompliant(true)]
namespace Move
{
    partial class MoveTaskbar : ApplicationContext
    {
        // declares the taskbar icon and related menu
        private NotifyIcon TrayIcon;
        private ContextMenuStrip TrayIconContextMenu;
        private ToolStripMenuItem ResetMenuItem;
        private ToolStripMenuItem SettingsMenuItem;
        private ToolStripMenuItem CloseMenuItem;
        private ToolStripComboBox TimerInterval;
        private ToolStripMenuItem EnableFlashIcon;
        private ToolStripMenuItem EnableSystemBeep;
        //private ToolStripMenuItem EnableMessageBox;
        private ToolStripMenuItem EnableBalloonToolTip;
        private ToolStripMenuItem EnableScreenFlash;
        private ToolStripMenuItem EnableMachineLock;
        private FlashScreenForm FlashScreen;

        public MoveTaskbar()
        {
            InitializeComponent();

            // start the logic
            StartMoveTimer();
        }

        private void InitializeComponent()
        {
            // before initialising, attempt to load user configuration TODO: check whether this should be done before or after
            Properties.Settings.Default.Reload();

            // setup application event handlers
            Application.ApplicationExit += new EventHandler(Application_Exit);

            FlashScreen = new FlashScreenForm();

            // setup system event handler to allow reset on screen lock return
            Microsoft.Win32.SystemEvents.SessionSwitch += new Microsoft.Win32.SessionSwitchEventHandler(SystemEvents_SessionSwitch);

            // taskbar icon
            TrayIcon = new NotifyIcon()
            {
                Text = "",
                Icon = Properties.Resources.Icon,
                Visible = true
            };

            // event handlers
            TrayIcon.DoubleClick += new EventHandler(TrayIcon_DoubleClick);
            TrayIcon.MouseMove += new MouseEventHandler(TrayIcon_MouseMove);
            MoveTimer.Tick += new EventHandler(MoveTimer_Tick);
            TaskbarIconFlashTimer.Tick += new EventHandler(TaskbarIconFlashTimer_Tick);
            SystemBeepTimer.Tick += new EventHandler(SystemBeepTimer_Tick);
            TrayIcon.BalloonTipClicked += new EventHandler(TrayIcon_BalloonTipClicked);
            TrayIcon.BalloonTipClosed += new EventHandler(TrayIcon_BalloonTipClosed);

            // tray icon context menu
            TrayIconContextMenu = new ContextMenuStrip();
            TrayIconContextMenu.SuspendLayout();

            TimerInterval = new ToolStripComboBox();
            ResetMenuItem = new ToolStripMenuItem();
            SettingsMenuItem = new ToolStripMenuItem();
            EnableFlashIcon = new ToolStripMenuItem();
            EnableSystemBeep = new ToolStripMenuItem();
            //this.EnableMessageBox = new ToolStripMenuItem();
            EnableBalloonToolTip = new ToolStripMenuItem();
            EnableScreenFlash = new ToolStripMenuItem();
            EnableMachineLock = new ToolStripMenuItem();
            CloseMenuItem = new ToolStripMenuItem();
            TrayIconContextMenu.Items.AddRange(new ToolStripItem[] {
                ResetMenuItem,
                SettingsMenuItem,
                CloseMenuItem
            });

            ResetMenuItem.Text = Properties.Resources.ResetMenuItem_Text;
            ResetMenuItem.ToolTipText = Properties.Resources.ResetMenuItem_ToolTipText;
            ResetMenuItem.Click += new EventHandler(ResetMenuItem_Click);

            SettingsMenuItem.Text = Properties.Resources.SettingsMenuItem_Text;
            SettingsMenuItem.DropDown.Closing += new ToolStripDropDownClosingEventHandler(SettingsMenuItem_Closing);
            SettingsMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                TimerInterval,
                EnableFlashIcon,
                EnableSystemBeep,
                //this.EnableMessageBox,
                EnableBalloonToolTip,
                EnableScreenFlash,
                EnableMachineLock
            });

            TimerInterval.ToolTipText = Properties.Resources.TimerInterval_ToolTipText;
            TimerInterval.Items.AddRange(new object[] {
                1,2,3,4,5,6,7,8,9,10,
                11,12,13,14,15,16,17,18,19,20,
                21,22,23,24,25,26,27,28,29,30,
                31,32,33,34,35,36,37,38,39,40,
                41,42,43,44,45,46,47,48,49,50,
                51,52,53,54,55,56,57,58,59,60,
            });
            //TODO: not all needed
            TimerInterval.SelectedItem = Properties.Settings.Default.IntervalMinutes;
            TimerInterval.SelectedText = Properties.Settings.Default.IntervalMinutes.ToString(System.Globalization.CultureInfo.CurrentCulture);
            TimerInterval.Text = Properties.Settings.Default.IntervalMinutes.ToString(System.Globalization.CultureInfo.CurrentCulture);
            TimerInterval.SelectedIndexChanged += new EventHandler(TimerInterval_SelectedIndexChanged);

            EnableFlashIcon.Text = Properties.Resources.EnableFlashIcon_Text;
            EnableFlashIcon.ToolTipText = Properties.Resources.EnableFlashIcon_ToolTipText;
            EnableFlashIcon.CheckOnClick = true;
            EnableFlashIcon.Click += new EventHandler(EnableFlashIcon_Click);
            EnableFlashIcon.Checked = Properties.Settings.Default.FlashIconEnabled;

            EnableSystemBeep.Text = Properties.Resources.EnableSystemBeep_Text;
            EnableSystemBeep.ToolTipText = Properties.Resources.EnableSystemBeep_ToolTipText;
            EnableSystemBeep.CheckOnClick = true;
            EnableSystemBeep.Click += new EventHandler(EnableSystemBeep_Click);
            EnableSystemBeep.Checked = Properties.Settings.Default.SystemBeepEnabled;

            //this.EnableMessageBox.Text = "Message Box";
            //this.EnableMessageBox.ToolTipText = "";
            //this.EnableMessageBox.CheckOnClick = true;
            //this.EnableMessageBox.Click += new EventHandler(EnableMessageBox_Click);
            //this.EnableMessageBox.Checked = Properties.Settings.Default.MessageBoxEnabled;

            EnableBalloonToolTip.Text = Properties.Resources.EnableBalloonToolTip_Text;
            EnableBalloonToolTip.ToolTipText = Properties.Resources.EnableBalloonToolTip_TooltipText;
            EnableBalloonToolTip.CheckOnClick = true;
            EnableBalloonToolTip.Click += new EventHandler(EnableBalloonToolTip_Click);
            EnableBalloonToolTip.Checked = Properties.Settings.Default.BalloonTipEnabled;

            EnableScreenFlash.Text = Properties.Resources.EnableScreenFlash_Text;
            EnableScreenFlash.ToolTipText = Properties.Resources.EnableScreenFlash_ToolTipText;
            EnableScreenFlash.CheckOnClick = true;
            EnableScreenFlash.Click += new EventHandler(EnableScreenFlash_Click);
            EnableScreenFlash.Checked = Properties.Settings.Default.FlashScreenEnabled;

            EnableMachineLock.Text = Properties.Resources.EnableMachineLock_Text;
            EnableMachineLock.ToolTipText = Properties.Resources.EnableMachineLock_ToolTipText;
            EnableMachineLock.CheckOnClick = true;
            EnableMachineLock.Click += new EventHandler(EnableMachineLock_Click);
            EnableMachineLock.Checked = Properties.Settings.Default.LockMachineEnabled;

            CloseMenuItem.Text = Properties.Resources.CloseMenuItem_Text;
            CloseMenuItem.ToolTipText = Properties.Resources.CloseMenuItem_ToolTipText;
            CloseMenuItem.Click += new EventHandler(CloseMenuItem_Click);

            TrayIcon.ContextMenuStrip = TrayIconContextMenu;

            TrayIconContextMenu.ResumeLayout();
        }
        
        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            Action_Accepted(sender, e);
        }

        private void TrayIcon_MouseMove(object sender, EventArgs e)
        {
            // only display the time left if it is valid to do so
            if (MoveTimer.Interval >= stopwatch.ElapsedMilliseconds)
            {
                TrayIcon.Text = 
                    TimeSpan.FromMilliseconds
                    (MoveTimer.Interval - stopwatch.ElapsedMilliseconds).ToString(@"hh\:mm\:ss", System.Globalization.CultureInfo.CurrentCulture);
            }
            // otherwise just display nothing
            else
            {
                TrayIcon.Text = "";
            }
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

        private void SettingsMenuItem_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                e.Cancel = true;
            }
        }
        
        private void TimerInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IntervalMinutes = (int)TimerInterval.SelectedItem;
            Properties.Settings.Default.Save();

            StartMoveTimer();
        }

        private void EnableFlashIcon_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FlashIconEnabled = EnableFlashIcon.Checked;
            Properties.Settings.Default.Save();
        }

        private void EnableSystemBeep_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SystemBeepEnabled = EnableSystemBeep.Checked;
            Properties.Settings.Default.Save();
        }

        //private void EnableMessageBox_Click(object sender, EventArgs e)
        //{
        //    Properties.Settings.Default.MessageBoxEnabled = this.EnableMessageBox.Checked;

        //    if (this.EnableMessageBox.Checked)
        //    {
        //        this.EnableBalloonToolTip.Checked = false;
        //        Properties.Settings.Default.BalloonTipEnabled = false;
        //    }

        //    Properties.Settings.Default.Save();
        //}

        private void EnableBalloonToolTip_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.BalloonTipEnabled = EnableBalloonToolTip.Checked;

            //if (this.EnableBalloonToolTip.Checked)
            //{
            //    this.EnableMessageBox.Checked = false;
            //    Properties.Settings.Default.MessageBoxEnabled = false;
            //}

            Properties.Settings.Default.Save();
        }
        private void EnableScreenFlash_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FlashScreenEnabled = EnableScreenFlash.Checked;
            Properties.Settings.Default.Save();
        }

        private void EnableMachineLock_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LockMachineEnabled = EnableMachineLock.Checked;
            Properties.Settings.Default.Save();
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Application_Exit(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();

            // ensure the icon is be removed when the application is closed
            TrayIcon.Visible = false;
        }
    }
}
