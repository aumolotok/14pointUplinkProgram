﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.PageElements.Intefaces
{
    public interface ICustomElement
    {
        IWebElement RootElement { get;}
    }
}