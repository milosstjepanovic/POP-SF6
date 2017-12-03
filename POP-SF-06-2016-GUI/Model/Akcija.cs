using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP.Model
{
    public class Akcija : INotifyPropertyChanged, ICloneable
    {

        private int id;
        private decimal popust;
        private DateTime datumPocetka;
        private DateTime datumZavrsetka;
        private int namestajId;
        private bool obrisan;

        public event PropertyChangedEventHandler PropertyChanged;
        
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public decimal Popust
        {
            get { return popust; }
            set
            {
                popust = value;
                OnPropertyChanged("Popust");
            }
        }

        public DateTime DatumPocetka
        {
            get { return datumPocetka; }
            set
            {
                datumPocetka = value;
                OnPropertyChanged("DatumPocetka");
            }
        }

        public DateTime DatumZavrsetka
        {
            get { return datumZavrsetka; }
            set
            {
                datumZavrsetka = value;
                OnPropertyChanged("DatumZavrsetka");
            }
        }       

        public int NamestajId
        {
            get { return namestajId; }
            set
            {
                namestajId = value;
                OnPropertyChanged("NamestajId");
            }
        }

        private Namestaj namestajPopust;
        [XmlIgnore]
        public Namestaj NamestajPopust
        {
            get
            {
                if (namestajPopust == null)
                {
                    namestajPopust = Namestaj.GetById(NamestajId);
                }
                return namestajPopust;
            }
            set
            {
                namestajPopust = value;
                namestajId = namestajPopust.Id;
                OnPropertyChanged("NamestajPopust");
            }
        }

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }

        public override string ToString()
        {
            return $"{Popust}, {DatumPocetka}, {DatumZavrsetka}, {namestajPopust.Naziv}";
        }


        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static Akcija GetById(int id)
        {
            foreach (var akcija in Projekat.Instance.Akcija)
            {
                if (akcija.Id == id)
                {
                    return akcija;
                }
            }
            return null;

            //ovo zamenjuje sve ovo gore iznad (lambda funkcija)
            //return Projekat.Instance.TipoviNamestaja.SingleOrDefault(x => x.Id == id);
        }

        public object Clone()
        {
            return new Akcija
            {
                id = Id,
                popust = Popust,
                datumPocetka = DatumPocetka,
                datumZavrsetka = DatumZavrsetka,
                obrisan = Obrisan
            };
        }
    }
}
