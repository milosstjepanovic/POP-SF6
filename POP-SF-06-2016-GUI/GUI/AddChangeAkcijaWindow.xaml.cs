using POP.Model;
using POP.Utils;
using POP_SF_06_2016_GUI.Model;
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
    /// Interaction logic for AddChangeAkcijaWindow.xaml
    /// </summary>
    public partial class AddChangeAkcijaWindow : Window
    {
        //private ICollectionView view;

        public enum TipOperacije
        {
            DODAVANJE,
            IZMENA
        }

        private Akcija akcija;
        private TipOperacije operacija;


        public AddChangeAkcijaWindow(Akcija akcija, TipOperacije operacija)
        {
            InitializeComponent();

            InicijalizujPodatke(akcija, operacija);
        }

        private void InicijalizujPodatke(Akcija akcija, TipOperacije operacija)
        {
            this.akcija = akcija;
            this.operacija = operacija;

            tbNaziv.DataContext = akcija;
            tbPopust.DataContext = akcija;
            dpDatumPocetka.DataContext = akcija;
            dpDatumZavrsetka.DataContext = akcija;                   
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var listaAkcija = Projekat.Instance.Akcija;           

            switch (operacija)
            {
                case TipOperacije.DODAVANJE:
                    Akcija.Dodaj(akcija);
                    break;

                case TipOperacije.IZMENA:
                    foreach (var a in listaAkcija)
                    {
                        if (a.Id == akcija.Id)
                        {
                            a.Naziv = tbNaziv.Text;
                            a.Popust = Double.Parse(tbPopust.Text);
                            a.DatumPocetka = dpDatumPocetka.SelectedDate.Value;
                            a.DatumZavrsetka = dpDatumZavrsetka.SelectedDate.Value;
                            break;
                        }
                    }
                    Akcija.Izmeni(akcija);
                    break;
                default:
                    break;
            }            
            Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }        
    }
}
