using POP.Model;
using POP.Utils;
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
    /// Interaction logic for AkcijaWindow.xaml
    /// </summary>
    public partial class AkcijaWindow : Window
    {
        private ICollectionView view;

        public Akcija IzabranaAkcija { get; set; }

        public AkcijaWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Akcija);

            dgAkcija.ItemsSource = view;
            dgAkcija.DataContext = this;
            dgAkcija.IsSynchronizedWithCurrentItem = true;
            dgAkcija.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);


        }

        private void btnDodajAkciju_Click(object sender, RoutedEventArgs e)
        {
            var praznaAkcija = new Akcija()
            {
                Popust = 0,
                DatumPocetka = DateTime.Now,
                DatumZavrsetka = DateTime.Now
            };
            var akcijaProzor = new AddChangeAkcijaWindow(praznaAkcija, AddChangeAkcijaWindow.TipOperacije.DODAVANJE);
            akcijaProzor.ShowDialog();
        }

        private void btnIzmeniAkciju_Click(object sender, RoutedEventArgs e)
        {
            if (IzabranaAkcija == null)
            {
                MessageBox.Show("Morate izabrati neku stavku.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Akcija kopijaAkcija = (Akcija)IzabranaAkcija.Clone();

            var akcijaProzor = new AddChangeAkcijaWindow(kopijaAkcija, AddChangeAkcijaWindow.TipOperacije.IZMENA);
            akcijaProzor.ShowDialog();
        }

        private void btnObrisiAkciju_Click(object sender, RoutedEventArgs e)
        {
            var akcijaZaBrisanje = (Akcija)dgAkcija.SelectedItem;
            if (akcijaZaBrisanje == null)
            {
                MessageBox.Show("Morate izabrati neku stavku.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete akciju: { akcijaZaBrisanje.Naziv}?",
                "Brisanje namestaja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var lista = Projekat.Instance.Akcija;

                foreach (var akcija in lista)
                {
                    if (akcija.Id == akcijaZaBrisanje.Id)
                    {
                        akcija.Obrisan = true;
                        view.Refresh();
                    }
                }
                GenericSerializer.Serialize("akcija.xml", lista);
            }
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgAkcija_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id" || e.Column.Header.ToString() == "Obrisan" || e.Column.Header.ToString() == "NamestajId")
            {
                e.Cancel = true;
            }
        }
    }
}
