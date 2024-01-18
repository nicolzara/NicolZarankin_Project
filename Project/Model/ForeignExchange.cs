using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class ForeignExchange : BaseEntity
    {
        protected string currencyName;
        [DataMember]
        public string CurrencyName
        {
            get { return currencyName; }
            set { currencyName = value; }
        }

        protected string currencyCode;
        [DataMember]
        public string CurrencyCode
        {
            get { return currencyCode; }
            set { currencyCode = value; }
        }

        protected double value;
        [DataMember]
        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public override string ToString()
        {
            return ("Currency Name" + currencyName + "Currency Code: " + currencyCode + ", Currency Value: " + value.ToString());
        }
    }

    [CollectionDataContract]
    public class ForeignExchangeList : List<ForeignExchange>
    {
        public ForeignExchangeList() { } // default c'tor with empty list

        public ForeignExchangeList(IEnumerable<ForeignExchange> list) : base(list) { } // parse generic list to foreign exchange list

        public ForeignExchangeList(IEnumerable<BaseEntity> list) : base(list.Cast<ForeignExchange>().ToList()) { } // from base class to foreign exchange list
    }
}
