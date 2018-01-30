// 

using System;

namespace BankRef.Service.Exchange
{
    public class ExchangeTest:IExchangeService
    {
        private readonly Random randomicValue = new Random();

        public decimal Calculate(string currencyOrigin, string currencyDestination, decimal currencyValue)
            => currencyValue*(decimal) randomicValue.NextDouble();
    }
}