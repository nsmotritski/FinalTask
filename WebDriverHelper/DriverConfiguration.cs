using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverHelper
{
    public class DriverConfiguration
    {
        public IWebDriver driver;

        public IWebDriver GetWebDriver()
        {
            if (driver == null)
            {
                var pathToDriver = Path.Combine(AssemblyDirectory, "drivers");
                driver = new ChromeDriver(pathToDriver);
                SetDefaultSettings(driver);
            }
            return driver;
        }

        private void SetDefaultSettings(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(20);
        }

        public static string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}
