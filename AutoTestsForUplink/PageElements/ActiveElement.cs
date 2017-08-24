using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.PageElements
{
    class InteractiveElement : BaseElement, IClicable
    {
        public void Click()
        {
            RootElement.Click();
        }

        public InteractiveElement(IWebDriver driver, By locator) : base(driver, locator)
        {
        }


    }
}
