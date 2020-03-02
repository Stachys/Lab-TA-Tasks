using lab_ta_homework_5.Shopping_websites;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace lab_ta_homework_5.BLL
{
    [Binding, Scope(Tag = "rozetka")]
    class RozetkaSteps
    {
        private Rozetka rozetka;

        [Given(@"I am on the main page")]
        public void OnTheMainPage()
        {
            rozetka = new Rozetka();
            rozetka.GoToPage();
        }

        [When(@"I search for laptops")]
        public void SearchForLaptops()
        {
            rozetka.CatalogeClick();
            rozetka.MoveToComputersMenu();
            rozetka.LaptopsClick();
        }

        [When(@"set minimum price to (.*)")]
        public void SetFilter(int minPrice)
        {
            rozetka.SetMinPrice(minPrice);
            rozetka.SubmitFilter();
        }

        [Then(@"the results prices should be greater than or equal to (.*)")]
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
