using Autotests.PageOdjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.PageObjects
{
    static class AllInsuredsPageActions
    {
        static public void GoToCreatingNewInsured(this AllInsuredsPage Page)
        {
            Page.AddNewButton.Click();
            //CreateNewInsuredPage newInsuredPage = new CreateNewInsuredPage(Page)
        }
    }
}
