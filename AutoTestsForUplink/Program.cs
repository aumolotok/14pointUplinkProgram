using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autotests.UploadService;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.PageObjects;
using System.Xml.Linq;
using Autotests.PageElements;
using Autotests.PageOdjects;
using NUnit;
using NUnit.Framework;

namespace Autotests
{
    class Program
    {
        static void Main(string[] args)
        {
            UplinkAutoTests.InsuranceLineAndXmlAccordanceCheck();
        }
    }   
}
