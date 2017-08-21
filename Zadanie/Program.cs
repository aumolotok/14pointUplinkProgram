using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie.UploadService;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.PageObjects;
using System.Xml.Linq;

namespace Zadanie
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test.testMethod();
            TestChoose();
;
        }
  
        static void TestChoose()
        {
            Configurator config = new Configurator();
            // IWebDriver driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"),DesiredCapabilities.Firefox());
            IWebDriver driver = new FirefoxDriver();
            TimeSpan time = new TimeSpan(0, 0, 50);

            driver.Manage().Timeouts().ImplicitWait = time;
            driver.Url = "https://appulatebeta.com/signin";
            

            LoginPage loginPage = new LoginPage(driver);         
            loginPage.ToSignIn(config.GetEmail(), config.GetPassword());


            AllInsuredsPage allInsuredPage = new AllInsuredsPage(driver);
            allInsuredPage.GoToCreatingNewInsured();
            

            CreateNewInsuredPage newInsuredpage = new CreateNewInsuredPage(driver);
            newInsuredpage.createNewInsured();

            //
            CreateNewRquestForQoutePage newRequest = new CreateNewRquestForQoutePage(driver);
            newRequest.CreateNewRquestForQoute("General");

            InsuredPage insuredPage = new InsuredPage(driver);

            XMlAccordanceChecker Checker = new XMlAccordanceChecker();
            Checker.AddPare(GetXmlOfLine(driver,insuredPage));
            driver.Close();

            List<string> handlerList = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(handlerList[0]);

            insuredPage.GoToAddNewRequestForQuote();

            newRequest.CreateNewRquestForQoute("Workers");

            Checker.AddPare(GetXmlOfLine(driver, insuredPage));



            Console.Read();
        }
        static public XMlAccordance GetXmlOfLine(IWebDriver driver, InsuredPage insuredPage)
        {     
            Thread.Sleep(10000);
            insuredPage.getXML();
            XmlWorker.FindXmlTab(driver);
            XMlAccordance first = new XMlAccordance(insuredPage.PolicyInsuranceType, driver.PageSource);
            return first;

        }
    }

    static  class Test
    {
        //public static void testMethod()
        //{

        //    // IWebDriver driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"),DesiredCapabilities.Firefox());
        //    IWebDriver driver = new FirefoxDriver();
        //    TimeSpan time = new TimeSpan(0, 0, 50);

        //    driver.Manage().Timeouts().ImplicitWait = time;
        //    driver.Url = "https://appulatebeta.com/signin";

        //    LoginPage loginPage = new LoginPage(driver);
        //    loginPage.BuildEmailField();
        //    loginPage.BuildPasswordField();
        //    loginPage.BuildSingIn();
        //    loginPage.ToSignIn(@"akolotilo@appulate.com", @"!APL8@");

        //    AllInsuredsPage allInsuredPage = new AllInsuredsPage(driver);
        //    allInsuredPage.BuildeAddButton();
        //    allInsuredPage.addNewButton.Click();

        //    CreateNewInsuredPage newInsuredpage = new CreateNewInsuredPage(driver);
        //    newInsuredpage.BuildInsuredName();
        //    newInsuredpage.BuildContinue();
        //    newInsuredpage.createNewInsured();

        //    CreateNewRquestForQoutePage newRequest = new CreateNewRquestForQoutePage(driver);
        //    newRequest.setUpAllPageElements();
        //    newRequest.CreateNewRquestForQoute("General");

        //    InsuredPage insuredPage = new InsuredPage(driver);
        //    insuredPage.getXML();


        //    XmlWorker.FindXmlTab(driver);

        //    Console.WriteLine(driver.PageSource);
        //    Console.WriteLine(insuredPage.PolicyInsuranceType);
        //    driver.Close();

        //    //driver.Quit(); 
        //}


    }

    
}
