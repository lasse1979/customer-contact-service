using System;
using System.Linq;
using System.Net.Mail;

namespace CustomerContact.Domain.Rules
{
  public static class CustomerContactValidationExtensions
  {
    public static void ValidateAndThrow(this Entity.CustomerContact self)
    {
      if (!Hr.Api.IsPersonalNumberValid(self.PersonalNumber))
      {
        throw new Exception("Invalid personal number");
      }

      if (!IsEmailValid(self.Email))
      {
        throw new Exception("Invalid email address");
      }
      
      if (!IsCountryValid(self.Country))
      {
        throw new Exception("Invalid country");
      }
      
      if (!IsZipCodeValid(self.ZipCode))
      {
        throw new Exception("Invalid zip code");
      }

      if (!IsPhoneNumberValid(self.PhoneNumber, self.Country))
      {
        throw new Exception("Invalid phone number");
      }
    }

    private static bool IsEmailValid(string email)
    {
      try
      {
        var m = new MailAddress(email);
        return true;
      }
      catch (FormatException)
      {
        return false;
      }
    }

    private static bool IsCountryValid(string country)
    {
      if (new [] {"sweden", "denmark", "norway", "finland"}.Contains(country.ToLower()))
      {
        return true;   
      }

      return false;
    }

    private static bool IsZipCodeValid(int zipCode)
    {
      return zipCode >= 1000 && zipCode < 100000;
    }

    private static bool IsPhoneNumberValid(string phoneNumber, string country)
    {
      if (phoneNumber.Length < 8 || phoneNumber.Length > 15)
      {
        return false;
      }

      var c = country.ToLower();

      if (c == "sweden" && !(phoneNumber.StartsWith("0") || phoneNumber.StartsWith("+46")))
      {
        return false;
      }
      else if (c == "denmark" && !phoneNumber.StartsWith("+45"))
      {
        return false;
      }
      else if (c == "norway" && !phoneNumber.StartsWith("+47"))
      {
        return false;
      }
      else if (c == "finland" && !phoneNumber.StartsWith("+358"))
      {
        return false;
      }

      if (!phoneNumber.Skip(1).All(Char.IsDigit))
      {
        return false;
      }

      return true;
    }
    
  }
}