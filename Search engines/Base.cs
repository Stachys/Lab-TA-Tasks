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

        protected string PathToSave { get; set; } = Constants.pathToImages;

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
                        Console.WriteLine(String.Format(Constants.foundToConsole, ToFind, ToSearch, pageNum));
                        var bytesArr = driver.TakeScreenshot(new VerticalCombineDecorator(new ScreenshotMaker().RemoveScrollBarsWhileShooting()));
                        Driver.BytesToBitmap(bytesArr).Save(String.Format(Constants.imageNameFound, PathToSave, pageNum));
                        return Int32.Parse(pageNum);
                    }
                }

                if (screenshotAllPages)
                {
                    var bytesArr = driver.TakeScreenshot(new VerticalCombineDecorator(new ScreenshotMaker().RemoveScrollBarsWhileShooting()));
                    Driver.BytesToBitmap(bytesArr).Save(String.Format(Constants.imageNameNotFound, PathToSave, pageNum));
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
                throw new InvalidOperationException(Constants.noUrlMessage);
            }

            driver.Navigate().GoToUrl(Url);
        }
    }
}
