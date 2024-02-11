using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
