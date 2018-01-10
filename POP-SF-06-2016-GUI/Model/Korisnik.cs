using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        public static Korisnik GetById(int id)
        {
            foreach (var korisnik in Projekat.Instance.Korisnik)
            {
                if (korisnik.Id == id)
                {
                    return korisnik;
                }
            }
            return null;
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

        #region Database
        public static ObservableCollection<Korisnik> UcitajSveKorisnike()
        {
            var korisnici = new ObservableCollection<Korisnik>();

            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM KORISNIK WHERE OBRISAN = 0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Korisnik");  //izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["Korisnik"].Rows)
                {
                    var k = new Korisnik();
                    k.Id = int.Parse(row["ID"].ToString());
                    k.Ime = row["IME"].ToString();
                    k.Prezime = row["PREZIME"].ToString();
                    k.KorisnickoIme = row["KOR_IME"].ToString();
                    k.Lozinka = row["LOZINKA"].ToString();
                    
                    if(row["TIP_KORISNIKA"].ToString().Equals("True"))
                    {
                        k.TipKorisnika = TipKorisnika.Prodavac;
                    }
                    k.Obrisan = bool.Parse(row["OBRISAN"].ToString());

                    korisnici.Add(k);
                }
                return korisnici;
            }
        }

        public static Korisnik DodajKorisnika(Korisnik k)
        {
            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"INSERT INTO KORISNIK (IME, PREZIME, KOR_IME, LOZINKA, TIP_KORISNIKA, OBRISAN) " +
                                  $"VALUES (@IME, @PREZIME, @KOR_IME, @LOZINKA, @TIP_KORISNIKA, 0);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("IME", k.Ime);
                cmd.Parameters.AddWithValue("PREZIME", k.Prezime);
                cmd.Parameters.AddWithValue("KOR_IME", k.KorisnickoIme);
                cmd.Parameters.AddWithValue("LOZINKA", k.Lozinka);
                cmd.Parameters.AddWithValue("TIP_KORISNIKA", k.TipKorisnika);

                int newId = int.Parse(cmd.ExecuteScalar().ToString()); //ExecuteScalar izvrsava query
                k.Id = newId;
            }
            Projekat.Instance.Korisnik.Add(k);
            return k;
        }

        public static void IzmeniKorisnika(Korisnik k)
        {
            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE KORISNIK SET IME=@IME, PREZIME=@PREZIME, KOR_IME=@KOR_IME, LOZINKA=@LOZINKA, " +
                                  "TIP_KORISNIKA=@TIP_KORISNIKA, OBRISAN=@OBRISAN WHERE ID=@ID";

                cmd.Parameters.AddWithValue("ID", k.Id);
                cmd.Parameters.AddWithValue("IME", k.Ime);
                cmd.Parameters.AddWithValue("PREZIME", k.Prezime);
                cmd.Parameters.AddWithValue("KOR_IME", k.KorisnickoIme);
                cmd.Parameters.AddWithValue("LOZINKA", k.Lozinka);
                cmd.Parameters.AddWithValue("TIP_KORISNIKA", k.TipKorisnika);
                cmd.Parameters.AddWithValue("OBRISAN", k.Obrisan);
                cmd.ExecuteNonQuery();

                foreach (var korisnik in Projekat.Instance.Korisnik)
                {
                    if (korisnik.Id == k.Id)
                    {
                        korisnik.Ime = k.Ime;
                        korisnik.Prezime = k.Prezime;
                        korisnik.KorisnickoIme = k.KorisnickoIme;
                        korisnik.Lozinka = k.Lozinka;
                        korisnik.TipKorisnika = k.TipKorisnika;
                        korisnik.Obrisan = k.Obrisan;
                        break;
                    }
                }
            }
        }

        public static void ObrisiKorisnika(Korisnik k)
        {
            k.Obrisan = true;
            IzmeniKorisnika(k);
        }


        #endregion
    }
}
