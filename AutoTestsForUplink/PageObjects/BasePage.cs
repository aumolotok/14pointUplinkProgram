using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Autotests.PageElements;

namespace Autotests.PageObjects
{
    abstract class BasePage
    {
        public string Url { get; }
        public Browser Browser { get; }

        public BasePage(Browser browser)
        {
            Browser = browser;
            Url = Browser.GetCurentUrl();
        }
    }
}
