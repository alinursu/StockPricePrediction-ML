using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MachineLearningModel.Controllers
{
    [ApiController]
    [Route("StockController")]
    public class StockController : Controller
    {
        private static readonly IEnumerable<string> StockNames = Utils.GetStockNames();


        [Route("AllStocks")]
        [HttpGet]
        public IActionResult GetAllStocks()
        {
            return Ok(StockNames);
        }

        [Route("StockData")]
        [HttpGet]
        public IActionResult GetStockData([FromQuery] string name, [FromQuery] int days)
        {
            Console.WriteLine(name);
            Dictionary<string, string> stockDataWithDate = new Dictionary<string, string>();
            var stockData = Utils.GetStockHighPrice(name, days);
            if (stockData == null)
            {
                return BadRequest("Stock name not found");
            }

            var date = DateTime.Today;
            foreach (var value in stockData)
            {
                stockDataWithDate.Add(date.ToString("MM/dd/yyyy"), value);
                date = date.AddDays(-1);
            }

            return Ok(stockDataWithDate);
        }

        [Route("StockPrediction")]
        [HttpGet]
        public IActionResult GetStockPrediction([FromQuery] string name, [FromQuery] int days)
        {
            var prediction = Model.LoadModelAndPredict(name, days);
            Dictionary<string, float> stockDataWithDate = new Dictionary<string, float>();
            if (days < 0)
            {
                return BadRequest("The number of days must be a positive number");
            }

            if (prediction is null)
            {
                return BadRequest("Not valid stock name");
            }

            var date = DateTime.Today;
            foreach (var value in prediction)
            {
                date = date.AddDays(1);
                stockDataWithDate.Add(date.ToString("MM/dd/yyyy"), value);
            }

            return Ok(stockDataWithDate);
        }
    }
}