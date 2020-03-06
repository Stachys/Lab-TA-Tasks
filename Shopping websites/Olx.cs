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

        public Olx() : base()
        {
            Url = Constants.olxUrl;
            PricesXPath = Constants.olxPricesXPath;
        }

        public void ElectronicsClick()
        {
            electronics.Click();
        }

        public void LaptopsAndAccessories()
        {
            laptopsAndAccessories.Click();
        }

        public void TypeOfGoodsDropdown()
        {
            typeOfGoodsDropdown.Click();
        }

        public void LaptopsInDropdown()
        {
            try
            {
                laptopsInDropdown.Click();
            }
            catch (NoSuchElementException)
            {
                TypeOfGoodsDropdown();
                LaptopsInDropdown();
            }
        }

        public void SetMinPrice(int minPrice)
        {
            WaitListLoad(Constants.explicitWaitSec);
            try
            {
                minField.Click();
                filterInput.SendKeys(minPrice.ToString());
            }
            catch (ElementNotInteractableException)
            {
                SetMinPrice(minPrice);
            }
        }

        public override IEnumerable<int> GetPrices()
        {
            WaitListLoad(Constants.explicitWaitSec);
            return base.GetPrices();
        }

        private void WaitListLoad(int sec)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sec));
            if (driver.FindElement(listContainer).GetAttribute("class") == "loaderActive")
            {
                wait.Until(d => d.FindElement(listContainer).GetAttribute("class") == "");
            }
            else
            {
                System.Threading.Thread.Sleep(3000); // I tried... ;(
                wait.Until(d => d.FindElement(listContainer).GetAttribute("class") == "");
            }
        }
    }
}
