using System.Linq;

namespace CustomerContact.Hr
{
  public sealed class Api
  {
    public static bool IsPersonalNumberValid(string personalNumber)
    {
      return personalNumber.All(char.IsDigit) && (personalNumber.Length == 10 || personalNumber.Length == 12);
    }

    public static void NotifyCustomerContactChanged(Domain.Entity.CustomerContact entity)
    {
      // Do nothing
    }
  }
}