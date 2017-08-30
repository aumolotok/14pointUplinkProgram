using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.FacilitySystem
{
    public class ConstractBy : System.Attribute
    {
        public How How { get; set; }
        public string Context { get; set; }
        public By Locator { get; set; }

        public ConstractBy(How how, string context)
        {
            How = how;
            Context = context;
            Locator = GetLocator(how, Context);
        }

        private By GetLocator(How how, string context)
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
}
