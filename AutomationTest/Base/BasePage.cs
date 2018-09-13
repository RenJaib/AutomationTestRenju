using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationTest.Base
{
    public abstract class BasePage
    {
        public WebDriverWait _wait;
        public IWebDriver _driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
    }
}