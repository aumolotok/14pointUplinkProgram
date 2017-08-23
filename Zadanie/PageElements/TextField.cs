﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie.PageElements
{
    class TextField : ActiveElement, IFillable
    {
        public TextField(IWebDriver driver, By locator) : base(driver, locator)
        {
        }

        public void InsertText(string text)
        {
            RootElement.SendKeys(text);
        }
    }
}