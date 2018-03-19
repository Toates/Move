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
            Application.ApplicationExit += new EventHandler(this.Application_Exit);

            FlashScreen = new FlashScreenForm();

            // setup system event handler to allow reset on screen lock return
            Microsoft.Win32.SystemEvents.SessionSwitch += new Microsoft.Win32.SessionSwitchEventHandler(SystemEvents_SessionSwitch);

            // taskbar icon
            this.TrayIcon = new NotifyIcon()
            {
                Text = "",
                Icon = Properties.Resources.Icon,
                Visible = true
            };

            // event handlers
            this.TrayIcon.DoubleClick += new EventHandler(TrayIcon_DoubleClick);
            //this.TrayIcon.Click += new EventHandler(TrayIcon_Click);
            this.TrayIcon.MouseMove += new MouseEventHandler(TrayIcon_MouseMove);
            MoveTimer.Tick += new EventHandler(MoveTimer_Tick);
            TaskbarIconFlashTimer.Tick += new EventHandler(TaskbarIconFlashTimer_Tick);
            SystemBeepTimer.Tick += new EventHandler(SystemBeepTimer_Tick);
            this.TrayIcon.BalloonTipClicked += new EventHandler(TrayIcon_BalloonTipClicked);
            this.TrayIcon.BalloonTipClosed += new EventHandler(TrayIcon_BalloonTipClosed);

            // tray icon context menu
            this.TrayIconContextMenu = new ContextMenuStrip();
            this.TrayIconContextMenu.SuspendLayout();

            this.TimerInterval = new ToolStripComboBox();
            this.ResetMenuItem = new ToolStripMenuItem();
            this.SettingsMenuItem = new ToolStripMenuItem();
            this.EnableFlashIcon = new ToolStripMenuItem();
            this.EnableSystemBeep = new ToolStripMenuItem();
            //this.EnableMessageBox = new ToolStripMenuItem();
            this.EnableBalloonToolTip = new ToolStripMenuItem();
            this.EnableScreenFlash = new ToolStripMenuItem();
            this.EnableMachineLock = new ToolStripMenuItem();
            this.CloseMenuItem = new ToolStripMenuItem();
            this.TrayIconContextMenu.Items.AddRange(new ToolStripItem[] {
                this.ResetMenuItem,
                this.SettingsMenuItem,
                this.CloseMenuItem
            });

            this.ResetMenuItem.Text = "Reset";
            this.ResetMenuItem.ToolTipText = "Resets the timer to the specified interval";
            this.ResetMenuItem.Click += new EventHandler(ResetMenuItem_Click);

            this.SettingsMenuItem.Text = "Settings";
            this.SettingsMenuItem.DropDown.Closing += new ToolStripDropDownClosingEventHandler(SettingsMenuItem_Closing);
            this.SettingsMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                this.TimerInterval,
                this.EnableFlashIcon,
                this.EnableSystemBeep,
                //this.EnableMessageBox,
                this.EnableBalloonToolTip,
                this.EnableScreenFlash,
                this.EnableMachineLock
            });
            
            this.TimerInterval.ToolTipText = "Sets the timer interval";
            this.TimerInterval.Items.AddRange(new object[] {
                1,2,3,4,5,6,7,8,9,10,
                11,12,13,14,15,16,17,18,19,20,
                21,22,23,24,25,26,27,28,29,30,
                31,32,33,34,35,36,37,38,39,40,
                41,42,43,44,45,46,47,48,49,50,
                51,52,53,54,55,56,57,58,59,60,
                61,62,63,64,65,66,67,68,69,70,
                71,72,73,74,75,76,77,78,79,80,
                81,82,83,84,85,86,87,88,89,90,
                91,92,93,94,95,96,97,98,99,100,

            });
            this.TimerInterval.SelectedItem = Properties.Settings.Default.IntervalMinutes;
            this.TimerInterval.SelectedText = Properties.Settings.Default.IntervalMinutes.ToString();
            this.TimerInterval.Text = Properties.Settings.Default.IntervalMinutes.ToString();
            this.TimerInterval.SelectedIndexChanged += new EventHandler(TimerInterval_SelectedIndexChanged);

            this.EnableFlashIcon.Text = "Flash Icon";
            this.EnableFlashIcon.ToolTipText = "When the timer expires, the taskbar icon will flash until reset";
            this.EnableFlashIcon.CheckOnClick = true;
            this.EnableFlashIcon.Click += new EventHandler(EnableFlashIcon_Click);
            this.EnableFlashIcon.Checked = Properties.Settings.Default.FlashIconEnabled;

            this.EnableSystemBeep.Text = "System Beep";
            this.EnableSystemBeep.ToolTipText = "When the timer expires, a sound will be output until reset";
            this.EnableSystemBeep.CheckOnClick = true;
            this.EnableSystemBeep.Click += new EventHandler(EnableSystemBeep_Click);
            this.EnableSystemBeep.Checked = Properties.Settings.Default.SystemBeepEnabled;

            //this.EnableMessageBox.Text = "Message Box";
            //this.EnableMessageBox.ToolTipText = "";
            //this.EnableMessageBox.CheckOnClick = true;
            //this.EnableMessageBox.Click += new EventHandler(EnableMessageBox_Click);
            //this.EnableMessageBox.Checked = Properties.Settings.Default.MessageBoxEnabled;

            this.EnableBalloonToolTip.Text = "Balloon ToolTip";
            this.EnableBalloonToolTip.ToolTipText = "When the timer expires, a tooltip will appear for a short period and will reset the timer itself on closure";
            this.EnableBalloonToolTip.CheckOnClick = true;
            this.EnableBalloonToolTip.Click += new EventHandler(EnableBalloonToolTip_Click);
            this.EnableBalloonToolTip.Checked = Properties.Settings.Default.BalloonTipEnabled;

            this.EnableScreenFlash.Text = "Flash Screen";
            this.EnableScreenFlash.ToolTipText = "When the timer expires, the screen will flash until reset";
            this.EnableScreenFlash.CheckOnClick = true;
            this.EnableScreenFlash.Click += new EventHandler(EnableScreenFlash_Click);
            this.EnableScreenFlash.Checked = Properties.Settings.Default.FlashScreenEnabled;

            this.EnableMachineLock.Text = "Lock Machine";
            this.EnableMachineLock.ToolTipText = "When the timer expires, the machine will be locked and require unlocking";
            this.EnableMachineLock.CheckOnClick = true;
            this.EnableMachineLock.Click += new EventHandler(EnableMachineLock_Click);
            this.EnableMachineLock.Checked = Properties.Settings.Default.LockMachineEnabled;

            this.CloseMenuItem.Text = "Close";
            this.CloseMenuItem.ToolTipText = "Closes the application";
            this.CloseMenuItem.Click += new EventHandler(this.CloseMenuItem_Click);

            this.TrayIcon.ContextMenuStrip = TrayIconContextMenu;

            this.TrayIconContextMenu.ResumeLayout();
        }
        
        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            Action_Accepted(sender, e);
        }

        //private void TrayIcon_Click(object sender, EventArgs e)
        //{
        //}

        private void TrayIcon_MouseMove(object sender, EventArgs e)
        {
            // only display the time left if it is valid to do so
            if (MoveTimer.Interval >= stopwatch.ElapsedMilliseconds)
            {
                this.TrayIcon.Text = 
                    TimeSpan.FromMilliseconds
                    (MoveTimer.Interval - stopwatch.ElapsedMilliseconds).ToString(@"hh\:mm\:ss");
            }
            // otherwise just display nothing TODO: or could display a different message
            else
            {
                this.TrayIcon.Text = "";
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
            //this.TrayIconContextMenu.Close();
            Action_Accepted(sender, e);
        }

        private void SettingsMenuItem_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                e.Cancel = true;
            }
        }

        //private void SettingsMenuItem_Click(object sender, EventArgs e)
        //{
        //}

        private void TimerInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IntervalMinutes = (int)this.TimerInterval.SelectedItem;
            Properties.Settings.Default.Save();

            StartMoveTimer();
        }

        private void EnableFlashIcon_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FlashIconEnabled = this.EnableFlashIcon.Checked;
            Properties.Settings.Default.Save();
        }

        private void EnableSystemBeep_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SystemBeepEnabled = this.EnableSystemBeep.Checked;
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
            Properties.Settings.Default.BalloonTipEnabled = this.EnableBalloonToolTip.Checked;

            //if (this.EnableBalloonToolTip.Checked)
            //{
            //    this.EnableMessageBox.Checked = false;
            //    Properties.Settings.Default.MessageBoxEnabled = false;
            //}

            Properties.Settings.Default.Save();
        }
        private void EnableScreenFlash_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FlashScreenEnabled = this.EnableScreenFlash.Checked;
            Properties.Settings.Default.Save();
        }
        private void EnableMachineLock_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LockMachineEnabled = this.EnableMachineLock.Checked;
            Properties.Settings.Default.Save();
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Application_Exit(object sender, EventArgs e)
        {
            // store all user settings for next startup
            Properties.Settings.Default.Save();

            // ensure the icon is be removed when the application is closed
            TrayIcon.Visible = false;
        }
    }
}
