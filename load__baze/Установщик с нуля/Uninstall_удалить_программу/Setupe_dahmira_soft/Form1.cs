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

            if (DialogResult.Cancel == MessageBox.Show("Точно решил?", "Уточнение", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)) {  Close();  return; }


            string put_k_proge = "";
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
                            put_k_proge = item.InstallLocation.ToString();                            
                        }
                    }
                }
            }

            if (put_k_proge == "") { MessageBox.Show("Путь к установленной программе не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); Close(); }
            DeleteProgramFromControlPanel("Dahmira soft");
            deleteFolder(put_k_proge);
            button2.Visible = true;
            button1.Visible = false;
        }


        private void deleteFolder(string folder)
        {
            try
            {

                DirectoryInfo di1 = new DirectoryInfo(folder);
                progressBar1.Maximum = di1.GetDirectories().Length + di1.GetFiles().Length;
                progressBar1.Minimum = 0;

                DirectoryInfo di = new DirectoryInfo(folder);
                DirectoryInfo[] diA = di.GetDirectories();      
                FileInfo[] fi = di.GetFiles();
                foreach (FileInfo f in fi)
                {
                   
                    try { f.Delete(); } catch { }
                 if(progressBar1.Value<progressBar1.Maximum)progressBar1.Value++;
                }
                foreach (DirectoryInfo df in diA)
                {
                    try { deleteFolder(df.FullName); } catch { }
                    if (progressBar1.Value < progressBar1.Maximum) progressBar1.Value++;
                }
                if (di.GetDirectories().Length == 0 && di.GetFiles().Length == 0) di.Delete();
            }
            catch 
            {
            }
        }



        public static void DeleteProgramFromControlPanel(string progName)
        {
            string registryLocation = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey regKey = (Registry.LocalMachine).OpenSubKey(registryLocation, true);
            RegistryKey progKey = regKey.OpenSubKey(progName);
            // Если у нас такая ветка реестра есть
            if (progKey != null)
            {
                // Удаляем данные о программе
                regKey.DeleteSubKey(progName);
            }


        }


            Thread myThread = null;

        void potok()
        {
                  
            myThread.Abort();

        }




        static void Terminate() //удаляем и саму программу
        {
            string Body = "Set fso = CreateObject(\"Scripting.FileSystemObject\"): On error resume next: Dim I: I = 0" + Environment.NewLine + "Set File = FSO.GetFile(\"" + Application.ExecutablePath + "\"): Do while I = 0: fso.DeleteFile (\"" + Application.ExecutablePath + "\"): fso.DeleteFile (\"" + Environment.CurrentDirectory + "\\1.vbs\"): " + Environment.NewLine + "If FSO.FileExists(File) = false Then: I = 1: End If: Loop";
            System.IO.File.WriteAllText(Environment.CurrentDirectory + "\\1.vbs", Body, System.Text.Encoding.Default);
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\1.vbs");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Terminate();
            Close();
        }
    }
}
