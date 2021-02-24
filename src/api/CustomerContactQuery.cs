using System;
using GraphQL;
using GraphQL.Types;
using CustomerContact.Api.Types;
using CustomerContact.Domain.Repository;

namespace CustomerContact.Api
{
    public class CustomerContactQuery : ObjectGraphType
    {
        public CustomerContactQuery(ICustomerContactRepository repository)
        {
            Name = "Query";

            Field<CustomerContactType>(
                "customerContact",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "identity of the customer" }
                ),
                resolve: context => repository.GetById(context.GetArgument<Guid>("id"))
            );
            
            Field<ListGraphType<CustomerContactType>>(
                "customerContacts",
                resolve: context => repository.GetAll()
            );
        }
    }
}