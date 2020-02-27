using lab_ta_homework_5.BLL;
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
            SearchEngineBll google = new SearchEngineBll();
            google.OnTheMainGooglePage();
            google.Search("Ooga anisotropic polycarbonate");
            google.VerifyResultOnFirstPage("Strain Hardening of Polycarbonate");
        }

        [TestMethod]
        public void GoogleFoundNotOnFirstPage()
        {
            SearchEngineBll google = new SearchEngineBll();
            google.OnTheMainGooglePage();
            google.Search("Ooga anisotropic polycarbonate");
            google.VerifyResultNotOnFirstPage("European Patent");
        }

        [TestMethod]
        public void GoogleNotFoundScreenAll()
        {
            SearchEngineBll google = new SearchEngineBll();
            google.OnTheMainGooglePage();
            google.Search("Ooga anisotropic polycarbonate");
            google.NoResultScreenAllPages("ASFhgghgdsfgkdjhg");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.StopBrowser();
        }
    }
}
