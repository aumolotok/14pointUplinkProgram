using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Zadanie
{
     class XmlWorker
    {
        Dictionary<string, string> TagToLines = new Dictionary<string, string>();
//{ [W]   };

        static public void FindXmlTab(IWebDriver driver)
        {
            List<string> handlerList = driver.WindowHandles.ToList();
            for (int i = 0; i < handlerList.Count; i++)
            {
                driver.SwitchTo().Window(handlerList[i]);
                if (driver.Title.Contains(@"Q&A") == false)
                { break; }

            }
        }


    }

    
}
