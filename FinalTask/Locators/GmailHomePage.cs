using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FinalTask.Locators
{
    public class GmailHomePage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = "input[type=\'email\']")]
        public IWebElement UsernameInput;

        [FindsBy(How = How.CssSelector, Using = "#identifierNext")]
        public IWebElement NextButton;

        public GmailHomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public GmailHomePage setUsername(string username)
        {
            UsernameInput.SendKeys(username);
            return this;
        }

        public GmailHomePage clickNextButton()
        {
            NextButton.Click();
            return this;
        }
    }
}
