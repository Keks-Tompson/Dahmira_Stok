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
using System.Security.Cryptography;
using System.Threading;

namespace logo
{
    public partial class Form1 : Form
    {
        public Form1(string[] args)
        {
            TopMost = true; //поверх всех окон
            InitializeComponent();
            try { if (args[0] != "") { a = true; put_k_baza = args[0].Replace("▄"," "); } } catch { } //короче знак пробела этот метод не переносит между программами, потому меняем и там и тут пробелы на квадратик ▄
            //фон
            this.BackgroundImageLayout = ImageLayout.Stretch;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
            BackgroundImage = logo.Properties.Resources.Результат200; // картинка
            ImageAnimator.Animate(BackgroundImage, OnFrameChanged);

            //добавляем табличку 
            tablichka.AutoSize = false;
            tablichka.Location = new System.Drawing.Point(720, 273);
            tablichka.Size = new System.Drawing.Size(200, 40);
            tablichka.Text = "0%";
            tablichka.Font = new System.Drawing.Font("Trebuchet MS", 26, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));       
           //tablichka.BackColor = Color.Wheat;//фон
            tablichka.ForeColor = Color.LightPink;
            this.Controls.Add(tablichka);
            DoubleBuffered = true;
            
        }
        Label tablichka = new Label(); // табличка загрузки



              bool a = false; //заменить на false что б заработала в программе 
        string put_k_baza = "";
            private void Form1_Load(object sender, EventArgs e)
        {
            if (a == false)
            {
                MessageBox.Show("Это служебная программа! Нафиг ты сюда залез!", "Сообщение для юзера!",MessageBoxButtons.OK,MessageBoxIcon.Stop);

               Application.Exit();
            }

        }
        int frime = 180;
        private void OnFrameChanged(object sender, EventArgs e)
        {
            if (frime > 0)
            {
                frime--;
                if (InvokeRequired)
                {
                    BeginInvoke((Action)(() => OnFrameChanged(sender, e)));
                    return;
                }
                ImageAnimator.UpdateFrames();
                Invalidate(false);
            }

            if (frime < 1) //загрузились и наблюдаем за прораммой. Если пропала с оперативки прога то закроемся.
            {


                ComboBox listBox1 = new ComboBox();
                

                System.Diagnostics.Process[] processes;
                processes = System.Diagnostics.Process.GetProcesses();
                foreach (System.Diagnostics.Process instance in processes)
                {
                    listBox1.Items.Add(instance.ProcessName);
                }
                if (listBox1.Items.Count > 0)
                {    bool br = false;
                    string[] a = new string[listBox1.Items.Count];

                    for (int r = 0; r < listBox1.Items.Count; r++)
                    {
                        if (listBox1.Items[r].ToString() == "load__baze")
                        {
                            br = true;

                        }                       
                    }
                    if (br == false) { Application.Exit(); }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //новый поток данных! 
        //Поместите эти две строки туда, где вы хотите проверить соединение
        Thread checkConnection = new Thread(() => checkConn());
        checkConnection.Start();



        }






        //Затем создайте метод, как показано ниже

        bool gfg = false;
public void checkConn()
        {


            try
            {
            //пробуем проценты 
            long sdsd= Process.GetProcessesByName("load__baze")[0].WorkingSet64;



                // пустая программа "88903680"
                // полная "222498816"
                //размер файла прайса.. 133562368



               System.IO.FileInfo file = new System.IO.FileInfo(put_k_baza);
                //укажим имя базы:
                if (gfg == false)
                {   
                    tablichka.Size = new System.Drawing.Size(350, 35);
                    tablichka.BackColor = Color.Wheat;//фон
                    tablichka.ForeColor = Color.Red;
                    tablichka.Font = new System.Drawing.Font("Trebuchet MS", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    tablichka.Text = "Подключение к файлу: \n"+file.Name;
                    gfg = true;
                }


 
                long size = file.Length;

                long dfdf = sdsd - 89452544;

                long xx = (dfdf * 100 / size);
                if (xx < 0) { xx = 0; }
                if (xx > 100) { xx = 100; }
                tablichka.Size = new System.Drawing.Size(90, 39);
                tablichka.BackColor = Color.White;
                tablichka.ForeColor = Color.LightPink;
                tablichka.Font = new System.Drawing.Font("Microsoft Sans Serif", 24, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                tablichka.Text = xx.ToString() + "%";
            }
            catch { }

            //Вызовите метод проверки подключения здесь
       //     if (!miconexion(ip, user, pass))
       //     {
                //Обработайте сбой здесь, используйте Invoke, если вы хотите управлять потоком пользовательского интерфейса.
      //      }
            //Для наилучшего использования ресурсов присоединяйтесь к потоку после его использования.
           // Thread.Join();
        }



    }
}
