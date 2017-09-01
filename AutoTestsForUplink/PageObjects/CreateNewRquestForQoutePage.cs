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
        [ConstructWithOptions(How.Id, "select2-chosen-1", How.CssSelector, "li div.select2-result-label")]
        public Select LineSelect { get; private set; }

        [ConstractBy(How.XPath, "//div/button[text() =\"Continue\"]")]
        public Button Continue { get; private set; }

        public void CreateNewRequestForQuote(string lineType)
        {
            LineSelect.ChooseOption(this, lineType);
            Continue.Click();
            Waitor.WaitUntilEementDisappear(Driver, Continue);
        }

        public CreateNewRequestForQuotePage(IWebDriver driver) : base(driver)
        {

        }
    }
}
