using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Data
{
    public class TradeData
    {
        private string tradeType;
        public string TradeType 
        {
            get { return tradeType; }

            set { tradeType = value; }
        }
        private int quantity;
        public int Quantity
        {
            get { return quantity; }

            set { quantity = value; }
        }
        private double price;
        public double Price
        {
            get { return price; }

            set { price = value; }
        }
        public TradeData(string tradeType,int quantity, double price)
        {
            this.tradeType = tradeType;
            this.quantity = quantity;
            this.price = price;
        }
    }
}
