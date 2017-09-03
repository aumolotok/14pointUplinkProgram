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
        static public void createNewInsured(this CreateNewInsuredPage Page)
        {
            Page.InsuredName.InsertText("NameOne");
            Page.Continue.Click();
        }
    }
}
