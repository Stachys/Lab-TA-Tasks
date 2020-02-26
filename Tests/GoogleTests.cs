using lab_ta_homework_5.Search_engines;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab_ta_homework_5.Tests
{
    [TestClass]
    public class GoogleTests
    {
        [TestInitialize]
        public void Initialize()
        {
            Driver.StartBrowser();
        }

        [TestMethod]
        public void GoogleFoundOnFirstPage()
        {
            Google google = new Google("Ooga anisotropic polycarbonate", "Strain Hardening of Polycarbonate");
            google.GoToPage();
            google.Search();
            Assert.IsTrue(google.VerifyResults(false) == 1);
        }

        [TestMethod]
        public void GoogleFoundNotOnFirstPage()
        {
            Google google = new Google("Ooga anisotropic polycarbonate", "European Patent");
            google.GoToPage();
            google.Search();
            Assert.IsTrue(google.VerifyResults(false) > 1);
        }

        [TestMethod]
        public void GoogleNotFoundScreenAll()
        {
            Google google = new Google("Ooga anisotropic polycarbonate", "ASFhgghgdsfgkdjhg");
            google.GoToPage();
            google.Search();
            Assert.IsTrue(google.VerifyResults(true) == 0);
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.StopBrowser();
        }
    }
}
