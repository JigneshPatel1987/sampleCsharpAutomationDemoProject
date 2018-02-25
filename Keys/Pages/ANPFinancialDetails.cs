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
    public class ANPFinancialDetails
    {
        internal ANPFinancialDetails()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        //Financial Details Form
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[2]/div[1]/div[1]/div/input")]
        private IWebElement PurchasePrice { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[2]/div[1]/div[2]/div/input")]
        private IWebElement Mortgage { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[2]/div[2]/div[1]/div/input")]
        private IWebElement Homevalue { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[2]/div[9]/div/button[3]")]
        private IWebElement ClickNext { get; set; }

        internal void FinDetailsMethod()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "FinancialDetails");
            Driver.wait(2);
            //Verify the title of Webpage
            Assert.IsTrue(Driver.driver.PageSource.Contains("Purchase Price"));
            try
            {
                PurchasePrice.SendKeys(ExcelLib.ReadData(2, "PurchasePrice"));
                decimal d;
                if (decimal.TryParse(ExcelLib.ReadData(2, "PurchasePrice"), out d))
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Purchase Price field has been filled with integer");
                    Mortgage.SendKeys(ExcelLib.ReadData(2, "Mortgage"));
                    decimal dM;
                    if (decimal.TryParse(ExcelLib.ReadData(2, "Mortgage"), out d))
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Purchase Price field has been filled with integer");
                        Homevalue.SendKeys(ExcelLib.ReadData(2, "HomeValue"));
                        Driver.wait(2);
                        if (ClickNext.Enabled)
                        {
                            ClickNext.Click();
                            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Method to enter Financial details executed and mandatory fileds verified");
                        }
                        else
                        {
                            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Next button is not enabled");
                        }
                    }
                    else
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Mortgage Field has been not been filled with numeric value");
                    }
                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Purchase Price field has not been filled with a numeric character");
                }
            }
            catch (Exception ex)
            {
                string excepMesg = ex.Message;
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Exception Message:" + excepMesg);
            }
        }
    }
}
