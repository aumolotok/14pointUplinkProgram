using OpenQA.Selenium;
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
    static class Waitor
    {
        public static void WaitForScript(IWebDriver driver)
        {
            IJavaScriptExecutor Script = (IJavaScriptExecutor)driver;
            
            for (int i =0; i < 20 ; i++)
            {
                if ((bool) Script.ExecuteScript("return window.$ != undefined"))
                {
                    Console.WriteLine("Go-Go-Go");
                    for (int j = 0; i < 100; i++)
                    {
                        if ((bool)Script.ExecuteScript("return $.active == 0"))
                        {
                            Console.WriteLine("Yes-yes");
                            break;
                        }
                        else
                        {
                            Thread.Sleep(100);
                            Console.WriteLine("No-No-No");
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

        public static void WaitUntilGo(IWebDriver driver, ICustomElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.StalenessOf(element.RootElement));
        }

        public static void WaitForXmlReady(IWebDriver driver)
        {
            IJavaScriptExecutor Script = (IJavaScriptExecutor)driver;

            for (int i=0; i < 2000; i++)
            {
                if((string)Script.ExecuteScript("return document.readyState") == "complete")
                {
                    break;
                }
                else
                {
                    Thread.Sleep(1);
                }
            } 
        }
    }
}
