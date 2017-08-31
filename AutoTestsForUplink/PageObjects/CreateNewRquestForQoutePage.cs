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
    class CreateNewRequestForQuotePage : BasePage
    {
        [ConstractBy(How.Id, "select2-chosen-1")]
        public Select LineSelect { get; private set; }
        //private By lineSelectLocator = By.Id("select2-chosen-1");
        private By lineSelectOptionsLocator = By.CssSelector("li div.select2-result-label");

        public Button Continue { get; }
        private By continueLocator = By.XPath("//div/button[text() =\"Continue\"]");

        public void CreateNewRequestForQuote(string lineType)
        {
            LineSelect.ChooseOption(this, lineType);
            Continue.Click();
            Waitor.WaitUntilEementDisappear(Driver, Continue);
        }

        public CreateNewRequestForQuotePage(IWebDriver driver) : base(driver)
        {
            LineSelect = new Select(driver, lineSelectLocator, lineSelectOptionsLocator);
            Continue = new Button(driver, continueLocator);
        }
    }
}
