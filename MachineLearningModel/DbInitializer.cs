using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MachineLearningModel
{
    public static class DbInitializer
    {
        public static void Initialize(StockDataContext context)
        {
            context.Database.EnsureCreated();

            // Look for any stocks
            if (context.Stocks.Any())
            {
                return; // DB has been seeded
            }

            var stocks = new List<Stock>();
            var fileNames = Directory.GetFiles(".\\StockData\\stocks");
            foreach (string file in fileNames)
            {
                using (var reader = new StreamReader(file))
                {
                    var line = reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        var values = line.Split(',');
                        stocks.Append(new Stock(Convert.ToDateTime(values[0]), float.Parse(values[1]),
                            float.Parse(values[2]), float.Parse(values[3]), float.Parse(values[4]),
                            float.Parse(values[5]),
                            int.Parse(values[6])));
                    }
                }
            }

            foreach (Stock s in stocks)
            {
                context.Stocks.Add(s);
            }

            context.SaveChanges();
        }
    }
}