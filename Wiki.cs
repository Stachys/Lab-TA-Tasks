using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

namespace lab_ta_homework_5
{
    [TestClass]
    public class Wiki
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TestMethod]
        public void Task1()
        {
            string url = "https://en.wikipedia.org";
            driver.Navigate().GoToUrl(url);
            Console.WriteLine($"Page title: {driver.Title}, page title length: {driver.Title.Length}");
            Console.WriteLine($"Page source length: {driver.PageSource.Length}");
            Assert.IsTrue(driver.Url.Contains(url));
        }

        [TestMethod]
        public void Task2()
        {
            string url = "https://en.wikipedia.org";
            driver.Url = url;
            driver.FindElement(By.LinkText("Help")).Click();
            driver.Navigate().Back();
            driver.Navigate().Forward();
            driver.Navigate().GoToUrl(url);
            driver.Navigate().Refresh();
        }

        [TestMethod]
        public void ScreenAllImages()
        {
            driver.Url = "https://en.wikipedia.org";
            var bytesArr = driver.TakeScreenshot(new VerticalCombineDecorator(new ScreenshotMaker()));
            Bitmap pageScreenshot = Driver.BytesToBitmap(bytesArr);
            string path = $"C:\\Users\\Stanislav_Hrechykhin\\source\\repos\\lab_ta_homework_5\\Wiki images\\" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm");
            Directory.CreateDirectory(path);

            IList<IWebElement> images = driver.FindElements(By.XPath("//*[@id='mp-upper']//img | //*[@id='mp-lower']//img"));
            foreach (IWebElement image in images)
            {
                string imageName = image.GetAttribute("alt");
                Rectangle rect = new Rectangle(image.Location, image.Size);
                pageScreenshot.Clone(rect, pageScreenshot.PixelFormat).Save($"{path}\\{imageName}.png");
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}

