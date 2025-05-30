﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.Reflection.Emit;

namespace Human_Benchmark
{
    public partial class Form4 : Form
    {
        private SoundPlayer dzwiek;
        private Stopwatch stoper = new Stopwatch();
        private Timer zegar = new Timer();
        private Random rng = new Random();
        private bool zaszybko = false;
        private List<double> wyniki = new List<double>();   // lista zawierajaca 15 ostatnich wynikow testu reakcji
        private bool fazaszkolenia = true;
        private int liczniktestu = 0;
        private double sredniwynik = 0;

        public Form4()
        {
            InitializeComponent();
            dzwiek = new SoundPlayer(Properties.Resources.dzwiek1);
            zegar.Tick += timer1_Tick;
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

            if (zaszybko == true)     // warunek ktory wystepuje w przypadku zbyt szybkiego nacisniecia przycisku
            {
                label1.Font = new Font(label1.Font.FontFamily, 26);
                label1.Text = "    Za szybko! Kliknij w przycisk, żeby spróbować ponownie.";
                zegar.Stop();
                button1.Text = "Ponów";
            }
            else
            {
                int opoznienie = rng.Next(200, 10001); // po losowym czasie w zakresie od 2 do 10 sekund zmieni sie kolor tla
                zegar.Interval = opoznienie;  // zegar otrzymuje informacje ile czasu ma dzialac
                zegar.Start();  // rozpoczynamy odliczanie
            }
            zaszybko = !zaszybko;

            if (stoper.IsRunning)
            {
                if (fazaszkolenia == true)         // czesc szkolenia
                {
                    stoper.Stop();
                    TimeSpan czasreakcjiszkolenie = stoper.Elapsed;
                    label1.Font = new Font(label1.Font.FontFamily, 46);
                    label1.Text = $"       Czas reakcji: {czasreakcjiszkolenie.TotalMilliseconds-450} ms";
                    label2.Visible = true;
                    label2.Font = new Font(label2.Font.FontFamily, 22);
                    label2.Text = "Bardzo dobrze, możesz przejść do właściwego testu, klikając przycisk";
                    fazaszkolenia = false;

                }
                else                        //  czesc wlasciwa testu
                {
                    stoper.Stop();          // mierzy czas po kliknieciu po zmianie koloru i wyswietla wynik
                    TimeSpan czasreakcji = stoper.Elapsed;
                    wyniki.Add(czasreakcji.TotalMilliseconds - 450);  // odejmujemy 0,45s z powodu opoznienia pliku dzwiekowego
                    if (wyniki.Count > 15)
                    {
                        wyniki.RemoveAt(0);
                    }
                    label1.Font = new Font(label1.Font.FontFamily, 46);
                    label1.Text = $"    Czas reakcji: {czasreakcji.TotalMilliseconds - 450} ms";
                    button1.Text = "Kontynuuj";
                    liczniktestu++;
                }
            }

            if(liczniktestu == 3)
            {
                label2.Visible=true;
                label2.Font = new Font(label1.Font.FontFamily, 40);
                label2.Text = "Zakończenie testu reakcji akustycznej!";
                button1.Visible = false;

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
            dzwiek.Play();
            stoper.Reset();
            stoper.Start(); // rozpoczynamy pomiar czasu
        }
    }
}
