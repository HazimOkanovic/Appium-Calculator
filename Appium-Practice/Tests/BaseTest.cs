using System;
using Appium_Calculator.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;

namespace Appium_Practice.Tests
{
    public class BaseTest
    {
        private readonly AndroidDriver<AndroidElement> driver;

        protected BaseTest()
        {
            driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"),
                Configuration.ReadConfiguration());
        }

        [OneTimeTearDown]
        protected void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}