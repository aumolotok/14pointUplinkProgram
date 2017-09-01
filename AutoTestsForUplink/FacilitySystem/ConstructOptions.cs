using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace Autotests.FacilitySystem
{
    class ConstructWithOptions : ConstractBy
    {
        public How OptionsHow { get; set; }
        public string OptionContext { get; set; }
        public By OptionsLocator { get; set; }

        public ConstructWithOptions(How how, string context, How optionsHow, string optionContext) : base(how, context)
        {
            OptionsHow = optionsHow;
            OptionContext = optionContext;
            OptionsLocator = GetLocator(OptionsHow, OptionContext);     
        }

        public ConstructWithOptions (By locator, By optionsLocator) : base(locator)
        {
            OptionsLocator = optionsLocator;
        }
    }
}
