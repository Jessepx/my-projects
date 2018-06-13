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
                label1.Text = clickLocation.ToString();
                locOn = false;
            }
        }

        //label1 displays the X,Y coordinates of the stored location
        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Uses the imported user32.dll to implement "Clicking" functionality when button2 is pressed
        public void MouseClick()
        {
            int count = 0;
            timer2.Tick += new EventHandler(button2_Click);
            timer2.Interval = 2000;
            timer2.Start();
            Cursor.Position = clickLocation;
            while (count < 5)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, clickLocation);
                count++;
            }
            timer2.Stop();
        }

        //Where we are calling the "Clicking" functionality to occur
        private void button2_Click(object sender, EventArgs e)
        {
            MouseClick();
        }

        

    }
}
