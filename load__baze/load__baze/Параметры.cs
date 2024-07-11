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
using System.Net;
using Org.BouncyCastle.Asn1.Ocsp;
using iTextSharp.text.pdf.qrcode;
using System.Xml.Linq;
using load__baze.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace load__baze
{
    public partial class Параметры : Form
    {
        private string exhibitionsFilePath = Path.Combine("countries.json");

        private List<NumericUpDown> coefficientsList = new List<NumericUpDown>();
        private List<System.Windows.Forms.TextBox> countryNameList = new List<System.Windows.Forms.TextBox>();
        private List<NumericUpDown> discountList = new List<NumericUpDown>();

        public static bool isValid = false;

        public Параметры()
        {
         Program.fX=this;    
            InitializeComponent();

            coefficientsList.Add(PriceCoef_1);
            coefficientsList.Add(PriceCoef_2);
            coefficientsList.Add(PriceCoef_3);
            coefficientsList.Add(PriceCoef_4);
            coefficientsList.Add(PriceCoef_5);
            coefficientsList.Add(PriceCoef_6);
            coefficientsList.Add(PriceCoef_7);
            coefficientsList.Add(PriceCoef_8);
            coefficientsList.Add(PriceCoef_9);
            coefficientsList.Add(PriceCoef_10);
            coefficientsList.Add(PriceCoef_11);
            coefficientsList.Add(PriceCoef_12);
            coefficientsList.Add(PriceCoef_13);
            coefficientsList.Add(PriceCoef_14);
            coefficientsList.Add(PriceCoef_15);

            countryNameList.Add(NameCoeff_1);
            countryNameList.Add(NameCoeff_2);
            countryNameList.Add(NameCoeff_3);
            countryNameList.Add(NameCoeff_4);
            countryNameList.Add(NameCoeff_5);
            countryNameList.Add(NameCoeff_6);
            countryNameList.Add(NameCoeff_7);
            countryNameList.Add(NameCoeff_8);
            countryNameList.Add(NameCoeff_9);
            countryNameList.Add(NameCoeff_10);
            countryNameList.Add(NameCoeff_11);
            countryNameList.Add(NameCoeff_12);
            countryNameList.Add(NameCoeff_13);
            countryNameList.Add(NameCoeff_14);
            countryNameList.Add(NameCoeff_15);

            discountList.Add(DiscountСoeff_1);
            discountList.Add(DiscountСoeff_2);
            discountList.Add(DiscountСoeff_3);
            discountList.Add(DiscountСoeff_4);
            discountList.Add(DiscountСoeff_5);
            discountList.Add(DiscountСoeff_6);
            discountList.Add(DiscountСoeff_7);
            discountList.Add(DiscountСoeff_8);
            discountList.Add(DiscountСoeff_9);
            discountList.Add(DiscountСoeff_10);
            discountList.Add(DiscountСoeff_11);
            discountList.Add(DiscountСoeff_12);
            discountList.Add(DiscountСoeff_13);
            discountList.Add(DiscountСoeff_14);
            discountList.Add(DiscountСoeff_15);
            #region окно експорт в ексель выподающие цветастики
            //вывод в exsel
            //цвета
            comboBox2.DataSource = typeof(Color).GetProperties()
            .Where(x => x.PropertyType == typeof(Color))
            .Select(x => x.GetValue(null)).ToList();
            comboBox2.MaxDropDownItems = 10;
            comboBox2.IntegralHeight = false;
            comboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DrawItem += comboBox2_DrawItem;

            comboBox3.DataSource = typeof(Color).GetProperties()
            .Where(x => x.PropertyType == typeof(Color))
            .Select(x => x.GetValue(null)).ToList();
            comboBox3.MaxDropDownItems = 10;
            comboBox3.IntegralHeight = false;
            comboBox3.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DrawItem += comboBox3_DrawItem;


            comboBox4.DataSource = typeof(Color).GetProperties()
            .Where(x => x.PropertyType == typeof(Color))
            .Select(x => x.GetValue(null)).ToList();
            comboBox4.MaxDropDownItems = 10;
            comboBox4.IntegralHeight = false;
            comboBox4.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.DrawItem += comboBox4_DrawItem;

            comboBox5.DataSource = typeof(Color).GetProperties()
            .Where(x => x.PropertyType == typeof(Color))
            .Select(x => x.GetValue(null)).ToList();
            comboBox5.MaxDropDownItems = 10;
            comboBox5.IntegralHeight = false;
            comboBox5.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.DrawItem += comboBox5_DrawItem;


            comboBox6.DataSource = typeof(Color).GetProperties()
            .Where(x => x.PropertyType == typeof(Color))
            .Select(x => x.GetValue(null)).ToList();
            comboBox6.MaxDropDownItems = 10;
            comboBox6.IntegralHeight = false;
            comboBox6.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox6.DrawItem += comboBox6_DrawItem;

            comboBox7.DataSource = typeof(Color).GetProperties()
            .Where(x => x.PropertyType == typeof(Color))
            .Select(x => x.GetValue(null)).ToList();
            comboBox7.MaxDropDownItems = 10;
            comboBox7.IntegralHeight = false;
            comboBox7.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox7.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox7.DrawItem += comboBox7_DrawItem;


            #endregion окно експорт в ексель выподающие цветастики

        }
        string[] setting = new string[30];
        string[] setting_excel = new string[15];
        string data0_manageri = "";
        private void Параметры_Load(object sender, EventArgs e)
        {
            //глобальные переменные 
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
            /*
             0- тема программы
             1- звук asq
             2- время интервала таймера опроса аськи
             3- Имя пользователя
             4- Путь рабочей папки Прайса
             5- Время интервала проверки не обновился ли прайс в интернете   .. НЕАКТУАЛЬНО
             6- разрешение на запись и сохранение на сайт
             7- ключ для загрузки на сайт
             8- настройка коэф цены. меняется не в этом окне!

            20 ... 30 пути к сохранению и загрузки 
             */
            if (setting[0] == "" || setting[0] ==null) setting[0] = "0";
            comboBox1.SelectedIndex = Convert.ToInt16(setting[0]);
            

            //аська 
            if (setting[1] == ""|| setting[1] == null) { setting[1] = "0"; }
            comboBox_asq.SelectedIndex = Convert.ToInt16(setting[1]);
            if (setting[2] == "" || setting[2] == null) { setting[2] = "0,8"; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(setting[2], out newDecimal); numericUpDown3.Value = newDecimal; if (isDecimal == false) { numericUpDown3.BackColor = Color.Red; } } catch { numericUpDown3.BackColor = Color.Red; }
            if (setting[3] == "" || setting[3] == null) { textBox_имя_в_аськи.Text = Environment.UserName; } else { textBox_имя_в_аськи.Text = setting[3]; }


            //работа с прайсом с интернета
            if (setting[4] == "" || setting[4] == null) { label31.Text = ""; } else { label31.Text = setting[4]; }

            //Ключ
            if (setting[7] == "" || setting[7] == null) { label_my_key.Text = "Нет ключа";} else {label_my_key.Text = setting[7]; decom_pass(setting[7]); }

            //numericUpDown4

            //вывод в PDF
            int[] color_pdf = new int[9];
            int x = 0;
            using (StreamReader stream = new StreamReader("rez\\Color_PDF.txt"))
            {
                while (stream.Peek() >= 0)
                {
                    color_pdf[x] = Convert.ToInt16(stream.ReadLine());
                    x++;
                }
                stream.Close();
            }
            pictureBox2.BackColor = Color.FromArgb(color_pdf[0], color_pdf[1], color_pdf[2]);
            pictureBox3.BackColor = Color.FromArgb(color_pdf[3], color_pdf[4], color_pdf[5]);
            pictureBox4.BackColor = Color.FromArgb(color_pdf[6], color_pdf[7], color_pdf[8]);


            //вывод в Excel
            int l = 0;
            using (StreamReader stream = new StreamReader("rez\\Color_excel.txt"))
            {
                while (stream.Peek() >= 0)
                {
                    setting_excel[l] = stream.ReadLine();
                    l++;
                }
                stream.Close();
            } 
            
            for (int i = 0; i < comboBox2.Items.Count; i++) { if (comboBox2.Items[i].ToString() == "Color [" + setting_excel[0] + "]") { comboBox2.SelectedIndex = i; } }
            for (int i = 0; i < comboBox3.Items.Count; i++) { if (comboBox3.Items[i].ToString() == "Color [" + setting_excel[1] + "]") { comboBox3.SelectedIndex = i; } }
            for (int i = 0; i < comboBox4.Items.Count; i++) { if (comboBox4.Items[i].ToString() == "Color [" + setting_excel[2] + "]") { comboBox4.SelectedIndex = i; } }
            for (int i = 0; i < comboBox5.Items.Count; i++) { if (comboBox5.Items[i].ToString() == "Color [" + setting_excel[3] + "]") { comboBox5.SelectedIndex = i; } }
            for (int i = 0; i < comboBox6.Items.Count; i++) { if (comboBox6.Items[i].ToString() == "Color [" + setting_excel[4] + "]") { comboBox6.SelectedIndex = i; } }
            for (int i = 0; i < comboBox7.Items.Count; i++) { if (comboBox7.Items[i].ToString() == "Color [" + setting_excel[5] + "]") { comboBox7.SelectedIndex = i; } }
            if (setting_excel[6] == "0") { comboBox8.SelectedIndex = 0; } else { comboBox8.SelectedIndex = 1; }         
            numericUpDown1.Value=Convert.ToDecimal( setting_excel[7]);
            numericUpDown2.Value=Convert.ToDecimal(setting_excel[8]);
            if (setting_excel[9] == "0") { comboBox9.SelectedIndex = 0; } else { comboBox9.SelectedIndex = 1; }
            if (setting_excel[10] == "Итого:") { comboBox10.SelectedIndex = 0; }
            if (setting_excel[10] == "Итого без НДС:") { comboBox10.SelectedIndex = 1; }
            if (setting_excel[10] == "Итого с НДС:") { comboBox10.SelectedIndex = 2; }
            if (setting_excel[10] == "Цена:") { comboBox10.SelectedIndex = 3; }




            //загрузка данных по менеджерам 
            #region загрузка цен манагеров
            
            string[] data = new string[46];
            string str2 = "";
            // открываем файл
            using (StreamReader stream = new StreamReader("settlement.dll"))
            {
                int b = 0;
                while (stream.Peek() >= 0)
                {
                    // читаем строку из файла
                    str2 = stream.ReadLine();
                    try { data[b] = str2; } catch {  }
                    b++;
                }
                stream.Close();
            }

            try { NameCoeff_1.Text = data[1]; } catch { }
            try { NameCoeff_2.Text = data[2]; } catch { }
            try { NameCoeff_3.Text = data[3]; } catch { }
            try { NameCoeff_4.Text = data[4]; } catch { }
            try { NameCoeff_5.Text = data[5]; } catch { }
            try { NameCoeff_6.Text = data[6]; } catch { }
            try { NameCoeff_7.Text = data[7]; } catch { }
            try { NameCoeff_8.Text = data[8]; } catch { }
            try { NameCoeff_9.Text = data[9]; } catch { }
            try { NameCoeff_10.Text = data[10]; } catch { }
            try { NameCoeff_11.Text = data[11]; } catch { }
            try { NameCoeff_12.Text = data[12]; } catch { }
            try { NameCoeff_13.Text = data[13]; } catch { }
            try { NameCoeff_14.Text = data[14]; } catch { }
            try { NameCoeff_15.Text = data[15]; } catch { }

            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[16], out newDecimal); PriceCoef_1.Value = newDecimal; if (isDecimal == false) { PriceCoef_1.BackColor = Color.Red; } } catch { PriceCoef_1.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[17], out newDecimal); PriceCoef_2.Value = newDecimal; if (isDecimal == false) { PriceCoef_2.BackColor = Color.Red; } } catch { PriceCoef_2.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[18], out newDecimal); PriceCoef_3.Value = newDecimal; if (isDecimal == false) { PriceCoef_3.BackColor = Color.Red; } } catch { PriceCoef_3.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[19], out newDecimal); PriceCoef_4.Value = newDecimal; if (isDecimal == false) { PriceCoef_4.BackColor = Color.Red; } } catch { PriceCoef_4.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[20], out newDecimal); PriceCoef_5.Value = newDecimal; if (isDecimal == false) { PriceCoef_5.BackColor = Color.Red; } } catch { PriceCoef_5.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[21], out newDecimal); PriceCoef_6.Value = newDecimal; if (isDecimal == false) { PriceCoef_6.BackColor = Color.Red; } } catch { PriceCoef_6.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[22], out newDecimal); PriceCoef_7.Value = newDecimal; if (isDecimal == false) { PriceCoef_7.BackColor = Color.Red; } } catch { PriceCoef_7.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[23], out newDecimal); PriceCoef_8.Value = newDecimal; if (isDecimal == false) { PriceCoef_8.BackColor = Color.Red; } } catch { PriceCoef_8.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[24], out newDecimal); PriceCoef_9.Value = newDecimal; if (isDecimal == false) { PriceCoef_9.BackColor = Color.Red; } } catch { PriceCoef_9.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[25], out newDecimal); PriceCoef_10.Value = newDecimal; if (isDecimal == false) { PriceCoef_10.BackColor = Color.Red; } } catch { PriceCoef_10.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[26], out newDecimal); PriceCoef_11.Value = newDecimal; if (isDecimal == false) { PriceCoef_11.BackColor = Color.Red; } } catch { PriceCoef_11.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[27], out newDecimal); PriceCoef_12.Value = newDecimal; if (isDecimal == false) { PriceCoef_12.BackColor = Color.Red; } } catch { PriceCoef_12.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[28], out newDecimal); PriceCoef_13.Value = newDecimal; if (isDecimal == false) { PriceCoef_13.BackColor = Color.Red; } } catch { PriceCoef_13.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[29], out newDecimal); PriceCoef_14.Value = newDecimal; if (isDecimal == false) { PriceCoef_14.BackColor = Color.Red; } } catch { PriceCoef_14.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[30], out newDecimal); PriceCoef_15.Value = newDecimal; if (isDecimal == false) { PriceCoef_15.BackColor = Color.Red; } } catch { PriceCoef_15.BackColor = Color.Red; }

            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[31], out newDecimal); DiscountСoeff_1.Value = newDecimal; if (isDecimal == false) { DiscountСoeff_1.BackColor = Color.Red; } } catch { DiscountСoeff_1.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[32], out newDecimal); DiscountСoeff_2.Value = newDecimal; if (isDecimal == false) { DiscountСoeff_2.BackColor = Color.Red; } } catch { DiscountСoeff_2.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[33], out newDecimal); DiscountСoeff_3.Value = newDecimal; if (isDecimal == false) { DiscountСoeff_3.BackColor = Color.Red; } } catch { DiscountСoeff_3.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[34], out newDecimal); DiscountСoeff_4.Value = newDecimal; if (isDecimal == false) { DiscountСoeff_4.BackColor = Color.Red; } } catch { DiscountСoeff_4.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[35], out newDecimal); DiscountСoeff_5.Value = newDecimal; if (isDecimal == false) { DiscountСoeff_5.BackColor = Color.Red; } } catch { DiscountСoeff_5.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[36], out newDecimal); DiscountСoeff_6.Value = newDecimal; if (isDecimal == false) { DiscountСoeff_6.BackColor = Color.Red; } } catch { DiscountСoeff_6.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[37], out newDecimal); DiscountСoeff_7.Value = newDecimal; if (isDecimal == false) { DiscountСoeff_7.BackColor = Color.Red; } } catch { DiscountСoeff_7.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[38], out newDecimal); DiscountСoeff_8.Value = newDecimal; if (isDecimal == false) { DiscountСoeff_8.BackColor = Color.Red; } } catch { DiscountСoeff_8.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[39], out newDecimal); DiscountСoeff_9.Value = newDecimal; if (isDecimal == false) { DiscountСoeff_9.BackColor = Color.Red; } } catch { DiscountСoeff_9.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[40], out newDecimal); DiscountСoeff_10.Value = newDecimal; if (isDecimal == false) { DiscountСoeff_10.BackColor = Color.Red; } } catch { DiscountСoeff_10.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[41], out newDecimal); DiscountСoeff_11.Value = newDecimal; if (isDecimal == false) { DiscountСoeff_11.BackColor = Color.Red; } } catch { DiscountСoeff_11.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[42], out newDecimal); DiscountСoeff_12.Value = newDecimal; if (isDecimal == false) { DiscountСoeff_12.BackColor = Color.Red; } } catch { DiscountСoeff_12.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[43], out newDecimal); DiscountСoeff_13.Value = newDecimal; if (isDecimal == false) { DiscountСoeff_13.BackColor = Color.Red; } } catch { DiscountСoeff_13.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[44], out newDecimal); DiscountСoeff_14.Value = newDecimal; if (isDecimal == false) { DiscountСoeff_14.BackColor = Color.Red; } } catch { DiscountСoeff_14.BackColor = Color.Red; }
            try { decimal newDecimal; bool isDecimal = Decimal.TryParse(data[45], out newDecimal); DiscountСoeff_15.Value = newDecimal; if (isDecimal == false) { DiscountСoeff_15.BackColor = Color.Red; } } catch { DiscountСoeff_15.BackColor = Color.Red; }



            #endregion загрузка цен манагеров

            Size f = Program.f1.Size;
            Point g = Program.f1.Location;
            int W = g.X + (f.Width / 3);
            this.Location = new Point(W, f.Height / 4);
            this.MaximumSize = new Size(573, 462);
            Program.f1.oposity(0.75);



            //дефолтные пути к сохранению 
            label20.Text = setting[20];
            label22.Text = setting[21];
            label26.Text = setting[22];
            label24.Text = setting[23];
        }

        private void Параметры_FormClosing(object sender, FormClosingEventArgs e)
        {

             Program.f1.oposity(1);

            //сохранение глобальных настроек 
           
            using (StreamWriter writer = new StreamWriter("theme.dll", false, System.Text.Encoding.UTF8))
            {
                for (int i = 0; i < 30; i++)
                {
                   writer.WriteLineAsync(setting[i]);
                }
                
           
            }

            //сохранение вывод в pdf 
            try
            {
                using (StreamWriter sw = new StreamWriter("rez\\Color_PDF.txt", false, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine(pictureBox2.BackColor.R);
                    sw.WriteLine(pictureBox2.BackColor.G);
                    sw.WriteLine(pictureBox2.BackColor.B);
                    sw.WriteLine(pictureBox3.BackColor.R);
                    sw.WriteLine(pictureBox3.BackColor.G);
                    sw.WriteLine(pictureBox3.BackColor.B);
                    sw.WriteLine(pictureBox4.BackColor.R);
                    sw.WriteLine(pictureBox4.BackColor.G);
                    sw.WriteLine(pictureBox4.BackColor.B);
                }
            }
            catch
            {
            
            }

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

            Program.f1.get_setting();

            timer1.Stop();

        }

  


#region оформление окна
        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Location = new Point(110,2);
            groupBox2.Location = new Point(1010, 2);
            groupBox3.Location = new Point(1010, 2); 
            groupBox4.Location = new Point(1010, 2); 
            groupBox5.Location = new Point(1010, 2);
            groupBox6.Location = new Point(1010, 2);
            groupBox7.Location = new Point(1010, 2);
            groupBox8.Location = new Point(1010, 2);
            button1.BackColor = Color.Cyan;
            button2.BackColor = Color.Empty;
            button3.BackColor = Color.Empty;
            button4.BackColor = Color.Empty;
            button5.BackColor = Color.Empty;
            button6.BackColor = Color.Empty;
            button7.BackColor = Color.Empty;
            button8.BackColor = Color.Empty;
            button1.Size = new Size(105, button1.Size.Height);
            button2.Size = new Size(94, button2.Size.Height);
            button3.Size = new Size(94, button3.Size.Height);
            button4.Size = new Size(94, button4.Size.Height);
            button5.Size = new Size(94, button5.Size.Height);
            button6.Size = new Size(94, button6.Size.Height);
            button7.Size = new Size(94, button7.Size.Height);
            button8.Size = new Size(94, button8.Size.Height);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Location = new Point(110, 2);
            groupBox1.Location = new Point(1010, 2);
            groupBox3.Location = new Point(1010, 2);
            groupBox4.Location = new Point(1010, 2);
            groupBox5.Location = new Point(1010, 2);
            groupBox6.Location = new Point(1010, 2);
            groupBox7.Location = new Point(1010, 2);
            groupBox8.Location = new Point(1010, 2);
            button1.BackColor = Color.Empty;
            button2.BackColor = Color.Cyan;
            button3.BackColor = Color.Empty;
            button4.BackColor = Color.Empty;
            button5.BackColor = Color.Empty;
            button6.BackColor = Color.Empty;
            button7.BackColor = Color.Empty;
            button8.BackColor = Color.Empty;
            button1.Size = new Size(94, button1.Size.Height);
            button2.Size = new Size(105, button2.Size.Height);
            button3.Size = new Size(94, button3.Size.Height);
            button4.Size = new Size(94, button4.Size.Height);
            button5.Size = new Size(94, button5.Size.Height);
            button6.Size = new Size(94, button6.Size.Height);
            button7.Size = new Size(94, button7.Size.Height);
            button8.Size = new Size(94, button8.Size.Height);

            if(isValid == true)
            {
                for(int i = 0; i < countryNameList.Count; i++)
                {
                    countryNameList[i].Enabled = true;
                    coefficientsList[i].Enabled = true;
                    discountList[i].Enabled = true;
                }
                ChangeCoeff.Visible = true;
                label18.Visible = false;
            }
            else
            {
                for (int i = 0; i < countryNameList.Count; i++)
                {
                    countryNameList[i].Enabled = false;
                    coefficientsList[i].Enabled = false;
                    discountList[i].Enabled = false;
                }
                ChangeCoeff.Visible = false;
                label18.Visible = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox3.Location = new Point(110, 2);
            groupBox1.Location = new Point(1010, 2);
            groupBox2.Location = new Point(1010, 2);
            groupBox4.Location = new Point(1010, 2);
            groupBox5.Location = new Point(1010, 2);
            groupBox6.Location = new Point(1010, 2);
            groupBox7.Location = new Point(1010, 2);
            groupBox8.Location = new Point(1010, 2);
            button1.BackColor = Color.Empty;
            button2.BackColor = Color.Empty;
            button3.BackColor = Color.Cyan;
            button4.BackColor = Color.Empty;
            button5.BackColor = Color.Empty;
            button6.BackColor = Color.Empty;
            button7.BackColor = Color.Empty;
            button8.BackColor = Color.Empty;
            button1.Size = new Size(94, button1.Size.Height);
            button2.Size = new Size(94, button2.Size.Height);
            button3.Size = new Size(105, button3.Size.Height);
            button4.Size = new Size(94, button4.Size.Height);
            button5.Size = new Size(94, button5.Size.Height);
            button6.Size = new Size(94, button6.Size.Height);
            button7.Size = new Size(94, button7.Size.Height);
            button8.Size = new Size(94, button8.Size.Height);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox4.Location = new Point(110, 2);
            groupBox1.Location = new Point(1010, 2);
            groupBox2.Location = new Point(1010, 2);
            groupBox3.Location = new Point(1010, 2);
            groupBox5.Location = new Point(1010, 2);
            groupBox6.Location = new Point(1010, 2);
            groupBox7.Location = new Point(1010, 2);
            groupBox8.Location = new Point(1010, 2);
            button1.BackColor = Color.Empty;
            button2.BackColor = Color.Empty;
            button3.BackColor = Color.Empty;
            button4.BackColor = Color.Cyan;
            button5.BackColor = Color.Empty;
            button6.BackColor = Color.Empty;
            button7.BackColor = Color.Empty;
            button8.BackColor = Color.Empty;
            button1.Size = new Size(94, button1.Size.Height);
            button2.Size = new Size(94, button2.Size.Height);
            button3.Size = new Size(94, button3.Size.Height);
            button4.Size = new Size(105, button4.Size.Height);
            button5.Size = new Size(94, button5.Size.Height);
            button6.Size = new Size(94, button6.Size.Height);
            button7.Size = new Size(94, button7.Size.Height);
            button8.Size = new Size(94, button8.Size.Height);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox5.Location = new Point(110, 2);
            groupBox6.Location = new Point(1010, 2);
            groupBox7.Location = new Point(1010, 2);
            groupBox8.Location = new Point(1010, 2);
            groupBox1.Location = new Point(1010, 2);
            groupBox2.Location = new Point(1010, 2);
            groupBox3.Location = new Point(1010, 2);
            groupBox4.Location = new Point(1010, 2);
            button1.BackColor = Color.Empty;
            button2.BackColor = Color.Empty;
            button3.BackColor = Color.Empty;
            button4.BackColor = Color.Empty;
            button5.BackColor = Color.Cyan;
            button6.BackColor = Color.Empty;
            button7.BackColor = Color.Empty;
            button8.BackColor = Color.Empty;
            button1.Size = new Size(94, button1.Size.Height);
            button2.Size = new Size(94, button2.Size.Height);
            button3.Size = new Size(94, button3.Size.Height);
            button4.Size = new Size(94, button4.Size.Height);
            button5.Size = new Size(105, button5.Size.Height);
            button6.Size = new Size(94, button6.Size.Height);
            button7.Size = new Size(94, button7.Size.Height);
            button8.Size = new Size(94, button8.Size.Height);

            dataGridView1.Rows.Clear();
            dataGridView3.Rows.Clear();
            for (int i = 0; i < Manager.Instance.countries.Count; i++)
            {
                dataGridView1.Rows.Add(Manager.Instance.countries[i].name, Manager.Instance.countries[i].coefficient, Manager.Instance.countries[i].discount);
                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == "")
                {
                    dataGridView1.Rows[i].Visible = false;
                }
            }

            for (int i = 0; i < Manager.Instance.allManufacturers.Count; i++)
            {
                dataGridView3.Rows.Add();
                dataGridView3.Rows[i].Cells[0].Value = Manager.Instance.allManufacturers[i].name;
            }

            dataGridView1_CellClick(this, new DataGridViewCellEventArgs(0, 0));

            //212; 200

            if (isValid == true)
            {
                button9.Visible = true;
                dataGridView3.Height = 156;
            }
            else
            {
                button9.Visible = false;
                dataGridView3.Height = 200;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox6.Location = new Point(110, 2);
            groupBox7.Location = new Point(1010, 2);
            groupBox8.Location = new Point(1010, 2);
            groupBox1.Location = new Point(1010, 2);
            groupBox2.Location = new Point(1010, 2);
            groupBox3.Location = new Point(1010, 2);
            groupBox4.Location = new Point(1010, 2);
            groupBox5.Location = new Point(1010, 2);
            button1.BackColor = Color.Empty;
            button2.BackColor = Color.Empty;
            button3.BackColor = Color.Empty;
            button4.BackColor = Color.Empty;
            button5.BackColor = Color.Empty;
            button6.BackColor = Color.Cyan;
            button7.BackColor = Color.Empty;
            button8.BackColor = Color.Empty;
            button1.Size = new Size(94, button1.Size.Height);
            button2.Size = new Size(94, button2.Size.Height);
            button3.Size = new Size(94, button3.Size.Height);
            button4.Size = new Size(94, button4.Size.Height);
            button5.Size = new Size(94, button5.Size.Height);
            button6.Size = new Size(105, button6.Size.Height);
            button7.Size = new Size(94, button7.Size.Height);
            button8.Size = new Size(94, button8.Size.Height);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox7.Location = new Point(110, 2);
            groupBox1.Location = new Point(1010, 2);
            groupBox2.Location = new Point(1010, 2);
            groupBox3.Location = new Point(1010, 2);
            groupBox4.Location = new Point(1010, 2);
            groupBox5.Location = new Point(1010, 2);
            groupBox6.Location = new Point(1010, 2);
            groupBox8.Location = new Point(1010, 2);
            button1.BackColor = Color.Empty;
            button2.BackColor = Color.Empty;
            button3.BackColor = Color.Empty;
            button4.BackColor = Color.Empty;
            button5.BackColor = Color.Empty;
            button6.BackColor = Color.Empty;
            button7.BackColor = Color.Cyan;
            button8.BackColor = Color.Empty;
            button1.Size = new Size(94, button1.Size.Height);
            button2.Size = new Size(94, button2.Size.Height);
            button3.Size = new Size(94, button3.Size.Height);
            button4.Size = new Size(94, button4.Size.Height);
            button5.Size = new Size(94, button5.Size.Height);
            button6.Size = new Size(94, button6.Size.Height);
            button7.Size = new Size(105, button7.Size.Height);
            button8.Size = new Size(94, button8.Size.Height);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox8.Location = new Point(110, 2);
            groupBox1.Location = new Point(1010, 2);
            groupBox2.Location = new Point(1010, 2);
            groupBox3.Location = new Point(1010, 2);
            groupBox4.Location = new Point(1010, 2);
            groupBox5.Location = new Point(1010, 2);
            groupBox6.Location = new Point(1010, 2);
            groupBox7.Location = new Point(1010, 2);
            button1.BackColor = Color.Empty;
            button2.BackColor = Color.Empty;
            button3.BackColor = Color.Empty;
            button4.BackColor = Color.Empty;
            button5.BackColor = Color.Empty;
            button6.BackColor = Color.Empty;
            button7.BackColor = Color.Empty;
            button8.BackColor = Color.Cyan;
            button1.Size = new Size(94, button1.Size.Height);
            button2.Size = new Size(94, button2.Size.Height);
            button3.Size = new Size(94, button3.Size.Height);
            button4.Size = new Size(94, button4.Size.Height);
            button5.Size = new Size(94, button5.Size.Height);
            button6.Size = new Size(94, button6.Size.Height);
            button7.Size = new Size(94, button7.Size.Height);
            button8.Size = new Size(105, button8.Size.Height);
        }
        #endregion оформление окна

        //1 ОКНО главное
        //Тема и внешний вид
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setting[0] = comboBox1.SelectedIndex.ToString();
            switch (comboBox1.SelectedIndex)
            {
                case (0):
                    this.BackColor = Color.Empty;
                    Program.f1.tema(0);
                    break;
                case (1):
                    this.BackColor = Color.Gray;
                    Program.f1.tema(1);
                    break;
                case (2):
                    this.BackColor = Color.LightGray;
                    Program.f1.tema(2);
                    break;
            }

           
        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e){e.Handled = true;}


        //2 ОКНО цены менеджеров
        private void button9_Click(object sender, EventArgs e)
        {
         
        }




        //3 ОКНО
        //вывод в PDF
        private void pictureBox2_Click(object sender, EventArgs e)
        {

            //отладка окно выбора цвета
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = pictureBox2.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.BackColor = MyDialog.Color;
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

            //отладка окно выбора цвета
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = pictureBox3.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.BackColor = MyDialog.Color;
            }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
        //отладка окно выбора цвета
        ColorDialog MyDialog = new ColorDialog();
        // Keeps the user from selecting a custom color.
        MyDialog.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = pictureBox4.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            { pictureBox4.BackColor = MyDialog.Color;       
            }
        }


        //4 Вывод в PDF
        void comboBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                var txt = comboBox2.GetItemText(comboBox2.Items[e.Index]);
               var color = (Color)comboBox2.Items[e.Index];
                var r1 = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1,
                    2 * (e.Bounds.Height - 2), e.Bounds.Height - 2);
                var r2 = Rectangle.FromLTRB(r1.Right + 2, e.Bounds.Top,
                    e.Bounds.Right, e.Bounds.Bottom);
                using (var b = new SolidBrush(color))
                    e.Graphics.FillRectangle(b, r1);
                e.Graphics.DrawRectangle(Pens.Black, r1);
                TextRenderer.DrawText(e.Graphics, txt, comboBox2.Font, r2,
                    comboBox2.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
        }
        void comboBox3_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                var txt = comboBox3.GetItemText(comboBox3.Items[e.Index]);
                var color = (Color)comboBox3.Items[e.Index];
                var r1 = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1,
                    2 * (e.Bounds.Height - 2), e.Bounds.Height - 2);
                var r2 = Rectangle.FromLTRB(r1.Right + 2, e.Bounds.Top,
                    e.Bounds.Right, e.Bounds.Bottom);
                using (var b = new SolidBrush(color))
                    e.Graphics.FillRectangle(b, r1);
                e.Graphics.DrawRectangle(Pens.Black, r1);
                TextRenderer.DrawText(e.Graphics, txt, comboBox3.Font, r2,
                    comboBox3.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }

        }
        void comboBox4_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                var txt = comboBox4.GetItemText(comboBox4.Items[e.Index]);
                var color = (Color)comboBox4.Items[e.Index];
                var r1 = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1,
                    2 * (e.Bounds.Height - 2), e.Bounds.Height - 2);
                var r2 = Rectangle.FromLTRB(r1.Right + 2, e.Bounds.Top,
                    e.Bounds.Right, e.Bounds.Bottom);
                using (var b = new SolidBrush(color))
                    e.Graphics.FillRectangle(b, r1);
                e.Graphics.DrawRectangle(Pens.Black, r1);
                TextRenderer.DrawText(e.Graphics, txt, comboBox4.Font, r2,
                    comboBox4.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }

        }
        void comboBox5_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                var txt = comboBox5.GetItemText(comboBox5.Items[e.Index]);
                var color = (Color)comboBox5.Items[e.Index];
                var r1 = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1,
                    2 * (e.Bounds.Height - 2), e.Bounds.Height - 2);
                var r2 = Rectangle.FromLTRB(r1.Right + 2, e.Bounds.Top,
                    e.Bounds.Right, e.Bounds.Bottom);
                using (var b = new SolidBrush(color))
                    e.Graphics.FillRectangle(b, r1);
                e.Graphics.DrawRectangle(Pens.Black, r1);
                TextRenderer.DrawText(e.Graphics, txt, comboBox5.Font, r2,
                    comboBox5.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }

        }
        void comboBox6_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                var txt = comboBox6.GetItemText(comboBox6.Items[e.Index]);
                var color = (Color)comboBox6.Items[e.Index];
                var r1 = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1,
                    2 * (e.Bounds.Height - 2), e.Bounds.Height - 2);
                var r2 = Rectangle.FromLTRB(r1.Right + 2, e.Bounds.Top,
                    e.Bounds.Right, e.Bounds.Bottom);
                using (var b = new SolidBrush(color))
                    e.Graphics.FillRectangle(b, r1);
                e.Graphics.DrawRectangle(Pens.Black, r1);
                TextRenderer.DrawText(e.Graphics, txt, comboBox6.Font, r2,
                    comboBox6.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }

        }
        void comboBox7_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                var txt = comboBox7.GetItemText(comboBox7.Items[e.Index]);
                var color = (Color)comboBox7.Items[e.Index];
                var r1 = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1,
                    2 * (e.Bounds.Height - 2), e.Bounds.Height - 2);
                var r2 = Rectangle.FromLTRB(r1.Right + 2, e.Bounds.Top,
                    e.Bounds.Right, e.Bounds.Bottom);
                using (var b = new SolidBrush(color))
                    e.Graphics.FillRectangle(b, r1);
                e.Graphics.DrawRectangle(Pens.Black, r1);
                TextRenderer.DrawText(e.Graphics, txt, comboBox7.Font, r2,
                    comboBox7.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }

        }
        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }    
        private void comboBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void comboBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void comboBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {                   
            setting_excel[0]= comboBox2.Text;          
            //Color cv = Color.FromName(ds);
            //вариант1
            //excelRange = (excelSheet.Cells[1, 1] as Microsoft.Office.Interop.Excel.Range);
            //excelRange.Interior.ColorIndex = 3; // red
            //excelRange.Interior.PatternColorIndex = Microsoft.Office.Interop.Excel.Constants.xlAutomatic;

            //вариант2
            // (excelSheet.Cells[3, 3] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.Green;

        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            setting_excel[1] = comboBox3.Text;
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            setting_excel[2] = comboBox4.Text;
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            setting_excel[3] = comboBox5.Text;
        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            setting_excel[4] = comboBox6.Text;

        }
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            setting_excel[5] = comboBox7.Text;
        }
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex == 0) { setting_excel[6] = "0"; Program.f1.foto_excel_button(false); } else { setting_excel[6] = "1"; Program.f1.foto_excel_button(true); }
            
        }    
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            setting_excel[7] =Convert.ToInt16( numericUpDown1.Value).ToString();
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            setting_excel[8] = Convert.ToInt16(numericUpDown2.Value).ToString();
        }
        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox9.SelectedIndex == 0) { setting_excel[9] = "0"; } else { setting_excel[9] = "1"; }
        }
        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            setting_excel[10] = comboBox10.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label20.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (setting[20] != null && setting[20] != "") folderBrowserDialog1.SelectedPath = setting[20];
            if ( folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                setting[20]= folderBrowserDialog1.SelectedPath;
                label20.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            label22.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (setting[21] != null && setting[21] != "") folderBrowserDialog1.SelectedPath = setting[21];            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK){           
                setting[21] = folderBrowserDialog1.SelectedPath;
                label22.Text = folderBrowserDialog1.SelectedPath;
            }

        }

        private void button16_Click(object sender, EventArgs e)
        {
            //26
            label26.Text = "";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (setting[22] != null && setting[22] != "") folderBrowserDialog1.SelectedPath = setting[22]; if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                setting[22] = folderBrowserDialog1.SelectedPath;
                label26.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {//24
            label24.Text = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (setting[23] != null && setting[23] != "") folderBrowserDialog1.SelectedPath = setting[23]; if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                setting[23] = folderBrowserDialog1.SelectedPath;
                label24.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        //звук аськи
        private void comboBox_asq_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_asq.SelectedIndex == 1) setting[1] = "1";
            else
            setting[1] = "0";

        }

        //время проверки аски
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            setting[2] = numericUpDown3.Value.ToString();
        }

        //Воод имени общего! 
        int t = 0;
        private void textBox_имя_в_аськи_TextChanged(object sender, EventArgs e)
        {
        }
        //Воод имени общего! 
        private void textBox_имя_в_аськи_Leave(object sender, EventArgs e)
        {
            if (textBox_имя_в_аськи.Text == "") { setting[3] = Environment.UserName; textBox_имя_в_аськи.Text = Environment.UserName; }
        }
        //Путь к файлам прайса
        private void button19_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (setting[4] != null && setting[4] != "") folderBrowserDialog1.SelectedPath = setting[4]; if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                setting[4] = folderBrowserDialog1.SelectedPath;
                label31.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        //удалить путь
        private void button18_Click(object sender, EventArgs e)
        {
            label31.Text = "";
            setting[4]= "";
        }
     

        //Проверка личности
        private void button20_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            Form gf = new info();
            gf.TopMost = true;
            gf.Size = new Size(360, 353);

            gf.ShowDialog();

        }

        //результат аутификации

        public void ok_aut(string names_u)
        {
            textBox_имя_в_аськи.Text = names_u;
            setting[3]= names_u;
            setting[6] = "true";                       
        }


        //расшифровка ключа

        private void decom_pass(string codewhat)
        {
            DateTime dateTimeStart = new DateTime(1900, 1, 1, 1, 0, 0, 0);
            DateTime dateTimeStop = new DateTime(1900, 1, 1, 1, 0, 0, 0);
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
                label_key_info.Text = "c:" + dateTimeStart.ToString() + " по:" + dateTimeStop.ToString();

            }
            catch
            {
                label_key_info.Text = "♣ Ключ не раcшифровывается ♣";

            }
        }

        private void button_new_key_set_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            string result = Microsoft.VisualBasic.Interaction.InputBox("Введите ключ!", "Установка нового ключа");
            if (result != "")
            {
                result = result.Replace(" ", "");
                try
                {


                    bool wtf = true;
                    foreach (char c in result)
                    {
                        if (c < '0' || c > '9') wtf = false;

                    }

                    if (wtf == false)
                    {
                        MessageBox.Show("Это не ключ", "отказано");
                        return;
                    }
                } catch
                {
                    MessageBox.Show("Это не ключ", "отказано");
                    return;
                }
                decom_pass(result);
                label_my_key.Text = result;
                setting[7] = result;
            }
            else
            {//испугался
            }
            this.TopMost = true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void ChangeCoeff_Click(object sender, EventArgs e)
        {
            // Создаем объект FtpWebRequest - он указывает на файл, который будет создан
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Form1.url_praise + "/coefficient_prices/coefficient_prices_test.txt");
            // устанавливаем метод на загрузку файлов
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("dahmira1_admin", "zI2Hghfnslob");

            // создаем текст загрузки файла
            string text =
                "1" + "\n" +
                NameCoeff_1.Text + "\n" +
                NameCoeff_2.Text + "\n" +
                NameCoeff_3.Text + "\n" +
                NameCoeff_4.Text + "\n" +
                NameCoeff_5.Text + "\n" +
                NameCoeff_6.Text + "\n" +
                NameCoeff_7.Text + "\n" +
                NameCoeff_8.Text + "\n" +
                NameCoeff_9.Text + "\n" +
                NameCoeff_10.Text + "\n" +
                NameCoeff_11.Text + "\n" +
                NameCoeff_12.Text + "\n" +
                NameCoeff_13.Text + "\n" +
                NameCoeff_14.Text + "\n" +
                NameCoeff_15.Text + "\n" +
                
                PriceCoef_1.Text + "\n" +
                PriceCoef_2.Text + "\n" +
                PriceCoef_3.Text + "\n" +
                PriceCoef_4.Text + "\n" +
                PriceCoef_5.Text + "\n" +
                PriceCoef_6.Text + "\n" +
                PriceCoef_7.Text + "\n" +
                PriceCoef_8.Text + "\n" +
                PriceCoef_9.Text + "\n" +
                PriceCoef_10.Text + "\n" +
                PriceCoef_11.Text + "\n" +
                PriceCoef_12.Text + "\n" +
                PriceCoef_13.Text + "\n" +
                PriceCoef_14.Text + "\n" +
                PriceCoef_15.Text + "\n" +
                
                DiscountСoeff_1.Text + "\n" +
                DiscountСoeff_2.Text + "\n" +
                DiscountСoeff_3.Text + "\n" +
                DiscountСoeff_4.Text + "\n" +
                DiscountСoeff_5.Text + "\n" +
                DiscountСoeff_6.Text + "\n" +
                DiscountСoeff_7.Text + "\n" +
                DiscountСoeff_8.Text + "\n" +
                DiscountСoeff_9.Text + "\n" +
                DiscountСoeff_10.Text + "\n" +
                DiscountСoeff_11.Text + "\n" +
                DiscountСoeff_12.Text + "\n" +
                DiscountСoeff_13.Text + "\n" +
                DiscountСoeff_14.Text + "\n" +
                DiscountСoeff_15.Text
                ;
            byte[] fileContents = Encoding.UTF8.GetBytes(text);

            request.ContentLength = fileContents.Length;

            // пишем считанный в массив байтов файл в выходной поток
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            // получаем ответ от сервера в виде объекта FtpWebResponse
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Console.WriteLine("Загрузка файлов завершена. Статус: {0}", response.StatusDescription);

            response.Close();
            Console.Read();

            bool isChange = false;

            for(int i = 0; i < 15; i++)
            {
                if (i < Manager.Instance.countries.Count) 
                {
                    
                    if (Manager.Instance.countries[i].name != countryNameList[i].Text)
                    {
                        Manager.Instance.countries[i].name = countryNameList[i].Text;
                        isChange = true;
                    }
                    if (Manager.Instance.countries[i].coefficient != coefficientsList[i].Value)
                    {
                        Manager.Instance.countries[i].coefficient = coefficientsList[i].Value;
                        isChange = true;
                    }
                    if (Manager.Instance.countries[i].discount != discountList[i].Value)
                    {
                        Manager.Instance.countries[i].discount = discountList[i].Value;
                        isChange = true;
                    }
                }
                else
                {
                    Manager.Instance.countries.Add(new Models.Country { name = countryNameList[i].Text, coefficient = coefficientsList[i].Value, discount = discountList[i].Value, countryManufacturers = new List<Manufacturer> { } });
                }
            }

            //удаление пустых строк
            for (int i = 0; i < Manager.Instance.countries.Count; i++)
            {
                if (Manager.Instance.countries[i].name.ToString() == "")
                {
                    Manager.Instance.countries[i].countryManufacturers = new List<Manufacturer> { };
                }
            }

            if (isChange)
            {
                uploadCountriesOnFtp();
            }
            
            Program.f1.proverka_praisev_c_ftp();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView2.Rows.Clear();
                dataGridView3.Rows.Clear();

                if (e.RowIndex >= 0) // Проверяем, что строка была нажата (не заголовок)
                {
                    for (int i = 0; i < Manager.Instance.allManufacturers.Count; i++)
                    {
                        Manufacturer manufacturer = Manager.Instance.allManufacturers[i];
                        dataGridView3.Rows.Add(manufacturer.name);
                    }

                    int clickedRowIndex = e.RowIndex;
                    if (Manager.Instance.countries[clickedRowIndex].countryManufacturers.Count > 0)
                    {
                        for (int i = 0; i < Manager.Instance.countries[clickedRowIndex].countryManufacturers.Count; i++)
                        {
                            Manufacturer manufacturer = Manager.Instance.countries[clickedRowIndex].countryManufacturers[i];
                            dataGridView2.Rows.Add(manufacturer.name);
                        }
                    }

                    List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();
                    foreach (DataGridViewRow row1 in dataGridView3.Rows)
                    {
                        foreach (DataGridViewRow row2 in dataGridView2.Rows)
                        {
                            if (row1.Cells[0].Value != null && row2.Cells[0].Value != null)
                            {
                                if (row1.Cells[0].Value.ToString() == row2.Cells[0].Value.ToString())
                                {
                                    rowsToRemove.Add(row1);
                                    break;
                                }
                            }
                        }
                    }

                    foreach (DataGridViewRow rowToRemove in rowsToRemove)
                    {
                        dataGridView3.Rows.Remove(rowToRemove);
                    }
                }
            }
            catch
            {

            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(isValid == true)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Проверяем, что клик был по ячейке (не заголовку)
                    {
                        string cellValue = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        Manager.Instance.countries[dataGridView1.CurrentCell.RowIndex].countryManufacturers.RemoveAt(e.RowIndex);
                        dataGridView3.Rows.Add(cellValue);
                        dataGridView2.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
            catch 
            { 

            }
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(isValid == true)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Проверяем, что клик был по ячейке (не заголовку)
                    {
                        string cellValue = dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        Manager.Instance.countries[dataGridView1.CurrentCell.RowIndex].countryManufacturers.Add(new Manufacturer { name = cellValue });
                        dataGridView2.Rows.Add(cellValue);
                        dataGridView3.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
            catch 
            { 
            
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            uploadCountriesOnFtp();
            Program.f1.proverka_praisev_c_ftp();
        }

        public void uploadCountriesOnFtp()
        {
            string jsonString = JsonConvert.SerializeObject(Manager.Instance.countries);

            string ftpUsername = "dahmira1_admin";
            string ftpPassword = "zI2Hghfnslob";
            string ftpFilePath = "/countries/countries.json";

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Form1.url_praise + ftpFilePath);
            request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            byte[] fileBytes = Encoding.UTF8.GetBytes(jsonString);

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(fileBytes, 0, fileBytes.Length);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "Administrator2024")
            {
                isValid = true;
                label38.Text = "вы Администратор";
                label38.ForeColor = Color.Green;
                timer1.Start();
            }
            else
            {
                isValid = false;
                label38.Text = "у вас нет прав Администратора";
                label38.ForeColor = Color.Red;
                MessageBox.Show("Пароль Администратора введён неверно", "Проверка", MessageBoxButtons.OK);
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            label38.Text = "у вас нет прав Администратора";
            label38.ForeColor = Color.Red;
            isValid = false;
        }
    }
}
