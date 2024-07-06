using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace load__baze
{
    public partial class Kolor_Exel : Form
    {
        public Kolor_Exel()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        string[] f = new string[15];
        private void Kolor_Exel_Load(object sender, EventArgs e)
        {
            int x = 0;
            using (StreamReader stream = new StreamReader("rez\\Color_Excel.txt"))
            {
                while (stream.Peek() >= 0)
                {
                    f[x] = stream.ReadLine();
                    x++;
                }
                stream.Close();
            }
            try
            {
                numericUpDown1.Value = Convert.ToInt16(f[0]);
                numericUpDown2.Value = Convert.ToInt16(f[1]);
                numericUpDown3.Value = Convert.ToInt16(f[2]);
                numericUpDown4.Value = Convert.ToInt16(f[3]);
                numericUpDown5.Value = Convert.ToInt16(f[4]);
                numericUpDown6.Value = Convert.ToInt16(f[5]);
                numericUpDown7.Value = Convert.ToInt16(f[6]);
            }
            catch
            {

            }
            if (f[7] == "1") { checkBox1.Checked = true; } else { checkBox1.Checked = false; }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("rez\\Color_Excel.txt", false, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine(numericUpDown1.Value);
                    sw.WriteLine(numericUpDown2.Value);
                    sw.WriteLine(numericUpDown3.Value);
                    sw.WriteLine(numericUpDown4.Value);
                    sw.WriteLine(numericUpDown5.Value);
                    sw.WriteLine(numericUpDown6.Value);
                    sw.WriteLine(numericUpDown7.Value);
                    if (checkBox1.Checked == true)
                    {//с фото
                        sw.WriteLine(1);
                    }
                    else
                    {//без фото
                        sw.WriteLine(0);

                    }

                }
                label4.Text = "Сохранено!";
                Random h = new Random();
                label4.ForeColor = Color.FromArgb(h.Next(100,150), h.Next(50, 180), h.Next(50, 160));
            }
            catch
            {
                label4.Text = "Не получилось сохранить!";
            }
            }

      

        private void Kolor_Exel_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {//с фото
                
            }
            else
            {//без фото


            }
        }
    }
}
