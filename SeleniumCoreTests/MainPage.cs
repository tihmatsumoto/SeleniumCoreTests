using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumCoreTests
{
    [TestClass]
    public class MainPage
    {
        IWebDriver _driver;
        [TestMethod]
        public void ShouldLogin()
        {
            var driverDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver(driverDirectory);
            _driver.Navigate().GoToUrl("https://www.saucedemo.com");

            var loginBtnLocator = By.CssSelector(".btn_action");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(loginBtnLocator));

            var usernameField = _driver.FindElement(By.Id("user-name"));
            var passwordField = _driver.FindElement(By.Id("password"));
            var loginBtn = _driver.FindElement(By.CssSelector(".btn_action"));

            usernameField.SendKeys("standard_user");
            passwordField.SendKeys("secret_sauce");
            loginBtn.Click();

            Assert.IsTrue(_driver.Url.Contains("inventory.html"));
        }

        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}
