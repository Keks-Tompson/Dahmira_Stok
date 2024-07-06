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
using System.Net;
using System.Net.Sockets;

namespace load__baze
{
    public partial class pass : Form
    {
        public pass()
        {
            InitializeComponent();
        }




       string passed = "";
        private void pass_Load(object sender, EventArgs e)
        {

            try
            {
                using (StreamReader stream = new StreamReader("rez\\pcl.dll"))
                {
                    while (stream.Peek() >= 0)
                    {
                        passed = @stream.ReadLine();
                    }
                    stream.Close();
                }
            }
            catch
            {
                MessageBox.Show("Файл ключа поврежден! Нужно ввести заного");
               
            }
            if (passed == "") { MessageBox.Show("Поврежден файл пароля!\nТут какой-то юный программист работает.. Ну-Ну!", "Да тут умняшка залез ко мне в папку!"); }
            DateTime dateTimeStart=new DateTime (1900,1,1,1,0,0,0);
            DateTime dateTimeStop = new DateTime(1900, 1, 1, 1,0, 0, 0);
            try
            {
                string codewhat = passed;
            byte[] bytes = new byte[codewhat.Length / 2];
            int g = 0;
            for (int i = 0; i < codewhat.Length; i = i + 2)
            {
                bytes[g] = Convert.ToByte(codewhat.Substring(i, 2));
                g++;
            }
            string str = Encoding.ASCII.GetString(bytes);
            int p5 = Convert.ToInt16(str.Substring(0, 2));
            int p4 = Convert.ToInt16(str.Substring(3, 2));
            int p3 = Convert.ToInt16(str.Substring(6, 2));
            int p2 = Convert.ToInt16(str.Substring(9, 2));
            int p1 = Convert.ToInt16(str.Substring(12, 4));        // год - месяц - день - час - минута - секунда
            dateTimeStart = new DateTime(p1, p2, p3, p5, p4, 00); // год - месяц - день - час - минута - секунда
            int f5 = Convert.ToInt16(str.Substring(17, 2));
            int f4 = Convert.ToInt16(str.Substring(20, 2));
            int f3 = Convert.ToInt16(str.Substring(23, 2));
            int f2 = Convert.ToInt16(str.Substring(26, 2));
            int f1 = Convert.ToInt16(str.Substring(29, 4));
            dateTimeStop = new DateTime(f1, f2, f3, f5, f4, 00);
            string dfd = "Расшифровка: \n c:" + dateTimeStart.ToString() + " по:" + dateTimeStop.ToString();
            } catch
            {
                //хуета c файлом
                MessageBox.Show("Файл ключа поврежден! Досвидос!");
                this.Close();
            }
            try { 
            DateTime tec = GetNetworkTimeUtc();
            tec=tec.AddHours(+3);

            if (dateTimeStart < tec && dateTimeStop > tec)
            {

                //Удачный ключ, сохраняемся
                label2.Text = "Ключ ещё актуальный";
                label3.Text = "до:" + dateTimeStop.ToString();
               Program.f1.save_praise();
                this.Close();
            }

            if (dateTimeStop < tec)
            {
                    //закончился ключ 
                    //оповистить и 
                    MessageBox.Show("Ключ истёк:\n" + dateTimeStop.ToString(),"Проверка доступа",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
            } catch
            {
                MessageBox.Show("Для сохранения данных требуется верификация в сети!\n Для этого нужен стабильный интернет!\nТребования компании.\n   Неудача!", "Проверка доступа", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
            //проверка pic
            Bitmap image1 = new Bitmap("rez\\he1.dll", true);
            int x, y;
            for (x = 0; x < image1.Width; x++)
            {
                for (y = 0; y < image1.Height; y++)
                {
                    Color pixelColor = image1.GetPixel(x, y);
                    Color newColor = Color.FromArgb(pixelColor.R, 0, 0);
                    image1.SetPixel(x, y, newColor);
                }
            }
            pictureBox1.Image = image1;

            pausePlay = !pausePlay;
            if (pausePlay)
            {
               // wmp.controls.pause();
              //  label1.Text = "Paused";
                ImageAnimator.StopAnimate(image1, delegate (object o, EventArgs args) { });
            }

            timer1.Enabled = true;

        }





        public static DateTime GetNetworkTimeUtc(string ntpServer = "time.nist.gov")
        {
            // NTP message size - 16 bytes of the digest (RFC 2030)
            var ntpData = new byte[48];

            //Setting the Leap Indicator, Version Number and Mode values
            ntpData[0] = 0x1B; //LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)

            var addresses = Dns.GetHostEntry(ntpServer).AddressList;

            // NTP работает через UDP и использует порт 123
            var ipEndPoint = new IPEndPoint(addresses[0], 123);
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                socket.Connect(ipEndPoint);

                //Stops code hang if NTP is blocked
                socket.ReceiveTimeout = 3000;

                socket.Send(ntpData);
                socket.Receive(ntpData);
            }

            //Offset to get to the "Transmit Timestamp" field (time at which the reply 
            //departed the server for the client, in 64-bit timestamp format."
            const byte serverReplyTime = 40;

            // Get the seconds part
            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

            // Get the seconds fraction
            ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

            //Convert From big-endian to little-endian
            intPart = SwapEndianness(intPart);
            fractPart = SwapEndianness(fractPart);

            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
            return (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);
        }

        // Convert From big-endian to little-endian
        // [url]http://stackoverflow.com/a/3294698/162671[/url]
        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
        }


        Boolean pausePlay = false;
        //ok   
        private void button_OK_Click(object sender, EventArgs e)
        {

            DateTime dateTimeStart = new DateTime(1900, 1, 1, 1, 0, 0, 0);
            DateTime dateTimeStop = new DateTime(1900, 1, 1, 1, 0, 0, 0);

            try
            {
                string codewhat = textBox1.Text;
                byte[] bytes = new byte[codewhat.Length / 2];
                int g = 0;
                for (int i = 0; i < codewhat.Length; i = i + 2)
                {
                    bytes[g] = Convert.ToByte(codewhat.Substring(i, 2));
                    g++;
                }
                string str = Encoding.ASCII.GetString(bytes);
                int p5 = Convert.ToInt16(str.Substring(0, 2));
                int p4 = Convert.ToInt16(str.Substring(3, 2));
                int p3 = Convert.ToInt16(str.Substring(6, 2));
                int p2 = Convert.ToInt16(str.Substring(9, 2));
                int p1 = Convert.ToInt16(str.Substring(12, 4));        // год - месяц - день - час - минута - секунда
                dateTimeStart = new DateTime(p1, p2, p3, p5, p4, 00); // год - месяц - день - час - минута - секунда
                int f5 = Convert.ToInt16(str.Substring(17, 2));
                int f4 = Convert.ToInt16(str.Substring(20, 2));
                int f3 = Convert.ToInt16(str.Substring(23, 2));
                int f2 = Convert.ToInt16(str.Substring(26, 2));
                int f1 = Convert.ToInt16(str.Substring(29, 4));
                dateTimeStop = new DateTime(f1, f2, f3, f5, f4, 00);
                string dfd = "Расшифровка: \n c:" + dateTimeStart.ToString() + " по:" + dateTimeStop.ToString();




                MessageBox.Show(dfd);

                DateTime tec= new DateTime(1900, 1, 1, 1, 0, 0, 0);
                try
                {
                    tec = GetNetworkTimeUtc();
                    tec = tec.AddHours(+3);

                }
                catch
                {
                    MessageBox.Show("Для сохранения данных требуется верификация в сети!\n Для этого нужен стабильный интернет!\nТребования компании.\n     Неудача!", "Проверка доступа", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();

                }
                    if (dateTimeStart < tec && dateTimeStop > tec)
                    {
                        //Удачный ключ, сохраняемся
                        label2.Text = "Ключ ещё актуальный";
                        label3.Text = "до:" + dateTimeStop.ToString();
                    // полная перезапись файла 
                    using (StreamWriter writer = new StreamWriter("rez\\pcl.dll", false))
                    {
                         writer.WriteLineAsync(textBox1.Text);
                    }
                    Program.f1.save_praise();
                    this.Close();
                    }

                    if (dateTimeStop < tec)
                    {
                        //закончился ключ 
                        //оповистить и 
                        MessageBox.Show("Ключ истёк:\n" + dateTimeStop.ToString(), "Проверка доступа", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                }
            }
            catch
            {
                //хуета c файлом
               


                MessageBox.Show("Файл ключа поврежден! Досвидос!");
                this.Close();
            }





























        }




        private void timer1_Tick(object sender, EventArgs e)
        {
 
            pictureBox1.Visible = false;
            timer1.Enabled = false;
        }


    }
}
