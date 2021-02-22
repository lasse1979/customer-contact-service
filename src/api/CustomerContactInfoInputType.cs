using CustomerContact.Api.Model;
using GraphQL.Types;

namespace CustomerContact.Api
{
    public class CustomerContactInfoInputType : InputObjectGraphType<CustomerContactInfo>
    {
        public CustomerContactInfoInputType()
        {
            Name = "CustomerContactInfoInput";
            Field(x => x.PersonalNumber);
            Field(x => x.Email);
            Field(x => x.Address);
            Field(x => x.PhoneNumber);
        }
    }
}