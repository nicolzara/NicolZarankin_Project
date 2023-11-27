using Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json.Nodes;

namespace ViewModel
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
            List<ForeignExchange> foreignExchangeList = new List<ForeignExchange>();
            foreach (var currency in list)
            {
                var foreignExchangeInfo = currencies[currency.CurrencyCode];
                ForeignExchange foreignExchange = new ForeignExchange();
                foreignExchange.CurrencyName = currency.CurrencyName;
                foreignExchange.CurrencyCode = (foreignExchangeInfo["code"]).ToString();
                foreignExchange.Value = Double.Parse((foreignExchangeInfo["value"]).ToString());

                foreignExchangeList.Add(foreignExchange);
            }

            return foreignExchangeList;
        }

        public ForeignExchange SelectById(int Id)
        {
            command.CommandText = "SELECT * FROM ForeingExchange_Table WHERE Id=" + Id;
            ForeignExchangeList foreignExchangeList = new ForeignExchangeList(ExecuteCommand());

            if (foreignExchangeList.Count == 0)
            {
                return null;
            }

            return foreignExchangeList[0];
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            ForeignExchange foreignExchange = entity as ForeignExchange;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Id", foreignExchange.Id);
            command.Parameters.AddWithValue("@CurrencyName", foreignExchange.CurrencyName);
            command.Parameters.AddWithValue("@CurrencyCode", foreignExchange.CurrencyCode);
        }

        public int Insert(ForeignExchange foreignExchange)
        {
            command.CommandText = "INSERT INTO ForeignExchange_Table (CurrencyName, CurrencyCode) VALUES (@CurrencyName, @CurrencyCode)";
            LoadParameters(foreignExchange);
            return ExecuteCRUD();
        }
        public int Update(ForeignExchange foreignExchange)
        {
            command.CommandText = "UPDATE ForeignExchange_Table SET CurrencyName = @CurrencyName, CurrencyCode = @CurrencyCode WHERE Id = @Id";
            LoadParameters(foreignExchange);
            return ExecuteCRUD();
        }
        public int Delete(ForeignExchange foreignExchange)
        {
            command.CommandText = "DELETE FROM ForeignExchange_Table WHERE Id = @Id";
            LoadParameters(foreignExchange);
            return ExecuteCRUD();
        }
    }
}
