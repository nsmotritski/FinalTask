using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allure.Commons;
using Allure.NUnit.Attributes;
using FinalTask.Locators;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using WebDriverHelper;

namespace FinalTask
{
    [AllureSuite("Suite without base class")]
    [AllureEpic("Epic story")]
    [TestFixture]
    [Parallelizable]
    public class GmailTests : AllureReport
    {
        private IWebDriver _driver;

        [SetUp]
        public void StartBrowser()
        {
            //Running with Selenium Grid
            //var localNodeURL = "http://localhost:5566/wd/hub";
            //_driver = new RemoteWebDriver(new Uri(localNodeURL), options);
            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //_driver = new RemoteWebDriver(new Uri(localNodeURL), options);

            //Running locally
            _driver = Driver.InitializeWebDriver();
        }

        [AllureLink("1")]
        [AllureOwner("Nikolai Smotritski")]
        [AllureSeverity(Allure.Commons.Model.SeverityLevel.Minor)]
        [AllureTest("Test login to tut.by using PageObject")]
        [TestCase("lvivautoteam@gmail.com", "zaq1ZAQ!", "Test User")]
        [Parallelizable]
        public void GmailLoginTest(string username, string password, string expectedUser)
        {
            //Open gmail home page
            _driver.Url = "https://gmail.com";

            //perform login
            GmailHomePage homePage = new GmailHomePage(_driver);
            homePage.Login(username, password);

            var inboxPage = new InboxPage(_driver);
            var ariaLabelText = inboxPage.AccountButton.GetAttribute("aria-label");

            //when Inbox page is opened, validate that the correct user is signed in
            Assert.IsTrue(ariaLabelText.Contains(expectedUser), $"Aria label {ariaLabelText} does not contain expected text {expectedUser}");
            Assert.IsTrue(ariaLabelText.Contains(username), $"Aria label {ariaLabelText} does not contain expected text {username}");

            //take screenshot before the final check
            _driver.TakeScreenshot("GmailLoginTest.png");
        }

        [AllureLink("1")]
        [AllureOwner("Nikolai Smotritski")]
        [AllureSeverity(Allure.Commons.Model.SeverityLevel.Minor)]
        [AllureTest("Test login to tut.by using PageObject")]
        [TestCase("lvivautoteam2@gmail.com", "zaq1ZAQ!", "Test User")]
        [Parallelizable]
        public void GmailLogoutTest(string username, string password, string expectedUser)
        {
            //Open gmail home page
            _driver.Url = "https://gmail.com";

            //perform login
            GmailHomePage homePage = new GmailHomePage(_driver);
            homePage.Login(username, password);

            var inboxPage = new InboxPage(_driver);
            var ariaLabelText = inboxPage.AccountButton.GetAttribute("aria-label");

            //when Inbox page is opened, validate that the correct user is signed in
            Assert.IsTrue(ariaLabelText.Contains(expectedUser), $"Aria label {ariaLabelText} does not contain expected text {expectedUser}");
            Assert.IsTrue(ariaLabelText.Contains(username), $"Aria label {ariaLabelText} does not contain expected text {username}");

            //take screenshot before the final check
            _driver.TakeScreenshot("GmailLoginTest.png");
        }

        [TearDown]
        public void CloseBrowser()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                _driver.TakeScreenshot(TestContext.CurrentContext.Test.Properties["AllureTest"].ToString());
            }

            _driver.Quit();
        }
    }
}
