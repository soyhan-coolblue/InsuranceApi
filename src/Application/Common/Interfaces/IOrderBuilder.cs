using System.Collections.Generic;

namespace Insurance.Application.Common.Interfaces
{
    public interface IOrderBuilder
    {
        void ApplyBusinessRules();

        List<IOrderInsurance> GetBusinessRules();
    }
}
