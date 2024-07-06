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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace load__baze
{
    public partial class окно_настроек_взять_цену : Form
    {
        public окно_настроек_взять_цену()
        {
            InitializeComponent();
        }

        private void окно_настроек_взять_цену_Load(object sender, EventArgs e)
        {
            string[] f = new string[8];
            int x = 0;
            using (StreamReader stream = new StreamReader("rez\\setting_ctrlv.txt"))
            {
                while (stream.Peek() >= 0)
                {
                    f[x] = stream.ReadLine();
                    x++;
                }
                stream.Close();
            }


            try{numericUpDown1.Value = Convert.ToInt16(f[0]);} catch { }
            try { numericUpDown2.Value = Convert.ToInt16(f[1]); } catch { }
            try { numericUpDown3.Value = Convert.ToInt16(f[2]); } catch { }
            try { numericUpDown4.Value = Convert.ToInt16(f[3])+1; } catch { }
            try { if (f[4] == "True") checkBox1.Checked=true; } catch { }
            try { if (f[5] == "True") checkBox8.Checked = true; } catch { }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("rez\\setting_ctrlv.txt", false, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine(numericUpDown1.Value);
                    sw.WriteLine(numericUpDown2.Value);
                    sw.WriteLine(numericUpDown3.Value);
                    sw.WriteLine(numericUpDown4.Value-1);
                    sw.WriteLine(checkBox1.Checked);
                    sw.WriteLine(checkBox8.Checked);


                }
                label1.Text = "Сохранено!";
                label_consol.Text = "Удачно сохранено!";
            }
            catch
            {
                label1.Text = "Не получилось!";
                label_consol.Text = "Ошибка сохрание настройки";
            }
        }




        private void окно_настроек_взять_цену_Deactivate(object sender, EventArgs e)
        {
        
        }

        private void окно_настроек_взять_цену_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.f1.Rgt = false;
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
              if (pictureBox1.Visible == false) { pictureBox1.Visible = true; this.MaximumSize = new Size(1017,294);  this.Size = new Size(1017,294); button2.BackColor = Color.LightGreen; }
           
                                           else { pictureBox1.Visible = false; this.MaximumSize = new Size(322,294);  this.Size = new Size(322,294); button2.BackColor = Color.Empty; }
        }

        bool один_раз = false;
        private void button3_Click(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(1017, 294); this.Size = new Size(1017, 294);

            dataGridView1.Rows.Clear();



            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Старый добрый Excel(.xlsx)|*.xlsx"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {

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











                for (rCnt = 1 + Convert.ToInt16(numericUpDown4.Value)-1; rCnt <= rw; rCnt++)
                {
                    // 1- артикул. 2- наименование 3-цена 4- начальная строка, типо флаг, что записано

                    dataGridView1.Rows.Add();
                    for (cCnt = 1; cCnt <= cl; cCnt++)
                    {
                        try
                        {
                            try { str = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value.ToString(); } catch { str = null; }
                            if (cCnt == Convert.ToInt16(numericUpDown1.Value))
                            {
                                dataGridView1.Rows[rCnt- Convert.ToInt16(numericUpDown4.Value)].Cells[0].Value = str;
                            } //артикул

                            if (cCnt == Convert.ToInt16(numericUpDown3.Value))
                            {//наименовние                                   
                                dataGridView1.Rows[rCnt - Convert.ToInt16(numericUpDown4.Value)].Cells[1].Value = str;
                            }

                            if (cCnt == Convert.ToInt16(numericUpDown2.Value))//цена
                            {

                                string new_ctena = str.Replace(".", ",");
                                decimal newDecimal;
                                bool isDecimal = Decimal.TryParse(new_ctena, out newDecimal);
                                if (isDecimal == false || newDecimal.ToString("#######0.0000") == "0.0000") { dataGridView1.Rows[rCnt - 1 - (Convert.ToInt16(numericUpDown4.Value)-1)].Cells[2].Value = "в столбце не цифра!"; }
                                else
                                {
                                    if (newDecimal < 1)
                                    { dataGridView1.Rows[rCnt - 1 - (Convert.ToInt16(numericUpDown4.Value)-1)].Cells[2].Value = newDecimal.ToString("#######0.0000"); }
                                    else
                                    { dataGridView1.Rows[rCnt - 1 - (Convert.ToInt16(numericUpDown4.Value)-1)].Cells[2].Value = newDecimal.ToString("########.0000"); }
                                }
                                //   if (новые_данные_производителя[rCnt - 1][3] == "0,00")
                                //  { новые_данные_производителя[rCnt - 1][6] += "/n Цена кривая"; }//это пиздец а не цена




                            }
                            label_consol.Text = "Пихаю данные:" + open_dialog.FileName + " строка:" + rCnt + " столбец:" + cCnt + "   Всего строк:" + rw;
                        }
                        catch { }
                    }
                    if (rCnt >= 7+ (Convert.ToInt16(numericUpDown4.Value)-1)) {  dataGridView1.Rows[rCnt  - (Convert.ToInt16(numericUpDown4.Value)-1)].Cells[1].Value = "ну и в таком духе дальше будет..";rCnt = rw + 1; }
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


                string dfdfdfd = open_dialog.SafeFileName;
                label_consol.Text = "Файл:"+ dfdfdfd+" частично прогружен!";

                if ( один_раз == false)
                {if (MessageBox.Show("Открыть файл для проверки?", "Предложение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) { Process.Start(filename); }
                        один_раз = true;  }
                    

            }

            }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "";
        }
    }
}
