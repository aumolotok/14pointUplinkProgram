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
            // IWebDriver driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"),DesiredCapabilities.Firefox());
            IWebDriver driver = new FirefoxDriver();
            TimeSpan time = new TimeSpan(0, 0, 50);

            driver.Manage().Timeouts().ImplicitWait = time;
            driver.Url = "https://appulatebeta.com/signin";

            LoginPage loginPage = new LoginPage(driver);
            loginPage.BuildEmailField();
            loginPage.BuildPasswordField();
            loginPage.BuildSingIn();
            loginPage.ToSignIn(@"", @"");

            AllInsuredsPage allInsuredPage = new AllInsuredsPage(driver);
            allInsuredPage.BuildeAddButton();
            allInsuredPage.addNewButton.Click();

            CreateNewInsuredPage newInsuredpage = new CreateNewInsuredPage(driver);
            newInsuredpage.BuildInsuredName();
            newInsuredpage.BuildContinue();
            newInsuredpage.createNewInsured();

            CreateNewRquestForQoutePage newRequestFirst = new CreateNewRquestForQoutePage(driver);
            newRequestFirst.BuildLineDropDown();
            newRequestFirst.lineDropDown.ChooseOption(newRequestFirst,"General");
            newRequestFirst.BuildContinue();
            newRequestFirst.Continue.Click();

            InsuredPage insuredPage = new InsuredPage(driver);
            Thread.Sleep(10000);
            insuredPage.getXML();
            XmlWorker.FindXmlTab(driver);

            XMlAccordanceChecker Checker = new XMlAccordanceChecker();
            XMlAccordance first = new XMlAccordance(insuredPage.PolicyInsuranceType, driver.PageSource);
            Checker.AddPare(first);
            driver.Close();

            XmlWorker.LineXmlTest(Checker.PareList);

            foreach( var e in Checker.PareList)
            {
                Console.WriteLine(e.InsuranceType +" " + e.isCorrect.ToString()+ " " +e.wasChecked.ToString());
            }

            //List<string> handlerList = driver.WindowHandles.ToList();
            //driver.SwitchTo().Window(handlerList[0]);


            //driver.Navigate().Refresh();
            //insuredPage.BuildAddDrop();
            //insuredPage.FuncrionsDrop.Click();
            

            //insuredPage.BuildInsuredsTypes();
            //insuredPage.InsuranceTypes.ChooseOption(insuredPage,"Create");
                           
            Console.Read();


        }
    }

    static  class Test
    {
        public static void testMethod()
        {

            // IWebDriver driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"),DesiredCapabilities.Firefox());
            IWebDriver driver = new FirefoxDriver();
            TimeSpan time = new TimeSpan(0, 0, 50);

            driver.Manage().Timeouts().ImplicitWait = time;
            driver.Url = "https://appulatebeta.com/signin";

            LoginPage loginPage = new LoginPage(driver);
            loginPage.BuildEmailField();
            loginPage.BuildPasswordField();
            loginPage.BuildSingIn();
            loginPage.ToSignIn(@"akolotilo@appulate.com", @"!APL8@");

            AllInsuredsPage allInsuredPage = new AllInsuredsPage(driver);
            allInsuredPage.BuildeAddButton();
            allInsuredPage.addNewButton.Click();

            CreateNewInsuredPage newInsuredpage = new CreateNewInsuredPage(driver);
            newInsuredpage.BuildInsuredName();
            newInsuredpage.BuildContinue();
            newInsuredpage.createNewInsured();

            CreateNewRquestForQoutePage newRequest = new CreateNewRquestForQoutePage(driver);
            newRequest.setUpAllPageElements();
            newRequest.CreateNewRquestForQoute();

            InsuredPage insuredPage = new InsuredPage(driver);
            insuredPage.getXML();


            XmlWorker.FindXmlTab(driver);

            Console.WriteLine(driver.PageSource);
            Console.WriteLine(insuredPage.PolicyInsuranceType);
            driver.Close();

            //driver.Quit(); 
        }


    }

    
}
