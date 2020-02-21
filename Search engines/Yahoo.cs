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
    class Yahoo : Base
    {
        public Yahoo(string toSearch, string toFind) : base(toSearch, toFind)
        {
            Url = "";
            SearchField = driver.FindElement(By.XPath(""));
            ResultsXPath = "";
            PathToSave += $"Yahoo images\\{toFind}_by_{toSearch}_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm");
        }

        public override int VerifyResults(bool screenshotAllPages)
        {
            throw new NotImplementedException();
        }
    }
}
