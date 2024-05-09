using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ForeignExchangeWallet_Database : Base_Database
    {
        protected override BaseEntity NewEntity()
        {
            return new ForeignExchangeWallet();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User_Database user_Database = new User_Database();
            ForeignExchange_Database foreignExchange_Database = new ForeignExchange_Database();
            ForeignExchangeWallet foreignExchangeWallet = entity as ForeignExchangeWallet;

            foreignExchangeWallet.User = user_Database.SelectById(int.Parse(reader["UserId"].ToString()));
            foreignExchangeWallet.ForeignExchange = foreignExchange_Database.SelectById(int.Parse(reader["ForeignExchangeId"].ToString()));
            foreignExchangeWallet.CurrencyAmount = double.Parse(reader["CurrencyAmount"].ToString());

            return foreignExchangeWallet;
        }

        public ForeignExchangeWalletList SelectAll()
        {
            command.CommandText = "SELECT * FROM ForeignExchangeWallet_Table";
            ForeignExchangeWalletList foreignExchangeWalletList = new ForeignExchangeWalletList(ExecuteCommand());
            return foreignExchangeWalletList;
        }

        public ForeignExchangeWalletList SelectByUser(User user)
        {
            command.CommandText = "SELECT * FROM ForeignExchangeWallet_Table WHERE UserId=" + user.Id;
            ForeignExchangeWalletList foreignExchangeWalletList = new ForeignExchangeWalletList(ExecuteCommand());

            return foreignExchangeWalletList;
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            ForeignExchangeWallet foreignExchangeWallet = entity as ForeignExchangeWallet;
            command.Parameters.Clear();

            command.Parameters.AddWithValue("@UserId", foreignExchangeWallet.User.Id);
            command.Parameters.AddWithValue("@ForeignExchangeId", foreignExchangeWallet.ForeignExchange.Id);
            command.Parameters.AddWithValue("@CurrencyAmount", foreignExchangeWallet.CurrencyAmount);
        }

        public int Insert(ForeignExchangeWallet ForeignExchangeWallet)
        {
            command.CommandText = "INSERT INTO ForeignExchangeWallet_Table (UserId, ForeignExchangeId, CurrencyAmount) VALUES (@UserId, @ForeignExchangeId, @CurrencyAmount)";
            LoadParameters(ForeignExchangeWallet);
            return ExecuteCRUD();
        }
        public int Update(ForeignExchangeWallet ForeignExchangeWallet)
        {
            command.CommandText = "UPDATE ForeignExchangeWallet_Table SET UserId = @UserId, ForeignExchangeId = @ForeignExchangeId, CurrencyAmount = @CurrencyAmount WHERE UserId = @UserId AND ForeignExchangeId = @ForeignExchangeId";
            LoadParameters(ForeignExchangeWallet);
            return ExecuteCRUD();
        }
        public int Delete(ForeignExchangeWallet ForeignExchangeWallet)
        {
            command.CommandText = "DELETE FROM ForeignExchangeWallet_Table WHERE UserId = @UserId AND ForeignExchangeId = @ForeignExchangeId";
            LoadParameters(ForeignExchangeWallet);
            return ExecuteCRUD();
        }
    }
}
