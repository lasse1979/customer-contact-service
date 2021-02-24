using System;
using CustomerContact.Api.Types;
using CustomerContact.Domain.Repository;
using GraphQL;
using GraphQL.Types;

namespace CustomerContact.Api
{
  public class CustomerContactMutation : ObjectGraphType
  {
    public CustomerContactMutation(ICustomerContactRepository repository)
    {
      Name = "Mutation";

      Field<CustomerContactType>(
          "createCustomerContact",
          arguments: new QueryArguments(
              new QueryArgument<NonNullGraphType<NewCustomerContactInputType>> { Name = "customerContact" }
          ),
          resolve: context => 
          {
            return repository.Add(context.GetArgument<Domain.Entity.CustomerContact>("customerContact")).GetAwaiter().GetResult();
          });
    }
  }
}