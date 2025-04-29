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
        private int dzwiekwtescie = 0;

        public Form5()
        {
            InitializeComponent();
            dzwiekpoprawny = new SoundPlayer(Properties.Resources.dzwiek1);
            dzwiek2 = new SoundPlayer(Properties.Resources.dzwiek2);
            dzwiek3 = new SoundPlayer(Properties.Resources.dzwiek3);
            dzwiek4 = new SoundPlayer(Properties.Resources.dzwiek4);
            zegar.Tick += timer1_Tick;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            if (zaszybko == false)
            { 
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
                label1.Font = new Font(label1.Font.FontFamily, 26);
                label1.Text = "Czy sygnał dźwiękowy zgadza się z sygnałem oryginalnym?";
                dzwiekwtescie = rng.Next(1, 4);
                int opoznienie = rng.Next(200, 10001); // po losowym czasie w zakresie od 2 do 10 sekund zmieni sie kolor tla
                zegar.Interval = opoznienie;  // zegar otrzymuje informacje ile czasu ma dzialac
                zegar.Start();  // rozpoczynamy odliczanie

                switch (dzwiekwtescie){
                    case 1:
                        dzwiekpoprawny.Play();
                        break;
                    case 2:
                        dzwiek2.Play();
                        break;
                    case 3:
                        dzwiek3.Play();
                        break;
                    case 4:
                        dzwiek4.Play();
                        break;
                }
                 // puszcza randomowy dzwiek
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            zegar.Stop();
            stoper.Reset();
            stoper.Start(); // rozpoczynamy pomiar czasu
        }

        private void Przyciski_Click(object sender, EventArgs e)
        {
            Button przycisk = (Button)sender; // jezeli wcisniemy przycisk to wywola funkcje przez sendera i dzieki temu okreslimy ktory z nich zostal wcisniety
            if (przycisk.Name == "Poprawny")
            {
                button1.Visible = true;
     

                if (dzwiekwtescie== 1 && stoper.IsRunning)
                {
                    
                    stoper.Stop();  // mierzy czas po kliknieciu puszczeniu dzwieku i wyswietla wynik
                    if (fazaszkolenia == true)
                    {
                        TimeSpan czasreakcjiszkolenie = stoper.Elapsed;
                        label1.Font = new Font(label1.Font.FontFamily, 46);
                        label1.Text = $"  Czas reakcji: {czasreakcjiszkolenie.TotalMilliseconds} ms";
                        label2.Visible = true;
                        label2.Font = new Font(label2.Font.FontFamily, 20);
                        label2.Text = " Bardzo dobrze, możesz przejść do właściwego testu, klikając przycisk kontynuuj";
                        button1.Text = "Kontynuuj";
                        fazaszkolenia = false;

                    }
                    else
                    {
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
                else
                {
                    label1.Font = new Font(label1.Font.FontFamily, 20);
                    label1.Text = "   Błędny dźwięk! Kliknij w przycisk ponów, żeby spróbować ponownie.";
                    zegar.Stop();
                    button1.Text = "Ponów";
                }

                dzwiekwtescie = 0;
            }
            else if (przycisk.Name == "Błędny")
            {
                button1.Visible = true;
                
                if (stoper.IsRunning)
                {
                    if (dzwiekwtescie != 1)
                    {
                        label1.Font = new Font(label1.Font.FontFamily, 20);
                        label1.Text = "     Dobrze - był to błędny dźwięk, kliknij przycisk by kontynuuwać";
                        zegar.Stop();
                        button1.Text = "Kontynuuj";
                    }
                    else
                    {
                        label1.Font = new Font(label1.Font.FontFamily, 16);
                        label1.Text = "Błąd - był to poprawny dźwięk, kliknij w przycisk ponów, żeby spróbować ponownie.";
                        zegar.Stop();
                        button1.Text = "Ponów";
                    }
                }
                else
                {
                    label1.Font = new Font(label1.Font.FontFamily, 20);
                    label1.Text = "Za szybko, kliknij w przycisk ponów, żeby spróbować ponownie.";
                    zegar.Stop();
                    button1.Text = "Ponów";
                }
            }
            stoper.Stop();  // asekuracja, zeby nie nachodzily na siebie testy
        }
    }
}
