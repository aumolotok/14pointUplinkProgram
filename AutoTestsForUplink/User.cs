using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests
{
    class User
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
