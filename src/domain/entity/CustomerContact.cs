using System;

namespace CustomerContact.Domain.Entity
{
  public class CustomerContact
  {
    public Guid Id { get; set; }
    public string PersonalNumber { get; set; }
    public string Email { get; set; }
    public string Street { get; set; }
    public int ZipCode { get; set; }
    public string Country { get; set; }
    public string PhoneNumber { get; set; }
    
    public void SetNewId()
    {
      Id = Guid.NewGuid();
    }
  }

}