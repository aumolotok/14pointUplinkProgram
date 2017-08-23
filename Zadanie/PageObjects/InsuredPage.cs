using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie.PageElements;

namespace Zadanie.PageOdjects
{
    class InsuredPage : Page
    {
        public string PolicyInsuranceType { get; set; }
        public BaseElement PolicyTipeField { get; set; }
        protected By PolicyTipeFieldLocator = By.CssSelector("div.policy-insurance-type");

        public SpanDropDown InsuranceTypes { get; set; }
        protected By InsurentTypeDrop = By.XPath("//div/span[@class=\"arrow\"]");
        protected By OptionsLocator = By.CssSelector("li div.select2-result-label");

        public SpanDropDown FuncrionsDrop { get; set; }
        protected By AdditionalFunctionsDropLoator = By.CssSelector("div button[title = \"Additional functions to work with the questionnaire.\"]");
        protected By AdditionalOptionsLocatorLocator = By.CssSelector("ul li.drop-down-menu-button__item");

        public InsuredPage(IWebDriver driver) : base(driver)
        {
        }

        public void BuildInsuredsTypes()
        {
            InsuranceTypes = new SpanDropDown(driver, InsurentTypeDrop, OptionsLocator);
        }

        public void getXML()
        {
            GetCurrentPolicyLine();
            FuncrionsDrop = new SpanDropDown(driver, AdditionalFunctionsDropLoator, AdditionalOptionsLocatorLocator); ;
            FuncrionsDrop.ChooseOption(this, "Get");
        }

        public void BuildAddDrop()
        {
            FuncrionsDrop = new SpanDropDown(driver, AdditionalFunctionsDropLoator, AdditionalOptionsLocatorLocator);
        }

        public void GetCurrentPolicyLine()
        {
            PolicyInsuranceType = new BaseElement(driver, PolicyTipeFieldLocator).GetText();
        }

        public void GoToAddNewRequestForQuote()
        {
            BuildInsuredsTypes();
            InsuranceTypes.ChooseOption(this, "New");
        }
    }
}
