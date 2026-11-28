using Microsoft.Extensions.Logging;
using PsychologyApp.Presentation.Entities.Test;
using PsychologyApp.Presentation.Features.RunTests;
using PsychologyApp.Presentation.Shared.Common;

namespace PsychologyApp.Presentation.Pages.RunTests.TestsList;

public partial class TestsListViewModel
{
    private async Task HandleSelectionAsync(TestItem testItem) =>
        await _navigationService.GoToFindProblemAsync(
            testItem.Description,
            testItem.Algorithm,
            testItem.Comment,
            testItem.StartAsync,
            testItem.TestId);

    public async Task InitAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await UiThread.RunAsync(SetInit);
            await _databaseReadySignal.WaitAsync(cancellationToken);

            TestsListLoadResult result = await _testsListLoader.LoadItemsAsync(
                _navigationService,
                HandleSelectionAsync,
                cancellationToken);

            await UiThread.RunAsync(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                TestItemCollection.ReplaceRange(result.Items);
                _initialized = true;
                SetDone();
            });

            if (result.ProgressDeferred)
            {
                RefreshProgressAsync(result.Items).FireAndForget();
            }
        }
        catch (OperationCanceledException)
        {
            await UiThread.RunAsync(CancelProgress);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "TestsListViewModel init failed.");
            await UiThread.RunAsync(SetFail);
        }
    }

    private async Task RefreshProgressAsync(IReadOnlyList<TestItem> items)
    {
        await _progressGate.WaitAsync();
        try
        {
            await _testsListLoader.EnrichProgressAsync(items);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Test catalog progress refresh failed.");
        }
        finally
        {
            _progressGate.Release();
        }
    }
}
