using System;
using GraphQL.Types;
using GraphQL.Utilities;

namespace CustomerContact.Api
{

  public class CustomerContactSchema : Schema
  {
    public CustomerContactSchema(IServiceProvider provider)
    : base(provider)
    {
      Query = provider.GetRequiredService<CustomerContactQuery>();
      Mutation = provider.GetRequiredService<CustomerContactMutation>();
    }

  }
}