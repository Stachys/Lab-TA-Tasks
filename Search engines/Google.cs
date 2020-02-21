using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

namespace lab_ta_homework_5.Search_engines
{
    class Google : Base
    {
        public Google(string toSearch, string toFind) : base(toSearch, toFind)
        {
            Url = "https://www.google.com/";
            SearchField = driver.FindElement(By.XPath("//input[@name='q']"));
            ResultsXPath = "//div[@class='g']//div[@class='r']//h3 | //div[@class='g']//span[@class='st']";
            PathToSave += $"Google images\\{toFind}_by_{toSearch}_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm");
        }

        public override int VerifyResults(bool screenshotAllPages)
        {
            Directory.CreateDirectory(PathToSave);
            IList<IWebElement> next;
            do
            {
                string pageNum = driver.FindElement(By.XPath("//td[@class='cur']")).Text;
                ((IJavaScriptExecutor)driver).ExecuteScript($"arguments[0].setAttribute('hidden','');", driver.FindElement(By.XPath("//*[@id='searchform']")));

                GetResults();
                foreach (IWebElement result in Results)
                {
                    if (result.Text.Contains(ToFind))
                    {
                        ((IJavaScriptExecutor)driver).ExecuteScript($"arguments[0].setAttribute('style','color: red;');", result);
                        Console.WriteLine($"Found {ToFind} by {ToSearch} on {pageNum} page");
                        var bytesArr = driver.TakeScreenshot(new VerticalCombineDecorator(new ScreenshotMaker().RemoveScrollBarsWhileShooting()));
                        Driver.BytesToBitmap(bytesArr).Save($"{PathToSave}\\Found_on_{pageNum}.png");
                        return Int32.Parse(pageNum);
                    }
                }

                if (screenshotAllPages)
                {
                    var bytesArr = driver.TakeScreenshot(new VerticalCombineDecorator(new ScreenshotMaker().RemoveScrollBarsWhileShooting()));
                    Driver.BytesToBitmap(bytesArr).Save($"{PathToSave}\\Not_found_on_{pageNum}.png");
                }

                next = driver.FindElements(By.CssSelector("#pnnext"));
                if (next.Count != 0)
                {
                    next[0].Click();
                }

            } while (next.Count != 0);

            return 0;
        }
    }
}
