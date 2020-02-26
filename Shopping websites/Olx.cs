using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace lab_ta_homework_5.Shopping_websites
{
    class Olx : Base
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='maincategories']//span[text()='Электроника']")]
        private IWebElement electronics;

        [FindsBy(How = How.XPath, Using = "//div[@class='maincategories']//span[text()='Ноутбуки и аксессуары']")]
        private IWebElement laptopsAndAccessories;

        [FindsBy(How = How.XPath, Using = "//li[@id='param_subcat']/div/a")]
        private IWebElement typeOfGoodsDropdown;

        [FindsBy(How = How.XPath, Using = "//li[@id='param_subcat']//a[@data-code='noutbuki']")]
        private IWebElement laptopsInDropdown;

        [FindsBy(How = How.XPath, Using = "//li[@data-key='price']//div[contains(@class,'filter-item-from')]/a/span")]
        private IWebElement minField;

        [FindsBy(How = How.XPath, Using = "//li[@data-key='price']//input[contains(@class, 'from')]")]
        private IWebElement filterInput;

        private By listContainer = By.XPath("//div[@id='listContainer']");

        public Olx(int minPrice) : base(minPrice)
        {
            Url = "https://www.olx.ua/";
            PricesXPath = "//p[@class='price']/strong";
        }

        public override void Search()
        {
            electronics.Click();
            laptopsAndAccessories.Click();
            typeOfGoodsDropdown.Click();
            laptopsInDropdown.Click();
        }

        public override void SetFilter()
        {
            WaitListLoad(5);
            minField.Click();
            filterInput.SendKeys(MinPrice.ToString());
        }

        public override IEnumerable<int> GetPrices()
        {
            WaitListLoad(5);
            return base.GetPrices();
        }

        private void WaitListLoad(int sec)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sec));
            wait.Until(d => d.FindElement(listContainer).GetAttribute("class") == "loaderActive");
            wait.Until(d => d.FindElement(listContainer).GetAttribute("class") == "");
        }
    }
}
