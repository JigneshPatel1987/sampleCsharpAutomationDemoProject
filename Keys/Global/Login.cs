using Keys.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keys.Global
{
    class Login
    {
        // Initializing the web elements 
        internal Login()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        // Finding the Email Field
        [FindsBy(How = How.XPath, Using = "//*[@id='UserName']")]
        private IWebElement Email { get; set; }

        // Finding the Password Field
        [FindsBy(How = How.XPath, Using = "//*[@id='Password']")]
        private IWebElement PassWord { get; set; }

        // Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//*[@id='sign_in']/div[3]/button[1]")]
        private IWebElement loginButton { get; set; }

        internal void LoginSuccessfull()
        {
            // Populating the data from Excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Login");
            // Navigating to Login page using value from Excel
            Driver.driver.Navigate().GoToUrl(ExcelLib.ReadData(3, "url"));
            
            Driver.driver.Manage().Window.Maximize();

            var rowid = Int32.Parse(KeysResource.LoginAs);
            
            // Sending the username 
            Email.SendKeys(ExcelLib.ReadData(rowid, "Email"));
            // Sending the password
            PassWord.SendKeys(ExcelLib.ReadData(rowid, "Password"));
            // Clicking on the login button
            loginButton.Click();
        }


    }
}
