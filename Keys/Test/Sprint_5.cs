using Keys.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keys.Global;

namespace Keys.Test
{
    class Sprint_1
    {
        [TestFixture]
        [Category("Sprint_5")]
        class Sprint_1_Administration : Base
        {

            // Add a new user in the Account Managment
            [Test]
            public void Register_CreateNewUser()
            {
                // creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Register New Customer");
                Register obj = new Register();
                obj.register();

            }

           [Test]
           public void TC_004_03()
            {
                try
                {
                    test = extent.StartTest("Add New Property");
                    try
                    {
                        OwnerNavigation ObjOwnerNavigation = new OwnerNavigation();
                        ObjOwnerNavigation.OwnerMethod();
                    }
                    catch (Exception)
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Owner Properties navigation");
                        throw;
                    }
                    try
                    {
                        ANPPropertyDetails ObjPropertyDetails = new ANPPropertyDetails();
                        ObjPropertyDetails.AddNewPropertyClick();
                        ObjPropertyDetails.PropDetailsMethod();
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Property Details are entered successfully");
                    }
                    catch (Exception)
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Property Details not entered");
                        throw;
                    }
                    try
                    {
                        ANPFinancialDetails ObjFinancialDetails = new ANPFinancialDetails();
                        ObjFinancialDetails.FinDetailsMethod();
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Financial details are added successfully");
                    }
                    catch(Exception)
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Financial details not entered");
                        throw;
                    }
                    try
                    {
                        ANPTenantDetails ObjTenantDetails = new ANPTenantDetails();
                        ObjTenantDetails.TenantDetails4mExcel();
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Tenant Details are added successfully");
                    }
                    catch (Exception)
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Tenant Detail are not entered");
                        throw;
                    }
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Property is added successfully");
                }
                catch (Exception)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Property could not be added");
                }
            }
            [Test]
            public void TC_009_02()
            {
                test = extent.StartTest("Verifying Financial Details of listed property");
                
                   OwnerNavigation ObjOwnerNavigation = new OwnerNavigation();
                    ObjOwnerNavigation.OwnerMethod();
                    ObjOwnerNavigation.SearchMethod();
                    ObjOwnerNavigation.FinanceDMethod();
                    PropertyFinDetails propertyFinDetails = new PropertyFinDetails();
                    propertyFinDetails.HomeValueMethod();
                    propertyFinDetails.RepaymentsMethod();
                    propertyFinDetails.ExpensesMethod();
                    propertyFinDetails.RentalPaymentMethod();
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Financial Details Added");
                //Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Check for information, Test case failed");
                
            }
            [Test]
            public void TC_013_03()
            {
                try
                {
                    try
                    {
                        test = extent.StartTest(" Add Tenants Detail for listed property");
                        OwnerNavigation ObjOwnerNavigation = new OwnerNavigation();
                        ObjOwnerNavigation.OwnerMethod();
                        ObjOwnerNavigation.SearchMethod();
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Searched property to Add tenant");
                    }
                    catch
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Error in Search property to Add tenant");
                        throw;
                    }
                    try
                    {
                        AddTenant ObjAddTenant = new AddTenant();
                        ObjAddTenant.AddTenantMethod();
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Executed Add tenant");
                    }
                    catch
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Error in execution of Add tenant");
                        throw;
                    }
                    try
                    {
                        AddTenantLiabilityDetails ObjAddLiabiltyMethod = new AddTenantLiabilityDetails();
                        ObjAddLiabiltyMethod.AddLiabiltyMethod();
                        ObjAddLiabiltyMethod.CompleteTenantMethod();
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Tenant Details Added");
                    }
                    catch
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Error while Adding Tenant Liability Details");
                        throw;
                    }
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Added a new tenant to the listed Property");
                }
                catch
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Error in Adding a new tenant to the listed Property");
                }
            }
            [Test]
            public void TC_PropertyForRent()
            {
                try
                {
                    test = extent.StartTest("Apply for Property to Rent");
                    PropertyForRent ObjPropertyForRent = new PropertyForRent();
                    ObjPropertyForRent.ClickPropertyForRent();
                    ObjPropertyForRent.SearchMethod();
                    ObjPropertyForRent.ApplyForProperty();
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Applied for Property For Rent");
                }
                catch(Exception)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, " Error in Apply for Property to Rent");
                }
            }
            [Test]
            public void TC_EditApplictaionTenant()
            {
                try
                {
                    test = extent.StartTest("Edit Application in Tenants Module");
                    EditApplicationTenant ObjEditApplicationTenant = new EditApplicationTenant();
                    ObjEditApplicationTenant.TenantMethod();
                    ObjEditApplicationTenant.SearchMethod();
                    ObjEditApplicationTenant.EditApplication();
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Edited Application for Property in Tenants Module");
                }

                catch(Exception)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Error occured while editing Application for Property in Tenants Module");
                }
            }
            [Test]
            //Test case for Send request link on Tenant Dashboard
            public void TC_TenantDB_SendRequest()
            {
                try
                {
                    test = extent.StartTest("Check Send Request link on Tenants Dashboard");
                    TenantDashboard tenantDashboard = new TenantDashboard();
                    tenantDashboard.DashboardMethod();
                    tenantDashboard.SendRequestMethod();
                    TenantsMyRequest tenantsMyRequest = new TenantsMyRequest();
                    tenantsMyRequest.AddNewRequest();
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Testing Send Request using automation is successful");
                }
                catch
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Send Request using automation needs to be verified again");
                    throw;
                }
            }
            [Test]       
            public void TC_TenantDB_MyReq_AddNewRequest()

            {
                try
                {
                    test = extent.StartTest("Check *My Request --> Add New request* link on Tenants dashboard");

                    TenantDashboard tenantDashboard = new TenantDashboard();
                    tenantDashboard.DashboardMethod();
                    tenantDashboard.MyRequestMethod();
                    TenantsMyRequest tenantsMyRequest = new TenantsMyRequest();
                    tenantsMyRequest.ClickOnAddNewRequest();
                    tenantsMyRequest.AddNewRequest();
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Testing My Requests-->Add New Request using automation is successful");
                }
                catch
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Testing My Requests-->Add New Request using automation needs code check");
                    throw;

                }
            }
            [Test]
            public void TC_TenantDB_MyReq_EditRequest()
            {
                try
                {
                    test = extent.StartTest("Check *My Request-->Edit  Request* link on Tenant Dashboard");
                    TenantDashboard tenantDashboard = new TenantDashboard();
                    tenantDashboard.DashboardMethod();
                    tenantDashboard.MyRequestMethod();
                    TenantsMyRequest tenantsMyRequest = new TenantsMyRequest();
                    tenantsMyRequest.EditRequestMethod();
                    Driver.wait(5);
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Testing My Requests-->Edit Request using automation is successful");
                }
                catch
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Testing My Requests-->Edit Request using automation code needs to be checked again");
                    throw;
                }
            }
            [Test]
            public void TC_TenantDB_MyApplications()
            {
                try
                {
                    test = extent.StartTest("Check *My Request-->Edit  Request* link on Tenant Dashboard");
                    Driver.wait(10);
                    TenantDashboard tenantDashboard = new TenantDashboard();
                    tenantDashboard.DashboardMethod();
                    tenantDashboard.MyApplication();
                    Driver.wait(5);
                    EditApplicationTenant editApplicationTenant = new EditApplicationTenant();
                    //editApplicationTenant.TenantMethod();
                    editApplicationTenant.SearchMethod();
                    Driver.wait(5);
                    editApplicationTenant.EditApplication();
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Testing My Application using automation is successful");
                }
                catch
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Please check the code there is some issue executing the My Application TestCase");
                    throw;
                }
            }
            [Test]
            public void TC_TenantDB_MyRentals()
            {
                try
                {
                    test = extent.StartTest("Check *My Request-->My Rentals* link on Tenant Dashboard");
                    Driver.wait(10);
                    TenantDashboard tenantDashboard = new TenantDashboard();
                    tenantDashboard.DashboardMethod();
                    tenantDashboard.MyRental();
                    tenantDashboard.MyRentalSendReq();
                    TenantsMyRequest tenantsMyRequest = new TenantsMyRequest();
                    tenantsMyRequest.AddNewRequest();
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "User able to fill Rental Request Form by navigating from My Rentals on DB");

                }
                catch
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "There is issue in filling up Rental Request Form by navigating from My Rentals on DB");
                    throw;
                }
            }

            [Test]
            public void PO_AddFinanceDetail()
            {
                try
                {
                    test = extent.StartTest("Check the link in Property Owner Dashboard");
                    PODashboard ObjPODashboard = new PODashboard();
                    ObjPODashboard.AddFinDetailMethod();
                    PropertyFinDetails ObjPropertyFinDetail = new PropertyFinDetails();
                    ObjPropertyFinDetail.HomeValueMethod();
                    ObjPropertyFinDetail.RentalPaymentMethod();
                    ObjPropertyFinDetail.RepaymentsMethod();
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Verification of Add Financial Details linq done");
                }
                catch
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Verification of Add Financial Details linq done");
                }
            }
            [Test]
            public void PO_AddNewTenant()
            {
                try
                {
                    test = extent.StartTest("Check if user is able to Add Tenant using Add new tenant link in Property Owner Dashboard");
                    PODashboard ObjPODashboard = new PODashboard();
                    ObjPODashboard.DashboardMethod();
                    ObjPODashboard.AddTenantMethod();
                    AddTenant ObjAddTenant = new AddTenant();
                    ObjAddTenant.AddTenantMethod();
                    AddTenantLiabilityDetails ObjAddTenantLiability = new AddTenantLiabilityDetails();
                    ObjAddTenantLiability.AddLiabiltyMethod();
                    ObjAddTenantLiability.CompleteTenantMethod();
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Verification of AddTenant link done");
                }
                catch
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "There is issue with the methods used in Verification of AddTenant link");
                }
            }
            [Test]
            public void PO_AddNewProperty()
            {
                try
                {
                    test = extent.StartTest("Check if user is able to create new property with Add New Property link in Property Owner Dashboard");
                    PODashboard ObjPODashboard = new PODashboard();
                    ObjPODashboard.DashboardMethod();
                    ObjPODashboard.AddNewPropertyMethod();
                    ANPPropertyDetails ObjANPropertyDetails = new ANPPropertyDetails();
                    ObjANPropertyDetails.PropDetailsMethod();
                    ANPFinancialDetails ObjANPFinancialDetails = new ANPFinancialDetails();
                    ObjANPFinancialDetails.FinDetailsMethod();
                    ANPTenantDetails ObjANPTenantDetails = new ANPTenantDetails();
                    ObjANPTenantDetails.TenantDetails4mExcel();
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Verification of Add New Property link done");
                }
                catch
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Verification of Add new Property link  could not be done");
                }
            }
            [Test]
            public void PO_AddNewListing()
            {
                try
                {
                    test = extent.StartTest("Check if User is able to Add a New Listing by clicking on *Add New Listing* on the Quick Buttons");
                    PODashboard ObjDashboard = new PODashboard();
                    ObjDashboard.DashboardMethod();
                    ObjDashboard.AddNewListingMethod();
                    ListNewProperty ObjListNewProp = new ListNewProperty();
                    ObjListNewProp.ListPropMethod();
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Selected Property listed as new Rental");
                }
                catch
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Selected Property could not be listed as new Rental. Please check the logs");
                }
            }
            [Test]
            public void PO_AddNewRequest()
            {
                try
                {
                    test = extent.StartTest("Check if Owner is able to Send New Request by click on Add New Request");
                    PODashboard oDashboard = new PODashboard();
                    oDashboard.DashboardMethod();
                    oDashboard.AddNewRequestmethod();
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Verification of Add new request on Quick Buttons done");
                }
                catch
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Methods to Verify Add new request on Quick Buttons are not successful");
                }
            }
        }
    }
}
