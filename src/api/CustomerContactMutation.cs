using CustomerContact.Api.Model;
using CustomerContact.Api.Types;
using GraphQL;
using GraphQL.Types;

namespace CustomerContact.Api
{
  /// <example>
  /// This is an example JSON request for a mutation
  /// {
  ///   "query": "mutation ($human:HumanInput!){ createHuman(human: $human) { id name } }",
  ///   "variables": {
  ///     "human": {
  ///       "name": "Boba Fett"
  ///     }
  ///   }
  /// }
  /// </example>
  public class CustomerContactMutation : ObjectGraphType
  {
    public CustomerContactMutation(CustomerContactData data)
    {
      Name = "Mutation";

      Field<CustomerContactInfoType>(
          "createCustomerContact",
          arguments: new QueryArguments(
              new QueryArgument<NonNullGraphType<CustomerContactInfoInputType>> { Name = "NewCustomerContactInfo" }
          ),
          resolve: context =>
          {
            var info = context.GetArgument<CustomerContactInfo>("NewCustomerContactInfo");
            return data.AddCustomerContactInfo(info);
          });
    }
  }
}