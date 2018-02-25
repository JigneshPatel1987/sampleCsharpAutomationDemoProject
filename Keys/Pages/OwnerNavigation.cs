using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keys.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Keys.Pages
{
    public class OwnerNavigation
    {
        internal OwnerNavigation()
        {
            PageFactory.InitElements(Driver.driver, this);
        }
        [FindsBy(How = How.XPath, Using = "/html/body/nav/div/ul/li[2]/a")]
        private IWebElement Owner { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/nav/div/ul/li[2]/ul/li[1]")]
        private IWebElement Owner_Property { get; set; }
        [FindsBy(How= How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div[1]/div[1]/div/form/div/input")]
        private IWebElement SearchBar { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div[1]/div[1]/div/form/div/div/button")]
        private IWebElement SearchButton { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div[2]/div[1]/div/div/div[3]/div/div[1]")]
        private IWebElement FinanceForProp { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/ul/li[2]/a")]
        private IWebElement FinanceDetails { get; set; }

        internal void OwnerMethod()
        {
            try
            {
                Owner.Click();
                Owner_Property.Click();
                Driver.wait(2);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }
        internal void SearchMethod()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "PropertyDetails");
            SearchBar.SendKeys(ExcelLib.ReadData(2, "PropertyName"));
            SearchButton.Click();
            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Property Searched Using Search Menu");
        }
        internal void FinanceDMethod()
        {
            FinanceForProp.Click();
            Driver.wait(2);
            FinanceDetails.Click();
            
        }
    }
}
