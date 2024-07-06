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
using System.IO.Compression;
using System.Diagnostics;
using Ionic.Zip;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Resources;
using System.Net;

namespace load__baze
{
    public partial class info : Form
    {
        string url_praise = "ftp://31.177.95.187";


        public info()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            groupBox2.Location = new Point(2, -6);
            groupBox1.Location = new Point(346, -6);                
        }

            string имя = "";
            string пароль = "";
        private void button2_Click(object sender, EventArgs e)
        {
            
            string email = "";
            //проверка строки на емайл
            string cond = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
            string emailу = TextBox_emal.Text.Replace(" ", "");
            TextBox_emal.Text= TextBox_emal.Text.Replace(" ", "");

            //чёрный список
            if (
                TextBox_emal.Text == "tech@dahmira.com" ||
                TextBox_emal.Text == "tech@dahmira.by" ||
                TextBox_emal.Text == "tech@dahmira.ru"||
                TextBox_emal.Text == "+tech@dahmira.ru"
                )
            {
                MessageBox.Show("Данный почтовый ящик в чёрном списке!\nТам проходной двор, ребята!","Нет!");
                return;
            }


            if (Regex.IsMatch(emailу, cond))
            {
                string[] messenges = null;
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
                        bool no = false;
                        for (int i = 0; i < messenges.Length; i++)
                        {
                            if (messenges[i] == TextBox_emal.Text)
                            {
                                //есть 
                                 имя = messenges[i-1];
                                 пароль = messenges[i+1];
                                 email = messenges[i];
                                 label3.Text = имя;
                                 no = true;
                            }                    
                        }
                        if (no == false)
                        {
                            //нет в базе таких  юзиров! 
                            MessageBox.Show("Вас нет в списках комании!\nВы не можете пользоваться прайсом.\nСвяжитесь с руководителем отдела.", "Отказано");
                            return;
                        }
                    }
                    else
                    { MessageBox.Show("На сайте ведуться работы, попробуйте позже");return; }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Техническая неисправность\nНетсвязи с сайтом компании\ner001");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Не правильно введен почтовый ящик\nНе удовлетворяет международным требованиям!", "Акуратнее");
                return;
            }

         //   return; //временно

            // Отправить письмо
            try
            {
                var fromAddress = new MailAddress("i1mn@dahmira.com", "Администратор");   //я
                var toAddress = new MailAddress(email, имя); //кому
                string fromPassword = "Qazxswedcvfrtgb1234";
                string subject = "Ваш пароль от программы";            
                string body = "<!DOCTYPE html>\n<html>\n<head>\n\t<title>be1.ru</title>\n</head>\n<body>\n<table align=\"center\" border=\"1\" bordercolor=\"#ccc\" cellpadding=\"5\" cellspacing=\"0\" style=\"border-collapse:collapse\">\n\t<tbody>\n\t\t<tr>\n\t\t\t<td colspan=\"2\">\n\t\t\t<p><span style=\"font-size:18px\"><span style=\"color:#8e44ad\">Здравствуйте, "+имя+"!</span></span></p>\n\t\t\t</td>\n\t\t</tr>\n\t\t<tr>\n\t\t\t<td colspan=\"2\">\n\t\t\t<p><span style=\"color:#330033\">Вы воспользовались программой компании Дахмира.<br />\n\t\t\tДля последующей работы через сеть Интернет.<br />\n\t\t\tМы создали для Вас аккаунт.</span></p>\n\t\t\t</td>\n\t\t</tr>\n\t\t<tr>\n\t\t\t<td colspan=\"2\">\n\t\t\t<p><span style=\"color:#000066\"><var><span style=\"font-family:Comic Sans MS,cursive\"><span style=\"background-color:#dddddd\">ВАШ ПАРОЛЬ:"+ пароль + "</span></span></var></span></p>\n\t\t\t</td>\n\t\t</tr>\n\t\t<tr>\n\t\t\t<td colspan=\"2\">\n\t\t\t<p>Надеемся, Вам понравится наш новый продукт.<br />\n\t\t\tВаши отзывы, предложения и пожелания по работе&nbsp; Вы можете оставить при себе, нам не интересно Ваше мнение.&nbsp;</p>\n\t\t\t</td>\n\t\t</tr>\n\t\t<tr>\n\t\t\t<td colspan=\"2\">\n\t\t\t<p>Если у Вас возникли какие-либо вопросы, свяжитесь с нашей службой поддержки:<a href=\"mailto: tech@dahmira.by?subject=%D0%9A%D0%BB%D0%B8%D0%B5%D0%BD%D1%82&amp;body=%D0%9F%D1%80%D0%BE%D1%88%D1%83%20%D0%BF%D0%BE%D0%BC%D0%BE%D1%89%D1%8C.%20%0A%D0%A3%D0%BC%D0%BE%D0%BB%D1%8F%D1%8E.%20\" target=\"_blank\">служба поддержки.</a>.</p>\n\n\t\t\t<p>Почитать дополнителью информацию можно на сайте комании: &nbsp;<a href=\"http://dahmira.com\" target=\"_blank\">Dahmira</a></p>\n\t\t\t</td>\n\t\t</tr>\n\t</tbody>\n</table>\n</body>\n</html>"; //http://dahmira.com
                var smtp = new SmtpClient
                {
                    Host = "91.189.116.43",  // "mail.nic.ru",
                    Port = 2525,
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 5000
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                   message.IsBodyHtml = true; 
                    smtp.EnableSsl = false;
                    try
                    {
                       //отправка
                        smtp.Send(message);
                        groupBox3.Location = new Point(2, -6);
                        groupBox2.Location = new Point(346, -6);
                    }
                    catch (SmtpFailedRecipientsException ex)
                    {
                        string sdsd = ex.Message;
                        MessageBox.Show(ex.Message, "Техническая неисправность\nНетсвязи с сайтом компании\n"+ sdsd + "\ner002");
                    }
                    catch (Exception ex)
                    {
                       string sdsd = ex.Message;
                        MessageBox.Show(ex.Message, "Техническая неисправность\nНетсвязи с сайтом компании\n" + sdsd + "\ner003");
                    }
                }
            }
            catch (Exception ex)
            {
                string sdsd = ex.Message;
                MessageBox.Show(ex.Message, "Техническая неисправность\nНетсвязи с сайтом компании\n" + sdsd + "\ner004");
            }
        }

        int g = 10;
        private void button3_Click(object sender, EventArgs e)
        {




            if (g == 0)
            {
                try { Process.Start("cmd", "/C color 2 &&  tree c:\\"); } catch { }              
            }


            if (textBox1.Text == пароль)
            {
                groupBox4.Location = new Point(2, -6);
                groupBox3.Location = new Point(346, -6);
            }
            else
            {
                MessageBox.Show("Осталось: " + g.ToString() + ", попытки, до заражения компьютера, вирусом", " Не правильно!");
                g--;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Program.fX.ok_aut(имя);
            Close();
        }

        private void info_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { Program.fX.TopMost = true; } catch { }
        }
    }    
}
