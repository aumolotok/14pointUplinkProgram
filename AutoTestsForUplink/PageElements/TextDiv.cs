using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Autotests.PageElements
{
    class TextDiv : BaseElement
    {
        public override string GetInnerText()
        {
            return RootElement.Text;
        }
        public TextDiv(Browser browser, By locator) : base(browser, locator)
        {

        }
    }
}
