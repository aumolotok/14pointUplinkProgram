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
        public BaseElement PolicyTipeField { get; set; }
        private By policyTipeFieldLocator = By.CssSelector("div.policy-insurance-type");

        public SpanDropDown InsuranceTypes { get; set; }
        private By insurentTypeDrop = By.XPath("//div/span[@class=\"arrow\"]");
        private By optionsLocator = By.CssSelector("li div.select2-result-label");

        public SpanDropDown FuncrionsDrop { get; set; }
        private By additionalFunctionsDropLoator = By.CssSelector("div button[title = \"Additional functions to work with the questionnaire.\"]");
        private By additionalOptionsLocatorLocator = By.CssSelector("ul li.drop-down-menu-button__item");

        public InsuredPage(IWebDriver driver) : base(driver)
        {
            Waitor.WaitForScript(driver);
            InsuranceTypes = new SpanDropDown(driver, insurentTypeDrop, optionsLocator);
            FuncrionsDrop = new SpanDropDown(driver, additionalFunctionsDropLoator, additionalOptionsLocatorLocator);
            PolicyInsuranceType = new BaseElement(driver, policyTipeFieldLocator).GetText();
        }

        public void getXML()
        {
            FuncrionsDrop.ChooseOption(this, "Get");
        }

        public void GoToAddNewRequestForQuote()
        {
            InsuranceTypes.ChooseOption(this, "New");
        }
    }
}
