using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

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
    }
}
