using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using SDE_Server.Domain.ReleaseStatemachine;

namespace SDE_Server
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine(JsonConvert.SerializeObject(AppSettings.GetSettings()));
            Console.WriteLine("\nStatemachine Digraph: \n:" + new ReleaseMachine().ToDotMap());
            Console.WriteLine("\nStatemachine JSON: \n:" + new ReleaseMachine().ToJson());
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
