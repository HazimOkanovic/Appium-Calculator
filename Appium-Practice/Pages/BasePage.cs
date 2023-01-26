using System;
using System.Collections.Generic;
using System.Linq;
using Appium_Practice.Components;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;

namespace Appium_Practice.Pages;

public class BasePage : BaseComponent
{
    protected BasePage(AndroidDriver<AndroidElement> driver) : base(driver)
        {
        }

        #region Methods allowing to dynamically pause the execution until needed element meets a condition

        protected void WaitElementExists(By by, int timeoutInSeconds = Constants.TimeOutInSec)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementExists(by));
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false, "Element does not exist with xpath: " + by);
            }
        }

        protected void WaitElementVisible(By by, int timeoutInSeconds = Constants.TimeOutInSec)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false, "Element is not visible with xpath: " + by);
            }
        }

        protected void WaitElementClickable(By by, int timeoutInSeconds = Constants.TimeOutInSec)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementToBeClickable(by));
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false, "Element is not clickable with xpath: " + by);
            }
        }

        public void WaitLoaderNotVisible(int timeoutInSeconds = Constants.TimeOutInSec)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("mat-spinner")));
        }

        #endregion

        #region Methods for getting an element after element meets a condition

        protected IWebElement WaitElementExistsAndGet(By by, int timeoutInSeconds = Constants.TimeOutInSec)
        {
            WaitElementExists(by, timeoutInSeconds);
            return driver.FindElement(by);
        }

        protected IWebElement WaitElementVisibleAndGet(By by, int timeoutInSeconds = Constants.TimeOutInSec)
        {
            WaitElementVisible(by, timeoutInSeconds);
            return driver.FindElement(by);
        }

        protected IWebElement WaitElementClickableAndGet(By by,
            int timeoutInSeconds = Constants.TimeOutInSec)
        {
            WaitElementClickable(by, timeoutInSeconds);
            return driver.FindElement(by);
        }

        #endregion

        #region Methods to assert if element meets a condition

        protected void CheckElementExists(By by, int timeoutInSeconds = Constants.TimeOutInSec)
        {
            WaitElementExists(by, timeoutInSeconds);
        }

        protected void CheckListOfElementsExist(List<By> elements,
            int timeoutInSeconds = Constants.TimeOutInSec)
        {
            //Assert.Multiple(() =>
            // {
            foreach (By el in elements)
            {
                CheckElementExists(el, timeoutInSeconds);
            }
            //});
        }

        #endregion

        #region Methods to check if element meets a condition

        protected bool ElementExists(By by, int timeoutInSeconds = Constants.TimeOutInSec)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementExists(by));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        #endregion

        #region Helper methods to execute some actions

        public string PrepareEmail(string email)
        {
            Random random = new Random();
            int randomNum = random.Next(10000000, 99999999);
            string _email = email.Split('@')[0] + "+" + randomNum.ToString() + "@" + email.Split('@')[1];
            return _email;
        }

        public void ClickOnText(string text)
        {
            WaitElementClickableAndGet(By.XPath("//*[contains(text(), '" + text + "')]"), 10).Click();
        }

        public void ClearInput(By element)
        {
            WaitElementExistsAndGet(element, 60).Clear();
        }

        public void ClickJS(By path)
        {
            var element = driver.FindElement(path);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }

        public void SendKeys(By element, string text)
        {
            WaitElementClickableAndGet(element, 60).SendKeys(text);
        }

        public static string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }

        #endregion
}