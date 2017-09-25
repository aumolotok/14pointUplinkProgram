using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Autotests.PageElements
{
    public class Browser
    {
        public IWebDriver Driver { get; set; }

        public IWebElement FindElement(By locator)
        {
            return Waitings.WaitClickability(Driver, locator);
        }

        public List<IWebElement> FindElements(By locator)
        {
            return Driver.FindElements(locator).ToList();
        }

        public void OpenStertPage(/*string url*/)
        {
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

        public string GetCurentUrl()
        {
            return Driver.Url;
        }

        public string GetPageSourceAndCloseTab()
        {
            string source = GetSource();
            Driver.Close();
            return source;
        }

        public string GetSource()
        {
            return Driver.PageSource;
        }
    }
}