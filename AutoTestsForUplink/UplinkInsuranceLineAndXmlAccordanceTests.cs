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

namespace Autotests
{
   [TestFixture]
    static class UplinkInsuranceLineAndXmlAccordanceTests
    {
        static IWebDriver driver;
        static XmlAccordanceChecker Checker;
       [Test]
        public static void InsuranceLineAndXmlAccordanceCheck()
        {
            LogIntoSystem();

            CreateNewInsured("General");

            GetXmlOfCurrentLine();

            CreateNewRequestForQuote("Workers");

            GetXmlOfCurrentLine();

            Assert.IsTrue(SumUpResults());
        }

        static UplinkInsuranceLineAndXmlAccordanceTests()
        {
            driver = new FirefoxDriver();
            TimeSpan time = new TimeSpan(0, 0, 50);

            driver.Manage().Timeouts().ImplicitWait = time;
            driver.Url = Configurator.GetUrl();
        }

        static public void LogIntoSystem()
        {
            
            LoginPage loginPage = new LoginPage(driver);
            Facility.InitElementsOfPage(loginPage);
            loginPage.LogInToSystem(Configurator.GetEmail(), Configurator.GetPassword());
        }

        static void CreateNewInsured(string line)
        {
            
            AllInsuredsPage allInsuredPage = new AllInsuredsPage(driver);
            Facility.InitElementsOfPage(allInsuredPage);
            allInsuredPage.GoToCreatingNewInsured();

            CreateNewInsuredPage newInsuredpage = new CreateNewInsuredPage(driver);
            Facility.InitElementsOfPage(newInsuredpage);
            newInsuredpage.createNewInsured();

            CreateNewRequestForQuotePage newRequest = new CreateNewRequestForQuotePage(driver);
            Facility.InitElementsOfPage(newRequest);
            newRequest.CreateNewRequestForQuote(line);
        }

        static void CreateNewRequestForQuote(string line)
        {

            InsuredPage insuredPage = new InsuredPage(driver);
            Facility.InitElementsOfPage(insuredPage);

            insuredPage.GoToAddNewRequestForQuote();

            CreateNewRequestForQuotePage newRequest = new CreateNewRequestForQuotePage(driver);
            Facility.InitElementsOfPage(newRequest);
            newRequest.CreateNewRequestForQuote(line);
        }

        static void GetXmlOfCurrentLine()
        {
            InsuredPage insuredPage = new InsuredPage(driver);
            Facility.InitElementsOfPage(insuredPage);

            Checker = new XmlAccordanceChecker();
            Checker.AddPare(XmlWorker.GetXmlOfLine(driver, insuredPage));
            driver.Close();

            List<string> handlerList = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(handlerList[0]);
        }

        static bool SumUpResults()
        {
            driver.Quit();

            Checker.LineXmlTest();

            return Checker.CheckPares();
        }
    }
}
