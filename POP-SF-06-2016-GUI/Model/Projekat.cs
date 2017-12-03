using POP.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; private set; } = new Projekat();

        public ObservableCollection<TipNamestaja> TipoviNamestaja { get; set; }
        public ObservableCollection<Namestaj> Namestaj { get; set; }
        public ObservableCollection<Korisnik> Korisnik { get; set; }
        public ObservableCollection<Akcija> Akcija { get; set; }
        public ObservableCollection<DodatnaUsluga> DodatnaUsluga { get; set; }

        private Projekat()
        {
            TipoviNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tipovi_namestaja.xml");
            Namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
            Korisnik = GenericSerializer.Deserialize<Korisnik>("korisnik.xml");
            Akcija = GenericSerializer.Deserialize<Akcija>("akcija.xml");
            DodatnaUsluga = GenericSerializer.Deserialize<DodatnaUsluga>("dodatna_usluga.xml");

        }        
    }
}
