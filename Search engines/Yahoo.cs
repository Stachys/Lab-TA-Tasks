
namespace lab_ta_homework_5.Search_engines
{
    class Yahoo : SearchEngine
    {
        public Yahoo() : base()
        {
            Url = Constants.yahooUrl;
            SearchFieldXPath = Constants.yahooSearchFieldXPath;
            ResultsXPath = Constants.yahooResultsXPath;
            NextXPath = Constants.yahooNextXPath;
            PageNumXPath = Constants.yahooPageNumXPath;
        }
    }
}
