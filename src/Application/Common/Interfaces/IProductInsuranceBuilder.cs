using System.Collections.Generic;

namespace Insurance.Application.Common.Interfaces
{
    public interface IProductInsuranceBuilder
    {
        void ApplyBusinessRules();

        List<IProductInsurance> GetBusinessRules();

    }
}
