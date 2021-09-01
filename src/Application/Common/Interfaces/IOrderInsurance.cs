using Insurance.Domain.Entities;
using System.Collections.Generic;

namespace Insurance.Application.Common.Interfaces
{
    public interface IOrderInsurance
    {
        float CalculateInsurance(List<InsuranceDto> insuranceDto);
    }
}
