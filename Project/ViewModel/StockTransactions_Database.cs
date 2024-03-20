using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Util;

namespace ViewModel
{
    public class StockTransactions_Database : Base_Database
    {
        protected override BaseEntity NewEntity()
        {
            return new StockTransaction();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User_Database user_Database = new User_Database();
            Stock_Database stock_Database = new Stock_Database();
            StockTransaction stockTransaction = entity as StockTransaction;

            stockTransaction.Id = int.Parse(reader["Id"].ToString());
            stockTransaction.User = user_Database.SelectById(int.Parse(reader["UserId"].ToString()));   
            stockTransaction.Stock = stock_Database.SelectById(int.Parse(reader["StockId"].ToString()));
            stockTransaction.StockAmount = int.Parse(reader["StockAmount"].ToString());
            stockTransaction.StockValue = double.Parse(reader["StockValue"].ToString());
            stockTransaction.BuyOrSell = bool.Parse(reader["BuyOrSell"].ToString());
            stockTransaction.DateSignature = DateTime.Parse(reader["DateSignature"].ToString());

            return stockTransaction;
        }

        public StockTransactionList SelectAll()
        {
            command.CommandText = "SELECT * FROM StockTransactions_Table";
            StockTransactionList stockTransactionList = new StockTransactionList(ExecuteCommand());
            return stockTransactionList;
        }

        public StockTransaction SelectById(int Id)
        {
            command.CommandText = "SELECT * FROM StockTransactions_Table WHERE TransactionId=" + Id;
            StockTransactionList stockTransactionList = new StockTransactionList(ExecuteCommand());

            if (stockTransactionList.Count == 0)
            {
                return null;
            }

            return stockTransactionList[0];
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            StockTransaction stockTransaction = entity as StockTransaction;
            command.Parameters.Clear();

            command.Parameters.AddWithValue("@UserId", stockTransaction.User.Id);
            command.Parameters.AddWithValue("@StockId", stockTransaction.Stock.Id);
            command.Parameters.AddWithValue("@StockAmount", stockTransaction.StockAmount);
            command.Parameters.AddWithValue("@StockValue", stockTransaction.StockValue);
            command.Parameters.AddWithValue("@BuyOrSell", stockTransaction.BuyOrSell);
            command.Parameters.AddWithValue("@DateSignature", stockTransaction.DateSignature);
            command.Parameters.AddWithValue("@TransactionId", stockTransaction.Id);
        }

        public int Insert(StockTransaction stockTransaction)
        {
            command.CommandText = "INSERT INTO StockTransactions_Table (UserId, StockId, StockAmount, StockValue, BuyOrSell, DateSignature) VALUES (@UserId, @StockId, @StockAmount, @StockValue, @BuyOrSell, @DateSignature)";
            LoadParameters(stockTransaction);
            return ExecuteCRUD();
        }
        public int Update(StockTransaction stockTransaction)
        {
            command.CommandText = "UPDATE StockTransactions_Table SET UserId = @UserId, StockId = @StockId, StockAmount = @StockAmount, StockValue = @StockValue, BuyOrSell = @BuyOrSell, DateSignature = @DateSignature  WHERE TransactionId = @TransactionId";
            LoadParameters(stockTransaction);
            return ExecuteCRUD();
        }
        public int Delete(StockTransaction stockTransaction)
        {
            command.CommandText = "DELETE FROM StockTransactions_Table WHERE TransactionId = @TransactionId";
            LoadParameters(stockTransaction);
            return ExecuteCRUD();
        }
    }
}
