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
        public IActionResult GetStockData([FromQuery] string name, [FromQuery] int lines)
        {
            Console.WriteLine(name);
            var stockData = Utils.GetStockData(name, lines);
            if (stockData == null)
            {
                return BadRequest("Stock name not found");
            }

            return Ok(stockData);
        }

        [Route("StockPrediction")]
        [HttpPost]
        public IActionResult GetStockPrediction([FromQuery] string name, [FromQuery] int days)
        {
            return Ok("Not implemented");
        }
    }
}