using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP.Model
{
    public class Namestaj
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public double Cena { get; set; }
        public int KolicinaUMagacinu { get; set; }
        public TipNamestaja TipNamestaja { get; set; }
        public int Kolicina { get; set; }
        public Akcija Akcija { get; set; }
        public bool Obrisan { get; set; }        
    }
}
