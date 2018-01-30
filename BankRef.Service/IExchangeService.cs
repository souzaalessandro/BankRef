// 
namespace BankRef.Service
{
    public interface IExchangeService
    {

        decimal Calculate(string currencyOrigin, string currencyDestination, decimal currencyValue);

    }
}