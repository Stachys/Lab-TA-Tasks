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
            Olx olx = new Olx(65000);
            olx.GoToPage();
            olx.Search();
            olx.SetFilter();
            IEnumerable<int> prices = olx.GetPrices();
            foreach (int price in prices)
            {
                Assert.IsTrue(price >= 65000);
            }
        }

        [TestMethod]
        public void Rozetka()
        {
            Rozetka rozetka = new Rozetka(65000);
            rozetka.GoToPage();
            rozetka.Search();
            rozetka.SetFilter();
            IEnumerable<int> prices = rozetka.GetPrices();
            foreach (int price in prices)
            {
                Assert.IsTrue(price >= 65000);
            }
        }

        [TestMethod]
        public void AliExpress()
        {
            AliExpress aliExpress = new AliExpress(65000);
            aliExpress.GoToPage();
            aliExpress.SignIn();
            aliExpress.Search();
            aliExpress.SetFilter();
            IEnumerable<int> prices = aliExpress.GetPrices();
            foreach (int price in prices)
            {
                Console.WriteLine(price.ToString());
                Assert.IsTrue(price >= 65000);
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.StopBrowser();
        }
    }
}
