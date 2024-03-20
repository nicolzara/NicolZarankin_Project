using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class ForeignExchangeTransaction : BaseEntity
    {
        protected User user;
        [DataMember]
        public User User
        {
            get { return user; } 
            set { user = value; }
        }

        protected ForeignExchange foreignExchange;
        [DataMember]
        public ForeignExchange ForeignExchange
        {
            get { return foreignExchange; }
            set { foreignExchange = value; }
        }

        protected double currencyAmount;
        [DataMember]
        public double CurrencyAmount
        {
            get { return currencyAmount; }
            set { currencyAmount = value; }
        }

        protected double currencyValue;
        [DataMember]
        public double CurrencyValue
        {
            get { return currencyValue; }
            set { currencyValue = value; }
        }

        protected bool buyOrSell;
        [DataMember]
        public bool BuyOrSell
        {
            get { return buyOrSell;}
            set { buyOrSell = value; }
        }

        protected DateTime dateSignature;
        [DataMember]
        public DateTime DateSignature
        {
            get { return dateSignature; } 
            set {  dateSignature = value; } 
        }
    }

    [CollectionDataContract]
    public class ForeignExchangeTransactionList : List<ForeignExchangeTransaction>
    {
        public ForeignExchangeTransactionList() { } // default c'tor with empty list

        public ForeignExchangeTransactionList(IEnumerable<ForeignExchangeTransaction> list) : base(list) { } // parse generic list to foreign exchange list

        public ForeignExchangeTransactionList(IEnumerable<BaseEntity> list) : base(list.Cast<ForeignExchangeTransaction>().ToList()) { } // from base class to foreign exchange list
    }
}
