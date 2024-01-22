using System;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;

namespace Demo_API
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //api key : IHW5KG3V4NV7V8I0
            string symbol = "TSLA";
            var request = (HttpWebRequest)WebRequest.Create($"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={symbol}&interval=60min&outputsize=compact&apikey=IHW5KG3V4NV7V8I0");
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            JsonObject json = new JsonObject();
            json = (JsonObject)JsonObject.Parse(responseString);
            string stockRecentValue = (json["Time Series (60min)"][(json["Meta Data"]["3. Last Refreshed"]).ToString()]).ToString();
            json = (JsonObject)JsonObject.Parse(stockRecentValue);
            stockRecentValue = (json["4. close"]).ToString();
            double value = double.Parse(stockRecentValue);
            Console.WriteLine(value);
        }
    }
}