using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autotests.PageElements;
using Autotests.PageObjects;

namespace Autotests.PageOdjects
{
    class InsuredPage : BasePage
    {
        public string PolicyInsuranceType { get; set; }
        public TextDiv PolicyTypeField { get; }
        private By policyTypeFieldLocator = By.CssSelector("div.policy-insurance-type");

        public Select InsuranceTypes { get; }
        private By insuredTypeSelect = By.XPath("//div/span[@class=\"arrow\"]");
        private By insuredTypeOptionsLocator = By.CssSelector("li div.select2-result-label");

        public Select AdditionalFunctionsQuestionnaireSelect { get; }
        private By additionalFunctionsQuestionnaireSelectLoator = By.CssSelector("div button[title = \"Additional functions to work with the questionnaire.\"]");
        private By additionalFunctionsQuestionnaireSelectOptionsLocator = By.CssSelector("ul li.drop-down-menu-button__item");

        public InsuredPage(Browser browser) : base(browser)
        {
            Waitings.WaitForScript(browser);
            InsuranceTypes = new Select(browser, insuredTypeSelect, insuredTypeOptionsLocator);
            AdditionalFunctionsQuestionnaireSelect = new Select(browser, additionalFunctionsQuestionnaireSelectLoator, additionalFunctionsQuestionnaireSelectOptionsLocator);
            PolicyInsuranceType = new TextDiv(browser, policyTypeFieldLocator).GetInnerText();
        }
    }
}
