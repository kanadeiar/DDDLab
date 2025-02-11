using Task1.CustomerSub.Domain.Abstractions;
using Task1.CustomerSub.Domain.CustomerAggregate.Events;
using Task1.CustomerSub.Domain.CustomerAggregate.Values;

namespace Task1.CustomerSub.Domain.CustomerAggregate.State;

public class CustomerState
{
    public CustomerId Id { get; private set; }

    public bool ConsumptionLocked { get; set; }

    public bool ManualBilling { get; set; }

    public void Apply(IEvent ev)
    {
        Mutate(ev);
    }

    public void Mutate(IEvent ev)
    {
        ((dynamic)this).When((dynamic)ev);
    }

    public void When(CustomerLocked e)
    {
        ConsumptionLocked = true;
    }

    public void When(CustomerUnlocked e)
    {
        ConsumptionLocked = true;
    }
}