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
    public class ANPTenantDetails
    {
        internal ANPTenantDetails()
        {
            PageFactory.InitElements(Driver.driver, this);
        }
        //Tenants Details Form
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[3]/div[1]/div[1]/div/input")]
        private IWebElement TenantEmailId { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[3]/div[1]/div[2]/div/select/option[1]")]
        private IWebElement IsMainTenant { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[3]/div[2]/div[1]/div/input")]
        private IWebElement TenantFirstName { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[3]/div[2]/div[2]/div/input")]
        private IWebElement TenantLastName { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[3]/div[3]/div[1]/div/input")]
        private IWebElement TenantStartDate { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[3]/div[4]/div[1]/input")]
        private IWebElement RentAmount { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[3]/div[4]/div[2]/div/select/option[1]")]
        private IWebElement PaymentFrequncy { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[3]/div[5]/div[1]/div/input")]
        private IWebElement PaymentStartDate { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[3]/div[5]/div[2]/div/select/option[4]")]
        private IWebElement PaymentDueDate { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[3]/div[7]/div/div/a")]
        private IWebElement ClickNewLiability { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[3]/div[7]/div/div/table/tbody/tr/td[1]/select/option[3]")]
        private IWebElement LiabilityName { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[3]/div[7]/div/div/table/tbody/tr/td[2]/input")]
        private IWebElement LiabilityAmount { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[3]/div[8]/div/button[2]")]
        private IWebElement ButtonSave { get; set; }

        internal void TenantDetails4mExcel()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "TenantDetails");
            Driver.wait(2);
            Assert.IsTrue(Driver.driver.PageSource.Contains("Tenant Email"));
            try
            {
                bool bEmail = TenantEmailId.Enabled;
                if (bEmail)
                {
                    TenantEmailId.SendKeys(ExcelLib.ReadData(3, "EmailId"));
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Email Id field is enabled and value from excel sheet passed");
                    IsMainTenant.Click();
                    //Verify first name field and last name is emabled or not
                    bool bFName = TenantFirstName.Enabled;
                    if (bFName)
                    {
                        TenantFirstName.SendKeys(ExcelLib.ReadData(3, "FirstName"));
                        TenantLastName.SendKeys(ExcelLib.ReadData(3, "LastName"));
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Its a new email id; First Name and Last name filled with Excel sheet");

                    }
                    else
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "First Name & Last Name has been auto filled with the email id");

                    }
                        TenantStartDate.Click();
                    //verify Rent amount field is enabled or not
                        bool bRentField = RentAmount.Enabled;
                    if (bRentField)
                    {
                        RentAmount.SendKeys(ExcelLib.ReadData(3, "RentAmount"));
                        decimal d;

                        if (decimal.TryParse(ExcelLib.ReadData(3, "RentAmount"), out d))
                        {
                            PaymentFrequncy.Click();
                            Driver.wait(5);
                            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Rent Amount field has been verified for decimal values");
                            PaymentStartDate.Click();

                            PaymentDueDate.Click();
                            if (ButtonSave.Enabled)
                            {
                                ButtonSave.Click();
                                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "All the field has been entered on Add Tenant page");
                            }
                            else
                            {
                                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Some of the fields on Add tenant Page need sto be cross verified, Next button is not enabled ");
                            }
                        }
                        else
                        {
                            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Rent Amount field has been verified for decimal values");
                        }

                    }
                    else
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Rent amount field is not enabled");
                    }
                }                
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Email Id Field is not enabled");
                }

                //ClickNewLiability.Click();
                //LiabilityName.Click();
                //LiabilityAmount.SendKeys(ExcelLib.ReadData(2, "LiabilityAmount"));
                //Driver.wait(5);            
                //ButtonSave.Click();
            }
            catch(Exception ex)
            {
                string exMesg = ex.Message;
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Exception Message thrown:" + exMesg);
            }

        }
    }
}
