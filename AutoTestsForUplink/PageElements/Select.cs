using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autotests.PageOdjects;

namespace Autotests.PageElements
{
    class Select : InteractiveElement //, IDropDown
    {
        public List<IWebElement> Options { get; set; }
        public By OptionsLocator { get; set; } 

        public List<IWebElement> GetAllOptions(BasePage Page)
        {
            Click();
            return Page.Driver.FindElements(OptionsLocator).ToList();
        }


        public Select(Browser browser, By locator, By optionsLocator) : base(browser, locator)
        {
            OptionsLocator = optionsLocator;
        }

        public IWebElement OptionSearch(string searchText, List <IWebElement> options)
        {
            IEnumerable<IWebElement> opportune = from element in options
                                                 where element.Text.Contains(searchText)
                                                 select element;
            List<IWebElement> result = opportune.ToList();  // HACK: решить проблему

            if (result.Count > 0)
            { 
                return result.First();
            }
            else
            {
                throw new NoSuchElementException("No such option");  // TODO сделать подходящий Exeption
            }
        }

        public void ChooseOption(BasePage sender, string optionText)
        {
                OptionSearch(optionText, GetAllOptions(sender)).Click();                 
        }
    }
}
