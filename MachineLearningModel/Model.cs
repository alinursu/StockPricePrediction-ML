﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;

namespace MachineLearningModel
{
    public class Model
    {
        private static MLContext _mlContext = new MLContext();

        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH",
            MessageId = "type: System.Single[]; size: 143MB")]
        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH",
            MessageId = "type: System.String; size: 374MB")]
        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH",
            MessageId = "type: System.Byte[]")]
        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH",
            MessageId = "type: System.Reflection.CustomAttributeNamedParameter[]; size: 245MB")]
        public static void CreateAndSaveModel(string stock)
        {
            var dataPath = Path.Combine(Environment.CurrentDirectory, "StockData", "stocks", String.Concat(stock, ".csv"));
            Console.WriteLine(dataPath);
            var data = _mlContext.Data.LoadFromTextFile<StockData>(dataPath, hasHeader: true, separatorChar: ',');
            var pipeline = _mlContext.Forecasting.ForecastBySsa(
                "HighPricePredicted",
                nameof(StockData.HighPrice),
                20,
                100,
                5000,
                100,
                confidenceLevel: .98f);
            var model = pipeline.Fit(data);
            _mlContext.Model.Save(model, data.Schema,
                Path.Combine(Environment.CurrentDirectory, "StockData", "Models", String.Concat(stock, ".zip")));
        }

        public static IEnumerable<float> LoadModelAndPredict(string stock, int counts)
        {
            ITransformer trainedModel = _mlContext.Model.Load(
                Path.Combine(Environment.CurrentDirectory, "StockData", "stocks", String.Concat(stock, ".zip")),
                out var modelSchema);
            var forecastingEngine = trainedModel.CreateTimeSeriesEngine<StockData, StockPrediction>(_mlContext);
            var forecasts = forecastingEngine.Predict(counts);
            // foreach (var f in forecasts.HighPricePredicted)
            // {
            //     Console.WriteLine(f);
            // }

            return forecasts.HighPricePredicted;
        }

        public static void CreateAllModels()
        {
            var files = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, "StockData", "stocks"));
            foreach (var file in files)
            {
                if (file.Contains(".zip"))
                {
                    File.Delete(file);
                    continue;
                }
                var stock = file.Replace(".csv", "");
                Model.CreateAndSaveModel(stock);
            }
        }
    }
}