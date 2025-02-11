using Task1.CustomerSub.Domain.Abstractions;
using Task1.CustomerSub.Domain.CustomerAggregate.Events;
using Task1.CustomerSub.Domain.CustomerAggregate.Values;

namespace Task1.CustomerSub.Domain.CustomerAggregate;

public class CustomerState
{
    public CustomerId Id { get; private set; }
}

public class Customer
{
    private readonly CustomerState _state = new();

    public bool ConsumptionLocked { get; private set; }

    public bool ManualBilling { get; set; }
    
    public Customer(IEnumerable<IEvent> events)
    {
        foreach (var ev in events)
        {
            Mutate(ev);
        }
    }

    public void Mutate(IEvent ev)
    {
        ((dynamic)this).When((dynamic)ev);
    }

    public void Apply(IEvent ev)
    {
        Changes.Add(ev);
        Mutate(ev);
    }

    public void When(CustomerLocked e)
    {
        ConsumptionLocked = true;
    }

    public void When(CustomerUnlocked e)
    {
        ConsumptionLocked = true;
    }

    public List<IEvent> Changes = new();

    public void LockForAccountOverdraft(string comment, IPricingService pricingService)
    {
        if (!ManualBilling)
        {
            LockCustomer("Overdraft: " + comment);
        }
    }

    public void LockCustomer(string reason)
    {
        if (!ConsumptionLocked)
        {
            Apply(new CustomerLocked(_state.Id, reason));
        }
    }
}