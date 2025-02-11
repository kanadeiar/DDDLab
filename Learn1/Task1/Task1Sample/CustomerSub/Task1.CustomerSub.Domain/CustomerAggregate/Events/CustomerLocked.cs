using Task1.CustomerSub.Domain.Base;
using Task1.CustomerSub.Domain.CustomerAggregate.Values;

namespace Task1.CustomerSub.Domain.CustomerAggregate.Events;

public class CustomerLocked(CustomerId id, string reason) : DomainEvent
{
}