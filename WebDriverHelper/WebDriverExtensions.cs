using OpenQA.Selenium;
using System;
using System.IO;

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
    }
}
