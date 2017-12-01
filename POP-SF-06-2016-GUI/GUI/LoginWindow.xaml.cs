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
        //private Korisnik korisnik;

        public LoginWindow()
        {
            InitializeComponent();
            //this.korisnik = korisnik;
        }
        //int brojac = 0;

        //public int Brojac { get => brojac; set => brojac = value; }

        private void btnPrijaviSe_Click(object sender, RoutedEventArgs e)
        {
            var listaKorisnika = Projekat.Instance.Korisnik;
            
            foreach (var korisnik in Projekat.Instance.Korisnik)
            {
                
                if (tbKorisnickoIme.Text.Equals(korisnik.KorisnickoIme) && pbLozinka.Password.Equals(korisnik.Lozinka) && 
                    korisnik.TipKorisnika.ToString().Equals("Administrator") && korisnik.Obrisan != true)
                {
                    var adminProzor = new AdministratorWindow(Stanje.Administracija);
                    adminProzor.ShowDialog();
                    return;
                }
                else if (tbKorisnickoIme.Text.Equals(korisnik.KorisnickoIme) && pbLozinka.Password.Equals(korisnik.Lozinka) && 
                    korisnik.TipKorisnika.ToString().Equals("Prodavac") && korisnik.Obrisan != true)
                {
                    var adminProzor = new AdministratorWindow(Stanje.Prodaja);
                    adminProzor.ShowDialog();
                    return;
                }
                /*
                else if (Brojac == 2)
                {
                    MessageBox.Show("Pogresili ste previse puta. Aplikacija ce se zatvoriti!", "Greska", MessageBoxButton.OK);
                    this.Close();
                    return;
                    
                }
                */
                else if ((tbKorisnickoIme.Text.Equals("") || pbLozinka.Password.Equals("")) || (tbKorisnickoIme.Text != korisnik.KorisnickoIme || pbLozinka.Password != korisnik.Lozinka))
                {
                    MessageBox.Show("Niste popunili sva polja ili ste uneli pogresne podatke!", "Greska", MessageBoxButton.OK);
                    //Brojac++;
                    //tbKorisnickoIme.Focus();
                    //break;
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
