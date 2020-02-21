using System;
using System.Drawing;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace lab_ta_homework_5
{
    public static class Driver
    {
        public static IWebDriver driver;

        public static void StartBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        static public Bitmap BytesToBitmap(byte[] bytesArr)
        {
            var memoryStream = new MemoryStream(bytesArr);
            return new Bitmap(memoryStream);
        }

        public static void StopBrowser()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
