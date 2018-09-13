using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace AutomationTest.PageObjects
{
    public class DashboardPage : Base.BasePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id=\"app\"]/div/div/div/div/div/h1")]
        private IWebElement _dashboardFirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"app\"]/div/div/div/div/div/ul/li")]
        private IWebElement _dashboardFullName { get; set; }

        public DashboardPage(IWebDriver driver): base(driver)
        {
            
        }

        public bool DashboardFirstNameCheck() // function to check firstname after login
        {
            _wait.Until(driver => _dashboardFirstName.Displayed);
            return _dashboardFirstName.Text == string.Format("Hi {0}!", RegistrationPage.RegisteredFirstName);
        }
        public bool DashboardFullNameCheck() //function to check full name after login
        {
            _wait.Until(driver => _dashboardFullName.Displayed);
            return _dashboardFullName.Text == string.Format("{0} {1} - Delete", RegistrationPage.RegisteredFirstName, RegistrationPage.RegisteredLastName);
        }
    }
}