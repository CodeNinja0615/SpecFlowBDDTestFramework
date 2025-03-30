using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowBDDTest.Support
{
    [Binding]
    public class Hooks
    {
        private static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        private string browserName;

        public static IWebDriver Driver => driver.Value;

        [BeforeScenario] //[BeforeScenario("@Smoke")]
        public void StartBrowser()
        {
            // Fetch browser name from test context or config
            browserName = TestContext.Parameters["browserName"];
            if (browserName == null)
            {
                browserName = ConfigurationManager.AppSettings["browser"];
            }

            InitBrowser(browserName);
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Value.Manage().Window.Maximize();
            driver.Value.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        private void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    driver.Value = new FirefoxDriver();
                    break;

                case "Chrome":
                    driver.Value = new ChromeDriver();
                    break;

                case "Edge":
                    driver.Value = new EdgeDriver();
                    break;

                default:
                    throw new ArgumentException($"Browser '{browserName}' is not supported.");
            }
        }

        [AfterScenario]
        public void TearDown()
        {
            if (driver.Value != null)
            {
                driver.Value.Quit();
                driver.Value.Dispose();
            }
        }
    }
}

// 1️⃣ BeforeTestRun / AfterTestRun → Runs once before/after the entire test run.
// 2️⃣ BeforeFeature / AfterFeature → Runs once before/after each feature file.
// 3️⃣ BeforeScenario / AfterScenario → Runs before/after each scenario in a feature file.
// 4️⃣ BeforeStep / AfterStep → Runs before/after each step (Given/When/Then).
// 5️⃣ BeforeScenarioBlock / AfterScenarioBlock → Runs before/after a block of steps (e.g., all Given or When steps).
// 6️⃣ Tagged Hooks (@smoke, @regression, etc.) → Runs only for scenarios with specific tags.