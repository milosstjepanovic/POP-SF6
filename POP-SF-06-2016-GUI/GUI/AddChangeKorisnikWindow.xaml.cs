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

            tbIme.Text = korisnik.Ime;
            tbPrezime.Text = korisnik.Prezime;
            tbKorIme.Text = korisnik.KorisnickoIme;
            tbLozinka.Text = korisnik.Lozinka;
            cmbTipKorisnika.Items.Add(korisnik.TipKorisnika);
            //cmbTipKorisnika.Items.Add(TipKorisnika.Prodavac);
            
            foreach (var idKorisnika in Projekat.Instance.Korisnik)
            {
                cmbTipKorisnika.Items.Add(idKorisnika.TipKorisnika);
            }
            
            /*
            foreach (var tipKorisnika in Projekat.Instance.Korisnik)
            {
                if (tipKorisnika.TipKorisnika.ToString() == TipKorisnika.Administrator.ToString())
                {
                    cmbTipKorisnika.SelectedItem = TipKorisnika.Administrator;
                    break;
                }
                else
                    cmbTipKorisnika.SelectedItem = TipKorisnika.Prodavac;
                    //break;
            }
            */
            
        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
