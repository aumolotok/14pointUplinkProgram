using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie.PageElements;

namespace Zadanie.PageOdjects
{
    class LoginPage : Page
    {
        public TextField emailField;
        public By emailFieldLocator = By.Id("email");

        public TextField passwordField;
        public By passwordFieldLocator = By.Id("password");

        public Button SignIn;
        public By SignInlocation = By.ClassName("signin-button");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void BuildEmailField()
        {
            emailField = new TextField(driver, emailFieldLocator);
        }

        public void BuildPasswordField()
        {
            passwordField = new TextField(driver, passwordFieldLocator);
        }

        public void BuildSingIn()
        {
            SignIn = new Button(driver, SignInlocation);
        }

        public void ToSignIn(string login, string password)
        {
            BuildEmailField();
            BuildPasswordField();
            BuildSingIn();

            emailField.InsertText(login);
            passwordField.InsertText(password);
            SignIn.Click();
        }
    }
}
