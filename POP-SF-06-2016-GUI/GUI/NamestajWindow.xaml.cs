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
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        public NamestajWindow()
        {
            InitializeComponent();
            OsveziPrikaz();
        }

        private void OsveziPrikaz()
        {
            lbNamestaj.Items.Clear();
            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                if (namestaj.Obrisan == false)
                {
                    lbNamestaj.Items.Add(namestaj);
                }
                
            };
            lbNamestaj.SelectedIndex = 0;
        }

        private void btnDodajNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var prazanNamestaj = new Namestaj()
            {
                Naziv = "",
                Cena = 0,
                KolicinaUMagacinu = 0
            };
            var namestajProzor = new AddNamestajWindow(prazanNamestaj, AddNamestajWindow.TipOperacije.DODAVANJE);
            namestajProzor.ShowDialog();
            OsveziPrikaz();
        }

        private void btnIzmeniNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var izabraniNamestaj = (Namestaj)lbNamestaj.SelectedItem;

            var namestajProzor = new AddNamestajWindow(izabraniNamestaj, AddNamestajWindow.TipOperacije.IZMENA);
            namestajProzor.ShowDialog();
            OsveziPrikaz();
        }

        private void btnObrisiNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var namestajZaBrisanje = (Namestaj)lbNamestaj.SelectedItem;

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete namestaj: { namestajZaBrisanje.Naziv}?",
                "Brisanje namestaja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var lista = Projekat.Instance.Namestaj;

                foreach (var namestaj in lista)
                {
                    if (namestaj.Id == namestajZaBrisanje.Id)
                    {
                        namestaj.Obrisan = true;
                    }
                }

                Projekat.Instance.Namestaj = lista;
                OsveziPrikaz();
            }
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}
