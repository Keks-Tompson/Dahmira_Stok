using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace load__baze
{
    public partial class o_programme_otziv : Form
    {
        public o_programme_otziv()
        {
            InitializeComponent();
        }

        Random x = new Random();
        int xx = 0;
        int yy = 0;
        private void button2_MouseHover(object sender, EventArgs e)
        {


        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {

        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            xx = x.Next(2, 353);
            yy= x.Next(2, 85);
            button2.Location = new System.Drawing.Point(xx, yy);
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Label d = new Label();
            d.Text = "Спасибо за отзыв!\nЕщё можно в чат написать! :)";
            d.ForeColor = Color.DarkBlue;
            d.Size = new Size(200, 100);
            d.Font= new Font("Times New Roman", 9.0f);
            d.Location = new Point(80, 33);
            this.Controls.Add(d);
            timer1.Enabled = true;
            button1.Visible = false;
            button2.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            timer1.Enabled = false;
            this.Close();
        }

        private void o_programme_otziv_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
            Process.Start("https://rt.pornhub.com");
            Process.Start("https://xhamster.com");
            Process.Start("https://www.youporn.com");
            Process.Start("https://pornkai.com");
            }
     
           
        }
    }
}
