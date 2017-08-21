using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Zadanie
{
    interface IClicable
    {
        void Click();
    }

    interface IFillable
    {
        void InsertText(string text);
    }

    interface IDropDown
    {
        List<IWebElement> options { get; set; }
        By OptionsLocator { get; set; }
        void GetAllOptions(IWebDriver driver);
        IWebElement OptionSearch(string searchText);
    }



    class BaseElement
    {
        public IWebElement RootElement { get; }

        public string GetText()
        {
            return RootElement.Text;
        }
        
        public IWebElement waitVisibility(IWebDriver driver , By locator, int seconds = 20)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return (wait.Until(ExpectedConditions.ElementIsVisible(locator)));
        }

        public BaseElement(IWebDriver driver, By locator)
        {
            RootElement = waitVisibility(driver, locator);
        }
    }

    class ActiveElement : BaseElement, IClicable
    {
        public void Click()
        {
            RootElement.Click();
        }

        public ActiveElement(IWebDriver driver, By locator) : base(driver, locator)
        {
        }

        
    }

    class Button :ActiveElement
    {
        public Button(IWebDriver driver, By locator) : base(driver, locator)
        {
        }
    }

    class TextField : ActiveElement, IFillable
    {


        public TextField(IWebDriver driver, By locator) : base(driver, locator)
        {
        }

        public void InsertText(string text)
        {
            RootElement.SendKeys(text);
        }
    }

    class SpanDropDown : ActiveElement, IDropDown
    {
        public List<IWebElement> options { get; set; }
        public By OptionsLocator { get; set;} //= By.CssSelector("li.select2-results-dept-0");

        public void  GetAllOptions(IWebDriver driver)
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

        public void ChooseOption(Page sender ,string optionText)
        {
            GetAllOptions(sender.driver);
            OptionSearch(optionText).Click();
        }
    }
}
