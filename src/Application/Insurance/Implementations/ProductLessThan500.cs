using Insurance.Application.Common.Interfaces;
using Insurance.Domain.Entities;

namespace Insurance.Application.Insurance.Implementations
{
    public class ProductLessThan500 : IProductInsurance
    {
        public float CalculateInsurance(InsuranceDto insuranceDto)
        {
            if (insuranceDto.ProductTypeHasInsurance && insuranceDto.SalesPrice < 500)
                    return insuranceDto.InsuranceValue = 0;
            return 0;
        }
    }
}
