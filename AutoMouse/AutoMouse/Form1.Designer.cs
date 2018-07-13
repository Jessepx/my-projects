namespace AutoMouse
{
    partial class Form1
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
            this.coordButton = new System.Windows.Forms.Button();
            this.coordTimer = new System.Windows.Forms.Timer(this.components);
            this.clickDelay = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.startClickButton = new System.Windows.Forms.Button();
            this.clickSpeed = new System.Windows.Forms.Timer(this.components);
            this.logFileButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.coordButton.Location = new System.Drawing.Point(38, 12);
            this.coordButton.Name = "CoordinatesButton";
            this.coordButton.Size = new System.Drawing.Size(75, 23);
            this.coordButton.TabIndex = 0;
            this.coordButton.Text = "Grab";
            this.coordButton.UseVisualStyleBackColor = true;
            this.coordButton.Click += new System.EventHandler(this.coordButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cursor Coordinates";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button2
            // 
            this.startClickButton.Location = new System.Drawing.Point(189, 12);
            this.startClickButton.Name = "StartClickingButton";
            this.startClickButton.Size = new System.Drawing.Size(75, 23);
            this.startClickButton.TabIndex = 3;
            this.startClickButton.Text = "Clicker";
            this.startClickButton.UseVisualStyleBackColor = true;
            this.startClickButton.Click += new System.EventHandler(this.startClickButton_Click);
            // 
            // button3
            // 
            this.logFileButton.Location = new System.Drawing.Point(38, 74);
            this.logFileButton.Name = "FindLogfileButton";
            this.logFileButton.Size = new System.Drawing.Size(75, 23);
            this.logFileButton.TabIndex = 4;
            this.logFileButton.Text = "File Path";
            this.logFileButton.UseVisualStyleBackColor = true;
            this.logFileButton.Click += new System.EventHandler(this.logFileButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(300, 125);
            this.Controls.Add(this.logFileButton);
            this.Controls.Add(this.startClickButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.coordButton);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "AutoMouse v0.0.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button coordButton;
        private System.Windows.Forms.Timer clickDelay;
        private System.Windows.Forms.Timer coordTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startClickButton;
        private System.Windows.Forms.Timer clickSpeed;
        private System.Windows.Forms.Button logFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

