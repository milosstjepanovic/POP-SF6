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
    /// Interaction logic for DodatnaUslugaWindow.xaml
    /// </summary>
    public partial class DodatnaUslugaWindow : Window
    {
        private ICollectionView view;
        private CollectionViewSource cvs;

        public DodatnaUsluga IzabranaUsluga { get; set; }
        

    public DodatnaUslugaWindow()
        {
            InitializeComponent();
            cvs = new CollectionViewSource();
            cvs.Source = Projekat.Instance.DodatnaUsluga;
            view = cvs.View;
            view.Filter = FilterNeobrisanihUsluga;

            dgDodatneUsluge.ItemsSource = view;
            dgDodatneUsluge.DataContext = this;
            dgDodatneUsluge.IsSynchronizedWithCurrentItem = true;
            dgDodatneUsluge.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);       

            var uslugeSort = new List<string>();
            uslugeSort.Add("");
            uslugeSort.Add("Nazivu");
            uslugeSort.Add("Ceni");           

            cmbSortiranje.ItemsSource = uslugeSort;
        }

        private bool FilterNeobrisanihUsluga(object obj)
        {
            return ((DodatnaUsluga)obj).Obrisan == false;

        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var praznaUsluga = new DodatnaUsluga()
            {
                Naziv = "",
                Cena = 0
            };
            var uslugaProzor = new AddChangeDodatnaUslugaWindow(praznaUsluga, AddChangeDodatnaUslugaWindow.TipOperacije.DODAVANJE);
            uslugaProzor.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (IzabranaUsluga == null)
            {
                MessageBox.Show("Morate izabrati neku stavku.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DodatnaUsluga kopijaUsluga = (DodatnaUsluga)IzabranaUsluga.Clone();
            
            var uslugaProzor = new AddChangeDodatnaUslugaWindow(kopijaUsluga, AddChangeDodatnaUslugaWindow.TipOperacije.IZMENA);
            uslugaProzor.ShowDialog();
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            var uslugaZaBrisanje = (DodatnaUsluga)dgDodatneUsluge.SelectedItem;
            if (uslugaZaBrisanje == null)
            {
                MessageBox.Show("Morate izabrati neku stavku.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete uslugu: { uslugaZaBrisanje.Naziv}?",
                "Brisanje usluge", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var lista = Projekat.Instance.DodatnaUsluga;

                foreach (var usluga in lista)
                {
                    if (usluga.Id == uslugaZaBrisanje.Id)
                    {
                        DodatnaUsluga.Obrisi(usluga);
                        view.Refresh();
                    }
                }
            }
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgDodatneUsluge_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id" || (string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
        }

        private void cmbSortiranje_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var uslugeSort = (string)cmbSortiranje.SelectedItem;

            if (uslugeSort != null)
            {
                switch (uslugeSort)
                {
                    case "":
                        cmbSortiranje.SelectedIndex = 0;
                        dgDodatneUsluge.ItemsSource = view;
                        break;
                    case "Nazivu":
                        dgDodatneUsluge.ItemsSource = Projekat.Instance.DodatnaUsluga.OrderBy(x => x.Naziv);
                        break;
                    case "Ceni":
                        dgDodatneUsluge.ItemsSource = Projekat.Instance.DodatnaUsluga.OrderBy(x => x.Cena);
                        break;                    
                    default:
                        break;
                }
            }
        }

        private void Pretraga(object sender, FilterEventArgs e)
        {            
            string tb = tbPretrazi.Text.ToLower();
            DodatnaUsluga usluga = (DodatnaUsluga)e.Item;
            
            e.Accepted = usluga.Naziv.ToString().ToLower().Contains(tb);
                  
        }

        private void tbPretrazi_TextChanged(object sender, TextChangedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(Pretraga);
        }
    }
}
