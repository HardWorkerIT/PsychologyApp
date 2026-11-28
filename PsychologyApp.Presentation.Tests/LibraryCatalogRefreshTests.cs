using Moq;
using PsychologyApp.Application.Articles;
using PsychologyApp.Presentation.Pages.ReadArticles.Articles;
using PsychologyApp.Presentation.Pages.ReadArticles.Courses;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;
using Xunit;

namespace PsychologyApp.Presentation.Tests;

[Collection("Localization")]
public sealed class LibraryCatalogRefreshTests
{
    [Fact]
    public async Task ReturningToCoursesWithoutVisibleProgressChangesKeepsTheListInPlace()
    {
        var reading = new Mock<IReadingService>();
        Course course = ArticleContent.Courses(AppStrings.Language)[0];
        DateTime now = new(2026, 11, 26, 12, 0, 0, DateTimeKind.Utc);
        ReadingState state = new() { Courses = [new(course.Id, now, [new(1, now, null)])] };
        reading.Setup(service => service.GetAsync(It.IsAny<CancellationToken>())).ReturnsAsync(() => state);
        var viewModel = new CoursesViewModel(new TestNavigationService(Mock.Of<INavigation>()), reading.Object, ReadyDatabase());
        await viewModel.RefreshAsync();
        var visibleSections = viewModel.Sections;

        state = new ReadingState
        {
            LastArticleId = ArticleIds.Sleep,
            Courses = [new(course.Id, now, [new(1, now, "Updated reflection")])]
        };
        viewModel.RefreshAdEligibility();
        await viewModel.RefreshAsync();

        Assert.Same(visibleSections, viewModel.Sections);
        Assert.Equal(AppStrings.CourseProgress(1, course.Days.Count), viewModel.Sections[0][0].MetaText);

        state = new ReadingState { Courses = [new(course.Id, now, [new(1, now, null)], now)] };
        await viewModel.RefreshAsync();

        Assert.Equal(AppStrings.CourseFinished, viewModel.Sections[0][0].MetaText);
        Assert.True(viewModel.Sections[0][0].IsRead);

        state = new ReadingState();
        await viewModel.RefreshAsync();

        Assert.False(viewModel.Sections[0][0].IsRead);
        Assert.Equal(AppStrings.ArticlesCourseMeta(course.Days.Count, course.Days.Max(day => day.Minutes)),
            viewModel.Sections[0][0].MetaText);
    }

    [Fact]
    public async Task FailedBookmarkReadDoesNotLookLikeAnEmptySavedList()
    {
        var reading = new Mock<IReadingService>();
        reading.SetupSequence(service => service.GetAsync(It.IsAny<CancellationToken>()))
            .ThrowsAsync(new IOException("Bookmarks unavailable"))
            .ReturnsAsync(new ReadingState { Saved = [ArticleIds.Sleep] });
        var viewModel = new ArticlesViewModel(new TestNavigationService(Mock.Of<INavigation>()), reading.Object, ReadyDatabase());
        viewModel.SelectFilterCommand.Execute("saved");
        Assert.True(viewModel.ShowSavedLoading);
        Assert.False(viewModel.HasEmptyText);

        await viewModel.RefreshAsync();
        Assert.True(viewModel.ShowSavedLoadFailure);
        Assert.False(viewModel.HasEmptyText);

        await viewModel.RefreshAsync();
        Assert.False(viewModel.ShowSavedLoadFailure);
        Assert.Single(Assert.Single(viewModel.Sections));
    }

    [Fact]
    public void ReselectingAnArticleFilterKeepsItsListInPlace()
    {
        var viewModel = new ArticlesViewModel(new TestNavigationService(Mock.Of<INavigation>()),
            Mock.Of<IReadingService>(), ReadyDatabase());
        var allSections = viewModel.Sections;

        viewModel.SelectFilterCommand.Execute(viewModel.Filters[0].Key);

        Assert.Same(allSections, viewModel.Sections);

        viewModel.SelectFilterCommand.Execute(viewModel.Filters[2].Key);
        var topicSections = viewModel.Sections;
        Assert.NotSame(allSections, topicSections);
        Assert.Equal(viewModel.Filters[2].Title, Assert.Single(topicSections).Title);

        viewModel.SelectFilterCommand.Execute(viewModel.Filters[2].Key);

        Assert.Same(topicSections, viewModel.Sections);
    }

    private static DatabaseReadySignal ReadyDatabase()
    {
        DatabaseReadySignal ready = new();
        ready.SignalReady();
        return ready;
    }
}
