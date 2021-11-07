using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace MachineLearningModel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
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

        [HttpGet]
        public IEnumerable<string> GetAllStocks()
        {
            return StockNames;
        }
    }
}