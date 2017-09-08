using Autotests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Autotests.PageElements;

namespace Autotests
{
    static class Quote
    {               
        public static void BuildNewRequestForQuote(Browser browser,string line)
        {
            CreateNewRequestForQuotePage newRequest = new CreateNewRequestForQuotePage(browser);
            newRequest.CreateNewRequestForQuote(line);
        }
    }
}
