using System;
using Insurance.Application.Common.Interfaces;
using Insurance.Domain.Entities;

namespace Insurance.Application.Insurance.Implementations
{
    class ProductMoreThan2000 : IProductInsurance
    {
        public float CalculateInsurance(InsuranceDto insuranceDto)
        {
            if (insuranceDto.SalesPrice >= 2000 && insuranceDto.ProductTypeHasInsurance)
                    return insuranceDto.InsuranceValue += 2000;
            return 0;
        }
    }
}
