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

        private Projekat()
        {
            TipoviNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tipovi_namestaja.xml");
            Namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
            Korisnik = GenericSerializer.Deserialize<Korisnik>("korisnik.xml");
            Akcija = GenericSerializer.Deserialize<Akcija>("akcija.xml");
        }
        
        /*
        public List<TipNamestaja> TipoviNamestaja
        {
            
        }

        public List<Namestaj> Namestaj
        {
            get
            {
                namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
                return namestaj;
            }
            set
            {
                namestaj = value;
                GenericSerializer.Serialize<Namestaj>("namestaj.xml", namestaj);
            }
        }

        public List<Korisnik> Korisnik
        {
            get
            {
                korisnik = GenericSerializer.Deserialize<Korisnik>("korisnik.xml");
                return korisnik;
            }
            set
            {
                korisnik = value;
                GenericSerializer.Serialize<Korisnik>("korisnik.xml", korisnik);
            }
        }

        public List<Akcija> Akcija
        {
            get
            {
                akcija = GenericSerializer.Deserialize<Akcija>("akcija.xml");
                return akcija;
            }
            set
            {
                akcija = value;
                GenericSerializer.Serialize<Akcija>("akcija.xml", akcija);
            }
        }*/
    }
}
