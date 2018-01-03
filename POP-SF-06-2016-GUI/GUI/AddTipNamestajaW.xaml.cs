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
    /// Interaction logic for AddTipNamestajaW.xaml
    /// </summary>
    public partial class AddTipNamestajaW : Window
    {
        public enum TipOperacije
        {
            DODAVANJE,
            IZMENA
        }

        private TipNamestaja tipNamestaja;
        private TipOperacije operacija;
       

        public AddTipNamestajaW(TipNamestaja tipNamestaja, TipOperacije operacija)
        {
            InitializeComponent();
            InicijalizujPodatke(tipNamestaja, operacija);
        }

        private void InicijalizujPodatke(TipNamestaja tipNamestaja, TipOperacije operacija)
        {
            this.tipNamestaja = tipNamestaja;
            this.operacija = operacija;

            tbNaziv.DataContext = tipNamestaja;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var ucitaniTipoviNamestaja = Projekat.Instance.TipoviNamestaja;

            switch (operacija)
            {
                case TipOperacije.DODAVANJE:
                    TipNamestaja.Dodaj(tipNamestaja);
                    break;

                case TipOperacije.IZMENA:
                    foreach (var tipNam in ucitaniTipoviNamestaja)
                    {
                        if (tipNam.Id == tipNamestaja.Id)
                        {
                            tipNam.Naziv = tbNaziv.Text;
                            break;
                        }
                    }
                    TipNamestaja.Izmeni(tipNamestaja);
                    break;
                default:
                    break;
            }
            Close();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
