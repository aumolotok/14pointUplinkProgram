using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.PageElements
{
    class InteractiveElement : BaseElement, IClickable
    {
        public void Click()
        {
            RootElement.Click();
        }

        public InteractiveElement(Browser browser, By locator) : base(browser, locator)
        {
        }
    }
}
