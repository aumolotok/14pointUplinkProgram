using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.PageElements
{
    class Button : ActiveElement
    {
        public Button(IWebDriver driver, By locator) : base(driver, locator)
        {
        }
    }
}
