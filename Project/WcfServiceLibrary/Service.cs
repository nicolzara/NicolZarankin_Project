using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ViewModel;

namespace WcfServiceLibrary
{
    public class Service : IService
    {
        #region
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

        public int Login(string username, string password)
        {
            return new User_Database().Login(username, password);
        }

        #endregion

        #region
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

        #region
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
            Stock_Database stock_Database= new Stock_Database();
            return stock_Database.Update(stock);
        }

        public int DeleteStock(Stock stock)
        {
            Stock_Database stock_Database = new Stock_Database();
            return stock_Database.Delete(stock);
        }
        #endregion
    }
}
