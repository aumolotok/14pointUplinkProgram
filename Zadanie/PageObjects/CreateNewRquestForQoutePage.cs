using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie.PageElements;

namespace Zadanie.PageOdjects
{
    class CreateNewRquestForQoutePage : Page
    {
        public SpanDropDown LineDropDown { get; set; }
        By lineDropDownLocator = By.Id("select2-chosen-1");
        By dropOptionsLocator = By.CssSelector(" li div.select2-result-label");

        public Button Continue { get; set; }
        // By ContinueLocator = By.XPath("html/body/div[1]/div[2]/main/div/div/div[3]/button[1]");
        By continueLocator = By.XPath("//div/button[text() =\"Continue\"]");

        public void setUpAllPageElements()
        {
            BuildLineDropDown();
            BuildContinue();
        }

        public void BuildLineDropDown()
        {
            LineDropDown = new SpanDropDown(driver, lineDropDownLocator, dropOptionsLocator);
        }

        public void BuildContinue()
        {
            Continue = new Button(driver, continueLocator);
        }

        public void CreateNewRquestForQoute(string lineType)
        {
            BuildLineDropDown();
            LineDropDown.ChooseOption(this, lineType);
            BuildContinue();
            Continue.Click();
        }

        public CreateNewRquestForQoutePage(IWebDriver driver) : base(driver)
        {
        }
    }
}
