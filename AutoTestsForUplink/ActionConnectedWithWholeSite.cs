using Autotests.PageElements;
using Autotests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests
{
    static  class Site
    {
        public static void LogIntoSystem(Browser browser, User user)
        {
            LoginPage loginPage = new LoginPage(browser);
            Facility.InitElementsOfPage(loginPage);
            loginPage.LogInToSystem(user);
        }
    }
}
