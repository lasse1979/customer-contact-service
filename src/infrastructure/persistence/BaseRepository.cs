using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using CustomerContact.Utils;

namespace CustomerContact.Infrastructure.Persistence
{
  public abstract class BaseRepository
  {
    private readonly string connectionString = ConnectionString.Get();
    protected BaseRepository()
    {
    }

    // use for buffered queries that return a type
    protected async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData)
    {
      try
      {
        await using (var connection = new SqlConnection(connectionString))
        {
          await connection.OpenAsync();
          return await getData(connection);
        }
      }
      catch (TimeoutException ex)
      {
        throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
      }
      catch (SqlException ex)
      {
        throw new Exception(String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
      }
    }

    // use for buffered queries that do not return a type
    protected async Task WithConnection(Func<IDbConnection, Task> getData)
    {
      try
      {
        await using (var connection = new SqlConnection(connectionString))
        {
          await connection.OpenAsync();
          await getData(connection);
        }
      }
      catch (TimeoutException ex)
      {
        throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
      }
      catch (SqlException ex)
      {
        throw new Exception(String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
      }
    }

    //use for non-buffered queries that return a type
    protected async Task<TResult> WithConnection<TRead, TResult>(Func<IDbConnection, Task<TRead>> getData, Func<TRead, Task<TResult>> process)
    {
      try
      {
        await using (var connection = new SqlConnection(connectionString))
        {
          await connection.OpenAsync();
          var data = await getData(connection);
          return await process(data);
        }
      }
      catch (TimeoutException ex)
      {
        throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
      }
      catch (SqlException ex)
      {
        throw new Exception(String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
      }
    }
  }
}