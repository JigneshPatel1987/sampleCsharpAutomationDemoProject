using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keys.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Keys.Pages
{
    class PODashboard
    {
        internal PODashboard()
        {
            PageFactory.InitElements(Driver.driver, this);
        }
        [FindsBy(How =How.XPath, Using = "html/body/nav/div/ul/li[1]/a")]
        private IWebElement LnqDashboard { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[2]/div[1]/div/div[2]/div[1]/div[1]/div[2]")]
        private IWebElement LnqAddFinDetail { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[2]/select/option[2]")]
        private IWebElement SelectProp { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[2]/div[1]/div/div[2]/div[1]/div[2]/div[2]")]
        private IWebElement LnqAddTenant { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[2]/div[1]/div/div[2]/div[1]/div[3]/div[2]")]
        private IWebElement LnqAddNewProperty { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[2]/div[1]/div/div[2]/div[2]/div/div/div[1]/div[2]")]
        private IWebElement LnqAddNewListing { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[2]/div[1]/div/div[2]/div[2]/div/div/div[2]/a/div[2]")]
        private IWebElement LnqAddNewRequest { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[2]/div[1]/div/div[2]/div[2]/div/div/div[3]/a/div[1]")]
        private IWebElement LnqAddNewMarketJob { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[2]/div/form/fieldset/div[1]/div[1]/div/select/option[1]")]
        private IWebElement SRProperty { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[2]/div/form/fieldset/div[1]/div[2]/div[1]/select/option[1]")]
        private IWebElement SRRequestType { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[2]/div/form/fieldset/div[2]/div/div/textarea")]
        private IWebElement SRDescriptionBox { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[2]/div/form/fieldset/div[5]/div/button")]
        private IWebElement SRSaveBtn { get; set; }


        internal void DashboardMethod()
        {
           try
            {
               LnqDashboard.Click();
               Driver.wait(2);
               string title = Driver.driver.Title;
               Assert.AreEqual("Dashboard", title);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        internal void AddFinDetailMethod()
        {
            try
            {
                LnqAddFinDetail.Click();
                Driver.wait(2);
                bool bPage = Driver.driver.PageSource.Contains("Edit Property Finance");
                if (bPage)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Navigated to Rental Request Form");
                }

                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Page details not verified");
                }
                IWebElement SelProperty = Driver.driver.FindElement(By.CssSelector("form-control"));
                var selectElement = new SelectElement(SelProperty);
                selectElement.SelectByIndex(1);
                //SelectProp.Click();
            }
            catch(Exception Ex)
            {
                string excep = Ex.Message;
            }
        }
        internal void AddTenantMethod()
        {
            LnqAddTenant.Click();
            Assert.AreEqual("Add New Tenant", Driver.driver.Title);
        }
        internal void AddNewPropertyMethod()
        {
            try
            {
                
                LnqAddNewProperty.Click();
                Driver.wait(1);
                Assert.IsTrue( Driver.driver.PageSource.Contains("Add New Property"));
            }
            catch(Exception ex)
            {
                string excep = ex.Message;
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Page title does not match and exception message thrown:" + excep);
            }
        }
        internal void AddNewListingMethod()
        {
            
            LnqAddNewListing.Click();
            Driver.wait(1);
            Assert.AreEqual("ListRental", Driver.driver.Title);
        }
        internal void AddNewRequestmethod()
        {
            LnqAddNewRequest.Click();
            Driver.wait(1);
            Assert.AreEqual("Send Request", Driver.driver.Title);
            try
            {
                ExcelLib.PopulateInCollection(Base.ExcelPath, "PropertyDetails");
                SRProperty.Click();
                Assert.IsTrue(SRRequestType.Enabled);
                SRRequestType.Click();
                Assert.IsTrue(SRDescriptionBox.Enabled);
                SRDescriptionBox.SendKeys(ExcelLib.ReadData(2, "Description"));
                if (SRSaveBtn.Enabled)
                {
                    SRSaveBtn.Submit();
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "All the mandatory filed verified for Send Request");
                }
            }
            catch(Exception exc)
            {
                string excepM = exc.Message;
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Exception Message:" + excepM);
            }

        }
        internal void AddNewMarketJobMethod()
        {
            Driver.wait(1);
            LnqAddNewMarketJob.Click();
            Assert.AreEqual("Property Owner|Add New Job", Driver.driver.Title);
        }
    }
}
