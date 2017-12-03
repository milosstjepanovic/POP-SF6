using POP.Model;
using POP.Utils;
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
            view.Filter = FilterNeobrisanihKorisnika;

            dgKorisnik.ItemsSource = view;
            dgKorisnik.DataContext = this;
            dgKorisnik.IsSynchronizedWithCurrentItem = true;
            dgKorisnik.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private bool FilterNeobrisanihKorisnika(object obj)
        {
            return ((Korisnik)obj).Obrisan == false;
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
            if (IzabraniKorisnik == null)
            {
                MessageBox.Show("Morate izabrati neku stavku.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Korisnik kopijaKorisnika = (Korisnik)IzabraniKorisnik.Clone();

            var korisnikProzor = new AddChangeKorisnikWindow(kopijaKorisnika, AddChangeKorisnikWindow.TipOperacije.IZMENA);
            korisnikProzor.ShowDialog();
        }

        private void btnObrisiKorisnika_Click(object sender, RoutedEventArgs e)
        {
            var korisnikZaBrisanje = (Korisnik)dgKorisnik.SelectedItem;
            if (korisnikZaBrisanje == null)
            {
                MessageBox.Show("Morate izabrati neku stavku.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete korisnika: { korisnikZaBrisanje.Ime} { korisnikZaBrisanje.Prezime} ?",
                "Brisanje korisnika", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var lista = Projekat.Instance.Korisnik;

                foreach (var korisnik in lista)
                {
                    if (korisnik.Id == korisnikZaBrisanje.Id)
                    {
                        korisnik.Obrisan = true;
                        view.Refresh();
                    }
                }
                GenericSerializer.Serialize("korisnik.xml", lista);
            }
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgKorisnik_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

            if ((string)e.Column.Header == "Id" || (string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
        }
    }
}
