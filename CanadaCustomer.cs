using System;
using System.Collections.Generic;
using System.Text;
using TaxService.Interfaces;
using System.Threading.Tasks;

namespace TaxService
{
    class CanadaCustomer:ICanadaCustomer
    {
        public async Task GetTaxRatesBasedOnCanada()
        {
            //Specific code based for Canadian customers
        }

        public async Task CalculateTaxesForAnOrderFromCanada()
        {
            //Specific code based for Canadian customers
        }
    }
}
