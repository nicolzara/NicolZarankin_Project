using Model;
using System.ServiceModel;

namespace WcfServiceLibrary
{
    [ServiceContract]
    public interface IService
    {
        //User
        [OperationContract] UserList SelectAllUsers();
        [OperationContract] int InsertUser(User user);
        [OperationContract] int UpdateUser(User user);
        [OperationContract] int DeleteUser(User user);
        [OperationContract] User Login(string username, string password);
        [OperationContract] int Signup(User user);

        //Foreign Exchange
        [OperationContract] ForeignExchangeList SelectAllForeignExchanges();
        [OperationContract] int InsertForeignExchange(ForeignExchange foreignExchange);
        [OperationContract] int UpdateForeignExchange(ForeignExchange foreignExchange);
        [OperationContract] int DeleteForeignExchange(ForeignExchange foreignExchange);

        //Stock
        [OperationContract] StockList SelectAllStocks();
        [OperationContract] int InsertStock(Stock stock);
        [OperationContract] int UpdateStock(Stock stock);
        [OperationContract] int DeleteStock(Stock stock);

        //Foreign Exchange Transactions
        [OperationContract] ForeignExchangeTransactionList SelectAllForeignExchangeTransactions();
        [OperationContract] ForeignExchangeTransactionList SelectForeignExchangeTransactionsByUser(User user);
        [OperationContract] int InsertForeignExchangeTransaction(ForeignExchangeTransaction foreignExchangeTransaction);
        [OperationContract] int UpdateForeignExchangeTransaction(ForeignExchangeTransaction foreignExchangeTransaction);
        [OperationContract] int DeleteForeignExchangeTransaction(ForeignExchangeTransaction foreignExchangeTransaction);

        //Stock Transactions
        [OperationContract] StockTransactionList SelectAllStockTransactions();
        [OperationContract] StockTransactionList SelectStockTransactionsByUser(User user);
        [OperationContract] int InsertStockTransaction(StockTransaction StockTransaction);
        [OperationContract] int UpdateStockTransaction(StockTransaction StockTransaction);
        [OperationContract] int DeleteStockTransaction(StockTransaction StockTransaction);

        //Foreign Exchange Wallet
        [OperationContract] ForeignExchangeWalletList SelectAllForeignExchangeWallets();
        [OperationContract] ForeignExchangeWalletList SelectForeignExchangeWalletsByUser(User user);
        [OperationContract] int InsertForeignExchangeWallet(ForeignExchangeWallet foreignExchangeWallet);
        [OperationContract] int UpdateForeignExchangeWallet(ForeignExchangeWallet foreignExchangeWallet);
        [OperationContract] int DeleteForeignExchangeWallet(ForeignExchangeWallet foreignExchangeWallet);

        //Stock Wallet
        [OperationContract] StockWalletList SelectAllStockWallets();
        [OperationContract] StockWalletList SelectStockWalletsByUser(User user);
        [OperationContract] int InsertStockWallet(StockWallet stockWallet);
        [OperationContract] int UpdateStockWallet(StockWallet stockWallet);
        [OperationContract] int DeleteStockWallet(StockWallet stockWallet);
    }

}
