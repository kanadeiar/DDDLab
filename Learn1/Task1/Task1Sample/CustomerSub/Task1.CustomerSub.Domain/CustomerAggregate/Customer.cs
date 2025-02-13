using Task1.CustomerSub.Domain.Abstractions;
using Task1.CustomerSub.Domain.CustomerAggregate.Events;
using Task1.CustomerSub.Domain.CustomerAggregate.State;

namespace Task1.CustomerSub.Domain.CustomerAggregate;

public class Customer
{
    private readonly CustomerState _state = new();
    
    public Customer(IEnumerable<IEvent> events)
    {
        foreach (var ev in events)
        {
            _state.Apply(ev);
        }
    }

    public void Apply(IEvent ev)
    {
        Changes.Add(ev);
        _state.Apply(ev);
    }

    public List<IEvent> Changes = new();

    public void LockForAccountOverdraft(string comment, IPricingService pricingService)
    {
        if (!_state.ManualBilling)
        {
            LockCustomer("Overdraft: " + comment);
        }
    }

    public void LockCustomer(string reason)
    {
        if (!_state.ConsumptionLocked)
        {
            Apply(new CustomerLocked(_state.Id, reason));
        }
    }
}