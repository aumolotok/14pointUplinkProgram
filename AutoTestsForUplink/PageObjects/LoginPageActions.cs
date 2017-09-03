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
        static public void LogInToSystem(this LoginPage Page,string login, string password)
        {
            Page.EmailField.InsertText(login);
            Page.PasswordField.InsertText(password);
            Page.SignIn.Click();
        }
    }
}
