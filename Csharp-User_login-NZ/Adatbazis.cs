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

        //adatbázis kapcsolat és adatbázis SELECT futtatása
        MySqlConnectionStringBuilder connStr = new MySqlConnectionStringBuilder()
        {
            Server = "localhost",
            Port = 3306,
            UserID = "root",
            Password = "",
            Database = "userloginapp"
        };
        MySqlConnection Connect { get => new MySqlConnection(connStr.ConnectionString); }
        MySqlCommand cmd = null;



        //lista létrehozása a  betöltésére
        public List<Userdata> userLista()
        {
            MySqlConnection conn = Connect;
            List<Userdata> users = new List<Userdata>();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM userdata;";

            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Userdata user = new Userdata(reader.GetInt32("userid"), reader.GetString("username"), reader.GetString("email"), reader.GetString("passwd"));
                users.Add(user);
            }
            conn.Close();

            return users;
        }


    }
}
