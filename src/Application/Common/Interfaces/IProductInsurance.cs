using Insurance.Domain.Entities;

namespace Insurance.Application.Common.Interfaces
{
    public interface IProductInsurance
    {
        float CalculateInsurance(InsuranceDto insuranceDto);
    }
}
