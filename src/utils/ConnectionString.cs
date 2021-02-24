using System;

namespace CustomerContact.Utils
{
  public sealed class ConnectionString
  {
    public static string Get()
    {
      return $"Server={Environment.GetEnvironmentVariable("DB_HOST")}; Database=Customer; User Id={Environment.GetEnvironmentVariable("DB_USER")}; Password={Environment.GetEnvironmentVariable("DB_PASSWORD")}";
    }
  }
}