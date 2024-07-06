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
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;


namespace download_baza_to
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Form2 newForm = new Form2();
            newForm.Show();
           
            this.tableTableAdapter.Fill(this._1DataSet.Table);


            string put_k_baza= Environment.CurrentDirectory;
            string put_k_file = put_k_baza.Substring(0,put_k_baza.Length - 12);

            string name_file = "";
            // открываем файл
            using (StreamReader stream = new StreamReader(put_k_file+  "name.ini"))
            {
                while (stream.Peek() >= 0)
                {
                    // читаем строку из файла
                    name_file = stream.ReadLine();
                }
                stream.Close();
            }



            string put_k_data = put_k_file+ "resource\\"+ name_file+".ini";

                //грузим основное

                using (BinaryReader bw = new BinaryReader(File.Open(put_k_data, FileMode.Open)))
            {
                int n = bw.ReadInt32();
                int m = bw.ReadInt32();
                for (int i = 0; i < m; ++i)
                {
                    if (i == m)
                    {
                    }
                    if (i < m-1)
                    {
                        //dataGridView_расчёт_2.Rows.Add();
                        bindingNavigatorAddNewItem.PerformClick();
                    }
                    for (int j = 0; j < n; ++j)
                    {
                        if (bw.ReadBoolean())
                        {
                            if (j == 0) { tableDataGridView.Rows[i].Cells[j].Value = (i + 1).ToString(); }

                            if (j == 0 || j == 1 || j == 2) { tableDataGridView.Rows[i].Cells[j + 1].Value = bw.ReadString(); }
                           
                             if (j == 3) { tableDataGridView.Rows[i].Cells[j + 2].Value = bw.ReadString(); }

                            if (j == 0) //пробуем фото
                            {
                       
                                bool tryfile_png = File.Exists(put_k_file+ "resource\\" + i.ToString() + ".png");

                                if (tryfile_png == true)
                                {
                                    System.Drawing.Image img;
                                    using (var bmpTemp = new Bitmap(put_k_file + "resource\\" + i.ToString() + ".png"))
                                    {
                                        img = new Bitmap(bmpTemp);
                                        фотографияPictureBox.Image = img;
                                    }


                                }
                               

                            }
                        }
                        else { bw.ReadBoolean(); } 
                    }
                }
            }




            //   bindingNavigatorAddNewItem.PerformClick();

            newForm.Close();

            
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._1DataSet);
            timer1.Enabled = true;

        }

        private void tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._1DataSet);

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void tableBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._1DataSet);

        }

        private void tableDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
      
        bool ga = false;
        private void timer1_Tick(object sender, EventArgs e)
        {




            Application.Exit();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            ProcessStartInfo infoStartProcess = new ProcessStartInfo();
            string put_k_baza = Environment.CurrentDirectory;
            string put_k_file = put_k_baza.Substring(0, put_k_baza.Length - 12);
            infoStartProcess.WorkingDirectory = put_k_file + "copirait";
            infoStartProcess.FileName = "copiride.bat";

            Process.Start(infoStartProcess);
        }
    }
}
