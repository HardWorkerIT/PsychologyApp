using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Features.RunTechniqueSession.DependencyInjection;

namespace PsychologyApp.Presentation.Pages.RunTechniqueSession.TechniqueDesigner;

public partial class DesignerPage : ContentPage
{
    private readonly DesignerViewModel _viewModel;
    private readonly KeyboardResize _keyboard = new();
    private PageAnimationHelper? _animationHelper;

    public DesignerPage(
        IPageViewModelActivator pageViewModelActivator,
        IDesignerViewModelFactory designerViewModelFactory,
        long id)
    {
        InitializeComponent();
        _viewModel = this.ActivateViewModel(pageViewModelActivator, page => designerViewModelFactory.Create(page, id));
        _animationHelper = new PageAnimationHelper(_viewModel, LoadingProgress, contentView: DesignerContent);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _keyboard.Enable();
        _animationHelper?.TryRevealAsync();
        _viewModel.EnsureInitializedAsync().FireAndForget();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _keyboard.Restore();
    }

    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();
        if (Handler is null)
        {
            _animationHelper?.Dispose();
            _animationHelper = null;
        }
    }
}
