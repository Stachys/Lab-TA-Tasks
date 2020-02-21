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
    class Bing : Base
    {
        public Bing(string toSearch, string toFind) : base(toSearch, toFind)
        {
            Url = "https://www.bing.com/";
            SearchField = driver.FindElement(By.XPath("//input[@id='sb_form_q']"));
            ResultsXPath = "//li[@class='b_algo']/div";
            PathToSave += $"Bing images\\{toFind}_by_{toSearch}_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm");
        }

        public override int VerifyResults(bool screenshotAllPages)
        {
            GetResults();
            return 0;
        }
    }
}
