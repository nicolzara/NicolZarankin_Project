using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicolZarankin_Project.Model
{
    public class ForeignExchange : BaseEntity
    {
        protected string currencyName;
        public string CurrencyName
        {
            get { return CurrencyName; }
            set { CurrencyName = value; }
        }

        protected string currencyCode;
        public string CurrencyCode
        {
            get { return currencyCode; }
            set { currencyCode = value; }
        }

        protected double value;
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

    public class ForeignExchangeList : List<ForeignExchange>
    {
        public ForeignExchangeList() { } // default c'tor with empty list

        public ForeignExchangeList(IEnumerable<ForeignExchange> list) : base(list) { } // parse generic list to foreign exchange list

        public ForeignExchangeList(IEnumerable<BaseEntity> list) : base(list.Cast<ForeignExchange>().ToList()) { } // from base class to foreign exchange list
    }
}
