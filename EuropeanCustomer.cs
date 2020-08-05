using System;
using System.Collections.Generic;
using System.Text;
using TaxService.Interfaces;
using System.Threading.Tasks;

namespace TaxService
{
    class EuropeanCustomer:IEuropeanCustomer
    {
        public async Task GetTaxRatesBasedOnEurope()
        {
            //Specific code based for European customers
        }

        public async Task CalculateTaxesForAnOrderFromEurope()
        {
            //Specific code based for European customers
        }
    }
}
