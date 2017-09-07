using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autotests.PageElements;

namespace Autotests.PageOdjects
{
    class LoginPage : BasePage
    {
        public TextField EmailField { get; }
        private By emailFieldLocator = By.Id("email");

        public TextField PasswordField { get; }
        private By passwordFieldLocator = By.Id("password");

        public Button SignIn { get; }
        private By signInLocation = By.ClassName("signin-button");

        public LoginPage(Browser browser) : base(browser)
        {
            EmailField = new TextField(browser, emailFieldLocator);
            PasswordField = new TextField(browser, passwordFieldLocator);
            SignIn = new Button(browser, signInLocation);
        }
    }
}
