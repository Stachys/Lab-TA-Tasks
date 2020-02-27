using lab_ta_homework_5.Shopping_websites;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace lab_ta_homework_5.BLL
{
    class OlxBll
    {
        private Olx olx;

        public void OnTheMainPage()
        {
            olx = new Olx();
            olx.GoToPage();
        }

        public void SearchForLaptops()
        {
            olx.ElectronicsClick();
            olx.LaptopsAndAccessories();
            olx.TypeOfGoodsDropdown();
            olx.LaptopsInDropdown();
        }


        public void SetFilter(int minPrice)
        {
            olx.SetMinPrice(minPrice);
        }

        public void VerifyResults(int minPrice)
        {
            IEnumerable<int> prices = olx.GetPrices();
            foreach (int price in prices)
            {
                Assert.IsTrue(price >= minPrice);
            }
        }
    }
}
