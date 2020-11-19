using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FutarProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static Osszekoto Osszekoto { get; } = new Osszekoto();

        public MainWindow()
        {
            InitializeComponent();
            UjSzallitasGomb.IsEnabled = false;
            VisszaerkezettGomb.IsEnabled = false;

            this.DataContext = Osszekoto;
        }

        private void ListaValtozott(object sender, NotifyCollectionChangedEventArgs e)
        {
            GombEllenorzes();
        }

        private void UjFutar(object sender, RoutedEventArgs e)
        {
            FutarAblak ablak = new FutarAblak();
            ablak.ShowDialog();
            Osszekoto.Futarok.Add(ablak.Futar);
            ablak.Futar.Szallitasok.CollectionChanged += ListaValtozott;
        }

        private void UjSzallitas(object sender, RoutedEventArgs e)
        {
            SzallitasAblak ablak = new SzallitasAblak();
            ablak.ShowDialog();
            if (ablak.DialogResult == true)
            {
                Osszekoto.Futarok[Futarok.SelectedIndex].Szallitasok.Add(ablak.Szallitas);
            }
        }

        private void Visszaerkezett(object sender, RoutedEventArgs e)
        {
            Futar futar = (Futar)Futarok.SelectedItem;
            int i = 0;
            while (i < futar.Szallitasok.Count && futar.Szallitasok[i].Erkezes != DateTime.MinValue)
            {
                i++;
            }
            futar.Szallitasok[i].Erkezes = System.DateTime.Now;
            VisszaerkezettGomb.IsEnabled = false;
            UjSzallitasGomb.IsEnabled = true;
        }

        private void FutarKijeloles(object sender, SelectionChangedEventArgs e)
        {
            GombEllenorzes();
        }

        private void GombEllenorzes()
        {
            if (Futarok.SelectedItem != null)
            {
                Futar futar = (Futar)Futarok.SelectedItem;
                int i = 0;
                while (i < futar.Szallitasok.Count && futar.Szallitasok[i].Erkezes != DateTime.MinValue)
                {
                    i++;
                }
                UjSzallitasGomb.IsEnabled = i < futar.Szallitasok.Count ? false : true;
                VisszaerkezettGomb.IsEnabled = i < futar.Szallitasok.Count ? true : false;
            }
        }

    }
}
