using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Autotests
{
    static class Configurator
    {
        static private string GetEmail(XDocument xdoc)
        {
            return xdoc.Element("TestConfig").Element("SignIn").Element("Email").Value;
        }

        static private string GetPassword(XDocument xdoc)
        {
            return xdoc.Element("TestConfig").Element("SignIn").Element("Password").Value;
        }
        static public string GetUrl()
        {
            return ConfigurationManager.AppSettings["Stand"];
        }

        static public User GetUser()
           
        {
            XDocument xdocument =  XDocument.Load(Environment.CurrentDirectory + @"Config.xml");
            string DLLFolder = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("AutoTestsForUplinkCheckList.dll", "");
            XDocument xdocument =  XDocument.Load (DLLFolder  + @"Config.xml");
            return new User(GetEmail(xdocument), GetPassword(xdocument));

        }
    }
}
