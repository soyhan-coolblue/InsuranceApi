using Insurance.Application.Common.Models;
using Insurance.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Insurance.Application.Insurance.EventHandlers
{
    public class CalculateInsuranceCreatedEventHandler : INotificationHandler<DomainEventNotification<CalculateInsuranceCreatedEvent>>
    {
        private readonly ILogger<CalculateInsuranceCreatedEventHandler> _logger;

        public CalculateInsuranceCreatedEventHandler(ILogger<CalculateInsuranceCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<CalculateInsuranceCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Insurance Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
