using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
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

        public void OpenPage(string url)
        {
            if (Driver == null)
            {
                Driver = new FirefoxDriver();
            }

            Driver.Url = Configurator.GetUrl();
            Driver.Manage().Window.Maximize();
        }
   
        public Browser()
        {
            Driver = new FirefoxDriver();
        }

        public void CloseAll()
        {
            Driver.Quit();
        }

        public void CloseCurrentTab()
        {
            Driver.Close();
        }
    }
}