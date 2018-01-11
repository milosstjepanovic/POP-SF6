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
    /// Interaction logic for AkcijaWindow.xaml
    /// </summary>
    public partial class AkcijaWindow : Window
    {
        private ICollectionView view;
        private CollectionViewSource cvs;

        public Akcija IzabranaAkcija { get; set; }

        public AkcijaWindow()
        {
            InitializeComponent();
            cvs = new CollectionViewSource();
            cvs.Source = Projekat.Instance.Akcija;

            view = cvs.View;
            view.Filter = FilterNeobrisanihAkcija;

            dgAkcija.ItemsSource = view;
            dgAkcija.DataContext = this;
            dgAkcija.IsSynchronizedWithCurrentItem = true;
            dgAkcija.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            cmbPretraga.Items.Add("");
            cmbPretraga.Items.Add("Nazivu");
            cmbPretraga.Items.Add("Datumu pocetka");
            cmbPretraga.Items.Add("Datumu zavrsetka");
            cmbPretraga.SelectedIndex = 0;

            var akcijaSort = new List<string>();
            akcijaSort.Add("");
            akcijaSort.Add("Nazivu");
            akcijaSort.Add("Popustu");
            akcijaSort.Add("Dat. pocetka");
            akcijaSort.Add("Dat. zavrsetka");
            
            cmbSortiranje.ItemsSource = akcijaSort;
        }

        private bool FilterNeobrisanihAkcija(object obj)
        {
            return ((Akcija)obj).Obrisan == false;
        }

        private void btnDodajAkciju_Click(object sender, RoutedEventArgs e)
        {
            var praznaAkcija = new Akcija()
            {
                Popust = 0,
                DatumPocetka = DateTime.Now,
                DatumZavrsetka = DateTime.Now
            };
            var akcijaProzor = new AddChangeAkcijaWindow(praznaAkcija, AddChangeAkcijaWindow.TipOperacije.DODAVANJE);
            akcijaProzor.ShowDialog();
        }

        private void btnIzmeniAkciju_Click(object sender, RoutedEventArgs e)
        {
            if (IzabranaAkcija == null)
            {
                MessageBox.Show("Morate izabrati neku stavku.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Akcija kopijaAkcija = (Akcija)IzabranaAkcija.Clone();

            var akcijaProzor = new AddChangeAkcijaWindow(kopijaAkcija, AddChangeAkcijaWindow.TipOperacije.IZMENA);
            akcijaProzor.ShowDialog();
        }

        private void btnObrisiAkciju_Click(object sender, RoutedEventArgs e)
        {
            var akcijaZaBrisanje = (Akcija)dgAkcija.SelectedItem;
            if (akcijaZaBrisanje == null)
            {
                MessageBox.Show("Morate izabrati neku stavku.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete akciju: { akcijaZaBrisanje.Naziv}?",
                "Brisanje namestaja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var lista = Projekat.Instance.Akcija;

                foreach (var akcija in lista)
                {
                    if (akcija.Id == akcijaZaBrisanje.Id)
                    {
                        Akcija.Obrisi(akcija);
                        view.Refresh();
                    }
                }
            }
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgAkcija_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string sakrij = e.Column.Header.ToString();
            if (sakrij == "Id" || sakrij == "Obrisan")
            {
                e.Cancel = true;
            }
        }
        
        private void cmbSortiranje_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var akcijaSort = (string)cmbSortiranje.SelectedItem;

            if (akcijaSort != null)
            {
                switch (akcijaSort)
                {
                    case "":
                        cmbSortiranje.SelectedIndex = 0;
                        dgAkcija.ItemsSource = view;
                        break;
                    case "Nazivu":
                        dgAkcija.ItemsSource = Projekat.Instance.Akcija.OrderBy(x => x.Naziv);
                        break;
                    case "Popustu":
                        dgAkcija.ItemsSource = Projekat.Instance.Akcija.OrderBy(x => x.Popust);
                        break;
                    case "Dat. pocetka":
                        dgAkcija.ItemsSource = Projekat.Instance.Akcija.OrderBy(x => x.DatumPocetka);
                        break;
                    case "Dat. zavrsetka":
                        dgAkcija.ItemsSource = Projekat.Instance.Akcija.OrderBy(x => x.DatumZavrsetka);
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
            Akcija akcija = (Akcija)e.Item;
            switch (cmb)
            {
                case "":
                    break;
                case "Nazivu":
                    e.Accepted = akcija.Naziv.ToString().ToLower().Contains(tb);
                    break;
                case "Datumu pocetka":
                    e.Accepted = akcija.DatumPocetka.ToString().ToLower().Contains(tb);
                    break;
                case "Datumu zavrsetka":
                    e.Accepted = akcija.DatumZavrsetka.ToString().ToLower().Contains(tb);
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
