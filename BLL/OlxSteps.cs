using lab_ta_homework_5.Shopping_websites;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace lab_ta_homework_5.BLL
{
    [Binding, Scope(Tag = "olx")]
    class OlxSteps
    {
        private Olx olx;

        [Given(@"I am on the main page")]
        public void OnTheMainPage()
        {
            olx = new Olx();
            olx.GoToPage();
        }

        [When(@"I search for laptops")]
        public void SearchForLaptops()
        {
            olx.ElectronicsClick();
            olx.LaptopsAndAccessories();
            olx.TypeOfGoodsDropdown();
            olx.LaptopsInDropdown();
        }

        [When(@"I set minimum price to (.*)")]
        public void SetFilter(int minPrice)
        {
            olx.SetMinPrice(minPrice);
        }

        [Then(@"The results prices should be greater than or equal to (.*)")]
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
