using POP.Model;
using System.Windows;

namespace POP_SF_06_2016_GUI.GUI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        //private Korisnik korisnik;

        public LoginWindow()
        {
            InitializeComponent();
            //this.korisnik = korisnik;
        }

        private void btnPrijaviSe_Click(object sender, RoutedEventArgs e)
        {
            //var listaKorisnika = Projekat.Instance.Korisnik;

            foreach (var korisnik in Projekat.Instance.Korisnik)
            {
                if (tbKorisnickoIme.Text.Equals(korisnik.KorisnickoIme) && pbLozinka.Password.Equals(korisnik.Lozinka) && 
                    korisnik.TipKorisnika.ToString().Equals("Administrator") && korisnik.Obrisan != true)
                {
                    var adminProzor = new AdministratorWindow();
                    adminProzor.ShowDialog();
                    return;
                }
                else if (tbKorisnickoIme.Text.Equals(korisnik.KorisnickoIme) && pbLozinka.Password.Equals(korisnik.Lozinka) && 
                    korisnik.TipKorisnika.ToString().Equals("Prodavac") && korisnik.Obrisan != true)
                {
                    var prodavacProzor = new ProdavacWindow();
                    prodavacProzor.ShowDialog();
                    return;
                }
            }    
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
