using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerContact.Domain.Repository;
using Dapper;

namespace CustomerContact.Infrastructure.Persistence
{
  public class CustomerContactRepository : BaseRepository, ICustomerContactRepository
  {
    private readonly ICustomerContactCommand command;
    public CustomerContactRepository(ICustomerContactCommand command)
    {
      this.command = command;
    }

    public async ValueTask<Domain.Entity.CustomerContact> Add(Domain.Entity.CustomerContact entity)
    {
      return await WithConnection(async conn =>
      {
        entity.SetNewId();

        await conn.ExecuteAsync(command.Add,
            new
            {
              Id = entity.Id,
              PersonalNumber = entity.PersonalNumber,
              Email = entity.Email,
              Street = entity.Street,
              ZipCode = entity.ZipCode,
              Country = entity.Country,
              PhoneNumber = entity.PhoneNumber
            });

        return await GetById(entity.Id);
      });
    }

    public async Task Delete(Guid id)
    {
      await WithConnection(async conn =>
      {
        await conn.ExecuteAsync(command.Delete, new { Id = id });
      });
    }

    public async Task<IEnumerable<Domain.Entity.CustomerContact>> GetAll()
    {
      return await WithConnection(async conn =>
      {
        var query = await conn.QueryAsync<Domain.Entity.CustomerContact>(command.GetAll);
        return query;
      });
    }

    public async ValueTask<Domain.Entity.CustomerContact> GetById(Guid id)
    {
      return await WithConnection(async conn =>
      {
        var query = await conn.QueryFirstOrDefaultAsync<Domain.Entity.CustomerContact>(command.GetById, new { Id = id });
        return query;
      });
    }

    public async ValueTask<Domain.Entity.CustomerContact> Update(Domain.Entity.CustomerContact entity, Guid id)
    {
      await WithConnection(async conn =>
      {
        await conn.ExecuteAsync(command.Update,
        new
        {
          PersonalNumber = entity.PersonalNumber,
          Email = entity.Email,
          Street = entity.Street,
          ZipCode = entity.ZipCode,
          Country = entity.Country,
          PhoneNumber = entity.PhoneNumber,
          Id = id
        });
      });
        
      return await GetById(id);
    }
  }
}
