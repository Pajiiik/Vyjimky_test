using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestVyjimky
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>();
            list.Clear();
            for (int i = 0; i < textBox1.Lines.Length; i++)
            {
                try
                {
                    if (int.TryParse(textBox1.Lines[i], out int value))
                    {
                        list.Add(value);
                    }
                    else
                    {
                        MessageBox.Show("Neplatná hodnota ignorována    " + textBox1.Lines[i], "Varování");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Špatný formát na řádku: " + (i + 1) + "Varování");
                }
                catch (OverflowException)
                {
                    MessageBox.Show("Zadáné čislo je moc velké: " + textBox1.Lines[i] + "Varování");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nečekaná chyba" + "Varování");
                }
            }

            if (list.Count != 0)
            {
                label3.Text = "A.P. záporných čísel: " + artimeticky_prumer(list).ToString();
            }
            else
            {
                MessageBox.Show("Neplatné hodnoty!", "Varování");
            }
        }

        public double artimeticky_prumer(List<int> list)
        {
            double pocet = 0;
            double delitel = 0;
            double vysledek = 0;
            foreach (double cislo in list)
            {
                if (cislo < 0)
                { 
                pocet = pocet + cislo;
                delitel++;
                }
            }
            checked
            {
                try
                {
                    vysledek = pocet / delitel;
                }
                catch (DivideByZeroException)
                {
                    MessageBox.Show("Dělení nulou");
                }
                return vysledek;
            }
        }
    }
}
