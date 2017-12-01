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

        public Namestaj IzabraniNamestaj { get; set; }
        
        public NamestajWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
            view.Filter = FilterNeobrisanogNamestaja;

            dgNamestaj.ItemsSource = view;
            dgNamestaj.DataContext = this;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

        }

        private bool FilterNeobrisanogNamestaja(object obj)
        {
            //1.
            /*
            if(((Namestaj).obj).Obrisan == false)
            {
                return true; //treba da se prikaze zadovoljava kriterijum
            }
            else
            {
                return false;
            }
            */

            //2. nacin
            return ((Namestaj)obj).Obrisan == false;

            //3.
            //return !((Namestaj).obj).Obrisan;
            
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
            }

        private void btnIzmeniNamestaj_Click(object sender, RoutedEventArgs e)
        {

            // vise ne treba
            //var izabraniNamestaj = (Namestaj)dgNamestaj.SelectedItem;

            Namestaj kopijaNamestaja = (Namestaj)IzabraniNamestaj.Clone();


            var namestajProzor = new AddNamestajWindow(kopijaNamestaja, AddNamestajWindow.TipOperacije.IZMENA);
            namestajProzor.ShowDialog();
           }

        private void btnObrisiNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var namestajZaBrisanje = (Namestaj)dgNamestaj.SelectedItem;

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete namestaj: { namestajZaBrisanje.Naziv}?",
                "Brisanje namestaja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var lista = Projekat.Instance.Namestaj;

                foreach (var namestaj in lista)
                {
                    if (namestaj.Id == namestajZaBrisanje.Id)
                    {
                        namestaj.Obrisan = true;
                        view.Refresh();
                    }
                }
                GenericSerializer.Serialize("namestaj.xml", lista);                               
                }
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgNamestaj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            
            string sakrijKolone = (string)e.Column.Header;
            if (sakrijKolone == "Id" || sakrijKolone == "TipNamestajaId" || sakrijKolone == "Obrisan")
            {                
                e.Cancel = true;
            }            
        }
    }
}
