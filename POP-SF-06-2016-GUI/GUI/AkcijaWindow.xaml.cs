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
    /// Interaction logic for AkcijaWindow.xaml
    /// </summary>
    public partial class AkcijaWindow : Window
    {
        private ICollectionView view;

        public AkcijaWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Akcija);

            dgAkcija.ItemsSource = view;
            dgAkcija.DataContext = this;
            dgAkcija.IsSynchronizedWithCurrentItem = true;
            dgAkcija.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);


        }

        private void NovaAkcija()
        {
            var novaAkcija = new Akcija()
            {
                Id = 2,
                Popust = 30,
                DatumPocetka = new DateTime(),
                DatumZavrsetka = new DateTime()
            };
            var listaAkcija = Projekat.Instance.Akcija;
        }
       
        private void btnDodajAkciju_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIzmeniAkciju_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObrisiAkciju_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgAkcija_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id" || e.Column.Header.ToString() == "Obrisan")
            {
                e.Cancel = true;
            }
        }
    }
}
