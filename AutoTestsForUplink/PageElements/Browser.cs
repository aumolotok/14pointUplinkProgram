using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.PageElements
{
    class Browser
    {
        private IWebDriver Driver { get; set; }

        public IWebElement FindElement(By locator)
        {
            return Waitings.WaitClickability(Driver, locator);
        }
    }
}
