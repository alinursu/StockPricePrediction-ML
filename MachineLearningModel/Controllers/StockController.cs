using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace MachineLearningModel.Controllers
{
    [ApiController]
    [Route("StockController")]
    public class StockController : Controller
    {
        private static readonly string[] StockNames = GetStockNames();

        private static string[] GetStockNames()
        {
            var fileNames = Directory.GetFiles(".\\Data\\stocks");
            var stockNames = new string[fileNames.Length];
            var len = 0;
            foreach (var fileName in fileNames)
            {
                var stock = fileName.Substring(".\\Data\\stocks\\".Length);
                stock = stock.Replace(".csv", "");
                stockNames[len++] = stock;
            }

            return stockNames;
        }
        [Route("AllStocks")]
        [HttpGet]
        public IEnumerable<string> GetAllStocks()
        {
            return StockNames;
        }
        [Route("StockData")]
        [HttpPost]
        public IEnumerable<string> GetStockData(string name)
        {
            return new string[]{"name","data"};
        }
    }
}