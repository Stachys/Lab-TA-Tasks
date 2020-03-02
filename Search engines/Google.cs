
namespace lab_ta_homework_5.Search_engines
{
    class Google : SearchEngine
    {
        public Google() : base()
        {
            Url = Constants.googleUrl;
            SearchFieldXPath = Constants.googleSearchFieldXPath;
            ResultsXPath = Constants.googleResultsXPath;
            NextXPath = Constants.googleNextXPath;
            PageNumXPath = Constants.googlePageNumXPath;
        }
    }
}
