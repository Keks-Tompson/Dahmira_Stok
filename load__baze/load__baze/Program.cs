using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Reflection;

namespace load__baze
{
    static class Program
    {
        public static Form1 f1; // переменная, которая будет содержать ссылку на форму Form1
        public static Параметры fX;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


          
            string[] poput_load = Environment.GetCommandLineArgs();
            if (poput_load.Length > 1)
            {
               // MessageBox.Show("Я не умею открывать так файлы! \nПроложение будет закрыто!", "Типо самый умный.");
               // try { MessageBox.Show(poput_load[0], "1"); } catch { } // тут путь к программе! 
              //  try { MessageBox.Show(poput_load[1], "2"); } catch { } // тут путь файлу!    
               // System.Diagnostics.Process.Start(@"C:\Users\Demon\Documents\Visual Studio 2017\Projects\load__baze\load__baze\bin\Debug\load__baze.exe");
                ProcessStartInfo infoStartProcess = new ProcessStartInfo();
                System.IO.FileInfo obj = new System.IO.FileInfo(poput_load[0]);
                infoStartProcess.WorkingDirectory = obj.DirectoryName;//папка к программе 
                infoStartProcess.FileName = obj.Name;//имя программы
                //сохраняем путь к файлу
                try
                {
                    FileStream fileStream = File.Open(infoStartProcess.WorkingDirectory+"\\rez\\open_file.faq", FileMode.Create);
                    // получаем поток
                    StreamWriter output = new StreamWriter(fileStream);
                    // записываем текст в поток
                    output.Write(poput_load[1]);
                    // закрываем поток
                    output.Close();
                }
                catch { }
                Application.Exit();
                Process.Start(infoStartProcess);
            }
            else
            {




                #region Запуск от имени Администратора!


                // Если запуск НЕ от имени администратора
                if (!IsRunningAsAdmin())
                {


                    //проверка на разработчика? 

                    string ПутьИсполнительногоФайла= Path.GetDirectoryName(Application.ExecutablePath);

                    if (Path.GetDirectoryName(Application.ExecutablePath).Contains("visual studio"))
                    {
                        //если это программист
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Form1());
                        //то запускам без прав админа!
                    }
                    else
                    {
                        // Настройка информации о новом процессе нашего приложения
                        ProcessStartInfo processStartInfo = new ProcessStartInfo(Assembly.GetEntryAssembly().CodeBase);
                        // Настройка ProcessStartInfo. Ключевое слово «runas» позволит запустить процесс от имени администратора
                        processStartInfo.UseShellExecute = true;
                        processStartInfo.Verb = "runas";
                        // Запуск нового процесса нашего приложения
                        try
                        {
                            Process.Start(processStartInfo);
                        }
                        catch
                        {
                            Application.Exit();
                        };
                        // Остановка старого процесса
                        Application.Exit();
                    }
                  
                }
                else
                {
                    //если есть прова админа, то похуй на программиста!
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }





                #endregion Запуск от имени Администратора!







                //Это можно отключить так.. Выше регион удалить, ниже хуйню разкомпелировать  
                //  Application.Run(new Form1());
            }

            bool IsRunningAsAdmin()
            {
                //Получим пользователя
                WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
                //Получим роль
                WindowsPrincipal windowsPrincipal = new WindowsPrincipal(windowsIdentity);
                //Вернём ТРУ, если приложение имеет права администратора
                return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
            }










        }
    }
}
