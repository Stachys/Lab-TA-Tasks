using lab_ta_homework_5.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab_ta_homework_5.Tests
{
    [TestClass]
    public class BingTests
    {
        [TestInitialize]
        public void Initialize()
        {
            Driver.StartBrowser();
        }

        [TestMethod]
        public void BingFoundNotOnFirstPage()
        {
            SearchEngineBll bing = new SearchEngineBll();
            bing.OnTheMainBingPage();
            bing.Search("Glass boga anisotropic polycarbonate");
            bing.VerifyResultNotOnFirstPage("Allen's Seminar");
        }

        //TODO
        //Found on the first page
        //Not found screen all pages

        [TestCleanup]
        public void Cleanup()
        {
            Driver.StopBrowser();
        }
    }
}
