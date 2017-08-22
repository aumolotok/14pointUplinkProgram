using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Zadanie
{
    abstract class Page
    {
        public string Url { get; set; }
        public IWebDriver driver { get; set;}

        protected delegate IWebElement Search(By by);
        protected Search FindElement;

        public Page(IWebDriver driver)
        {
            this.driver = driver;
            Url = driver.Url;
            FindElement = this.driver.FindElement;
        }

    }

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
            emailField = new TextField(driver,emailFieldLocator);
        }

        public void BuildPasswordField()
        {
            passwordField = new TextField(driver,passwordFieldLocator);
        }

        public void BuildSingIn()
        {
            SignIn  = new Button(driver, SignInlocation); 
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

    class AllInsuredsPage : Page
    {
        public Button addNewButton;
        By addNewButtonLocator = By.ClassName("add-new-insured-link");

        public AllInsuredsPage(IWebDriver driver) : base(driver)
        {
        }

        public void BuildeAddButton()
        {
            addNewButton = new Button(driver,addNewButtonLocator);
        }

        public void GoToCreatingNewInsured()
        {
            BuildeAddButton();
            addNewButton.Click();
        }

    }

    class CreateNewInsuredPage : Page
    {
        TextField insuredName;
        By insuredNameLocator = By.Id("Name");

        Button Continue;
        By ContinueLocator = By.CssSelector("input[value=\"Continue\"]");

        public void BuildInsuredName()
        {
            insuredName = new TextField(driver, insuredNameLocator);
        }

        public void BuildContinue()
        {
            Continue = new Button(driver, ContinueLocator);
        }

        public CreateNewInsuredPage(IWebDriver driver) : base(driver)
        {
        }

        public void createNewInsured()
        {
            BuildInsuredName();
            BuildContinue();

            insuredName.InsertText("NameOne");
            Continue.Click();
        }

    }

    class CreateNewRquestForQoutePage : Page
    {
        public SpanDropDown lineDropDown;
        By lineDropDownLocator = By.Id("select2-chosen-1");
        By DropOptionsLocator = By.CssSelector(" li div.select2-result-label");

        public Button Continue;
        By ContinueLocator = By.XPath("html/body/div[1]/div[2]/main/div/div/div[3]/button[1]");

        public void setUpAllPageElements()
        {
            BuildLineDropDown();
            BuildContinue();
        }

        public void BuildLineDropDown()
        {
            lineDropDown = new SpanDropDown(driver, lineDropDownLocator, DropOptionsLocator);
        }

        public void BuildContinue()
        {
            Continue = new Button(driver, ContinueLocator);
        } 

        public void CreateNewRquestForQoute(string lineType)
        {
            BuildLineDropDown();
            lineDropDown.ChooseOption(this, lineType);
            BuildContinue();
            Continue.Click();
        }

        public CreateNewRquestForQoutePage(IWebDriver driver) : base(driver)
        {
        }
    }

    class InsuredPage : Page
    {
        public string PolicyInsuranceType { get; set; }
        public BaseElement PolicyTipeField { get; set; }
        protected By PolicyTipeFieldLocator = By.CssSelector("div.policy-insurance-type") ;

        public SpanDropDown InsuranceTypes { get; set; }
        protected By InsurentTypeDrop = By.XPath("//div/span[@class=\"arrow\"]");
        protected By OptionsLocator = By.CssSelector("li div.select2-result-label");

        public SpanDropDown FuncrionsDrop { get; set; }
        protected By AdditionalFunctionsDropLoator = By.CssSelector("div button[title = \"Additional functions to work with the questionnaire.\"]");
        protected By AdditionalOptionsLocatorLocator = By.CssSelector("ul li.drop-down-menu-button__item");

        public InsuredPage(IWebDriver driver) : base(driver)
        {
        }

        public void BuildInsuredsTypes()
        {
            InsuranceTypes = new SpanDropDown(driver, InsurentTypeDrop, OptionsLocator);
        }

        public void getXML()
        {
            GetCurrentPolicyLine();
            FuncrionsDrop = new SpanDropDown(driver, AdditionalFunctionsDropLoator, AdditionalOptionsLocatorLocator);;
            FuncrionsDrop.ChooseOption(this,"Get");
        }

        public void BuildAddDrop()
        {
            FuncrionsDrop = new SpanDropDown(driver, AdditionalFunctionsDropLoator, AdditionalOptionsLocatorLocator);
        }

        public void GetCurrentPolicyLine()
        {
            PolicyInsuranceType = new BaseElement(driver, PolicyTipeFieldLocator).GetText();
        }

        public void GoToAddNewRequestForQuote()
        {
            BuildInsuredsTypes();
            InsuranceTypes.ChooseOption(this,"New");
        }
    }
}
