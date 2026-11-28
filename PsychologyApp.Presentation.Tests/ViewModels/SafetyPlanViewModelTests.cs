using Microsoft.Maui.ApplicationModel;
using Moq;
using PsychologyApp.Application.ClinicalCare;
using PsychologyApp.Application.Models;
using PsychologyApp.Presentation.Pages.ClinicalCare.SafetyPlan;
using PsychologyApp.Presentation.Shared.Services.Clipboard;
using PsychologyApp.Presentation.Shared.Services.Dialogs;
using PsychologyApp.Presentation.Shared.UI.Overlays;
using Xunit;

namespace PsychologyApp.Presentation.Tests.ViewModels;

/// <summary>The safety plan is written by the person for a bad moment; losing or mangling an entry would be worse than any crash.</summary>
[Collection("StaticShims")]
public sealed class SafetyPlanViewModelTests
{
    private readonly Mock<INavigationService> _navigation = new();
    private readonly Mock<IClinicalCareService> _care = new();
    private readonly Mock<IDialogService> _dialogs = new();
    private readonly Mock<IAppClipboardService> _clipboard = new();
    private readonly List<SafetyPlanDTO> _saved = [];

    public SafetyPlanViewModelTests()
    {
        Launcher.Opened.Clear();
        Launcher.FailWith = null;
        _navigation.Setup(n => n.GoBackAsync()).Returns(Task.CompletedTask);
        _care.Setup(c => c.SaveSafetyPlanAsync(It.IsAny<SafetyPlanDTO>(), It.IsAny<CancellationToken>()))
            .Callback<SafetyPlanDTO, CancellationToken>((plan, _) => _saved.Add(plan))
            .Returns(Task.CompletedTask);
    }

    private async Task<SafetyPlanViewModel> CreateAsync(SafetyPlanDTO? plan = null)
    {
        _care.Setup(c => c.GetSafetyPlanAsync(It.IsAny<CancellationToken>())).ReturnsAsync(plan ?? new SafetyPlanDTO());
        SafetyPlanViewModel viewModel = new(_navigation.Object, _care.Object, _dialogs.Object, _clipboard.Object);
        await VmTestHelpers.WaitUntilAsync(() => _care.Invocations.Any(i => i.Method.Name == nameof(IClinicalCareService.GetSafetyPlanAsync)));
        await Task.Delay(30);
        return viewModel;
    }

    [Fact]
    public async Task AFailedReadOffersRetryBeforeDisplayingContacts()
    {
        var initialRead = new TaskCompletionSource<SafetyPlanDTO>(TaskCreationOptions.RunContinuationsAsynchronously);
        _care.SetupSequence(c => c.GetSafetyPlanAsync(It.IsAny<CancellationToken>()))
            .Returns(initialRead.Task)
            .ReturnsAsync(new SafetyPlanDTO { Contacts = [new SafetyPlanContactDTO { Name = "Anna", Phone = "1" }] });
        SafetyPlanViewModel viewModel = new(_navigation.Object, _care.Object, _dialogs.Object, _clipboard.Object);
        Assert.True(viewModel.IsPlanLoading);
        Assert.False(viewModel.IsPlanReady);

        initialRead.SetException(new IOException("Plan unreadable"));
        await VmTestHelpers.WaitUntilAsync(() => viewModel.IsPlanLoadFailed);
        Assert.False(viewModel.IsPlanReady);

        await VmTestHelpers.RunAsync(viewModel.RetryLoadCommand);
        Assert.True(viewModel.IsPlanReady);
        Assert.Equal("Anna", Assert.Single(viewModel.Contacts).Name);
    }

    [Fact]
    public async Task TheSavedPlanIsShownWhenTheScreenOpens()
    {
        SafetyPlanViewModel viewModel = await CreateAsync(new SafetyPlanDTO
        {
            WarningSigns = ["can't sleep"],
            CopingStrategies = ["walk", "tea"],
            Reasons = ["my dog"],
            Contacts = [new SafetyPlanContactDTO { Name = "Anna", Phone = "+7 900" }]
        });

        Assert.Equal(["can't sleep"], viewModel.WarningSigns.Select(i => i.Text));
        Assert.Equal(["walk", "tea"], viewModel.CopingStrategies.Select(i => i.Text));
        Assert.Equal(["my dog"], viewModel.Reasons.Select(i => i.Text));
        Assert.Equal("Anna", Assert.Single(viewModel.Contacts).Name);
    }

    [Fact]
    public async Task AnEditWhileLoadingPreservesTheSavedPlan()
    {
        TaskCompletionSource<SafetyPlanDTO> load = new(TaskCreationOptions.RunContinuationsAsynchronously);
        _care.Setup(c => c.GetSafetyPlanAsync(It.IsAny<CancellationToken>())).Returns(load.Task);
        SafetyPlanViewModel viewModel = new(_navigation.Object, _care.Object, _dialogs.Object, _clipboard.Object)
        {
            NewCopingStrategyText = "call a friend"
        };

        viewModel.AddCopingStrategyCommand.Execute(null);
        load.SetResult(new SafetyPlanDTO { Reasons = ["family"] });
        await VmTestHelpers.WaitUntilAsync(() => viewModel.AddCopingStrategyCommand.CanExecute(null));

        SafetyPlanDTO saved = Assert.Single(_saved);
        Assert.Equal(["family"], saved.Reasons);
        Assert.Equal(["call a friend"], saved.CopingStrategies);
    }

    [Fact]
    public async Task FailedWritesKeepTheContactAndTheUnsentDraft()
    {
        SafetyPlanViewModel viewModel = await CreateAsync(new SafetyPlanDTO
        {
            Contacts = [new SafetyPlanContactDTO { Name = "Anna", Phone = "100" }]
        });
        _care.Setup(c => c.SaveSafetyPlanAsync(It.IsAny<SafetyPlanDTO>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new IOException("Could not write the plan."));
        viewModel.NewWarningSignText = "a draft";

        await VmTestHelpers.RunAsync(viewModel.Contacts[0].DeleteCommand);
        await VmTestHelpers.RunAsync(viewModel.AddWarningSignCommand);

        Assert.Equal("Anna", Assert.Single(viewModel.Contacts).Name);
        Assert.Empty(viewModel.WarningSigns);
        Assert.Equal("a draft", viewModel.NewWarningSignText);
    }

    [Fact]
    public async Task AddingAnEntryTrimsItClearsTheFieldAndSavesTheWholePlan()
    {
        SafetyPlanViewModel viewModel = await CreateAsync(new SafetyPlanDTO { Reasons = ["family"] });
        viewModel.NewCopingStrategyText = "  call a friend  ";

        await VmTestHelpers.RunAsync(viewModel.AddCopingStrategyCommand);

        Assert.Equal(string.Empty, viewModel.NewCopingStrategyText);
        SafetyPlanDTO saved = Assert.Single(_saved);
        Assert.Equal(["call a friend"], saved.CopingStrategies);
        Assert.Equal(["family"], saved.Reasons);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ABlankEntryIsIgnoredAndNothingIsSaved(string text)
    {
        SafetyPlanViewModel viewModel = await CreateAsync();
        viewModel.NewWarningSignText = text;

        await VmTestHelpers.RunAsync(viewModel.AddWarningSignCommand);

        Assert.Empty(viewModel.WarningSigns);
        Assert.Empty(_saved);
    }

    [Fact]
    public async Task RemovingAnEntryRemovesOnlyThatEntryAndSaves()
    {
        SafetyPlanViewModel viewModel = await CreateAsync(new SafetyPlanDTO { WarningSigns = ["a", "b", "c"] });
        SafetyPlanTextItem middle = viewModel.WarningSigns[1];

        await VmTestHelpers.RunAsync(middle.DeleteCommand);

        Assert.Equal(["a", "c"], viewModel.WarningSigns.Select(i => i.Text));
        Assert.Equal(["a", "c"], Assert.Single(_saved).WarningSigns);
    }

    [Fact]
    public async Task AContactNeedsADiallablePhone()
    {
        SafetyPlanViewModel viewModel = await CreateAsync();

        viewModel.NewContactName = "A friend";
        viewModel.NewContactPhone = "not a phone";
        await VmTestHelpers.RunAsync(viewModel.AddContactCommand);
        Assert.Empty(viewModel.Contacts);
        Assert.Empty(_saved);
        Assert.Equal("A friend", viewModel.NewContactName);
        _dialogs.Verify(dialogs => dialogs.ShowAsync(AppStrings.SafetyPlanContactsTitle, AppStrings.SafetyPlanContactPhoneInvalid), Times.Once);

        viewModel.NewContactPhone = " 112 ";
        await VmTestHelpers.RunAsync(viewModel.AddContactCommand);

        SafetyPlanContactItem contact = Assert.Single(viewModel.Contacts);
        Assert.Equal("112", contact.Phone);
        Assert.Equal(string.Empty, viewModel.NewContactPhone);
        Assert.Equal("112", Assert.Single(Assert.Single(_saved).Contacts).Phone);
    }

    [Fact]
    public async Task TheCallButtonDialsTheContactAndAnEmptyNumberDoesNothing()
    {
        SafetyPlanViewModel viewModel = await CreateAsync(new SafetyPlanDTO
        {
            Contacts = [new SafetyPlanContactDTO { Name = "Anna", Phone = "+7 900" }, new SafetyPlanContactDTO { Name = "No number", Phone = "" }]
        });

        await VmTestHelpers.RunAsync(Assert.IsAssignableFrom<System.Windows.Input.ICommand>(viewModel.Contacts[0].CallCommand));
        Assert.False(viewModel.Contacts[1].CanCall);
        Assert.Null(viewModel.Contacts[1].CallCommand);

        Assert.Equal(["tel:+7 900"], Launcher.Opened);
    }

    [Fact]
    public async Task ADialIntentThatFailsOffersToCopyTheContactNumber()
    {
        SafetyPlanViewModel viewModel = await CreateAsync(new SafetyPlanDTO { Contacts = [new SafetyPlanContactDTO { Name = "Anna", Phone = "1" }] });
        Launcher.FailWith = new InvalidOperationException("no dialer");

        _dialogs.Setup(dialogs => dialogs.AskAsync(null, AppStrings.CrisisDialUnavailable("1"), AppStrings.DonateCopyNumber, AppStrings.Cancel))
            .ReturnsAsync(true);
        try
        {
            await VmTestHelpers.RunAsync(Assert.IsAssignableFrom<System.Windows.Input.ICommand>(viewModel.Contacts[0].CallCommand));

            _clipboard.Verify(service => service.CopyWithFeedbackAsync("1", AppStrings.QuoteCopied, AppToastKind.Success), Times.Once);
        }
        finally
        {
            Launcher.FailWith = null;
        }
    }
}
