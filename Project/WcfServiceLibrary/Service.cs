using Model;
using ViewModel;

namespace WcfServiceLibrary
{
    public class Service : IService
    {
        #region User
        public UserList SelectAllUsers()
        {
            User_Database user_Database = new User_Database();
            return user_Database.SelectAll();
        }

        public int InsertUser(User user)
        {
            User_Database user_Database = new User_Database();
            return user_Database.Insert(user);
        }

        public int UpdateUser(User user)
        {
            User_Database user_Database = new User_Database();
            return user_Database.Update(user);
        }

        public int DeleteUser(User user)
        {
            User_Database user_Database = new User_Database();
            return user_Database.Delete(user);
        }

        public User Login(string username, string password)
        {
            return new User_Database().Login(username, password);
        }

        public int Signup(User user)
        {
            // check if the username exists in the table
            if (new User_Database().SelectByUsername(user.UserName) != null)
            {
                return -1;
            }

            return InsertUser(user);
        }

        #endregion

        #region Foreign Exchange
        public ForeignExchangeList SelectAllForeignExchanges()
        {
            ForeignExchange_Database foreignExchange_Database = new ForeignExchange_Database();
            return foreignExchange_Database.SelectAll();
        }

        public int InsertForeignExchange(ForeignExchange foreignExchange)
        {
            ForeignExchange_Database foreignExchange_Database = new ForeignExchange_Database();
            return foreignExchange_Database.Insert(foreignExchange);
        }

        public int UpdateForeignExchange(ForeignExchange foreignExchange)
        {
            ForeignExchange_Database foreignExchange_Database = new ForeignExchange_Database();
            return foreignExchange_Database.Update(foreignExchange);
        }

        public int DeleteForeignExchange(ForeignExchange foreignExchange)
        {
            ForeignExchange_Database foreignExchange_Database = new ForeignExchange_Database();
            return foreignExchange_Database.Delete(foreignExchange);
        }
        #endregion 

        #region Stock
        public StockList SelectAllStocks()
        {
            Stock_Database stock_Database = new Stock_Database();
            return stock_Database.SelectAll();
        }

        public int InsertStock(Stock stock)
        {
            Stock_Database stock_Database = new Stock_Database();
            return stock_Database.Insert(stock);
        }

        public int UpdateStock(Stock stock)
        {
            Stock_Database stock_Database = new Stock_Database();
            return stock_Database.Update(stock);
        }

        public int DeleteStock(Stock stock)
        {
            Stock_Database stock_Database = new Stock_Database();
            return stock_Database.Delete(stock);
        }
        #endregion 

        #region Foreign Exchange Transactions
        public ForeignExchangeTransactionList SelectAllForeignExchangeTransactions()
        {
            ForeignExchangeTransactions_Database foreignExchangeTransactions_Database = new ForeignExchangeTransactions_Database();
            return foreignExchangeTransactions_Database.SelectAll();
        }

        public int InsertForeignExchangeTransaction(ForeignExchangeTransaction foreignExchangeTransaction)
        {
            ForeignExchangeTransactions_Database foreignExchangeTransactions_Database = new ForeignExchangeTransactions_Database();
            return foreignExchangeTransactions_Database.Insert(foreignExchangeTransaction);
        }

        public int UpdateForeignExchangeTransaction(ForeignExchangeTransaction foreignExchangeTransaction)
        {
            ForeignExchangeTransactions_Database foreignExchangeTransactions_Database = new ForeignExchangeTransactions_Database();
            return foreignExchangeTransactions_Database.Update(foreignExchangeTransaction);
        }

        public int DeleteForeignExchangeTransaction(ForeignExchangeTransaction foreignExchangeTransaction)
        {
            ForeignExchangeTransactions_Database foreignExchangeTransactions_Database = new ForeignExchangeTransactions_Database();
            return foreignExchangeTransactions_Database.Delete(foreignExchangeTransaction);
        }
        #endregion

        #region Stock Transactions
        public StockTransactionList SelectAllStockTransactions()
        {
            StockTransactions_Database stockTransactions_Database = new StockTransactions_Database();
            return stockTransactions_Database.SelectAll();
        }

        public int InsertStockTransaction(StockTransaction StockTransaction)
        {
            StockTransactions_Database stockTransactions_Database = new StockTransactions_Database();
            return stockTransactions_Database.Insert(StockTransaction);
        }

        public int UpdateStockTransaction(StockTransaction StockTransaction)
        {
            StockTransactions_Database stockTransactions_Database = new StockTransactions_Database();
            return stockTransactions_Database.Update(StockTransaction);
        }

        public int DeleteStockTransaction(StockTransaction StockTransaction)
        {
            StockTransactions_Database stockTransactions_Database = new StockTransactions_Database();
            return stockTransactions_Database.Delete(StockTransaction);
        }
        #endregion
    }
}
