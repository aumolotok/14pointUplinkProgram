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
using Autotests.FacilitySystem;

namespace Autotests
{
    [TestFixture]
    static class Facility
    {
        [Test]
            
        public static void InitElementsOfPage(BasePage Page)
        {
            List<PropertyInfo> allproperty = Page.GetType().GetProperties().ToList();

            foreach(PropertyInfo property in allproperty)
            {
                Type propertyType = property.PropertyType;
                if (propertyType.GetInterface("ICustomElement") != null && property.GetCustomAttributes() != null)
                {
                    ConstructorInfo c = propertyType.GetConstructor( new Type[2] { typeof(IWebDriver), typeof(By) });
                    Type attr = typeof(ConstractBy);
                    ConstractBy a = (ConstractBy)property.GetCustomAttribute(attr);

                    property.SetValue(Page,c.Invoke(new object[2] {Page.Driver, a.Locator} ));
                }  
            }
        }
    }
    

}
