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
    /// Interaction logic for AddNamestajWindow.xaml
    /// </summary>
    public partial class AddNamestajWindow : Window
    {
        public enum TipOperacije
        {
            DODAVANJE,
            IZMENA
        }

        private Namestaj namestaj;
        private TipOperacije operacija;

        

        public AddNamestajWindow(Namestaj namestaj, TipOperacije operacija)
        {
            InitializeComponent();

            InicijalizujPodatke(namestaj, operacija);
        }

        private void InicijalizujPodatke(Namestaj namestaj, TipOperacije operacija)
        {
            this.namestaj = namestaj;
            this.operacija = operacija;

            //gde treba da gleda kad bude menjao text box naziv
            tbNaziv.DataContext = namestaj;
            tbCena.DataContext = namestaj;
            tbKolicina.DataContext = namestaj;
            cmbTipNamestaja.ItemsSource = Projekat.Instance.TipoviNamestaja;
            cmbTipNamestaja.DataContext = namestaj;
            cmbAkcija.ItemsSource = Projekat.Instance.Akcija;
            cmbAkcija.DataContext = namestaj;

        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            //citaj sa diska
            var ucitaniNamestaji = Projekat.Instance.Namestaj;
            TipNamestaja izabraniTipNamestaja = (TipNamestaja)cmbTipNamestaja.SelectedItem;
            Akcija izabranaAkcija = (Akcija)cmbAkcija.SelectedItem;

            switch (operacija)
            {
                case TipOperacije.DODAVANJE:
                    Namestaj.Dodaj(namestaj);
                    break;

                case TipOperacije.IZMENA:                    
                    //var namestajZaIzmenu = listaNamestaja.SingleOrDefault(x => x.Id == namestaj.Id);
                    foreach (var n in ucitaniNamestaji)
                    {
                        if (n.Id == namestaj.Id)
                        {
                            n.Naziv = tbNaziv.Text;
                            n.Cena = Double.Parse(tbCena.Text);
                            n.KolicinaUMagacinu = int.Parse(tbKolicina.Text);
                            n.TipNamestajaId = izabraniTipNamestaja.Id;
                            n.AkcijaId = izabranaAkcija.Id;
                            break;
                        }
                    }
                    Namestaj.Izmeni(namestaj);
                    break;
                default:
                    break;
            }          
            Close();
        }
    }
}
