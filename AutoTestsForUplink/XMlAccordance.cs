using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests
{
    class XmlAccordance
    {
        public string InsuranceType { get; }
        public string Xml { get; }
        public bool wasChecked;
        public bool isCorrect;

        public XmlAccordance(string insurance, string xml)
        {
            InsuranceType = insurance;
            Xml = xml;
        }
    }
}
