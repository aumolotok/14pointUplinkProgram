using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.PageElements.Intefaces
{
    interface ICustomElement
    {
        IWebElement RootElement { get;}
    }
}
