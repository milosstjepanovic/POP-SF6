using POP_SF_06_2016_GUI.Model;
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
    public class ProdajaNamestaja : INotifyPropertyChanged
    {
        public const double PDV = 0.2;
        
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private string brojRacuna;
        private DateTime datumProdaje;        
        private string kupac;
        private double ukupnaCena;
        private int uslugaId;
        private DodatnaUsluga dodatnaUsluga;
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

        public string BrojRacuna
        {
            get { return brojRacuna; }
            set
            {
                brojRacuna = value;
                OnPropertyChanged("BrojRacuna");
            }
        }

        public DateTime DatumProdaje
        {
            get { return datumProdaje; }
            set
            {
                datumProdaje = value;
                OnPropertyChanged("DatumProdaje");
            }
        }            

        public string Kupac
        {
            get { return kupac; }
            set
            {
                kupac = value;
                OnPropertyChanged("Kupac");
            }
        }        

        public double UkupnaCena
        {
            get { return ukupnaCena; }
            set
            {
                ukupnaCena = value;
                OnPropertyChanged("UkupnaCena");
            }
        }

        public int UslugaId
        {
            get { return uslugaId; }
            set
            {
                uslugaId = value;
                OnPropertyChanged("UslugaId");
            }
        }
        
        public DodatnaUsluga DodatnaUsluga
        {
            get
            {
                if (dodatnaUsluga == null)
                {
                    dodatnaUsluga = DodatnaUsluga.GetById(uslugaId);
                }
                return dodatnaUsluga;
            }
            set
            {
                dodatnaUsluga = value;
                UslugaId = dodatnaUsluga.Id;
                OnPropertyChanged("DodatnaUsluga");
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
        
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new ProdajaNamestaja()
            {
                id = Id,
                brojRacuna = BrojRacuna,
                datumProdaje = DatumProdaje,
                kupac = Kupac,
                ukupnaCena = UkupnaCena,
                uslugaId = UslugaId,
                obrisan = Obrisan
            };
        }


        public static double IzracunajUkupnuCenu()
        {
            double ukupnaCena = 0;
            double cenaKomad;
            double cenaSaPdv = 0;

            foreach (ProdajaStavke stavke in Projekat.Instance.ProdajaStavke)
            {

                // MOJ NACIN,  BEZ SPOLJNIH KLJUCENA AKCIJA ID i DODATNE USLUGE
                if (stavke.Akcija != null)
                {
                    cenaKomad = stavke.Cena - (stavke.Cena * (stavke.Akcija.Popust / 100));
                    cenaSaPdv = cenaKomad + (cenaKomad * PDV);
                }
                else
                {
                    cenaKomad = stavke.Cena;
                    //ukupnaCena += cenaKomad * stavke.Kolicina;
                }
                


                    /*
                    try
                    {
                        cenaKomad = stavke.Cena - (stavke.Cena / stavke.Akcija.Popust);
                    }
                    catch (Exception)
                    {
                        cenaKomad = stavke.Cena;
                    }
                    */
                
                ukupnaCena += cenaSaPdv * stavke.Kolicina;
            }
            return ukupnaCena;
        }


        #region Database
        public static ObservableCollection<ProdajaNamestaja> UcitajSveProdaje()
        {
            var prodaje = new ObservableCollection<ProdajaNamestaja>();

            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))

            {

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM PRODAJA WHERE OBRISAN = 0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "ProdajaNamestaja");  //izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["ProdajaNamestaja"].Rows)
                {
                    var prodaja = new ProdajaNamestaja();
                    prodaja.Id = int.Parse(row["ID"].ToString());
                    prodaja.BrojRacuna = row["BR_RACUNA"].ToString();
                    prodaja.DatumProdaje = DateTime.Parse(row["DATUM"].ToString());
                    prodaja.Kupac = row["KUPAC"].ToString();
                    prodaja.UkupnaCena = double.Parse(row["UKUPNA_CENA"].ToString());
                    prodaja.UslugaId = int.Parse(row["ID_DODATNE_USLUGE"].ToString());
                    prodaja.Obrisan = bool.Parse(row["OBRISAN"].ToString());

                    //try
                    //{
                    //    prodaja.DodatnaUsluga = DodatnaUsluga.GetById(prodaja.uslugaId);
                    //}
                    //catch (Exception) { }

                    prodaje.Add(prodaja);
                }
            }
            return prodaje;
        }


        public static ProdajaNamestaja Dodaj(ProdajaNamestaja prodaja)
        {
            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"INSERT INTO PRODAJA (BR_RACUNA, DATUM, KUPAC, UKUPNA_CENA, ID_DODATNE_USLUGE, OBRISAN) " +
                                  $"VALUES (@BR_RACUNA, @DATUM, @KUPAC, @UKUPNA_CENA, @ID_DODATNE_USLUGE, 0);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("BR_RACUNA", prodaja.BrojRacuna);
                cmd.Parameters.AddWithValue("DATUM", prodaja.DatumProdaje);
                cmd.Parameters.AddWithValue("KUPAC", prodaja.Kupac);
                cmd.Parameters.AddWithValue("UKUPNA_CENA", prodaja.UkupnaCena);
                cmd.Parameters.AddWithValue("ID_DODATNE_USLUGE", prodaja.UslugaId);

                int newId = int.Parse(cmd.ExecuteScalar().ToString()); //ExecuteScalar izvrsava query
                prodaja.Id = newId;
            }
            Projekat.Instance.ProdajaNamestaja.Add(prodaja); //azuriram i stanje modela
            return prodaja;
        }

        
        public static void Izmeni(ProdajaNamestaja prodaja)
        {
            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE PRODAJA SET BR_RACUNA=@BR_RACUNA, DATUM=@DATUM, KUPAC=@KUPAC, " +
                                  "UKUPNA_CENA=@UKUPNA_CENA, ID_DODATNE_USLUGE=@ID_DODATNE_USLUGE, OBRISAN=@OBRISAN WHERE ID=@ID";

                cmd.Parameters.AddWithValue("ID", prodaja.Id);
                cmd.Parameters.AddWithValue("BR_RACUNA", prodaja.BrojRacuna);
                cmd.Parameters.AddWithValue("DATUM", prodaja.DatumProdaje);
                cmd.Parameters.AddWithValue("KUPAC", prodaja.Kupac);
                cmd.Parameters.AddWithValue("UKUPNA_CENA", prodaja.UkupnaCena);
                cmd.Parameters.AddWithValue("ID_DODATNE_USLUGE", prodaja.UslugaId);
                cmd.Parameters.AddWithValue("OBRISAN", prodaja.Obrisan);

                cmd.ExecuteNonQuery();

                //azuriram stanje modela
                foreach (var p in Projekat.Instance.ProdajaNamestaja)
                {
                    if (p.Id == prodaja.Id)
                    {
                        p.BrojRacuna = prodaja.BrojRacuna;
                        p.DatumProdaje = prodaja.DatumProdaje;
                        p.Kupac = prodaja.Kupac;
                        p.UkupnaCena = prodaja.UkupnaCena;
                        p.UslugaId = prodaja.UslugaId;
                        p.Obrisan = prodaja.Obrisan;
                        break;
                    }
                }
            }
        }

        public static void Obrisi(ProdajaNamestaja prodaja)
        {
            prodaja.Obrisan = true;
            Izmeni(prodaja);
        }        

        #endregion



    }
}
