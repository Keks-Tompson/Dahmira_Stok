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
    public partial class автор : Form
    {  //for your info, this only works on x86 projects
       //due to the library itself







        public автор()
        {
            InitializeComponent();
        }

        Vlc.DotNet.Forms.VlcControl vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
        string vail = "";
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon("ico.ico");
            this.Text= "О программе. Версия: "+System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            MaximizeBox = false;

            string[] poput_load = Environment.GetCommandLineArgs();
            System.IO.FileInfo obj = new System.IO.FileInfo(poput_load[0]);
            vail = obj.DirectoryName + "\\rez\\ava.ini";//папка к программе            
            ProcessStartInfo infoStartProcess = new ProcessStartInfo();
            infoStartProcess.WorkingDirectory = obj.DirectoryName + "rez\\CNData\\ddl";//папка к программе 
            DirectoryInfo di = new DirectoryInfo(obj.DirectoryName + "\\rez\\CNData\\ddl");
            vlcControl1.Size = new Size(489, 278);
            vlcControl1.Location = new System.Drawing.Point(11, 11);
            vlcControl1.BackColor = Color.Empty;
            vlcControl1.BeginInit();
            vlcControl1.VlcLibDirectory = (System.IO.DirectoryInfo)(vlcControl1.VlcLibDirectory = di); //Make sure your dir is correct
            vlcControl1.VlcMediaplayerOptions = new[] { "-vv" }; //not sure what this does
            vlcControl1.EndInit();
            this.Controls.Add(vlcControl1); //Add the control to your container
            vlcControl1.Dock = DockStyle.None; //Optional          
            timer1.Enabled = true;

        }

        private void автор_FormClosing(object sender, FormClosingEventArgs e)
        {
            vlcControl1.Stop();
        }

        private void vlcControl1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            vlcControl1.Play(new Uri(vail));
            timer1.Enabled = false;
        }

        string[] liz = new string[50];

        int x = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            liz[0] = " Я Вас не видел. Я Вас не знаю. Каждый сам за себя!";
            liz[1] = " Представленная сборка была создана неизвестным";
            liz[2] = " программистом (уже не студентами), в перерывах между";
            liz[3] = " лекциями и варкой пельменей (между варкой пельменей и";
            liz[4] = " варкой пельменей, если бы где то там были лекции он бы";
            liz[5] = " все еще были студентам) при поддержке мамы, папы,";
            liz[6] = " ремня папы, кота Василия (на самом деле его не существует";
            liz[7] = " было просто очень одиноко) и военкома Геннадия Петровича,";
            liz[8] = " благодаря которому он скинул пару килограмм и приобрел";
            liz[9] = " пару седин.";
            liz[10] = " Надеюсь, Вам понравится, все делалось ради удобства и";
            liz[11] = " причинения удовольствия пользавтелю!";
            liz[12] = " Если же нет, ничего страшного. Просто отправь мне свой";
            liz[13] = " адрес на мыло и мы при встрече разберемся, чем ты";
            liz[14] = " недоволен.";
            liz[15] = " И я снова вынужден напомнить, что если программа  ";
            liz[16] = " что то случайно удалила или испортила, или зависла!";
            liz[17] = " Прошу извенить! Она не хотела. Просто, Вы возлажили";
            liz[18] = " на неё большие надежды! А она сделала Ваш день!";
            liz[19] = " Понимаешь, тут как в сексе: Каждый сам за себя!";
            liz[20] = "  Я Вас не видел. Я Вас не знаю. Каждый сам за себя!";


            label2.Text = "Лицензия:"+liz[x];

            if (x == 20) { timer2.Enabled = false; }
            x++;
               
        }
    }
}

/*
 
   player = new VlcControl();

panel1.Controls.Add(player);

player.BackColor = System.Drawing.Color.Black;
player.ImeMode = System.Windows.Forms.ImeMode.NoControl;
player.Location = new System.Drawing.Point(0, 0);
player.Name = "test";
player.Rate = 0.0F;

player.Size = new System.Drawing.Size(1024, 768);

Vlc.DotNet.Core.Medias.MediaBase media = new 
    Vlc.DotNet.Core.Medias.PathMedia(@"path\movie.avi");
player.Media = media;
player.Play();






     */
