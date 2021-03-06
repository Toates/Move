﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Move
{
    public partial class FlashScreenForm : Form
    {
        private Random r = new Random();

        public FlashScreenForm()
        {
            InitializeComponent();
        }

        private void FlashScreenForm_Load(object sender, EventArgs e)
        {
            // displays the form over the entire screen except for the taskbar 
            // to allow access to the icon in order to disable
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;

            FlashScreenFormTimer.Enabled = true;
        }

        private void FlashScreenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FlashScreenFormTimer.Enabled = false;
        }

        private void FlashScreenFormTimer_Tick(object sender, EventArgs e)
        {
            switch (Properties.Settings.Default.ActionFlashScreenBehaviour)
            {
                case "Black & White":
                    if (BackColor == Color.White)
                    {
                        BackColor = Color.Black;
                    }
                    else
                    {
                        BackColor = Color.White;
                    }
                    break;

                case "Custom":
                    if (BackColor == Properties.Settings.Default.ActionFlashScreenColourCustom)
                    {
                        if (BackColor == Color.White)
                        {
                            BackColor = Color.Black;
                        }
                        else
                        {
                            BackColor = Color.White;
                        }
                    }
                    else
                    {
                        BackColor = Properties.Settings.Default.ActionFlashScreenColourCustom;
                    }
                    break;

                case "Random":
                default:
                    BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
                    break;
            }
        }
    }
}
