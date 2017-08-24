﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Autotests.PageOdjects
{
    abstract class BasePage
    {
        public string Url { get; set; }
        public IWebDriver Driver { get; set;}

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Url = driver.Url;
        }
    }
}