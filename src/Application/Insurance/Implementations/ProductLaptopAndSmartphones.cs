using System;
using Insurance.Application.Common.Interfaces;
using Insurance.Domain.Entities;

namespace Insurance.Application.Insurance.Implementations
{
    class ProductLaptopAndSmartphones : IProductInsurance
    {
        public float CalculateInsurance(InsuranceDto insuranceDto)
        {
            if (insuranceDto.SalesPrice > 500 && (insuranceDto.ProductTypeName == "Laptops" || insuranceDto.ProductTypeName == "Smartphones"))
                if (insuranceDto.ProductTypeHasInsurance)
                    return insuranceDto.InsuranceValue += 500;
            return 0;
        }
    }
}