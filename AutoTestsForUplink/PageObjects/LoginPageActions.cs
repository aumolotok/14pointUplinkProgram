using Autotests.PageOdjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.PageObjects
{
    static class LoginPageActions
    {
        static public void LogInToSystem(this LoginPage page, string login, string password)
        {
            page.EmailField.InsertText(login);
            page.PasswordField.InsertText(password);
            page.SignIn.Click();
        }
    }
}
