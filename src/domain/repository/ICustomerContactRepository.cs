using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerContact.Domain.Repository
{
  public interface ICustomerContactRepository
  {
    ValueTask<Entity.CustomerContact> GetById(Guid id);
    ValueTask<Entity.CustomerContact> Add(Entity.CustomerContact entity);
    ValueTask<Entity.CustomerContact> Update(Entity.CustomerContact entity, Guid id);
    Task Delete(Guid id);
    Task<IEnumerable<Entity.CustomerContact>> GetAll();
  }
}