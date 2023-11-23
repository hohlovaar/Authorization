using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization
{
    internal class UserBD
    {
        public string login; public string password;
        public UserBD(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
    }
}
