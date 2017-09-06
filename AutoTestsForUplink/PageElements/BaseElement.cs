using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autotests.PageElements;

namespace Autotests.PageElements
{
    class BaseElement // : ICustomElement
    {
        public IWebElement RootElement { get; }

        public virtual string GetText()
        {
            return RootElement.Text;
        }

        public BaseElement(Browser browser, By locator)
        {
            RootElement = browser.FindElement(locator);
        }
    }
}
