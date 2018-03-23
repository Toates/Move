namespace Move
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.FlashIconGroupBox = new System.Windows.Forms.GroupBox();
            this.FlashIconSpeedLabel = new System.Windows.Forms.Label();
            this.FlashIconSpeedValueLabel = new System.Windows.Forms.Label();
            this.SystemBeepGroupBox = new System.Windows.Forms.GroupBox();
            this.BalloonTipGroupBox = new System.Windows.Forms.GroupBox();
            this.FlashScreenGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FlashScreenTransparencyTrackBar = new System.Windows.Forms.TrackBar();
            this.FlashScreenTransparencyLabel = new System.Windows.Forms.Label();
            this.FlashScreenColourLabel = new System.Windows.Forms.Label();
            this.FlashScreenSpeedLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LockMachineGroupBox = new System.Windows.Forms.GroupBox();
            this.OtherGroupBox = new System.Windows.Forms.GroupBox();
            this.RunOnStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.MoveIntervalLabel = new System.Windows.Forms.Label();
            this.MoveTimerIntervalLabel = new System.Windows.Forms.Label();
            this.MoveTimerIntervalTrackBar = new System.Windows.Forms.TrackBar();
            this.LockMachineEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.FlashScreenEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.FlashScreenSpeedTrackBar = new System.Windows.Forms.TrackBar();
            this.BalloonTipEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.SystemBeepEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.ActionFlashIconEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.FlashIconSpeedTrackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.FlashIconGroupBox.SuspendLayout();
            this.SystemBeepGroupBox.SuspendLayout();
            this.BalloonTipGroupBox.SuspendLayout();
            this.FlashScreenGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlashScreenTransparencyTrackBar)).BeginInit();
            this.LockMachineGroupBox.SuspendLayout();
            this.OtherGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MoveTimerIntervalTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlashScreenSpeedTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlashIconSpeedTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Random",
            "Black & White",
            "Custom"});
            this.comboBox1.Location = new System.Drawing.Point(63, 136);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // FlashIconGroupBox
            // 
            this.FlashIconGroupBox.Controls.Add(this.FlashIconSpeedLabel);
            this.FlashIconGroupBox.Controls.Add(this.ActionFlashIconEnabledCheckBox);
            this.FlashIconGroupBox.Controls.Add(this.FlashIconSpeedValueLabel);
            this.FlashIconGroupBox.Controls.Add(this.FlashIconSpeedTrackBar);
            this.FlashIconGroupBox.Location = new System.Drawing.Point(12, 12);
            this.FlashIconGroupBox.Name = "FlashIconGroupBox";
            this.FlashIconGroupBox.Size = new System.Drawing.Size(776, 100);
            this.FlashIconGroupBox.TabIndex = 7;
            this.FlashIconGroupBox.TabStop = false;
            this.FlashIconGroupBox.Text = "Flash Icon";
            // 
            // FlashIconSpeedLabel
            // 
            this.FlashIconSpeedLabel.AutoSize = true;
            this.FlashIconSpeedLabel.Location = new System.Drawing.Point(6, 51);
            this.FlashIconSpeedLabel.Name = "FlashIconSpeedLabel";
            this.FlashIconSpeedLabel.Size = new System.Drawing.Size(41, 13);
            this.FlashIconSpeedLabel.TabIndex = 22;
            this.FlashIconSpeedLabel.Text = "Speed:";
            // 
            // FlashIconSpeedValueLabel
            // 
            this.FlashIconSpeedValueLabel.AutoSize = true;
            this.FlashIconSpeedValueLabel.Location = new System.Drawing.Point(480, 51);
            this.FlashIconSpeedValueLabel.Name = "FlashIconSpeedValueLabel";
            this.FlashIconSpeedValueLabel.Size = new System.Drawing.Size(57, 13);
            this.FlashIconSpeedValueLabel.TabIndex = 21;
            this.FlashIconSpeedValueLabel.Text = "EXAMPLE";
            // 
            // SystemBeepGroupBox
            // 
            this.SystemBeepGroupBox.Controls.Add(this.label4);
            this.SystemBeepGroupBox.Controls.Add(this.label3);
            this.SystemBeepGroupBox.Controls.Add(this.label5);
            this.SystemBeepGroupBox.Controls.Add(this.comboBox2);
            this.SystemBeepGroupBox.Controls.Add(this.trackBar1);
            this.SystemBeepGroupBox.Controls.Add(this.SystemBeepEnabledCheckBox);
            this.SystemBeepGroupBox.Location = new System.Drawing.Point(12, 353);
            this.SystemBeepGroupBox.Name = "SystemBeepGroupBox";
            this.SystemBeepGroupBox.Size = new System.Drawing.Size(776, 127);
            this.SystemBeepGroupBox.TabIndex = 8;
            this.SystemBeepGroupBox.TabStop = false;
            this.SystemBeepGroupBox.Text = "System Beep";
            // 
            // BalloonTipGroupBox
            // 
            this.BalloonTipGroupBox.Controls.Add(this.textBox1);
            this.BalloonTipGroupBox.Controls.Add(this.label6);
            this.BalloonTipGroupBox.Controls.Add(this.BalloonTipEnabledCheckBox);
            this.BalloonTipGroupBox.Location = new System.Drawing.Point(12, 486);
            this.BalloonTipGroupBox.Name = "BalloonTipGroupBox";
            this.BalloonTipGroupBox.Size = new System.Drawing.Size(776, 115);
            this.BalloonTipGroupBox.TabIndex = 13;
            this.BalloonTipGroupBox.TabStop = false;
            this.BalloonTipGroupBox.Text = "Balloon Tip";
            // 
            // FlashScreenGroupBox
            // 
            this.FlashScreenGroupBox.Controls.Add(this.label1);
            this.FlashScreenGroupBox.Controls.Add(this.FlashScreenTransparencyTrackBar);
            this.FlashScreenGroupBox.Controls.Add(this.FlashScreenTransparencyLabel);
            this.FlashScreenGroupBox.Controls.Add(this.FlashScreenColourLabel);
            this.FlashScreenGroupBox.Controls.Add(this.FlashScreenSpeedLabel);
            this.FlashScreenGroupBox.Controls.Add(this.FlashScreenEnabledCheckBox);
            this.FlashScreenGroupBox.Controls.Add(this.label2);
            this.FlashScreenGroupBox.Controls.Add(this.FlashScreenSpeedTrackBar);
            this.FlashScreenGroupBox.Controls.Add(this.comboBox1);
            this.FlashScreenGroupBox.Location = new System.Drawing.Point(12, 118);
            this.FlashScreenGroupBox.Name = "FlashScreenGroupBox";
            this.FlashScreenGroupBox.Size = new System.Drawing.Size(776, 229);
            this.FlashScreenGroupBox.TabIndex = 14;
            this.FlashScreenGroupBox.TabStop = false;
            this.FlashScreenGroupBox.Text = "Flash Screen";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(480, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "EXAMPLE";
            // 
            // FlashScreenTransparencyTrackBar
            // 
            this.FlashScreenTransparencyTrackBar.Location = new System.Drawing.Point(87, 87);
            this.FlashScreenTransparencyTrackBar.Maximum = 100;
            this.FlashScreenTransparencyTrackBar.Minimum = 1;
            this.FlashScreenTransparencyTrackBar.Name = "FlashScreenTransparencyTrackBar";
            this.FlashScreenTransparencyTrackBar.Size = new System.Drawing.Size(230, 45);
            this.FlashScreenTransparencyTrackBar.TabIndex = 28;
            this.FlashScreenTransparencyTrackBar.Value = 1;
            this.FlashScreenTransparencyTrackBar.Scroll += new System.EventHandler(this.FlashScreenTransparencyTrackBar_Scroll);
            // 
            // FlashScreenTransparencyLabel
            // 
            this.FlashScreenTransparencyLabel.AutoSize = true;
            this.FlashScreenTransparencyLabel.Location = new System.Drawing.Point(6, 87);
            this.FlashScreenTransparencyLabel.Name = "FlashScreenTransparencyLabel";
            this.FlashScreenTransparencyLabel.Size = new System.Drawing.Size(75, 13);
            this.FlashScreenTransparencyLabel.TabIndex = 27;
            this.FlashScreenTransparencyLabel.Text = "Transparency:";
            // 
            // FlashScreenColourLabel
            // 
            this.FlashScreenColourLabel.AutoSize = true;
            this.FlashScreenColourLabel.Location = new System.Drawing.Point(6, 139);
            this.FlashScreenColourLabel.Name = "FlashScreenColourLabel";
            this.FlashScreenColourLabel.Size = new System.Drawing.Size(51, 13);
            this.FlashScreenColourLabel.TabIndex = 26;
            this.FlashScreenColourLabel.Text = "Colour(s):";
            // 
            // FlashScreenSpeedLabel
            // 
            this.FlashScreenSpeedLabel.AutoSize = true;
            this.FlashScreenSpeedLabel.Location = new System.Drawing.Point(6, 42);
            this.FlashScreenSpeedLabel.Name = "FlashScreenSpeedLabel";
            this.FlashScreenSpeedLabel.Size = new System.Drawing.Size(41, 13);
            this.FlashScreenSpeedLabel.TabIndex = 25;
            this.FlashScreenSpeedLabel.Text = "Speed:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(480, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "EXAMPLE";
            // 
            // LockMachineGroupBox
            // 
            this.LockMachineGroupBox.Controls.Add(this.LockMachineEnabledCheckBox);
            this.LockMachineGroupBox.Location = new System.Drawing.Point(12, 654);
            this.LockMachineGroupBox.Name = "LockMachineGroupBox";
            this.LockMachineGroupBox.Size = new System.Drawing.Size(776, 57);
            this.LockMachineGroupBox.TabIndex = 14;
            this.LockMachineGroupBox.TabStop = false;
            this.LockMachineGroupBox.Text = "Lock Machine";
            // 
            // OtherGroupBox
            // 
            this.OtherGroupBox.Controls.Add(this.RunOnStartupCheckBox);
            this.OtherGroupBox.Controls.Add(this.MoveIntervalLabel);
            this.OtherGroupBox.Controls.Add(this.MoveTimerIntervalLabel);
            this.OtherGroupBox.Controls.Add(this.MoveTimerIntervalTrackBar);
            this.OtherGroupBox.Location = new System.Drawing.Point(12, 717);
            this.OtherGroupBox.Name = "OtherGroupBox";
            this.OtherGroupBox.Size = new System.Drawing.Size(776, 120);
            this.OtherGroupBox.TabIndex = 16;
            this.OtherGroupBox.TabStop = false;
            this.OtherGroupBox.Text = "Other";
            // 
            // RunOnStartupCheckBox
            // 
            this.RunOnStartupCheckBox.AutoSize = true;
            this.RunOnStartupCheckBox.Location = new System.Drawing.Point(9, 70);
            this.RunOnStartupCheckBox.Name = "RunOnStartupCheckBox";
            this.RunOnStartupCheckBox.Size = new System.Drawing.Size(96, 17);
            this.RunOnStartupCheckBox.TabIndex = 16;
            this.RunOnStartupCheckBox.Text = "Run on startup";
            this.RunOnStartupCheckBox.UseVisualStyleBackColor = true;
            // 
            // MoveIntervalLabel
            // 
            this.MoveIntervalLabel.AutoSize = true;
            this.MoveIntervalLabel.Location = new System.Drawing.Point(6, 16);
            this.MoveIntervalLabel.Name = "MoveIntervalLabel";
            this.MoveIntervalLabel.Size = new System.Drawing.Size(75, 13);
            this.MoveIntervalLabel.TabIndex = 19;
            this.MoveIntervalLabel.Text = "Move Interval:";
            // 
            // MoveTimerIntervalLabel
            // 
            this.MoveTimerIntervalLabel.AutoSize = true;
            this.MoveTimerIntervalLabel.Location = new System.Drawing.Point(323, 16);
            this.MoveTimerIntervalLabel.Name = "MoveTimerIntervalLabel";
            this.MoveTimerIntervalLabel.Size = new System.Drawing.Size(47, 13);
            this.MoveTimerIntervalLabel.TabIndex = 18;
            this.MoveTimerIntervalLabel.Text = "1 minute";
            // 
            // MoveTimerIntervalTrackBar
            // 
            this.MoveTimerIntervalTrackBar.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Move.Properties.Settings.Default, "MoveIntervalMinutes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.MoveTimerIntervalTrackBar.Location = new System.Drawing.Point(87, 16);
            this.MoveTimerIntervalTrackBar.Maximum = 60;
            this.MoveTimerIntervalTrackBar.Minimum = 1;
            this.MoveTimerIntervalTrackBar.Name = "MoveTimerIntervalTrackBar";
            this.MoveTimerIntervalTrackBar.Size = new System.Drawing.Size(230, 45);
            this.MoveTimerIntervalTrackBar.TabIndex = 17;
            this.MoveTimerIntervalTrackBar.Value = global::Move.Properties.Settings.Default.MoveIntervalMinutes;
            this.MoveTimerIntervalTrackBar.Scroll += new System.EventHandler(this.MoveTimerInterval_Scroll);
            // 
            // LockMachineEnabledCheckBox
            // 
            this.LockMachineEnabledCheckBox.AutoSize = true;
            this.LockMachineEnabledCheckBox.Checked = global::Move.Properties.Settings.Default.ActionLockMachineEnabled;
            this.LockMachineEnabledCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Move.Properties.Settings.Default, "ActionLockMachineEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.LockMachineEnabledCheckBox.Location = new System.Drawing.Point(6, 19);
            this.LockMachineEnabledCheckBox.Name = "LockMachineEnabledCheckBox";
            this.LockMachineEnabledCheckBox.Size = new System.Drawing.Size(65, 17);
            this.LockMachineEnabledCheckBox.TabIndex = 15;
            this.LockMachineEnabledCheckBox.Text = "Enabled";
            this.LockMachineEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // FlashScreenEnabledCheckBox
            // 
            this.FlashScreenEnabledCheckBox.AutoSize = true;
            this.FlashScreenEnabledCheckBox.Checked = global::Move.Properties.Settings.Default.ActionFlashScreenEnabled;
            this.FlashScreenEnabledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FlashScreenEnabledCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Move.Properties.Settings.Default, "ActionFlashScreenEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FlashScreenEnabledCheckBox.Location = new System.Drawing.Point(6, 19);
            this.FlashScreenEnabledCheckBox.Name = "FlashScreenEnabledCheckBox";
            this.FlashScreenEnabledCheckBox.Size = new System.Drawing.Size(65, 17);
            this.FlashScreenEnabledCheckBox.TabIndex = 14;
            this.FlashScreenEnabledCheckBox.Text = "Enabled";
            this.FlashScreenEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // FlashScreenSpeedTrackBar
            // 
            this.FlashScreenSpeedTrackBar.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Move.Properties.Settings.Default, "ActionFlashScreenSpeed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FlashScreenSpeedTrackBar.Location = new System.Drawing.Point(87, 39);
            this.FlashScreenSpeedTrackBar.Maximum = 1000;
            this.FlashScreenSpeedTrackBar.Minimum = 100;
            this.FlashScreenSpeedTrackBar.Name = "FlashScreenSpeedTrackBar";
            this.FlashScreenSpeedTrackBar.Size = new System.Drawing.Size(230, 45);
            this.FlashScreenSpeedTrackBar.TabIndex = 23;
            this.FlashScreenSpeedTrackBar.Value = global::Move.Properties.Settings.Default.ActionFlashScreenSpeed;
            // 
            // BalloonTipEnabledCheckBox
            // 
            this.BalloonTipEnabledCheckBox.AutoSize = true;
            this.BalloonTipEnabledCheckBox.Checked = global::Move.Properties.Settings.Default.ActionBalloonTipEnabled;
            this.BalloonTipEnabledCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Move.Properties.Settings.Default, "ActionBalloonTipEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.BalloonTipEnabledCheckBox.Location = new System.Drawing.Point(6, 19);
            this.BalloonTipEnabledCheckBox.Name = "BalloonTipEnabledCheckBox";
            this.BalloonTipEnabledCheckBox.Size = new System.Drawing.Size(65, 17);
            this.BalloonTipEnabledCheckBox.TabIndex = 13;
            this.BalloonTipEnabledCheckBox.Text = "Enabled";
            this.BalloonTipEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // SystemBeepEnabledCheckBox
            // 
            this.SystemBeepEnabledCheckBox.AutoSize = true;
            this.SystemBeepEnabledCheckBox.Checked = global::Move.Properties.Settings.Default.ActionSystemBeepEnabled;
            this.SystemBeepEnabledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SystemBeepEnabledCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Move.Properties.Settings.Default, "ActionSystemBeepEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SystemBeepEnabledCheckBox.Location = new System.Drawing.Point(6, 19);
            this.SystemBeepEnabledCheckBox.Name = "SystemBeepEnabledCheckBox";
            this.SystemBeepEnabledCheckBox.Size = new System.Drawing.Size(65, 17);
            this.SystemBeepEnabledCheckBox.TabIndex = 11;
            this.SystemBeepEnabledCheckBox.Text = "Enabled";
            this.SystemBeepEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // ActionFlashIconEnabledCheckBox
            // 
            this.ActionFlashIconEnabledCheckBox.AutoSize = true;
            this.ActionFlashIconEnabledCheckBox.Checked = global::Move.Properties.Settings.Default.ActionFlashIconEnabled;
            this.ActionFlashIconEnabledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ActionFlashIconEnabledCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Move.Properties.Settings.Default, "ActionFlashIconEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ActionFlashIconEnabledCheckBox.Location = new System.Drawing.Point(6, 19);
            this.ActionFlashIconEnabledCheckBox.Name = "ActionFlashIconEnabledCheckBox";
            this.ActionFlashIconEnabledCheckBox.Size = new System.Drawing.Size(65, 17);
            this.ActionFlashIconEnabledCheckBox.TabIndex = 0;
            this.ActionFlashIconEnabledCheckBox.Text = "Enabled";
            this.ActionFlashIconEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // FlashIconSpeedTrackBar
            // 
            this.FlashIconSpeedTrackBar.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Move.Properties.Settings.Default, "ActionFlashIconSpeed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FlashIconSpeedTrackBar.Location = new System.Drawing.Point(87, 51);
            this.FlashIconSpeedTrackBar.Maximum = 1000;
            this.FlashIconSpeedTrackBar.Minimum = 100;
            this.FlashIconSpeedTrackBar.Name = "FlashIconSpeedTrackBar";
            this.FlashIconSpeedTrackBar.Size = new System.Drawing.Size(230, 45);
            this.FlashIconSpeedTrackBar.TabIndex = 20;
            this.FlashIconSpeedTrackBar.Value = global::Move.Properties.Settings.Default.ActionFlashIconSpeed;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Sound:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Random",
            "Black & White",
            "Custom"});
            this.comboBox2.Location = new System.Drawing.Point(110, 41);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Speed:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(480, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "EXAMPLE";
            // 
            // trackBar1
            // 
            this.trackBar1.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Move.Properties.Settings.Default, "ActionFlashIconSpeed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.trackBar1.Location = new System.Drawing.Point(87, 76);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Minimum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(230, 45);
            this.trackBar1.TabIndex = 23;
            this.trackBar1.Value = global::Move.Properties.Settings.Default.ActionFlashIconSpeed;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Text:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(84, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 33;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 864);
            this.Controls.Add(this.OtherGroupBox);
            this.Controls.Add(this.LockMachineGroupBox);
            this.Controls.Add(this.FlashScreenGroupBox);
            this.Controls.Add(this.BalloonTipGroupBox);
            this.Controls.Add(this.SystemBeepGroupBox);
            this.Controls.Add(this.FlashIconGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.TopMost = true;
            this.FlashIconGroupBox.ResumeLayout(false);
            this.FlashIconGroupBox.PerformLayout();
            this.SystemBeepGroupBox.ResumeLayout(false);
            this.SystemBeepGroupBox.PerformLayout();
            this.BalloonTipGroupBox.ResumeLayout(false);
            this.BalloonTipGroupBox.PerformLayout();
            this.FlashScreenGroupBox.ResumeLayout(false);
            this.FlashScreenGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlashScreenTransparencyTrackBar)).EndInit();
            this.LockMachineGroupBox.ResumeLayout(false);
            this.LockMachineGroupBox.PerformLayout();
            this.OtherGroupBox.ResumeLayout(false);
            this.OtherGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MoveTimerIntervalTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlashScreenSpeedTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlashIconSpeedTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox ActionFlashIconEnabledCheckBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox FlashIconGroupBox;
        private System.Windows.Forms.CheckBox SystemBeepEnabledCheckBox;
        private System.Windows.Forms.CheckBox BalloonTipEnabledCheckBox;
        private System.Windows.Forms.CheckBox FlashScreenEnabledCheckBox;
        private System.Windows.Forms.CheckBox LockMachineEnabledCheckBox;
        private System.Windows.Forms.GroupBox SystemBeepGroupBox;
        private System.Windows.Forms.GroupBox BalloonTipGroupBox;
        private System.Windows.Forms.GroupBox FlashScreenGroupBox;
        private System.Windows.Forms.GroupBox LockMachineGroupBox;
        private System.Windows.Forms.GroupBox OtherGroupBox;
        private System.Windows.Forms.TrackBar MoveTimerIntervalTrackBar;
        private System.Windows.Forms.Label MoveTimerIntervalLabel;
        private System.Windows.Forms.Label FlashIconSpeedLabel;
        private System.Windows.Forms.Label FlashIconSpeedValueLabel;
        private System.Windows.Forms.TrackBar FlashIconSpeedTrackBar;
        private System.Windows.Forms.CheckBox RunOnStartupCheckBox;
        private System.Windows.Forms.Label MoveIntervalLabel;
        private System.Windows.Forms.Label FlashScreenSpeedLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar FlashScreenSpeedTrackBar;
        private System.Windows.Forms.Label FlashScreenColourLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar FlashScreenTransparencyTrackBar;
        private System.Windows.Forms.Label FlashScreenTransparencyLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
    }
}