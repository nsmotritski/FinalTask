using OpenQA.Selenium;
using System;
using System.IO;
using OpenQA.Selenium.Support.UI;

namespace WebDriverHelper
{
    public static class WebDriverExtensions
    {
        public static void TakeScreenshot(this IWebDriver driver, string testTitle)
        {
            var ss = ((ITakesScreenshot)driver).GetScreenshot();
            var runname = testTitle + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
            var screenshotfilename = Path.Combine(DriverConfiguration.AssemblyDirectory, runname + ".jpg");
            ss.SaveAsFile(screenshotfilename, ScreenshotImageFormat.Png);
        }

        //link: https://stackoverflow.com/questions/6992993/selenium-c-sharp-webdriver-wait-until-element-is-present
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
    }
}
