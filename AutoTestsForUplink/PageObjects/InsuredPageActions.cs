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
        static public void OperXMLTab(this InsuredPage page)
        {
            page.AdditionalFunctionsQuestionnaireSelect.ChooseOption(page, "Get");
        }

        static public void GoToAddNewRequestForQuote(this InsuredPage Page)
        {
            Page.InsuranceTypes.ChooseOption(Page, "New"); //TODO Вернуть обьект страницы
        }
    }
}
