using System;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace demo_dotnet_console_postgresql
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
            String connectionString = configuration.GetConnectionString("postgresql");
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Postgresql version = " + connection.ServerVersion);
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
