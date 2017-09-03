using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autotests.PageElements;

namespace Autotests.PageOdjects
{
    class CreateNewInsuredPage : BasePage
    {
        public TextField InsuredName { get; }
        public By insuredNameLocator = By.Id("Name");

        public Button Continue { get; }
        public By ContinueLocator = By.CssSelector("input[value=\"Continue\"]");

        public CreateNewInsuredPage(IWebDriver driver) : base(driver)
        {
            Continue = new Button(driver, ContinueLocator);
            InsuredName = new TextField(driver, insuredNameLocator);
        }
    }
}
