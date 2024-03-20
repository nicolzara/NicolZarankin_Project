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
        [OperationContract] int InsertForeignExchangeTransaction(ForeignExchangeTransaction foreignExchangeTransaction);
        [OperationContract] int UpdateForeignExchangeTransaction(ForeignExchangeTransaction foreignExchangeTransaction);
        [OperationContract] int DeleteForeignExchangeTransaction(ForeignExchangeTransaction foreignExchangeTransaction);

        //Stock Transactions
        [OperationContract] StockTransactionList SelectAllStockTransactions();
        [OperationContract] int InsertStockTransaction(StockTransaction StockTransaction);
        [OperationContract] int UpdateStockTransaction(StockTransaction StockTransaction);
        [OperationContract] int DeleteStockTransaction(StockTransaction StockTransaction);
    }

}
