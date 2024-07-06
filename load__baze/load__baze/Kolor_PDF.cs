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
    public partial class Kolor_PDF : Form
    {
        public Kolor_PDF()
        {
            InitializeComponent();
        }

        private void Kolor_PDF_Load(object sender, EventArgs e)
        {

            int[] f = new int[9];
            int x = 0;
            using (StreamReader stream = new StreamReader("rez\\Color_PDF.txt"))
            {
                while (stream.Peek() >= 0)
                {
                    f[x] = Convert.ToInt16(stream.ReadLine());
                    x++;
                }
                stream.Close();
            }
            pictureBox1.BackColor = Color.FromArgb(f[0], f[1], f[2]);
            pictureBox2.BackColor = Color.FromArgb(f[3], f[4], f[5]);
            pictureBox3.BackColor = Color.FromArgb(f[6], f[7], f[8]);






        }

        bool cl = false;
        private void Kolor_PDF_Deactivate(object sender, EventArgs e)
        {
            if (cl==false)
                this.Close();

        }

        private void Kolor_PDF_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.f1.gt1 = false;
        }



        private void color_save()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("rez\\Color_PDF.txt", false, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine(pictureBox1.BackColor.R);
                    sw.WriteLine(pictureBox1.BackColor.G);
                    sw.WriteLine(pictureBox1.BackColor.B);
                    sw.WriteLine(pictureBox2.BackColor.R);
                    sw.WriteLine(pictureBox2.BackColor.G);
                    sw.WriteLine(pictureBox2.BackColor.B);
                    sw.WriteLine(pictureBox3.BackColor.R);
                    sw.WriteLine(pictureBox3.BackColor.G);
                    sw.WriteLine(pictureBox3.BackColor.B);
                }
            }
            catch
            {
                label1.Text = "Не получилось сохранить!"; label1.ForeColor = Color.Empty;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cl = true;
           
            //отладка окно выбора цвета
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = pictureBox1.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            { pictureBox1.BackColor = MyDialog.Color;       
            } 
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cl = true;

            //отладка окно выбора цвета
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = pictureBox2.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                pictureBox2.BackColor = MyDialog.Color;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            cl = true;

            //отладка окно выбора цвета
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = pictureBox3.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                pictureBox3.BackColor = MyDialog.Color;
        }

        private void pictureBox1_BackColorChanged(object sender, EventArgs e)
        {
            cl = false;
            color_save();
            label1.Text = "Сохранено!";
            label1.ForeColor = pictureBox1.BackColor;
        }

        private void pictureBox2_BackColorChanged(object sender, EventArgs e)
        {
            cl = false;
            color_save();
            label1.Text = "Сохранено!";
            label1.ForeColor = pictureBox2.BackColor;
        }

        private void pictureBox3_BackColorChanged(object sender, EventArgs e)
        {
            cl = false;
            color_save();
            label1.Text = "Сохранено!";
            label1.ForeColor = pictureBox3.BackColor;
        }
    }
}



/*
//отладка окно выбора цвета
ColorDialog MyDialog = new ColorDialog();
// Keeps the user from selecting a custom color.
MyDialog.AllowFullOpen = true;
// Allows the user to get help. (The default is false.)
MyDialog.ShowHelp = true;
// Sets the initial color select to the current text color.
MyDialog.Color = groupBox_Расчеты.ForeColor;

// Update the text box color if the user clicks OK 
if (MyDialog.ShowDialog() == DialogResult.OK)
    groupBox_Расчеты.ForeColor = MyDialog.Color;
3 цвета 

//
*/
