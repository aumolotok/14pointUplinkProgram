using Autotests.PageOdjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests
{
    [TestFixture]
    static class Test
    {
        [Test]
        public static void MainTest()
        {
            Configurator config = new Configurator();
            IWebDriver driver = new FirefoxDriver();
            TimeSpan time = new TimeSpan(0, 0, 50);

            driver.Manage().Timeouts().ImplicitWait = time;
            driver.Url = config.GetUrl();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.LogInToSystem(config.GetEmail(), config.GetPassword());

            AllInsuredsPage allInsuredPage = new AllInsuredsPage(driver);
            allInsuredPage.GoToCreatingNewInsured();

            CreateNewInsuredPage newInsuredpage = new CreateNewInsuredPage(driver);
            newInsuredpage.createNewInsured();

            CreateNewRquestForQoutePage newRequest = new CreateNewRquestForQoutePage(driver);
            newRequest.CreateNewRquestForQoute("General");

            InsuredPage insuredPage = new InsuredPage(driver);

            XMlAccordanceChecker Checker = new XMlAccordanceChecker();
            Checker.AddPare(XmlWorker.GetXmlOfLine(driver, insuredPage));
            driver.Close();

            List<string> handlerList = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(handlerList[0]);

            insuredPage = new InsuredPage(driver);

            insuredPage.GoToAddNewRequestForQuote();

            newRequest = new CreateNewRquestForQoutePage(driver);
            newRequest.CreateNewRquestForQoute("Workers");

            insuredPage = new InsuredPage(driver);

            Checker.AddPare(XmlWorker.GetXmlOfLine(driver, insuredPage));

            driver.Quit();

            Checker.LineXmlTest();

            Assert.IsTrue(Checker.CheckPares());
        }

    }
}
