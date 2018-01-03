using POP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_06_2016_GUI.Model
{
    public class AkcijaStavke : INotifyPropertyChanged
    {
        private int idAkcije;

        public int IdAkcije
        {
            get { return idAkcije; }
            set
            {
                idAkcije = value;
                OnPropertyChanged("IdAkcije");
            }
        }

        private int idNamestaja;

        public int IdNamestaja
        {
            get { return idNamestaja; }
            set
            {
                idNamestaja = value;
                OnPropertyChanged("IdNamestaja");
            }
        }


        private bool obrisan;

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


        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public object Clone()
        {
            return new AkcijaStavke()
            {
                idAkcije = IdAkcije,
                idNamestaja = IdNamestaja,
                obrisan = Obrisan
            };
        }


        #region Database
        public static ObservableCollection<AkcijaStavke> UcitajSveStavke(Akcija n)
        {
            var stavke = new ObservableCollection<AkcijaStavke>();

            using (SqlConnection con = new SqlConnection(Projekat.CONNECTION_STRING))

            {

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT NAMESTAJ.NAZIV, KOLICINA_MAG, CENA FROM NAMESTAJ, AKCIJA_STAVKE, AKCIJA " +
                                "WHERE NAMESTAJ.ID = AKCIJA_STAVKE.NAMESTAJ_ID AND AKCIJA_STAVKE.AKCIJA_ID = AKCIJA.ID AND AKCIJA.ID = 1";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "AkcijaStavke");  //izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["AkcijaStavke"].Rows)
                {
                    var akcijaStavke = new AkcijaStavke();
                    akcijaStavke.IdAkcije = int.Parse(row["AKCIJA_ID"].ToString());
                    akcijaStavke.IdNamestaja = int.Parse(row["NAMESTAJ_ID"].ToString());
                    akcijaStavke.Obrisan = bool.Parse(row["OBRISAN"].ToString());

                    stavke.Add(akcijaStavke);
                }
            }
            return stavke;
        }
        #endregion



















        
    }
}
