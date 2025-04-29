using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Human_Benchmark
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.test1 = null;
            this.test2 = null;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logo.Visible= false;
            tytul.Visible= false;
            button1.Visible= false;
            label2.Visible = true;
            button2.Visible= true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.test1 = new Form2();
            test1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.test2 = new Form3();
            test2.ShowDialog();
        }
    }
}
