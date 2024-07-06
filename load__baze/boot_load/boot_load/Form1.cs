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
using System.IO.Compression;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Ionic.Zip;
using System.Net;
using System.Threading;

namespace boot_load
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }    
        string файл_исходник="";
        string имя_файла="";
        BackgroundWorker bgwCopyFile = new BackgroundWorker();
        private void Form1_Load(object sender, EventArgs e)
        {                              
            DateTime new_soft=new DateTime();
            DateTime tec_soft=new DateTime();

            // Создаем объект FtpWebRequest
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri("ftp://31.177.95.187/setup_auto"));
            request.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
            request.Method = WebRequestMethods.Ftp.GetDateTimestamp;
            // получаем ответ от сервера в виде объекта FtpWebResponse
            FtpWebResponse response = null;
            try { response = (FtpWebResponse)request.GetResponse(); }
            catch
            {
                
                Close();
                return; //нет соединения
            }                      

            new_soft = new DateTime(response.LastModified.Year, response.LastModified.Month, response.LastModified.Day, response.LastModified.Hour, response.LastModified.Minute, response.LastModified.Second); // год - месяц - день - час - минута - секунда
            response.Close();

            if (new_soft.Date.ToString() != "01.01.0001 0:00:00")
                    {
                        //Всё новый файл есть. У него есть имя и дата. Проверяем нашу версию. 
                        string[] files2 = Directory.GetFiles(Environment.CurrentDirectory);
                        foreach (string n in files2)
                        {
                            Console.WriteLine(n);
                            string exe = n.Substring(n.Length - 3);
                           
                            if (exe == "exe")
                            {

                                FileInfo fileInfo2 = new FileInfo(n);
                                if (fileInfo2.Name !="boot_load.exe")
                                {
                                   if (fileInfo2.Exists)
                                   {
                                        FileVersionInfo.GetVersionInfo(n);
                                        FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(n);
                                        tec_soft = fileInfo2.LastWriteTime;
                                        
                                   }
                                }                 
                            }
                        }
                    }
                    if (tec_soft < new_soft) //Если текущий софт древнее нового то надо что то делать. 
                    {
                // создаем новый поток
                myThread = new Thread(Print);
                // запускаем поток myThread
                myThread.Start();
            }
            else
                    {
                     Close();
                    }
        }

        Thread myThread = null;


        void Print()
        {
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
            FileStream fs = new FileStream("setup_auto", FileMode.Create);
            //Буфер для считываемых данных
            int ling = 1024;
            byte[] buffer = new byte[ling];
            int size = 0;
            int obi = 0;
            try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Minimum = 0; }); } catch { }
            try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Maximum = size_f; }); } catch { }
            progressBar1.Maximum = size_f;
            while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fs.Write(buffer, 0, size);
                obi = obi + ling;
                if (progressBar1.Maximum > obi)
                {
                    try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value = obi; }); } catch { }
                }
            }

            fs.Close();
            response2.Close();
            kl = true;
            myThread.Abort(); 
        }
        bool kl = false;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (kl == true)
            {
                timer1.Enabled = true;
                timer2.Enabled = false;
            }            
        }
        int этапы = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {

            progressBar1.Maximum = 100;
            button1.Enabled = false;
            switch (этапы)
            {  
                case 0:
                    //закончилось ли копирование
                    if (label1.Text != "Установка:")
                    {
                        try
                        {
                            const string filePatch = "setup_auto";
                            try
                            {
                                using (var fs = File.Open(filePatch, FileMode.Open, FileAccess.Read, FileShare.None))
                                {
                                    label1.Text = "Установка:";
                                    progressBar1.Value = 0;
                                }
                            }
                            catch{ MessageBox.Show("Всё пошло не по плану. Звони моему Автору. Код 02"); }
                        }
                        catch
                        { MessageBox.Show("Всё пошло не по плану. Звони моему Автору. Код 15"); }
                    }
                    else
                    {
                        этапы = 1;
                        progressBar1.Value = 20;
                    }
                    break;
                case 1:
                    timer1.Enabled = false;
                    using (ZipFile zip1 = new ZipFile(Environment.CurrentDirectory + "\\setup_auto", Encoding.GetEncoding(866))) //+имя_файла
                    {
                        try { progressBar1.Value = 33; zip1.ExtractAll(Environment.ExpandEnvironmentVariables(Environment.CurrentDirectory + "\\temp_load")); }
                        catch { }
                        этапы = 2;
                    }
                    progressBar1.Value = 33;
                    timer1.Enabled = true;
                    break;
                case 2:
                    //удаление текущего 
                    timer1.Enabled = false;
                    DirectoryInfo dirInfo =new DirectoryInfo(Environment.CurrentDirectory);
                    //удаление файлов
                    foreach (FileInfo file in dirInfo.GetFiles())
                    {
                        if (file.Name == "boot_load.exe" ||
                            file.Name == "boot_load.pdb" ||
                            file.Name == "load__baze.exe.config" ||                           
                            file.Name == "theme.dll"||
                            file.Name == ""
                            ) { }else {
                            try { file.Delete(); } catch { }
                        }
                    }
                    progressBar1.Value = 40;
                    //удаление папок
                    foreach (DirectoryInfo direct in dirInfo.GetDirectories())
                    {
                        if (direct.Name != "temp_load")                         
                        {
                            try { Directory.Delete(direct.Name, true); } catch { }
                        }
                    }
                    progressBar1.Value = 45;
                    этапы = 3;
                    timer1.Enabled = true;
                    break;
                case 3:
                    timer1.Enabled = false;
                    //копирование,
                    //MessageBox.Show("Ок");
                    DirectoryInfo dirInfo1 = new DirectoryInfo(Environment.CurrentDirectory+ "\\temp_load");
                    foreach (FileInfo file in dirInfo1.GetFiles())
                    {                        
                    string newPath = Environment.CurrentDirectory;
                    FileInfo fileInf = new FileInfo(file.DirectoryName + "\\" + file.Name);
                        if (progressBar1.Value < 98) { progressBar1.Value++;}
                        if (file.Name == "boot_load.exe" || file.Name == "boot_load.pdb" || file.Name == "DotNetZip.dll"|| file.Name == "load__baze.exe.config"|| file.Name == "theme.dll") //нельзя копировать с temp_load
                        { }else
                        {
                            if (fileInf.Exists)
                            {
                                File.Move(file.DirectoryName + "\\" + file.Name, newPath + "\\" + file.Name);
                                // альтернатива с помощью класса File
                                // File.Move(path, newPath);
                            }
                        }
                    }
                    foreach (DirectoryInfo direct2 in dirInfo1.GetDirectories())
                    {
                        if (progressBar1.Value < 100) { progressBar1.Value++; }
                        if (direct2.Exists && !Directory.Exists(Environment.CurrentDirectory+"\\"+ direct2.Name))
                        {
                            direct2.MoveTo(Environment.CurrentDirectory+ "\\" + direct2.Name);
                        }
                    }
                    этапы = 4;
                    progressBar1.Value = 100;
                    timer1.Enabled = true;
                    label1.Text = "Обновились :)";
                    break;
                case 4:

                    exete = true;
                    Close();
                    break;
             }

        }
        bool exete = false;
        private void button1_Click(object sender, EventArgs e)
        {
            myThread.Abort();
            Close();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {          
            if (exete == true)
            {
                // Меняем дату создания файла.
                DateTime df = DateTime.Now;
                try
                { System.IO.File.SetCreationTime(Environment.CurrentDirectory + "\\" + "load__baze.exe", df); }
                catch { }

                // Меняем дату последней операции записи в файл
                try
                    { System.IO.File.SetLastWriteTime(Environment.CurrentDirectory + "\\" + "load__baze.exe", df);
                    }
                    catch { }
                    try {  Process.Start(Environment.CurrentDirectory + "\\" + "load__baze.exe");}catch{}
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing&& button1.Enabled==false && exete==false)
            {
                e.Cancel = true;
            }
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;
            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

       
    }
}
