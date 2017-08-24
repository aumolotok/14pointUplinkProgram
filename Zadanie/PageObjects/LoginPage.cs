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
        public TextField EmailField { get; set; }
        public By emailFieldLocator = By.Id("email");

        public TextField PasswordField { get; set; }
        public By passwordFieldLocator = By.Id("password");

        public Button SignIn { get; set; }
        public By signInlocation = By.ClassName("signin-button");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void BuildEmailField()
        {
            EmailField = new TextField(driver, emailFieldLocator);
        }

        public void BuildPasswordField()
        {
            PasswordField = new TextField(driver, passwordFieldLocator);
        }

        public void BuildSingIn()
        {
            SignIn = new Button(driver, signInlocation);
        }

        public void ToSignIn(string login, string password)
        {
            BuildEmailField();
            BuildPasswordField();
            BuildSingIn();

            EmailField.InsertText(login);
            PasswordField.InsertText(password);
            SignIn.Click();
        }
    }
}
