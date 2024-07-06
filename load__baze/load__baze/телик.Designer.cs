namespace load__baze
{
    partial class телик
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
            this.tmrVideo = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(-1, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(16, 14);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button2.ForeColor = System.Drawing.Color.Blue;
            this.button2.Location = new System.Drawing.Point(-1, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "экран full";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button3.ForeColor = System.Drawing.Color.Blue;
            this.button3.Location = new System.Drawing.Point(-1, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "каналы";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button4.ForeColor = System.Drawing.Color.Blue;
            this.button4.Location = new System.Drawing.Point(-1, 53);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(63, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "база";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.trackBar1.Location = new System.Drawing.Point(68, -1);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 104);
            this.trackBar1.SmallChange = 5;
            this.trackBar1.TabIndex = 4;
            this.trackBar1.TickFrequency = 5;
            this.trackBar1.Value = 50;
            this.trackBar1.Visible = false;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button5.ForeColor = System.Drawing.Color.Blue;
            this.button5.Location = new System.Drawing.Point(-1, 75);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(63, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "закрыть";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Location = new System.Drawing.Point(-1, 105);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(114, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // телик
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(503, 293);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(539, 385);
            this.MinimumSize = new System.Drawing.Size(203, 157);
            this.Name = "телик";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Телик. :)";
            this.TopMost = true;
            this.MaximumSizeChanged += new System.EventHandler(this.телик_MaximumSizeChanged);
            this.Activated += new System.EventHandler(this.телик_Activated);
            this.Deactivate += new System.EventHandler(this.телик_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.автор_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.DoubleClick += new System.EventHandler(this.телик_DoubleClick);
            this.Enter += new System.EventHandler(this.телик_Enter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.телик_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.телик_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.телик_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.телик_MouseUp);
            this.Resize += new System.EventHandler(this.телик_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer tmrVideo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}