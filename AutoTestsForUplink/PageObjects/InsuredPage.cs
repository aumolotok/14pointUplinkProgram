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
    class InsuredPage : BasePage
    {
        public string PolicyInsuranceType { get; set; }
        [ConstractBy(How.CssSelector, "div.policy-insurance-type") ]
        public BaseElement PolicyTypeField { get; private set; }
        //private By policyTypeFieldLocator = By.CssSelector("div.policy-insurance-type");

        [ConstructWithOptions(How.XPath, "//div/span[@class=\"arrow\"]",How.CssSelector, "li div.select2-result-label")]
        public Select InsuranceTypes { get; private set; }
        //private By insuredTypeSelect = By.XPath("//div/span[@class=\"arrow\"]");
        //private By insuredTypeOptionsLocator = By.CssSelector("li div.select2-result-label");

        [ConstructWithOptions(How.CssSelector, "div button[title = \"Additional functions to work with the questionnaire.\"]",How.CssSelector, "ul li.drop-down-menu-button__item")]

        public Select AdditionalFunctionsQuestionnaireSelect { get; private set; }
        //private By additionalFunctionsQuestionnaireSelectLoator = By.CssSelector("div button[title = \"Additional functions to work with the questionnaire.\"]");
        //private By additionalFunctionsQuestionnaireSelectOptionsLocator = By.CssSelector("ul li.drop-down-menu-button__item");

        public InsuredPage(IWebDriver driver) : base(driver)
        {
            Waitor.WaitForScript(driver);
            //InsuranceTypes = new Select(driver, insuredTypeSelect, insuredTypeOptionsLocator);
            //AdditionalFunctionsQuestionnaireSelect = new Select(driver, additionalFunctionsQuestionnaireSelectLoator, additionalFunctionsQuestionnaireSelectOptionsLocator);
            //PolicyInsuranceType = new BaseElement(driver, policyTypeFieldLocator).GetText();
        }

        public void getXML()
        {
            AdditionalFunctionsQuestionnaireSelect.ChooseOption(this, "Get");
        }

        public void GoToAddNewRequestForQuote()
        {
            InsuranceTypes.ChooseOption(this, "New");
        }
    }
}
