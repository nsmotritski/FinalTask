using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebDriverHelper
{
    public class Waiters
    {

        private Driver _driver = Driver.GetInstance();

        //public WebDriverWait GetWaiter() => GetWaiter(10);

        //public WebDriverWait GetWaiter(int seconds) => new WebDriverWait(_driver, seconds);

        //public bool WaitForElementDisplayed(By by)
        //{
        //    var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15))
        //    {
        //        PollingInterval = TimeSpan.FromMilliseconds(600)
        //    };
        //    var element = wait.Until(condition =>
        //    {
        //        try
        //        {
        //            var elementToBeDisplayed = _driver.FindElement(by);
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
