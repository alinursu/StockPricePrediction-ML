using System;
using Microsoft.ML.Data;

namespace MachineLearningModel
{
    public class StockData
    {
        [LoadColumn(0)] public DateTime Date;

        // [LoadColumn(1)] public float Open;

        [LoadColumn(2)] public float HighPrice;
        //
        // [LoadColumn(3)] public double LowPrice;
        //
        // [LoadColumn(4)] public double ClosePrice;
        //
        // [LoadColumn(5)] public double AdjClosePrice;
        //
        // [LoadColumn(6)] public long Volume;
    }
}