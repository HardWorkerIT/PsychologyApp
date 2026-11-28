using PsychologyApp.Presentation.Features.ReadArticles;
using PsychologyApp.Presentation.Shared.Common;

namespace PsychologyApp.Presentation.Pages.ReadArticles.ArticleReader;

public partial class ArticleReaderPage : ContentPage
{
    // "Read" when the last lines are on screen, not on opening: an article glanced at is not an article read.
    private const double EndSlack = 48;

    private readonly ArticleReaderViewModel _viewModel;

#if ANDROID
    internal bool CanShowInterstitialOnReturn { get; set; }
    internal bool HasReachedEnd { get; private set; }
#endif

    public ArticleReaderPage(IArticleReaderViewModelFactory viewModelFactory, string articleId)
    {
        InitializeComponent();
        _viewModel = viewModelFactory.Create(this, articleId);
        BindingContext = _viewModel;
        foreach (IView child in Tools.Children)
        {
            FlexLayout.SetShrink((BindableObject)child, 0);
        }

        Scroller.Scrolled += (_, _) => CheckEnd();
        Scroller.SizeChanged += (_, _) => CheckEnd();
    }

    private void CheckEnd()
    {
        if (Scroller.Height > 0 && Scroller.ContentSize.Height > 0
            && Scroller.ScrollY + Scroller.Height >= Scroller.ContentSize.Height - EndSlack)
        {
#if ANDROID
            HasReachedEnd = true;
#endif
            _viewModel.ReachedEndAsync().FireAndForget();
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _viewModel.StopListening();
    }
}
