using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySqlConnector;

namespace Csharp_User_login_NZ
{
    class Program
    {

        // az adatbázis példányosítása:
        static Adatbazis db = new Adatbazis();
        static List<Userdata> userdatas = db.userLista();

        static void Main(string[] args)
        {

            /*TESZT
            foreach (Userdata adat in userdatas)
            {
                Console.WriteLine(adat.Username);
            }
            */

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("***Sziper-Szuper bejelentkező program 4000***\n");
            Console.WriteLine("Kérem adja meg a bejelentkezési adatait.");

            adatFeldolgoz();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Válassz a menüből: Lista | Kilépés");
            
            menu();

            Console.ReadKey();
        }

        private static void menu()
        {
            while (true)
            {
                string userValaszt = Console.ReadLine().ToLower();
                Console.WriteLine("");
                Console.WriteLine("Az adatbázisban tárolt felhasználónevek:");

                switch (userValaszt)
                {
                    //listával kiírattatjuk az összes felhasználót
                    case "lista":
                        foreach (Userdata adat in userdatas.OrderBy(a => a.Username))
                        {
                            Console.WriteLine($"- {adat.Username}");
                        }
                        Console.WriteLine("");
                        Console.WriteLine("A teljes lista kiíratva. Gombnyomásra kilép.");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;

                    case "kilépés":
                        Console.WriteLine("Kilépés! Az adatbázissal való kapcsolat zárása");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;

                    default :
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Érvénytelen parancs.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                }
            }
        }

        public static void adatFeldolgoz()
        {
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nFelhasználónév: ");
                string felhasznalonev = Console.ReadLine();

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Jelszó: ");
                string jelszo = null;


                //jelszó elrejtése
                while (true)
                {
                    var key = System.Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                        break;
                    jelszo = jelszo + key.KeyChar;
                }
                
                if (felhasznaloKeres(felhasznalonev) == felhasznalonev)
                {
                        if (jelszoKeres(jelszo) == jelszo)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nSikeres bejelentkezés!\n");
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Hibás jelszó!");
                        }  
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hibás a felhasználónév!");
                }
            }
        }



        private static string jelszoKeres(string jelszo)
        {
            string password = null;

            foreach (Userdata data in userdatas)
            {
                if (jelszo == data.Password)
                {
                    password = data.Password;
                }
            }
            return password;
        }



        private static string felhasznaloKeres(string felhasznalonev)
        {
            string username = null;

            foreach (Userdata data in userdatas) 
            {
                if (felhasznalonev == data.Username)
                {
                    username = data.Username;
                }
            }
            return username;
        }
    }

    
}
