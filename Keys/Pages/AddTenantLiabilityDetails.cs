using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Keys.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Keys.Pages
{
    public class AddTenantLiabilityDetails
    {
        internal AddTenantLiabilityDetails()
        {
            PageFactory.InitElements(Driver.driver, this);
        }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[2]/div/form/fieldset[2]/div/div[1]/div/a")]
        private IWebElement LnqAddNewLiabilty { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[2]/div/form/fieldset[2]/div/div[1]/div/table/tbody/tr/td[1]/select/option[1]")]
        private IWebElement DDLLiabilityName { get; set; }
        [FindsBy (How = How.XPath, Using = "html/body/div/section/div[2]/div/form/fieldset[2]/div/div[1]/div/table/tbody/tr/td[2]/input")]
        private IWebElement TxtLiabilityAmount { get; set; }
        [FindsBy (How = How.XPath, Using = "html/body/div/section/div[2]/div/form/fieldset[2]/div/div[1]/div/table/tbody/tr/td[3]/input")]
        private IWebElement BtnLiabilitySave { get; set; }
        [FindsBy (How =How.XPath, Using = "html/body/div/section/div[2]/div/form/fieldset[2]/div/div[2]/button[2]")]
        private IWebElement BtnNext { get; set; }
        [FindsBy (How = How.XPath, Using = "html/body/div/section/div[2]/div/form/fieldset[3]/div[10]/div/button[2]")]
        private IWebElement BtnSubmit { get; set; }


        internal void AddLiabiltyMethod()
        {
            try
            {

                ExcelLib.PopulateInCollection(Base.ExcelPath, "TenantDetails");
                if (Driver.driver.PageSource.Contains("Liability Name"))
                {
                    LnqAddNewLiabilty.Click();
                    Thread.Sleep(1000);
                    DDLLiabilityName.Click();
                    Thread.Sleep(500);
                    TxtLiabilityAmount.SendKeys(ExcelLib.ReadData(2, "LiabilityAmount"));
                    decimal d;
                    if (decimal.TryParse(ExcelLib.ReadData(2, "LiabilityAmount"), out d))
                    {
                        TxtLiabilityAmount.SendKeys(ExcelLib.ReadData(2, "LiabilityAmount"));
                        BtnLiabilitySave.Click();
                        Thread.Sleep(1000);
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Verified Liability Amount field for decimal value has been done");
                        bool bNext = BtnNext.Enabled;
                        if (bNext)
                        {
                            BtnNext.Click();
                            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Values on the Add Liability Page has been filled");
                        }
                        else
                        {
                            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Next button on Add Liability page is not enabled");
                        }
                    }
                    else
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Liability Amount field does not have decimal value");
                    }
                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Navigation to Add Liability Details page is broken");
                }

            }
            catch(Exception ex)
            {
                string exceptionmessage = ex.Message;
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, exceptionmessage);

            }
        }
        internal void CompleteTenantMethod()
        {
            bool bSubmit = BtnSubmit.Enabled;
            if (bSubmit)
            {
                Thread.Sleep(1000);
                BtnSubmit.Submit();
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "All the values have been verified and Add Tenant submitted");
            }
            else
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "All the values have been verified and Submit button is not enabled");
            }
        }

    }
}
