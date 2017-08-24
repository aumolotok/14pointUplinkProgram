using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autotests.PageElements;

namespace Autotests.PageOdjects
{
    class CreateNewRquestForQoutePage : BasePage
    {
        public SpanDropDown LineDropDown { get; set; }
        private By lineDropDownLocator = By.Id("select2-chosen-1");
        private By dropOptionsLocator = By.CssSelector(" li div.select2-result-label");

        public Button Continue { get; set; }
        private By continueLocator = By.XPath("//div/button[text() =\"Continue\"]");

        public void CreateNewRquestForQoute(string lineType)
        {
            LineDropDown.ChooseOption(this, lineType);;
            Continue.Click();
            Waitor.WaitUntilGo(Driver, Continue);
        }

        public CreateNewRquestForQoutePage(IWebDriver driver) : base(driver)
        {
            LineDropDown = new SpanDropDown(driver, lineDropDownLocator, dropOptionsLocator);
            Continue = new Button(driver, continueLocator);
        }

    }
}
