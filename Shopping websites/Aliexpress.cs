using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace lab_ta_homework_5.Shopping_websites
{
    class AliExpress : Base
    {
        private const string login = "emailfortests88@gmail.com";
        private const string password = "glGfggD0S";
        
        [FindsBy(How = How.XPath, Using = "//div[@class='ui-window-bd']//a[@class='close-layer']")]
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

        public AliExpress(int minPrice) : base(minPrice)
        {
            Url = "https://aliexpress.ru/";
            PricesXPath = "//div[contains(@class,'product-list')]//span[@class='price-current']";
        }

        public void CloseAd()
        {
            closeAd.Click();
        }

        public void SignIn()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(myProfile);
            action.Perform();
            singInButton.Click();
            driver.SwitchTo().Frame(signInFrame);
            loginField.SendKeys(login);
            passwordField.SendKeys(password);
            passwordField.SendKeys(Keys.Enter);
            driver.SwitchTo().DefaultContent();
        }

        public override void Search()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(computers);
            action.Perform();
            laptops.Click();
        }

        public override void SetFilter()
        {
            minField.SendKeys(MinPrice.ToString());
            submitFilter.Click();
        }

        public override IEnumerable<int> GetPrices()
        {
            // TODO

            return base.GetPrices();
        }
    }
}
