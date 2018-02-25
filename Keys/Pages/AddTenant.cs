using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Keys.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Keys.Pages
{
    public class AddTenant
    {
        internal AddTenant()
        {
            PageFactory.InitElements(Driver.driver, this);
        }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[2]/div/form/fieldset[1]/div[1]/div/div/select/option[1]")]
        private IWebElement LnqTenantAddress { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div[2]/div/div/div/div[2]/div[2]/div[2]/div/a[1]")]
        private IWebElement LnqAddTenant { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[2]/div/form/fieldset[1]/div[2]/div[1]/div/input")]
        private IWebElement TxtTenantEmail { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[2]/div/form/fieldset[1]/div[2]/div[2]/div/select/option[1]")]
        private IWebElement IsMainTenant { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[2]/div/form/fieldset[1]/div[3]/div[1]/div/input")]
        private IWebElement TxtFirstName { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='BasicDetail']/div[3]/div[2]/div/input")]
        private IWebElement TxtLastName { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[2]/div/form/fieldset[1]/div[4]/div[1]/div/input")]
        private IWebElement DtRentStartDate { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[2]/div/form/fieldset[1]/div[5]/div[1]/div/input")]
        private IWebElement TxtRentAmount { get; set; }
        [FindsBy(How = How.XPath, Using ="html/body/div/section/div[2]/div/form/fieldset[1]/div[5]/div[2]/div/select/option[2]")]
        private IWebElement DDLPayFrequency { get; set; }
        [FindsBy (How = How.XPath, Using = "html/body/div/section/div[2]/div/form/fieldset[1]/div[6]/div[1]/div/input")]
        private IWebElement DtPayStartDate { get; set; }
        [FindsBy (How= How.XPath, Using = "html/body/div/section/div[2]/div/form/fieldset[1]/div[6]/div[2]/div/select/option[4]")]
        private IWebElement DDLPayDuedate { get; set; }
        [FindsBy (How = How.XPath, Using = "html/body/div/section/div[2]/div/form/fieldset[1]/div[7]/div/div/input[1]")]
        private IWebElement BtnAddTenantNext { get; set; }

        internal void AddTenantMethod()
        {
            try
            {
                ExcelLib.PopulateInCollection(Base.ExcelPath, "TenantDetails");
                if (Driver.driver.PageSource.Contains("Add Tenant"))
                {
                    LnqTenantAddress.Click();
                    Thread.Sleep(3000);
                    bool bEmail = TxtTenantEmail.Enabled;
                    if (bEmail)
                    {
                        TxtTenantEmail.SendKeys(ExcelLib.ReadData(3, "EmailId"));
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Email Id field is enabled and value from excel sheet passed");
                        IsMainTenant.Click();
                        Thread.Sleep(3000);
                        bool bFName = TxtFirstName.Enabled;
                        if (bFName)
                        {
                            TxtFirstName.SendKeys(ExcelLib.ReadData(3, "FirstName"));
                            TxtLastName.SendKeys(ExcelLib.ReadData(3, "LastName"));
                            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Its a new email id; First Name and Last name filled with Excel sheet");
                            // DtRentStartDate.Click();
                            //DtRentStartDate.Clear();
                            //DtRentStartDate.SendKeys(ExcelLib.ReadData(3, "StartDate"));

                        }
                        else
                        {
                            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "First Name & Last Name has been auto filled with the email id");
                        }
                        Driver.wait(7);
                         DtRentStartDate.Click();
                      
                         bool bRentField = TxtRentAmount.Enabled;
                         if (bRentField)
                            {
                                TxtRentAmount.SendKeys(ExcelLib.ReadData(3, "RentAmount"));
                                decimal d;

                                if (decimal.TryParse(ExcelLib.ReadData(3, "RentAmount"), out d))
                                {
                                    DDLPayFrequency.Click();
                                    Thread.Sleep(2000);
                                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Rent Amount field has been verified for decimal values");
                                    DtPayStartDate.Click();
                                    //DtPayStartDate.Clear();
                                    //DtPayStartDate.SendKeys(ExcelLib.ReadData(3, "PaymentStartDate"));
                                    DDLPayDuedate.Click();
                                    if (BtnAddTenantNext.Enabled)
                                    {
                                        BtnAddTenantNext.Click();
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

                }
                
            }
            catch(Exception ex)
            {
                string excepMessage = ex.Message;
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, excepMessage);
            }
        }

    }
}
