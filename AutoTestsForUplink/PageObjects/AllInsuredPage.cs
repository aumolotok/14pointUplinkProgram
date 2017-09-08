using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autotests.PageElements;

namespace Autotests.PageObjects
{
    class AllInsuredsPage : BasePage
    {
        public Button AddNewButton { get; }
        By addNewButtonLocator = By.ClassName("add-new-insured-link");

        public AllInsuredsPage(Browser browser) : base(browser)
        {
            AddNewButton = new Button(browser, addNewButtonLocator);
        }
    }
}
