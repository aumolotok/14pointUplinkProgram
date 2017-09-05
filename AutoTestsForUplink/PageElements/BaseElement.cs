using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autotests.PageElements.Intefaces;

namespace Autotests.PageElements
{
    class BaseElement // : ICustomElement
    {
        public IWebElement RootElement { get; }

        public virtual string GetText()
        {
            return RootElement.Text;
        }

        private IWebElement WaitVisibility(IWebDriver driver, By locator, int seconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return (wait.Until(ExpectedConditions.ElementIsVisible(locator)));
        }

        public BaseElement(IWebDriver driver, By locator)
        {
            RootElement = WaitVisibility(driver, locator);
        }
    }
}
