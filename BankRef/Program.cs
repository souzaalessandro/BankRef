using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankRef.Infrastruture;

namespace BankRef
{
    class Program
    {
        static void Main(string[] args)
        {

            var urlApplication = new string[]{"http://localhost:5341/"};
            var webApp = new WepAppication(urlApplication);
            webApp.Initiallize();


        }
    }
}
