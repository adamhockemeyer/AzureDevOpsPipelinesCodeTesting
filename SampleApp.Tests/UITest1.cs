using NUnit.Framework;
using Microsoft.Extensions.Logging.Abstractions;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace SampleApp.Tests
{
    [TestFixture, Category("UI")]
    public class UITests
    {

        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [SetUp]
        public void Setup()
        {
            appURL = "http://devopspipelinescodetesting.azurewebsites.net/";

            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver(options);
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }

        [Test]
        public void Verify_Navbar_Text()
        {
            driver.Navigate().GoToUrl(appURL);
            var element = driver.FindElement(By.CssSelector(".container > .navbar-brand"));

            // Assert
            Assert.AreEqual("SampleApp", element.Text);
        }

        [Test]
        public void Verify_Nav_To_Privacy_Policy_Check_Title()
        {
            driver.Navigate().GoToUrl(appURL);
            driver.FindElement(By.CssSelector("li:nth-of-type(2) > .nav-link.text-dark")).Click();
            var element = driver.FindElement(By.CssSelector("main[role='main'] > h1"));

            // Assert
            Assert.AreEqual("Privacy Policy", element.Text);
        }

    }
}