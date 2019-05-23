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
    public class GmailHomePage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "identifierId")]
        public IWebElement UsernameInput;

        [FindsBy(How = How.CssSelector, Using = "#identifierNext")]
        public IWebElement UsernameNextButton;

        public IWebElement PasswordNextButton => _driver.FindElement(By.CssSelector("#passwordNext"));

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

        public GmailHomePage SetPassword(string text)
        {
            PasswordInput.SendKeys(text);
            return this;
        }

        public GmailHomePage ClickUsernameNextButton()
        {
            UsernameNextButton.Click();
            return this;
        }

        public GmailHomePage ClickPasswordNextButton()
        {
            _driver.FindElement(By.CssSelector("#passwordNext"), 10).Click(); 
            return this;
        }

        public void Login(string username, string password)
        {
            SetUsername(username);
            ClickUsernameNextButton();
            SetPassword(password);
            ClickPasswordNextButton();
        }
    }
}
