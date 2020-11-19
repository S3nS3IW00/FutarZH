using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutarProgram
{
    public class Szallitas : Bindable
    {

        private DateTime erkezes = DateTime.MinValue;

        public string CelCim { get; set; }
        public int Tomeg { get; set; }
        public DateTime Indulas { get; set; }
        public DateTime Erkezes { get => erkezes; set { erkezes = value; ControlPropertyChanged(); } }

    }
}
