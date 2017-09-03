using Autotests.PageOdjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.PageObjects
{
    static class CreateNewRequestForQuotePageActions
    {
        static public void CreateNewRequestForQuote(this CreateNewRequestForQuotePage Page, string lineType)
        {
            Page.LineSelect.ChooseOption(Page, lineType);
            Page.Continue.Click();
            Waitor.WaitUntilEementDisappear(Page.Driver, Page.Continue);
            int intt = 5;
        }
    }
}
