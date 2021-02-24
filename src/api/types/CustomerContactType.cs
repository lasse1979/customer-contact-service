using CustomerContact.Domain.Repository;
using GraphQL.Types;

namespace CustomerContact.Api.Types
{
  public class CustomerContactType : ObjectGraphType<Domain.Entity.CustomerContact>
  {
    public CustomerContactType(ICustomerContactRepository repository)
    {
      Name = "CustomerContact";

      Field(i => i.Id).Description("The identity of the customer");
      Field(i => i.PersonalNumber).Description("The personal number of the customer");
      Field(i => i.Email).Description("The email address of the customer");
      Field(i => i.Street).Description("The street address of the customer");
      Field(i => i.ZipCode).Description("The zip code of the customer");
      Field(i => i.Country).Description("The country of the customer");
      Field(i => i.PhoneNumber).Description("The phone number of the customer");
    }
  }
}