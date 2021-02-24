using GraphQL.Types;

namespace CustomerContact.Api
{
    public class NewCustomerContactInputType : InputObjectGraphType<Domain.Entity.CustomerContact>
    {
        public NewCustomerContactInputType()
        {
            Name = "NewCustomerContact";
            Field(x => x.PersonalNumber);
            Field(x => x.Email);
            Field(x => x.Street);
            Field(x => x.ZipCode);
            Field(x => x.Country);
            Field(x => x.PhoneNumber);
        }
    }
}