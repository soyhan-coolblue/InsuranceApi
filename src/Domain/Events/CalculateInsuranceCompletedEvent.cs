using Insurance.Domain.Common;
using Insurance.Domain.Entities;

namespace Insurance.Domain.Events
{
    public class CalculateInsuranceCompletedEvent : DomainEvent
    {
        public CalculateInsuranceCompletedEvent(InsuranceDto item)
        {
            Item = item;
        }

        public InsuranceDto Item { get; }
    }
}
