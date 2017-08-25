using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests
{
    class XmlAccordance
    {
        public string InsuranceType { get; set; }
        public string Xml { get; set; }

        public bool wasChecked = false;
        public bool isCorrect = false;

        public XmlAccordance(string insurance, string xml)
        {
            InsuranceType = insurance;
            Xml = xml;
        }
    }
}
