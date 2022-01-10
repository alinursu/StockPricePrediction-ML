using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MachineLearningModel
{
    public class Program
    {
        /**
         *  To generate the models for stock prediction, run the project with first line from main uncommented.
         */
        public static void Main(string[] args)
        {
            // Model.CreateAllModels();
            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}