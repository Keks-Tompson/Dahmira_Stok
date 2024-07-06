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

namespace crackBaza
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //фон
            this.BackgroundImageLayout = ImageLayout.Stretch;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
            BackgroundImage = crackBaza.Properties.Resources._1;
            ImageAnimator.Animate(BackgroundImage, OnFrameChanged);

            this.label1.BackColor = System.Drawing.Color.Transparent; //прозрачность
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label3.BackColor = System.Drawing.Color.Transparent;
        }


        string put_k_proge = "";




        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            Boolean papca= false;
            Boolean ex = false;
            while (papca==false)
            {

                using (var fbd = new FolderBrowserDialog())   //создаем путь к папке в файл
                {
                    //fbd.RootFolder = System.Environment.SpecialFolder.MyDocuments;
                    fbd.Description = "Укажите папку с программой:";
                    fbd.ShowNewFolderButton = false;                  
                    DialogResult result = fbd.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        //  string[] files = Directory.GetFiles(fbd.SelectedPath);
                        // System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                        put_k_proge = fbd.SelectedPath;

                        papca = Directory.Exists(put_k_proge + "\\rez");
                        Boolean papca1 = File.Exists(put_k_proge + "\\rez\\pcl.dll");
                        Boolean papca2 = File.Exists(put_k_proge + "\\rez\\pcm.dll");

                        if (papca == false) { MessageBox.Show("Тут нет нужной программы!\nУкажи нужную папку.", "Ошибка!"); }
                        else
                        {
                            if (papca1 == false) { MessageBox.Show("Отсутствует  файл ключа юзера!", "Ошибка!"); }
                            if (papca2 == false) { MessageBox.Show("Отсутствует  файл ключа мастера!", "Ошибка!"); }


                        }


                    }
                    if (result == DialogResult.Cancel)
                    {
                        papca =true;
                        ex = true;


                    }
                }
            }

            if (ex == true) Application.Exit(); else
            {

            string passedm = "";
            try
            {
                using (StreamReader stream = new StreamReader(put_k_proge + "\\rez\\pcm.dll"))
                {
                    while (stream.Peek() >= 0)
                    {
                        passedm = @stream.ReadLine();
                    }
                    stream.Close();
                }
            }
              catch { }
                     var x1 = new XORCipher();
                     var pass = "dfgdg5462";
                    if(passedm != "") textBox1.Text = x1.Decrypt(passedm, pass);

                try
                {
                    using (StreamReader stream = new StreamReader(put_k_proge + "\\rez\\pcl.dll"))
                    {
                        while (stream.Peek() >= 0)
                        {
                            passedm = @stream.ReadLine();
                        }
                        stream.Close();
                    }
                }
                catch { }
                if (passedm != "") textBox2.Text = x1.Decrypt(passedm, pass);            
                this.Activate();
                this.MaximizeBox = false;

            }
         

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (textBox3.Text.Length < 4)
            {
                MessageBox.Show("Слишком короткий пароль мастера.\nМинимум 4 символа.", "Не катит!");
            }
            else
            {
                var x1 = new XORCipher();
                var pass = "dfgdg5462";
                var encryptedMessageByPass = x1.Encrypt(textBox3.Text, pass);
                string newpass = encryptedMessageByPass;


                try
                {
                    FileStream fileStream = File.Open(put_k_proge + "\\rez\\pcll.dll", FileMode.Create); //FileMode.Create
                                                                                                         // получаем поток
                    StreamWriter output = new StreamWriter(fileStream);
                    // записываем текст в поток
                    output.Write(newpass);
                    // закрываем поток
                    output.Close();
                }
                catch { }




                string passedm1 = "";
                try
                {
                    using (StreamReader stream = new StreamReader(put_k_proge + "\\rez\\pcll.dll"))
                    {
                        while (stream.Peek() >= 0)
                        {
                            passedm1 = @stream.ReadLine();
                        }
                        stream.Close();
                    }
                }
                catch { }
                string test_pass = x1.Decrypt(passedm1, pass);

                if (test_pass != textBox3.Text)

                {
                    MessageBox.Show("Неполучится. !\nТакой пароль возможно взломать.\nПридумай другой!", "Не катит!");
                }
                else

                {
                    try { File.Delete(put_k_proge + "\\rez\\pcm.dll"); } catch { }
                    try { File.Move(put_k_proge + "\\rez\\pcll.dll", put_k_proge + "\\rez\\pcm.dll"); } catch { }
                    MessageBox.Show("Создан новый мастер пароль!!!\nПароль юзера меняется в программе!", "Сообщение");
                    textBox1.Text = test_pass;
                    //  this.Close();
                }

            }




        }








        public class XORCipher
        {
            //генератор повторений пароля
            private string GetRepeatKey(string s, int n)
            {
                var r = s;
                while (r.Length < n)
                {
                    r += r;
                }

                return r.Substring(0, n);
            }

            //метод шифрования/дешифровки
            private string Cipher(string text, string secretKey)
            {
                var currentKey = GetRepeatKey(secretKey, text.Length);
                var res = string.Empty;
                for (var i = 0; i < text.Length; i++)
                {
                    res += ((char)(text[i] ^ currentKey[i])).ToString();
                }

                return res;
            }

            //шифрование текста
            public string Encrypt(string plainText, string password)
                => Cipher(plainText, password);

            //расшифровка текста
            public string Decrypt(string encryptedText, string password)
                => Cipher(encryptedText, password);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true; 

        }

        private void OnFrameChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => OnFrameChanged(sender, e)));
                return;
            }
            ImageAnimator.UpdateFrames();
            Invalidate(false);
        }


    }
}
