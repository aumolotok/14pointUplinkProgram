using OpenQA.Selenium;
using System.Collections.Generic;

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
