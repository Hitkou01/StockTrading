using StockMarket.Data;
using StockMarket.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket
{
    public class GBCE
    {
        public Double getAllShareIndex(Dictionary<string, StockData> stockdata)
        {
            Double allShareIndex = 0.0;
            
            foreach (var stock in stockdata.Values){
                allShareIndex += stock.getPrice();
            }
            return Math.Pow(allShareIndex, 1.0 / stockdata.Count);
        }
    }
}
