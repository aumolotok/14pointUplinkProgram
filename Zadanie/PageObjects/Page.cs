using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Zadanie.PageOdjects
{
    abstract class Page
    {
        public string Url { get; set; }
        public IWebDriver driver { get; set;}

        protected delegate IWebElement Search(By by);
        protected Search FindElement;

        public Page(IWebDriver driver)
        {
            this.driver = driver;
            Url = driver.Url;
            FindElement = this.driver.FindElement;
        }

    }
}
