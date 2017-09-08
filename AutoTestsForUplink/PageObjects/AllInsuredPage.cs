using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autotests.PageElements;
using Autotests.FacilitySystem;
using OpenQA.Selenium.Support.PageObjects;

namespace Autotests.PageObjects
{
    class AllInsuredsPage : BasePage
    {
        [ConstractBy(How.ClassName, "add-new-insured-link")]
        public Button AddNewButton { get; private set; }

        public AllInsuredsPage(Browser browser) : base(browser)
        {
        }
    }
}
