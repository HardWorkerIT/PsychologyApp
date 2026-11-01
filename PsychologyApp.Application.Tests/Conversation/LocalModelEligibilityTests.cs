using PsychologyApp.Application.Conversation.Companion;
using Xunit;

namespace PsychologyApp.Application.Tests.Conversation;

public class LocalModelEligibilityTests
{
    private const long Gb = 1024L * 1024 * 1024;

    private sealed record Device(long TotalMemoryBytes, long FreeStorageBytes, long? Available = null) : IDeviceCapabilities
    {
        public long AvailableMemoryBytes => Available ?? TotalMemoryBytes;
    }

    private static readonly LocalModelManifest Manifest = new(
        "m", "M", "x", [new LocalModelFile("a", "https://x/a", 4 * Gb)], ["en"],
        MinTotalMemoryBytes: 7 * Gb, MinAvailableMemoryBytes: 2 * Gb);

    [Fact]
    public void Capable_device_is_eligible() =>
        Assert.Equal(LocalModelEligibility.Eligible, LocalModelEligibilityChecker.Check(Manifest, new Device(8 * Gb, 10 * Gb)));

    [Fact]
    public void Too_little_memory_is_reported_before_storage() =>
        Assert.Equal(LocalModelEligibility.NotEnoughMemory, LocalModelEligibilityChecker.Check(Manifest, new Device(4 * Gb, 0)));

    [Fact]
    public void Unknown_memory_counts_as_not_capable() =>
        Assert.Equal(LocalModelEligibility.NotEnoughMemory, LocalModelEligibilityChecker.Check(Manifest, new Device(0, 100 * Gb)));

    [Fact]
    public void Busy_device_with_low_available_memory_is_not_eligible() =>
        Assert.Equal(LocalModelEligibility.NotEnoughMemory, LocalModelEligibilityChecker.Check(Manifest, new Device(8 * Gb, 100 * Gb, Available: Gb)));

    [Theory]
    [InlineData(4 * Gb)]
    [InlineData(4 * Gb + 200 * 1024 * 1024)]
    public void Storage_must_cover_the_model_with_headroom(long free) =>
        Assert.Equal(LocalModelEligibility.NotEnoughStorage, LocalModelEligibilityChecker.Check(Manifest, new Device(8 * Gb, free)));

    [Fact]
    public void Exactly_enough_storage_with_headroom_is_eligible() =>
        Assert.Equal(LocalModelEligibility.Eligible, LocalModelEligibilityChecker.Check(Manifest, new Device(8 * Gb, (long)(4 * Gb * 1.15) + 1)));

    [Fact]
    public void Atomic_update_requires_space_for_existing_model_and_new_staging_copy() =>
        Assert.Equal(LocalModelEligibility.NotEnoughStorage,
            LocalModelEligibilityChecker.Check(Manifest, new Device(8 * Gb, 7 * Gb), existingModelBytes: 4 * Gb));

    [Fact]
    public void Atomic_update_is_eligible_when_old_model_new_copy_and_headroom_fit() =>
        Assert.Equal(LocalModelEligibility.Eligible,
            LocalModelEligibilityChecker.Check(Manifest, new Device(8 * Gb, 9 * Gb), existingModelBytes: 4 * Gb));
}
