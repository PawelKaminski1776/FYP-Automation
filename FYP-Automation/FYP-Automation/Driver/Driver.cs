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
    public class Driver
    {
        private WebDriver driver;
        private int RetryCount = 3;
        public Driver(WebDriver Driver)
        {
            this.driver = Driver;
        }

        public void GoToWebsite(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void RetryableElementClick(By Element)
        {
            int count = 0;
            while (RetryCount < count)
            {
                try
                {
                    driver.FindElement(Element).Click();
                }
                catch (Exception e)
                {
                    count++;
                    Thread.Sleep(1000);
                }
            }
        }

        public void RetryableElementInsert(By Element, string text)
        {
            int count = 0;
            while (RetryCount < count)
            {
                try
                {
                    driver.FindElement(Element).SendKeys(text);
                }
                catch (Exception e)
                {
                    count++;
                    Thread.Sleep(1000);
                }
            }
        }

        public void Quit()
        {
            driver.Quit();
        }
    }
}
