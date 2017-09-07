using Autotests.PageOdjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.PageObjects
{
    static class CreateNewInsuredPageActions
    {
        static public void createNewInsured(this CreateNewInsuredPage page,string insuredName)
        {
            page.InsuredName.InsertText(insuredName);
            page.Continue.Click();
        }
    }
}
