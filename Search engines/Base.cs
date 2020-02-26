using System;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

namespace lab_ta_homework_5.Search_engines
{
    abstract class Base
    {
        protected IWebDriver driver;

        protected string Url { get; set; }

        protected string SearchFieldXPath { get; set; }

        protected string ToSearch { get; set; }

        protected string ToFind { get; set; }

        protected string PathToSave { get; set; } = $"C:\\Users\\{Environment.UserName}\\Desktop\\Images\\";

        protected string ResultsXPath { get; set; }

        protected string NextXPath { get; set; }

        protected string PageNumXPath { get; set; }

        protected Base(string toSearch, string toFind)
        {
            driver = Driver.driver;
            ToSearch = toSearch;
            ToFind = toFind;
        }

        public void Search() 
        {
            IWebElement searchField = driver.FindElement(By.XPath(SearchFieldXPath));
            searchField.SendKeys(ToSearch);
            searchField.SendKeys(Keys.Enter);
        }

        public int VerifyResults(bool screenshotAllPages)
        {
            Directory.CreateDirectory(PathToSave);
            IList<IWebElement> next;
            do
            {
                string pageNum = driver.FindElement(By.XPath(PageNumXPath)).Text;
                IList<IWebElement> results = driver.FindElements(By.XPath(ResultsXPath));
                foreach (IWebElement result in results)
                {
                    if (result.Text.Contains(ToFind))
                    {
                        Console.WriteLine($"Found {ToFind} by {ToSearch} on {pageNum} page");
                        var bytesArr = driver.TakeScreenshot(new VerticalCombineDecorator(new ScreenshotMaker().RemoveScrollBarsWhileShooting()));
                        Driver.BytesToBitmap(bytesArr).Save($"{PathToSave}\\Page {pageNum} - found.png");
                        return Int32.Parse(pageNum);
                    }
                }

                if (screenshotAllPages)
                {
                    var bytesArr = driver.TakeScreenshot(new VerticalCombineDecorator(new ScreenshotMaker().RemoveScrollBarsWhileShooting()));
                    Driver.BytesToBitmap(bytesArr).Save($"{PathToSave}\\Page {pageNum} - not found.png");
                }

                next = driver.FindElements(By.XPath(NextXPath));
                if (next.Count != 0)
                {
                    next[0].Click();
                }

            } while (next.Count != 0);

            return 0;
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
