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

namespace Autotests
{
    [TestFixture]
    static class Facility
    {
        [Test]
        public static void test()
        {

            TestPage page = new TestPage();
            InitElementsOfPage(page);
            int c = page.testBUtton.a;
        }

        public static void InitElementsOfPage(TestPage Page)
        {
            List<PropertyInfo> allproperty = Page.GetType().GetProperties().ToList();

            foreach(PropertyInfo property in allproperty)
            {
                Type propertyType = property.PropertyType;
                if (propertyType.GetInterface("ITest") != null)
                {
                    Console.WriteLine(propertyType);
                    object abs = new object();
                    ConstructorInfo c = propertyType.GetConstructor(Type.EmptyTypes);
                    property.SetValue(Page,c.Invoke(null));
                }  
            }
        }
    }

    class TestPage
    {
        IWebDriver driver;
        public TestButton testBUtton { get; set; }
        public TestField testField { get; set; }
        public testThing tst { get; set; }
        
        public TestPage()
        {
            tst = new testThing();
        }
    }

    interface ITest { }

    class TestButton: ITest
    {
        public int a;
        public TestButton()
        {
            a = 5;
        }
    }

    class TestField : ITest
    {
        int b;
        public TestField()
        {
            b = 6;
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
}
