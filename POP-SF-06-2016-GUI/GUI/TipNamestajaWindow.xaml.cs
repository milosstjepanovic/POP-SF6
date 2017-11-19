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
    /// Interaction logic for TipNamestajaWindow.xaml
    /// </summary>
    public partial class TipNamestajaWindow : Window
    {
        
        public TipNamestajaWindow()
        {
            InitializeComponent();
            OsveziPrikaz();
        }

        private void OsveziPrikaz()
        {
            lbTipoviNamestaja.Items.Clear();
            foreach (var tipNamestaja in Projekat.Instance.TipoviNamestaja)
            {
                if (tipNamestaja.Obrisan == false)
                {
                    lbTipoviNamestaja.Items.Add(tipNamestaja);
                }

            };
            lbTipoviNamestaja.SelectedIndex = 0;
        }

        private void btnDodajNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var prazanTipNamestaja = new TipNamestaja()
            {
                Naziv = ""
            };
            var tipNamestajaProzor = new AddTipNamestajaW(prazanTipNamestaja, AddTipNamestajaW.TipOperacije.DODAVANJE);
            tipNamestajaProzor.ShowDialog();
            OsveziPrikaz();
        }

        private void btnIzmeniNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var izabraniTipNamestaja = (TipNamestaja)lbTipoviNamestaja.SelectedItem;

            var tipNamestajaProzor = new AddTipNamestajaW(izabraniTipNamestaja, AddTipNamestajaW.TipOperacije.IZMENA);
            tipNamestajaProzor.ShowDialog();
            OsveziPrikaz();
        }

        private void btnObrisiNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var tipNamestajaZaBrisanje = (TipNamestaja)lbTipoviNamestaja.SelectedItem;

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete tip namestaj: { tipNamestajaZaBrisanje.Naziv}?",
                "Brisanje namestaja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var lista = Projekat.Instance.TipoviNamestaja;

                foreach (var tipNamestaja in lista)
                {
                    if (tipNamestaja.Id == tipNamestajaZaBrisanje.Id)
                    {
                        tipNamestaja.Obrisan = true;
                    }
                }
                Projekat.Instance.TipoviNamestaja = lista;
                OsveziPrikaz();
            }
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
