using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autotests.PageElements;

namespace Autotests.PageOdjects
{
    class InsuredPage : BasePage
    {
        public string PolicyInsuranceType { get; set; }
        public BaseElement PolicyTypeField { get; set; }
        private By policyTypeFieldLocator = By.CssSelector("div.policy-insurance-type");

        public Select InsuranceTypes { get; set; }
        private By insuredTypeSelect = By.XPath("//div/span[@class=\"arrow\"]");
        private By insuredTypeOptionsLocator = By.CssSelector("li div.select2-result-label");

        public Select FunctionsSelect { get; set; }
        private By additionalFunctionsSelectLoator = By.CssSelector("div button[title = \"Additional functions to work with the questionnaire.\"]");
        private By additionalFunctionsSelectOptionsLocator = By.CssSelector("ul li.drop-down-menu-button__item");

        public InsuredPage(IWebDriver driver) : base(driver)
        {
            Waitor.WaitForScript(driver);
            InsuranceTypes = new Select(driver, insuredTypeSelect, insuredTypeOptionsLocator);
            FunctionsSelect = new Select(driver, additionalFunctionsSelectLoator, additionalFunctionsSelectOptionsLocator);
            PolicyInsuranceType = new BaseElement(driver, policyTypeFieldLocator).GetText();
        }

        public void getXML()
        {
            FunctionsSelect.ChooseOption(this, "Get");
        }

        public void GoToAddNewRequestForQuote()
        {
            InsuranceTypes.ChooseOption(this, "New");
        }
    }
}
