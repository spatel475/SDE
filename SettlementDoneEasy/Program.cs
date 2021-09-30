using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;

namespace SDE_Server
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine(JsonConvert.SerializeObject(AppSettings.GetSettings()));
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("https://" + AppSettings.GetSettings().SDE_ServerHost + ":" + AppSettings.GetSettings().SDE_ServerPort);
                    webBuilder.UseStartup<Startup>();
                });

    }
}
