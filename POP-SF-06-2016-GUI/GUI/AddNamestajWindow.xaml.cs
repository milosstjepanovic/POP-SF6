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

            tbNaziv.Text = namestaj.Naziv;
            tbCena.Text = Convert.ToString(namestaj.Cena);
            tbKolicina.Text = Convert.ToString(namestaj.KolicinaUMagacinu);  
            
            foreach (var idNamestaja in Projekat.Instance.TipoviNamestaja)
            {
                cmbTipNamestaja.Items.Add(idNamestaja);
            }

            foreach (TipNamestaja tipNamestaja in cmbTipNamestaja.Items)
            {
                if (tipNamestaja.Id == namestaj.TipNamestajaId)
                {
                    cmbTipNamestaja.SelectedItem = tipNamestaja;
                    break;
                }
            }

        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            //citaj sa diska
            var listaNamestaja = Projekat.Instance.Namestaj;
            TipNamestaja izabraniTipNamestaja = (TipNamestaja)cmbTipNamestaja.SelectedItem;

            switch (operacija)
            {
                case TipOperacije.DODAVANJE:
                    namestaj = new Namestaj()
                    {
                        Id = listaNamestaja.Count + 1,
                        Naziv = tbNaziv.Text,
                        Cena = Double.Parse(tbCena.Text),
                        TipNamestajaId = izabraniTipNamestaja.Id
                        
                    };
                    listaNamestaja.Add(namestaj);
                    break;

                case TipOperacije.IZMENA:
                    
                    //var namestajZaIzmenu = listaNamestaja.SingleOrDefault(x => x.Id == namestaj.Id);
                    foreach (var n in listaNamestaja)
                    {
                        if (n.Id == namestaj.Id)
                        {
                            n.Naziv = tbNaziv.Text;
                            n.Cena = Double.Parse(tbCena.Text);
                            n.KolicinaUMagacinu = int.Parse(tbKolicina.Text);
                            n.TipNamestajaId = izabraniTipNamestaja.Id;
                            break;
                        }
                    }
                    
                    /*
                    namestajZaIzmenu.Naziv = tbNaziv.Text;
                    namestajZaIzmenu.Cena = Double.Parse(tbCena.Text);
                    namestajZaIzmenu.KolicinaUMagacinu = int.Parse(tbKolicina.Text);
                    namestajZaIzmenu.TipNamestajaId = cmbTipNamestaja.SelectedItem
                    */
                    break;
                default:
                    break;
            }          
            
            //cuvaj u disk
            Projekat.Instance.Namestaj = listaNamestaja;

            Close();
        }
    }
}
