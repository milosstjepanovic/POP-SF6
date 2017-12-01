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

        public TipNamestaja IzabraniTipNamestaja { get; set; }

        public TipNamestajaWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.TipoviNamestaja);

            dgTipoviNamestaja.ItemsSource = view;
            dgTipoviNamestaja.DataContext = this;
            dgTipoviNamestaja.IsSynchronizedWithCurrentItem = true;
            dgTipoviNamestaja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

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
            //var izabraniTipNamestaja = (TipNamestaja)dgTipoviNamestaja.SelectedItem;

            TipNamestaja kopijaTipaNamestaja = (TipNamestaja)IzabraniTipNamestaja.Clone();

            var tipNamestajaProzor = new AddTipNamestajaW(kopijaTipaNamestaja, AddTipNamestajaW.TipOperacije.IZMENA);
            tipNamestajaProzor.ShowDialog();
        }

        private void btnObrisiNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var tipNamestajaZaBrisanje = (TipNamestaja)dgTipoviNamestaja.SelectedItem;

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete tip namestaj: { tipNamestajaZaBrisanje.Naziv}?",
                "Brisanje namestaja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var lista = Projekat.Instance.TipoviNamestaja;

                foreach (var tipNamestaja in lista)
                {
                    if (tipNamestaja.Id == tipNamestajaZaBrisanje.Id)
                    {
                        tipNamestaja.Obrisan = true;
                    }
                }
                Projekat.Instance.TipoviNamestaja = lista;
            }
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgTipoviNamestaja_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string sakrijKolone = (string)e.Column.Header;
            if (sakrijKolone == "Id")
            {
                e.Cancel = true;
            }
                        
            if (sakrijKolone == "Obrisan")
            {
                e.Cancel = true;
            }
        }
    }
}
