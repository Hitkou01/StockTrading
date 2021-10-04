using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Data
{
    public class StockData
    {
        private string stockSymbol;
        public string StockSymbol
        {
            get { return stockSymbol; }

            set { stockSymbol = value; }
        }
        private StockType stockType;
        public StockType StockType
        {
            get { return stockType; }

            set { stockType = value; }
        }
        private double lastDiv;
        public double LastDiv
        {
            get { return lastDiv; }

            set { lastDiv = value; }
        }
        private double fixDiv;
        public double FixDiv
        {
            get { return fixDiv; }

            set { fixDiv = value; }
        }
        private double parValue;
        public double ParValue
        {
            get { return parValue; }

            set { parValue = value; }
        }
        private Dictionary<DateTime, TradeData> trades;
        public Dictionary<DateTime, TradeData> Trades
        {
            get { return trades; }

            set { trades = value; }
        }

        public StockData(string stockSymbol, StockType stockType, double lastDiv, double fixDiv, double value)
        {
            this.stockSymbol = stockSymbol;
            this.stockType = stockType;
            this.lastDiv = lastDiv;
            this.fixDiv = fixDiv;
            this.parValue = value;
            this.trades = new Dictionary<DateTime, TradeData>();
        }
        public double getDividend(double price, StockData data)
        {
            switch (data.StockType)
            {
                case StockType.Common:
                    return data.LastDiv / price;
                case StockType.Preferred:
                    return (data.FixDiv * data.ParValue) / price;
                default:
                    return 0.0;

            }
        }
        public double getPERatio(double price, StockData data)
        {
            return price / data.LastDiv;
        }

        public void buyTrade(int quantity, double price)
        {
            TradeData trade = new TradeData("BUY", quantity, price);
            this.Trades.Add(DateTime.Now, trade);
        }
        public void sellTrade(int quantity, double price)
        {
            TradeData trade = new TradeData("SELL", quantity, price);
            this.Trades.Add(DateTime.Now, trade);
        }

        public double getPrice()
        {
            if (this.Trades.Count > 0)
            {
                return this.Trades.Values.Last().Price;
            }
            return 0.0;
        }

        public string getStockSysmbol()
        {
            return this.StockSymbol;
        }

        public Double calculateVolumeWeightedStockPrice()
        {            
            // Date 15 minutes ago
            var startTime = DateTime.Now - new TimeSpan(0,15,0);
            // Get trades for the last 15 minutes
            this.trades.Keys.Where(a => a.Equals(startTime));
            // Calculate
            Double volumeWeigthedStockPrice = 0.0;
            int totalQuantity = 0;
            foreach (var trade in this.Trades.Values)
            {
                totalQuantity += trade.Quantity;
                volumeWeigthedStockPrice += trade.Price * trade.Quantity;
            }
            return volumeWeigthedStockPrice / totalQuantity;
        }
    }
}
