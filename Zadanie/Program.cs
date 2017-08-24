using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autotests.UploadService;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.PageObjects;
using System.Xml.Linq;
using Autotests.PageElements;
using Autotests.PageOdjects;
using NUnit;
using NUnit.Framework;

namespace Autotests
{
    class Program
    {
        static void Main(string[] args)
        {
            Test.MainTest();
        }


    }

    [TestFixture]
    static  class Test
    {
        [Test]
        public static void MainTest()
        {
            Configurator config = new Configurator();
            // IWebDriver driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"),DesiredCapabilities.Firefox());
            IWebDriver driver = new FirefoxDriver();
            TimeSpan time = new TimeSpan(0, 0, 50);

            driver.Manage().Timeouts().ImplicitWait = time;
            driver.Url = config.GetUrl();

            LoginPage loginPage = new LoginPage(driver);
             loginPage.ToSignIn(config.GetEmail(), config.GetPassword());

            AllInsuredsPage allInsuredPage = new AllInsuredsPage(driver);
            allInsuredPage.GoToCreatingNewInsured();

            CreateNewInsuredPage newInsuredpage = new CreateNewInsuredPage(driver);
            newInsuredpage.createNewInsured();

            CreateNewRquestForQoutePage newRequest = new CreateNewRquestForQoutePage(driver);
            newRequest.CreateNewRquestForQoute("General");
           

            //Waitor.WaitForScript(driver);

            InsuredPage insuredPage = new InsuredPage(driver);

            XMlAccordanceChecker Checker = new XMlAccordanceChecker();
            Checker.AddPare(GetXmlOfLine(driver, insuredPage));
            driver.Close();

            List<string> handlerList = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(handlerList[0]);

            insuredPage = new InsuredPage(driver);

            insuredPage.GoToAddNewRequestForQuote();

            newRequest.CreateNewRquestForQoute("Workers");

            insuredPage = new InsuredPage(driver);

            Checker.AddPare(GetXmlOfLine(driver, insuredPage));

            driver.Quit();

            Checker.LineXmlTest();


           
            Assert.IsTrue(Checker.CheckPares());
        }

        static public XMlAccordance GetXmlOfLine(IWebDriver driver, InsuredPage insuredPage)
        {
            insuredPage.getXML();
            
            XmlWorker.FindXmlTab(driver);
            XMlAccordance first = new XMlAccordance(insuredPage.PolicyInsuranceType, driver.PageSource);
            return first;

        }
    }

    
}
