using Insurance.Application.Common.Models;
using Insurance.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Insurance.Application.Insurance.EventHandlers
{
    public class CalculateInsuranceCompletedEventHandler : INotificationHandler<DomainEventNotification<CalculateInsuranceCompletedEvent>>
    {
        private readonly ILogger<CalculateInsuranceCompletedEventHandler> _logger;

        public CalculateInsuranceCompletedEventHandler(ILogger<CalculateInsuranceCompletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<CalculateInsuranceCompletedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Insurance Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
