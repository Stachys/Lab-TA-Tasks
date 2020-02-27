using lab_ta_homework_5.Shopping_websites;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace lab_ta_homework_5.BLL
{
    class RozetkaBll
    {
        private Rozetka rozetka;

        public void OnTheMainPage()
        {
            rozetka = new Rozetka();
            rozetka.GoToPage();
        }

        public void SearchForLaptops()
        {
            rozetka.CatalogeClick();
            rozetka.MoveToComputersMenu();
            rozetka.LaptopsClick();
        }

        public void SetFilter(int minPrice)
        {
            rozetka.SetMinPrice(minPrice);
            rozetka.SubmitFilter();
        }

        public void VerifyResults(int minPrice)
        {
            IEnumerable<int> prices = rozetka.GetPrices();
            foreach (int price in prices)
            {
                Assert.IsTrue(price >= minPrice);
            }
        }
    }
}
