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

            Assert.IsTrue(SumUpResults());
        }

        [SetUp]
        public void InitTest()
        {
            browser = new Browser();
            browser.OpenPage(Configurator.GetUrl());
            Checker = new XmlAccordanceChecker();
        }

        [TearDown]
        public void CleanUpTest()
        {
            browser.CloseAll();
        }

        //public void LogIntoSystem(User user)
        //{
        //    LoginPage loginPage = new LoginPage(browser);
        //    loginPage.LogInToSystem(user);
        //}

        //void CreateNewInsured(string insuredName, string line)
        //{            
        //    AllInsuredsPage allInsuredPage = new AllInsuredsPage(browser);
            
        //    CreateNewInsuredPage newInsuredpage = allInsuredPage.GoToCreatingNewInsured();
        //    newInsuredpage.createNewInsured(insuredName);

        //    CreateNewRequestForQuotePage newRequest = new CreateNewRequestForQuotePage(browser);
        //    newRequest.CreateNewRequestForQuote(line);
        //}

        //void CreateNewRequestForQuote(string line)
        //{
        //    InsuredPage insuredPage = new InsuredPage(browser);

        //    insuredPage.GoToAddNewRequestForQuote();

        //    CreateNewRequestForQuotePage newRequest = new CreateNewRequestForQuotePage(browser);
        //    newRequest.CreateNewRequestForQuote(line);
        //}

        //void GetXmlOfCurrentLine()
        //{
        //    InsuredPage insuredPage = new InsuredPage(browser);

        //    Checker.AddPair(XmlWorker.GetXmlOfLine(browser, insuredPage));
        //    browser.CloseCurrentTab();

        //    List<string> handlerList = browser.Driver.WindowHandles.ToList();
        //    browser.Driver.SwitchTo().Window(handlerList[0]);
        //}

        bool SumUpResults()
        {
            Checker.LineXmlTest();
            return Checker.CheckPares();
        }
    }
}
