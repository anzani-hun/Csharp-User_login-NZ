using System;
using System.Collections.Generic;
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
            Console.WriteLine("***Sziper-Szuper bejelentkező program 4000***");
            Console.WriteLine("Kérem adja meg a bejelentkezési adatait");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Felhasználónév: ");
            string felhasznalonev = Console.ReadLine();

            Console.Write("Jelszó: ");
            string jelszo = null;


            while (true)
            {
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                jelszo = jelszo + key.KeyChar;
            }


            feldolgoz1(felhasznalonev, jelszo);

            Console.ReadKey();
        }

        public static void feldolgoz1(string felhasznalonev, string jelszo)
        {

            //bool változó alapból false-ra állítva.
            bool logged = false; 

            foreach (Userdata adat in userdatas)
            {
                if (felhasznalonev == adat.Username)
                {
                    if (jelszo == adat.Password)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nSikeres bejelentkezés!");
                        logged = true;
                        break;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Rossz jelszó!");
                }
            }

            if (!logged)
            {
                Console.WriteLine("Sikertelen bejelentkezés!");
            }

            Console.ReadKey();
        }
    }

    
}
