using System;

namespace lab_ta_homework_5
{
    public static class Constants
    {
        public const int implicitWaitSec = 10;
        public const int explicitWaitSec = 10;
        public const string dateTime = "dd-MM-yyyy HH-mm";
        public const string noUrlMessage = "Page has no predefined url";
        public const int minPrice = 65000;

        //Search engine base
        public const string pathToImages = "C:\\Users\\{0}\\Desktop\\Images\\{1}\\{2} {3} by {4}\\";
        public const string foundToConsole = "Found {0} by {1} on {2} page";
        public const string imageNameFound = "{0}\\Page {1} - found.png";
        public const string imageNameNotFound = "{0}\\Page {1} - not found.png";

        //Bing
        public const string bingUrl = "https://www.bing.com/";
        public const string bingSearchFieldXPath = "//input[@id='sb_form_q']";
        public const string bingResultsXPath = "//li[@class='b_algo']/*";
        public const string bingNextXPath = "//a[@title='Next page']";
        public const string bingPageNumXPath = "//li[@class='b_pag']/nav[@role='navigation']//a[contains(@class, 'sb_pagS_bp')]";

        //Google
        public const string googleUrl = "https://www.google.com/";
        public const string googleSearchFieldXPath = "//input[@name='q']";
        public const string googleResultsXPath = "//div[@class='g']//div[@class='r']//h3 | //div[@class='g']//span[@class='st']";
        public const string googleNextXPath = "//*[@id='pnnext']";
        public const string googlePageNumXPath = "//td[@class='cur']";

        //Yahoo
        public const string yahooUrl = "https://www.yahoo.com/";
        public const string yahooSearchFieldXPath = "//input[@id='header-search-input']";
        public const string yahooResultsXPath = "//div[@id='web']//li/div[contains(@class,'algo')]/div";
        public const string yahooNextXPath = "//a[@class='next']";
        public const string yahooPageNumXPath = "//div[@class='compPagination']/strong";

        //AliExpress
        public const string aliExpressUrl = "https://aliexpress.ru/";
        public const string login = "emailfortests88@gmail.com";
        public const string password = "glGfggD0S";
        public const string aliExpressPricesXPath = "//div[contains(@class,'product-list')]//span[@class='price-current']";

        //Olx
        public const string olxUrl = "https://www.olx.ua/";
        public const string olxPricesXPath = "//p[@class='price']/strong";

        //Rozetka
        public const string rozetkaUrl = "https://rozetka.com.ua/";
        public const string rozetkaPricesXPath = "//ul[@class='catalog-grid']//span[@class='goods-tile__price-value']";
    }
}
