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
        private XDocument confDoc;

        public Configurator()
        {
            confDoc = XDocument.Load(Environment.CurrentDirectory + "\\Config.xml");
        }

        public string GetEmail()
        {
            return confDoc.Element("TestConfig").Element("SignIn").Element("Email").Value;
        }

        public string GetPassword()
        {
            return confDoc.Element("TestConfig").Element("SignIn").Element("Password").Value;
        }
        public string GetUrl()
        {
            return confDoc.Element("TestConfig").Element("Stand").Value;
        }
    }
}
