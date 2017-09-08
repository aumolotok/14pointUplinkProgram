using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Autotests.PageObjects;
using NUnit.Framework;
using Autotests.PageElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using Autotests.PageElements;
using OpenQA.Selenium.Support.UI;
using Autotests.FacilitySystem;

namespace Autotests
{
    static class Facility
    {             
        public static void InitElementsOfPage(BasePage Page)
        {
            List<PropertyInfo> allproperty = Page.GetType().GetProperties().ToList();

            foreach(PropertyInfo property in allproperty)
            {
                Type propertyType = property.PropertyType;
                Type сustomElementType = typeof(ICustomElement);
                Type selectType = typeof(Select);


                if (propertyType.GetInterface(сustomElementType.Name) != null && property.GetCustomAttributes() != null )
                {
                    if ((propertyType.Name != selectType.Name))
                    { 
                        ConstructorInfo c = propertyType.GetConstructor( new Type[2] { typeof(Browser), typeof(By) });
                        ConstractBy constructAttribute = (ConstractBy)property.GetCustomAttribute(typeof(ConstractBy));

                        if (constructAttribute != null)
                        {
                            property.SetValue(Page, c.Invoke(new object[2] { Page.Browser, constructAttribute.Locator }));
                        }
                    }

                    if ((propertyType.Name == selectType.Name))
                    {
                        ConstructorInfo c = propertyType.GetConstructor(new Type[3] { typeof(Browser), typeof(By), typeof(By) });
                        ConstructWithOptions constructWithOptionsAttribute = (ConstructWithOptions)property.GetCustomAttribute(typeof(ConstructWithOptions));

                        if (constructWithOptionsAttribute !=null)
                        { 
                        property.SetValue(Page, c.Invoke(new object[3] { Page.Browser, constructWithOptionsAttribute.Locator, constructWithOptionsAttribute.OptionsLocator }));
                        }
                    }
                }
            }
        }
    }
}
