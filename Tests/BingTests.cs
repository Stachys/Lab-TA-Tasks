using lab_ta_homework_5.Search_engines;
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
            Bing bing = new Bing("Glass boga anisotropic polycarbonate", "Allen's Seminar");
            bing.GoToPage();
            bing.Search();
            Assert.IsTrue(bing.VerifyResults(true) > 0);
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
