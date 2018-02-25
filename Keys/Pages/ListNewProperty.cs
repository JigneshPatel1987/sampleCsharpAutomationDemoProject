using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keys.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Keys.Pages
{
    public class ListNewProperty
    {
        internal ListNewProperty()
        {
            PageFactory.InitElements(Driver.driver, this);
        }
        //[FindsBy(How = How.CssSelector, Using = ("select.form-control"))]
        [FindsBy(How = How.XPath, Using=("html/body/div/section/div[2]/form/fieldset/div[1]/div/div/select/option[2]"))]
        private IWebElement SelectProperty { get; set; }
        [FindsBy(How = How.XPath, Using = ("html/body/div/section/div[2]/form/fieldset/div[2]/div[1]/div[1]/div/div/input"))]
        private IWebElement PropTitle { get; set; }
        [FindsBy(How = How.XPath, Using = ("html/body/div/section/div[2]/form/fieldset/div[2]/div[2]/div/textarea"))]
        private IWebElement PropDescription { get; set; }
        [FindsBy(How = How.XPath, Using = ("html/body/div/section/div[2]/form/fieldset/div[2]/div[1]/div[2]/div/div/input"))]
        private IWebElement PropMovingCost { get; set; }
        [FindsBy(How = How.XPath, Using = ("html/body/div/section/div[2]/form/fieldset/div[3]/div[1]/div/input"))]
        private IWebElement PropTargetRent { get; set; }
        [FindsBy(How = How.XPath, Using = ("html/body/div/section/div[2]/form/fieldset/div[4]/div[1]/div/input"))]
        private IWebElement PropAvailabledate { get; set; }
        [FindsBy(How = How.XPath, Using = ("html/body/div/section/div[2]/form/fieldset/div[5]/div[1]/div/input"))]
        private IWebElement PropOccupantCount { get; set; }
        [FindsBy(How = How.XPath, Using = ("html/body/div/section/div[2]/form/fieldset/div[8]/div/button[1]"))]
        private IWebElement PropSave { get; set; }

        internal void ListPropMethod()
        {
            try
            {
                SelectProperty.Click();
                Driver.wait(2);

                ExcelLib.PopulateInCollection(Base.ExcelPath, "PropertyDetails");
                PropTitle.SendKeys(ExcelLib.ReadData(2, "Title"));
                int actualLimit = ExcelLib.ReadData(2,"Title").Length;
                if(actualLimit >= 10)
                {
                    PropDescription.SendKeys(ExcelLib.ReadData(2, "Description"));
                    int DescLimit = ExcelLib.ReadData(2,"Description").Length;
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Limit of characters for Title is verified");
                    if (DescLimit >= 10)
                    {
                        PropMovingCost.SendKeys(ExcelLib.ReadData(2, "Moving Cost"));
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Limit of characters in Description is verified");
                        decimal d;
                        if (decimal.TryParse(ExcelLib.ReadData(2,"Moving Cost"),  out d))
                        {
                            PropTargetRent.SendKeys(ExcelLib.ReadData(2, "TargetRent"));
                            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Limit of Decimal in Moving Cost is verified");
                            if (decimal.TryParse(ExcelLib.ReadData(2, "TargetRent"), out d))
                            {
                                PropAvailabledate.Click();
                                PropOccupantCount.SendKeys(ExcelLib.ReadData(2, "Occupants Count"));
                                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Limit of Decimal in Target Rent is verified");
                                if (decimal.TryParse(ExcelLib.ReadData(2, "Occupants Count"), out d))
                                {
                                    PropSave.Click();
                                    Driver.wait(5);
                                    Driver.driver.SwitchTo().Alert().Accept();
                                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Numeric Value for Occupants count has been verified");
                                }
                                else
                                {
                                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Occupant Count doesn't have numeric value");
                                }
                                //}
                                //else
                                //{
                                  //  Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Available date format is not accepted");
                                //}

                            }
                            else
                            {
                                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Target Rent doesn't have decimal value");
                            }
                        }
                        else
                        {
                            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Moving Cost doesn't have decimal value");
                        }

                    }
                    else
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Description does not contain minimun of 10 Characters");
                    }
                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Limit of characters in Title is less than 10");
                }
            }
            catch (Exception Ex)
            {
                string excepMessage = Ex.Message;
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, excepMessage +"Error while adding a Property to List as Rental");
            }

        }
    }
}
