using System;

namespace lab_ta_homework_5.Search_engines
{
    class Yahoo : Base
    {
        public Yahoo(string toSearch, string toFind) : base(toSearch, toFind)
        {
            Url = Constants.yahooUrl;
            SearchFieldXPath = Constants.yahooSearchFieldXPath;
            ResultsXPath = Constants.yahooResultsXPath;
            PathToSave += String.Format(Constants.yahooPathToSave + DateTime.Now.ToString(Constants.dateTime), ToFind, ToSearch);
            NextXPath = Constants.yahooNextXPath;
            PageNumXPath = Constants.yahooPageNumXPath;
        }
    }
}
