using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie.PageElements;

namespace Zadanie.PageOdjects
{
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
}
