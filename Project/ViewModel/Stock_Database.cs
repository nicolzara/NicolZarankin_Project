using Model;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json.Nodes;
using System;

namespace ViewModel
{
    public class Stock_Database : Base_Database
    {
        protected override BaseEntity NewEntity()
        {
            return new Stock();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Stock stock = entity as Stock;

            stock.Id = int.Parse(reader["Id"].ToString());
            stock.StockName = reader["StockName"].ToString();
            stock.StockSymbol = reader["StockSymbol"].ToString();

            return stock;
        }

        public StockList SelectAll()
        {
            command.CommandText = "SELECT * FROM Stock_Table";
            StockList stockList = new StockList(ExecuteCommand());

            List<Stock> stocks = CreateStockList(stockList);
            stockList = new StockList(stocks);
                
            return stockList;
        }

        /// <summary>
        /// the function uses api to get updated currency values
        /// </summary>
        /// <returns>list of currencies</returns>
        public static List<Stock> CreateStockList(StockList list)
        {
            List<Stock> stockList = new List<Stock>(); 
            //api key : IHW5KG3V4NV7V8I0
            foreach(Stock s in list)
            {
                try
                {
                    string symbol = s.StockSymbol;
                    var request = (HttpWebRequest)WebRequest.Create($"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={symbol}&interval=60min&outputsize=compact&apikey=IHW5KG3V4NV7V8I0");
                    var response = (HttpWebResponse)request.GetResponse();
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    JsonObject json = new JsonObject();
                    json = (JsonObject)JsonObject.Parse(responseString);
                    string stockRecentValue = (json["Time Series (60min)"][(json["Meta Data"]["3. Last Refreshed"]).ToString()]).ToString();
                    json = (JsonObject)JsonObject.Parse(stockRecentValue);
                    stockRecentValue = (json["4. close"]).ToString();
                    double value = double.Parse(stockRecentValue);
                    s.Value = value;
                    stockList.Add(s);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Data);
                }
            }

            return stockList;
        }

        public Stock SelectById(int Id)
        {
            command.CommandText = $"SELECT * FROM Stock_Table WHERE Id={Id}";
            StockList stockList = new StockList(ExecuteCommand());

            if (stockList.Count == 0)
            {
                return null;
            }

            return stockList[0];
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            Stock stock = entity as Stock;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Id", stock.Id);
            command.Parameters.AddWithValue("@StockName", stock.StockName);
            command.Parameters.AddWithValue("@StockSymbol", stock.StockSymbol);
        }
        public int Insert(Stock stock)
        {
            command.CommandText = "INSERT INTO Stock_Table (StockName, StockSymbol) VALUES (@StockName, @StockSymbol)";
            LoadParameters(stock);
            return ExecuteCRUD();
        }
        public int Update(Stock stock)
        {
            command.CommandText = "UPDATE Stock_Table SET StockName = @StockName, StockSymbol = @StockSymbol WHERE Id = @Id";
            LoadParameters(stock);
            return ExecuteCRUD();
        }
        public int Delete(Stock stock)
        {
            command.CommandText = "DELETE FROM Stock_Table WHERE Id = @Id";
            LoadParameters(stock);
            return ExecuteCRUD();
        }
    }
}
