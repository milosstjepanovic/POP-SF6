using POP.Model;
using POP.Utils;
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
    /// Interaction logic for AddChangeKorisnikWindow.xaml
    /// </summary>
    public partial class AddChangeKorisnikWindow : Window
    {
        public enum TipOperacije
        {
            DODAVANJE,
            IZMENA
        }

        private Korisnik korisnik;
        private TipOperacije operacija;

        public AddChangeKorisnikWindow(Korisnik korisnik, TipOperacije operacija)
        {
            InitializeComponent();

            InicijalizujPodatke(korisnik, operacija);
        }

        private void InicijalizujPodatke(Korisnik korisnik, TipOperacije operacija)
        {
            this.korisnik = korisnik;
            this.operacija = operacija;

            tbIme.DataContext = korisnik;
            tbPrezime.DataContext = korisnik;
            tbKorIme.DataContext = korisnik;
            tbLozinka.DataContext = korisnik;          
            cmbTipKorisnika.ItemsSource = Enum.GetValues(typeof(TipKorisnika));
            cmbTipKorisnika.DataContext = korisnik;

        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var listaKorisnika = Projekat.Instance.Korisnik;
            TipKorisnika izabraniTipKorisnika = (TipKorisnika)cmbTipKorisnika.SelectedItem;
            Console.WriteLine(izabraniTipKorisnika);

            switch (operacija)
            {
                case TipOperacije.DODAVANJE:
                    Korisnik.DodajKorisnika(korisnik);
                    break;

                case TipOperacije.IZMENA:

                    foreach (var k in listaKorisnika)
                    {
                        if (k.Id == korisnik.Id)
                        {
                            k.Ime = tbIme.Text;
                            k.Prezime = tbPrezime.Text;
                            k.KorisnickoIme = tbKorIme.Text;
                            k.Lozinka = tbLozinka.Text;
                            k.TipKorisnika = izabraniTipKorisnika;
                        }
                    }
                    Korisnik.IzmeniKorisnika(korisnik);
                    break;
                default:
                    break;
            }
            Close();
        }
    }
}
