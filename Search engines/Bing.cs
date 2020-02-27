using System;

namespace lab_ta_homework_5.Search_engines
{
    class Bing : Base
    {
        public Bing(string toSearch, string toFind) : base(toSearch, toFind)
        {
            Url = Constants.bingUrl;
            SearchFieldXPath = Constants.bingSearchFieldXPath;
            ResultsXPath = Constants.bingResultsXPath;
            PathToSave += String.Format(Constants.bingPathToSave + DateTime.Now.ToString(Constants.dateTime), ToFind, ToSearch);
            NextXPath = Constants.bingNextXPath;
            PageNumXPath = Constants.bingPageNumXPath;
        }
    }
}
