using lab_ta_homework_5.Search_engines;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab_ta_homework_5.BLL
{
    class SearchEngineBll
    {
        private SearchEngine searchEngine;

        public void OnTheMainGooglePage()
        {
            searchEngine = new Google();
            searchEngine.GoToPage();
        }

        public void OnTheMainBingPage()
        {
            searchEngine = new Bing();
            searchEngine.GoToPage();
        }

        public void OnTheMainYahooPage()
        {
            searchEngine = new Yahoo();
            searchEngine.GoToPage();
        }

        public void Search(string toSearch)
        {
            searchEngine.Search(toSearch);
        }

        public void VerifyResultOnFirstPage(string toFind)
        {
            Assert.IsTrue(searchEngine.VerifyResults(toFind, false) == 1);
        }

        public void VerifyResultNotOnFirstPage(string toFind)
        {
            Assert.IsTrue(searchEngine.VerifyResults(toFind, false) > 1);
        }

        public void NoResultScreenAllPages(string toFind)
        {
            Assert.IsTrue(searchEngine.VerifyResults(toFind, true) == 0);
        }
    }
}
