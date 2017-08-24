using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Autotests
{
    class Configurator
    {
        private XDocument configurationDocument;

        public Configurator()
        {
            configurationDocument = XDocument.Load(@"D:\Automatis\14pointUplinkProgram\Config.xml");
        }

        public string GetEmail()
        {
            return configurationDocument.Element("TestConfig").Element("SignIn").Element("Email").Value;
        }

        public string GetPassword()
        {
            return configurationDocument.Element("TestConfig").Element("SignIn").Element("Password").Value;
        }
        public string GetUrl()
        {
            return configurationDocument.Element("TestConfig").Element("Stand").Value;
        }
    }
}
