using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keys.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Keys.Pages
{
    public class EditApplicationTenant
    {
        internal EditApplicationTenant()
        {
            PageFactory.InitElements(Driver.driver, this);
        }
        [FindsBy(How = How.XPath, Using = "html/body/nav/div/ul/li[2]/a")]
        private IWebElement LnqTenant { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/nav/div/ul/li[2]/ul/li[2]/a")]
        private IWebElement LnqMyApplication { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[1]/div[2]/div[1]/div/form/div/input")]
        private IWebElement TxtSearch { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[1]/div[2]/div[1]/div/form/div/div/button")]
        private IWebElement BtnSearch { get; set; }
        [FindsBy(How= How.XPath, Using = "html/body/div/section/div[1]/div[4]/div/div/div/div/div[2]/div[3]/button[2]")]
        private IWebElement LnqEdit { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[3]/div[2]/form/fieldset/div/div/div[3]/input")]
        private IWebElement TxtNoOfTenant { get; set; }
        [FindsBy(How= How.XPath, Using = "html/body/div/section/div[3]/div[2]/form/fieldset/div/div/div[4]/textarea")]
        private IWebElement TxtNotes { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[3]/div[2]/form/fieldset/div/div/div[8]/button[1]")]
        private IWebElement BtnSave { get; set; }

        internal void TenantMethod()
        {
            try
            {
                LnqTenant.Click();
                LnqMyApplication.Click();
                Driver.wait(2);
            }
            catch { throw; }
        }
        internal void SearchMethod()
        {
            try
            {
                ExcelLib.PopulateInCollection(Base.ExcelPath, "PropertyDetails");
                TxtSearch.SendKeys(ExcelLib.ReadData(4, "PropertyName"));
                Driver.wait(2);
                BtnSearch.Click();
                string PropName = Driver.driver.FindElement(By.XPath("html/body/div/section/div[1]/div[4]/div[1]/div/div/div/div[2]/div[2]/div[1]/div[2]/div[1]")).Text;
                bool bPropName = PropName.Contains(ExcelLib.ReadData(4, "PropertyName"));
                if(bPropName)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Property searched is:" + PropName);
                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Property searched failed as:" + PropName);
                }
            }
            catch(Exception Ex)
            { string errormessage= Ex.Message; }
        }
        internal void EditApplication()
        {
            try
            {
                LnqEdit.Click();
                //validate page navigation
                bool bPage = Driver.driver.PageSource.Contains("Edit Rental Appliaction");
                if (bPage)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Navigated to Edit Rental Application Page");
                }

                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Page details not verified");
                }

                ExcelLib.PopulateInCollection(Base.ExcelPath, "TenantDetails");
                //Verify if the Tenant Count field is enalbled
                bool bEnableField = TxtNoOfTenant.Enabled;
                if (bEnableField)
                {
                   TxtNoOfTenant.SendKeys(ExcelLib.ReadData(2, "NoOfTenants"));
                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Tenant Count Field not enabled");
                }
                bool bEnableNote = TxtNotes.Enabled;
                if (bEnableNote)
                {
                    TxtNotes.SendKeys(ExcelLib.ReadData(2, "Notes"));
                    Driver.wait(2);
                    BtnSave.Submit();
                    //validate the success message??
                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Notes field not enabled");
                }
            }
            catch(Exception Ex)
            { string exceptionMsg = Ex.Message; }
        }
    }
}
