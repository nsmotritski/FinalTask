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
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            //var localNodeURL = "http://localhost:5566/wd/hub";
            //_driver = new RemoteWebDriver(new Uri(localNodeURL), options);
            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //_driver = new RemoteWebDriver(new Uri(localNodeURL), options);

            //Running locally
            _driver = WebDriverHelper.WebDriverHelper.DeployWebDriver();
        }

        [AllureLink("1")]
        [AllureOwner("Nikolai Smotritski")]
        [AllureSeverity(Allure.Commons.Model.SeverityLevel.Minor)]
        [AllureTest("Test login to tut.by using PageObject")]
        [TestCase("lvivautoteam@gmail.com", "zaq1ZAQ!", "Selenium Test")]
        [Parallelizable]
        public void TutByLoginTest(string username, string password, string expectedUser)
        {
            //Open tut.by hompage
            _driver.Url = "https://gmail.com";
            _driver.Manage().Window.Maximize();

            //perform login (with methods chaining)
            GmailHomePage homePage = new GmailHomePage(_driver);
            homePage.setUsername(username)
                    .clickNextButton();
            //var loggedUser = homePage.ClickEnterButton()
            //    .PerformLogin(username, password)
            //    .GetLoggedInUser();

            //take screenshot before the final check
            _driver.TakeScreenshot("TutByLoginTest.png");

            //validate logged in user
            //Assert.AreEqual(expectedUser, loggedUser, "User 'Selenium Test' is not logged in!");
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
