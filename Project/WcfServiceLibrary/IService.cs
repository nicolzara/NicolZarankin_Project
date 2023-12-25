using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;

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
        [OperationContract] int Login(string username, string password);

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
    }

}
