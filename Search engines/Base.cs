using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace lab_ta_homework_5.Search_engines
{
    abstract class Base
    {
        protected IWebDriver driver;

        public string Url { get; protected set; }

        protected IWebElement SearchField { get; set; }

        protected string ToSearch { get; set; }

        protected string ToFind { get; set; }

        protected string PathToSave { get; set; } = $"C:\\Users\\Stanislav_Hrechykhin\\source\\repos\\lab_ta_homework_5\\";

        protected string ResultsXPath { get; set; }

        protected IList<IWebElement> Results { get; set; }


        protected Base(string toSearch, string toFind)
        {
            driver = Driver.driver;
            ToSearch = toSearch;
            ToFind = toFind;
        }

        public void Search() 
        {
            SearchField.SendKeys(ToSearch);
            SearchField.SendKeys(Keys.Enter);
        }

        public void GetResults() 
        {
            Results = driver.FindElements(By.XPath(ResultsXPath));
        }

        public abstract int VerifyResults(bool screenshotAllPages);
        
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
