using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Autotests.PageOdjects;
using NUnit.Framework;
using Autotests.PageElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using Autotests.PageElements.Intefaces;
using OpenQA.Selenium.Support.UI;

namespace Autotests
{
    [TestFixture]
    static class Facility
    {
        [Test]
        public static void test()
        {

            TestPage page = new TestPage(@"https://www.yandex.ru/");


            InitElementsOfPage(page);
            page.testField.Intext();
            page.testBUtton.RootElement.Click();
        }
            

        public static void InitElementsOfPage(TestPage Page)
        {
            List<PropertyInfo> allproperty = Page.GetType().GetProperties().ToList();

            foreach(PropertyInfo property in allproperty)
            {
                Type propertyType = property.PropertyType;
                if (propertyType.GetInterface("ICustomElement") != null)
                {
                    ConstructorInfo c = propertyType.GetConstructor( new Type[2] { typeof(TestPage), typeof(By) });
                    Type attr = typeof(ConstractBy);
                    ConstractBy a = (ConstractBy)property.GetCustomAttribute(attr);

                    By locator = Helper.GetLocator(a.How, a.Context);

                    property.SetValue(Page,c.Invoke(new object[2] {Page, locator} ));
                }  
            }
        }
    }
    
    class TestPage
    {
        public IWebDriver driver { get; set; }

        [ConstractBy(How = How.CssSelector,Context = @".suggest2-form__button")]
        public TestButton testBUtton { get; set; }

        [ConstractBy(How = How.CssSelector,Context = "#text")]
        public TestField testField { get; set; }
        
        public TestPage(string url)
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(url);
        }
    }


 
    class TestButton: ICustomElement
    {
        public IWebElement RootElement
        { get; protected set; }

        public TestButton(TestPage sender, By locator)
        {
            RootElement = WaitVisibility(sender.driver, locator);
        }
        
        private IWebElement WaitVisibility(IWebDriver driver, By locator, int seconds = 20)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return (wait.Until(ExpectedConditions.ElementIsVisible(locator)));
        }

    }

    class TestField :TestButton 
    {
        public TestField(TestPage sender, By locator) : base(sender,locator)
        {
            
        }

        public void Intext()
        {
            RootElement.SendKeys("Лисица");
        }

    }
    
    class testThing
    {
        int c;
        public testThing()
        {
            c = 7;
        }
    }


    public class ConstractBy : System.Attribute
    {
        public How How { get; set; }
        public string Context { get; set; }
        public By Locator { get; set; }

        public ConstractBy(How how,string context)
        {
            How = how;
            Context = context;
        }

        public ConstractBy()
        {

        }

        private By GetLocator(How how,string context)
        {
            switch (how)
            {
                case How.ClassName:
                    return By.ClassName(context);
                case How.CssSelector:
                    return By.CssSelector(context);
                case How.Id:
                    return By.Id(context);
                case How.LinkText:
                    return By.LinkText(context);
                case How.Name:
                    return By.Name(context);
                case How.PartialLinkText:
                    return By.PartialLinkText(context);
                case How.TagName:
                    return By.TagName(context);
                case How.XPath:
                    return By.XPath(context);
                default:
                    return By.Id(context);
            }              
        }
    }

    class Helper
    {
        static public By GetLocator(How how, string context)
        {
            switch (how)
            {
                case How.ClassName:
                    return By.ClassName(context);
                case How.CssSelector:
                    return By.CssSelector(context);
                case How.Id:
                    return By.Id(context);
                case How.LinkText:
                    return By.LinkText(context);
                case How.Name:
                    return By.Name(context);
                case How.PartialLinkText:
                    return By.PartialLinkText(context);
                case How.TagName:
                    return By.TagName(context);
                case How.XPath:
                    return By.XPath(context);
                default:
                    return By.Id(context);
            }
        }

    }
    interface ITest { }
}
