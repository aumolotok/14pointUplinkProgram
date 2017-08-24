﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autotests.PageElements;

namespace Autotests.PageOdjects
{
    class CreateNewInsuredPage : BasePage
    {
        TextField InsuredName { get; set; }
        By insuredNameLocator = By.Id("Name");

        Button Continue { get; set; }
        By ContinueLocator = By.CssSelector("input[value=\"Continue\"]");

        public void BuildInsuredName()
        {
            InsuredName = new TextField(driver, insuredNameLocator);
        }

        public void BuildContinue()
        {
            Continue = new Button(driver, ContinueLocator);
        }

        public CreateNewInsuredPage(IWebDriver driver) : base(driver)
        {
        }

        public void createNewInsured()
        {
            BuildInsuredName();
            BuildContinue();

            InsuredName.InsertText("NameOne");
            Continue.Click();
        }

    }
}
