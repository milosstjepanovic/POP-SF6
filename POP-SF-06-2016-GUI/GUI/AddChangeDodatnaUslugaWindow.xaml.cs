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
    /// Interaction logic for AddChangeDodatnaUslugaWindow.xaml
    /// </summary>
    public partial class AddChangeDodatnaUslugaWindow : Window
    {
        public enum TipOperacije
        {
            DODAVANJE,
            IZMENA
        }

        private DodatnaUsluga usluga;
        private TipOperacije operacija;

        public AddChangeDodatnaUslugaWindow(DodatnaUsluga usluga, TipOperacije operacija)
        {
            InitializeComponent();

            InicijalizujPodatke(usluga, operacija);
        }

        private void InicijalizujPodatke(DodatnaUsluga usluga, TipOperacije operacija)
        {
            this.usluga = usluga;
            this.operacija = operacija;

            tbNaziv.DataContext = usluga;
            tbCena.DataContext = usluga;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var listaUsluga = Projekat.Instance.DodatnaUsluga;

            switch (operacija)
            {
                case TipOperacije.DODAVANJE:
                    usluga = new DodatnaUsluga()
                    {
                        Id = listaUsluga.Count + 1,
                        Naziv = tbNaziv.Text,
                        Cena = Double.Parse(tbCena.Text)
                    };
                    listaUsluga.Add(usluga);
                    break;

                case TipOperacije.IZMENA:

                    foreach (var u in listaUsluga)
                    {
                        if (u.Id == usluga.Id)
                        {
                            u.Naziv = tbNaziv.Text;
                            u.Cena = Double.Parse(tbCena.Text);
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }

            GenericSerializer.Serialize("dodatne_usluge.xml", listaUsluga);

            Close();
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
