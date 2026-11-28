using PsychologyApp.Presentation.Shared.Common;
using System.Runtime.CompilerServices;

namespace PsychologyApp.Presentation.Features.RunTechniqueSession;

internal sealed class WeakReferenceManager<TMessage>
{
    // Keep callbacks alive for as long as their owner lives, even if a callback captures that owner.
    private readonly ConditionalWeakTable<object, List<Action<TMessage>>> _subscribers = new();
    private readonly Lock _gate = new();

    public void Subscribe(object subscriber, Action<TMessage> handler)
    {
        ArgumentNullException.ThrowIfNull(subscriber);
        ArgumentNullException.ThrowIfNull(handler);
        lock (_gate)
        {
            _subscribers.GetOrCreateValue(subscriber).Add(handler);
        }
    }

    public void Unsubscribe(object subscriber)
    {
        if (subscriber == null)
            return;

        lock (_gate)
        {
            _subscribers.Remove(subscriber);
        }
    }

    public void Send(TMessage message)
    {
        if (message == null)
            return;

        List<Action<TMessage>> handlers = [];
        lock (_gate)
        {
            foreach (KeyValuePair<object, List<Action<TMessage>>> subscription in _subscribers)
            {
                handlers.AddRange(subscription.Value);
            }
        }

        foreach (Action<TMessage> handler in handlers)
        {
            try
            {
                handler(message);
            }
            catch (Exception error)
            {
                BestEffort.Report(error);
            }
        }
    }
}
