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
    public class Akcija : INotifyPropertyChanged, ICloneable
    {

        private int id;
        private string naziv;
        private double popust;
        private DateTime datumPocetka;
        private DateTime datumZavrsetka;
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

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        public double Popust
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
            return $"{Popust}" + "% do " + $"{DatumZavrsetka}";
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

        public static void OcistiAkcije()
        {
            foreach (Akcija akcija in Projekat.Instance.Akcija)
            {
                if (akcija.DatumZavrsetka < DateTime.Now)
                {
                    Projekat.Instance.Akcija.Remove(akcija);
                    Obrisi(akcija);
                }
            }
        }

        public object Clone()
        {
            return new Akcija
            {
                id = Id,
                naziv = Naziv,
                popust = Popust,
                datumPocetka = DatumPocetka,
                datumZavrsetka = DatumZavrsetka,
                obrisan = Obrisan
            };
        }


        #region Database
        public static ObservableCollection<Akcija> UcitajSveAkcije()
        {
            var akcije = new ObservableCollection<Akcija>();

            //using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP_SF6"].ConnectionString))

            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM AKCIJA WHERE OBRISAN = 0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Akcija");  //izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["Akcija"].Rows)
                {
                    var akcija = new Akcija();
                    akcija.Id = int.Parse(row["ID"].ToString());
                    akcija.Naziv = row["NAZIV"].ToString();
                    akcija.DatumPocetka = DateTime.Parse(row["DATUM_OD"].ToString());
                    akcija.DatumZavrsetka = DateTime.Parse(row["DATUM_DO"].ToString());
                    akcija.Popust = int.Parse(row["POPUST"].ToString());
                    akcija.Obrisan = bool.Parse(row["OBRISAN"].ToString());

                    akcije.Add(akcija);
                }
            }
            return akcije;
        }


        public static Akcija Dodaj(Akcija akcija)
        {
            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"INSERT INTO AKCIJA (NAZIV, DATUM_OD, DATUM_DO, POPUST, OBRISAN) " +
                                  $"VALUES (@NAZIV, @DATUM_OD, @DATUM_DO, @POPUST, 0);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("NAZIV", akcija.Naziv);
                cmd.Parameters.AddWithValue("DATUM_OD", akcija.DatumPocetka);
                cmd.Parameters.AddWithValue("DATUM_DO", akcija.DatumZavrsetka);
                cmd.Parameters.AddWithValue("POPUST", akcija.Popust);

                int newId = int.Parse(cmd.ExecuteScalar().ToString()); //ExecuteScalar izvrsava query
                akcija.Id = newId;
            }
            Projekat.Instance.Akcija.Add(akcija); //azuriram i stanje modela
            return akcija;
        }

        public static void Izmeni(Akcija akcija)
        {
            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE AKCIJA SET NAZIV=@NAZIV, DATUM_OD=@DATUM_OD, DATUM_DO=@DATUM_DO, " +
                                  "POPUST=@POPUST, OBRISAN=@OBRISAN WHERE ID=@ID";
                cmd.Parameters.AddWithValue("ID", akcija.Id);
                cmd.Parameters.AddWithValue("NAZIV", akcija.Naziv);
                cmd.Parameters.AddWithValue("DATUM_OD", akcija.DatumPocetka);
                cmd.Parameters.AddWithValue("DATUM_DO", akcija.DatumZavrsetka);
                cmd.Parameters.AddWithValue("POPUST", akcija.Popust);
                cmd.Parameters.AddWithValue("OBRISAN", akcija.Obrisan);

                cmd.ExecuteNonQuery();

                //azuriram stanje modela
                foreach (var ak in Projekat.Instance.Akcija)
                {
                    if (ak.Id == akcija.Id)
                    {
                        ak.Naziv = akcija.Naziv;
                        ak.DatumPocetka = akcija.DatumPocetka;
                        ak.DatumZavrsetka = akcija.DatumZavrsetka;
                        ak.Popust = akcija.Popust;
                        ak.Obrisan = akcija.Obrisan;
                        break;
                    }
                }
            }
        }

        public static void Obrisi(Akcija akcija)
        {
            akcija.Obrisan = true;
            Izmeni(akcija);
        }


        #endregion 
    }
}
