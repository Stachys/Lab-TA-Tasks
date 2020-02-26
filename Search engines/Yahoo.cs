using System;

namespace lab_ta_homework_5.Search_engines
{
    class Yahoo : Base
    {
        public Yahoo(string toSearch, string toFind) : base(toSearch, toFind)
        {
            Url = "https://www.yahoo.com/";
            SearchFieldXPath = "//input[@id='header-search-input']";
            ResultsXPath = "//div[@id='web']//li/div/div";
            PathToSave += $"Yahoo images\\{ToFind} by {ToSearch} " + DateTime.Now.ToString("dd-MM-yyyy HH-mm");
            NextXPath = "//a[@class='next']";
            PageNumXPath = "//div[@class='compPagination']/strong";
        }
    }
}
