using PsychologyApp.Domain.Notifications;

namespace PsychologyApp.Domain.Tests.Notifications;

public sealed class ChatReminderPolicyTests
{
    [Theory]
    [InlineData(false, false, false)]
    [InlineData(false, true, false)]
    [InlineData(true, false, false)]
    [InlineData(true, true, true)]
    public void ShouldSchedule_RequiresRemindersAndCompletedOnboarding(
        bool remindersEnabled,
        bool hasCompletedOnboarding,
        bool expected)
    {
        Assert.Equal(expected, ChatReminderPolicy.ShouldSchedule(remindersEnabled, hasCompletedOnboarding));
    }

    [Theory]
    [InlineData(false, true)]
    [InlineData(true, false)]
    public void ResolveNextFireLocal_ReturnsNullWhenSchedulingIsNotAllowed(
        bool remindersEnabled,
        bool hasCompletedOnboarding)
    {
        DateTime nowLocal = new(2026, 1, 10, 11, 30, 0, DateTimeKind.Local);

        DateTime? nextFire = ChatReminderPolicy.ResolveNextFireLocal(
            remindersEnabled,
            hasCompletedOnboarding,
            lastChatActivityUtc: null,
            reminderHour: 8,
            nowLocal);

        Assert.Null(nextFire);
    }

    [Fact]
    public void ResolveNextFireLocal_UsesThreeDaysAfterLastChatAtTheChosenHour()
    {
        DateTime lastActivityLocal = new(2026, 1, 10, 12, 30, 0, DateTimeKind.Local);
        DateTime nowLocal = new(2026, 1, 12, 9, 0, 0, DateTimeKind.Local);

        DateTime? nextFire = ChatReminderPolicy.ResolveNextFireLocal(
            remindersEnabled: true,
            hasCompletedOnboarding: true,
            lastActivityLocal.ToUniversalTime(),
            reminderHour: 8,
            nowLocal);

        Assert.Equal(new DateTime(2026, 1, 13, 8, 0, 0, DateTimeKind.Local), nextFire);
    }

    [Fact]
    public void ResolveNextFireLocal_UsesNowWhenThereIsNoChatActivity()
    {
        DateTime nowLocal = new(2026, 1, 10, 11, 30, 0, DateTimeKind.Local);

        DateTime? nextFire = ChatReminderPolicy.ResolveNextFireLocal(
            remindersEnabled: true,
            hasCompletedOnboarding: true,
            lastChatActivityUtc: null,
            reminderHour: 8,
            nowLocal);

        Assert.Equal(new DateTime(2026, 1, 13, 8, 0, 0, DateTimeKind.Local), nextFire);
    }

    [Theory]
    [InlineData(-2, QuoteReminderPolicy.MinHour)]
    [InlineData(24, QuoteReminderPolicy.MaxHour)]
    public void ResolveNextFireLocal_ClampsTheReminderHour(int requestedHour, int expectedHour)
    {
        DateTime nowLocal = new(2026, 1, 10, 11, 30, 0, DateTimeKind.Local);

        DateTime? nextFire = ChatReminderPolicy.ResolveNextFireLocal(
            remindersEnabled: true,
            hasCompletedOnboarding: true,
            lastChatActivityUtc: null,
            requestedHour,
            nowLocal);

        Assert.Equal(new DateTime(2026, 1, 13, expectedHour, 0, 0, DateTimeKind.Local), nextFire);
    }
}
