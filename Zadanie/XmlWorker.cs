using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Autotests
{
    class XmlWorker
    {
        public static Dictionary<string, string> TagToLines = new Dictionary<string, string>()
           {
                { "Workers' Compensation", "WorkCompPolicyQuoteInqRq"/* "ctyrgt" */},
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
    }
}
