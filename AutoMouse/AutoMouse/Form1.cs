﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;
using Hotkeys;

namespace AutoMouse
{
    public partial class Form1 : Form
    {
        Point clickLocation = new Point();
        string text;
        bool locOn = false;
        bool buttonCheck = false;
        bool clickCheck = false;
        Hotkeys.GlobalHotkey qhk;
        Hotkeys.GlobalHotkey shk;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, Point loc);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public Form1()
        {
            InitializeComponent();
            qhk = new Hotkeys.GlobalHotkey(Constants.SHIFT, Keys.Q, this); // SHIFT+Q to stop clicking Hotkey
            shk = new Hotkeys.GlobalHotkey(Constants.SHIFT, Keys.S, this); // SHIFT+S to start clicking Hotkey
        }

        private void QuitHotkey()
        {
            clickDelay.Stop();
            clickDelay.Dispose();
            clickSpeed.Stop();
            clickSpeed.Dispose();
            label1.Text = "Clicking Stopped.\nReset Coordinates.";
        }

        private void StartHotkey()
        {
            clickDelay.Tick += new EventHandler(startClickButton_Click);


            if (buttonCheck == false)
            {
                label1.Text = "Set your Location.";
            }
            else
            {
                if (clickCheck == false)
                {
                    clickCheck = true;
                    clickDelay.Interval = 2000;
                    clickDelay.Start();
                }
                else
                {
                    clickCheck = false;
                    clickDelay.Stop();
                    clickDelay.Dispose();
                    Cursor.Position = clickLocation; //Moves cursor to stored location
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, clickLocation);
                    clickSpeed.Tick += new EventHandler(ClickMouseBaseGame);
                    clickSpeed.Interval = 2000;
                    clickSpeed.Start();
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Hotkeys.Constants.WM_HOTKEY_MSG_ID)
            {
                if (m.WParam.ToInt32() == qhk.GetHashCode())
                {
                    QuitHotkey();
                }
                if (m.WParam.ToInt32() == shk.GetHashCode())
                {
                    StartHotkey();
                }
            }
            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WriteLine("Trying to register Hotkeys");
            if (qhk.Register())
                WriteLine("Hotkey SHIFT+Q registered.");
            else
                WriteLine("Hotkey failed to register");

            if (shk.Register())
                WriteLine("Hotkey SHIFT+S registered.");
            else
                WriteLine("Hotkey failed to register");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!qhk.Unregister())
                MessageBox.Show("Hotkey failed to unregister!");
            if (!shk.Unregister())
                MessageBox.Show("Hotkey failed to unregister!");
        }

        private void WriteLine(string text)
        {
            //label1.Text = text + Environment.NewLine;
        }

        //button1 should store the location of the Cursor into a Point object, allowing button2 to access that stored Point.
        private void coordButton_Click(object sender, EventArgs e)
        {
            if (locOn == false)
            {
                coordTimer.Tick += new EventHandler(coordButton_Click);
                coordTimer.Interval = 1000;
                coordTimer.Start();
                label1.Text = "Getting Location..";
                locOn = true;
            }
            else
            {
                coordTimer.Stop();
                coordTimer.Dispose();
                clickLocation = Cursor.Position;
                label1.Text = "Location set:\n" + clickLocation.ToString();
                locOn = false;
                buttonCheck = true;
            }
        }

        //label1 displays the X,Y coordinates of the stored location
        private void label1_Click(object sender, EventArgs e)
        {
            //Displays X, Y Coordinates
        }

        //Uses the imported user32.dll to implement "Clicking" functionality when button2 is pressed
        private void startClickButton_Click(object sender, EventArgs e)
        {
            clickDelay.Tick += new EventHandler(startClickButton_Click);
            

            if (buttonCheck == false)
            {
                label1.Text = "Set your Location.";
            }
            else
            {
                if (clickCheck == false)
                {
                    clickCheck = true;
                    clickDelay.Interval = 2000;
                    clickDelay.Start();
                }
                else
                {
                    clickCheck = false;
                    clickDelay.Stop();
                    clickDelay.Dispose();
                    Cursor.Position = clickLocation; //Moves cursor to stored location
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, clickLocation);
                    clickSpeed.Tick += new EventHandler(ClickMouseBaseGame);
                    clickSpeed.Interval = 2000;
                    clickSpeed.Start();
                }
            }
        }

        private void ClickMouseBaseGame(object sender, EventArgs e)
        {
            Cursor.Position = clickLocation; //Moves cursor to stored location
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, clickLocation);
        }

        private void ClickMouseBonusGame(object sender, EventArgs e)
        {

        }

        private void logFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "nvm files (*.nvm)|*.nvm|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                ParseLog();
            } 
        }

        private void ParseLog()
        {
             
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                text = System.IO.File.ReadAllText(openFileDialog1.FileName);

                if (text.Contains("::GetBonusWin"))
                {
                    MessageBox.Show("success");
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //Event Handler for Button3 to access file path to parse log
        }
    }
}
