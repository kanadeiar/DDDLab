using Simple.InventorySubn.Contract.Abstractions;
using Simple.InventorySubn.Contract.Base;
using Simple.InventorySubn.Domain.Abstractions;

namespace Simple.InventorySubn.Infra.Bus;

public class FakeBus : ICommandSender, IEventPublisher
{
    private readonly Lock _lock = new();
    private readonly Dictionary<Type, List<Action<IMessage>>> _routes = new();

    public void RegisterHandler<T>(Action<T> handler) 
        where T : IMessage
    {
        if (!_routes.TryGetValue(typeof(T), out var handlers))
        {
            handlers = new List<Action<IMessage>>();
            _routes.Add(typeof(T), handlers);
        }

        handlers.Add(message => handler((T)message));
    }

    public void Send<T>(T command) 
        where T : Command
    {
        if (_routes.TryGetValue(typeof(T), out var handlers))
        {
            if (handlers.Count != 1) throw new InvalidOperationException("Нельзя послать более чем одному обработчику команды типа " + typeof(T));
            handlers.First()(command);
        }
        else
        {
            throw new InvalidOperationException("Не зарегистрирован ни один обработчик команды типа " + typeof(T));
        }
    }

    public void Publish<T>(T @event) 
        where T : Event
    {
        if (!_routes.TryGetValue(@event.GetType(), out var handlers)) return;

        foreach (var each in handlers)
        {
            var local = each;
            Task.Run(() =>
            {
                try
                {
                    lock (_lock)
                    {
                        local(@event);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        }
    }
}