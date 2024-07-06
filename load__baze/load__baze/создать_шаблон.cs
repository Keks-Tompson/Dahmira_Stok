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
using System.Text.RegularExpressions;

namespace load__baze
{
    public partial class создать_шаблон : Form
    {
        public создать_шаблон()
        {
          
            InitializeComponent();
            
        }

        private void создать_шаблон_Load(object sender, EventArgs e)
        {
                        //плавное появление формы
                   
               
            
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon("ico.ico");
            MaximizeBox = false;
            table_load("Загрузка", 1);
            string путь_к_базе = Program.f1.istohtik_bazi;        
            System.IO.FileInfo new_put = new System.IO.FileInfo(путь_к_базе);
            directory = new_put.DirectoryName;
            string[] second = null;
            try { second = Directory.GetFiles(directory + "\\шаблоны"); } catch { MessageBox.Show("С этим прайсом нет каталога с шаблонами!");return; } // путь к папке
            if (second.Length > 0) { 
               for (int i = 0; i < second.Length; i++)
               {
                    string fail = second[i].Substring(directory.Length + 9);
                    fail = fail.Substring(fail.Length - 4);
                    if (fail == ".DAH")
                    {        
                        string rr = (second[i].Substring(directory.Length + 9));                      
                        int indexOfSubstring = rr.IndexOf("_"); // равно 6
                        string rrr = rr;
                        try { rrr = rr.Substring(0, indexOfSubstring); } catch { }                 
                        bool d = true;
                        if (dataGridView2.RowCount > 0)
                        {
                            for (int n = 0; n < dataGridView2.RowCount; n++)
                            {
                                if (dataGridView2.Rows[n].Cells[0].Value.ToString() == rrr)
                                {
                                    d = false;
                                }
                            }
                        }
                        if (d==true)
                        {
                            dataGridView2.Rows.Add(rrr);
                        }

                    }
                }
                new_update();
             }
            table_load("Загрузка", 1);
        }


        private void new_update()
        {
            dataGridView1.Rows.Clear();
            string путь_к_базе = Program.f1.istohtik_bazi;
            System.IO.FileInfo new_put = new System.IO.FileInfo(путь_к_базе);
            directory = new_put.DirectoryName;
            string[] second = Directory.GetFiles(directory + "\\шаблоны"); // путь к папке
            if (second.Length > 0)
            {
                
                for (int i = 0; i < second.Length; i++)
                {
                    string fail = second[i].Substring(directory.Length + 9);
                    fail = fail.Substring(fail.Length - 4);
                    if (fail == ".DAH")
                    {
                        string ww = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value.ToString();
                        string rr = (second[i].Substring(directory.Length + 9));
                        int indexOfSubstring = rr.IndexOf("_"); // равно 6
                        string rrr = rr;
                        try { rrr = rr.Substring(0, indexOfSubstring); } catch { }
                        if (ww == rrr)
                        {
                            string kkk = rr.Substring(indexOfSubstring + 1, rr.Length - indexOfSubstring - 5);
                            bool d = true;
                            if (dataGridView1.RowCount > 0)
                            {
                                for (int n = 0; n < dataGridView1.RowCount; n++)
                                {
                                    if (dataGridView1.Rows[n].Cells[0].Value.ToString() == kkk)
                                    {
                                        d = false;
                                    }
                                }
                            }
                            if (d == true)
                            {
                                dataGridView1.Rows.Add(kkk);
                            }
                        }
                    }
                }
                textBox_раздел.Text = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }
        }





        string directory = "";
        private void dataGridView1_Click(object sender, EventArgs e)
        {           
            
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {

            DialogResult rezult = MessageBox.Show("Точно стираем?",
                            "Уточнение", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

          if (rezult== System.Windows.Forms.DialogResult.OK)
          { 
            textBox_шаблон.Text = "";

            if (dataGridView2.RowCount > 0)
            {

      
             


                    int yy = dataGridView2.CurrentCell.RowIndex;
                int xx = 0;
                if (dataGridView2.RowCount > 0)xx= dataGridView1.CurrentCell.RowIndex;
                try
                {
                    string name = (dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value.ToString()) + "_" + (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString()) + ".DAH";

                    System.IO.File.Delete(directory + "\\шаблоны\\" + name);

                        Program.f1.Save_history_user_work("Я удалил шаблон:" + directory + "\\шаблоны\\" + name, "");
                        if (dataGridView1.RowCount > 0) dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                    int g = dataGridView2.CurrentCell.RowIndex;
                   
                    if (dataGridView1.RowCount == 0)
                    {
                        dataGridView2.Rows.RemoveAt(g);

                        if (g > 0) dataGridView2.CurrentCell = dataGridView2.Rows[g - 1].Cells[0];
                        if (g == 0) dataGridView2.CurrentCell = dataGridView2.Rows[0].Cells[0];
                    }
                    if (dataGridView2.RowCount > 0)
                    {
                        new_update();

                        if (dataGridView1.RowCount > 0)
                        {
                            if (xx> 0) dataGridView1.CurrentCell = dataGridView1.Rows[xx - 1].Cells[0];
                            if (xx== 0) dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                        }

                        table_load("Удалила", 1);
                    }
                }
                catch
                {
                    MessageBox.Show("У компа нет доступа к папке!", "О дела...");
                }
            }
            else
            {
                MessageBox.Show("В папке с шаблонами ничего нет!", "ТАК! ");
            }
          }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            textBox_шаблон.Text = textBox_шаблон.Text.Trim();
            Boolean ok = true;
            if (textBox_шаблон.Text == ""|| textBox_раздел.Text=="")
            {
                MessageBox.Show("Надо имя придумать!", "О дела...");
                ok = false;
            }

            if (ok == true)
            {
            string s = textBox_шаблон.Text+ textBox_раздел.Text;

                bool err= false;// есть ли ошибка
                if (Regex.IsMatch(s, "^[^_]+$") == false) { err = true; }
                if (Regex.IsMatch(s, "^[^(]+$") == false) { err = true; }
                if (Regex.IsMatch(s, "^[^)]+$") == false) { err = true; }
                if (Regex.IsMatch(s, "^[^>]+$") == false) { err = true; }
                if (Regex.IsMatch(s, "^[^@]+$") == false) { err = true; }
                if (Regex.IsMatch(s, "^[^^]+$") == false) { err = true; }
                if (Regex.IsMatch(s, "^[^*]+$") == false) { err = true; }
                if (Regex.IsMatch(s, "^[^<]+$") == false) { err = true; }
                if (Regex.IsMatch(s, "^[^;]+$") == false) { err = true; }
                if (Regex.IsMatch(s, "^[^:]+$") == false) { err = true; }
                if (err == true) { MessageBox.Show("Нарушение правила именования.\nУберите:_()<>@^*;:", "НЕ НАДО ТАК ДЕЛАТЬ...."); }
                string curFile = directory + "\\шаблоны\\" + textBox_раздел.Text + "_" + textBox_шаблон.Text + ".DAH";
                if (File.Exists(curFile) == true)
                {
                    ok = false;
                    MessageBox.Show("Такое имя уже есть!", "НЕ НАДО ТАК ДЕЛАТЬ....");
                }                              
            }
            //string new_name_i_adress = directory + "\\шаблоны\\" + textBox_раздел.Text + "_" + textBox_шаблон.Text + ".DAH";
            if (ok == true)
            {
                try { string[] second1 = Directory.GetFiles(directory + "\\шаблоны"); } catch
                {

                    Directory.CreateDirectory(directory + "\\шаблоны");



                }



                table_load("Создаю", 1);
                string[] переход_на_новый_расчет = new string[2];
                переход_на_новый_расчет[0] = textBox_раздел.Text;
                переход_на_новый_расчет[1] = textBox_шаблон.Text;
                //можно передовать в другую форму. 
                Program.f1.создала_шаблон = false;
                Program.f1.имя_файла = textBox_раздел.Text + "_" + textBox_шаблон.Text + ".DAH";
                Program.f1.button_создать_шаблон.Visible = true;
                Program.f1.button_создать_шаблон.PerformClick();
                if (Program.f1.создала_шаблон == true)
                {
                    ///Заного грузим список
                    dataGridView1.Rows.Clear();
                    dataGridView2.Rows.Clear();
                    string путь_к_базе = Program.f1.istohtik_bazi;
                    System.IO.FileInfo new_put = new System.IO.FileInfo(путь_к_базе);
                    directory = new_put.DirectoryName;
                    string[] second = null;
                    try { second = Directory.GetFiles(directory + "\\шаблоны"); } catch { }
                    if (second!= null && second.Length > 0)
                    {
                        for (int i = 0; i < second.Length; i++)
                        {
                            string fail = second[i].Substring(directory.Length + 9);
                            fail = fail.Substring(fail.Length - 4);
                            if (fail == ".DAH")
                            {
                                string rr = (second[i].Substring(directory.Length + 9));
                                int indexOfSubstring = rr.IndexOf("_"); // равно 6
                                string rrr = rr;
                                try { rrr = rr.Substring(0, indexOfSubstring); } catch { }
                                bool d = true;
                                if (dataGridView2.RowCount > 0)
                                {
                                    for (int n = 0; n < dataGridView2.RowCount; n++)
                                    {
                                        if (dataGridView2.Rows[n].Cells[0].Value.ToString() == rrr)
                                        {
                                            d = false;
                                        }
                                    }
                                }
                                if (d == true)
                                {
                                    dataGridView2.Rows.Add(rrr);
                                }
                            }
                        }
                        //перейдем на эту строчку 
                        //переход_на_новый_расчет[0]
                        for (int i = 0; i < dataGridView2.RowCount; i++)
                        {
                            if (переход_на_новый_расчет[0] == dataGridView2.Rows[i].Cells[0].Value.ToString()) { dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[0]; }
                        }
                        new_update(); //обновим второй
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            if (переход_на_новый_расчет[1] == dataGridView1.Rows[i].Cells[0].Value.ToString()) { dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0]; }
                        }
                    }
                    table_load("Добавила", 1);
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;
            if (e.KeyChar == 46 || e.KeyChar == 45 || e.KeyChar ==44 || e.KeyChar ==43 || e.KeyChar ==42 || e.KeyChar ==47 || e.KeyChar ==126 || e.KeyChar == 96 || e.KeyChar == 126 || e.KeyChar == 60 || e.KeyChar == 61 || e.KeyChar == 62 || e.KeyChar == 92 || e.KeyChar == 124 || e.KeyChar == 123 || e.KeyChar == 125 || e.KeyChar == 91|| e.KeyChar == 93 )
            {
                e.Handled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Boolean er=false;
            string file_temp = null;
            string names = null;

            try
            {
                string путь_к_базе = Program.f1.istohtik_bazi;
                System.IO.FileInfo new_put = new System.IO.FileInfo(путь_к_базе);
                directory = new_put.DirectoryName;
                names = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value.ToString()+"_"+dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString()+".DAH";
                string file_in_proeckt = directory + "\\шаблоны\\" + names; // путь к проекту
                file_temp = Environment.CurrentDirectory + "\\rez\\CNDataTemp\\" + names;
               
                table_load("Добавляем",1);
                FileInfo fileInf = new FileInfo(file_in_proeckt);
                if (fileInf.Exists)
                {
                    fileInf.CopyTo(file_temp, true);
                    // альтернатива с помощью класса File
                    // File.Copy(path, newPath, true);
                }
                
                er = true;
            }
            catch { MessageBox.Show("Не смогла скопировать файл шаблона!", "Удаленный комп не отвечает"); }
            try
            {
                if (er== true)
                {
                Program.f1.имя_файла_шаблона = names;
                Program.f1.путь_и_имя_файла_шаблона = file_temp;
                Program.f1.button_догрузить_шаблон.Visible = true;
                Program.f1.button_догрузить_шаблон.PerformClick();
                    table_load("Добавлено", 1);
                }
            } catch { }

        }
        private void button_редактировать_Click(object sender, EventArgs e)
        {      
                Boolean er = false;
                string file_temp = null;
                string names = null;             
                try
                {
                   
                    string путь_к_базе = Program.f1.istohtik_bazi;
                    System.IO.FileInfo new_put = new System.IO.FileInfo(путь_к_базе);
                    directory = new_put.DirectoryName;
                    names = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value.ToString()+"_"+ dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString()+".DAH";
                    string file_in_proeckt = directory + "\\шаблоны\\" + names; // путь к проекту
                    file_temp = Environment.CurrentDirectory + "\\rez\\CNDataTemp\\" + names;
                
                    FileInfo fileInf = new FileInfo(file_in_proeckt);
                    if (fileInf.Exists)
                    {                    
                        fileInf.CopyTo(file_temp, true);

                    }
                
                    er = true;
                }
                catch { MessageBox.Show("Не смогла скопировать файл шаблона!", "Удаленный комп не отвечает"); }
            try
            {
                if (er == true)
                {
                    Program.f1.имя_файла_шаблона = names;
                    Program.f1.путь_и_имя_файла_шаблона = file_temp;
                    Program.f1.button_редактировать_шаблон.Visible = true;
                    Program.f1.button_редактировать_шаблон.PerformClick();
                    this.Close();
                }
            }
            catch { }                    
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       #region Поиск

     
        private void button3_Click_1(object sender, EventArgs e)
        {



            
             
    
           
            string путь_к_базе = Program.f1.istohtik_bazi;        
            System.IO.FileInfo new_put = new System.IO.FileInfo(путь_к_базе);
            directory = new_put.DirectoryName;
            string[] second;
            try {  second = Directory.GetFiles(directory + "\\шаблоны"); } catch { MessageBox.Show("Что то делаешь не то! ", "замечание"); return; }// путь к папке
            if (second.Length > 0) { 
            int cd = 0;
            for (int i = 0; i < second.Length; i++)
            {   string fail = second[i].Substring(directory.Length + 9);
                fail = fail.Substring(fail.Length - 4);
                if (fail == ".DAH") cd++;
            }

                string[] second1 = new string[cd];
                cd = 0;
                for (int i = 0; i < second.Length; i++)
                {
                    string fail = second[i].Substring(directory.Length + 9);
                    fail = fail.Substring(fail.Length - 4);
                    if (fail == ".DAH") { second1[cd] = second[i];cd++;}
                }

                string[] раздел = new string[cd*2];
                int q = 0;
               for (int i = 0; i < second1.Length; i++)
               {
                    string fail = second1[i].Substring(directory.Length + 9);
                    fail = fail.Substring(fail.Length - 4);
                    if (fail == ".DAH")
                    {        
                        string rr = (second1[i].Substring(directory.Length + 9));                      
                        int indexOfSubstring = rr.IndexOf("_"); // равно 6
                        string rrr = rr;
                        try { rrr = rr.Substring(0, indexOfSubstring); } catch { }

                        string vv= (second1[i].Substring(directory.Length + 9));
                        string vvv = vv;
                       
                        try { vvv = vv.Substring(indexOfSubstring+1, vv.Length- indexOfSubstring-5); } catch { }
                        раздел[q]=rrr;
                        раздел[(раздел.Length/2)+q] = vvv;
                        q++;






                    }
                }







                for (int i = 0; i < раздел.Length; i++)
                {
                    string straka = раздел[i].ToLower();
                    //поиск:
                    string stroka_poiska = textBox2.Text.ToLower();
                    if (straka.Contains(stroka_poiska))
                    {
                        if (i < раздел.Length / 2)
                        { //нашли в разделе 
                            for (int r = 0; r < dataGridView2.RowCount; r++)
                            {
                                if (dataGridView2.Rows[r].Cells[0].Value.ToString().ToLower() == straka)
                                {
                                    dataGridView2.CurrentCell = dataGridView2.Rows[r].Cells[0]; new_update(); table_load("Нашла в разделе", 1); break;
                                }
                            }
                        }
                        else
                        {
                            //нашли шаблонах                            
                            string p = раздел[i - раздел.Length / 2];
                            for (int r = 0; r < dataGridView2.RowCount; r++)
                            {
                                if (dataGridView2.Rows[r].Cells[0].Value.ToString() == p)
                                {
                                    dataGridView2.CurrentCell = dataGridView2.Rows[r].Cells[0]; new_update();


                                   for (int k= 0; r < dataGridView1.RowCount; k++)
                                   {
                                      if (dataGridView1.Rows[k].Cells[0].Value.ToString().ToLower() == straka)
                                      {
                                         dataGridView1.CurrentCell = dataGridView1.Rows[k].Cells[0]; table_load("Нашла в шаблонах", 1); break;
                                      }
                                   }
                                }
                            }                           
                        }                                      
                    }                   
                }            
            }
        }
        #endregion Поиск

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            new_update();
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

 
        private void table_load(string j,int h)
        {
            label1.Text = j;
            label1.Visible = true;
            if (h==1)timer1.Enabled = true;
            if (h == 0) { timer1.Enabled = false; label1.Visible = false; }
            }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Visible = false;
            timer1.Enabled = false;
        }
    }
}
