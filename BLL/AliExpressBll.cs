using lab_ta_homework_5.Shopping_websites;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace lab_ta_homework_5.BLL
{
    class AliExpressBll
    {
        private AliExpress aliExpress;

        public void OnTheMainPage()
        {
            aliExpress = new AliExpress();
            aliExpress.GoToPage();
        }

        public void SignIn(string login, string password)
        {
            aliExpress.CloseAd();
            aliExpress.MoveToMyProfile();
            aliExpress.SingInClick();
            aliExpress.FillSignInForm(login, password);
        }

        public void SearchForLaptops()
        {
            aliExpress.MoveToComputers();
            aliExpress.LabtopsClick();
        }

        public void SetFilter(int minPrice)
        {
            aliExpress.SetMinPrice(minPrice);
            aliExpress.SubmitFilter();
        }

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
