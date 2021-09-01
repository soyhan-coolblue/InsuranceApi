using Insurance.Domain.Common;
using Insurance.Domain.Entities;

namespace Insurance.Domain.Events
{
    public class CalculateInsuranceCreatedEvent : DomainEvent
    {
        public CalculateInsuranceCreatedEvent(InsuranceDto item)
        {
            Item = item;
        }

        public InsuranceDto Item { get; }
    }
}
