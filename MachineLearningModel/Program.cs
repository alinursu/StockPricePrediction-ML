using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MachineLearningModel
{
    public class Program
    {
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