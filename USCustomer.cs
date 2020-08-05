using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TaxService.Interfaces;

namespace TaxService
{
    class USCustomer: IUSCustomer
    {
        public static string APIUrl = "https://api.taxjar.com/";
        public static string endpoint = "v2/taxes";
        public async Task GetTaxRatesBasedOnUS()
        {
            using (var httpClient = new HttpClient())
            {
                Console.Write("Enter ZipCode to calculate taxes for an order: ");
                int zipCode = Convert.ToInt32(Console.ReadLine());
                httpClient.BaseAddress = new Uri(APIUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "5da2f821eee4035db4771edab942a4cc");
                HttpResponseMessage response = await httpClient.GetAsync("v2/rates/" + zipCode);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Your response data is: " + jsonString);
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }

        }

        public async Task CalculateTaxesForAnUSOrder()
        {

            
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("to_country", "US"),
                new KeyValuePair<string, string>("shipping", "1.5"),
                new KeyValuePair<string, string>("amount", "50000"),
                new KeyValuePair<string, string>("to_zip", "92093"),
                new KeyValuePair<string, string>("to_state", "CA")
            });


            using (var httpClient = new HttpClient())
            {
                Console.Write("********************************************");
                Console.Write("Calculating the tax rates for a location...");
                httpClient.BaseAddress = new Uri(APIUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new
                    System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "5da2f821eee4035db4771edab942a4cc");
                HttpResponseMessage response = await httpClient.PostAsync(endpoint, content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Your response data is: " + jsonString);
                    }
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }
                else
                {
                    throw new Exception();
                }
            }
        }

    }
}
