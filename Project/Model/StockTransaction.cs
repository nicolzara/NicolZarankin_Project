using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class StockTransaction : BaseEntity
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

        protected double stockValue;
        [DataMember]
        public double StockValue
        {
            get { return stockValue; }
            set { stockValue = value; }
        }

        protected bool buyOrSell;
        [DataMember]
        public bool BuyOrSell
        {
            get { return buyOrSell; }
            set { buyOrSell = value; }
        }

        protected DateTime dateSignature;
        [DataMember]
        public DateTime DateSignature
        {
            get { return dateSignature; }
            set { dateSignature = value; }
        }
    }

    [CollectionDataContract]
    public class StockTransactionList : List<StockTransaction>
    {
        public StockTransactionList() { } // default c'tor with empty list

        public StockTransactionList(IEnumerable<StockTransaction> list) : base(list) { } // parse generic list to list

        public StockTransactionList(IEnumerable<BaseEntity> list) : base(list.Cast<StockTransaction>().ToList()) { } // from base class to list
    }
}
