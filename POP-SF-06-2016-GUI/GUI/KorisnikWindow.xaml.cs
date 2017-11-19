using POP.Model;
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
    /// Interaction logic for KorisnikWindow.xaml
    /// </summary>
    public partial class KorisnikWindow : Window
    {
        public KorisnikWindow()
        {
            InitializeComponent();
            OsveziPrikaz();
        }

        private void OsveziPrikaz()
        {
            lbKorisnik.Items.Clear();
            foreach (var korisnik in Projekat.Instance.Korisnik)
            {
                lbKorisnik.Items.Add(korisnik);
            }
            lbKorisnik.SelectedIndex = 0;
        }

        private void btnDodajKorisnika_Click(object sender, RoutedEventArgs e)
        {
            var prazanKorisnik = new Korisnik()
            {
                Ime = "",
                Prezime = "",
                KorisnickoIme = "",
                Lozinka = ""
            };
            var korisnikProzor = new AddChangeKorisnikWindow(prazanKorisnik, AddChangeKorisnikWindow.TipOperacije.DODAVANJE);
            korisnikProzor.ShowDialog();
            OsveziPrikaz();
            
        }

        private void btnIzmeniKorisnika_Click(object sender, RoutedEventArgs e)
        {
            var izabraniKorisnik = (Korisnik)lbKorisnik.SelectedItem;

            var korisnikProzor = new AddChangeKorisnikWindow(izabraniKorisnik, AddChangeKorisnikWindow.TipOperacije.IZMENA);
            korisnikProzor.ShowDialog();
            OsveziPrikaz();
        }

        private void btnObrisiKorisnika_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
