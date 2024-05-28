using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class StockWallet_Database : Base_Database
    {
        protected override BaseEntity NewEntity()
        {
            return new StockWallet();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User_Database user_Database = new User_Database();
            Stock_Database stock_Database = new Stock_Database();
            StockWallet stockWallet = entity as StockWallet;

            stockWallet.User = user_Database.SelectById(int.Parse(reader["UserId"].ToString()));
            stockWallet.Stock = stock_Database.SelectById(int.Parse(reader["StockId"].ToString()));
            stockWallet.StockAmount = int.Parse(reader["StockAmount"].ToString());

            return stockWallet;
        }

        public StockWalletList SelectAll()
        {
            command.CommandText = "SELECT * FROM StockWallet_Table";
            StockWalletList stockWalletList = new StockWalletList(ExecuteCommand());
            return stockWalletList;
        }

        public StockWalletList SelectByUser(User user)
        {
            command.CommandText = "SELECT * FROM StockWallet_Table WHERE UserId=" + user.Id;
            StockWalletList stockWalletList = new StockWalletList(ExecuteCommand());

            return stockWalletList;
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            StockWallet stockWallet = entity as StockWallet;
            command.Parameters.Clear();

            command.Parameters.AddWithValue("@UserId", stockWallet.User.Id);
            command.Parameters.AddWithValue("@StockId", stockWallet.Stock.Id);
            command.Parameters.AddWithValue("@StockAmount", stockWallet.StockAmount);
        }

        public int Insert(StockWallet stockWallet)
        {
            command.CommandText = "INSERT INTO StockWallet_Table (UserId, StockId, StockAmount) VALUES (@UserId, @StockId, @StockAmount)";
            LoadParameters(stockWallet);
            return ExecuteCRUD();
        }
        public int Update(StockWallet stockWallet)
        {
            command.CommandText = "UPDATE StockWallet_Table SET UserId = @UserId, StockId = @StockId, StockAmount = @StockAmount WHERE UserId = @UserId AND StockId = @StockId";
            LoadParameters(stockWallet);
            return ExecuteCRUD();
        }
        public int Delete(StockWallet stockWallet)
        {
            command.CommandText = "DELETE FROM StockWallet_Table WHERE UserId = @UserId AND StockId = @StockId";
            LoadParameters(stockWallet);
            return ExecuteCRUD();
        }

        public void DeleteByUser(User user)
        {
            StockWalletList list = this.SelectByUser(user);
            if (list != null)
            {
                foreach (StockWallet stockWallet in list)
                {
                    this.Delete(stockWallet);
                }
            }            
        }
    }
}
