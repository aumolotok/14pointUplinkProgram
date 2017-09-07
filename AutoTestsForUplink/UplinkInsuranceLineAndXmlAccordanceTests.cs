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

namespace Autotests
{
   [TestFixture]
    class UplinkInsuranceLineAndXmlAccordanceTests
    {
        static IWebDriver driver;
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
            driver = new FirefoxDriver();
            TimeSpan time = new TimeSpan(0, 0, 50);

            driver.Manage().Timeouts().ImplicitWait = time;
            driver.Url = Configurator.GetUrl();

            Checker = new XmlAccordanceChecker();
        }

        [TearDown]
        public void CleanUpTest()
        {
            driver.Quit();
        }

        public void LogIntoSystem()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LogInToSystem(Configurator.GetEmail(), Configurator.GetPassword());
        }

        void CreateNewInsured(string insuredName, string line)
        {            
            AllInsuredsPage allInsuredPage = new AllInsuredsPage(driver);
            allInsuredPage.GoToCreatingNewInsured();

            CreateNewInsuredPage newInsuredpage = new CreateNewInsuredPage(driver);
            newInsuredpage.createNewInsured(insuredName);

            CreateNewRequestForQuotePage newRequest = new CreateNewRequestForQuotePage(driver);
            newRequest.CreateNewRequestForQuote(line);
        }

        void CreateNewRequestForQuote(string line)
        {
            InsuredPage insuredPage = new InsuredPage(driver);

            insuredPage.GoToAddNewRequestForQuote();

            CreateNewRequestForQuotePage newRequest = new CreateNewRequestForQuotePage(driver);
            newRequest.CreateNewRequestForQuote(line);
        }

        void GetXmlOfCurrentLine()
        {
            InsuredPage insuredPage = new InsuredPage(driver);

            Checker.AddPair(XmlWorker.GetXmlOfLine(driver, insuredPage));
            driver.Close();

            List<string> handlerList = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(handlerList[0]);
        }

        bool SumUpResults()
        {
            Checker.LineXmlTest();
            return Checker.CheckPares();
        }
    }
}
