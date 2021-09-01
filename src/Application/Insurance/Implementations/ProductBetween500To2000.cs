using Insurance.Application.Common.Interfaces;
using Insurance.Domain.Entities;

namespace Insurance.Application.Insurance.Implementations
{
    public class ProductBetween500To2000 : IProductInsurance
    {
        public float CalculateInsurance(InsuranceDto insuranceDto)
        {
            if (insuranceDto.SalesPrice > 500 && insuranceDto.SalesPrice < 2000 && insuranceDto.ProductTypeHasInsurance)
                            return insuranceDto.InsuranceValue += 1000;
                return 0;
        }
    }
}