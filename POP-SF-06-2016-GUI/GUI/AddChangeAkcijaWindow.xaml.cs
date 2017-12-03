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
    /// Interaction logic for AddChangeAkcijaWindow.xaml
    /// </summary>
    public partial class AddChangeAkcijaWindow : Window
    {
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

            tbPopust.DataContext = akcija;
            dpDatumPocetka.DataContext = akcija;
            dpDatumZavrsetka.DataContext = akcija;

            var listaSvih = Projekat.Instance.Namestaj;
            var listaNeobrisanih = new List<Namestaj>();
            for (int i = 0; i < listaSvih.Count; i++)
                if (listaSvih[i].Obrisan == false)
                    listaNeobrisanih.Add(listaSvih[i]);
            cmbNamestaj.ItemsSource = listaNeobrisanih;
            cmbNamestaj.DataContext = akcija;

            
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var listaAkcija = Projekat.Instance.Akcija;
            

            switch (operacija)
            {
                case TipOperacije.DODAVANJE:
                    akcija = new Akcija()
                    {
                        Id = listaAkcija.Count + 1,
                        Popust = Decimal.Parse(tbPopust.Text),
                        DatumPocetka = dpDatumPocetka.SelectedDate.Value,
                        DatumZavrsetka = dpDatumZavrsetka.SelectedDate.Value
                        //NamestajId = 
                    };
                    listaAkcija.Add(akcija);
                    break;

                case TipOperacije.IZMENA:

                    foreach (var a in listaAkcija)
                    {
                        if (a.Id == akcija.Id)
                        {
                            a.Popust = Decimal.Parse(tbPopust.Text);
                            a.DatumPocetka = dpDatumPocetka.SelectedDate.Value;
                            a.DatumZavrsetka = dpDatumZavrsetka.SelectedDate.Value;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }

            GenericSerializer.Serialize("akcija.xml", listaAkcija);

            Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
