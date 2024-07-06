using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Reflection;

namespace boot_load
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
          if (!IsRunningAsAdmin())
            {/*
                //Спросим нужно ли использовать права админа

                DialogResult result = MessageBox.Show(
                    "Запустить программу от имени администратора?",
                    "Запуск от имени администратора",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                  */

                

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

                   /*
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }

*/
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
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
