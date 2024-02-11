using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Automation_Framework_AI.Helpers
{
    public class Helpers
    {
        IWebDriver driver = new ChromeDriver();

        public void ClickWebElementByCoordinates(int xCoordinate, int yCoordinate)
        {
            // Create ActionChains object
            Actions action = new Actions(driver);

            // Move the mouse to the element's coordinates and click
            action.MoveToElement(driver.FindElement(By.TagName("body"))) // Use a base element like body
                  .MoveByOffset(xCoordinate, yCoordinate)
                  .Click()
                  .Perform();
        }
        public void SendEmail()
        {
            string to = "bt@outlook.com"; // Recipient email address
            string from = "fromAddress@outlook.com"; // Sender email address

            MailMessage message = new MailMessage(from, to);
            message.Subject = "Using the new SMTP client."; // Email subject
            message.Body = @"Code Ran Successfully"; // Email body

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = true;

            try
            {
                client.Send(message); // Send the email
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught in SendEmail(): {ex.ToString()}");
            }
        }
        public IWebDriver DriverStart(string driverspecific, string webAppUrl)
        {
            switch (driverspecific.ToLower())
            {

                case "firefox": driver = new FirefoxDriver(); break;
                case "chrome": driver = new ChromeDriver(); break;
                case "ie": driver = new InternetExplorerDriver(); break;
                case "egde": driver = new EdgeDriver(); break;

                default: driver = new FirefoxDriver(); break;
            }
            //  driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(webAppUrl);
            return driver;
        }
        public void MouseOver(IWebDriver MWebdriver, IWebElement element)
        {
            Actions builder = new Actions(MWebdriver);
            builder.MoveToElement(element).Build().Perform();
            Thread.Sleep(1500);

        }

        /// <summary>
        /// this method does a check if an element is present on screen or not 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        

        public void ScrollToBottom(IWebDriver driver)
        {
            long scrollHeight = 0;

            do
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                var newScrollHeight = (long)js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight); return document.body.scrollHeight;");

                if (newScrollHeight == scrollHeight)
                {
                    break;
                }
                else
                {
                    scrollHeight = newScrollHeight;
                    Thread.Sleep(400);
                }
            } while (true);
        }

        /// <summary>
        /// The Method Check any dropdown if it has values inside it or not 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public Boolean CheckDropdownHasValue(IWebElement element)
        {
            if (element.Text.Contains("Select an option...") || element.Text.Contains(""))
            {
                // value is present in drop down
                return false;
            }
            else
            {
                // value is not present
                return true;
            }


        }
        /// <summary>
        /// This method check to see if an element has a value or not 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        /// Quintin Moodley
        public Boolean CheckElementHasValue(IWebElement element)
        {

            var text = element.GetAttribute("value");

            if (text != "")
            {
                // value is present in drop down
                return false;
            }
            else
            {
                // value is not present
                return true;
            }
        }



        /// <summary>
        /// This Method get the row of any line item you what by the name you enter
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        /// Quintin Moodley
        public void ClickTableLink(IWebElement element, string value)
        {
            var table = element;
            foreach (var tr in table.FindElements(By.TagName("tr")))
            {
                var tds = tr.FindElements(By.TagName("td"));
                for (var i = 0; i < tds.Count; i++)
                {
                    if (tds[i].Text.Trim().Contains(value))
                    {
                        tds[4].Click();
                        break;
                    }

                }
            }
        }

        /// <summary>
        /// This Method get the row of any line item you what by the name you enter
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        /// Quintin Moodley
        public bool CheckMicrosoftCloudAgreementTableLink(IWebElement element, string value)
        {
            var table = element;
            foreach (var tr in table.FindElements(By.TagName("tr")))
            {
                var tds = tr.FindElements(By.TagName("td"));
                for (var i = 0; i < tds.Count; i++)
                {
                    if (tds[i].Text.Trim().Contains(value))
                    {
                        return true;
                    }

                }
            }
            return false;
        }


        public bool IsAlertPresent(IWebDriver driver)
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Dismiss();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }

        public int Randomnumber()
        {
            Random rnd = new Random();
            int RandomNo = rnd.Next(100, 999);

            return RandomNo;
        }
    }
}
