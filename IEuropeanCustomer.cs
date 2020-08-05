using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaxService.Interfaces
{
    interface IEuropeanCustomer
    {
        Task GetTaxRatesBasedOnEurope();

        Task CalculateTaxesForAnOrderFromEurope();
    }
}
