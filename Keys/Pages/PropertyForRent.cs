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
    public class PropertyForRent
    {
        internal PropertyForRent()
        {
            PageFactory.InitElements(Driver.driver, this);
        }
        [FindsBy(How = How.XPath, Using = ("html/body/nav/div/ul/li[5]/a"))]
        private IWebElement LnqPropertyForRent { get; set; }
        [FindsBy(How = How.XPath, Using = ("html/body/div[1]/section/div[1]/div[2]/div[1]/div[1]/form/div/input"))]
        private IWebElement SearchBar { get; set; }
        [FindsBy(How = How.XPath, Using = ("html/body/div[1]/section/div[1]/div[2]/div[1]/div[1]/form/div/div/button"))]
        private IWebElement BtnSearch { get; set; }
        [FindsBy(How = How.XPath, Using = ("html/body/div[1]/section/div[1]/div[3]/div[1]/div/div[3]/div[6]/div/div/div/button"))]
        private IWebElement LnqApply { get; set; }
        [FindsBy(How = How.XPath, Using = ("html/body/div[1]/section/div[2]/div[2]/form/fieldset/div[2]/div/div/input"))]
        private IWebElement TxtNoOfTenant { get; set; }
        [FindsBy(How = How.XPath, Using = ("html/body/div[1]/section/div[2]/div[2]/form/fieldset/div[3]/div/div/textarea"))]
        private IWebElement TxtNote { get; set; }
        [FindsBy(How = How.XPath, Using = ("html/body/div[1]/section/div[2]/div[2]/form/fieldset/div[6]/div/button[1]"))]
        private IWebElement BtnSubmit { get; set; }

        internal void SearchMethod()
        {   try
            {
                ExcelLib.PopulateInCollection(Base.ExcelPath, "PropertyDetails");
                SearchBar.SendKeys(ExcelLib.ReadData(2, "PropertyName"));
                BtnSearch.Click();
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Property Searched Using Search Menu");
            }
            catch
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "issue in Search Method");
                throw;
            }
        }
        internal void ClickPropertyForRent()
        {
            LnqPropertyForRent.Click();
            Driver.wait(2);
        }
        internal void ApplyForProperty()
        {
            try
            {
                LnqApply.Click();
                ExcelLib.PopulateInCollection(Base.ExcelPath, "TenantDetails");
                TxtNoOfTenant.SendKeys(ExcelLib.ReadData(2, "NoOfTenants"));
                TxtNote.SendKeys(ExcelLib.ReadData(2, "Notes"));
                Driver.wait(2);
                BtnSubmit.Submit();
            }
            catch
            {
                throw;
            }
        }

    }
}
