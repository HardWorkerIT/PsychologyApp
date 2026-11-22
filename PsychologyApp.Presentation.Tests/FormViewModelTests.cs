using Microsoft.Extensions.Options;
using Moq;
using PsychologyApp.Application.Configuration;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.Services.Dialogs;
using PsychologyApp.Presentation.Features.SendReviewForm;
using Xunit;

namespace PsychologyApp.Presentation.Tests;

public sealed class FormViewModelTests
{
    [Fact]
    public async Task Send_EmptyMessage_ShowsValidationDialog()
    {
        var dialog = new Mock<IDialogService>();
        var viewModel = CreateViewModel(dialog.Object, email: "a@b.com");

        viewModel.Send.Execute(null);
        await Task.Delay(50);

        dialog.Verify(
            d => d.ShowAsync(It.IsAny<string>(), AppStrings.ReviewMessageRequired),
            Times.Once);
    }

    [Fact]
    public async Task Send_WhitespaceMessage_ShowsValidationDialog()
    {
        var dialog = new Mock<IDialogService>();
        var viewModel = CreateViewModel(dialog.Object, email: "a@b.com");
        viewModel.MessageText = "   ";

        viewModel.Send.Execute(null);
        await Task.Delay(50);

        dialog.Verify(
            d => d.ShowAsync(It.IsAny<string>(), AppStrings.ReviewMessageRequired),
            Times.Once);
    }

    [Theory]
    [InlineData("a@b.com", "")]
    [InlineData("", "+123")]
    [InlineData("", "")]
    [InlineData("a@b.com", "+123")]
    public void ResolveChannel_AlwaysUsesEmail(string email, string sms)
    {
        var settings = new AppSettings
        {
            ReviewEmailAddress = email,
            ReviewSmsRecipient = sms
        };

        Assert.Equal(FeedbackChannel.Email, FormViewModel.ResolveChannel(settings));
    }

    private static FormViewModel CreateViewModel(IDialogService dialogService, string email = "", string sms = "") =>
        new(
            dialogService,
            Options.Create(new AppSettings
            {
                ReviewEmailAddress = email,
                ReviewSmsRecipient = sms
            }),
            Mock.Of<INavigationService>());
}
