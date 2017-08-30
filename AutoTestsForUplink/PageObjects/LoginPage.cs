using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autotests.PageElements;
using Autotests.FacilitySystem;
using OpenQA.Selenium.Support.PageObjects;

namespace Autotests.PageOdjects
{
    class LoginPage : BasePage
    {
        [ConstractBy(How.Id, "email")]
        public TextField EmailField { get; private set; }

        [ConstractBy(How.Id, "password")]
        public TextField PasswordField { get; private set; }

        [ConstractBy(How.ClassName, "signin-button")]
        public Button SignIn { get; private set; }

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
        public void LogInToSystem(string login, string password)
        {
            EmailField.InsertText(login);
            PasswordField.InsertText(password);
            SignIn.Click();
        }
    }
}
