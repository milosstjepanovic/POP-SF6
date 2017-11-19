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
        public AdministratorWindow()
        {
            InitializeComponent();
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

        }

        private void btnTipoviNamestaja_Click(object sender, RoutedEventArgs e)
        {
            var prozorTipoviNamestaja = new TipNamestajaWindow();
            prozorTipoviNamestaja.ShowDialog();
        }
    }
}
