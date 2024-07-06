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


namespace copiride
{
    public partial class Form1 : Form
    {
        public string AppDirectory { get; private set; } = AppDomain.CurrentDomain.BaseDirectory;
        public string FileName { get; private set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void BgwCopyFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            //  MessageBox.Show("Copy completed");
            tim_Этапы.Enabled = true;
        }

        private void BgwCopyFile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var value = e.ProgressPercentage;
            progressBar1.Value = value;
        }
        BackgroundWorker bgwCopyFile = new BackgroundWorker();
        private void Form1_Load(object sender, EventArgs e)
        {







            label1.Text = "Привет!";
            bgwCopyFile.WorkerReportsProgress = true;
            bgwCopyFile.ProgressChanged += BgwCopyFile_ProgressChanged;
            bgwCopyFile.RunWorkerCompleted += BgwCopyFile_RunWorkerCompleted;
            bgwCopyFile.DoWork += BgwCopyFile_DoWork;

            //получаем путь куда копировать.
            // открываем файл
            put_k_baza = Environment.CurrentDirectory;
            put_k_file = put_k_baza.Substring(0, put_k_baza.Length - 8);


                  label1.Text = "Читаю данные";
            using (StreamReader stream = new StreamReader(put_k_file + "dir.ini"))
            {
                while (stream.Peek() >= 0)
                {
                    // читаем строку из файла
                    name_dir = stream.ReadLine();
                }
                stream.Close();
            }

            using (StreamReader stream = new StreamReader(put_k_file + "name.ini"))
            {
                while (stream.Peek() >= 0)
                {
                    // читаем строку из файла
                    name_name = stream.ReadLine();
                }
                stream.Close();
            }


            //
            // чистим хвост прайса
            label1.Text = "Чистим хвосты";
            DirectoryInfo dirInfo = new DirectoryInfo(put_k_file+ "\\шаблоны");
            name_шаблоны = new string[Directory.GetFiles(put_k_file + "\\шаблоны").Length];
            int i = 0;

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                name_шаблоны[i] = put_k_file + "шаблоны\\" + file.Name;
                i++;
            }

            label1.Text = "Создаю папки шаблоны";
            // создаем папку
            string subpath = @"шаблоны";
            DirectoryInfo dirInfo11 = new DirectoryInfo(name_dir);
            if (!dirInfo11.Exists)
            {
                dirInfo11.Create();
            }
            dirInfo11.CreateSubdirectory(subpath);
            // переименуем файлы
            label1.Text = "Переименовываю файлы...";
            try { System.IO.File.Move(put_k_file + "prg_download\\1.mdf", put_k_file + "prg_download\\" + name_name + ".mdf"); } catch { }
            try { System.IO.File.Move(put_k_file + "prg_download\\1_log.ldf", put_k_file + "prg_download\\" + name_name + "_log.ldf"); } catch { }
            koll_copi = 2 + i;
            tim_Этапы.Enabled = true;

        }

        //будующее имя и путь к новому прайсу...
        string name_name = "";
        string name_dir = "";
        //имена шаблонов
        string[] name_шаблоны = null;
        //порядок
        int koll_copi = 0;
        //путь к базе
        string put_k_file = null;
        string put_k_baza = null;



    private void BgwCopyFile_DoWork(object sender, DoWorkEventArgs e)
        {
            var fileName = (string)e.Argument;
            var fsize = new FileInfo(FileName).Length;
            var bytesForPercent = fsize / 100;
            var buffer = new byte[bytesForPercent];

            using (var inputFs = new FileStream(FileName, FileMode.Open, FileAccess.Read))
            using (var outputFs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                int counter = 0;
                while (inputFs.Position < inputFs.Length)
                {
                    var wasRead = inputFs.Read(buffer, 0, (int)bytesForPercent);
                    outputFs.Write(buffer, 0, wasRead);
                    counter++;
                    if (counter <= progressBar1.Maximum)
                        bgwCopyFile.ReportProgress(counter);
                }
            }
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() != DialogResult.OK) return;
            FileName = ofd.FileName;
        }


        private void btnCopyFile_Click(object sender, EventArgs e)
        {
            tim_Этапы.Enabled = false;
            
           
                       //получаем имена файлов для копирование с путем. 
                       if (itape == 1) { FileName = put_k_file + "prg_download\\" + name_name + ".mdf"; }
                       if (itape == 2) { FileName= put_k_file + "prg_download\\" + name_name + "_log.ldf"; }
                       if (itape >  2) { FileName = name_шаблоны[itape - 3]; }
                   
            if (FileName == null) return;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0; 
            var destinationFileName = Path.Combine(name_dir, Path.GetFileName(FileName));   
            if (itape > 2) {destinationFileName = Path.Combine(name_dir+"\\шаблоны", Path.GetFileName(FileName)); }
            label1.Text = "Копирую файл:"+ Path.GetFileName(FileName);
            bgwCopyFile.RunWorkerAsync(destinationFileName);
                   
        }

        int itape = 0;
        private void tim_Этапы_Tick(object sender, EventArgs e)
        {
             itape++;
            if (itape > koll_copi) {
                tim_Этапы.Enabled = false;
                Application.Exit();
            } else { btnCopyFile.PerformClick(); }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
//удаление файлов



// чистим хвост прайса

            



             DirectoryInfo dirInfo = new DirectoryInfo(put_k_file + "\\resource");
          foreach (FileInfo file in dirInfo.GetFiles())
             {
          file.Delete();
}

            //чистим хвост шаблонов
            DirectoryInfo dirInfo1 = new DirectoryInfo(put_k_file + "\\шаблоны");

            foreach (FileInfo file1 in dirInfo1.GetFiles())
            {
              file1.Delete();
               }
             System.IO.File.Delete(put_k_file + "\\name.ini");
             System.IO.File.Delete(put_k_file + "\\dir.ini");
             System.IO.File.Delete(put_k_file + "prg_download\\"+ name_name + ".mdf");
             System.IO.File.Delete(put_k_file + "prg_download\\"+ name_name+ "_log.ldf");               
 
















        }
    }

}
