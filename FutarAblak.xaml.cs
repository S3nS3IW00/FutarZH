using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FutarProgram
{
    /// <summary>
    /// Interaction logic for FutarAblak.xaml
    /// </summary>
    public partial class FutarAblak : Window
    {

        public Futar Futar { get; set; }

        public FutarAblak()
        {
            InitializeComponent();

            Closing += Bezaras;
        }

        private void Bezaras(object sender, CancelEventArgs e)
        {
            if (this.DialogResult != true)
            {
                e.Cancel = true;
            }
        }

        private void TomegSzovegEllenorzes(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Ok(object sender, RoutedEventArgs e)
        {
            if(NevSzoveg.Text == "" || SzallitoeszkozTipusSzoveg.Text == "" || SzallitoeszkozLeirasSzoveg.Text == "" || MaxTomegSzoveg.Text == "")
            {
                MessageBox.Show("Hibás adat(ok)!");
            } else
            {
                Futar = new Futar() { Nev = NevSzoveg.Text, SzallitoeszkozTipus = SzallitoeszkozTipusSzoveg.Text, SzallitoeszkozLeiras = SzallitoeszkozLeirasSzoveg.Text, MaxTomeg = int.Parse(MaxTomegSzoveg.Text) };
                this.DialogResult = true;
            }
        }
    }
}
