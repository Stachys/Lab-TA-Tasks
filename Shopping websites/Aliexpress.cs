using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace lab_ta_homework_5.Shopping_websites
{
    class AliExpress : Base
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'close')]")]
        private IWebElement closeAd;

        [FindsBy(How = How.XPath, Using = "//span[@class='user-account-port']")]
        private IWebElement myProfile;

        [FindsBy(How = How.XPath, Using = "//a[@class='sign-btn']")]
        private IWebElement singInButton;

        [FindsBy(How = How.XPath, Using = "//iframe[@id='alibaba-login-box']")]
        private IWebElement signInFrame;

        [FindsBy(How = How.XPath, Using = "//input[@id='fm-login-id']")]
        private IWebElement loginField;

        [FindsBy(How = How.XPath, Using = "//input[@id='fm-login-password']")]
        private IWebElement passwordField;

        [FindsBy(How = How.XPath, Using = "//div[@data-role='category-content']//span[text()='Категории']")]
        private IWebElement categories;

        [FindsBy(How = How.XPath, Using = "//dl[contains(@class,'cl-item-computer')]/dt/span")]
        private IWebElement computers;

        [FindsBy(How = How.XPath, Using = "//dl[contains(@class,'cl-item-computer')]//div[@class='sub-cate-content']//a[text()='Ноутбуки']")]
        private IWebElement laptops;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class,'min-price')]/input")]
        private IWebElement minField;

        [FindsBy(How = How.XPath, Using = "//a[@class='ui-button narrow-go']")]
        private IWebElement submitFilter;

        public AliExpress() : base()
        {
            Url = Constants.aliExpressUrl;
            PricesXPath = Constants.aliExpressPricesXPath;
        }

        public void CloseAd()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2.5);
            try
            {
                closeAd.Click();
            }
            catch (NoSuchElementException)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.implicitWaitSec);
            }
        }

        public void MoveToMyProfile()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(myProfile);
            action.Perform();
        }

        public void SingInClick()
        {
            singInButton.Click();
            if (singInButton.Displayed)
            {
                SingInClick();
            }
        }

        public void FillSignInForm()
        {
            driver.SwitchTo().Frame(signInFrame);
            loginField.SendKeys(Credentials.AliLogin);
            passwordField.SendKeys(Credentials.AliPassword);
            passwordField.SendKeys(Keys.Enter);
            driver.SwitchTo().DefaultContent();
        }

        public void CategoriesClick()
        {
            categories.Click();
        }

        public void MoveToComputers()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(computers);
            action.Perform();
        }

        public void LabtopsClick()
        {
            laptops.Click();
        }

        public void SetMinPrice(int minPrice)
        {
            minField.SendKeys(minPrice.ToString());
        }

        public void SubmitFilter()
        {
            submitFilter.Click();
        }

        public override IEnumerable<int> GetPrices()
        {
            throw new NotImplementedException();
        }
    }
}
