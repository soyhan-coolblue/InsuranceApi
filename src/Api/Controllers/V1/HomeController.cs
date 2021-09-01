using Insurance.Application;
using Insurance.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Api.Controllers
{

    [ApiVersion("1", Deprecated = true)]
    [Route("api/v{version:apiVersion}/insurance")]
    public class HomeController: ApiControllerBase
    {
        [HttpPost]
        [Route("api/insurance/product")]
        public InsuranceDto CalculateInsurance([FromBody] InsuranceDto toInsure)
        {
            int productId = toInsure.ProductId;

            BusinessRules.GetProductType(ProductApi, productId, ref toInsure);
            BusinessRules.GetSalesPrice(ProductApi, productId, ref toInsure);

#pragma warning disable CS0219 // Variable is assigned but its value is never used
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            float insurance = 0f;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
#pragma warning restore CS0219 // Variable is assigned but its value is never used

            if (toInsure.SalesPrice < 500)
                toInsure.InsuranceValue = 0;
            else
            {
                if (toInsure.SalesPrice > 500 && toInsure.SalesPrice < 2000)
                    if (toInsure.ProductTypeHasInsurance)
                        toInsure.InsuranceValue += 1000;
                if (toInsure.SalesPrice >= 2000)
                    if (toInsure.ProductTypeHasInsurance)
                        toInsure.InsuranceValue += 2000;
                if (toInsure.ProductTypeName == "Laptops" || toInsure.ProductTypeName == "Smartphones" && toInsure.ProductTypeHasInsurance)
                    toInsure.InsuranceValue += 500;
            }

            return toInsure;
        }

        private const string ProductApi = "http://localhost:5002";
    }
}