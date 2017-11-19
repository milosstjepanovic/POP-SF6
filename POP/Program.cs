using POP.Model;
using POP.Tests;
using POP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP
{
    class Program
    {
        private static List<Namestaj> Namestaj = new List<Namestaj>();
        private static List<TipNamestaja> TipoviNamestaja = new List<TipNamestaja>();
        static void Main(string[] args)
        {
            Salon s1 = new Salon()
            {
                Id = 1,
                Adresa = "Trg Dositeja Obradovica 6",
                BrojZiroRacuna = "840-000171666-45",
                Email = "dekan@ftn.uns.ac.rs",
                MaticniBroj = 3216464,
                Naziv = "Forma FTNale",
                PIB = 123123,
                Telefon = "021/321-512",
                Websajt = "http://www.ftn.uns.ac.rs"
            };

            var tp1 = new TipNamestaja()
            {
                Id = 1,
                Naziv = "Krevet"
            };

            var tp2 = new TipNamestaja()
            {
                Id = 2,
                Naziv = "Sofa"
            };

            var n1 = new Namestaj()
            {
                Id = 1,
                Cena = 777,
                Naziv = "Ekstra krevet",
            };

            var n2 = new Namestaj()
            {
                Id = 2,
                Cena = 9000,
                Naziv = "Bracni krevet",
            };

            //Namestaj.Add(n1);
            //Namestaj.Add(n2);

            TipoviNamestaja.Add(tp1);
            TipoviNamestaja.Add(tp2);

            /* var listaNamestaja = new List<Namestaj>();
            listaNamestaja.Add(n1);

            GenericSerializer.Serialize<Namestaj>("namestaj.xml", listaNamestaja);

            //moze i var listaNamestaja
            listaNamestaja = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");


            var listaTipovaNamestaja = new List<TipNamestaja>();
            listaTipovaNamestaja.Add(tp1);
            listaTipovaNamestaja.Add(tp2);
            GenericSerializer.Serialize<TipNamestaja>("tipovi_namestaja.xml", listaTipovaNamestaja); */


            var listaTipovaNamestaja = Projekat.Instance.TipoviNamestaja;

            //listaTipovaNamestaja.RemoveAt();   za brisanje

            var noviTipNamestaja = new TipNamestaja()
            {
                Id = listaTipovaNamestaja.Count + 1,
                Naziv = "Ugaona"
            };

            listaTipovaNamestaja.Add(noviTipNamestaja);
            Projekat.Instance.TipoviNamestaja = listaTipovaNamestaja;


            var listaNamestaja = Projekat.Instance.Namestaj;
            var prviNamestaj = listaNamestaja[0];

            var trazeniTipNamestaja = TipNamestaja.GetById(prviNamestaj.TipNamestajaId);

            /*listaTipovaNamestaja = Projekat.Instance.TipoviNamestaja;
            TipNamestaja trazeniTipNamestaja = null;
            foreach (var tipNamestaja in listaTipovaNamestaja)
            {
                if (tipNamestaja.Id = prviNamestaj.TipNamestajaId)
                {
                    trazeniTipNamestaja = tipNamestaja;
                    break;
                }
            }*/
            Console.WriteLine($"naziv: {prviNamestaj.Naziv}");


            Console.WriteLine("FInished serialization.....");


            Console.WriteLine($"==== Dobro dosli u salon namestaja { s1.Naziv}. ====");

            IspisiGlavniMeni();
        }

        private static void IspisiGlavniMeni()
        {
            int izbor = 0;
            do
            {
                //ispitaj nesto
                do
                {
                    Console.WriteLine("\n==== GLAVNI MENI ====");
                    Console.WriteLine("1. Rad sa namestajem");
                    Console.WriteLine("2. Rad sa tipom namestaja");
                    //...dovrsiti kod kuce
                    Console.WriteLine("0. Izlaz iz aplikacije");

                    /*try
                    {
                        //izbor = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Niste uneli brojnu vrednost! {e}");
                    }  */

                    izbor = int.Parse(Console.ReadLine());
                    
                } while (izbor < 0 || izbor > 2);

                switch (izbor)
                {
                    case 1:
                        NamestajMeni();
                        break;
                    default:
                        break;
                } 


            } while (izbor != 0);
        }

        private static void NamestajMeni()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("\n====== RAD SA NAMESTAJEM ======");
                IspisiCRUDMeni();

                izbor = int.Parse(Console.ReadLine());
                

            } while (izbor < 0 || izbor > 4);

            switch (izbor)
            {
                case 1:
                    PrikaziNamestaj();
                    break;
                case 2:
                    DodajNamestaj();
                    break;
                case 3:
                    IzmeniNamestaj();
                    break;
                case 4:
                    ObrisiNamestaj();
                    break;
                default:
                    break;
            }
        }

        private static void ObrisiNamestaj()
        {
            Console.WriteLine("\n====== BRISANJE NAMESTAJA =====");
            Console.Write("Unesite ID namestaja koji zelite da obrisete: ");
            int Id = int.Parse(Console.ReadLine());
            for (int i = 0; i < Namestaj.Count; i++)
            {
                if (Namestaj[i].Id == Id)
                {
                    Console.WriteLine($"Izabrali ste: {Namestaj[i].Naziv}, cena: { Namestaj[i].Cena}, tip namestaja: { Namestaj[i].TipNamestajaId}  ");
                    Console.Write("\nDa li ste sigurni da zelite da izbrisete odabrani namestaj [d/n]: ");
                    var izbor = Console.ReadLine();
                    if (izbor == "")
                    {
                        Console.WriteLine("Niste uneli nista!");
                        return;
                    }
                    else if (izbor == "n")
                    {
                        Console.WriteLine("Niste obrisali namestaj.");
                        return;
                    }
                    else if (izbor == "d")
                    {
                        Namestaj.Remove(Namestaj[i]);
                        //Namestaj[i].Id --;
                        Console.WriteLine("\nUspesno ste obrisali namestaj.");
                    }
                }
            }
        }

        private static void IzmeniNamestaj()
        {
            Console.WriteLine("\n====== IZMENA NAMESTAJA =====");
            Console.Write("Unesite ID namestaja koji zelite da izmenite: ");
            int Id = int.Parse(Console.ReadLine());
            for (int i = 0; i < Namestaj.Count; i++)
            {                
                if (Namestaj[i].Id == Id)
                {
                    Console.WriteLine($"Izabrali ste: {Namestaj[i].Naziv}, cena: { Namestaj[i].Cena}, tip namestaja: { Namestaj[i].TipNamestajaId}  ");
                    Console.Write("Unesite novi naziv: ");
                    string noviNaziv = Console.ReadLine();
                    Console.Write("Unesite novu cenu: ");
                    double novaCena = double.Parse(Console.ReadLine());
                    Namestaj[i].Naziv = noviNaziv;
                    Namestaj[i].Cena = novaCena;
                    Console.WriteLine("\nUspesno ste izvrsili izmene.");
                    break;
                }                
            }
        }

        private static void DodajNamestaj()
        {
            Console.WriteLine("\n===== DODAVANJE NOVOG NAMESTAJA =====");

            Console.Write("Unesite naziv: ");
            string naziv = Console.ReadLine();
            Console.Write("Unesite cenu: ");
            double cena = double.Parse(Console.ReadLine());

            Console.Write("Unesite ID tipa namestaja: "); // NAPOMENA: u praksi se veze preko ID-a
            int idTipaNamestaja = int.Parse(Console.ReadLine());

            
            TipNamestaja trazeniTipNamestaja = null;
            foreach (var tipNamestaja in TipoviNamestaja)
            {
                if(tipNamestaja.Id == idTipaNamestaja) // PRAKSA tipNamestaja.id == trazeniId !!
                {
                    trazeniTipNamestaja = tipNamestaja;
                }
            }

            var noviNamestaj = new Namestaj()
            {
                Id = Namestaj.Count + 1,
                Naziv = naziv,
                Cena = cena,
                //TipNamestaja = trazeniTipNamestaja
            };
            Namestaj.Add(noviNamestaj);
            Console.WriteLine("Uspesno ste dodali namestaj.");
        }
        

        


        private static void PrikaziNamestaj()
        {
            Console.WriteLine("===== LISTING NAMESTAJA =====");

            for (int i = 0; i < Namestaj.Count; i++)
            {
                Console.WriteLine($"{ i + 1}. naziv: { Namestaj[i].Naziv }, cena: { Namestaj[i].Cena}, tip namestaja: { Namestaj[i].TipNamestajaId} ");
            }
            //NamestajMeni();
        }

        private static void IspisiCRUDMeni()
        {
            Console.WriteLine("1. Prikazi listing");
            Console.WriteLine("2. Dodaj novi");
            Console.WriteLine("3. Izmeni postojeci");
            Console.WriteLine("4. Obrisi");
            Console.WriteLine("0. Povratak u glavni meni");
        }
    }
}
