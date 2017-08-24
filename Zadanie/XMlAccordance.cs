using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests
{
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
}
