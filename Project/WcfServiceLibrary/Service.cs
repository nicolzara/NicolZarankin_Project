using Model;
using System.ServiceModel;
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

        #region Foreign Exchange Wallet
        public ForeignExchangeWalletList SelectAllForeignExchangeWallets()
        {
            ForeignExchangeWallet_Database foreignExchangeWallet_Database = new ForeignExchangeWallet_Database();
            return foreignExchangeWallet_Database.SelectAll();
        }

        public ForeignExchangeWalletList SelectForeignExchangeWalletsByUser(User user)
        {
            ForeignExchangeWallet_Database foreignExchangeWallet_Database = new ForeignExchangeWallet_Database();
            return foreignExchangeWallet_Database.SelectByUser(user);
        }

        public int InsertForeignExchangeWallet(ForeignExchangeWallet foreignExchangeWallet)
        {
            ForeignExchangeWallet_Database foreignExchangeWallet_Database = new ForeignExchangeWallet_Database();
            return foreignExchangeWallet_Database.Insert(foreignExchangeWallet);
        }

        public int UpdateForeignExchangeWallet(ForeignExchangeWallet foreignExchangeWallet)
        {
            ForeignExchangeWallet_Database foreignExchangeWallet_Database = new ForeignExchangeWallet_Database();
            return foreignExchangeWallet_Database.Update(foreignExchangeWallet);
        }

        public int DeleteForeignExchangeWallet(ForeignExchangeWallet foreignExchangeWallet)
        {
            ForeignExchangeWallet_Database foreignExchangeWallet_Database = new ForeignExchangeWallet_Database();
            return foreignExchangeWallet_Database.Delete(foreignExchangeWallet);
        }
        #endregion

        #region Stock Wallet
        public StockWalletList SelectAllStockWallets()
        {
            StockWallet_Database stockWallet_Database = new StockWallet_Database();
            return stockWallet_Database.SelectAll();
        }

        public StockWalletList SelectStockWalletsByUser(User user)
        {
            StockWallet_Database stockWallet_Database = new StockWallet_Database();
            return stockWallet_Database.SelectByUser(user);
        }

        public int InsertStockWallet(StockWallet stockWallet)
        {
            StockWallet_Database stockWallet_Database = new StockWallet_Database();
            return stockWallet_Database.Insert(stockWallet);
        }

        public int UpdateStockWallet(StockWallet stockWallet)
        {
            StockWallet_Database stockWallet_Database = new StockWallet_Database();
            return stockWallet_Database.Update(stockWallet);
        }

        public int DeleteStockWallet(StockWallet stockWallet)
        {
            StockWallet_Database stockWallet_Database = new StockWallet_Database();
            return stockWallet_Database.Delete(stockWallet);
        }
        #endregion
    }
}
