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
        private CollectionViewSource cvs;

        public Korisnik IzabraniKorisnik { get; set; }

        public KorisnikWindow()
        {
            InitializeComponent();

            cvs = new CollectionViewSource();
            cvs.Source = Projekat.Instance.Korisnik;

            view = cvs.View;
            view.Filter = FilterNeobrisanihKorisnika;

            dgKorisnik.ItemsSource = view;
            dgKorisnik.DataContext = this;
            dgKorisnik.IsSynchronizedWithCurrentItem = true;
            dgKorisnik.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            cmbPretraga.Items.Add("Imenu");
            cmbPretraga.Items.Add("Prezimenu");
            cmbPretraga.Items.Add("Kor.imenu");
            cmbPretraga.SelectedIndex = 0;

            var korisnikSort = new List<string>();
            korisnikSort.Add("Imenu");
            korisnikSort.Add("Prezimenu");
            korisnikSort.Add("Kor.imenu");
            korisnikSort.Add("Lozinci");
            korisnikSort.Add("Tipu korisnika");

            cmbSortiranje.ItemsSource = korisnikSort;
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
                        Korisnik.ObrisiKorisnika(korisnik);
                        view.Refresh();
                    }
                }
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
        
        private void cmbSortiranje_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var korisnikSort = (string)cmbSortiranje.SelectedItem;

            if (korisnikSort != null)
            {
                switch (korisnikSort)
                {
                    case "Imenu":
                        dgKorisnik.ItemsSource = Projekat.Instance.Korisnik.OrderBy(x => x.Ime);
                        break;
                    case "Prezimenu":
                        dgKorisnik.ItemsSource = Projekat.Instance.Korisnik.OrderBy(x => x.Prezime);
                        break;
                    case "Kor.imenu":
                        dgKorisnik.ItemsSource = Projekat.Instance.Korisnik.OrderBy(x => x.KorisnickoIme);
                        break;
                    case "Lozinci":
                        dgKorisnik.ItemsSource = Projekat.Instance.Korisnik.OrderBy(x => x.Lozinka);
                        break;
                    case "Tipu korisnika":
                        dgKorisnik.ItemsSource = Projekat.Instance.Korisnik.OrderBy(x => x.TipKorisnika);
                        break;
                    default:
                        break;
                }
            }
        }

        private void Pretraga(object sender, FilterEventArgs e)
        {
            string cmb = cmbPretraga.SelectedItem.ToString();
            string tb = tbPretrazi.Text.ToLower();
            Korisnik korisnik = (Korisnik)e.Item;
            switch (cmb)
            {
                case "Imenu":
                    e.Accepted = korisnik.Ime.ToString().ToLower().Contains(tb);
                    break;
                case "Prezimenu":
                    e.Accepted = korisnik.Prezime.ToString().ToLower().Contains(tb);
                    break;
                case "Kor.imenu":
                    break;
                default:
                    break;
            }
        }

        private void tbPretrazi_TextChanged(object sender, TextChangedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(Pretraga);
        }
    }
}
