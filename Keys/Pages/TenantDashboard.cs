using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Keys.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Keys.Pages
{
    public class TenantDashboard
    {
        internal TenantDashboard()
        {
            PageFactory.InitElements  (Driver.driver, this);
        }
        [FindsBy(How = How.XPath, Using = "html/body/nav/div/ul/li[1]/a")]
        private IWebElement LnqDashboard { get; set; }
        [FindsBy(How= How.XPath, Using = "html/body/div/section/div[2]/div[1]/div/div[2]/div[1]/div[1]/a/p")]
        private IWebElement LnqSendRequest { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[2]/div[1]/div/div[2]/div[1]/div[2]/div[2]")]
        private IWebElement LnqMyRequest { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div/section/div[2]/div[1]/div/div[2]/div[1]/div[3]/a")]
        private IWebElement LnqLandlordRequest { get; set; }
        [FindsBy (How = How.XPath, Using = "html/body/div/section/div[2]/div[1]/div/div[2]/div[2]/div/div/div[1]/div[2]")]
        private IWebElement LnqMyRentals { get; set; }
        [FindsBy(How= How.XPath, Using = "html/body/div/section/div[2]/div[1]/div/div[2]/div[2]/div/div/div[2]/div[2]")]
        private IWebElement LnqMyApplications { get; set; }
        [FindsBy(How= How.XPath, Using = "html/body/div/section/div[2]/div[1]/div/div[2]/div[2]/div/div/div[3]/div[3]")]
        private IWebElement LnqMyWatchlist { get; set; }
        [FindsBy(How =How.XPath, Using = "html/body/div/section/div[1]/div[3]/div[1]/div/div/div[2]/div[1]")]
        private IWebElement SendReq { get; set; }
        [FindsBy(How =How.XPath, Using = "html/body/div/section/div[1]/div[3]/div[1]/div/div/div[2]/div[2]")]
        private IWebElement MyReq { get; set; }
        [FindsBy(How =How.XPath, Using = "html/body/div/section/div[1]/div[3]/div[1]/div/div/div[2]/div[3]/a")]
        private IWebElement LandlordReq { get; set; }


        //click on Dashboard
        //
        internal void DashboardMethod()
        {
            try
            {
                LnqDashboard.Click();
                Driver.wait(5);
                string title = Driver.driver.Title;
                Assert.AreEqual("Dashboard", title);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //Method to click on Send Request link in the Quick Links
        internal void SendRequestMethod()
        {
            try
            {
                LnqSendRequest.Click();
                Assert.AreEqual("SendRequest", Driver.driver.Title);
            }
            catch (Exception Ex)
            { throw Ex; }
        }

        //Method to click on My Requests link in the Quick Links
        internal void MyRequestMethod()
        {
            try
            {
                //click on MyRequestMethod with validation
                LnqMyRequest.Click();
                Driver.wait(1);
                string stitle = Driver.driver.Title;
                Assert.AreEqual("Tenant | My Requests", stitle);
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Navigation to My Request page is-->" + stitle);
                //Assert.Equals("Tenant| My Requests", title);
            }
            catch
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Quick Link of My Request page is not working as expected.");
                throw;
            }
        }
        internal void MyRental()
        {
            try
            {
                LnqMyRentals.Click();
                Driver.wait(1);
                string ytitle = Driver.driver.Title;
                Assert.AreEqual("My Rentals", ytitle);
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Navigation to My Rentals page is successful");
            }
            catch
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Navigation to My Rentals page is not validated");
            }

        }

        internal void MyRentalSendReq()
        {
            SendReq.Click();
            bool Bpage = Driver.driver.PageSource.Contains("Rental Request Form");
            if(!Bpage)
            { Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Validation against Page having *Rental request form* failed"); }
        }

        internal void MyRentalMyReq()
        {
            MyReq.Click();
            bool Bpage = Driver.driver.PageSource.Contains("My Requests");
            if (!Bpage)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Validation against Page having *My Requests* failed");
            }
        }
        //Method to click on My Application link in the Quick Links
        internal void MyApplication()
        {
            try
            {

                LnqMyApplications.Click();
                string atitle = Driver.driver.Title;
                Assert.AreEqual("Tenant | Rental Applications", atitle);
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Navigation to My Request page is-->" + atitle);
            }
            catch
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Navigation to My Request page is not successful.");
                throw;
            }
        }

        //Method to click on Landlord Request link in the Quick Links
        internal void LandLordRequestMethod()
        {
            LnqLandlordRequest.Click();
            Assert.AreEqual("Landlord Request", Driver.driver.Title);
        }

        //Method to click on My Watchlist page in the Quick links
        internal void MyWatchlist()
        {
            LnqMyWatchlist.Click();
            Assert.AreEqual("My Watchlist", Driver.driver.Title);
            //Assert.That(element.Text, Is.Not.Null, "My Watchlist");
        }
    }

}
