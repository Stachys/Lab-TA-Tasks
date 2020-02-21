using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace lab_ta_homework_5
{
    [TestClass]
    public class Rozetka
    {
        [TestMethod]
        public void RozetkaTask()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Url = "https://rozetka.com.ua/";
            driver.FindElement(By.XPath("//button[@aria-label='Каталог товаров']")).Click();
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath("//ul[@class='menu-categories']/li/a[contains(text(),'Ноутбуки')]")));
            action.Perform();
            driver.FindElement(By.XPath("//ul[@class='menu-categories']//a[text()='Ноутбуки']")).Click();

            int minPrice = 65000;
            IWebElement minField = driver.FindElement(By.XPath("//fieldset//input[@formcontrolname='min']"));
            minField.Clear();
            minField.SendKeys(minPrice.ToString());
            driver.FindElement(By.XPath("//fieldset//button[@type='submit']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath("//li[@class='catalog-selection__item']/a"), minPrice.ToString()));

            IList <IWebElement> results = driver.FindElements(By.XPath("//ul[@class='catalog-grid']//span[@class='goods-tile__price-value']"));
            foreach (IWebElement result in results)
            {
                string resultPrice = result.Text;
                resultPrice = string.Join("", resultPrice.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
                Console.WriteLine(resultPrice);
                Assert.IsTrue(Int32.Parse(resultPrice) > minPrice);
            }

            driver.Quit();
            driver.Dispose();
        }
    }
}
