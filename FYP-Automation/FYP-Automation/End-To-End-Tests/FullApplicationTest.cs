using System;
using FYPAutomation.Driver;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace FYPAutomation.End_To_End_Tests
{
    class FullApplicationTest
    {
        private SeleniumDriver driver;
        By EmailInput = By.Name("email");
        By PasswordInput = By.Name("password");
        By LoginButton = By.XPath("//button[text()='Login']");

        [OneTimeSetUp]
        public void Setup()
        {
            Console.WriteLine("Starting Web Driver");
            driver = new SeleniumDriver();
            Console.WriteLine("Web Driver Started");
        }

        [Order(1)]
        [Test]
        public void CheckIfUrlWorks()
        { 
            Console.WriteLine("Url Test Started");
            driver.GoToWebsite("http://34.147.239.239/login");
            Console.WriteLine("Url Test Ended");
        }

        [Order(2)]
        [Test]
        public void LoginTest()
        {
            Console.WriteLine("Login Test Started");
            driver.RetryableElementInsert(EmailInput, "pawelkaminski1776@gmail.com","Email Textbox");
            driver.RetryableElementInsert(PasswordInput, "password", "Password Textbox");
            driver.RetryableElementClick(LoginButton, "Login Button");
            Thread.Sleep(10000);
            Console.WriteLine("Login Test Ended");
        }


        [OneTimeTearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
