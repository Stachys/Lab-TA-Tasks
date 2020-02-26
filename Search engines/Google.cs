using System;

namespace lab_ta_homework_5.Search_engines
{
    class Google : Base
    {
        public Google(string toSearch, string toFind) : base(toSearch, toFind)
        {
            Url = "https://www.google.com/";
            SearchFieldXPath = "//input[@name='q']";
            ResultsXPath = "//div[@class='g']//div[@class='r']//h3 | //div[@class='g']//span[@class='st']";
            PathToSave += $"Google images\\{ToFind} by {ToSearch} " + DateTime.Now.ToString("dd-MM-yyyy HH-mm");
            NextXPath = "//*[@id='pnnext']";
            PageNumXPath = "//td[@class='cur']";
        }
    }
}
