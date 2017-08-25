using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Autotests.PageOdjects;

namespace Autotests
{
    static class XmlWorker
    {
        public static Dictionary<string, string> TagToLines = new Dictionary<string, string>()
           {
                { "Workers' Compensation", "WorkCompPolicyQuoteInqRq"},
                { "General Liability", "GeneralLiabilityPolicyQuoteInqRq" }
            };

        static public void FindXmlTab(IWebDriver driver)
        {
            List<string> handlerList = driver.WindowHandles.ToList();
            for (int i = 0; i < handlerList.Count; i++)
            {
                driver.SwitchTo().Window(handlerList[i]);
                if (driver.Url.Contains(@"acordxml"))
                { break; }
            }
            Waitor.WaitForXmlReady(driver);
        }

        static public XmlAccordance GetXmlOfLine(IWebDriver driver, InsuredPage insuredPage)
        {
            insuredPage.getXML();
            XmlWorker.FindXmlTab(driver);
            XmlAccordance accordance = new XmlAccordance(insuredPage.PolicyInsuranceType, driver.PageSource);
            return accordance;
        }
    }
}
