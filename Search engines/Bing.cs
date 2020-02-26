using System;

namespace lab_ta_homework_5.Search_engines
{
    class Bing : Base
    {
        public Bing(string toSearch, string toFind) : base(toSearch, toFind)
        {
            Url = "https://www.bing.com/";
            SearchFieldXPath = "//input[@id='sb_form_q']";
            ResultsXPath = "//li[@class='b_algo']/*";
            PathToSave += $"Bing images\\{ToFind} by {ToSearch} " + DateTime.Now.ToString("dd-MM-yyyy HH-mm");
            NextXPath = "//a[@title='Next page']";
            PageNumXPath = "//li[@class='b_pag']/nav[@role='navigation']//a[contains(@class, 'sb_pagS_bp')]";
        }
    }
}
