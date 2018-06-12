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
        Point clickLocation;
        bool locOn = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (locOn == false)
            {
                timer1.Tick += new EventHandler(button1_Click);
                timer1.Interval = 2000;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
