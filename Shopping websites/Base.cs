using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace lab_ta_homework_5.Shopping_websites
{
    abstract class Base
    {
        protected IWebDriver driver;
        public string Url { get; protected set; }

        protected Base()
        {
            driver = Driver.driver;
            PageFactory.InitElements(driver, this);
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
