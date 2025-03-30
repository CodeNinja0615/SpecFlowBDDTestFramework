using SpecFlowBDDTest.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowBDDTest.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowBDDTest.StepDefinitions
{
    [Binding]
    public class EndToEndFlowSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;
        private LoginPage loginPage;
        private ProductsPage productPage;
        private CheckoutPage checkoutPage;
        private ConfirmationPage confirmationPage;
        private List<string> actualProducts = new List<string>();

        public EndToEndFlowSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = Hooks.Driver; // Assuming you have a Hooks class managing WebDriver
        }

        [Given(@"I log in with username ""(.*)"" and password ""(.*)""")]
        public void GivenILogInWithUsernameAndPassword(string username, string password)
        {
            loginPage = new LoginPage(driver);
            productPage = loginPage.ValidLogin(username, password);
            productPage.WaitForPageToDisplay();
        }

        [When(@"I add (.*) and (.*) to the cart")]
        public void WhenIAddProductsToTheCart(string product1, string product2)
        {
            IList<IWebElement> products = productPage.getCards();
            List<string> expectedProducts = new List<string> { product1, product2 };

            foreach (IWebElement product in products)
            {
                string productName = product.FindElement(productPage.getCardTitle()).Text;
                if (expectedProducts.Contains(productName))
                {
                    product.FindElement(productPage.getAddToCart()).Click();
                }
            }
        }

        [When(@"I proceed to checkout")]
        public void WhenIProceedToCheckout()
        {
            checkoutPage = productPage.checkout();
            IList<IWebElement> checkoutCards = checkoutPage.CheckoutCards();

            foreach (var card in checkoutCards)
            {
                actualProducts.Add(card.Text);
            }
        }

        [Then(@"I should see the selected products in the checkout page")]
        public void ThenIShouldSeeTheSelectedProductsInTheCheckoutPage()
        {
            Assert.That(actualProducts.Count, Is.EqualTo(2));
        }

        [Then(@"I should see a success message upon purchase")]
        public void ThenIShouldSeeASuccessMessageUponPurchase()
        {
            confirmationPage = checkoutPage.Checkout();
            confirmationPage.SelectCountry();
            string confirmText = confirmationPage.ConfirmPurchase();
            Assert.That(confirmText.Contains("Success"));
        }
    }
}
