using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP.Model
{
    public enum TipKorisnika
    {
        Administrator,
        Prodavac
    }
     public class Korisnik : INotifyPropertyChanged, ICloneable
    {

        private int id;
        private string ime;
        private string prezime;
        private string korisnickoIme;
        private string lozinka;
        private TipKorisnika tipKorisnika;
        private bool obrisan;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }

        public string Prezime
        {
            get { return prezime; }
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }
        
        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set
            {
                korisnickoIme = value;
                OnPropertyChanged("KorisnickoIme");
            }
        }
        
        public string Lozinka
        {
            get { return lozinka; }
            set
            {
                lozinka = value;
                OnPropertyChanged("Lozinka");
            }
        }

        public TipKorisnika TipKorisnika
        {
            get { return tipKorisnika; }
            set
            {
                tipKorisnika = value;
                OnPropertyChanged("TipKorisnika");
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

        public event PropertyChangedEventHandler PropertyChanged;
        
        public override string ToString()
        {
            return $"{Ime}, {Prezime}, {KorisnickoIme}, {Lozinka}, {TipKorisnika}";
        }

        
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new Korisnik
            {
                id = Id,
                ime = Ime,
                prezime = Prezime,
                korisnickoIme = KorisnickoIme,
                lozinka = Lozinka,
                tipKorisnika = TipKorisnika,
                obrisan = Obrisan

            };
        }
    }       
}
