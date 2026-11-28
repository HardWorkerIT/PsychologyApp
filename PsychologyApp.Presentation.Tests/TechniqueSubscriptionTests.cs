using System.Runtime.CompilerServices;
using PsychologyApp.Presentation.Features.RunTechniqueSession;
using Xunit;

namespace PsychologyApp.Presentation.Tests;

public sealed class TechniqueSubscriptionTests
{
    [Fact]
    public void Messenger_releases_an_abandoned_subscriber_even_when_its_callback_captures_it()
    {
        WeakReferenceManager<int> messenger = new();
        WeakReference subscriber = SubscribeAndForget(messenger);

        Collect();

        Assert.False(subscriber.IsAlive);
        GC.KeepAlive(messenger);
    }

    [Fact]
    public void A_live_subscriber_receives_updates_until_it_unsubscribes()
    {
        WeakReferenceManager<int> messenger = new();
        Counter subscriber = new();
        Subscribe(messenger, subscriber);
        Collect();

        messenger.Send(3);
        messenger.Unsubscribe(subscriber);
        messenger.Send(5);

        Assert.Equal(3, subscriber.Total);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static WeakReference SubscribeAndForget(WeakReferenceManager<int> messenger)
    {
        Counter subscriber = new();
        Subscribe(messenger, subscriber);
        return new WeakReference(subscriber);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void Subscribe(WeakReferenceManager<int> messenger, Counter subscriber) =>
        messenger.Subscribe(subscriber, value => subscriber.Total += value);

    private static void Collect()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
    }

    private sealed class Counter
    {
        public int Total { get; set; }
    }
}
