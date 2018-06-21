using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Hotkeys;

namespace AutoMouse
{
    public partial class Form1 : Form
    {
        Point clickLocation = new Point();
        bool locOn = false;
        bool buttonCheck = false;
        bool clickCheck = false;
        private Hotkeys.GlobalHotkey ghk;

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
            ghk = new Hotkeys.GlobalHotkey(Constants.SHIFT, Keys.Q, this);
        }

        private void HandleHotkey()
        {
            timer2.Stop();
            timer2.Dispose();
            timer3.Stop();
            timer3.Dispose();
            label1.Text = "Clicking Stopped.\nReset Coordinates.";
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Hotkeys.Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WriteLine("Trying to register SHIFT+Q");
            if (ghk.Register())
                WriteLine("Hotkey SHIFT+Q registered.");
            else
                WriteLine("Hotkey failed to register");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ghk.Unregister())
                MessageBox.Show("Hotkey failed to unregister!");
        }

        private void WriteLine(string text)
        {
            //label1.Text = text + Environment.NewLine;

        }

        //button1 should store the location of the Cursor into a Point object, allowing button2 to access that stored Point.
        private void button1_Click(object sender, EventArgs e)
        {

            if (locOn == false)
            {
                timer1.Tick += new EventHandler(button1_Click);
                timer1.Interval = 1000;
                timer1.Start();
                label1.Text = "Getting Location..";
                locOn = true;
            }
            else
            {
                timer1.Stop();
                timer1.Dispose();
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
        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Tick += new EventHandler(button2_Click);
            

            if (buttonCheck == false)
            {
                label1.Text = "Set your Location.";
            }
            else
            {
                if (clickCheck == false)
                {
                    clickCheck = true;
                    timer2.Interval = 2000;
                    timer2.Start();
                }
                else
                {
                    clickCheck = false;
                    timer2.Stop();
                    timer2.Dispose();
                    Cursor.Position = clickLocation; //Moves cursor to stored location
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, clickLocation);
                    timer3.Tick += new EventHandler(ClickMouse);
                    timer3.Interval = 2000;
                    timer3.Start();
                }
            }
        }

        private void ClickMouse(object sender, EventArgs e)
        {
            Cursor.Position = clickLocation; //Moves cursor to stored location
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, clickLocation);
        }
    }
}
