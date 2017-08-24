using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autotests.PageElements;

namespace Autotests.PageOdjects
{
    class CreateNewRequestForQuotePage : BasePage
    {
        public Select LineSelect { get; set; }
        private By lineSelectLocator = By.Id("select2-chosen-1");
        private By lineSelectOptionsLocator = By.CssSelector("li div.select2-result-label");

        public Button Continue { get; set; }
        private By continueLocator = By.XPath("//div/button[text() =\"Continue\"]");

        public void CreateNewRequestForQuote(string lineType)
        {
            LineSelect.ChooseOption(this, lineType);
            Continue.Click();
            Waitor.WaitUntilGo(Driver, Continue);
        }

        public CreateNewRequestForQuotePage(IWebDriver driver) : base(driver)
        {
            LineSelect = new Select(driver, lineSelectLocator, lineSelectOptionsLocator);
            Continue = new Button(driver, continueLocator);
        }
    }
}
