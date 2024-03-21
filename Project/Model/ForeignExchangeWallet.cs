using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ForeignExchangeWallet : BaseEntity
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

        protected int currencyAmount;
        [DataMember]
        public int CurrencyAmount
        {
            get { return currencyAmount; }
            set { currencyAmount = value; }
        }
    }

    [CollectionDataContract]
    public class ForeignExchangeWalletList : List<ForeignExchangeWallet>
    {
        public ForeignExchangeWalletList() { } // default c'tor with empty list

        public ForeignExchangeWalletList(IEnumerable<ForeignExchangeWallet> list) : base(list) { } // parse generic list to foreign exchange list

        public ForeignExchangeWalletList(IEnumerable<BaseEntity> list) : base(list.Cast<ForeignExchangeWallet>().ToList()) { } // from base class to foreign exchange list
    }
}
