using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutarProgram
{
    public class Futar
    {
        public string Nev { get; set; }
        public string SzallitoeszkozTipus { get; set; }
        public string SzallitoeszkozLeiras { get; set; }
        public int MaxTomeg { get; set; }
        public ObservableCollection<Szallitas> Szallitasok { get; } = new ObservableCollection<Szallitas>();

    }
}
