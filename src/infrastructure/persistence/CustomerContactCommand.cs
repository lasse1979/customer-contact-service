using CustomerContact.Domain.Repository;

namespace CustomerContact.Infrastructure.Persistence
{
  public class CustomerContactCommand : ICustomerContactCommand
  {
    public string GetAll => "SELECT * FROM CustomerContact";

    public string GetById => "SELECT * FROM CustomerContact WHERE Id=@Id";

    public string Add => "INSERT INTO CustomerContact VALUES (@Id, @PersonalNumber, @Email, @Street, @ZipCode, @Country, @PhoneNumber)";

    public string Update => "UPDATE CustomerContact Set PersonalNumber = @PersonalNumber, Email = @Email, Street = @Street, ZipCode = @ZipCode, Country = @Country, PhoneNumber = @PhoneNumber WHERE Id = @Id";

    public string Delete => "DELETE FROM CustomerContact WHERE Id = @Id";
  }
}