using System;
using System.Collections.Generic;
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
    /// Interaction logic for AdministratorWindow.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        public enum Stanje
        {
            Administracija,
            Prodaja
        };

        public Stanje stanje;

        public AdministratorWindow(Stanje stanje)
        {
            InitializeComponent();
            this.stanje = stanje;

            if (stanje == Stanje.Administracija)
            {
                btnProdaja.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                btnAkcije.Visibility = System.Windows.Visibility.Collapsed;
                btnNamestaj.Visibility = System.Windows.Visibility.Collapsed;
                btnKorisnici.Visibility = System.Windows.Visibility.Collapsed;
                btnTipoviNamestaja.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void btnKorisnici_Click(object sender, RoutedEventArgs e)
        {
            var prozorKorisnici = new KorisnikWindow();
            prozorKorisnici.ShowDialog();
        }

        private void btnNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var prozorNamestaj = new NamestajWindow();
            prozorNamestaj.ShowDialog();
        }

        private void btnAkcije_Click(object sender, RoutedEventArgs e)
        {
            var prozorAkcija = new AkcijaWindow();
            prozorAkcija.ShowDialog();
        }

        private void btnTipoviNamestaja_Click(object sender, RoutedEventArgs e)
        {
            var prozorTipoviNamestaja = new TipNamestajaWindow();
            prozorTipoviNamestaja.ShowDialog();
        }

        private void btnProdaja_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
