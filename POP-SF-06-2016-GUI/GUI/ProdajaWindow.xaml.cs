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
    /// Interaction logic for ProdajaWindow.xaml
    /// </summary>
    public partial class ProdajaWindow : Window
    {
        private ICollectionView view;

        public ProdajaNamestaja IzabranaProdaja { get; set; }

        public ProdajaWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.ProdajaNamestaja);
            view.Filter = FilterNeobrisanihProdaja;

            dgProdajaNamestaja.ItemsSource = view;
            dgProdajaNamestaja.DataContext = this;
            dgProdajaNamestaja.IsSynchronizedWithCurrentItem = true;
            dgProdajaNamestaja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            var prodajaSort = new List<string>();
            prodajaSort.Add("Br. racuna");
            prodajaSort.Add("Datum prodaje");
            prodajaSort.Add("Kupac");
            
            cmbSortiranje.ItemsSource = prodajaSort;

        }

        private bool FilterNeobrisanihProdaja(object obj)
        {            
            return ((ProdajaNamestaja)obj).Obrisan == false;            
        }


        private void btnDodajProdaju_Click(object sender, RoutedEventArgs e)
        {
            var praznaProdaja = new ProdajaNamestaja();
            //{
            //    BrojRacuna = "",
            //    DatumProdaje = DateTime.Now,
            //    Kupac = "",
                
            //    UkupnaCena = 0
            //};
            AddProdajaWindow addProdajaW = new AddProdajaWindow(praznaProdaja);
            addProdajaW.ShowDialog();
        }

        private void btnIzmeniProdaju_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObrisiProdaju_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgProdaja_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string sakrijK = (string)e.Column.Header;
            if (sakrijK == "Id" || sakrijK == "UslugaId" || sakrijK == "Obrisan")
            {
                e.Cancel = true;
            }
        }
        
        private void cmbSortiranje_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var prodajaSort = (string)cmbSortiranje.SelectedItem;

            if (prodajaSort != null)
            {
                switch (prodajaSort)
                {
                    case "Br. racuna":
                        dgProdajaNamestaja.ItemsSource = Projekat.Instance.ProdajaNamestaja.OrderBy(x => x.BrojRacuna);
                        break;
                    case "Datum prodaje":
                        dgProdajaNamestaja.ItemsSource = Projekat.Instance.ProdajaNamestaja.OrderBy(x => x.DatumProdaje);
                        break;
                    case "Kupac":
                        dgProdajaNamestaja.ItemsSource = Projekat.Instance.ProdajaNamestaja.OrderBy(x => x.Kupac);
                        break;                    
                    default:
                        break;
                }
            }
        }
    }
}
