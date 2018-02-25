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
    public class TenantsMyRequest
    {
        internal TenantsMyRequest()
        {
            PageFactory.InitElements(Driver.driver, this);
        }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[1]/div[3]/div[1]/div/form/div/input")]
        private IWebElement TxtSearchBar { get; set; } 
        [FindsBy(How=How.XPath,Using = "html/body/div/section/div[1]/div[3]/div[1]/div/form/div/div/button")]
        private IWebElement BtnSearch { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[1]/div[3]/div[2]/div/div/select/option[2]")]
        private IWebElement LnqSortBy { get; set; }
        [FindsBy(How= How.XPath, Using = "html/body/div/section/div[1]/div[5]/div[1]/div/div/div/div[2]/div[4]/button[2]")]
        private IWebElement LnqEdit { get; set; }
        [FindsBy(How= How.XPath, Using = "html/body/div/section/div[3]/div[2]/form/fieldset/div/div/div[1]/textarea")]
        private IWebElement TxtDescription { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[3]/div[2]/form/fieldset/div/div/div[4]/div/input")]
        private IWebElement LnqChooseFile { get; set; }
        [FindsBy(How= How.XPath, Using = "html/body/div/section/div[3]/div[2]/form/fieldset/div/div/div[6]/button[1]")]
        private IWebElement BtnSave { get; set; }

        [FindsBy(How= How.XPath, Using = "html/body/div/section/div[1]/div[1]/div[2]/div/a")]
        private IWebElement LnqAddnewrequest { get; set; }
        //[FindsBy(How= How.XPath, Using = "html/body/div/section/div/div[2]/form/fieldset/div[1]/div/div/select")]
        //private IWebElement DDLSelectProp { get; set; }
        
        [FindsBy(How= How.XPath, Using = "html/body/div/section/div/div[2]/form/fieldset/div[3]/div/div/select")]
        private IWebElement DDLType { get; set; }
        [FindsBy(How= How.XPath, Using = "html/body/div/section/div/div[2]/form/fieldset/div[4]/div/div/textarea")]
        private IWebElement TxtMessage { get; set; }
        [FindsBy(How= How.XPath, Using = "html/body/div/section/div/div[2]/form/fieldset/div[7]/div/button")]
        private IWebElement BtnSubmit { get; set; }

       
        internal void EditRequestMethod()
        {
            try
            {
                ExcelLib.PopulateInCollection(Base.ExcelPath, "TenantMyRequest");
                //validate if User is on My requests page
                Driver.driver.PageSource.Contains("My Requests");

                //Get Job Description from Excel sheet and search
                TxtSearchBar.SendKeys(ExcelLib.ReadData(2, "Job Description"));
                BtnSearch.Click();
                Driver.wait(2);
                LnqSortBy.Click();

                //validate if Job Description is as selected
                string JobDescription = Driver.driver.FindElement(By.XPath("html/body/div/section/div[1]/div[5]/div[1]/div/div/div/div[2]/div[3]/div/div[2]/span")).Text;
                JobDescription.Contains(ExcelLib.ReadData(2, "Job Description"));

                //Edit the Job Description and Submit the form
                LnqEdit.Click();
                TxtDescription.SendKeys(ExcelLib.ReadData(2, "New Description"));
                BtnSave.Submit();

                //Validate the success message
                //string message = Driver.driver.FindElement(By.XPath("html/body/div/section/div[3]/div[2]/form")).Text;
                string message = Driver.driver.SwitchTo().Alert().Text;
                Assert.AreEqual(message, "Item edited successfully");

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        internal void ClickOnAddNewRequest()
        {
            //Click on Add New Request link
            LnqAddnewrequest.Click();
            Driver.wait(2);
            //IWebElement MyReqPage = Driver.driver.FindElement(By.XPath(".//*[@id='RequestPage']/div[1]/div/h3"));

            //Validate  navigation to "Rental Request Form" page
            Driver.driver.PageSource.Contains("RequestPage");
        }
        internal void AddNewRequest()
        {
            try
            {
                ExcelLib.PopulateInCollection(Base.ExcelPath, "TenantMyRequest");
                //IWebElement MyReqPage = Driver.driver.FindElement(By.XPath(".//*[@id='RequestPage']/div[1]/div/h3"));

                //Validate  navigation to "Rental Request Form" page
                bool bPage = Driver.driver.PageSource.Contains("RequestPage");
                if (bPage)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Navigated to Rental Request Form");
                }

                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Page details not verified");
                }

                //Select 3rd option from the Drop down list
                IWebElement SelectPropertyDDL = Driver.driver.FindElement(By.XPath("html/body/div/section/div/div[2]/form/fieldset/div[1]/div/div/select"));
                var selectElement = new SelectElement(SelectPropertyDDL);
                selectElement.SelectByIndex(2);

                //Validate Property Detail is reflecting the selction of Property
                string PropertyDetail = Driver.driver.FindElement(By.XPath("html/body/div/section/div/div[2]/form/fieldset/div[2]/div[2]/div[1]/div/span")).Text;
                bool bRet = PropertyDetail.Contains("580 Great South Road Papakura");

                if (!bRet)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Property Details doesn't match");
                }
                //DDLSelectProp.Click();

                IWebElement JobReqType = Driver.driver.FindElement(By.Id("jobRequestType"));
                var jSelectElement = new SelectElement(JobReqType);
                jSelectElement.SelectByIndex(1);

                //Validate if TextField under Message is visible and fill the data from excel sheet
                bool bEnable = TxtMessage.Enabled;
                if (bEnable)
                {
                    TxtMessage.SendKeys(ExcelLib.ReadData(2, "Message"));
                    Driver.wait(3);

                    BtnSubmit.Click();
                    //verify the PopMessage text
                    //string AlertMsg = Driver.driver.SwitchTo().Alert().Text;
                    //if (AlertMsg == "Item added successful")
                    //{
                    //    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "New request submitted");
                    //}
                    //else { Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, AlertMsg); }
                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Message box not enabled");
                }
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.Message;
            }

            
        }

    }
}
