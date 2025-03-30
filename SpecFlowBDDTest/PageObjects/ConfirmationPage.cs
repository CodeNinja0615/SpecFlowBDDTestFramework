﻿using SpecFlowBDDTest.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBDDTest.PageObjects
{
    public class ConfirmationPage: CommonFunctions
    {
        private IWebDriver driver;
        public ConfirmationPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement country;
        [FindsBy(How = How.LinkText, Using = "India")]
        private IWebElement countryLink;
        [FindsBy(How = How.CssSelector, Using = "label[for*='checkbox2']")]
        private IWebElement checkBox;
        [FindsBy(How = How.CssSelector, Using = "[value='Purchase']")]
        private IWebElement purchaseButton;
        [FindsBy(How = How.CssSelector, Using = ".alert-success")]
        private IWebElement successMessage;
        private By India = By.LinkText("India");
        public void SelectCountry()
        {
            country.SendKeys("ind");
            WaitForElementToAppear(India);
            countryLink.Click();
        }

        public String ConfirmPurchase()
        {
            checkBox.Click();
            purchaseButton.Click();
            return successMessage.Text;
        }
    }
}
