using NicolZarankin_Project.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json.Nodes;

namespace NicolZarankin_Project.ViewModel
{
    public class ForeignExchange_Database : Base_Database
    {
        protected override BaseEntity NewEntity()
        {
            return new ForeignExchange();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            ForeignExchange foreingExchange = entity as ForeignExchange;

            foreingExchange.Id = int.Parse(reader["Id"].ToString());
            foreingExchange.CurrencyName = reader["CurrencyName"].ToString();
            foreingExchange.CurrencyCode = reader["CurrencyCode"].ToString();
           
            return foreingExchange;
        }

        /// <summary>
        /// the function gets all the foreign exchanges from the database and update their value
        /// </summary>
        /// <returns></returns>
        public ForeignExchangeList SelectAll()
        {
            // gets all the foreign exchanges data except the value from the database
            command.CommandText = "SELECT * FROM ForeingExchange_Table";
            ForeignExchangeList foreignExchangeList = new ForeignExchangeList(ExecuteCommand());

            // gets the data from the external api
            List<ForeignExchange> currencies = CreateForeignExchangeList(foreignExchangeList);
            foreignExchangeList = new ForeignExchangeList(currencies);

            return foreignExchangeList;
        }

        /// <summary>
        /// the function uses api to get updated currency values
        /// </summary>
        /// <returns>list of currencies</returns>
        public static List<ForeignExchange> CreateForeignExchangeList(ForeignExchangeList list)
        {
            // http request from external api to get the foreign exchage rates
            var request = (HttpWebRequest)WebRequest.Create("https://api.ForeignExchangeapi.com/v3/latest?apikey=cur_live_3OCymrhZQ4ZVFKl5twKaurzQQ0GAkGOvi7Jvcveu"); 
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            // parse the data to json format
            JsonObject json = new JsonObject();
            json = (JsonObject)JsonObject.Parse(responseString);
            var currencies = json["data"];

            // create the list of currencies with the updated rate
            List<ForeignExchange> ForeignExchangeList = new List<ForeignExchange>();
            foreach (var currency in list)
            {
                var ForeignExchangeInfo = currencies[currency.CurrencyCode];
                ForeignExchange foreignExchange = new ForeignExchange();
                foreignExchange.CurrencyName = currency.CurrencyName;
                foreignExchange.CurrencyCode = (ForeignExchangeInfo["code"]).ToString();
                foreignExchange.Value = Double.Parse((ForeignExchangeInfo["value"]).ToString());

                ForeignExchangeList.Add(foreignExchange);
            }

            return ForeignExchangeList;
        }

        public ForeignExchange SelectById(int Id)
        {
            command.CommandText = "SELECT * FROM ForeingExchange_Table WHERE Id=" + Id;
            ForeignExchangeList ForeignExchangeList = new ForeignExchangeList(ExecuteCommand());

            if (ForeignExchangeList.Count == 0)
            {
                return null;
            }

            return ForeignExchangeList[0];
        }
    }
}
