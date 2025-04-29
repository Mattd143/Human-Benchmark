using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Human_Benchmark
{
    public partial class Form4 : Form
    {
        private SoundPlayer dzwiek;
        
        public Form4()
        {
            InitializeComponent();
            dzwiek = new SoundPlayer(Properties.Resources.dzwiek1);
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label1.Font = new Font(label1.Font.FontFamily, 40);
            label1.Text = "        Czekaj na sygnał dźwiękowy...";
            button1.Text = "Przycisk";


            dzwiek.Play();
        }
    }
}
