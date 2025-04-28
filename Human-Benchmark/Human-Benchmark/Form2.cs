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

namespace Human_Benchmark
{
    public partial class Form2 : Form
    {

        private Stopwatch stoper = new Stopwatch();
        private Timer zegar = new Timer();
        private Random rng = new Random();
        private bool zaszybko = false;
        private List<double> wyniki = new List<double>();   // lista zawierajaca 10 ostatnich wynikow testu reakcji
        private bool fazaszkolenia = true;
        
        public Form2()
        {
            InitializeComponent();

            zegar.Tick += timer1_Tick;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible= false;
            if (zaszybko == true)     // warunek ktory wystepuje w przypadku zbyt szybkiego nacisniecia przycisku
            {
                label1.Font = new Font(label1.Font.FontFamily, 18);
                label1.Text = "Za szybko! Kliknij w przycisk, żeby spróbować ponownie.";
                zegar.Stop();
            }
            else
            {
                button1.Text = "Przycisk";
                this.BackColor = Color.Red;
                int opoznienie = rng.Next(200, 10001); // po losowym czasie w zakresie od 2 do 10 sekund zmieni sie kolor tla
                zegar.Interval = opoznienie;  // zegar otrzymuje informacje ile czasu ma dzialac
                zegar.Start();  // rozpoczynamy odliczanie

                label1.Font = new Font(label1.Font.FontFamily, 36);
                label1.Text = "Czekaj na zmianę koloru tła...";
             
            }
            zaszybko=!zaszybko;


            if(stoper.IsRunning)
            {
                if(fazaszkolenia == true)
                {
                    stoper.Stop();
                    TimeSpan czasreakcjiszkolenie = stoper.Elapsed;
                    label1.Font = new Font(label1.Font.FontFamily, 46);
                    label1.Text = $"Czas reakcji: {czasreakcjiszkolenie.TotalMilliseconds} ms";
                    label2.Visible= true;
                    label2.Font = new Font(label2.Font.FontFamily, 22);
                    label2.Text = "Bardzo dobrze, możesz przejść do właściwego testu, klikając przycisk";
                    fazaszkolenia= false;

                }
                else
                {
                    stoper.Stop();          // mierzy czas po kliknieciu po zmianie koloru i wyswietla wynik
                    TimeSpan czasreakcji = stoper.Elapsed;
                    wyniki.Add(czasreakcji.TotalMilliseconds);
                    if (wyniki.Count > 10)
                    {
                        wyniki.RemoveAt(0);
                    }
                    label1.Font = new Font(label1.Font.FontFamily, 46);
                    label1.Text = $"Czas reakcji: {czasreakcji.TotalMilliseconds} ms";
                }
                   
            }


        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            zegar.Stop();
            this.BackColor = Color.Green;
            stoper.Reset();
            stoper.Start(); // rozpoczynamy pomiar czasu
            

        }
    }
}
