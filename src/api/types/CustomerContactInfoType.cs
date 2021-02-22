using CustomerContact.Api.Model;
using GraphQL.Types;

namespace CustomerContact.Api.Types
{
  public class CustomerContactInfoType : ObjectGraphType<CustomerContactInfo>
  {
    public CustomerContactInfoType(CustomerContactData data)
    {
      Name = "CustomerContactInfo";

      Field(i => i.Id).Description("The identity of the customer");
      Field(i => i.PersonalNumber).Description("The personal number of the customer");
      Field(i => i.Email).Description("The email address of the customer");
      Field(i => i.Address).Description("The address of the customer");
      Field(i => i.PhoneNumber).Description("The phone number of the customer");
    }
  }
}