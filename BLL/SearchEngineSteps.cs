using lab_ta_homework_5.Search_engines;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace lab_ta_homework_5.BLL
{
    [Binding, Scope(Tag = "search")]
    class SearchEngineSteps
    {
        private SearchEngine searchEngine;

        [Given(@"I am on the main google page")]
        public void OnTheMainGooglePage()
        {
            searchEngine = new Search_engines.Google();
            searchEngine.GoToPage();
        }

        [Given(@"I am on the main bing page")]
        public void OnTheMainBingPage()
        {
            searchEngine = new Bing();
            searchEngine.GoToPage();
        }

        [Given(@"I am on the main yahoo page")]
        public void OnTheMainYahooPage()
        {
            searchEngine = new Yahoo();
            searchEngine.GoToPage();
        }

        [When(@"I search for '(.*)'")]
        public void Search(string toSearch)
        {
            searchEngine.Search(toSearch);
        }

        [Then(@"'(.*)' should be found on the first page")]
        public void VerifyResultOnFirstPage(string toFind)
        {
            Assert.IsTrue(searchEngine.VerifyResults(toFind, false) == 1);
        }

        [Then(@"'(.*)' should be found not on the first page")]
        public void VerifyResultNotOnFirstPage(string toFind)
        {
            Assert.IsTrue(searchEngine.VerifyResults(toFind, false) > 1);
        }

        [Then(@"'(.*)' should not be found")]
        public void NoResultScreenAllPages(string toFind)
        {
            Assert.IsTrue(searchEngine.VerifyResults(toFind, true) == 0);
        }
    }
}
