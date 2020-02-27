using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [FindsBy(How = How.XPath, Using = "//dl[contains(@class,'cl-item-computer')]/dt/span")]
        private IWebElement computers;

        [FindsBy(How = How.XPath, Using = "//dl[contains(@class,'cl-item-computer')]//div[@class='sub-cate-content']//a[text()='Ноутбуки']")]
        private IWebElement laptops;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class,'min-price')]/input")]
        private IWebElement minField;

        [FindsBy(How = How.XPath, Using = "//a[@class='ui-button narrow-go']")]
        private IWebElement submitFilter;

        private By adContainer = By.XPath("//div[@class='newuser-container' and contains(@style,'background-image')]");

        public AliExpress(int minPrice) : base(minPrice)
        {
            Url = Constants.aliExpressUrl;
            PricesXPath = Constants.aliExpressPricesXPath;
        }

        public void CloseAd()
        {
            TimeSpan wait = driver.Manage().Timeouts().ImplicitWait;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            if (driver.FindElements(adContainer).Count != 0)
            {
                closeAd.Click();
            }
            driver.Manage().Timeouts().ImplicitWait = wait;
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

        public void FillSignInForm(string login, string password)
        {
            driver.SwitchTo().Frame(signInFrame);
            loginField.SendKeys(login);
            passwordField.SendKeys(password);
            passwordField.SendKeys(Keys.Enter);
            driver.SwitchTo().DefaultContent();
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

        public void SetMinPrice()
        {
            minField.SendKeys(MinPrice.ToString());
        }

        public void SubmitFilter()
        {
            submitFilter.Click();
        }

        public override IEnumerable<int> GetPrices()
        {
            //Add explicit wait

            return driver.FindElements(By.XPath(PricesXPath)).Select(p => Int32.Parse(p.Text.Substring(0, p.Text.IndexOf('-') - 4).Replace(" ", "")));
        }
    }
}
