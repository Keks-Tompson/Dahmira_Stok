using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace load__baze
{
    public partial class отчет_с_поиска_по_повторам : Form
    {
        public отчет_с_поиска_по_повторам()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                this.TopMost = true;
            }
            else { this.TopMost = false; }
        }

        private void отчет_с_поиска_по_повторам_Load(object sender, EventArgs e)
        {
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon("ico.ico");            
            for (int i = 0; i < Program.f1.povtor.Length; i++)
            {
                dataGridView1.Rows.Add((i + 1).ToString(), Program.f1.povtor_strit1[i], Program.f1.povtor_strit2[i], Program.f1.povtor[i]);
            }            
        }

        private void отчет_с_поиска_по_повторам_Resize(object sender, EventArgs e)
        {
            dataGridView1.Size= new Size(Width-32, Height-70);
        }

        private void отчет_с_поиска_по_повторам_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.f1.open_window_otchetik = false;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
                int selectedRowCount = dataGridView1.CurrentCell.RowIndex;
                int selectedCelCount = dataGridView1.CurrentCell.ColumnIndex;
            if (selectedCelCount == 1)
            {
                try
                {
                    string re = dataGridView1.Rows[selectedRowCount].Cells[1].Value.ToString();
                    Program.f1.perehod_if_prais(re);
                }
                catch
                {

                }


            }
            if (selectedCelCount == 2)
            {
                try
                {
                    string re = dataGridView1.Rows[selectedRowCount].Cells[2].Value.ToString();
                    Program.f1.perehod_if_prais(re);
                }
                catch
                {

                }


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            //  Close();
            Program.f1.perehod_if_prais("☺☻");

            dataGridView1.Rows.Clear();

            try
            {
                {
                    for (int i = 0; i < Program.f1.povtor.Length; i++)
                    {
                        dataGridView1.Rows.Add((i + 1).ToString(), Program.f1.povtor_strit1[i], Program.f1.povtor_strit2[i], Program.f1.povtor[i]);
                    }
                }
            }
            catch
            {
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridView1.CurrentCell.RowIndex;
            int selectedCelCount = dataGridView1.CurrentCell.ColumnIndex;
            bool nada = false;
            string re = "";
            if (selectedCelCount == 1)
            {
                try
                {
                    if (dataGridView1.Rows[selectedRowCount].Cells[1].Value.ToString() != "Удалено")
                    {
                        re = dataGridView1.Rows[selectedRowCount].Cells[1].Value.ToString();
                        Program.f1.del_if_prais(re);
                        dataGridView1.Rows[selectedRowCount].Cells[1].Value = "Удалено";
                        nada = true;
                    }
                }
                catch
                {

                }


            }
            if (selectedCelCount == 2)
            {
                try
                {
                    if (dataGridView1.Rows[selectedRowCount].Cells[2].Value.ToString() != "Удалено")
                    {
                        re = dataGridView1.Rows[selectedRowCount].Cells[2].Value.ToString();
                        Program.f1.del_if_prais(re);
                        dataGridView1.Rows[selectedRowCount].Cells[2].Value = "Удалено";
                        nada = true;
                    }                   
                }
                catch
                {

                }


            }
            if (nada == true)
            {

                       int rt = Convert.ToInt16(re);
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            if (dataGridView1.Rows[i].Cells[1].Value.ToString()!= "Удалено" && rt < Convert.ToInt16(dataGridView1.Rows[i].Cells[1].Value.ToString()))
                            { int fdfa = Convert.ToInt16(dataGridView1.Rows[i].Cells[1].Value.ToString());
                                fdfa--;
                                dataGridView1.Rows[i].Cells[1].Value = fdfa;
                            }

                         if (dataGridView1.Rows[i].Cells[2].Value.ToString() != "Удалено" && rt < Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value.ToString()))
                         {
                          int fdfa = Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value.ToString());
                           fdfa--;
                           dataGridView1.Rows[i].Cells[2].Value = fdfa;
                         }
                }                       
            }        
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

            int selectedCelCount = dataGridView1.CurrentCell.ColumnIndex;
        
            if (selectedCelCount == 1 || selectedCelCount == 2) { button2.Enabled = true; } else { button2.Enabled = false; }
            
        }

        private void отчет_с_поиска_по_повторам_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}
