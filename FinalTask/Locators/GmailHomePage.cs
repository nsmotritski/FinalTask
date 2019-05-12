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

        [FindsBy(How = How.Id, Using = "identifierId")]
        public IWebElement UsernameInput;

        [FindsBy(How = How.CssSelector, Using = "#identifierNext")]
        public IWebElement NextButton;

        [FindsBy(How = How.CssSelector, Using = "input[name='password']")]
        public IWebElement PasswordInput;

        [FindsBy(How = How.XPath, Using = "//span[contains(@text,'Готово')]")]
        public IWebElement ReadyButton;

        public GmailHomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public GmailHomePage SetUsername(string text)
        {
            UsernameInput.SendKeys(text);
            return this;
        }

        public GmailHomePage ClickNextButton()
        {
            NextButton.Click();
            return this;
        }
    }
}
