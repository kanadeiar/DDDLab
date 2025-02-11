using Task1.CustomerSub.Application.Abstractions;
using Task1.CustomerSub.Domain.Abstractions;
using Task1.CustomerSub.Domain.CustomerAggregate;
using Task1.CustomerSub.Domain.CustomerAggregate.Values;

namespace Task1.CustomerSub.Application.CustomerFunction;

#region Дополнительное

public record LockCustomerCommand(CustomerId CustomerId, string Reason);

public record LockCustomer(CustomerId Id, string Reason);

public interface IApplicationService
{
    void Execute(LockCustomerCommand command);
}

#endregion

public class CustomerApplicationService(IEventStore eventStore, IPricingService pricingService) : IApplicationService
{
    #region Дополнительное

    public void When(LockCustomerCommand command)
    {
        var stream = eventStore.LoadEventStream(command.CustomerId);
        var customer = new Customer(stream.Events);

        customer.LockCustomer(command.Reason);
        eventStore.AppendToStream(command.CustomerId, stream.Version, customer.Changes);
    }
    public void Execute(LockCustomerCommand command)
    {
        ((dynamic)this).When((dynamic)command);
    }

    public void When(LockCustomer c)
    {
        Update(c.Id, customer => customer.LockCustomer(c.Reason));
    }
    public void Update(CustomerId customerId, Action<Customer> action)
    {
        var stream = eventStore.LoadEventStream(customerId);
        var customer = new Customer(stream.Events);

        action(customer);
        eventStore.AppendToStream(customerId, stream.Version, customer.Changes);
    }

    #endregion

    public void LockForAccountOverdraft(CustomerId customerId, string comment)
    {
        var stream = eventStore.LoadEventStream(customerId);
        var customer = new Customer(stream.Events);

        customer.LockForAccountOverdraft(comment, pricingService);
        eventStore.AppendToStream(customerId, stream.Version, customer.Changes);
    }

    public void LockCustomer(CustomerId customerId, string reason)
    {
        var stream = eventStore.LoadEventStream(customerId);
        var customer = new Customer(stream.Events);

        customer.LockCustomer(reason);
        eventStore.AppendToStream(customerId, stream.Version, customer.Changes);
    }

    public Customer LoadCustomerById(CustomerId id)
    {
        var stream = eventStore.LoadEventStream(id);
        var customer = new Customer(stream.Events);
        return customer;
    }
}