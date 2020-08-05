using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TaxService.Interfaces
{
    interface IUSCustomer
    {
        Task GetTaxRatesBasedOnUS();

        Task CalculateTaxesForAnUSOrder();
    }
}
