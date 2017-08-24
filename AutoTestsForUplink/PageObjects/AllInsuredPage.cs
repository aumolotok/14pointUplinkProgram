using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autotests.PageElements;

namespace Autotests.PageOdjects
{
    class AllInsuredsPage : BasePage
    {
        public Button addNewButton;
        By addNewButtonLocator = By.ClassName("add-new-insured-link");

        public AllInsuredsPage(IWebDriver driver) : base(driver)
        {
        }

        public void BuildeAddButton()
        {
            addNewButton = new Button(driver, addNewButtonLocator);
        }

        public void GoToCreatingNewInsured()
        {
            BuildeAddButton();
            addNewButton.Click();
        }

    }
}
