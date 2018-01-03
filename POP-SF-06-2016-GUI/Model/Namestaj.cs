using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP.Model
{
    public class Namestaj : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
        private double cena;
        private int kolicinaUMagacinu;
        private int tipNamestajaId;
        //private Akcija akcija;
        private bool obrisan;
        private TipNamestaja tipNamestaja;


        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        
        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }
        
        public double Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
            }
        }
        
        public int KolicinaUMagacinu
        {
            get { return kolicinaUMagacinu; }
            set
            {
                kolicinaUMagacinu = value;
                OnPropertyChanged("KolicinaUMagacinu");
            }
        }

        [XmlIgnore]
        public TipNamestaja TipNamestaja
        {
            get
            {
                if (tipNamestaja == null)
                {
                    return TipNamestaja.GetById(tipNamestajaId);
                }
                return tipNamestaja;
            }
            set
            {
                tipNamestaja = value;
                TipNamestajaId = tipNamestaja.Id;
                OnPropertyChanged("TipNamestaja");
            }
        }

        public int TipNamestajaId
        {
            get { return tipNamestajaId; }
            set
            {
                tipNamestajaId = value;
                OnPropertyChanged("TipNamestajaId");
            }
        }      

        //public Akcija Akcija
        //{
        //    get { return akcija; }
        //    set
        //    {
        //        akcija = value;
        //        OnPropertyChanged("Akcija");
        //    }
        //}        

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

        public static Namestaj GetById(int id)
        {
            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                if (namestaj.Id == id)
                {
                    return namestaj;
                }
            }
            return null;

            //ovo zamenjuje sve ovo gore iznad (lambda funkcija)
            //return Projekat.Instance.TipoviNamestaja.SingleOrDefault(x => x.Id == id);
        }

        

        public override string ToString()
        {
            //return $"{Naziv}, {Cena}, {TipNamestaja.GetById(TipNamestajaId).Naziv }";
            return $"{Naziv}";

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
            return new Namestaj()
            {
                id = Id,
                naziv = Naziv,
                cena = Cena,
                kolicinaUMagacinu = kolicinaUMagacinu,
                tipNamestaja = TipNamestaja,
                tipNamestajaId = TipNamestajaId,
                obrisan = Obrisan
            };
        }



        #region Database
        public static ObservableCollection<Namestaj> UcitajSveNamestaje()
        {
            var namestaji = new ObservableCollection<Namestaj>();

            //using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP_SF6"].ConnectionString))

            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))

            {

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM NAMESTAJ WHERE OBRISAN = 0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Namestaj");  //izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["Namestaj"].Rows)
                {
                    var n = new Namestaj();
                    n.Id = int.Parse(row["ID"].ToString());
                    n.Naziv = row["NAZIV"].ToString();
                    n.KolicinaUMagacinu = int.Parse(row["KOLICINA_MAG"].ToString());
                    n.Cena = double.Parse(row["CENA"].ToString());
                    n.TipNamestajaId = int.Parse(row["TIP_NAMESTAJA"].ToString());
                    n.Obrisan = bool.Parse(row["OBRISAN"].ToString());

                    namestaji.Add(n);
                }
            }
            return namestaji;
        }


        public static Namestaj Dodaj(Namestaj n)
        {
            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"INSERT INTO NAMESTAJ (NAZIV, KOLICINA_MAG, CENA, TIP_NAMESTAJA, OBRISAN) " +
                                  $"VALUES (@NAZIV, @KOLICINA_MAG, @CENA, @TIP_NAMESTAJA, 0);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("NAZIV", n.Naziv);
                cmd.Parameters.AddWithValue("KOLICINA_MAG", n.KolicinaUMagacinu);
                cmd.Parameters.AddWithValue("CENA", n.Cena);
                cmd.Parameters.AddWithValue("TIP_NAMESTAJA", n.TipNamestajaId);
                
                int newId = int.Parse(cmd.ExecuteScalar().ToString()); //ExecuteScalar izvrsava query
                n.Id = newId;
            }
            Projekat.Instance.Namestaj.Add(n); //azuriram i stanje modela
            return n;
        }

        public static void Izmeni(Namestaj n)
        {
            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                
                cmd.CommandText = "UPDATE NAMESTAJ SET NAZIV=@NAZIV, KOLICINA_MAG=@KOLICINA_MAG, CENA=@CENA, " +
                                  "TIP_NAMESTAJA=@TIP_NAMESTAJA, OBRISAN=@OBRISAN WHERE ID=@ID";
                
                cmd.Parameters.AddWithValue("ID", n.Id);
                cmd.Parameters.AddWithValue("NAZIV", n.Naziv);
                cmd.Parameters.AddWithValue("KOLICINA_MAG", n.KolicinaUMagacinu);
                cmd.Parameters.AddWithValue("CENA", n.Cena);
                cmd.Parameters.AddWithValue("TIP_NAMESTAJA", n.TipNamestajaId);
                cmd.Parameters.AddWithValue("OBRISAN", n.Obrisan);
                
                cmd.ExecuteNonQuery();                

                //azuriram stanje modela
                foreach (var namestaj in Projekat.Instance.Namestaj)
                {
                    if (namestaj.Id == n.Id)
                    {
                        namestaj.Naziv = n.Naziv;
                        namestaj.KolicinaUMagacinu = n.KolicinaUMagacinu;
                        namestaj.Cena = n.Cena;
                        namestaj.TipNamestajaId = n.TipNamestajaId;
                        namestaj.Obrisan = n.Obrisan;
                        break;
                    }
                }
            }
        }

        public static void Obrisi(Namestaj n)
        {
            n.Obrisan = true;
            Izmeni(n);
        }


        #endregion
    }

}
