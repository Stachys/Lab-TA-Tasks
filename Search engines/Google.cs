using System;

namespace lab_ta_homework_5.Search_engines
{
    class Google : Base
    {
        public Google(string toSearch, string toFind) : base(toSearch, toFind)
        {
            Url = Constants.googleUrl;
            SearchFieldXPath = Constants.googleSearchFieldXPath;
            ResultsXPath = Constants.googleResultsXPath;
            PathToSave += String.Format(Constants.googlePathToSave + DateTime.Now.ToString(Constants.dateTime), ToFind, ToSearch);
            NextXPath = Constants.googleNextXPath;
            PageNumXPath = Constants.googlePageNumXPath;
        }
    }
}
