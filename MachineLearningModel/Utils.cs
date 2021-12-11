﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MachineLearningModel
{
    public static class Utils
    {
        public static IEnumerable<string> GetStockNames()
        {
            var fileNames = Directory.GetFiles(".\\StockData\\stocks");
            var stockNames = new string[fileNames.Length];
            var len = 0;
            foreach (var fileName in fileNames)
            {
                var stock = fileName.Substring(".\\StockData\\stocks\\".Length);
                stock = stock.Replace(".csv", "");
                stockNames[len++] = stock;
            }

            return stockNames;
        }

        public static IEnumerable<string> GetStockData(string name, int lines)
        {
            IEnumerable<string> stockData = new List<string>();
            try
            {
                using (var streamReader = new StreamReader(".\\StockData\\stocks\\" + name + ".csv"))
                {
                    streamReader.ReadLine();
                    for (int i = 0; i < lines; i++)
                    {
                        stockData = stockData.Append(streamReader.ReadLine());
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }

            return stockData;
        }

        public static IEnumerable<string> GetStockHighPrice(string name, int days)
        {
            List<string> text = File.ReadLines(".\\StockData\\stocks\\" + name + ".csv").Reverse().Take(days).ToList();
            return text.Select(l => l.Split(",")[2]).Reverse();
        }
    }
}