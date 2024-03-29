﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class Stock : BaseEntity
    {
        protected string stockName;
        [DataMember]
        public string StockName
        {
            get { return stockName; }
            set { stockName = value; }
        }

        protected string stockSymbol;
        [DataMember]
        public string StockSymbol
        {
            get { return stockSymbol; }
            set { stockSymbol = value; }
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
            return ("Stock Name" + stockName + "Stock Symbol: " + stockSymbol + ", Stock Value: " + value.ToString());
        }
    }

    [CollectionDataContract]
    public class StockList : List<Stock>
    {
        public StockList() { } // default c'tor with empty list

        public StockList(IEnumerable<Stock> list) : base(list) { } // parse generic list to stock list

        public StockList(IEnumerable<BaseEntity> list) : base(list.Cast<Stock>().ToList()) { } // from base class to stock list
    }
}
