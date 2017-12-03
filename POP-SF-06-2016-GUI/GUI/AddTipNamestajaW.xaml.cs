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

            tbNaziv.Text = tipNamestaja.Naziv;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var listaTipovaNamestaja = Projekat.Instance.TipoviNamestaja;


            switch (operacija)
            {
                case TipOperacije.DODAVANJE:
                    tipNamestaja = new TipNamestaja()
                    {
                        Id = listaTipovaNamestaja.Count + 1,
                        Naziv = tbNaziv.Text
                    };
                    listaTipovaNamestaja.Add(tipNamestaja);
                    break;

                case TipOperacije.IZMENA:
                    foreach (var n in listaTipovaNamestaja)
                    {
                        if (n.Id == tipNamestaja.Id)
                        {
                            n.Naziv = tbNaziv.Text;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }

            //cuvaj u disk
            GenericSerializer.Serialize("tipovi_namestaja.xml", listaTipovaNamestaja);

            Close();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
