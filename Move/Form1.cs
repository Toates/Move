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
    public partial class Form1 : Form
    {
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fghToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DropdownToolStripMenuItem = new System.Windows.Forms.ToolStripComboBox();
            this.textBoxExampleToolStripMenuItem = new System.Windows.Forms.ToolStripTextBox();
            this.drudtyuToolStripMenuItem = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem,
            this.DropdownToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.textBoxExampleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowCheckMargin = true;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(301, 144);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(300, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dhToolStripMenuItem,
            this.fghToolStripMenuItem,
            this.toolStripComboBox2,
            this.drudtyuToolStripMenuItem,
            this.toolStripComboBox1});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(300, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // dhToolStripMenuItem
            // 
            this.dhToolStripMenuItem.Checked = true;
            this.dhToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dhToolStripMenuItem.Name = "dhToolStripMenuItem";
            this.dhToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.dhToolStripMenuItem.Text = "Setting 1";
            // 
            // fghToolStripMenuItem
            // 
            this.fghToolStripMenuItem.Name = "fghToolStripMenuItem";
            this.fghToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.fghToolStripMenuItem.Text = "Setting 2";
            this.fghToolStripMenuItem.Click += new System.EventHandler(this.fghToolStripMenuItem_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(300, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // DropdownToolStripMenuItem
            // 
            this.DropdownToolStripMenuItem.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.DropdownToolStripMenuItem.Name = "DropdownToolStripMenuItem";
            this.DropdownToolStripMenuItem.Size = new System.Drawing.Size(180, 23);
            this.DropdownToolStripMenuItem.Text = "Dropdown Example";
            this.DropdownToolStripMenuItem.Click += new System.EventHandler(this.nghjghjToolStripMenuItem_Click);
            // 
            // textBoxExampleToolStripMenuItem
            // 
            this.textBoxExampleToolStripMenuItem.Name = "textBoxExampleToolStripMenuItem";
            this.textBoxExampleToolStripMenuItem.Size = new System.Drawing.Size(240, 23);
            this.textBoxExampleToolStripMenuItem.Text = "TextBox Example";
            this.textBoxExampleToolStripMenuItem.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxExampleToolStripMenuItem_Validating);
            // 
            // drudtyuToolStripMenuItem
            // 
            this.drudtyuToolStripMenuItem.Items.AddRange(new object[] {
            "cvbfxb",
            "adsfg",
            "sdfg",
            "sdfg"});
            this.drudtyuToolStripMenuItem.Name = "drudtyuToolStripMenuItem";
            this.drudtyuToolStripMenuItem.Size = new System.Drawing.Size(180, 23);
            this.drudtyuToolStripMenuItem.Text = "drudtyu";
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.Size = new System.Drawing.Size(121, 23);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void fghToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nghjghjToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBoxExampleToolStripMenuItem_Validating(object sender, CancelEventArgs e)
        {

        }
        //public Form1()
        //{
        //    InitializeComponent();
        //}

        //private void Form1_Load(object sender, EventArgs e)
        //{

        //}

        //private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        //{

        //}
    }
}
