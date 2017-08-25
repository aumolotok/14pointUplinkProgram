using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests
{
    class XmlAccordanceChecker
    {
        private List<XmlAccordance> PareList = new List<XmlAccordance>();

        public void AddPare(XmlAccordance accordance)
        {
            PareList.Add(accordance);
        }

        public void LineXmlTest()
        {
            foreach (XmlAccordance Pare in PareList)
            {
                foreach (var e in XmlWorker.TagToLines)
                {
                    if (Pare.InsuranceType == e.Key && Pare.Xml.Contains(e.Value))
                    {
                        Pare.isCorrect = true;
                    }
                }
                Pare.wasChecked = true;
            }
        }

        public bool CheckPares()
        {
            foreach (var p in PareList)
            {
                if ((p.wasChecked == false) | (p.isCorrect == false))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
