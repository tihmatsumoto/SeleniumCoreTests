using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace SeleniumCoreTests
{
    [TestClass]
    public class MainPage
    {
        [TestMethod]
        public void ShouldLogin()
        {
            var driverDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var driver = new ChromeDriver(driverDirectory);
            driver.Navigate().GoToUrl("https://www.saucedemo.com");

        }
    }
}
