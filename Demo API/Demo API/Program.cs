using System;
using System.Net;
using System.Text.Json.Nodes;
using System.Transactions;

namespace Demo_API
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Currency> currencyList = CreateCurrencyList();

            foreach (Currency currency in currencyList) // 
            {
                Console.WriteLine(currency);
            }
        }

        /// <summary>
        /// the function uses api to get updated currency values
        /// </summary>
        /// <returns>list of currencies</returns>
        public static List<Currency> CreateCurrencyList()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://api.currencyapi.com/v3/latest?apikey=cur_live_3OCymrhZQ4ZVFKl5twKaurzQQ0GAkGOvi7Jvcveu");
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            JsonObject json = new JsonObject();
            json = (JsonObject)JsonObject.Parse(responseString);
            var currencies = json["data"];
            List<Currency> currencyList = new List<Currency>();
            List<string> currencyCodes = CreateListOfCurrecnyCodes();

            foreach (var currencyCode in currencyCodes)
            {
                var currencyInfo = currencies[currencyCode];
                Currency currency = new Currency((currencyInfo["code"]).ToString(), Double.Parse((currencyInfo["value"]).ToString()));
                currencyList.Add(currency);
            }

            return currencyList;
        }

        public static List<string> CreateListOfCurrecnyCodes()
        {
            List<string> currencyNames = new List<string>();
            currencyNames.Add("ILS");
            currencyNames.Add("EUR");
            currencyNames.Add("GBP");
            currencyNames.Add("JPY");
            currencyNames.Add("CHF");

            return currencyNames;
        }
    }

    public class Currency
    {
        private string CurrencyCode { get; set; }
        private double CurrencyValue { get; set; }

        /// <summary>
        /// C'tor
        /// </summary>
        public Currency (string code,  double value)
        {
            this.CurrencyCode = code;
            this.CurrencyValue = value;
        }

        /// <summary>
        /// toString override function
        /// </summary>
        /// <returns>the object as string</returns>
        public override string ToString() 
        {
            return ("Currency Code: " + CurrencyCode + ", Currency Value: " + CurrencyValue.ToString());
        }
    }

}