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
    class CreateNewInsuredPage : BasePage
    {
        [ConstractBy(How.Id,"Name")]
        public TextField InsuredName { get; private set; }

        [ConstractBy(How.CssSelector, "input[value=\"Continue\"]")]
        public Button Continue { get; private set; }

        public CreateNewInsuredPage(Browser browser) : base(browser)
        {
        }
    }
}
