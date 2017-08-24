using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.PageElements
{
    class ActiveElement : BaseElement, IClicable
    {
        public void Click()
        {
            RootElement.Click();
        }

        public ActiveElement(IWebDriver driver, By locator) : base(driver, locator)
        {
        }


    }
}
