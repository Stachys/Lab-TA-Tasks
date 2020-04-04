using lab_ta_homework_5.Shopping_websites;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace lab_ta_homework_5.BLL
{
    [Binding, Scope(Tag = "aliexpress")]
    class AliExpressSteps
    {
        private AliExpress aliExpress;

        [Given(@"I am on the main page")]
        public void OnTheMainPage()
        {
            aliExpress = new AliExpress();
            aliExpress.GoToPage();
        }

        [When(@"I sign in")]
        public void SignIn()
        {
            aliExpress.CloseAd();
            aliExpress.MoveToMyProfile();
            aliExpress.SingInClick();
            aliExpress.FillSignInForm();
        }

        [When(@"I search for laptops")]
        public void SearchForLaptops()
        {
            aliExpress.CloseAd();
            aliExpress.CategoriesClick();
            aliExpress.MoveToComputers();
            aliExpress.LabtopsClick();
        }

        [When(@"I set minimum price to (.*)")]
        public void SetFilter(int minPrice)
        {
            aliExpress.CloseAd();
            aliExpress.SetMinPrice(minPrice);
            aliExpress.SubmitFilter();
        }

        [Then(@"The results prices should be greater than or equal to (.*)")]
        public void VerifyResults(int minPrice)
        {
            IEnumerable<int> prices = aliExpress.GetPrices();
            foreach (int price in prices)
            {
                Assert.IsTrue(price >= minPrice);
            }
        }
    }
}
