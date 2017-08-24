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

        public Button SignIn { get; set; }
        private By signInLocation = By.ClassName("signin-button");

        public LoginPage(IWebDriver driver) : base(driver)
        {
            EmailField = new TextField(driver, emailFieldLocator);
            PasswordField = new TextField(driver, passwordFieldLocator);
            SignIn = new Button(driver, signInLocation);
        }
        public void LogInToSystem(string login, string password)
        {
            EmailField.InsertText(login);
            PasswordField.InsertText(password);
            SignIn.Click();
        }
    }
}
