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
        static public CreateNewInsuredPage GoToCreatingNewInsured(this AllInsuredsPage Page)
        {
            Page.AddNewButton.Click();
            return new CreateNewInsuredPage(Page.Browser);
        }
    }
}
