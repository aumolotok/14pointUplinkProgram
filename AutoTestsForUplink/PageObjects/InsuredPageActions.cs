using Autotests.PageOdjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.PageObjects
{
    static class InsuredPageActions
    {
        static public void getXML(this InsuredPage Page)
        {
            Page.AdditionalFunctionsQuestionnaireSelect.ChooseOption(Page, "Get");
        }

        static public void GoToAddNewRequestForQuote(this InsuredPage Page)
        {
            Page.InsuranceTypes.ChooseOption(Page, "New");
        }
    }
}
