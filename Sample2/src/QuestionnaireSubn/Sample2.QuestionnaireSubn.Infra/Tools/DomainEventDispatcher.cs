﻿using Sample2.QuestionnaireSubn.Contract.EventSourcing.Abstractions;
using Sample2.QuestionnaireSubn.Contract.EventSourcing.Base;

namespace Sample2.QuestionnaireSubn.Infra.Tools;

public class DomainEventDispatcher : IDispatcher
{
    private readonly Lock _lock = new();
    private readonly Dictionary<Type, List<Action<DomainEvent>>> _routes = new();
    private readonly List<DomainEvent> _events = new();

    public void RegisterHandler<T>(Action<T> handler)
        where T : DomainEvent
    {
        lock (_lock)
        {
            if (!_routes.TryGetValue(typeof(T), out var handlers))
            {
                handlers = new List<Action<DomainEvent>>();
                _routes.Add(typeof(T), handlers);
            }

            handlers.Add(message => handler((T)message));
        }
    }

    public void Dispatch(IEnumerable<DomainEvent> events)
    {
        lock (_lock)
        {
            _events.AddRange(events);
        }
    }

    public void Run()
    {
        Task.Run(async () =>
        {
            while (true)
            {
                lock (_lock)
                {
                    try
                    {
                        if (_events.Any())
                        {
                            foreach (var each in _events)
                            {
                                if (!_routes.TryGetValue(each.GetType(), out var handlers)) return;

                                Array.ForEach(handlers.ToArray(), action => action.Invoke(each));
                            }

                            _events.Clear();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }

                await Task.Delay(10);
            }
        });
    }
}