using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FinalTask.Locators
{
    public class InboxPage
    {
        private IWebDriver _driver;

        public InboxPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public IWebElement AccountButton
        {
            get
            {
                var elements = _driver.FindElements(By.XPath("//a[contains(@aria-label,\'Аккаунт Google\')]"));
                return _driver.FindElement(elements.Count == 0 ? By.XPath("//a[contains(@aria-label,\'Google Account\')]") : 
                                                                By.XPath("//a[contains(@aria-label,\'Аккаунт Google\')]"));
            }
        }
    }
}
