using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace HelloWorld2
{
    class Program
    {


        private static IConfiguration Configuration;

        static void Main(string[] args)
        {
            Console.WriteLine("Olá, eu sou um bot do Itaú, como posso te ajudar?");

            var response = Console.ReadLine();

            System.Console.WriteLine($"Hoje é dia: {DateTime.Today.ToLongDateString()}");


            var environmentName = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            Console.WriteLine(environmentName);

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();


            var value = Configuration["ItauEnvironment"];

            Console.WriteLine(value);

            Console.ReadKey();
        }
    }
}
