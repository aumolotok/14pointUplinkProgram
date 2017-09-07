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
        static public void CreateNewRequestForQuote(this CreateNewRequestForQuotePage page, string lineType)
        {
            page.LineSelect.ChooseOption(page, lineType);
            page.Continue.Click();
            Waitings.WaitUntilEementDisappear(page.Browser, page.Continue);
        }
    }
}
