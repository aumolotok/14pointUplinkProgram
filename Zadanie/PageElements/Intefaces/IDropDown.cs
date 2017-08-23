using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie.PageElements
{
    interface IDropDown
    {
        List<IWebElement> options { get; set; }
        By OptionsLocator { get; set; }
        void GetAllOptions(IWebDriver driver);
        IWebElement OptionSearch(string searchText);
    }
}
