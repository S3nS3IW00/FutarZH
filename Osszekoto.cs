using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutarProgram
{
    public class Osszekoto : Bindable
    {

        private Futar futar;

        public ObservableCollection<Futar> Futarok { get; } = new ObservableCollection<Futar>();
        public Futar Futar { get => futar; set { futar = value; ControlPropertyChanged(); } }

    }
}
