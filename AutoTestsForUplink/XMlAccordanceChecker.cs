using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests
{
    class XmlAccordanceChecker
    {
        private List<XmlAccordance> PairList = new List<XmlAccordance>();

        public void AddPair(XmlAccordance accordance)
        {
            PairList.Add(accordance);
        }

        public void LineXmlTest()
        {
            foreach (XmlAccordance Pair in PairList)
            {
                foreach (var e in XmlWorker.TagToLines)
                {
                    if (Pair.InsuranceType == e.Key && Pair.Xml.Contains(e.Value))
                    {
                        Pair.isCorrect = true;
                    }
                }
                Pair.wasChecked = true;
            }
        }

        public bool CheckPares()
        {
            foreach (var p in PairList)
            {
                if ((p.wasChecked == false) || (p.isCorrect == false))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
