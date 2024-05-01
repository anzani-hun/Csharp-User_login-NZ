using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_User_login_NZ
{
    class Userdata
    {
        int userid;
        string username;
        string email;
        string passwd;

        public Userdata(int userid, string username, string email, string passwd)
        {
            this.userid = userid;
            this.username = username;
            this.email = email;
            this.passwd = passwd;
        }

        public int Userid { get => userid; set => userid = value; }
        public string Username { get => username; set => username = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => passwd; set => passwd = value; }
    }
}
