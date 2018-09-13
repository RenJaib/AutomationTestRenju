using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest.TestScenarios
{
    class RegistrationTests
    {
        IWebDriver _driver = new ChromeDriver();

        [SetUp]
        public void PageSetup()
        {
            _driver.Url = ConfigurationManager.AppSettings["URL"];
        }

        [Test]
        public void UserRegistration()
        {
            // Register a user
            var loginPage = new PageObjects.LoginPage(_driver);
            var registrationPage = loginPage.ClickOnRegister();
            registrationPage.Register();
            Assert.IsTrue(loginPage.RegistrationSuccessCheck());
            Console.WriteLine("Registration Success");
            //Login after registration
            var dashboardPage = loginPage.ClickOnLogin();
            // Assertion check after login
            Assert.IsTrue(dashboardPage.DashboardFirstNameCheck());
            Console.WriteLine("FirstName Matched");
            Assert.IsTrue(dashboardPage.DashboardFullNameCheck());
            Console.WriteLine("Found user under registered users list");
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }
    
    }
}
