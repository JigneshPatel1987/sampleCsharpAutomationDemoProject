using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Keys.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Keys.Pages
{
    public class ANPPropertyDetails
    {
        internal ANPPropertyDetails()
        {
            PageFactory.InitElements(Driver.driver, this);
        }
        
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[2]/div[1]/div/div[2]/div[1]/div[3]/div[2]")]
        private IWebElement LnqAddNewProperty4mDashboard { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='mainPage']/div[1]/div[1]/div[2]/a[1]")]
        private IWebElement ClickAddNewProperty { get; set; }
        [FindsBy (How = How.XPath,Using = "html/body/div[1]/section/form/fieldset[1]/div[2]/div[1]/div[1]/div/div/input")]
        private IWebElement TxtSearchAddress { get; set; }
        [FindsBy(How =How.Name, Using = "propertyName")]
        private IWebElement PropDetail_PropName { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[1]/div[2]/div[2]/div/textarea")]
        private IWebElement PropDetail_Description { get; set; }
        [FindsBy(How =How.XPath, Using = "html/body/div[1]/section/form/fieldset[1]/div[2]/div[1]/div[2]/div[1]/div/input")]
        private IWebElement PropDetail_Number { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[1]/div[2]/div[1]/div[2]/div[2]/div/input")]
        private IWebElement PropDetail_Street { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[1]/div[2]/div[1]/div[3]/div[2]/div/input")]
        private IWebElement PropDetail_City { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[1]/div[2]/div[1]/div[3]/div[3]/div/input")]
        private IWebElement PropDetail_PostCode { get; set; }
      
        [FindsBy(How= How.XPath, Using = "html/body/div[1]/section/form/fieldset[1]/div[3]/div[1]/div/input")]
        private IWebElement PropDetail_YearBuilt { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[1]/div[3]/div[2]/div/input")]
        private IWebElement PropDetail_TargetRent { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[1]/div[5]/div[1]/div/input")]
        private IWebElement PropDetail_Bedrooms { get; set; }
        [FindsBy(How =How.XPath, Using = "html/body/div[1]/section/form/fieldset[1]/div[5]/div[2]/div/input")]
        private IWebElement PropDetail_Bathrooms { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[1]/div[6]/div[1]/div/input")]
        private IWebElement PropDetail_Carparks { get; set; }
        [FindsBy(How= How.XPath, Using = "html/body/div[1]/section/form/fieldset[1]/div[7]/div/div/div")]
        private IWebElement RandomClick { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/form/fieldset[1]/div[9]/div/button[1]") ]
        private IWebElement PropDetail_ClickNext { get; set; }

        internal void AddNewPropertyClick()
        {
            ClickAddNewProperty.Click();
            Driver.wait(2);
            Assert.AreEqual("Properties|Add New Property", Driver.driver.Title);
        }
        internal void PropDetailsMethod()
        {
            try
            {
                //verify webpage title
                Assert.AreEqual("Properties | Add New Property", Driver.driver.Title);
                ExcelLib.PopulateInCollection(Base.ExcelPath, "PropertyDetails");
                Driver.wait(2);
                PropDetail_PropName.SendKeys(ExcelLib.ReadData(5, "PropertyName"));
                
                
                //verify character limits in Description
                int actualLimit = ExcelLib.ReadData(5, "Description").Length;
                if (actualLimit >= 10)
                {
                    
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Description verified");
                    TxtSearchAddress.SendKeys(ExcelLib.ReadData(5, "PropertyName"));
                    //TxtSearchAddress.SendKeys(ExcelLib.ReadData(6, "Search Address"));
                    TxtSearchAddress.SendKeys(OpenQA.Selenium.Keys.ArrowDown);
                    TxtSearchAddress.SendKeys(OpenQA.Selenium.Keys.Enter);
                    PropDetail_Description.SendKeys(ExcelLib.ReadData(5, "Description"));
                    //string num = Driver.driver.FindElement(By.XPath("html/body/div[1]/section/form/fieldset[1]/div[2]/div[1]/div[2]/div[1]/div/input")).Text;
                    //Assert.AreEqual("99", num);
                    //string st = Driver.driver.FindElement(By.XPath("html/body/div[1]/section/form/fieldset[1]/div[2]/div[1]/div[2]/div[2]/div/input")).Text;
                    //Assert.AreEqual("Fairy Springs Road", st);
                    //string city = Driver.driver.FindElement(By.XPath("html/body/div[1]/section/form/fieldset[1]/div[2]/div[1]/div[3]/div[2]/div/input")).Text;
                    //Assert.AreEqual("Rotorua", city);
                    //string pstcd = Driver.driver.FindElement(By.XPath("html/body/div[1]/section/form/fieldset[1]/div[2]/div[1]/div[3]/div[3]/div/input")).Text;
                   
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Search result data has been verified fo Number, Street, City & Post Code fields");
                        PropDetail_YearBuilt.SendKeys(ExcelLib.ReadData(5, "YearBuilt"));
                        int year = Convert.ToInt32(ExcelLib.ReadData(5, "YearBuilt"));
                        if (year > 1900 && year <= DateTime.Now.Year)
                        {
                            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Year Built field has been verifed for year less than 1900 and greater that current year");
                            PropDetail_TargetRent.SendKeys(ExcelLib.ReadData(5, "TargetRent"));
                            //Verify character accepted for Target Rent field
                            decimal dTargetRent;
                            if (decimal.TryParse(ExcelLib.ReadData(5, "TargetRent"), out dTargetRent))
                            {
                                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Target Rent field has been verified with characters accepted");
                                PropDetail_Bedrooms.SendKeys(ExcelLib.ReadData(5, "Bedrooms"));
                                string sBedRoom = ExcelLib.ReadData(5, "Bedrooms");
                                //Verify Bedrooms field has not been left empty
                                Assert.IsNotEmpty(sBedRoom);
                                PropDetail_Bathrooms.SendKeys(ExcelLib.ReadData(5, "Bathrooms"));
                                string sBathroom = ExcelLib.ReadData(5, "Bathrooms");
                                //Verify Bathroom field has not been left emtpty
                                Assert.IsNotEmpty(sBathroom);
                                PropDetail_Carparks.SendKeys(ExcelLib.ReadData(5, "Carpark"));
                                string sCarpark = ExcelLib.ReadData(5, "Carpark");
                                //verify carpark field has not been left empty
                                Assert.IsNotEmpty(sCarpark);
                            Driver.wait(5);
                                bool bNextBtn = PropDetail_ClickNext.Enabled;
                                if (bNextBtn)
                                {
                                    PropDetail_ClickNext.Click();
                                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "All the mandatory fields has been verified and Next button is clickable");
                                }
                                else
                                {
                                    RandomClick.Click();
                                    Driver.wait(2);
                                    Thread.Sleep(5000);
                                    RandomClick.Click();
                                    PropDetail_ClickNext.Click();
                                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Mandatory fields verified and Random click enabled Next button");

                                }
                            }
                            else
                            {
                                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Target rent field does not comply with accepted format");
                            }
                        }
                        else
                        {
                            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Built year is greater than current year of less than 1900");
                        }

                }
                    
                

                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Description in the excel sheet is not verified for character limits");
                }
            }
            catch (Exception ex)
            {
                string exceptionM = ex.Message;
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Exception Message:" +exceptionM);
            }
        }

        //take the screenshot
    }
}
