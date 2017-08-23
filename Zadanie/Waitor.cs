using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadanie
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
                        if ((string)Script.ExecuteScript("return document.readyState") != "complete")
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


    }
}
