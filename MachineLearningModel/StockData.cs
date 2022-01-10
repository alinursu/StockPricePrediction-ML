using System;
using Microsoft.ML.Data;

namespace MachineLearningModel
{
    public class StockData
    {
        [LoadColumn(0)] public DateTime Date;

        [LoadColumn(2)] public float HighPrice;

    }
}