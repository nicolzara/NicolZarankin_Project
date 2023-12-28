using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
