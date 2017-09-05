﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autotests.PageElements;
using Autotests.PageElements.Intefaces;
using Autotests.PageOdjects;

namespace Autotests
{
    static class Waitings
    {
        public static void WaitForScript(IWebDriver driver)
        {
            IJavaScriptExecutor script = (IJavaScriptExecutor)driver;
            
            for (int i =0; i < 20 ; i++)
            {
                if ((bool) script.ExecuteScript("return window.$ != undefined"))
                {
                    for (int j = 0; j < 100; j++)
                    {
                        if ((bool)script.ExecuteScript("return $.active == 0"))
                        {
                            break;
                        }
                        else
                        {
                            Thread.Sleep(100);
                        }
                    }
                    break;
                }
                else
                {
                    Thread.Sleep(300);
                }
            }
        }

        public static void WaitUntilEementDisappear(IWebDriver driver, BaseElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.StalenessOf(element.RootElement));
        }
        public static void WaitForXmlReady(IWebDriver driver)
        {
            IJavaScriptExecutor script = (IJavaScriptExecutor)driver;

            for (int i=0; i < 2000; i++)
            {
                if((string)script.ExecuteScript("return document.readyState") == "complete")
                {
                    break;
                }
                else
                {
                    Thread.Sleep(1);
                }
            } 
        }

        public static  IWebElement WaitVisibility(IWebDriver driver, By locator, int seconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return (wait.Until(ExpectedConditions.ElementIsVisible(locator)));
        }
    }
}