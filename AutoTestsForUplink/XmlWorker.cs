using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Autotests.PageOdjects;
using Autotests.PageObjects;
using Autotests.PageElements;

namespace Autotests
{
    static class XmlWorker
    {
        public static Dictionary<string, string> TagToLines = new Dictionary<string, string>()
           {
                { "Workers' Compensation", "WorkCompPolicyQuoteInqRq"},
                { "General Liability", "GeneralLiabilityPolicyQuoteInqRq" }
            };

        static public void FindXmlTab(Browser browser)
        {
            List<string> handlerList = browser.Driver.WindowHandles.ToList();
            for (int i = 0; i < handlerList.Count; i++)
            {
                browser.Driver.SwitchTo().Window(handlerList[i]);
                if (browser.GetCurentUrl().Contains(@"acordxml"))
                { break; }
            }
            Waitings.WaitForXmlReady(browser);
        }

        static public XmlAccordance GetXmlOfLine(Browser browser, InsuredPage insuredPage)
        {
            string insuranceType = insuredPage.PolicyTypeField.GetInnerText();
            insuredPage.OperXMLTab();
            FindXmlTab(browser);
            return new XmlAccordance(insuranceType, browser.GetSource());
        }
    }
}
