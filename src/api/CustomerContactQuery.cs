using System;
using GraphQL;
using GraphQL.Types;
using CustomerContact.Api.Types;

namespace CustomerContact.Api
{
    public class CustomerContactQuery : ObjectGraphType<object>
    {
        public CustomerContactQuery(CustomerContactData data)
        {
            Name = "Query";

            Field<CustomerContactInfoType>(
                "customercontactinfo",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "identity of the customer" }
                ),
                resolve: context => data.GetCustomerContactInfoByIdAsync(context.GetArgument<string>("id"))
            );
        }
    }
}