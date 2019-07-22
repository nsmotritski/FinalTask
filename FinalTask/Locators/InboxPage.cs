using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using WebDriverHelper;

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

        public IWebElement SignOutButton
        {
            get
            {
                var elements = _driver.FindElements(By.XPath("//a[contains(text(),\'Выйти\')]"));
                return _driver.FindElement(elements.Count == 0 ? By.XPath("//a[contains(text(),\'Sign out\')]") :
                                                                By.XPath("//a[contains(text(),\'Выйти\')]"));
            }
        }

        public IWebElement WriteEmailButton => _driver.FindElement(By.XPath("//div[contains(text(),\'Написать\')]"));

        public IWebElement WriteEmailToEdit => _driver.FindElement(By.XPath("//textarea[@name=\'to\']"));

        public IWebElement WriteEmailSubjectEdit => _driver.FindElement(By.XPath("//input[@name=\'subjectbox\']"));

        public IWebElement WriteEmailSendButton => _driver.FindElement(By.XPath("//div[contains(@data-tooltip,\'Отправить\')]"));

        public void Logout()
        {
            AccountButton.Click();
            SignOutButton.Click();
            if (_driver.IsAlertPresent())
            {
                _driver.SwitchTo().Alert().Accept();
            }
        }
    }
}
