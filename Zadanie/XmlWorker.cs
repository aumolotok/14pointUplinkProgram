using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Zadanie
{
    class XmlWorker
    {
        public static Dictionary<string, string> TagToLines = new Dictionary<string, string>()
           { { "Workers' Compensation", "<WorkCompPolicyQuoteInqRq>"  },
             { "General Liability", "GeneralLiabilityPolicyQuoteInqRq" }
            };

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

        static public void LineXmlTest(List<XMlAccordance> PareList)
        {
            foreach (XMlAccordance Pare in PareList)
            {
                foreach (var e in TagToLines)
                {
                    if (Pare.InsuranceType == e.Key && Pare.Xml.Contains(e.Value))
                    {
                        Pare.isCorrect = true;
                    }
                }
                Pare.wasChecked = true;
            }
        }


    }

    class XMlAccordance
    {
        public string InsuranceType { get; set; }
        public string Xml { get; set; }

        public bool wasChecked = false;
        public bool isCorrect = false;

        public XMlAccordance(string insurance, string xml)
        {
            InsuranceType = insurance;
            Xml = xml;
        }
    }

    class XMlAccordanceChecker
    {
        public List<XMlAccordance> PareList = new List<XMlAccordance>();

        public void AddPare(XMlAccordance accordance)
        {
            PareList.Add(accordance);
        }



    }

    class Configurator
    {
        private XDocument confDoc; 
        
        public Configurator()
        {
            confDoc = XDocument.Load(@"D:\Automatis\14pointUplinkProgram\Zadanie\Config.xml");
        }

        public string GetEmail()
        {
         return confDoc.Element("TestConfig").Element("SignIn").Element("Email").Value;
        }

        public string GetPassword()
        {
            return confDoc.Element("TestConfig").Element("SignIn").Element("Password").Value;
        }
    }

}
