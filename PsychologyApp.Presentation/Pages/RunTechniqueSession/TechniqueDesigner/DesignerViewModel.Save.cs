using Microsoft.Extensions.Logging;
using PsychologyApp.Application.Models;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Features.RunTechniqueSession;

namespace PsychologyApp.Presentation.Pages.RunTechniqueSession.TechniqueDesigner;

public partial class DesignerViewModel
{
    private bool CanSave() => !IsSaving && !IsFail && (_techniqueId <= 0 || (_initialized && IsDone));

    private async Task ExecuteOperationAsync()
    {
        if (!CanSave())
        {
            return;
        }

        IsSaving = true;
        try
        {
            if (_techniqueId <= 0)
            {
                await ToAddTechniqueAsync();
            }
            else
            {
                await ToChangeTechniqueAsync();
            }
        }
        finally
        {
            IsSaving = false;
        }
    }

    private async Task ToChangeTechniqueAsync()
    {
        try
        {
            DesignerTechniqueForm form = CaptureForm();
            TechniqueDTO item = _techniqueOperations.BuildDto(_techniqueId, form);

            using CancellationTokenSource timeoutSource = OperationCancellation.CreateSmallTimeoutSource(_settings);
            await _techniqueOperations.UpdateAsync(
                item,
                _techniqueService,
                _techniqueMessenger,
                timeoutSource.Token);

            _savedForm = form;
            await GoToRootAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to update technique.");
            _toastService.ShortToast(AppStrings.DesignerSaveError);
        }
    }

    private async Task ToAddTechniqueAsync()
    {
        try
        {
            DesignerTechniqueForm form = CaptureForm();
            TechniqueDTO technique = _techniqueOperations.BuildDto(-1, form);

            using CancellationTokenSource timeoutSource = OperationCancellation.CreateSmallTimeoutSource(_settings);
            await _techniqueOperations.AddAsync(
                technique,
                _techniqueService,
                _techniqueMessenger,
                timeoutSource.Token);

            _savedForm = form;
            await GoBackAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to add technique.");
            _toastService.ShortToast(AppStrings.DesignerSaveError);
        }
    }
}
