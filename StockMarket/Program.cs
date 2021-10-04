using StockMarket.Data;
using System;
using System.Collections.Generic;

namespace StockMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Dictionary<string, StockData> stockdata = new Dictionary<string, StockData>();
            stockdata.Add("TEA", new StockData("TEA", StockType.Common, 0.0, 0.0, 100.0));
            stockdata.Add("POP", new StockData("POP", StockType.Common, 8.0, 0.0, 100.0));
            stockdata.Add("ALE", new StockData("ALE", StockType.Common, 23.0, 0.0, 60.0));
            stockdata.Add("GIN", new StockData("GIN", StockType.Common, 8.0, 0.02, 100.0));
            stockdata.Add("JOE", new StockData("JOE", StockType.Common, 13.0, 0.0, 250.0));

            Console.WriteLine("Please input price");
            double price = Convert.ToDouble(Console.ReadLine());

            foreach (var stock in stockdata.Values)
            {
                Console.WriteLine("Dividend for " + stock.getStockSysmbol() + " is " + stock.getDividend(price, stock));
                Console.WriteLine("PE Ratio for " + stock.getStockSysmbol() + " is " + stock.getPERatio(price, stock));                
                RecordTrade(stock);
                Console.WriteLine(stock.getStockSysmbol() + " price $ " + stock.getPrice());
                Console.WriteLine(stock.getStockSysmbol() + " VOlumeWeight $ " + stock.calculateVolumeWeightedStockPrice());                
            }
            GBCE gBCE = new GBCE();
            Console.WriteLine("GBE INdex " + gBCE.getAllShareIndex(stockdata));


        }
        public static void RecordTrade(StockData stock)
        {
            // Record some sample trades
            
                Random r = new Random();
                int rangeMin = 1;
                int rangeMax = 10;
                double randomValue = rangeMin + (rangeMax - rangeMin) * r.NextDouble();
                stock.buyTrade(1, randomValue);

                Console.WriteLine(stock.getStockSysmbol() + " Bought " + 1 + " Shares at $ " + randomValue);
                randomValue = rangeMin + (rangeMax - rangeMin) * r.NextDouble();
                stock.sellTrade(1, randomValue);
                Console.WriteLine(stock.getStockSysmbol() + " Sold " + 1 + " Shares at $ " + randomValue);            
        }
    }
}
