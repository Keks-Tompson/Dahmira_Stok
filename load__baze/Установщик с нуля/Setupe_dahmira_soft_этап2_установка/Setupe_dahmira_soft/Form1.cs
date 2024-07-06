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
using System.IO.Compression;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Ionic.Zip;
using Microsoft.Win32;
using System.Security.Principal;
using IWshRuntimeLibrary;


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


            myThread = new Thread(potok);
            myThread.Start();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            myThread.Abort();


            //удалим каталог, если он есть     
            DirectoryInfo dirInfo2 = new DirectoryInfo(System.IO.Path.GetTempPath() + "dahmira\\temp_load");
            if (dirInfo2.Exists)
            {
                try { dirInfo2.Delete(true); } catch  {  }
            }

            try { System.IO.File.Delete(System.IO.Path.GetTempPath() + "dahmira\\setup_auto"); } catch { }
            try { System.IO.File.Delete(System.IO.Path.GetTempPath() + "dahmira\\DotNetZip.dll"); } catch { }
            try { System.IO.File.Delete(System.IO.Path.GetTempPath() + "dahmira\\DotNetZip.pdb"); } catch { }
            try { System.IO.File.Delete(System.IO.Path.GetTempPath() + "dahmira\\DotNetZip.xml"); } catch { }
            try { System.IO.File.Delete(System.IO.Path.GetTempPath() + "dahmira\\put.dll"); } catch { }
            Close();

        }

        Thread myThread = null;

        void potok()
        {
          string put_kyda_stavim = "";          

            using (ZipFile zip1 = new ZipFile(System.IO.Path.GetTempPath() + "dahmira\\setup_auto", Encoding.GetEncoding(866))) //+имя_файла
            {
                //распаковка
                try
                {
                    zip1.ExtractAll(Environment.ExpandEnvironmentVariables(System.IO.Path.GetTempPath() + "dahmira\\temp_load"));
                }

                catch { MessageBox.Show("Данные с сайта скачались с ошибками", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
          
  

            //немного рисанём
            try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value = 33; }); } catch { }

        
            //читаем куда будем ставить

                
            using (StreamReader stream = new StreamReader(System.IO.Path.GetTempPath() + "dahmira\\put.dll")) 

            {
                while (stream.Peek() >= 0)
                {                
                    put_kyda_stavim = stream.ReadLine();
                }
                stream.Close();

            }
           


            //запись в реестр!

            string progName = "Dahmira soft";
            string progDir = put_kyda_stavim;
            string progIcon = put_kyda_stavim + "\\rez\\icon.ico";
            string progDeleteString = put_kyda_stavim + "\\Uninstall.exe";
          
            try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value = 95; }); } catch { }
            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(System.IO.Path.GetTempPath() + "dahmira\\temp_load\\load__baze.exe");//                    FileVersionInfo.GetVersionInfo(put_kyda_stavim + "\\" + "load__baze.exe");
            string vers = myFileVersionInfo.FileVersion;
            myFileVersionInfo = null;
            try
            {
                
                AddProgramToControlPanel(progName, progDir, progIcon, progDeleteString, vers);
            }
            catch
            {
               
            }
         
            //немного рисанём
            try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value = 40; }); } catch { }            //немного рисанём

            //удалим каталог, если он есть   
           
            DirectoryInfo dirInfo = new DirectoryInfo(put_kyda_stavim);
            if (dirInfo.Exists)
            {
                try { dirInfo.Delete(true); } catch (Exception e) { MessageBox.Show(e.Message, ""); }
            }

            //создание папки
            Directory.CreateDirectory(put_kyda_stavim);

            //перемещение файлов
            try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value = 60; }); } catch { }
            perebor_updates(System.IO.Path.GetTempPath() + "dahmira\\temp_load", put_kyda_stavim);
            try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value = 80; }); } catch { }
            //удаление tempa
            //удалим каталог, если он есть     
            DirectoryInfo dirInfo2 = new DirectoryInfo(System.IO.Path.GetTempPath() + "dahmira\\temp_load");
            if (dirInfo2.Exists)
            {
                try { dirInfo2.Delete(true); } catch (Exception e) { MessageBox.Show(e.Message, ""); }
            }

            try { System.IO.File.Delete(System.IO.Path.GetTempPath() + "dahmira\\setup_auto"); } catch { }      
            try { System.IO.File.Delete(System.IO.Path.GetTempPath() + "dahmira\\DotNetZip.pdb"); } catch { }
            try { System.IO.File.Delete(System.IO.Path.GetTempPath() + "dahmira\\DotNetZip.xml"); } catch { }         
            try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value = 90; }); } catch { }
            // Меняем дату создания файла.
            DateTime df = DateTime.Now;
            try
            { System.IO.File.SetCreationTime(put_kyda_stavim + "\\" + "load__baze.exe", df); }
            catch { }

            // Меняем дату последней операции записи в файл
            try
            {
                System.IO.File.SetLastWriteTime(put_kyda_stavim + "\\" + "load__baze.exe", df);
            }
            catch { }     
            try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value = 92; }); } catch { }
            //Ярлык на рабочий стол
            
            try
            {
                string deskTop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
                if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Dahmira.lnk"))  //
                {
                    System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Dahmira.lnk"); // Удалить исходный ярлык на рабочем столе
                }
                WshShell shell = new WshShell();

                // Расположение и название сочетания клавиш
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Dahmira.lnk");
                shortcut.TargetPath = put_kyda_stavim + "\\" + "load__baze.exe"; // Целевой файл
                                                                                // Этот атрибут указывает рабочий каталог приложения. Когда пользователь не указывает конкретный каталог, целевое приложение ярлыка будет использовать каталог, указанный этим атрибутом, для загрузки или сохранения файла.
                shortcut.WorkingDirectory = put_kyda_stavim;
                shortcut.WindowStyle = 1; // Состояние окна целевого приложения делится на нормальное, развернутое и свернутое 【1,3,7】
                shortcut.Description = "Прайс Дайхиры"; // Описание
                shortcut.IconLocation = put_kyda_stavim + "\\rez\\icon.ico"; // Значок ярлыка
                shortcut.Arguments = "";
                //shortcut.Hotkey = "CTRL + ALT + F11"; // комбинация клавиш
                shortcut.Save(); // Для успешного создания необходимо вызвать ярлык Save.
            }
            catch
            {

            }            
            try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value = 100; }); } catch { }
            try { button2.Invoke((MethodInvoker)delegate { button2.Visible=true; }); } catch { }
            try { button1.Invoke((MethodInvoker)delegate { button1.Visible = false; }); } catch { }
            try { label8.Invoke((MethodInvoker)delegate { label8.Text = "Установка завершена"; }); } catch { }

            try { pictureBox1.Invoke((MethodInvoker)delegate { pictureBox1.Visible=true; }); } catch { }
            try { pictureBox2.Invoke((MethodInvoker)delegate { pictureBox2.Visible = true; }); } catch { }
            try { pictureBox3.Invoke((MethodInvoker)delegate { pictureBox3.Visible = true; }); } catch { }

            myThread.Abort();

        }




        //заносим данные в реестр! 
        public static void AddProgramToControlPanel(string progName, string progDir, string progIcon, string progDeleteString, string vers)
        {
            try
            {
                // Определяем ветку реестра, в которую будем вносить изменения
                string registryLocation = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";
                // Открываем указанный подраздел в разделе реестра HKEY_LOCAL_MACHINE для записи
                RegistryKey regKey = (Registry.LocalMachine).OpenSubKey(registryLocation, true);
                // Создаём новый вложенный раздел с информацией по нашей программе
                RegistryKey progKey = regKey.CreateSubKey(progName);
                // Отображаемое имя
                progKey.SetValue("DisplayName", progName, RegistryValueKind.String);
                // Папка с файлами
                progKey.SetValue("InstallLocation", progDir, RegistryValueKind.ExpandString);
                // Иконка
                progKey.SetValue("DisplayIcon", progIcon, RegistryValueKind.String);
                // Строка удаления
                progKey.SetValue("UninstallString", progDeleteString, RegistryValueKind.ExpandString);
                // Отображаемая версия
                progKey.SetValue("DisplayVersion", vers, RegistryValueKind.String);
                // Издатель
                progKey.SetValue("Publisher", "Microsoft", RegistryValueKind.String);              
            }
            catch 
            {              
            }
        }

        //удаление папок! 
        //begin_dir - директория источник.
        //end_dir - директория приёмник.
        void perebor_updates(string begin_dir, string end_dir)
        {
            //Берём нашу исходную папку
            DirectoryInfo dir_inf = new DirectoryInfo(begin_dir);
            //Перебираем все внутренние папки
            foreach (DirectoryInfo dir in dir_inf.GetDirectories())
            {
                //Проверяем - если директории не существует, то создаём;
                if (Directory.Exists(end_dir + "\\" + dir.Name) != true)
                {
                    Directory.CreateDirectory(end_dir + "\\" + dir.Name);
                }
                //Рекурсия (перебираем вложенные папки и делаем для них то-же самое).
                perebor_updates(dir.FullName, end_dir + "\\" + dir.Name);
            }

            //Перебираем файлики в папке источнике.
            foreach (string file in Directory.GetFiles(begin_dir))
            {
                //Определяем (отделяем) имя файла с расширением - без пути (но с слешем "\").
                string filik = file.Substring(file.LastIndexOf('\\'), file.Length - file.LastIndexOf('\\'));
                //Копируем файлик с перезаписью из источника в приёмник.
                System.IO.File.Copy(file, end_dir + "\\" + filik, true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DirectoryInfo dirInfo2 = new DirectoryInfo(System.IO.Path.GetTempPath() + "dahmira\\temp_load");
            if (dirInfo2.Exists)
            {
                try { dirInfo2.Delete(true); } catch { }
            }

            try { System.IO.File.Delete(System.IO.Path.GetTempPath() + "dahmira\\setup_auto"); } catch { }
            try { System.IO.File.Delete(System.IO.Path.GetTempPath() + "dahmira\\DotNetZip.dll"); } catch { }
            try { System.IO.File.Delete(System.IO.Path.GetTempPath() + "dahmira\\DotNetZip.pdb"); } catch { }
            try { System.IO.File.Delete(System.IO.Path.GetTempPath() + "dahmira\\DotNetZip.xml"); } catch { }
            try { System.IO.File.Delete(System.IO.Path.GetTempPath() + "dahmira\\put.dll"); } catch { }
   
            Close();


          
        }
    }
}
