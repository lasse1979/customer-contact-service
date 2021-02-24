namespace CustomerContact.Domain.Repository
{
  public interface ICustomerContactCommand
  {
    string GetAll { get; }
    string GetById { get; }
    string Add { get; }
    string Update { get; }
    string Delete { get; }
  }
}