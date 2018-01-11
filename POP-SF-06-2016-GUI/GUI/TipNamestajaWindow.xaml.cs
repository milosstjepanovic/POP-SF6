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
    /// Interaction logic for TipNamestajaWindow.xaml
    /// </summary>
    public partial class TipNamestajaWindow : Window
    {
        private ICollectionView view;
        private CollectionViewSource cvs;

        public TipNamestaja IzabraniTipNamestaja { get; set; }

        public TipNamestajaWindow()
        {
            InitializeComponent();
            cvs = new CollectionViewSource();
            cvs.Source = Projekat.Instance.TipoviNamestaja;

            view = cvs.View;
            view.Filter = FilterNeobrisanihTipova;

            dgTipoviNamestaja.ItemsSource = view;
            dgTipoviNamestaja.DataContext = this;
            dgTipoviNamestaja.IsSynchronizedWithCurrentItem = true;
            dgTipoviNamestaja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            var tipNamestajaSort = new List<string>();
            tipNamestajaSort.Add("");
            tipNamestajaSort.Add("Nazivu");            

            cmbSortiranje.ItemsSource = tipNamestajaSort;

        }

        private bool FilterNeobrisanihTipova(object obj)
        {
            return ((TipNamestaja)obj).Obrisan == false;

        }

        private void btnDodajNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var prazanTipNamestaja = new TipNamestaja()
            {
                Naziv = ""
            };
            var tipNamestajaProzor = new AddTipNamestajaW(prazanTipNamestaja, AddTipNamestajaW.TipOperacije.DODAVANJE);
            tipNamestajaProzor.ShowDialog();
        }

        private void btnIzmeniNamestaj_Click(object sender, RoutedEventArgs e)
        {
            if (IzabraniTipNamestaja == null)
            {
                MessageBox.Show("Morate izabrati neku stavku.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            TipNamestaja kopijaTipaNamestaja = (TipNamestaja)IzabraniTipNamestaja.Clone();

            var tipNamestajaProzor = new AddTipNamestajaW(kopijaTipaNamestaja, AddTipNamestajaW.TipOperacije.IZMENA);
            tipNamestajaProzor.ShowDialog();
        }

        private void btnObrisiNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var tipNamestajaZaBrisanje = (TipNamestaja)dgTipoviNamestaja.SelectedItem;

            if (tipNamestajaZaBrisanje == null)
            {
                MessageBox.Show("Morate izabrati neku stavku.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete tip namestaj: { tipNamestajaZaBrisanje.Naziv}?",
                "Brisanje namestaja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var lista = Projekat.Instance.TipoviNamestaja;

                foreach (var tipNamestaja in lista)
                {
                    if (tipNamestaja.Id == tipNamestajaZaBrisanje.Id)
                    {
                        TipNamestaja.Obrisi(tipNamestaja);
                        view.Refresh();
                        
                    }
                }               
            }
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgTipoviNamestaja_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string sakrijKolone = (string)e.Column.Header;
            if (sakrijKolone == "Id" || sakrijKolone == "Obrisan")
            {
                e.Cancel = true;
            }            
        }

        private void cmbSortiranje_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tipNamestajaSort = (string)cmbSortiranje.SelectedItem;

            if (tipNamestajaSort != null)
            {
                switch (tipNamestajaSort)
                {
                    case "":
                        cmbSortiranje.SelectedIndex = 0;
                        dgTipoviNamestaja.ItemsSource = view;
                        break;
                    case "Nazivu":
                        dgTipoviNamestaja.ItemsSource = Projekat.Instance.TipoviNamestaja.OrderBy(x => x.Naziv);
                        break;                    
                    default:
                        break;
                }
            }
        }

        private void Pretraga(object sender, FilterEventArgs e)
        {
            string tb = tbPretrazi.Text.ToLower();
            TipNamestaja tipNam = (TipNamestaja)e.Item;

            e.Accepted = tipNam.Naziv.ToString().ToLower().Contains(tb);

        }

        private void tbPretrazi_TextChanged(object sender, TextChangedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(Pretraga);
        }
    }
}
