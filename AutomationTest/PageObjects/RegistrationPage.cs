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
    public class RegistrationPage : Base.BasePage
    {
        public static string RegisteredUserName;
        public static string RegisteredFirstName;
        public static string RegisteredLastName;
        public static string RegisteredUserPassword;

        [FindsBy(How = How.Name, Using = "firstName")]
        public IWebElement _firstName{ get; set; }

        [FindsBy(How = How.Name, Using = "lastName")]
        public IWebElement _lastName { get; set; }

        [FindsBy(How = How.Name, Using = "username")]
        public IWebElement _userName { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement _password { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn.btn-primary")]
        public IWebElement _registerButton { get; set; }

        public RegistrationPage(IWebDriver driver) : base(driver)
        {

        }

        public LoginPage Register() // function to register a user
        {
            //set user details
            SetUserRegistrationDetails();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_firstName)).SendKeys(RegistrationPage.RegisteredFirstName);
            _lastName.SendKeys(RegistrationPage.RegisteredLastName);
            _userName.SendKeys(RegistrationPage.RegisteredUserName);
            _password.SendKeys(RegistrationPage.RegisteredUserPassword);
            _registerButton.Click();
            return new LoginPage(_driver);
        }

        private void SetUserRegistrationDetails() // function to set user details fro registeration
        {
            var ticks = DateTime.Now.Ticks;
            RegistrationPage.RegisteredFirstName = string.Format(@"FirstN{0}", ticks);
            RegistrationPage.RegisteredLastName = string.Format(@"LastN{0}", ticks);
            RegistrationPage.RegisteredUserName = string.Format(@"User{0}", ticks);
            RegistrationPage.RegisteredUserPassword = "password123";
        }
    }
}
