using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace Setupe_dahmira_soft
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(474, 270);
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                           (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            label6.Text = Environment.Is64BitProcess ? Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) : Environment.GetEnvironmentVariable("ProgramW6432") + "\\Dahmira_soft";
            label_lez.Size = new Size(312, 2400);
         #region лицензия 
            label_lez.Text= "ЛИЦЕНЗИОННОЕ СОГЛАШЕНИЕ НА ИСПОЛЬЗОВАНИЕ ПРОГРАММЫ ДЛЯ ЭВМ" +
"\n<load__baze>"+
"\nУважаемый Пользователь!" +
"\nПеред началом установки, копирования либо иного использования программного обеспечения" +
"(далее – ПО) внимательно ознакомьтесь с условиями настоящего Соглашения, являющегося" +
"стандартной формой договора присоединения и заключаемого в письменной или иной форме," +
"предусмотренной действующим законодательством Республики Беларусь.Если вы не согласны с" +
"условиями настоящего Соглашения, вы не можете использовать ПО. Установка, запуск или иное" +
"начало использования ПО означает Ваше полное согласие со всеми условиями настоящего" +
"Соглашения и его надлежащее заключение.Настоящее Соглашение является юридически" +
"обязательным соглашением, если Вы не согласны принять на себя его условия, Вы не имеете права" +
"устанавливать ПО и должны удалить все его компоненты со своего устройства." +
"Настоящее Лицензионное соглашение(далее – Соглашение) заключается между Частным" +
"предприятием «Technical camera © Copyright» (далее – Лицензиар) и Пользователем(любым физическим лицом," +
"индивидуальным предпринимателем, юридическим лицом (далее – Пользователь) Программы для" +
"ЭВМ «load__baze» (далее – ПО)." +
"\nОсновные термины настоящего Соглашения:" +
"\nПО – программа для ЭВМ «load__baze» (как в целом, так и ее компоненты)," +
"исключительные имущественные права на которую на территории, определенной в п. 1.4." +
"\nСоглашения, принадлежат Лицензиару." +
"\nДемо - версия ПО – версия ПО «load__baze», в которой установлено ограничение по сроку" +
"ее использования и которая предназначена исключительно для самостоятельного ознакомления" +
"\nПользователем с функциональными возможностями ПО на условиях настоящего Соглашения и не" +
"предназначена для продажи или иного отчуждения третьим лицам." +
"\n1.Предмет соглашения" +
"\n1.1.В порядке и на условиях, предусмотренных настоящим Соглашением, Лицензиар" +
"предоставляет Пользователю право использования ПО(простая неисключительная лицензия)," +
"реализуемое путем установки(инсталляции) и запуска Пользователем ПО в соответствии с его" +
"технической документацией и условиями настоящего Соглашения." +
"\n1.2.Все положения настоящего Соглашения распространяются как на ПО в целом, так и на его" +
"отдельные компоненты. ПО лицензируется как единая программа для ЭВМ, его компоненты не могут" +
"быть разделены и использоваться на разных устройствах." +
"\n1.3.Настоящее Соглашение заключается до или непосредственно в момент начала использования" +
"ПО и действует на протяжении всего срока действия исключительного права Лицензиара на ПО, при" +
"условии надлежащего выполнения Пользователем условий настоящего Соглашения." +
"\n1.4.Лицензиар предоставляет Пользователю право использования ПО на территории Республики" +
"Беларусь и настоящим Соглашением." +
"\n2.Авторские права" +
"\n2.1.ПО является результатом интеллектуальной деятельности и объектом авторских прав как" +
"программа для ЭВМ, которые регулируются и защищены законодательством Республики Беларусь" +
"об интеллектуальной собственности и нормами международного права." +
"\n2.2.ПО содержит коммерческую тайну и иную конфиденциальную информацию, принадлежащую" +
"Лицензиару.Любое использование ПО в нарушение условий настоящего Соглашения" +
"рассматривается как нарушение прав Лицензиара и является достаточным основанием для" +
"лишения Пользователя предоставленных по настоящему Соглашению прав." +
"\n2.3.Лицензиар гарантирует, что обладает всеми правами использования ПО, включая" +
"документацию к ней, необходимыми для предоставления Пользователю прав на использование ПО" +
"по настоящему Соглашению." +
"\n2.4.В случае нарушения авторских прав предусматривается ответственность в соответствии с" +
"действующим законодательством Республики Беларусь." +
"\n3.Условия использования ПО и ограничения" +
"\n3.1.Настоящее Соглашение предоставляет право установки(инсталляции), запуска и" +
"использования законно приобретенной одной копии ПО в рамках его функциональных" +
"возможностей на одном устройстве пользователя." +
"\n3.2.Пользователь вправе изменять, добавлять или удалять любые файлы приобретенного ПО" +
"только в случаях, предусмотренных Законодательством Республики Беларусь об авторском праве." +
"\n3.3.Запрещается удалять любую информацию об авторских правах." +
"\n3.4.Запрещается любое использование ПО, противоречащее действующему законодательству" +
"Республики Беларусь." +
"\n4.Ответственность сторон" +
"\n4.1.За нарушение условий настоящего Соглашения наступает ответственность, предусмотренная" +
"законодательством Республики Беларусь." +
"\n4.2.Лицензиар не несет ответственности перед Пользователем за любой ущерб, любую потерю" +
"прибыли, информации или сбережений, связанных с использованием или с невозможностью" +
"использования ПО, даже в случае предварительного уведомления со стороны Пользователя о" +
"возможности такого ущерба, или по любому иску третьей стороны." +
"\n5.Ограниченная гарантия" +
"\n5.1.Лицензиар предоставляет Пользователю право получения Технической поддержки" +
"консультирования Пользователя по вопросам, связанным с функциональностью ПО, материалы по" +
"особенностям установки и эксплуатации на стандартных конфигурациях, поддерживаемых" +
"(популярных) операционных, почтовых и иных систем на условиях и в течение всего срока действия" +
"настоящего Соглашения, а также в соответствии с действующим законодательством Республики" +
"Беларусь без выплаты дополнительного вознаграждения." +
"\n5.2.Все обновления ПО являются ее неотъемлемой частью и используются исключительно вместе" +
"с ПО как единая программа для ЭВМ в порядке, предусмотренном в настоящем Соглашении, если" +
"иные условия использования таких обновлений не будут предусмотрены в отдельном лицензионном" +
"договоре." +
"\n5.3.Если при использовании ПО будут обнаружены ошибки, Лицензиар обязуется исправить их в" +
"максимально короткие сроки и выпустить новую, исправленную версию ПО. Стороны соглашаются," +
"что точное определение срока устранения ошибки не может быть установлено, так как ПО тесно" +
"взаимодействует с другими программами для ЭВМ сторонних разработчиков, операционной" +
"системой и аппаратными ресурсами компьютера Пользователя, и работоспособность и время" +
"устранения проблем в полной мере не зависят только от Лицензиара." +
"\n5.4.В случае несоблюдения любого из пунктов раздела 3 настоящего Соглашения, Пользователь" +
"автоматически теряет право на получение обновлений(новых версий) ПО." +
"\n6.Действие, изменение и расторжение соглашения" +
"\n6.1.Настоящее Соглашение заключено и подлежит толкованию в соответствии с законодательством" +
"Республики Беларусь." +
"\n6.2.В случае нарушения Пользователем условий настоящего Соглашения по использованию ПО" +
"Лицензиар имеет право в одностороннем порядке расторгнуть настоящее Соглашение, уведомив" +
"об этом Пользователя." +
"\n6.3.При расторжении настоящего Соглашения Пользователь обязан прекратить использование ПО" +
"полностью и уничтожить все копии ПО, установленные на своем ЭВМ, включая" +
"резервные копии и все компоненты ПО." +
"\n6.4.Пользователь вправе расторгнуть настоящее Соглашение в любое время, полностью удалив " +
"ПО." +
"\n6.5.В случае если компетентный суд признает какие-либо положения настоящего Соглашения" +
"недействительными, Соглашение продолжает действовать в остальной части." +
"\n6.6.Настоящее Соглашение также распространяется на все обновления(новые версии) ПО," +
"предоставляемые Пользователю в течение срока его действия, если только при обновлении ПО" +
"Пользователю не будет предложено ознакомиться и принять отдельный лицензионный договор или" +
"дополнения к настоящему Соглашению." +
"\n7.Контактная информация Лицензиара:" +
"\nЧастное предприятие «Technical camera © Copyright»" +
"\nkorotkevichov @gmail.com ";
            #endregion лицензия 

            string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(registryKey))
            {
                var query = from a in key.GetSubKeyNames()
                            let r = key.OpenSubKey(a)
                            select new
                            {
                                Application = r.GetValue("DisplayName"),
                                InstallLocation = r.GetValue("InstallLocation")
                            };
                foreach (var item in query)
                {
                    if (item.Application != null)
                    {

                        if (item.Application.ToString() == "Dahmira soft")
                        {
                            MessageBox.Show("Здравствуйте.\n У вас уже установлена программа!\n Установка поверх этой может вызвать ошибки.\nРекомендуем удалить текущую версию, через установку и удаления программ.", "Замечание", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    }
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {

            groupBox2.Location = new Point(91,-6);
            label2.Visible = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox3.Location = new Point(91, -6);
            label3.Visible = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            groupBox4.Location = new Point(91, -6);
            label4.Visible = true;
            Download();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            myThread.Abort();


            string dirName = System.IO.Path.GetTempPath() + "dahmira";

            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            if (dirInfo.Exists)
            {
                dirInfo.Delete(true);
            }


            Close();

        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int высота_текста = label_lez.Size.Height;          
            int высота_окна = groupBox6.Size.Height;      
            int p = ((label_lez.Size.Height - groupBox6.Size.Height) / vScrollBar1.Maximum);
            int d = 0-(vScrollBar1.Value * p);
            label_lez.Location = new Point(label_lez.Location.X,d);
            if (vScrollBar1.Value> vScrollBar1.Maximum-15) { checkBox1.Enabled = true; }         
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
  
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = Environment.Is64BitProcess ? Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) : Environment.GetEnvironmentVariable("ProgramW6432");
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                label6.Text= folderBrowserDialog1.SelectedPath+ "\\Dahmira_soft";
                //  textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }


        Thread myThread = null;
        void Download()
        {
            // Создаем объект FtpWebRequest
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri("ftp://31.177.95.187/setup_auto"));
            request.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
            request.Method = WebRequestMethods.Ftp.GetDateTimestamp;
            // получаем ответ от сервера в виде объекта FtpWebResponse
            FtpWebResponse response = null;
            try { response = (FtpWebResponse)request.GetResponse(); }
            catch
            {
                MessageBox.Show("Нет соединения с интернетом!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Close();
                return; //нет соединения
            }
            // создаем новый поток
            myThread = new Thread(potok);
            // запускаем поток myThread
            myThread.Start();

        }

        void potok()
        {

            string dirName = System.IO.Path.GetTempPath() + "dahmira";

            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            if (dirInfo.Exists)
            {
                dirInfo.Delete(true);             
            }



            string path = System.IO.Path.GetTempPath();
            string subpath = @"dahmira";
            DirectoryInfo dirInfo1 = new DirectoryInfo(path);
            if (!dirInfo1.Exists)
            {
                dirInfo1.Create();
            }
            dirInfo1.CreateSubdirectory(subpath);



            //путь к темп
            string temp_p = System.IO.Path.GetTempPath()+ "dahmira\\setup_auto";
            int size_f;
            FtpWebRequest request3 = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://31.177.95.187/setup_auto"));
            request3.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
            request3.Method = WebRequestMethods.Ftp.GetFileSize;
            FtpWebResponse response3 = (FtpWebResponse)request3.GetResponse();
            size_f = Convert.ToInt32(response3.ContentLength);
            response3.Close();

            FtpWebRequest request2 = (FtpWebRequest)WebRequest.Create(new Uri("ftp://31.177.95.187/setup_auto"));
            request2.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
            request2.Method = WebRequestMethods.Ftp.DownloadFile;
            FtpWebResponse response2 = (FtpWebResponse)request2.GetResponse();
            // получаем поток ответа
            Stream responseStream = response2.GetResponseStream();
            // сохраняем файл в дисковой системе
            // создаем поток для сохранения файла
            FileStream fs = new FileStream(temp_p, FileMode.Create);
            //Буфер для считываемых данных
            int ling = 1024;
            byte[] buffer = new byte[ling];
            int size = 0;
            int obi = 0;
            try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Minimum = 0; }); } catch { }
            try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Maximum = size_f; }); } catch { } 
            while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fs.Write(buffer, 0, size);
                obi = obi + ling;
                try{label_bite.Invoke((MethodInvoker)delegate {label_bite.Text = obi.ToString() + "/" + size_f.ToString(); }); } catch { }
                if (progressBar1.Maximum > obi)
                {                     
                    try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value = obi; }); } catch { }
                }
            }

            fs.Close();
            response2.Close();


            //создать файл с путём куда ставить



            //скачали. Теперь надо распоковать файлы для продолжении установки
            File.WriteAllBytes( System.IO.Path.GetTempPath()+ "dahmira\\DotNetZip.dll", Properties.Resources.DotNetZip);
            File.WriteAllBytes(System.IO.Path.GetTempPath() + "dahmira\\DotNetZip.pdb", Properties.Resources.DotNetZip1);
            File.WriteAllText(System.IO.Path.GetTempPath() + "dahmira\\DotNetZip.xml", Properties.Resources.DotNetZip2);
           
                     // перенести путь к сохранению программы
            using (StreamWriter writer = new StreamWriter(System.IO.Path.GetTempPath() + "dahmira\\put.dll", false))
            {
                writer.WriteLineAsync(label6.Text);
                
            }  
            
            
            //+файл exeшника перенести 
            File.WriteAllBytes(System.IO.Path.GetTempPath() + "dahmira\\Setup.exe", Properties.Resources.Setup);         
              ok = true; 
        }
        bool ok = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            

            if (ok == true)
            {
                //запустить продолжение и выйти.
                timer2.Enabled = true;
               timer1.Enabled = false;
              

            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {


        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (ok == true)
            {   //запустить продолжение и выйти.
                ProcessStartInfo processStartInfo = new ProcessStartInfo(Path.GetTempPath() + "dahmira\\Setup.exe");
                processStartInfo.UseShellExecute = true;
                processStartInfo.Verb = "runas";
                // Запуск нового процесса нашего приложения
                try
                {
                    Process.Start(processStartInfo);

                }
                catch
                {

                }
            }
            Close();
        }

       
    }
}
