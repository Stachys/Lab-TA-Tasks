using System;
using System.Collections.Generic;
using lab_ta_homework_5.Shopping_websites;
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
            Olx olx = new Olx(Constants.minPrice);
            olx.GoToPage();
            olx.ElectronicsClick();
            olx.LaptopsAndAccessories();
            olx.TypeOfGoodsDropdown();
            olx.LaptopsInDropdown();
            olx.SetMinPrice();
            IEnumerable<int> prices = olx.GetPrices();
            foreach (int price in prices)
            {
                Assert.IsTrue(price >= Constants.minPrice);
            }
        }

        [TestMethod]
        public void Rozetka()
        {
            Rozetka rozetka = new Rozetka(Constants.minPrice);
            rozetka.GoToPage();
            rozetka.CatalogeClick();
            rozetka.MoveToComputersMenu();
            rozetka.LaptopsClick();
            rozetka.SetMinPrice();
            rozetka.SubmitFilter();
            IEnumerable<int> prices = rozetka.GetPrices();
            foreach (int price in prices)
            {
                Assert.IsTrue(price >= Constants.minPrice);
            }
        }

        [TestMethod]
        public void AliExpress()
        {
            AliExpress aliExpress = new AliExpress(Constants.minPrice);
            aliExpress.GoToPage();
            aliExpress.CloseAd();
            aliExpress.MoveToMyProfile();
            aliExpress.SingInClick();
            aliExpress.FillSignInForm(Constants.login, Constants.password);
            aliExpress.MoveToComputers();
            aliExpress.LabtopsClick();
            aliExpress.SetMinPrice();
            aliExpress.SubmitFilter();
            IEnumerable<int> prices = aliExpress.GetPrices();
            foreach (int price in prices)
            {
                Console.WriteLine(price.ToString());
                Assert.IsTrue(price >= Constants.minPrice);
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.StopBrowser();
        }
    }
}
