using System;
using System.Net.Http;
using Insurance.Domain.Entities;
using Newtonsoft.Json;

namespace Insurance.Application
{
    public static class BusinessRules
    {
        public static void GetProductType(string baseAddress, int productID, ref InsuranceDto insurance)
        {
            #pragma warning disable IDE0090 // Use 'new(...)'
            HttpClient client = new HttpClient{ BaseAddress = new Uri(baseAddress)};
            #pragma warning restore IDE0090 // Use 'new(...)'
            string json = client.GetAsync("/product_types").Result.Content.ReadAsStringAsync().Result;
            var collection = JsonConvert.DeserializeObject<dynamic>(json);

            json = client.GetAsync(string.Format("/products/{0:G}", productID)).Result.Content.ReadAsStringAsync().Result;
            var product = JsonConvert.DeserializeObject<dynamic>(json);

            int productTypeId = product.productTypeId;
            #pragma warning disable CS0219 // Variable is assigned but its value is never used
            #pragma warning disable IDE0059 // Unnecessary assignment of a value
            string productTypeName = null;
            #pragma warning restore IDE0059 // Unnecessary assignment of a value
            #pragma warning restore CS0219 // Variable is assigned but its value is never used
            #pragma warning disable CS0219 // Variable is assigned but its value is never used
            #pragma warning disable IDE0059 // Unnecessary assignment of a value
            bool hasInsurance = false;
            #pragma warning restore IDE0059 // Unnecessary assignment of a value
            #pragma warning restore CS0219 // Variable is assigned but its value is never used

            insurance = new InsuranceDto();

            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i].id == productTypeId && collection[i].canBeInsured == true)
                {
                    insurance.ProductTypeName = collection[i].name;
                    insurance.ProductTypeHasInsurance = true;
                }
            }
        }

        public static void GetSalesPrice(string baseAddress, int productID, ref InsuranceDto insurance)
        {
#pragma warning disable IDE0090 // Use 'new(...)'
            HttpClient client = new HttpClient{ BaseAddress = new Uri(baseAddress)};
#pragma warning restore IDE0090 // Use 'new(...)'
            string json = client.GetAsync(string.Format("/products/{0:G}", productID)).Result.Content.ReadAsStringAsync().Result;
            var product = JsonConvert.DeserializeObject<dynamic>(json);

            insurance.SalesPrice = product.salesPrice;
        }
    }
}