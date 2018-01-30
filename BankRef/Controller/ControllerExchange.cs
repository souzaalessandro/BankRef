// 

using System.IO;
using System.Reflection;
using BankRef.Service;
using BankRef.Service.Exchange;

namespace BankRef.Controller
{
    public class ControllerExchange
    {

        private IExchangeService exchangeService;

        public ControllerExchange()
        {
            
            exchangeService = new ExchangeTest();
        }

        public string MXN()
        {
            var valueCurrency = exchangeService.Calculate("MXN", "BRL", 1);
            var resourceName = "BankRef.View.Cambio.MXN.html";
            var assembly = Assembly.GetExecutingAssembly();
            var streamResource = assembly.GetManifestResourceStream(resourceName);
            var streamReader = new StreamReader(streamResource);
            var pageText = streamReader.ReadToEnd();
            var pageResult = pageText.Replace("@VALUE", valueCurrency.ToString());

            return pageResult;
        }

        public string USS()
        {
            return string.Empty;
        }
    }
}