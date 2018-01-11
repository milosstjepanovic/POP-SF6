using POP.Model;
using POP_SF_06_2016_GUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POP_SF_06_2016_GUI.GUI
{
    /// <summary>
    /// Interaction logic for AddProdajaWindow.xaml
    /// </summary>
    public partial class AddProdajaWindow : Window
    {
        private ICollectionView viewNamestaj;
        private ICollectionView viewKorpa;

        public Namestaj IzabraniNamestaj { get; set; }
        public ProdajaStavke IzabraneStavke { get; set; }

        ProdajaNamestaja prodaja;


        public AddProdajaWindow(ProdajaNamestaja prodaja)
        {
            InitializeComponent();
                       

            viewNamestaj = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
            viewNamestaj.Filter = FilterNamestaja;

            viewKorpa = CollectionViewSource.GetDefaultView(Projekat.Instance.ProdajaStavke);

            dgNamestaj.ItemsSource = viewNamestaj;
            dgNamestaj.DataContext = this;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            dgKorpa.ItemsSource = viewKorpa;
            dgKorpa.DataContext = this;
            dgKorpa.IsSynchronizedWithCurrentItem = true;
            dgKorpa.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            tbKupac.DataContext = prodaja;
            dpDatumPocetka.DataContext = prodaja;
            tbBrojRacuna.DataContext = prodaja;
            tbUkupnaCena.DataContext = prodaja;
            cmbUsluga.DataContext = prodaja;

            cmbUsluga.ItemsSource = Projekat.Instance.DodatnaUsluga;

            this.prodaja = prodaja;
            InicijalizujPodatke();

        }

        private void InicijalizujPodatke()
        {
            DateTime datum = DateTime.Now;
            tbKupac.Text = "";
            prodaja.DatumProdaje = datum;
            prodaja.Id = Projekat.Instance.ProdajaNamestaja.Count + 1;
            prodaja.BrojRacuna = "R" + prodaja.Id + "/2018";
            tbKolicina.Text = "1";
            prodaja.UkupnaCena = ProdajaNamestaja.IzracunajUkupnuCenu();

        }

        private bool FilterNamestaja(object obj)
        {
            return ((Namestaj)obj).Obrisan == false;
        }

        //private bool FilterKorpe(object obj)
        //{
        //    return ((ProdajaStavke)obj).Obrisan == false;
        //}



        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (IzabraniNamestaj != null)
            {
                if (IzabraniNamestaj.KolicinaUMagacinu > 0)
                {
                    try
                    {
                        int kolicina = Int32.Parse(tbKolicina.Text);
                        if (kolicina > IzabraniNamestaj.KolicinaUMagacinu)
                        {
                            MessageBox.Show("Uneli ste vecu kolicinu nego sto ima na stanju!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        ProdajaStavke prodajaStavke = new ProdajaStavke(IzabraniNamestaj.Id, IzabraniNamestaj.Naziv, kolicina,
                            IzabraniNamestaj.Cena, 0, 0, IzabraniNamestaj.Akcija);

                        if (ProdajaStavke.ProveriDaliStavkaPostoji(prodajaStavke) == true)
                        {
                            ProdajaStavke.PovecajKolicinu(prodajaStavke, kolicina);
                        }
                        else
                        {
                            Projekat.Instance.ProdajaStavke.Add(prodajaStavke);
                        }

                        Namestaj.PovecajSmanjiKolicinu(IzabraniNamestaj.Id, false, kolicina);
                        Namestaj.Izmeni(IzabraniNamestaj);

                        //dgKorpa.ItemsSource = prodaja;
                        viewKorpa.Refresh();
                        viewNamestaj.Refresh();
                        prodaja.UkupnaCena = ProdajaNamestaja.IzracunajUkupnuCenu();
                        tbKolicina.Text = "1";
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Kolicina nije validna!");
                    }
                }
                else
                {
                    MessageBox.Show("Nema vise izabranog namestaja na lageru!", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Niste selektovali nijedan namestaj!", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    

        private void btnUkloni_Click(object sender, RoutedEventArgs e)
        {
            if (IzabraneStavke != null)
            {
                ProdajaStavke prodajaStavke = new ProdajaStavke(IzabraneStavke.Id, IzabraneStavke.Naziv, IzabraneStavke.Kolicina,
                               IzabraneStavke.Cena, IzabraneStavke.UkupnaCena, IzabraneStavke.CenaSaPopustom, IzabraneStavke.Akcija);

                Namestaj.PovecajSmanjiKolicinu(IzabraneStavke.Id, true, IzabraneStavke.Kolicina);
                Projekat.Instance.ProdajaStavke.Remove(prodajaStavke);

                ProdajaNamestaja.Obrisi(prodaja);

                ObrisiProdajaStavke();

                

                viewNamestaj.Refresh();
                viewKorpa.Refresh();
            }
            else
            {
                MessageBox.Show("Niste selektovali nijednu stavku!", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            if (prodaja.DodatnaUsluga != null)
            {
                prodaja.UkupnaCena = prodaja.UkupnaCena + prodaja.DodatnaUsluga.Cena;
                
                ProdajaNamestaja.Dodaj(prodaja);
                DodajProdajaStavke();

                Projekat.Instance.ProdajaStavke.Clear();
                Close();

            } else
            {
                prodaja.UkupnaCena = prodaja.UkupnaCena;
                //Projekat.Instance.ProdajaNamestaja.Add(prodaja);

                ProdajaNamestaja.Dodaj(prodaja);
                DodajProdajaStavke();

                Projekat.Instance.ProdajaStavke.Clear();
                Close();
            }
        }


        private void DodajProdajaStavke()
        {
            foreach (ProdajaStavke stavke in Projekat.Instance.ProdajaStavke)
            {
                ProdajaStavke.DodajStavke(prodaja.Id, stavke.Id, stavke.Kolicina);
            }
        }

        private void ObrisiProdajaStavke()
        {
            foreach (ProdajaStavke stavke in Projekat.Instance.ProdajaStavke)
            {
                ProdajaStavke.ClearTable(prodaja.Id);
            }
        }


        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgNamestaj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string sakrij = (string)e.Column.Header;
            if (sakrij == "Id" || sakrij == "TipNamestaja" || sakrij == "TipNamestajaId" || sakrij == "AkcijaId"
                || sakrij == "Obrisan")
            {
                e.Cancel = true;
            }
        }

        private void dgKorpa_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id")
            {
                e.Cancel = true;
            }
        }
    }
}
