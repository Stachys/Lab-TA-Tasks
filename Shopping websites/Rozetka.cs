using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace lab_ta_homework_5.Shopping_websites
{
    class Rozetka : Base
    {
        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Каталог товаров']")]
        private IWebElement cataloge;

        [FindsBy(How = How.XPath, Using = "//ul[@class='menu-categories']/li/a[contains(text(),'Ноутбуки')]")]
        private IWebElement computersMenu;

        [FindsBy(How = How.XPath, Using = "//ul[@class='menu-categories']//a[text()='Ноутбуки']")]
        private IWebElement laptops;

        [FindsBy(How = How.XPath, Using = "//fieldset//input[@formcontrolname='min']")]
        private IWebElement minField;

        private By filterOption = By.XPath("//li[@class='catalog-selection__item']/a");

        public Rozetka(int minPrice) : base(minPrice)
        {
            Url = Constants.rozetkaUrl;
            PricesXPath = Constants.rozetkaPricesXPath;
        }

        public override void Search()
        {
            cataloge.Click();
            Actions action = new Actions(driver);
            action.MoveToElement(computersMenu);
            action.Perform();
            laptops.Click();
        }

        public override void SetFilter()
        {
            minField.Clear();
            minField.SendKeys(MinPrice.ToString());
            minField.SendKeys(Keys.Enter);
        }

        public override IEnumerable<int> GetPrices()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.explicitWaitSec));
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(filterOption, MinPrice.ToString()));

            return base.GetPrices();
        }
    }
}
