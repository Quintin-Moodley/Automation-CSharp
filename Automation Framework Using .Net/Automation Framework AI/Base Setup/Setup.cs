using OpenQA.Selenium; // Replace with your chosen driver
using OpenQA.Selenium.Chrome; // Replace with your specific browser driver
using Applitools;
using Applitools.Selenium;
using NUnit.Framework;
using System;
using OpenQA.Selenium.DevTools.V119.Page;

namespace Automation_Framework_AI.Base_Setup
{
    public class Setup
    {
        public IWebDriver Driver { get; private set; }
        public Eyes Eyes { get; private set; }

        [SetUp]
        public void StartUp(string TestName)
        {
            // Initialize WebDriver and configure Applitools
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Eyes = new Eyes
            {
                ApiKey = Environment.GetEnvironmentVariable("APIKEY",EnvironmentVariableTarget.User)
            };
            Eyes.Open(Driver,"","");

            Driver.Navigate().GoToUrl("URL//www.com");

        }
        [TearDown]
        public void Cleanup()
        {
            Eyes.Close(); // Finalize test and upload results
            Driver.Quit();
            Eyes.AbortIfNotClosed();
        }
    }
}
