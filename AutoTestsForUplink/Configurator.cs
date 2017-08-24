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
        static public string GetEmail()
        {
            return ConfigurationManager.AppSettings["Email"];
        }

        static public string GetPassword()
        {
            return ConfigurationManager.AppSettings["Password"];
        }
        static public string GetUrl()
        {
            return ConfigurationManager.AppSettings["Stand"];
        }
    }
}
