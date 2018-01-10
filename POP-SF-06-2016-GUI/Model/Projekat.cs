using POP.Utils;
using POP_SF_06_2016_GUI.Model;
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
        public const string CONNECTION_STRING = @"Integrated Security=true; Initial Catalog=POP_SF6; Data Source=(localdb)\MSSQLLocalDB";

        public static Projekat Instance { get; private set; } = new Projekat();

        
        public ObservableCollection<TipNamestaja> TipoviNamestaja { get; set; }
        public ObservableCollection<Namestaj> Namestaj { get; set; }
        public ObservableCollection<Korisnik> Korisnik { get; set; }
        public ObservableCollection<Akcija> Akcija { get; set; }
        public ObservableCollection<DodatnaUsluga> DodatnaUsluga { get; set; }
        public ObservableCollection<ProdajaNamestaja> ProdajaNamestaja { get; set; }
        public ObservableCollection<ProdajaStavke> ProdajaStavke { get; set; }
       


        private Projekat()
        {
            

            TipoviNamestaja = TipNamestaja.UcitajSveTipoveNamestaja();
            Namestaj = Model.Namestaj.UcitajSveNamestaje();

            Korisnik = Model.Korisnik.UcitajSveKorisnike();
            Akcija = Model.Akcija.UcitajSveAkcije();

            DodatnaUsluga = Model.DodatnaUsluga.UcitajSveDodatneUsluge();
            
            //AkcijaStavke = AkcijaStavke
            //AkcijaStavke = POP_SF_06_2016_GUI.Model.AkcijaStavke.UcitajSveStavke();

            
            ProdajaNamestaja = Model.ProdajaNamestaja.UcitajSveProdaje();
            

            

            ProdajaStavke = new ObservableCollection<ProdajaStavke>();

            
        }        
    }
}
