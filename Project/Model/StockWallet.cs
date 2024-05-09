using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class StockWallet : BaseEntity
    {
        protected User user;
        [DataMember]
        public User User
        {
            get { return user; }
            set { user = value; }
        }

        protected Stock stock;
        [DataMember]
        public Stock Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        protected int stockAmount;
        [DataMember]
        public int StockAmount
        {
            get { return stockAmount; }
            set { stockAmount = value; }
        }
    }

    [CollectionDataContract]
    public class StockWalletList : List<StockWallet>
    {
        public StockWalletList() { } // default c'tor with empty list

        public StockWalletList(IEnumerable<StockWallet> list) : base(list) { } // parse generic list to foreign exchange list

        public StockWalletList(IEnumerable<BaseEntity> list) : base(list.Cast<StockWallet>().ToList()) { } // from base class to foreign exchange list
    }
}
