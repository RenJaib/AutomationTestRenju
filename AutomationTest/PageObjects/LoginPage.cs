using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest.PageObjects
{
    public class LoginPage: Base.BasePage
    {
        [FindsBy(How = How.LinkText, Using = "Register")]
        public IWebElement _registerButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".alert.alert-success")]
        public IWebElement _registrationSuccessMessage { get; set; }

        [FindsBy(How = How.Name, Using = "username")]
        public IWebElement _userName { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement _password { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn.btn-primary")]
        public IWebElement _loginButton { get; set; }

        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public RegistrationPage ClickOnRegister() //function to navigate to registration page
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_registerButton)).Click();
            return new RegistrationPage(_driver);
        }

        public bool RegistrationSuccessCheck() // functin to check for registration success
        {
            _wait.Until(driver => _registrationSuccessMessage.Displayed);
            return _registrationSuccessMessage.Text == "Registration successful";           
        }

        public DashboardPage ClickOnLogin() // function to Login after registration 
        {
            _userName.SendKeys(RegistrationPage.RegisteredUserName);
            _password.SendKeys(RegistrationPage.RegisteredUserPassword);
            _loginButton.Click();
            return new DashboardPage(_driver);
        }
    }
}
