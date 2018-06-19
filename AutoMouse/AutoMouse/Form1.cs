using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AutoMouse
{
    public partial class Form1 : Form
    {
        Point clickLocation = new Point();
        bool locOn = false;
        bool forceQuit = false;
        bool buttonCheck = false;
        bool clickCheck = false;

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
            int count = 0;

            if (buttonCheck == false)
            {
                label1.Text = "Set your Location.";
            }
            else
            {
                if (clickCheck == false)
                {
                    timer2.Tick += new EventHandler(button2_Click);
                    timer2.Interval = 2000;
                    timer2.Start();
                    clickCheck = true;
                }
                else
                {
                    Cursor.Position = clickLocation; //Moves cursor to stored location
                    while (count < 1) //While loop that clicks ONCE now, for testing
                    {
                        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, clickLocation);
                        count++;
                    }
                    timer2.Stop();
                    clickCheck = false;
                }
            }
        }
    }
}
