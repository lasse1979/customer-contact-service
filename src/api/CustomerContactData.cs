using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerContact.Api.Model;

namespace CustomerContact.Api
{
  public class CustomerContactData
  {
    private readonly List<CustomerContactInfo> data = new List<CustomerContactInfo>();
    public CustomerContactData()
    {
      data.Add(new CustomerContactInfo
      {
        Id = Guid.NewGuid().ToString(),
        PersonalNumber = "7906228536",
        Email = "lars@ecorp.com",
        Address = "Smedtorpsvägen 41A",
        PhoneNumber = "55512345",
      });
    }

    public Task<CustomerContactInfo> GetCustomerContactInfoByIdAsync(string id)
    {
      return Task.FromResult(data.FirstOrDefault(data => data.Id == id));
    }

    public CustomerContactInfo AddCustomerContactInfo(CustomerContactInfo info)
    {
      info.Id = Guid.NewGuid().ToString();
      data.Add(info);
      return info;

    }
  }
}