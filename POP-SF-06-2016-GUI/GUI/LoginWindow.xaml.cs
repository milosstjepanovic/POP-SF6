using POP.Model;
using System.Windows;
using static POP_SF_06_2016_GUI.GUI.AdministratorWindow;

namespace POP_SF_06_2016_GUI.GUI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public static string prijavljeniKorisnik { set; get; }

        public LoginWindow()
        {
            InitializeComponent();
            tbKorisnickoIme.Focus();
            //DodatnaUsluga.UcitajSveDodatneUsluge();
            
        }
        
        private void btnPrijaviSe_Click(object sender, RoutedEventArgs e)
        {        
            var listaKorisnika = Projekat.Instance.Korisnik;

            foreach (var korisnik in Projekat.Instance.Korisnik)
            {
                var korisnickoIme = tbKorisnickoIme.Text.Trim();
                var lozinka = pbLozinka.Password.Trim();

                if (korisnickoIme == "" || lozinka == "")
                {
                    MessageBox.Show("Morate uneti sve podatke!", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else if (korisnickoIme == korisnik.KorisnickoIme && lozinka == korisnik.Lozinka && korisnik.TipKorisnika.ToString().Equals("Administrator") 
                        && korisnik.Obrisan != true)
                {
                    var adminProzor = new AdministratorWindow(Stanje.Administracija);
                    adminProzor.ShowDialog();
                    tbKorisnickoIme.Clear();
                    pbLozinka.Clear();
                    tbKorisnickoIme.Focus();
                    return;
                }
                else if (korisnickoIme == korisnik.KorisnickoIme && lozinka == korisnik.Lozinka && korisnik.TipKorisnika.ToString().Equals("Prodavac")
                        && korisnik.Obrisan != true)
                {
                    var adminProzor = new AdministratorWindow(Stanje.Prodaja);
                    adminProzor.ShowDialog();
                    tbKorisnickoIme.Clear();
                    pbLozinka.Clear();
                    tbKorisnickoIme.Focus();
                    return;
                }
            }
            MessageBox.Show("Uneti podaci nisu tacni", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
