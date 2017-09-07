using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autotests.PageOdjects;

namespace Autotests.PageElements
{
    class Select : InteractiveElement
    {
        public By OptionsLocator { get; set; } 

        public List<IWebElement> GetAllOptions(BasePage Page)
        {
            Click();
            return Page.Browser.FindElements(OptionsLocator).ToList();
        }

        public Select(Browser browser, By locator, By optionsLocator) : base(browser, locator)
        {
            OptionsLocator = optionsLocator;
        }

        public void ChooseOption(BasePage sender, string optionText)
        {
            List<IWebElement> options = GetAllOptions(sender);
     
            var result = options.Where(o => o.Text.Contains(optionText)).ToList();

            if (result.Any())
            {
                result.First().Click();
            }
            else
            {
                throw new NoSuchElementException("No such option");  // TODO сделать подходящий Exeption
            }
        }
    }
}
