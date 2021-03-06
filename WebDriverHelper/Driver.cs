﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebDriverHelper
{
    public sealed class Driver
    {
        private static Driver _instance = null;

        static DriverConfiguration _driverConfiguration = new DriverConfiguration();
        public static IWebDriver driver = InitializeWebDriver();

        private Driver() { }

        public static Driver GetInstance()
        {
            return _instance ?? (_instance = new Driver());
        }

        public static IWebDriver InitializeWebDriver()
        {
            return driver ?? (driver = _driverConfiguration.GetWebDriver());
        }

        //public bool WaitForElementDisplayed(By by)
        //{
        //    var wait = new Waiters.GetWaiter();
        //    var element = wait.Until(condition =>
        //    {
        //        try
        //        {
        //            var elementToBeDisplayed = _instance.FindElement(by);
        //            return elementToBeDisplayed.Displayed;
        //        }
        //        catch (StaleElementReferenceException)
        //        {
        //            return false;
        //        }
        //        catch (NoSuchElementException)
        //        {
        //            return false;
        //        }
        //    });
        //    return false;
        //}
    }
}
