using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie.PageOdjects;

namespace Zadanie.PageElements
{
    class SpanDropDown : ActiveElement, IDropDown
    {
        public List<IWebElement> options { get; set; }
        public By OptionsLocator { get; set; } //= By.CssSelector("li.select2-results-dept-0");

        public void GetAllOptions(IWebDriver driver)
        {
            Click();
            options = driver.FindElements(OptionsLocator).ToList();
        }


        public SpanDropDown(IWebDriver driver, By locator, By optionsLocator) : base(driver, locator)
        {
            OptionsLocator = optionsLocator;
        }

        public IWebElement OptionSearch(string searchText)
        {
            IEnumerable<IWebElement> result = from element in options
                                              where element.Text.Contains(searchText)
                                              select element;
            return result.ToList()[0];
        }

        public void ChooseOption(Page sender, string optionText)
        {
            GetAllOptions(sender.driver);
            OptionSearch(optionText).Click();
        }
    }
}
