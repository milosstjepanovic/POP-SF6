using POP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_06_2016_GUI.Model
{
    public class ProdajaStavke
    {

        private int id;
        private string naziv;
        private int kolicina;
        private double cena;
        private double ukupnaCena;
        private double cenaSaPopustom;
        private Akcija akcija;
        //private bool obrisan;

        


        public int Id
        {
            get { return id; }
            set { id = value; }
        }        

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }        

        public int Kolicina
        {
            get { return kolicina; }
            set { kolicina = value; }
        }        

        public double Cena
        {
            get { return cena; }
            set { cena = value; }
        }              

        public double UkupnaCena
        {
            get { return cena * kolicina; }
            set { ukupnaCena = value; }
        }       

        public double CenaSaPopustom
        {
            get
            {
                //  MOJ NACIN,  BEZ SPOLJNIH KLJUCENA AKCIJA ID i DODATNE USLUGE
                if (akcija != null)
                {
                    return (cena - (cena * (akcija.Popust / 100.0))) * kolicina;
                }
                else
                {
                    return cena * kolicina;
                }
                

                /*
                try
                {
                    return (cena - (cena * (akcija.Popust / 100.0))) * kolicina;
                }
                catch (Exception)
                {
                }
                return cena * kolicina;
                */
                
            }
            set { cenaSaPopustom = value; }
        }        

        public Akcija Akcija
        {
            get { return akcija; }
            set { akcija = value; }
        }

        //public bool Obrisan
        //{
        //    get { return obrisan; }
        //    set { obrisan = value; }
        //}

        public ProdajaStavke()
        {

        }

        public ProdajaStavke(int id, string naziv, int kolicina, double cena, double ukupnaCena, double cenaSaPopustom, Akcija akcija)
        {
            this.id = id;
            this.naziv = naziv;
            this.kolicina = kolicina;
            this.cena = cena;
            this.ukupnaCena = ukupnaCena;
            this.cenaSaPopustom = cenaSaPopustom;
            this.akcija = akcija;
            //this.obrisan = obrisan;
        }
        
        public static void ObrisiStavkeProdaje()
        {
            foreach (ProdajaStavke prodaja in Projekat.Instance.ProdajaStavke)
            {
                Namestaj.PovecajSmanjiKolicinu(prodaja.Id, true, prodaja.Kolicina);
            }
            Projekat.Instance.ProdajaStavke.Clear();
        }

        public static bool ProveriDaliStavkaPostoji(ProdajaStavke prodajaStavke)
        {
            foreach (ProdajaStavke prodaja in Projekat.Instance.ProdajaStavke)
            {
                if (prodaja.Id == prodajaStavke.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public static void PovecajKolicinu(ProdajaStavke prodajaStavke, int kolicina)
        {
            foreach (ProdajaStavke prodaja in Projekat.Instance.ProdajaStavke)
            {
                if (prodaja.Id == prodajaStavke.Id)
                {
                    prodaja.Kolicina += kolicina;
                }
            }
        }
        

        #region Database
        public static ObservableCollection<ProdajaStavke> UcitajStavke(ProdajaNamestaja p)
        {

            ObservableCollection<ProdajaStavke> stavke = new ObservableCollection<ProdajaStavke>();

            using (SqlConnection connection = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                connection.Open();
                DataSet ds = new DataSet();

                SqlCommand prodajaItemCommand = connection.CreateCommand();
                prodajaItemCommand.CommandText = @"SELECT * FROM PRODAJA_STAVKE";

                SqlDataAdapter sqlda = new SqlDataAdapter();
                sqlda.SelectCommand = prodajaItemCommand;
                sqlda.Fill(ds, "ProdajaStavke");

                foreach (DataRow row in ds.Tables["ProdajaStavke"].Rows)
                {
                    if ((int)row["PRODAJA_ID"] == p.Id)
                    {
                        ProdajaStavke prodajaStavke = new ProdajaStavke();

                        Namestaj namestaj = Namestaj.GetById((int)row["NAMESTAJ_ID"]);

                        prodajaStavke.Kolicina = (int)row["PRODAJA_ID"];
                        prodajaStavke.Naziv = namestaj.Naziv;
                        prodajaStavke.Cena = namestaj.Cena;
                        prodajaStavke.Akcija = namestaj.Akcija;
                        //prodajaStavke.Obrisan = namestaj.Obrisan;

                        stavke.Add(prodajaStavke);
                    }
                }
            }
            return stavke;
        }


        public static void DodajStavke(int prodajaId, int namestajId, int kolicina)
        {
            using (SqlConnection conn = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = $"INSERT INTO PRODAJA_STAVKE (PRODAJA_ID, NAMESTAJ_ID, KOLICINA, OBRISAN) " +
                                  $"VALUES (@PRODAJA_ID, @NAMESTAJ_ID, @KOLICINA, 0);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("@PRODAJA_ID", prodajaId);
                cmd.Parameters.AddWithValue("@NAMESTAJ_ID", namestajId);
                cmd.Parameters.AddWithValue("@KOLICINA", kolicina);

                /*
                command.Parameters.Add(new SqlParameter("@PRODAJA_ID", prodajaid));
                command.Parameters.Add(new SqlParameter("@NAMESTAJ_ID", namestajid));
                command.Parameters.Add(new SqlParameter("@KOLICINA", kolicina));
                */


                cmd.ExecuteNonQuery();
            }
        }        

        public static void ClearTable(int prodajaId)
        {
            using (SqlConnection conn = new SqlConnection(Projekat.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"UPDATE PRODAJA_STAVKE SET OBRISAN=1 WHERE PRODAJA_ID=@PRODAJA_ID";

                cmd.Parameters.AddWithValue("PRODAJA_ID", prodajaId);

                cmd.ExecuteNonQuery();
            }
        }

        #endregion

    }
}
