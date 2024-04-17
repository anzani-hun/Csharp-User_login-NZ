using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySqlConnector;

namespace Csharp_User_login_NZ
{

    class Adatbazis
    {

        MySqlConnection dbConnection;      // adatbázis kapcsolat létrehozása
        MySqlCommand sqlCommand;            // a lekérdezése parancs kapcsolata         

        public Adatbazis()
        {

            string connectionString = "server=localhost;port=3306;uid=userloginclient;password=almaeper;database=userloginapp";

            dbConnection = new MySqlConnection(connectionString);
            dbConnection.Open();

            sqlCommand = dbConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM userdata";



        }
    }
}
