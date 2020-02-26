using lab_ta_homework_5.Search_engines;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab_ta_homework_5.Tests
{
    [TestClass]
    public class YahooTests
    {
        [TestInitialize]
        public void Initialize()
        {
            Driver.StartBrowser();
        }

        [TestMethod]
        public void YahooFoundNotOnFirstPage()
        {
            Yahoo yahoo = new Yahoo("Ooga anisotropic polycarbonate", "Shin-Etsu Polymer America");
            yahoo.GoToPage();
            yahoo.Search();
            Assert.IsTrue(yahoo.VerifyResults(true) > 0);
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
