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
        private List<double> wyniki = new List<double>();   // lista zawierajaca 15 ostatnich wynikow testu reakcji
        private bool fazaszkolenia = true;
        private int liczniktestu = 0;
        private double sredniwynik = 0;
        
        public Form2()
        {
            InitializeComponent();
            SetupChart();
            zegar.Tick += timer1_Tick;
        }

        private void SetupChart()         // wykres kolumnowy
        {
            chart1.Series.Clear();     // usuwa domyslne serie
            chart1.ChartAreas.Clear();

            chart1.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("MainArea"));   // dodaje obszar wykresu

            var series = new System.Windows.Forms.DataVisualization.Charting.Series("Twoje wyniki");  // dodaje serię danych
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column; // kolumnowy
            chart1.Series.Add(series);

        }
        
        
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible= false;
            label4.Visible= false;
            label5.Visible= false;
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
                if(fazaszkolenia == true)         // czesc szkolenia
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
                else                        //  czesc wlasciwa testu
                {
                    stoper.Stop();          // mierzy czas po kliknieciu po zmianie koloru i wyswietla wynik
                    TimeSpan czasreakcji = stoper.Elapsed;
                    wyniki.Add(czasreakcji.TotalMilliseconds);
                    if (wyniki.Count > 15)
                    {
                        wyniki.RemoveAt(0);
                    }
                    label1.Font = new Font(label1.Font.FontFamily, 46);
                    label1.Text = $"Czas reakcji: {czasreakcji.TotalMilliseconds} ms";
                    label5.Visible = true;
                    liczniktestu++;
                }
                   
            }

            if(liczniktestu == 3)   // zakonczenie czesci wlasciwej testu
            {
                label2.Visible = true;
                label5.Visible= false;
                label2.Font = new Font(label1.Font.FontFamily, 40);
                label2.Text = "Zakończenie testu reakcji optycznej!";

                button1.Visible = false;
                this.BackColor = Color.Blue;
                

                string tablicawynikow = "Czasy reakcji: \n";
                for (int i = 0; i < 3; i++)
                {
                    tablicawynikow += $"{i + 1}. {wyniki[i]:0.00} ms\n";
                    sredniwynik += wyniki[i];            // obliczanie sredniej wynikow
                } 
                sredniwynik = sredniwynik / 3;

                label6.Visible = true;
                label6.Text = tablicawynikow;

                label7.Visible = true;
                label7.Text = $"Średni wynik: {sredniwynik:0.00} ms";
                
                button2.Visible= true;
            }


        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            zegar.Stop();
            this.BackColor = Color.Green;
            stoper.Reset();
            stoper.Start(); // rozpoczynamy pomiar czasu
            

        }

        private void button2_Click(object sender, EventArgs e)           // klikniecie przycisku statystyk powinno prezentowac jak poszczegolne nasze testy wypadaly na wykresie srednich wynikow
        {
            label8.Visible = true;
            label1.Visible = true;
            label1.Font = new Font(label1.Font.FontFamily, 36);
            label1.Text = $"Twój średni wynik: {sredniwynik:0.00} ms";
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            button2.Enabled = false;

            chart1.Visible = true;
            var series = chart1.Series["Twoje wyniki"];
            series.Points.Clear(); // wyczyść stare dane

            series.Points.AddXY(0, 273);
            series.Points[0].Color = Color.Green;

            for (int i = 0; i < wyniki.Count; i++)
            {
                series.Points.AddXY(i + 1, wyniki[i]);
            }

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
