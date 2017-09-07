using Autotests.PageOdjects;
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
        public static Browser browser;
        XmlAccordanceChecker Checker = new XmlAccordanceChecker();
       [Test]
        public void InsuranceLineAndXmlAccordanceCheck()
        {
            LogIntoSystem();

            CreateNewInsured("InsuredName","General");

            GetXmlOfCurrentLine();

            CreateNewRequestForQuote("Workers");

            GetXmlOfCurrentLine();

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

        public void LogIntoSystem()
        {
            LoginPage loginPage = new LoginPage(browser);
            loginPage.LogInToSystem(Configurator.GetEmail(), Configurator.GetPassword());
        }

        void CreateNewInsured(string insuredName, string line)
        {            
            AllInsuredsPage allInsuredPage = new AllInsuredsPage(browser);
            allInsuredPage.GoToCreatingNewInsured();

            CreateNewInsuredPage newInsuredpage = new CreateNewInsuredPage(browser);
            newInsuredpage.createNewInsured(insuredName);

            CreateNewRequestForQuotePage newRequest = new CreateNewRequestForQuotePage(browser);
            newRequest.CreateNewRequestForQuote(line);
        }

        void CreateNewRequestForQuote(string line)
        {
            InsuredPage insuredPage = new InsuredPage(browser);

            insuredPage.GoToAddNewRequestForQuote();

            CreateNewRequestForQuotePage newRequest = new CreateNewRequestForQuotePage(browser);
            newRequest.CreateNewRequestForQuote(line);
        }

        void GetXmlOfCurrentLine()
        {
            InsuredPage insuredPage = new InsuredPage(browser);

            Checker.AddPair(XmlWorker.GetXmlOfLine(browser, insuredPage));
            browser.CloseCurrentTab();

            List<string> handlerList = browser.Driver.WindowHandles.ToList();
            browser.Driver.SwitchTo().Window(handlerList[0]);
        }

        bool SumUpResults()
        {
            Checker.LineXmlTest();
            return Checker.CheckPares();
        }
    }
}
