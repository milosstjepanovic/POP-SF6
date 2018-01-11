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
        private CollectionViewSource cvs;

        public ProdajaNamestaja IzabranaProdaja { get; set; }

        public ProdajaWindow()
        {
            InitializeComponent();
            cvs = new CollectionViewSource();
            cvs.Source = Projekat.Instance.ProdajaNamestaja;

            view = cvs.View;
            view.Filter = FilterNeobrisanihProdaja;

            dgProdajaNamestaja.ItemsSource = view;
            dgProdajaNamestaja.DataContext = this;
            dgProdajaNamestaja.IsSynchronizedWithCurrentItem = true;
            dgProdajaNamestaja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            cmbPretraga.Items.Add("");
            cmbPretraga.Items.Add("Kupcu");
            cmbPretraga.Items.Add("Broju racuna");
            cmbPretraga.Items.Add("Datumu prodaje");
            cmbPretraga.SelectedIndex = 0;

            var prodajaSort = new List<string>();
            prodajaSort.Add("");
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
                    case "":
                        cmbSortiranje.SelectedIndex = 0;
                        dgProdajaNamestaja.ItemsSource = view;
                        break;
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

        private void Pretraga(object sender, FilterEventArgs e)
        {
            string cmb = cmbPretraga.SelectedItem.ToString();
            string tb = tbPretrazi.Text.ToLower();
            ProdajaNamestaja prodaja = (ProdajaNamestaja)e.Item;
            switch (cmb)
            {
                case "":

                    break;
                case "Kupcu":
                    e.Accepted = prodaja.Kupac.ToString().ToLower().Contains(tb);
                    break;
                case "Broju racuna":
                    e.Accepted = prodaja.BrojRacuna.ToString().ToLower().Contains(tb);
                    break;
                case "Datumu prodaje":
                    e.Accepted = prodaja.DatumProdaje.ToString().ToLower().Contains(tb);
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
