using System;

namespace lab_ta_homework_5.Search_engines
{
    class Bing : SearchEngine
    {
        public Bing() : base()
        {
            Url = Constants.bingUrl;
            SearchFieldXPath = Constants.bingSearchFieldXPath;
            ResultsXPath = Constants.bingResultsXPath;
            NextXPath = Constants.bingNextXPath;
            PageNumXPath = Constants.bingPageNumXPath;
        }
    }
}
