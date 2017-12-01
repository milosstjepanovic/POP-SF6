using POP.Model;
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
    /// Interaction logic for KorisnikWindow.xaml
    /// </summary>
    public partial class KorisnikWindow : Window
    {
        private ICollectionView view;

        public Korisnik IzabraniKorisnik { get; set; }

        public KorisnikWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Korisnik);

            dgKorisnik.ItemsSource = view;
            dgKorisnik.DataContext = this;
            dgKorisnik.IsSynchronizedWithCurrentItem = true;
            dgKorisnik.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void btnDodajKorisnika_Click(object sender, RoutedEventArgs e)
        {
            var prazanKorisnik = new Korisnik()
            {
                Ime = "",
                Prezime = "",
                KorisnickoIme = "",
                Lozinka = ""
            };
            var korisnikProzor = new AddChangeKorisnikWindow(prazanKorisnik, AddChangeKorisnikWindow.TipOperacije.DODAVANJE);
            korisnikProzor.ShowDialog();             
        }

        private void btnIzmeniKorisnika_Click(object sender, RoutedEventArgs e)
        {
            //var izabraniKorisnik = (Korisnik)dgKorisnik.SelectedItem;

            Korisnik kopijaKorisnika = (Korisnik)IzabraniKorisnik.Clone();


            var korisnikProzor = new AddChangeKorisnikWindow(kopijaKorisnika, AddChangeKorisnikWindow.TipOperacije.IZMENA);
            korisnikProzor.ShowDialog();
        }

        private void btnObrisiKorisnika_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgKorisnik_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
           
            string sakrijKolone = (string)e.Column.Header;
            if (sakrijKolone == "Id")
            {
                //e.Column["Obrisan"] = 
                e.Cancel = true;
            }
            if (sakrijKolone == "Obrisan")
            {
                e.Cancel = true;
            }
            
        }
    }
}
