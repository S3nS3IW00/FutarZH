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
    /// Interaction logic for SzallitasAblak.xaml
    /// </summary>
    public partial class SzallitasAblak : Window
    {

        public Szallitas Szallitas { get; set; }

        public SzallitasAblak()
        {
            InitializeComponent();
        }

        private void Ok(object sender, RoutedEventArgs e)
        {
            if (CelcimSzoveg.Text == "" || SzallitottTomegSzoveg.Text == "" || IndulasDatuma.SelectedDate == null)
            {
                MessageBox.Show("Hibás adat(ok)!");
            }
            else
            {
                Szallitas = new Szallitas() { CelCim = CelcimSzoveg.Text, Indulas = IndulasDatuma.SelectedDate.Value, Tomeg = int.Parse(SzallitottTomegSzoveg.Text) };
                this.DialogResult = true;
            }
        }

        private void TomegSzovegEllenorzes(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
