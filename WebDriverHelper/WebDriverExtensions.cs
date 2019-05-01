using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebDriverHelper
{
    public static class WebDriverExtensions
    {
        public static void TakeScreenshot(this IWebDriver driver, string testTitle)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string Runname = testTitle + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
            string screenshotfilename = Path.Combine(WebDriverHelper.AssemblyDirectory, Runname + ".jpg");
            ss.SaveAsFile(screenshotfilename, ScreenshotImageFormat.Png);
        }
    }
}
