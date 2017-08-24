using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.PageElements
{
    public interface IDropDown
    {
        List<IWebElement> Options { get; }
        By OptionsLocator { get; }
        void GetAllOptions(IWebDriver driver);
        IWebElement OptionSearch(string searchText);
    }
}
