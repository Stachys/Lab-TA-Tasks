using lab_ta_homework_5.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab_ta_homework_5.Tests
{
    [TestClass]
    public class ShoppingTests
    {
        [TestInitialize]
        public void Initialize()
        {
            Driver.StartBrowser();
        }

        [TestMethod]
        public void Olx()
        {
            OlxBll olxBll = new OlxBll();
            olxBll.OnTheMainPage();
            olxBll.SearchForLaptops();
            olxBll.SetFilter(Constants.minPrice);
            olxBll.VerifyResults(Constants.minPrice);
        }

        [TestMethod]
        public void Rozetka()
        {
            RozetkaBll rozetkaBll = new RozetkaBll();
            rozetkaBll.OnTheMainPage();
            rozetkaBll.SearchForLaptops();
            rozetkaBll.SetFilter(Constants.minPrice);
            rozetkaBll.VerifyResults(Constants.minPrice);
        }

        [TestMethod]
        public void AliExpress()
        {
            AliExpressBll aliExpressBll = new AliExpressBll();
            aliExpressBll.OnTheMainPage();
            aliExpressBll.SignIn(Constants.login, Constants.password);
            aliExpressBll.SearchForLaptops();
            aliExpressBll.SetFilter(Constants.minPrice);
            aliExpressBll.VerifyResults(Constants.minPrice);
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.StopBrowser();
        }
    }
}
