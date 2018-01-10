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
    public class DodatnaUsluga : INotifyPropertyChanged, ICloneable
    {
      
        private int id;
        private string naziv;
        private double cena;
        private bool obrisan;

        public DodatnaUsluga()
        {

        }

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
            return $"{Naziv}";
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new DodatnaUsluga
            {
                id = Id,
                naziv = Naziv,
                cena = Cena,
                obrisan = Obrisan
            };
        }
        
        public static DodatnaUsluga GetById(int id)
        {
            foreach (var usluga in (ObservableCollection<DodatnaUsluga>)DodatnaUsluga.UcitajSveDodatneUsluge())
            {
                if (usluga.Id == id)
                {
                    return usluga;
                }
            }
            return null;
        }
        

        /*
        public static DodatnaUsluga NadjiPoId(int id)
        {
            foreach (var usluga in Projekat.Instance.DodatnaUsluga)
            {
                if (usluga.Id == id)
                {
                    return usluga;
                }
            }
            return null;
        }
        */


        #region Database
        public static ObservableCollection<DodatnaUsluga> UcitajSveDodatneUsluge()
        {
            var dodatneUsluge = new ObservableCollection<DodatnaUsluga>();
            
            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))

            {

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM DODATNE_USLUGE WHERE OBRISAN = 0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "DodatnaUsluga");  //izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["DodatnaUsluga"].Rows)
                {
                    DodatnaUsluga du = new DodatnaUsluga();
                    du.Id = int.Parse(row["ID"].ToString());
                    du.Naziv = row["NAZIV"].ToString();
                    du.Cena = double.Parse(row["CENA"].ToString());
                    du.Obrisan = bool.Parse(row["OBRISAN"].ToString());

                    dodatneUsluge.Add(du);
                }
            }
            return dodatneUsluge;
        }


        public static DodatnaUsluga Dodaj(DodatnaUsluga du)
        {
            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"INSERT INTO DODATNE_USLUGE (NAZIV, CENA, OBRISAN) VALUES (@NAZIV, @CENA, 0);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("NAZIV", du.Naziv);
                cmd.Parameters.AddWithValue("CENA", du.Cena);

                int newId = int.Parse(cmd.ExecuteScalar().ToString()); //ExecuteScalar izvrsava query
                du.Id = newId;
            }
            Projekat.Instance.DodatnaUsluga.Add(du); //azuriram i stanje modela
            return du;
        }

        public static void Izmeni(DodatnaUsluga du)
        {
            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE DODATNE_USLUGE SET NAZIV=@Naziv, CENA=@Cena, OBRISAN=@Obrisan WHERE ID=@Id";
                cmd.Parameters.AddWithValue("ID", du.Id);
                cmd.Parameters.AddWithValue("NAZIV", du.Naziv);
                cmd.Parameters.AddWithValue("CENA", du.Cena);
                cmd.Parameters.AddWithValue("OBRISAN", du.Obrisan);

                cmd.ExecuteNonQuery();

                //azuriram stanje modela
                foreach (var dodatnaUsluga in Projekat.Instance.DodatnaUsluga)
                {
                    if (dodatnaUsluga.Id == du.Id)
                    {
                        dodatnaUsluga.Naziv = du.Naziv;
                        dodatnaUsluga.Cena = du.Cena;
                        dodatnaUsluga.Obrisan = du.Obrisan;
                        break;
                    }
                }
            }
        }

        public static void Obrisi(DodatnaUsluga du)
        {
            du.Obrisan = true;
            Izmeni(du);
        }


        #endregion 
    }
}
