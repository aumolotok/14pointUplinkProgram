using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autotests.PageElements;
using Autotests.FacilitySystem;
using OpenQA.Selenium.Support.PageObjects;
using Autotests.PageObjects;

namespace Autotests.PageObjects
{
    class InsuredPage : BasePage
    {
        
        [ConstractBy(How.CssSelector, "div.policy-insurance-type") ]
        public TextDiv PolicyTypeField { get; private set; }
        public string PolicyInsuranceType { get; set; }

        [ConstructWithOptions(How.XPath, "//div/span[@class=\"arrow\"]",How.CssSelector, "li div.select2-result-label")]
        public Select InsuranceTypes { get; private set; }

        [ConstructWithOptions(How.CssSelector, "div button[title = \"Additional functions to work with the questionnaire.\"]",How.CssSelector, "ul li.drop-down-menu-button__item")]
        public Select AdditionalFunctionsQuestionnaireSelect { get; private set; }

        public InsuredPage(Browser browser) : base(browser)
        {
            Waitings.WaitForScript(browser);
        }

        public void OpenXMLTab()
        {
            PolicyInsuranceType = PolicyTypeField.GetInnerText();
            AdditionalFunctionsQuestionnaireSelect.ChooseOption(this, "Get");
        }

        public void GoToAddNewRequestForQuote()
        {
            InsuranceTypes.ChooseOption(this, "New");
        }
    }
}
