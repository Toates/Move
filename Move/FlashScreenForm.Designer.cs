namespace Move
{
    partial class FlashScreenForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FlashScreenFormTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // FlashScreenFormTimer
            // 
            this.FlashScreenFormTimer.Enabled = true;
            this.FlashScreenFormTimer.Interval = global::Move.Properties.Settings.Default.ActionFlashScreenSpeed;
            this.FlashScreenFormTimer.Tick += new System.EventHandler(this.FlashScreenFormTimer_Tick);
            // 
            // FlashScreenForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(100, 100);
            this.ControlBox = false;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DataBindings.Add(new System.Windows.Forms.Binding("Opacity", global::Move.Properties.Settings.Default, "ActionFlashScreenOpacity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FlashScreenForm";
            this.Opacity = global::Move.Properties.Settings.Default.ActionFlashScreenOpacity;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FlashScreenForm_FormClosed);
            this.Load += new System.EventHandler(this.FlashScreenForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer FlashScreenFormTimer;
    }
}