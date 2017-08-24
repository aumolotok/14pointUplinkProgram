using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.PageElements
{
    interface IDropDown
    {
        List<IWebElement> Options { get; set; }
        By OptionsLocator { get; set; }
        void GetAllOptions(IWebDriver driver);
        IWebElement OptionSearch(string searchText);
    }
}
