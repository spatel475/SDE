using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using SDE_Server.Domain.ReleaseStatemachine;
using System.IO;
using SDE_Server.Domain.Entities;

namespace SDE_Server
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine(JsonConvert.SerializeObject(AppSettings.GetSettings()));
            Console.WriteLine("\nStatemachine Digraph: \n:" + new ReleaseMachine().ToDotMap());
            Console.WriteLine("\nStatemachine JSON: \n:" + new ReleaseMachine().ToJson());
            Console.WriteLine(Convert.ToBase64String(File.ReadAllBytes("C:\\Users\\blakehastings\\Downloads\\example-release.pdf")));

            using (var db = new SDEDBContext())
            {
                db.DocumentTemplateData.Add(new DocumentTemplateData()
                {
                    TemplateID=1,
                    Template = File.ReadAllBytes("C:\\Users\\blakehastings\\Downloads\\example-release.pdf")
                });

                db.SaveChanges();
            }

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
