using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Forms;
using System.IO;
using System.Diagnostics;

namespace load__baze
{
    public partial class телик : Form
    {
        public телик()
        {
            {
                InitializeComponent();

                this.FormBorderStyle = FormBorderStyle.None;
                this.DoubleBuffered = true;
                this.SetStyle(ControlStyles.ResizeRedraw, true);

            }
        }
        Vlc.DotNet.Forms.VlcControl vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
        string vail = "";


            string[] name = null;
            string[] id = null;
        private void Form2_Load(object sender, EventArgs e)
        {

            Size resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;

            Location= new System.Drawing.Point(resolution.Width-600, 100);
            //this.button_поиск_по_баз_доб = new System.Windows.Forms.Button();

            System.Windows.Forms.Button d;
            d = new System.Windows.Forms.Button();
            d.Click += new System.EventHandler(Program.f1.скрыть_активнность);
            d.PerformClick();
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon("ico.ico");
            MaximizeBox = false;
            string[] poput_load = Environment.GetCommandLineArgs();
            System.IO.FileInfo obj = new System.IO.FileInfo(poput_load[0]);
            string str = "";
            // открываем файл
            int x = 0;
            using (StreamReader stream = new StreamReader("rez\\video.txt"))
            {
                while (stream.Peek() >= 0)
                {
                    x++;
                    // читаем строку из файла
                    vail = stream.ReadLine();
                }
                stream.Close();
            }

            if (x > 1)
            { 
                    string[] f = new string[x];
            using (StreamReader stream = new StreamReader("rez\\video.txt"))
            {          
                name = new string[x/2];
                id = new string[x/2]; 
                x = 0;
                while (stream.Peek() >= 0)
                {
                 try { f[x] = stream.ReadLine(); } catch { }
                    x++;
                }
                stream.Close();
            }
                  x = 0;
                for (int r = 0; r < f.Length; r++)
                {

                    name[x] = f[r];
                    r++;
                    id[x] = f[r];
                    x++;
                }
                 vail = id[0];
                 for(int y=0;y<name.Length;y++)comboBox1.Items.Add(name[y]);
                comboBox1.SelectedIndex = 0;
            }










                    // читаем строку из файла
                    // vail = stream.ReadLine();


            if (vail == "") { 
            vail = @"http://cdn1.live-tv.od.ua:8081/wave/wave-abr/playlist.m3u8";}                       
            ProcessStartInfo infoStartProcess = new ProcessStartInfo();
            infoStartProcess.WorkingDirectory = obj.DirectoryName + "rez\\CNData\\ddl";//папка к программе 
            DirectoryInfo di = new DirectoryInfo(obj.DirectoryName + "\\rez\\CNData\\ddl");
            vlcControl1.Size = new Size(501, 285);
            vlcControl1.Location = new System.Drawing.Point(0, 5);
            vlcControl1.BackColor = Color.Empty;
            vlcControl1.BeginInit();
            vlcControl1.VlcLibDirectory = (System.IO.DirectoryInfo)(vlcControl1.VlcLibDirectory = di); //Make sure your dir is correct
            vlcControl1.VlcMediaplayerOptions = new[] { "-vv" }; //not sure what this does
            vlcControl1.EndInit();
            this.Controls.Add(vlcControl1); //Add the control to your container

            vlcControl1.Dock = DockStyle.None; //Optional          
            timer1.Enabled = true;

            ImageList imgList = new ImageList();

            imgList.TransparentColor = Color.Transparent;
            //pictureBox1.Parent=vlcControl1 ;
           
            //pictureBox1.Image = imgList.Images["rez\\logo.png"];


        }






            private void автор_FormClosing(object sender, FormClosingEventArgs e)
        {
            vlcControl1.Stop();
            Button f = new Button();
            f.Click += new EventHandler(Program.f1.скрыть_активнность);
            f.PerformClick();
        }





        private void vlcControl1_Click(object sender, EventArgs e)
        {
            int t = 0;
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            vlcControl1.Play(new Uri(vail));
            vlcControl1.Audio.Volume = (int)trackBar1.Value;
            vlcControl1.MouseDoubleClick += new MouseEventHandler(vlcControl1_Click);
            timer1.Enabled = false;
        }



        private void timer2_Tick(object sender, EventArgs e)
        {
            gt = false;
            button1.BackColor = Color.Gray;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            comboBox1.Visible = false;
            timer2.Enabled = false;       
            trackBar1.Visible = false;
        }

        private void телик_Resize(object sender, EventArgs e)
        {
            if (full==true) {
                vlcControl1.Size = new Size(Width, Height); }
           else {
                vlcControl1.Size = new Size(Width-1, Height-7);
            }
         
        }

        Boolean gt = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (gt == false)
            {
                gt = true;
                button1.BackColor = Color.Green;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                trackBar1.Visible = true;
                comboBox1.Visible = true;
                timer2.Enabled = true;
                
            }
            else
            {
                gt = false;
                button1.BackColor = Color.Gray;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                comboBox1.Visible = false;
                trackBar1.Visible = false;


            }
        }

        Boolean full = false;
        private void button2_Click(object sender, EventArgs e)
        {
            if (full==false)
            {
                full = true;
                formSize = new Size(this.Width, this.Height);                
                WindowState = FormWindowState.Maximized;
                timer2.Enabled = false;
                timer2.Enabled = true;
                button2.Text = "mini";
              
            }
            else
            {
                full = false;
                //exit full screen when escape is pressed
                WindowState = FormWindowState.Normal;
                this.Size = formSize;
                button2.Text = "экран full";
                vlcControl1.Size = new Size(Width - 1, Height - 7);



            }

        }

        private void телик_Enter(object sender, EventArgs e)
        {
           // button1.Visible = true;
           // timer2.Enabled = true;
        }

        private void телик_Activated(object sender, EventArgs e)
        {
            button1.Visible = true;
            
            
        }
        private void телик_Deactivate(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            comboBox1.Visible = false;
            trackBar1.Visible = false;
            button1.BackColor = Color.Gray;
            gt = false;



        }


        private void button3_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("rez\\video.txt");
            vlcControl1.Audio.Volume = (int)trackBar1.Value;
            timer2.Enabled = false;
            timer2.Enabled = true;


     
        }

        private void button4_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("rez\\video_url.txt");
            vlcControl1.Audio.Volume = (int)trackBar1.Value;
            timer2.Enabled = false;
            timer2.Enabled = true;

        }
        private Size formSize;
        private void телик_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                full = false;
                //exit full screen when escape is pressed
                WindowState = FormWindowState.Normal;
                this.Size = formSize;
                button2.Text = "экран full";
                vlcControl1.Size = new Size(Width - 1, Height - 7);
            }
        }

        private void телик_DoubleClick(object sender, EventArgs e)
        {
         
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

         vlcControl1.Audio.Volume = (int)trackBar1.Value;
            timer2.Enabled = false;
            timer2.Enabled = true;
        }


        private void телик_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void телик_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void телик_MouseDown(object sender, MouseEventArgs e)
        {

        }


        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.DarkBlue, rc);
        }

        protected override void WndProc(ref Message m)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                
                button2.Text = "mini";
                
            }
            else
            {
                formSize =this.Size;
              

            }

            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void телик_MaximumSizeChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            vail = id[comboBox1.SelectedIndex];
            vlcControl1.Play(new Uri(vail));
            //vlcControl1.Audio.Volume = (int)trackBar1.Value;               
        }
    }
}