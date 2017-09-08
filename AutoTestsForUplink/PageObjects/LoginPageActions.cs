using Autotests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.PageObjects
{
    static class LoginPageActions
    {
        static public void LogInToSystem(this LoginPage page, User user)
        {
            page.EmailField.InsertText(user.Email);
            page.PasswordField.InsertText(user.Password);
            page.SignIn.Click();
        }
    }
}
