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
        public void StartUp(string TestName,string AppName)
        {
            // Initialize WebDriver and configure Applitools
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Eyes = new Eyes
            {
                ApiKey = Environment.GetEnvironmentVariable(Resources.AppitoolsApiKey,EnvironmentVariableTarget.User)
            };
            Eyes.Open(Driver,AppName,TestName);

            Driver.Navigate().GoToUrl(Resources.URL);

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
