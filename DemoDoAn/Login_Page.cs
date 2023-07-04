using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDoAn
{
    internal class Login_Page
    {
        public string username;
        public string password;
        public string type;

        public Login_Page(string username, string password, string type)
        {
            this.username = username;
            this.password = password;
            this.type = type;
        }
    }
}
