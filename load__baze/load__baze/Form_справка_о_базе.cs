using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;


namespace load__baze
{
    public partial class Form_справка_о_базе : Form
    {
        public Form_справка_о_базе()
        {
            InitializeComponent();
        }

        private void Form_справка_о_базе_Load(object sender, EventArgs e)
        {
            this.MaximizeBox =false;
            this.MinimizeBox = false;



            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon("ico.ico");   //this.Icon = Properties.Resources.youriconname;      

            

        }

        private void Form_справка_о_базе_FormClosed(object sender, FormClosedEventArgs e)
        {
        
        }
    }
}
