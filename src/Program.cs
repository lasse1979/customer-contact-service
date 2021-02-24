using System;
using System.Linq;
using System.Reflection;
using CustomerContact.Utils;
using DbUp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace CustomerContact
{
  public class Program
  {
    public static void Main(string[] args)
    {
      // Create/migrate DB
      var connectionString = ConnectionString.Get();

      EnsureDatabase.For.SqlDatabase(connectionString);

      var upgrader =
          DeployChanges.To
              .SqlDatabase(connectionString)
              .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
              .LogToConsole()
              .Build();

      var result = upgrader.PerformUpgrade();
      if (!result.Successful)
      {
        Console.WriteLine(result.Error);
        return;
      }

      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
          .ConfigureAppConfiguration((hostingContext, config) =>
          {
            config.AddEnvironmentVariables(prefix: "MSSQL_");
          })
          .ConfigureWebHostDefaults(webBuilder =>
          {
            webBuilder.UseStartup<Startup>();
          });
  }
}
