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
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        private ICollectionView view;
        private CollectionViewSource cvs; 

        public Namestaj IzabraniNamestaj { get; set; }
        
        public NamestajWindow()
        {
            InitializeComponent();

            cvs = new CollectionViewSource();
            cvs.Source = Projekat.Instance.Namestaj;

            view = cvs.View;
            view.Filter = FilterNeobrisanogNamestaja;

            dgNamestaj.ItemsSource = view;
            dgNamestaj.DataContext = this;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            cmbPretraga.Items.Add("Nazivu");
            cmbPretraga.Items.Add("Tipu namestaja");
            cmbPretraga.SelectedIndex = 0;

            var namestajSort = new List<string>();
            namestajSort.Add("Nazivu");
            namestajSort.Add("Kolicini");
            namestajSort.Add("Ceni");
            namestajSort.Add("Tipu namestaja");
            namestajSort.Add("Akciji");

            cmbSortiranje.ItemsSource = namestajSort;
        }

        private bool FilterNeobrisanogNamestaja(object obj)
        {
            return ((Namestaj)obj).Obrisan == false;            
        }

        private void btnDodajNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var prazanNamestaj = new Namestaj()
            {
                Naziv = "",
                Cena = 0,
                KolicinaUMagacinu = 0
            };
            var namestajProzor = new AddNamestajWindow(prazanNamestaj, AddNamestajWindow.TipOperacije.DODAVANJE);
            namestajProzor.ShowDialog();
            //view.Refresh();
            }

        private void btnIzmeniNamestaj_Click(object sender, RoutedEventArgs e)
        {
            if (IzabraniNamestaj == null)
            {
                MessageBox.Show("Morate izabrati neku stavku.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Namestaj kopijaNamestaja = (Namestaj)IzabraniNamestaj.Clone();

            var namestajProzor = new AddNamestajWindow(kopijaNamestaja, AddNamestajWindow.TipOperacije.IZMENA);
            namestajProzor.ShowDialog();
            view.Refresh();
           }

        private void btnObrisiNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var namestajZaBrisanje = (Namestaj)dgNamestaj.SelectedItem;
            if (namestajZaBrisanje == null)
            {
                MessageBox.Show("Morate izabrati neku stavku.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete namestaj: { namestajZaBrisanje.Naziv}?",
                "Brisanje namestaja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var lista = Projekat.Instance.Namestaj;

                foreach (var namestaj in lista)
                {
                    if (namestaj.Id == namestajZaBrisanje.Id)
                    {
                        Namestaj.Obrisi(namestaj);
                        view.Refresh();
                    }
                }
            }
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgNamestaj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            
            string sakrijKolone = (string)e.Column.Header;
            if (sakrijKolone == "Id" || sakrijKolone == "TipNamestajaId" || sakrijKolone == "AkcijaId" || 
                sakrijKolone == "Obrisan")
            {                
                e.Cancel = true;
            }            
        }

        private void cmbSortiranje_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var namestajSort = (string)cmbSortiranje.SelectedItem;

            if (namestajSort != null)
            {
                switch (namestajSort)
                {
                    case "Nazivu":
                        dgNamestaj.ItemsSource = Projekat.Instance.Namestaj.OrderBy(x => x.Naziv);
                        break;
                    case "Kolicini":
                        dgNamestaj.ItemsSource = Projekat.Instance.Namestaj.OrderBy(x => x.KolicinaUMagacinu);
                        break;
                    case "Ceni":
                        dgNamestaj.ItemsSource = Projekat.Instance.Namestaj.OrderBy(x => x.Cena);
                        break;
                    case "Tipu namestaja":
                        dgNamestaj.ItemsSource = Projekat.Instance.Namestaj.OrderBy(x => x.TipNamestajaId);
                        break;
                    case "Akciji":
                        dgNamestaj.ItemsSource = Projekat.Instance.Namestaj.OrderBy(x => x.AkcijaId);
                        break;                   
                    default:
                        break;
                }
            }
        }

        private void Pretraga(object sender, FilterEventArgs e)
        {
            string cmb = cmbPretraga.SelectedItem.ToString();
            string tb = tbPretrazi.Text;
            Namestaj namestaj = e.Item as Namestaj;
            switch (cmb)
            {
                case "Nazivu":
                    e.Accepted = namestaj.Naziv.ToString().Contains(tb);
                    break;                
                case "Tipu namestaja":
                    e.Accepted = namestaj.TipNamestaja.Naziv.ToString().Contains(tb);
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
