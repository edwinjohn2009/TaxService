using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TaxService
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
            USCustomer calculateRates = new USCustomer();
            await calculateRates.GetTaxRatesBasedOnUS();
            await calculateRates.CalculateTaxesForAnUSOrder();
            Console.ReadLine();
        }
    }
}
