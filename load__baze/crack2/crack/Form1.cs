using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            groupBox1.Location = new Point(551, 0);
            groupBox2.Location = new Point(551, 0);
            groupBox3.Location = new Point(551, 0);
            this.Size = new Size(465,489);
            this.MaximumSize = new Size(465, 489);
            this.MinimumSize = new Size(465, 489);



        }
        string url_praise = "ftp://31.177.95.187";
        private void Form1_Load(object sender, EventArgs e)
        {
            // DateTime dateTime = new DateTime();
            DateTime dateTime1 = DateTime.Now;
            numericUpDownHor.Value = dateTime1.Hour;
            numericUpDownMin.Value = dateTime1.Minute;
            cal1.Text = monthCalendar1.TodayDate.Day + "/" + monthCalendar1.TodayDate.Month + "/" + monthCalendar1.TodayDate.Year;
            label_n.Text = DateTime.Now.Hour.ToString("F0").PadLeft(2, '0') + "#" + DateTime.Now.Minute.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar1.TodayDate.Day.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar1.TodayDate.Month.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar1.TodayDate.Year.ToString("F0").PadLeft(4, '0');

            try { numericUpDownHor2.Value = dateTime1.Hour + 1; } catch { numericUpDownHor2.Value = 0; }
            numericUpDownMin2.Value = dateTime1.Minute;
            cal2.Text = monthCalendar2.TodayDate.Day + "/" + monthCalendar2.TodayDate.Month + "/" + monthCalendar2.TodayDate.Year;
            label_n1.Text = ((DateTime.Now.Hour + 1).ToString("F0").PadLeft(2, '0')) + "#" + DateTime.Now.Minute.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar2.TodayDate.Day.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar2.TodayDate.Month.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar2.TodayDate.Year.ToString("F0").PadLeft(4, '0');


           dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;


        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            cal1.Text = monthCalendar1.SelectionRange.Start.Day + "/" + monthCalendar1.SelectionRange.Start.Month + "/" + monthCalendar1.SelectionRange.Start.Year;
            label_n.Text = numericUpDownHor.Value.ToString("F0").PadLeft(2, '0')+ "#" + numericUpDownMin.Value.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar1.SelectionRange.Start.Day.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar1.SelectionRange.Start.Month.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar1.SelectionRange.Start.Year.ToString("F0").PadLeft(4, '0');
            timer1.Start();
        }

        private void numericUpDownHor_ValueChanged(object sender, EventArgs e)
        {
            label_n.Text = numericUpDownHor.Value.ToString("F0").PadLeft(2, '0') + "#" + numericUpDownMin.Value.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar1.SelectionRange.Start.Day.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar1.SelectionRange.Start.Month.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar1.SelectionRange.Start.Year.ToString("F0").PadLeft(4, '0');
            timer1.Start();
        }

        private void numericUpDownMin_ValueChanged(object sender, EventArgs e)
        {
            label_n.Text = numericUpDownHor.Value.ToString("F0").PadLeft(2, '0') + "#" + numericUpDownMin.Value.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar1.SelectionRange.Start.Day.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar1.SelectionRange.Start.Month.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar1.SelectionRange.Start.Year.ToString("F0").PadLeft(4, '0');
            timer1.Start();
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            cal2.Text = monthCalendar2.SelectionRange.Start.Day + "/" + monthCalendar2.SelectionRange.Start.Month + "/" + monthCalendar2.SelectionRange.Start.Year;
            label_n1.Text = numericUpDownHor2.Value.ToString("F0").PadLeft(2, '0') + "#" + numericUpDownMin2.Value.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar2.SelectionRange.Start.Day.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar2.SelectionRange.Start.Month.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar2.SelectionRange.Start.Year.ToString("F0").PadLeft(4, '0');
            timer1.Start();
        }

        private void numericUpDownHor2_ValueChanged(object sender, EventArgs e)
        {
            label_n1.Text = numericUpDownHor2.Value.ToString("F0").PadLeft(2, '0') + "#" + numericUpDownMin2.Value.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar2.SelectionRange.Start.Day.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar2.SelectionRange.Start.Month.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar2.SelectionRange.Start.Year.ToString("F0").PadLeft(4, '0');
            timer1.Start();
        }

        private void numericUpDownMin2_ValueChanged(object sender, EventArgs e)
        {
            label_n1.Text = numericUpDownHor2.Value.ToString("F0").PadLeft(2, '0') + "#" + numericUpDownMin2.Value.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar2.SelectionRange.Start.Day.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar2.SelectionRange.Start.Month.ToString("F0").PadLeft(2, '0') + "#" + monthCalendar2.SelectionRange.Start.Year.ToString("F0").PadLeft(4, '0');
            timer1.Start();
        }

     
        private void timer1_Tick(object sender, EventArgs e)
        {
            label_it.Text = label_n.Text + "#" + label_n1.Text;
            textBox2.Text = label_n.Text + "#" + label_n1.Text;
            byte[] bytes = Encoding.ASCII.GetBytes(label_it.Text);

            label_coding.Text = "";
            textBox2.Text = "";
            for (int i = 0; i < bytes.Length; i++)
            {
            label_coding.Text = label_coding.Text+bytes[i].ToString();
                textBox2.Text = label_coding.Text + bytes[i].ToString();
            }
            timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label_coding.Text);
            button1.BackColor = Color.Green;
            timer2.Start();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {

            try { 
            label_id.Text = "";
            string codewhat = label_coding.Text;
            byte[] bytes = new byte[codewhat.Length / 2];
            int g = 0;
            for (int i = 0; i < codewhat.Length; i=i+2)
            {                            
                bytes[g] = Convert.ToByte(codewhat.Substring(i, 2));
                g++;
            }
            string str = Encoding.ASCII.GetString(bytes);

            DateTime dateTimeStart;
            DateTime dateTimeStop;
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
            label_id.Text ="Расшифровка: \n c:" +dateTimeStart.ToString() +" по:"+ dateTimeStop.ToString();
            } catch
            {label_id.Text = "Ошибка дишифровки!";}






        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           button1.BackColor = Color.Empty;
            timer2.Stop();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                label_id.Text = "";
                string codewhat = textBox1.Text;
                byte[] bytes = new byte[codewhat.Length / 2];
                int g = 0;
                for (int i = 0; i < codewhat.Length; i = i + 2)
                {
                    bytes[g] = Convert.ToByte(codewhat.Substring(i, 2));
                    g++;
                }
                string str = Encoding.ASCII.GetString(bytes);

                DateTime dateTimeStart;
                DateTime dateTimeStop;
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
                label6.Text = "Расшифровка: \n c:" + dateTimeStart.ToString() + " по:" + dateTimeStop.ToString();
            }
            catch
            { label6.Text = "Ошибка дишифровки!"; }
        }

        string[] messenges = null;
        private void button2_Click(object sender, EventArgs e)
        {
            FtpWebRequest request2 = (FtpWebRequest)WebRequest.Create(url_praise + "/users/users.txt");
            request2.Method = WebRequestMethods.Ftp.DownloadFile;

            // This example assumes the FTP site uses anonymous logon.
            request2.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");

            try
            {
                FtpWebResponse response2 = (FtpWebResponse)request2.GetResponse();
                Stream responseStream = response2.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string s = reader.ReadToEnd();

                messenges = s.Split(
                 new[] { "\r\n", "\r", "\n" },
                   StringSplitOptions.None
                  );
                try { reader.Close(); } catch { }
                try { response2.Close(); } catch { }


                if (messenges != null)
                {
                    dataGridView1.Rows.Clear();

                    for (int i = 0; i < messenges.Length; i++)
                    {
                        dataGridView1.Rows.Add(messenges[i], messenges[i + 1], messenges[i + 2]);
                        i++;
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Техническая неисправность");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] mess_up = null;

            if (dataGridView1.RowCount > 0)
            {

                mess_up = new string[(dataGridView1.RowCount * 3)];
                int go = 0;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    mess_up[go] = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    go++;
                    mess_up[go] = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    go++;
                    mess_up[go] = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    go++;
                }
                string str = string.Join("\r\n", mess_up); // строка к отправке

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(url_praise + "/users/users.txt"));
                request.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                try
                {
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    response.Close();
                    WebClient client = new WebClient();
                    client.Encoding = Encoding.UTF8;
                    client.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                    client.UploadString(url_praise + "/users/users.txt", "APPE", str);
                    MessageBox.Show("Отправленно без ошибок.");
                }
                catch { MessageBox.Show("Не смогла отправить!"); }





            }
            else
            {
                MessageBox.Show("Пустая таблица", "");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Random fd = new Random();

            long gf = fd.Next(123456789, 999999999);
            
            dataGridView1.Rows.Add(textBox3.Text, textBox4.Text, gf.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0) { dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex); }
            else
            {
                MessageBox.Show("Все уволены!\nСписок пуст..", "");    
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //base.OnRowPostPaint(e);
            if (dataGridView1.RectangleToScreen(e.RowBounds).Contains(MousePosition))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Blue)), e.RowBounds);
                e.Graphics.DrawRectangle(new Pen(Color.Blue), e.RowBounds);
            }
        }

        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.Invalidate();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Empty;
                dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.Empty;
                dataGridView1.Rows[i].Cells[2].Style.BackColor = Color.Empty;
            }

            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Style.BackColor = Color.Blue;
            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Style.BackColor = Color.Blue;
            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Style.BackColor = Color.Blue;

        }


        
         #region кнопки и оформление
        private void Breack1_Click(object sender, EventArgs e)
        {
            groupBox1.Location = new Point(551, 0);
            groupBox2.Location = new Point(551, 0);
            groupBox3.Location = new Point(551, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox1.Location = new Point(551, 0);
            groupBox2.Location = new Point(551, 0);
            groupBox3.Location = new Point(551, 0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox1.Location = new Point(551, 0);
            groupBox2.Location = new Point(551, 0);
            groupBox3.Location = new Point(551, 0);
        }
       private void button8_Click(object sender, EventArgs e)
        {
            groupBox1.Location = new Point(1, 0);
            groupBox2.Location = new Point(551, 0);
            groupBox3.Location = new Point(551, 0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            groupBox2.Location = new Point(1, 0);
            groupBox1.Location = new Point(551, 0);
            groupBox3.Location = new Point(551, 0);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            groupBox3.Location = new Point(1, 0);
            groupBox2.Location = new Point(551, 0);
            groupBox1.Location = new Point(551, 0);
        }



















        #endregion кнопки и оформление4

        //коэфициенты
        // скачать


#region окно3 измеение цен, коэф.


        private void button12_Click(object sender, EventArgs e)
        {
           FtpWebRequest request2 = (FtpWebRequest)WebRequest.Create(url_praise + "/coefficient_prices/coefficient_prices.txt");
           request2.Method = WebRequestMethods.Ftp.DownloadFile;           
           request2.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
           string[] messenges_baks=null;
           try
            {
                FtpWebResponse response2 = (FtpWebResponse)request2.GetResponse();
                Stream responseStream = response2.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string s = reader.ReadToEnd();
                messenges_baks = s.Split(
                 new[] { "\r\n", "\r", "\n" },
                   StringSplitOptions.None
                  );
                try { reader.Close(); } catch { }
                try { response2.Close(); } catch { }
                if (messenges_baks == null)
                {
                    return;
                }
                int yu = Convert.ToInt16(messenges_baks[0]);
                if (yu > 0) { textBox30.Enabled = true; numericUpDown20.Enabled = true; textBox30.Text = messenges_baks[1]; numericUpDown20.Value = Convert.ToDecimal(messenges_baks[16]);}
                if (yu > 0) { textBox31.Enabled = true; numericUpDown21.Enabled = true; textBox31.Text = messenges_baks[2]; numericUpDown21.Value = Convert.ToDecimal(messenges_baks[17]); }
                if (yu > 1) { textBox32.Enabled = true; numericUpDown22.Enabled = true; textBox32.Text = messenges_baks[3]; numericUpDown22.Value = Convert.ToDecimal(messenges_baks[18]); }
                if (yu > 2) { textBox33.Enabled = true; numericUpDown23.Enabled = true; textBox33.Text = messenges_baks[4]; numericUpDown23.Value = Convert.ToDecimal(messenges_baks[19]); }
                if (yu > 3) { textBox34.Enabled = true; numericUpDown24.Enabled = true; textBox34.Text = messenges_baks[5]; numericUpDown24.Value = Convert.ToDecimal(messenges_baks[20]); }
                if (yu > 4) { textBox35.Enabled = true; numericUpDown25.Enabled = true; textBox35.Text = messenges_baks[6]; numericUpDown25.Value = Convert.ToDecimal(messenges_baks[21]); }
                if (yu > 5) { textBox36.Enabled = true; numericUpDown26.Enabled = true; textBox36.Text = messenges_baks[7]; numericUpDown26.Value = Convert.ToDecimal(messenges_baks[22]); }
                if (yu > 6) { textBox37.Enabled = true; numericUpDown27.Enabled = true; textBox37.Text = messenges_baks[8]; numericUpDown27.Value = Convert.ToDecimal(messenges_baks[23]); }
                if (yu > 7){ textBox38.Enabled = true; numericUpDown28.Enabled = true;  textBox38.Text = messenges_baks[9];  numericUpDown28.Value = Convert.ToDecimal(messenges_baks[24]); }
                if (yu > 8){ textBox39.Enabled = true; numericUpDown29.Enabled = true;  textBox39.Text = messenges_baks[10]; numericUpDown29.Value = Convert.ToDecimal(messenges_baks[25]); }
                if (yu > 9){ textBox40.Enabled = true; numericUpDown30.Enabled = true;  textBox40.Text = messenges_baks[11]; numericUpDown30.Value = Convert.ToDecimal(messenges_baks[26]); }
                if (yu > 10){ textBox41.Enabled = true; numericUpDown31.Enabled = true; textBox41.Text = messenges_baks[12]; numericUpDown31.Value = Convert.ToDecimal(messenges_baks[27]); }
                if (yu > 11){ textBox42.Enabled = true; numericUpDown32.Enabled = true; textBox42.Text = messenges_baks[13]; numericUpDown32.Value = Convert.ToDecimal(messenges_baks[28]); }
                if (yu > 12){ textBox43.Enabled = true; numericUpDown33.Enabled = true; textBox43.Text = messenges_baks[14]; numericUpDown33.Value = Convert.ToDecimal(messenges_baks[29]); }
                if (yu > 13){ textBox44.Enabled = true; numericUpDown34.Enabled = true; textBox44.Text = messenges_baks[15]; numericUpDown34.Value = Convert.ToDecimal(messenges_baks[30]); }
                label18.Text = "Загружено";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Техническая неисправность");
                label18.Text = "Ошибка";
            }
        }
        //закачать!
        private void button11_Click(object sender, EventArgs e)
        {
            string[] messenges_baks = new string[31];
            for (int i = 0; i <31; i++){messenges_baks[i] = "";}
            int J = 0;
            messenges_baks[1] = textBox30.Text; if (textBox30.Text != "") { J = 1; }
            messenges_baks[2] = textBox31.Text; if (textBox31.Text != "") { J = 2; }
            messenges_baks[3] = textBox32.Text; if (textBox32.Text != "") { J = 3; }
            messenges_baks[4] = textBox33.Text; if (textBox33.Text != "") { J = 4; }
            messenges_baks[5] = textBox34.Text; if (textBox34.Text != "") { J = 5; }
            messenges_baks[6] = textBox35.Text; if (textBox35.Text != "") { J = 6; }
            messenges_baks[7] = textBox36.Text; if (textBox36.Text != "") { J = 7; }
            messenges_baks[8] = textBox37.Text; if (textBox37.Text != "") { J = 8; }
            messenges_baks[9] = textBox38.Text; if (textBox38.Text != "") { J = 9; }
            messenges_baks[10] = textBox39.Text; if (textBox39.Text != "") { J =10; }
            messenges_baks[11] = textBox40.Text; if (textBox40.Text != "") { J = 11; }
            messenges_baks[12] = textBox41.Text; if (textBox41.Text != "") { J = 12; }
            messenges_baks[13] = textBox42.Text; if (textBox42.Text != "") { J = 13; }
            messenges_baks[14] = textBox43.Text; if (textBox43.Text != "") { J = 14; }
            messenges_baks[15] = textBox44.Text; if (textBox44.Text != "") { J = 15; }
            messenges_baks[0] = J.ToString();
            messenges_baks[16] = numericUpDown20.Value.ToString();
            messenges_baks[17] = numericUpDown21.Value.ToString();
            messenges_baks[18] = numericUpDown22.Value.ToString();
            messenges_baks[19] = numericUpDown23.Value.ToString();
            messenges_baks[20] = numericUpDown24.Value.ToString();
            messenges_baks[21] = numericUpDown25.Value.ToString();
            messenges_baks[22] = numericUpDown26.Value.ToString();
            messenges_baks[23] = numericUpDown27.Value.ToString();
            messenges_baks[24] = numericUpDown28.Value.ToString();
            messenges_baks[25] = numericUpDown29.Value.ToString();
            messenges_baks[26] = numericUpDown30.Value.ToString();
            messenges_baks[27] = numericUpDown31.Value.ToString();
            messenges_baks[28] = numericUpDown32.Value.ToString();
            messenges_baks[29] = numericUpDown33.Value.ToString();
            messenges_baks[30] = numericUpDown34.Value.ToString();
            string str = string.Join("\r\n", messenges_baks); // строка к отправке
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(url_praise + "/coefficient_prices/coefficient_prices.txt"));
            request.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                client.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                client.UploadString(url_praise + "/coefficient_prices/coefficient_prices.txt", "APPE", str);
                MessageBox.Show("Отправленно без ошибок.");
                label18.Text = "Загружено";
            }
            catch {
                MessageBox.Show("Не смогла отправить!");
                label18.Text = "Ошибка";
            }
        }
        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            if (textBox30.Text == "") { textBox31.Enabled = false; numericUpDown21.Enabled = false; textBox31.Text = ""; } else { textBox31.Enabled = true; numericUpDown21.Enabled = true; }
        }
        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            if (textBox31.Text == "") { textBox32.Enabled = false; numericUpDown22.Enabled = false; textBox32.Text = ""; } else { textBox32.Enabled = true; numericUpDown22.Enabled = true; }
        }
        private void textBox32_TextChanged(object sender, EventArgs e)
        {
            if (textBox32.Text == "") { textBox33.Enabled = false; numericUpDown23.Enabled = false; textBox33.Text = ""; } else { textBox33.Enabled = true; numericUpDown23.Enabled = true; }
        }
        private void textBox33_TextChanged(object sender, EventArgs e)
        {
            if (textBox33.Text == "") { textBox34.Enabled = false; numericUpDown24.Enabled = false; textBox34.Text = ""; } else { textBox34.Enabled = true; numericUpDown24.Enabled = true; }
        }
        private void textBox34_TextChanged(object sender, EventArgs e)
        {
            if (textBox34.Text == "") { textBox35.Enabled = false; numericUpDown25.Enabled = false; textBox35.Text = ""; } else { textBox35.Enabled = true; numericUpDown25.Enabled = true; }
        }
        private void textBox35_TextChanged(object sender, EventArgs e)
        {
            if (textBox35.Text == "") { textBox36.Enabled = false; numericUpDown26.Enabled = false; textBox36.Text = ""; } else { textBox36.Enabled = true; numericUpDown26.Enabled = true; }
        }
        private void textBox36_TextChanged(object sender, EventArgs e)
        {
            if (textBox36.Text == "") { textBox37.Enabled = false; numericUpDown27.Enabled = false; textBox37.Text = "";} else { textBox37.Enabled = true; numericUpDown27.Enabled = true; }
        }
        private void textBox37_TextChanged(object sender, EventArgs e)
        {
            if (textBox37.Text=="") { textBox38.Enabled = false; numericUpDown28.Enabled = false; textBox38.Text = ""; } else {textBox38.Enabled = true; numericUpDown28.Enabled = true;}
        }
        private void textBox38_TextChanged(object sender, EventArgs e)
        {
            if (textBox38.Text == "") { textBox39.Enabled = false; numericUpDown29.Enabled = false; textBox39.Text = ""; } else { textBox39.Enabled = true; numericUpDown29.Enabled = true; }
        }
        private void textBox39_TextChanged(object sender, EventArgs e)
        {
            if (textBox39.Text == "") { textBox40.Enabled = false; numericUpDown30.Enabled = false; textBox40.Text = ""; } else { textBox40.Enabled = true; numericUpDown30.Enabled = true; }
        }
        private void textBox40_TextChanged(object sender, EventArgs e)
        {
            if (textBox40.Text == "") { textBox41.Enabled = false; numericUpDown31.Enabled = false; textBox41.Text = ""; } else { textBox41.Enabled = true; numericUpDown31.Enabled = true; }
        }
        private void textBox41_TextChanged(object sender, EventArgs e)
        {
            if (textBox41.Text == "") { textBox42.Enabled = false; numericUpDown32.Enabled = false; textBox42.Text = ""; } else { textBox42.Enabled = true; numericUpDown32.Enabled = true; }
        }
        private void textBox42_TextChanged(object sender, EventArgs e)
        {
            if (textBox42.Text == "") { textBox43.Enabled = false; numericUpDown33.Enabled = false; textBox43.Text = ""; } else { textBox43.Enabled = true; numericUpDown33.Enabled = true; }
        }
        private void textBox43_TextChanged(object sender, EventArgs e)
        {
            if (textBox43.Text == "") { textBox44.Enabled = false; numericUpDown34.Enabled = false; textBox44.Text = ""; } else { textBox44.Enabled = true; numericUpDown34.Enabled = true; }
        }
        private void textBox44_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button12_Enter(object sender, EventArgs e)
        {
         
        }

        private void button12_Leave(object sender, EventArgs e)
        {
           
        }
        #endregion окно3 измеение цен, коэф.

        private void button12_MouseEnter(object sender, EventArgs e)
        {
          label7.Text="Получить данные с сайта";
        }

        private void button12_MouseLeave(object sender, EventArgs e)
        {
          label7.Text = "";
        }

        private void button11_MouseEnter(object sender, EventArgs e)
        {
            label7.Text = "Загрузить данные на сайт";
        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {
            label7.Text = "";
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            label8.Text = "Ключ для сохранения на сайт";
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            label8.Text = "";
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            label8.Text = "Регистрация работника";
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            label8.Text = "";
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            label8.Text = "Коэффициент накрутки цен";
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            label8.Text = "";
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            pictureBox1.Enabled = false;

            timer3.Enabled = false;
        }
    }
}
