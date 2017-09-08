using Autotests.PageElements;
using Autotests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests
{
    static class Insured
    {
        public static void CreateNewInsured(Browser browser, string insuredName, string line)
        {
            AllInsuredsPage allInsuredPage = new AllInsuredsPage(browser);
            Facility.InitElementsOfPage(allInsuredPage);

            CreateNewInsuredPage newInsuredpage = allInsuredPage.GoToCreatingNewInsured();
            Facility.InitElementsOfPage(newInsuredpage);
            newInsuredpage.createNewInsured(insuredName);

            Quote.BuildNewRequestForQuote(browser, line);
        }

        public static void CreateNewRequestForQuote(Browser browser, string line)
        {
            InsuredPage insuredPage = new InsuredPage(browser);
            Facility.InitElementsOfPage(insuredPage);
            insuredPage.GoToAddNewRequestForQuote();

            Quote.BuildNewRequestForQuote(browser, line);
        }

        public static void GetXmlOfCurrentLine(Browser browser,XmlAccordanceChecker Checker)
        {
            InsuredPage insuredPage = new InsuredPage(browser);
            Facility.InitElementsOfPage(insuredPage);

            Checker.AddPair(XmlWorker.GetXmlOfLine(browser, insuredPage));
            browser.CloseCurrentTab();

            List<string> handlerList = browser.Driver.WindowHandles.ToList();
            browser.Driver.SwitchTo().Window(handlerList[0]);
        }
    }
}
