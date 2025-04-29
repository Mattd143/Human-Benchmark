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
    public partial class Form3 : Form
    {

        private bool zaszybko = false;
        private char kolor = 'a';
        
        public Form3()
        {
            InitializeComponent();
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

        }

        private void PrzyciskKolory_click(object sender, EventArgs e)
        {
             
            Button przycisk = (Button)sender; // jezeli wcisniemy przycisk to wywola funkcje przez sendera i dzieki temu okreslimy ktory z nich zostal wcisniety
            if (przycisk.Name == "przyciskZielony")
            {
                kolor = 'z';
            }
            else if (przycisk.Name == "przyciskPomarancz")
            {
                kolor = 'p';
            }
            else if (przycisk.Name == "przyciskZolty")
            {
                kolor = 'ż';
            }
            else if (przycisk.Name == "przyciskNiebieski")
            {
                kolor = 'n';
            }



            if (zaszybko == true)     // warunek ktory wystepuje w przypadku zbyt szybkiego nacisniecia przycisku
            {
                label1.Font = new Font(label1.Font.FontFamily, 18);
                label1.Text = "Za szybko! Kliknij w przycisk, żeby spróbować ponownie.";
                // zegar.Stop();
            }
            else
            {

            }
            zaszybko = !zaszybko;

        }
    }
}
