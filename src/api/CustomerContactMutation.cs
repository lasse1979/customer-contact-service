using System;
using CustomerContact.Api.Types;
using CustomerContact.Domain.Repository;
using CustomerContact.Domain.Rules;
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
          try
          {
            var entity = context.GetArgument<Domain.Entity.CustomerContact>("customerContact");
            
            // Validate business rules
            entity.ValidateAndThrow();
            
            return repository.Add(entity).GetAwaiter().GetResult();
          }
          catch (Exception e)
          {
            context.Errors.Add(new ExecutionError($"Creating customer contact failed: {e.Message}"));
            return null;
          }
        });

      Field<CustomerContactType>(
        "updateCustomerContact",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<NewCustomerContactInputType>> { Name = "customerContact" },
          new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "identity of the customer" }
        ),
        resolve: context =>
        {
          try
          {
            var entity = context.GetArgument<Domain.Entity.CustomerContact>("customerContact");
            
            // Validate business rules
            entity.ValidateAndThrow();

            return repository.Update(
              entity,
              context.GetArgument<Guid>("id"))
              .GetAwaiter()
              .GetResult();
          }
          catch (Exception e)
          {
            context.Errors.Add(new ExecutionError($"Updating customer contact failed: {e.Message}"));
            return null;
          }
        });

      Field<StringGraphType>(
        "deleteCustomerContact",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "identity of the customer" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<Guid>("id");
          try
          {
            var customerContact = repository.GetById(id).GetAwaiter().GetResult();
            if (customerContact == null)
            {
              context.Errors.Add(new ExecutionError("Unable to find customer contact in db."));
              return null;
            }

            repository.Delete(id).GetAwaiter().GetResult();
            return $"Customer contact with id {id} has been deleted.";
          }
          catch (Exception e)
          {
            context.Errors.Add(new ExecutionError($"Deleting customer contact failed: {e.Message}"));
            return null;
          }
        });
    }
  }
}