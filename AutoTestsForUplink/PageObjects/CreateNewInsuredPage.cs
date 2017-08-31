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
    class CreateNewInsuredPage : BasePage
    {
        [ConstractBy(How.Id,"Name")]
        public TextField InsuredName { get; private set; }
        //By insuredNameLocator = By.Id("Name");

        [ConstractBy(How.CssSelector, "input[value=\"Continue\"]")]
        public Button Continue { get; private set; }
        //By ContinueLocator = By.CssSelector("input[value=\"Continue\"]");

        public CreateNewInsuredPage(IWebDriver driver) : base(driver)
        {
            //Continue = new Button(driver, ContinueLocator);
            //InsuredName = new TextField(driver, insuredNameLocator);
        }

        public void createNewInsured()
        {
            InsuredName.InsertText("NameOne");
            Continue.Click();
        }

    }
}
