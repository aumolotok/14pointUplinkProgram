using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie.PageElements
{
    class BaseElement
    {
        public IWebElement RootElement { get; }

        public string GetText()
        {
            return RootElement.Text;
        }

        public IWebElement WaitVisibility(IWebDriver driver, By locator, int seconds = 20)
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
