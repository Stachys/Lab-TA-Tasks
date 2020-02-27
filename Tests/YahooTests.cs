using lab_ta_homework_5.BLL;
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
            SearchEngineBll yahoo = new SearchEngineBll();
            yahoo.OnTheMainYahooPage();
            yahoo.Search("Ooga anisotropic polycarbonate");
            yahoo.VerifyResultNotOnFirstPage("Shin-Etsu Polymer America");
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
