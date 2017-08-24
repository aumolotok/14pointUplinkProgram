﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autotests.PageOdjects;

namespace Autotests.PageElements
{
    class SpanDropDown : ActiveElement, IDropDown
    {
        public List<IWebElement> Options { get; set; }
        public By OptionsLocator { get; set; } 

        public void GetAllOptions(IWebDriver driver)
        {
            Click();
            Options = driver.FindElements(OptionsLocator).ToList();
        }


        public SpanDropDown(IWebDriver driver, By locator, By optionsLocator) : base(driver, locator)
        {
            OptionsLocator = optionsLocator;
        }

        public IWebElement OptionSearch(string searchText)
        {
            IEnumerable<IWebElement> result = from element in Options
                                              where element.Text.Contains(searchText)
                                              select element;
            return result.ToList()[0];
        }

        public void ChooseOption(BasePage sender, string optionText)
        {
            GetAllOptions(sender.Driver);
            OptionSearch(optionText).Click();
        }
    }
}