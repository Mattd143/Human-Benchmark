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

namespace Human_Benchmark
{
    public partial class Form3 : Form
    {

        private bool blad = false;
        private Stopwatch stoper = new Stopwatch();
        private Timer zegar = new Timer();
        private Random rng = new Random();
        private bool fazaszkolenia = true;
        private List<double> wyniki = new List<double>();   // lista zawierajaca 15 ostatnich wynikow testu reakcji
        private int liczniktestu = 0;
        private double sredniwynik = 0;
        private int zmianakoloru = 0;

        public Form3()
        {
            InitializeComponent();
            zegar.Tick += timer1_Tick;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible  = false;
            label1.Font = new Font(label1.Font.FontFamily, 40);
            label1.Text = "      Czekaj na zmianę koloru tła...";
            button1.Visible = false;
            przyciskZielony.Visible = true;
            przyciskPomarancz.Visible=true;
            przyciskZolty.Visible=true;
            przyciskNiebieski.Visible=true;


            
            this.BackColor = Color.Red;
            zmianakoloru = rng.Next(1, 4);
            int opoznienie = rng.Next(200, 10001); // po losowym czasie w zakresie od 2 do 10 sekund zmieni sie kolor tla
            zegar.Interval = opoznienie;  // zegar otrzymuje informacje ile czasu ma dzialac
            zegar.Start();  // rozpoczynamy odliczanie

            label1.Font = new Font(label1.Font.FontFamily, 46);
            label1.Text = "   Czekaj na zmianę koloru tła...";
            

        }

        private void PrzyciskKolory_click(object sender, EventArgs e)
        {
             
            Button przycisk = (Button)sender; // jezeli wcisniemy przycisk to wywola funkcje przez sendera i dzieki temu okreslimy ktory z nich zostal wcisniety
            if (przycisk.Name == "przyciskZielony")
            {
                if (zmianakoloru != 1)
                {
                    blad = true;
                }
                
            }
            else if (przycisk.Name == "przyciskPomarancz")
            {
                if (zmianakoloru != 2)
                {
                    blad = true;
                }

            }
            else if (przycisk.Name == "przyciskZolty")
            {
                if (zmianakoloru != 3)
                {
                    blad = true;
                }

            }
            else if (przycisk.Name == "przyciskNiebieski")
            {
                if (zmianakoloru != 4)
                {
                    blad = true;
                }
            }

            if (blad == true)
            {
                label1.Font = new Font(label1.Font.FontFamily, 18);
                label1.Text = "Za szybko, bądź błędny kolor! Kliknij w przycisk ponów, żeby spróbować ponownie.";
                zegar.Stop();
                button1.Visible = true;
                button1.Text = "Ponów";
                blad = !blad;
            }
            else if(stoper.IsRunning && blad == false)
            {
                button1.Visible = true;
                button1.Text = "Kontynuuj";

                if (fazaszkolenia == true)
                {
                    stoper.Stop();
                    TimeSpan czasreakcjiszkolenie = stoper.Elapsed;
                    label1.Font = new Font(label1.Font.FontFamily, 46);
                    label1.Text = $"  Czas reakcji: {czasreakcjiszkolenie.TotalMilliseconds} ms";
                    label2.Visible = true;
                    label2.Font = new Font(label2.Font.FontFamily, 20);
                    label2.Text = " Bardzo dobrze, możesz przejść do właściwego testu, klikając przycisk kontynuuj";
                    fazaszkolenia = false;
                }
                else
                {
                    stoper.Stop();          // mierzy czas po kliknieciu po zmianie koloru i wyswietla wynik
                    TimeSpan czasreakcji = stoper.Elapsed;
                    wyniki.Add(czasreakcji.TotalMilliseconds);
                    if (wyniki.Count > 15)
                    {
                        wyniki.RemoveAt(0);
                    }
                    label1.Font = new Font(label1.Font.FontFamily, 46);
                    label1.Text = $"  Czas reakcji: {czasreakcji.TotalMilliseconds} ms";
                    liczniktestu++;
                }

                

            }


            
            
            
              





            if (liczniktestu == 3)  // zakonczenie czesci wlasciwej testu
            {
                label2.Visible = true;
                label2.Font = new Font(label1.Font.FontFamily, 40);
                label2.Text = "   Zakończenie testu reakcji optycznej!";
                przyciskNiebieski.Visible = false;
                przyciskPomarancz.Visible = false;
                przyciskZielony.Visible = false;
                przyciskZolty.Visible = false;
                button1.Visible= false;
                this.BackColor = Color.Blue;

                string tablicawynikow = "Czasy reakcji: \n";
                for (int i = 0; i < 3; i++)
                {
                    tablicawynikow += $"{i + 1}. {wyniki[i]:0.00} ms\n";
                    sredniwynik += wyniki[i];            // obliczanie sredniej wynikow
                }
                sredniwynik = sredniwynik / 3;

                label3.Visible = true;
                label3.Text = tablicawynikow;

                label4.Visible = true;
                label4.Text = $"Średni wynik: {sredniwynik:0.00} ms";
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            zegar.Stop();
            
            switch (zmianakoloru)
            {
                case 1:
                    this.BackColor = Color.Green;
                break;
                case 2:
                    this.BackColor = Color.DarkOrange;
                break;
                case 3:
                    this.BackColor = Color.Gold;
                break;
                case 4:
                    this.BackColor = Color.Blue;
                break;

            }
            stoper.Reset();
            stoper.Start(); // rozpoczynamy pomiar czasu
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
