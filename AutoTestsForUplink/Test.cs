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
        static XMlAccordanceChecker Checker;
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
            loginPage.LogInToSystem(Configurator.GetEmail(), Configurator.GetPassword());
        }

        static void CreateNewInsured(string line)
        {
            
            AllInsuredsPage allInsuredPage = new AllInsuredsPage(driver);
            allInsuredPage.GoToCreatingNewInsured();

            CreateNewInsuredPage newInsuredpage = new CreateNewInsuredPage(driver);
            newInsuredpage.createNewInsured();

            CreateNewRequestForQuotePage newRequest = new CreateNewRequestForQuotePage(driver);
            newRequest.CreateNewRequestForQuote(line);
        }

        static void CreateNewRequestForQuote(string line)
        {

            InsuredPage insuredPage = new InsuredPage(driver);

            insuredPage.GoToAddNewRequestForQuote();

            CreateNewRequestForQuotePage newRequest = new CreateNewRequestForQuotePage(driver);
            newRequest.CreateNewRequestForQuote(line);
        }

        static void GetXmlOfCurrentLine()
        {
            InsuredPage insuredPage = new InsuredPage(driver);

            Checker = new XMlAccordanceChecker();
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
