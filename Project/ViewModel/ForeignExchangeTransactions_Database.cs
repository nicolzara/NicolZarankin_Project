using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ForeignExchangeTransactions_Database : Base_Database
    {
        protected override BaseEntity NewEntity()
        {
            return new ForeignExchangeTransaction();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User_Database user_Database = new User_Database();
            ForeignExchange_Database foreignExchange_Database = new ForeignExchange_Database();
            ForeignExchangeTransaction foreignExchangeTransaction = entity as ForeignExchangeTransaction;

            foreignExchangeTransaction.Id = int.Parse(reader["TransactionId"].ToString());
            foreignExchangeTransaction.User = user_Database.SelectById(int.Parse(reader["UserId"].ToString()));
            foreignExchangeTransaction.ForeignExchange = foreignExchange_Database.SelectById(int.Parse(reader["ForeignExchangeId"].ToString()));
            foreignExchangeTransaction.CurrencyAmount = int.Parse(reader["CurrencyAmount"].ToString());
            foreignExchangeTransaction.CurrencyValue = double.Parse(reader["CurrencyValue"].ToString());
            foreignExchangeTransaction.BuyOrSell = bool.Parse(reader["BuyOrSell"].ToString());
            foreignExchangeTransaction.DateSignature = DateTime.Parse(reader["DateSignature"].ToString());

            return foreignExchangeTransaction;
        }

        public ForeignExchangeTransactionList SelectAll()
        {
            command.CommandText = "SELECT * FROM ForeignExchangeTransactions_Table";
            ForeignExchangeTransactionList foreignExchangeTransactionList = new ForeignExchangeTransactionList(ExecuteCommand());
            return foreignExchangeTransactionList;
        }

        public ForeignExchangeTransaction SelectById(int Id)
        {
            command.CommandText = "SELECT * FROM ForeignExchangeTransactions_Table WHERE TransactionId=" + Id;
            ForeignExchangeTransactionList foreignExchangeTransactionList = new ForeignExchangeTransactionList(ExecuteCommand());

            if (foreignExchangeTransactionList.Count == 0)
            {
                return null;
            }

            return foreignExchangeTransactionList[0];
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            ForeignExchangeTransaction foreignExchangeTransaction = entity as ForeignExchangeTransaction;
            command.Parameters.Clear();

            command.Parameters.AddWithValue("@UserId", foreignExchangeTransaction.User.Id);
            command.Parameters.AddWithValue("@ForeignExchangeId", foreignExchangeTransaction.ForeignExchange.Id);
            command.Parameters.AddWithValue("@CurrencyAmount", foreignExchangeTransaction.CurrencyAmount);
            command.Parameters.AddWithValue("@CurrencyValue", foreignExchangeTransaction.CurrencyValue);
            command.Parameters.AddWithValue("@BuyOrSell", foreignExchangeTransaction.BuyOrSell);
            command.Parameters.AddWithValue("@DateSignature", foreignExchangeTransaction.DateSignature);
            command.Parameters.AddWithValue("@TransactionId", foreignExchangeTransaction.Id);
        }

        public int Insert(ForeignExchangeTransaction foreignExchangeTransaction)
        {
            command.CommandText = "INSERT INTO ForeignExchangeTransactions_Table (UserId, ForeignExchangeId, CurrencyAmount, CurrencyValue, BuyOrSell, DateSignature) VALUES (@UserId, @ForeignExchangeId, @CurrencyAmount, @CurrencyValue, @BuyOrSell, @DateSignature)";
            LoadParameters(foreignExchangeTransaction);
            return ExecuteCRUD();
        }
        public int Update(ForeignExchangeTransaction foreignExchangeTransaction)
        {
            command.CommandText = "UPDATE ForeignExchangeTransactions_Table SET UserId = @UserId, ForeignExchangeId = @ForeignExchangeId, CurrencyAmount = @CurrencyAmount, CurrencyValue = @CurrencyValue, BuyOrSell = @BuyOrSell, DateSignature = @DateSignature  WHERE TransactionId = @TransactionId";
            LoadParameters(foreignExchangeTransaction);
            return ExecuteCRUD();
        }
        public int Delete(ForeignExchangeTransaction foreignExchangeTransaction)
        {
            command.CommandText = "DELETE FROM ForeignExchangeTransactions_Table WHERE TransactionId = @TransactionId";
            LoadParameters(foreignExchangeTransaction);
            return ExecuteCRUD();
        }
    }
}
