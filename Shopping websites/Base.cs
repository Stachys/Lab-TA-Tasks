using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace lab_ta_homework_5.Shopping_websites
{
    abstract class Base
    {
        protected IWebDriver driver;
        protected string Url { get; set; }

        protected int MinPrice { get; set; }

        protected string PricesXPath { get; set; }

        protected Base(int minPrice)
        {
            driver = Driver.driver;
            MinPrice = minPrice;
            PageFactory.InitElements(driver, this);
        }

        public abstract void Search();

        public abstract void SetFilter();

        public virtual IEnumerable<int> GetPrices()
        {
            IEnumerable<int> results = driver.FindElements(By.XPath(PricesXPath)).Select(p => Int32.Parse(Regex.Replace(p.Text, "[^0-9]", "")));
            foreach (int result in results)
            {
                Console.WriteLine(result.ToString());
            }
            return results;
        }

        public void GoToPage()
        {
            if (Url.Length == 0)
            {
                throw new InvalidOperationException("Page has no predefined url");
            }

            driver.Navigate().GoToUrl(Url);
        }
    }
}
