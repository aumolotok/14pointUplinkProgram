using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.PageElements
{
    class Button : InteractiveElement
    {
        public Button(Browser browser, By locator) : base(browser, locator)
        {
        }
    }
}
