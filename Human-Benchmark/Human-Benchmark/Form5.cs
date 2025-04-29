using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Media;


namespace Human_Benchmark
{
    public partial class Form5 : Form
    {
        private SoundPlayer dzwiekpoprawny;
        private SoundPlayer dzwiek2;
        private SoundPlayer dzwiek3;
        private SoundPlayer dzwiek4;
        private Stopwatch stoper = new Stopwatch();
        private Timer zegar = new Timer();
        private Random rng = new Random();
        private bool zaszybko = false;
        private List<double> wyniki = new List<double>();   // lista zawierajaca 15 ostatnich wynikow testu reakcji
        private bool fazaszkolenia = true;
        private int liczniktestu = 0;
        private double sredniwynik = 0;

        public Form5()
        {
            InitializeComponent();
            dzwiekpoprawny = new SoundPlayer(Properties.Resources.dzwiek1);
            dzwiekpoprawny = new SoundPlayer(Properties.Resources.dzwiek2);
            dzwiekpoprawny = new SoundPlayer(Properties.Resources.dzwiek3);
            dzwiekpoprawny = new SoundPlayer(Properties.Resources.dzwiek4);
            zegar.Tick += timer1_Tick;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(zaszybko == false)
            {
                label2.Visible = false;
                label1.Font = new Font(label1.Font.FontFamily, 40);
                label1.Text = "      Zapamiętaj sygnał dźwiękowy...";
                button1.Text = "Kontynuuj";
                dzwiekpoprawny.Play();
                zaszybko = !zaszybko;
            }
            else
            {
                button1.Visible= false;
                Poprawny.Visible = true;
                Błędny.Visible = true;
                label1.Font = new Font(label1.Font.FontFamily, 34);
                label1.Text = "Czy sygnał dźwiękowy zgadza się z sygnałem oryginalnym?";
                 // puszcza randomowy dzwiek
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Przyciski_Click(object sender, EventArgs e)
        {

        }
    }
}
