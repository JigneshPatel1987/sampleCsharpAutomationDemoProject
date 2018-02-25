using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keys.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Keys.Pages
{
    public class PropertyFinDetails
    {
        internal PropertyFinDetails()
        {
            PageFactory.InitElements(Driver.driver, this);
        }
        [FindsBy (How = How.XPath, Using= "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div[1]/div/a")]
        private IWebElement HomeValue { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div[1]/div/table/tbody/tr[2]/td[1]/input")]
        private IWebElement HomeValueAmount { get; set; }
        [FindsBy(How =How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div[1]/div/table/tbody/tr[2]/td[2]/select/option[2]")]
        private IWebElement HomeValueType { get; set; }
        [FindsBy(How =How.XPath,Using = "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div[1]/div/table/tbody/tr[2]/td[3]/input")]
        private IWebElement HomeValueDateAdded { get; set; }
        [FindsBy (How = How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div[1]/div/table/tbody/tr[2]/td[4]/input")]
        private IWebElement IsActiveCheckBox { get; set; }
        [FindsBy (How = How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div[1]/div/table/tbody/tr[2]/td[5]/buton")]
        private IWebElement HomeValueSave { get; set; }

        [FindsBy (How = How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div[2]/div/a")]
        private IWebElement AddRepayments { get; set; }
        [FindsBy (How = How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div[2]/div/table/tbody/tr/td[1]/input")]
        private IWebElement RepaymentsAmount { get; set; }
        [FindsBy (How = How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div[2]/div/table/tbody/tr/td[2]/select/option[2]")]
        private IWebElement RepaymentsFrequency { get; set; }
        [FindsBy (How = How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div[2]/div/table/tbody/tr/td[3]/input")]
        private IWebElement RepaymentsStartDate { get; set; }
        [FindsBy (How = How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div[2]/div/table/tbody/tr/td[4]/input")]
        private IWebElement RepaymentsEndDate { get; set; }
        [FindsBy (How = How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div[2]/div/table/tbody/tr/td[5]/buton")]
        private IWebElement RepaymentsSave { get; set; }


        [FindsBy (How = How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div[3]/a")]
        private IWebElement AddExpense { get; set; }
        [FindsBy (How = How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div[3]/table/tbody/tr/td[1]/input")]
        private IWebElement ExpensesAmount { get; set; }
        [FindsBy (How = How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div[3]/table/tbody/tr/td[2]/textarea")]
        private IWebElement ExpensesDescription { get; set; }
        [FindsBy (How =How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div[3]/table/tbody/tr/td[3]/input")]
        private IWebElement ExpensesDateAdded { get; set; }
        [FindsBy (How = How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div[3]/table/tbody/tr/td[4]/buton")]
        private IWebElement ExpensesSave { get; set; }

        [FindsBy (How= How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div[4]/a")]
        private IWebElement AddRentalPayment { get; set; }
        [FindsBy (How = How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div[4]/table/tbody/tr/td[1]/input")]
        private IWebElement RentalPaymentsAmount { get; set; }
        [FindsBy (How = How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div[4]/table/tbody/tr/td[2]/select/option[2]")]
        private IWebElement RentalPaymentFrequency { get; set; }
        [FindsBy (How = How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div[4]/table/tbody/tr/td[3]/input")]
        private IWebElement RentalPaymentDateAdded { get; set; }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div[4]/table/tbody/tr/td[4]/button[1]")]
        private IWebElement RentalPaySave { get; set; }

        internal void HomeValueMethod()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "PropertyFinDetails");
            HomeValue.Click();
            Driver.wait(2);
            HomeValueAmount.SendKeys(ExcelLib.ReadData(2, "HomeValueAmount"));
            HomeValueType.Click();
            HomeValueDateAdded.SendKeys(ExcelLib.ReadData(2, "DateAdded"));
            IsActiveCheckBox.Click();
            Driver.wait(2);
            HomeValueSave.Click();
            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Home value Added");
        }
        internal void RepaymentsMethod()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "PropertyFinDetails");
            AddRepayments.Click();
            Driver.wait(2);
            RepaymentsAmount.SendKeys(ExcelLib.ReadData(2, "RepaymentsAmount"));
            RepaymentsFrequency.Click();
            RepaymentsStartDate.SendKeys(ExcelLib.ReadData(2, "RepaymentsStartDate"));
            RepaymentsEndDate.SendKeys(ExcelLib.ReadData(2, "RepaymentsEndDate"));
            Driver.wait(2);
            RepaymentsSave.Click();
            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Repayment Method Added");
        }
        internal void ExpensesMethod()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "PropertyFinDetails");
            AddExpense.Click();
            Driver.wait(2);
            ExpensesAmount.SendKeys(ExcelLib.ReadData(2, "ExpensesAmount"));
            ExpensesDescription.SendKeys(ExcelLib.ReadData(2, "ExpensesDescription"));
            ExpensesDateAdded.SendKeys(ExcelLib.ReadData(2, "ExpenseDate"));
            Driver.wait(2);
            ExpensesSave.Click();
            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Expenses Added");
        }
        internal void RentalPaymentMethod()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "PropertyFinDetails");
            AddRentalPayment.Click();
            Driver.wait(2);
            RentalPaymentsAmount.SendKeys(ExcelLib.ReadData(2, "RentalPaymentAmount"));
            RentalPaymentFrequency.Click();
            RentalPaymentDateAdded.SendKeys(ExcelLib.ReadData(2, "RentalPaymentDateAdded"));
            Driver.wait(2);
            RentalPaySave.Click();
            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Rental Payment Added");
        }

    }
}
