using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.PageElements
{
    class InteractiveElement : BaseElement, IClickable
    {
        public TextDiv InnerTextDiv { get; set; }
        public By innerTextLocator;
        public void Click()
        {
            RootElement.Click();
        }

        public override string GetInnerText()
        {
            if (InnerTextDiv != null)
            {
                return InnerTextDiv.GetInnerText();
            }
            return null;
        }

        public InteractiveElement(Browser browser, By locator) : base(browser, locator)
        {
        }

        public InteractiveElement(Browser browser, By locator, By innerTextLocator) : base(browser, locator)
        {
            InnerTextDiv = new TextDiv(browser, innerTextLocator);
        }
    }
}
