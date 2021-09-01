using Insurance.Domain.Common;
using System.Threading.Tasks;

namespace Insurance.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
