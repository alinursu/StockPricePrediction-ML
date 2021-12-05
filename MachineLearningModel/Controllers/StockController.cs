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
            var stockData = Utils.GetStockHighPrice(name, days);
            if (stockData == null)
            {
                return BadRequest("Stock name not found");
            }

            return Ok(stockData);
        }

        [Route("StockPrediction")]
        [HttpGet]
        public IActionResult GetStockPrediction([FromQuery] string name, [FromQuery] int days)
        {
            var prediction = Model.LoadModelAndPredict(name, days);
            if (days < 0)
            {
                return BadRequest("The number of days must be a positive number");
            }

            if (prediction is null)
            {
                return BadRequest("Not valid stock name");
            }

            return Ok(prediction);
        }
    }
}