using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Runtime.InteropServices;

namespace FYPAutomation.Driver
{
    public class SeleniumDriver
    {
        private WebDriver driver;
        private int RetryCount = 3;
        public SeleniumDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage"); 
            options.AddArgument("--remote-debugging-port=9222"); 
            this.driver = new ChromeDriver(options);
        }

        public void GoToWebsite(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void RetryableElementClick(By Element, string elementname)
        {
            int count = 0;
            while (RetryCount > count)
            {
                try
                {
                    driver.FindElement(Element).Click();
                    break;
                }
                catch (Exception e)
                {
                    count++;
                    Thread.Sleep(1000);
                    if(count == 3)
                    {
                        Console.WriteLine("Test Failed Cannot find element: " + elementname);
                    }
                }
            }
        }

        public void RetryableElementInsert(By Element, string text, string elementName)
        {
            int count = 0;
            while (RetryCount > count)
            {
                try
                {
                    driver.FindElement(Element).SendKeys(text);
                    break;
                }
                catch (Exception e)
                {
                    count++;
                    Thread.Sleep(1000);
                    if (count == 3)
                    {
                        Console.WriteLine("Test Failed Cannot find element: " + elementName);
                    }
                }
            }
        }

        public void Quit()
        {
            driver.Quit();
        }
    }
}
