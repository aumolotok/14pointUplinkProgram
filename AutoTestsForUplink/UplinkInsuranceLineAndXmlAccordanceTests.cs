using Autotests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Autotests.PageObjects;
using Autotests.PageElements;

namespace Autotests
{
   [TestFixture]
    class UplinkInsuranceLineAndXmlAccordanceTests
    {
        public  Browser browser;
        public XmlAccordanceChecker Checker = new XmlAccordanceChecker();

       [Test]
        public void InsuranceLineAndXmlAccordanceCheck()
        {
            Site.LogIntoSystem(browser, Configurator.GetUser());

            Insured.CreateNewInsured(browser, "InsuredName","General");

            Insured.GetXmlOfCurrentLine(browser, Checker);

            Insured.CreateNewRequestForQuote(browser,"Workers");

            Insured.GetXmlOfCurrentLine(browser, Checker);

            Assert.IsTrue(Checker.SumUpResults());
        }

        [SetUp]
        public void InitTest()
        {
            browser = new Browser();
            browser.OpenStertPage(/*Configurator.GetUrl()*/);
            Checker = new XmlAccordanceChecker();
        }

        [TearDown]
        public void CleanUpTest()
        {
            browser.CloseAll();           
        }
    }
}
