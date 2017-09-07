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
    class BaseElement
    {
        public IWebElement RootElement { get; }

        public virtual string GetInnerText()
        {
            return null; 
        }

        public BaseElement(Browser browser, By locator)
        {
            RootElement = browser.FindElement(locator);
        }
    }
}
