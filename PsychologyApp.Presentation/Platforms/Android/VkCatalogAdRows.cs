#if ANDROID
namespace PsychologyApp.Presentation.Platforms.Android;

/// <summary>Owns the two realized ad rows in a virtualized catalog.</summary>
internal sealed class VkCatalogAdRows(object source, string bannerEligibility, string nativeEligibility, Thickness bannerMargin)
{
    private ContentView? _bannerRow;
    private ContentView? _nativeRow;
    private bool _isPageVisible;

    public void SetPageVisible(bool visible)
    {
        if (_isPageVisible == visible)
        {
            return;
        }

        _isPageVisible = visible;
        if (visible)
        {
            Mount(_bannerRow, isBanner: true);
            Mount(_nativeRow, isBanner: false);
        }
        else
        {
            Unmount(_bannerRow);
            Unmount(_nativeRow);
        }
    }

    public void BindRow(ContentView row, bool? isBanner)
    {
        if (isBanner != true && ReferenceEquals(_bannerRow, row))
        {
            Unmount(row);
            _bannerRow = null;
        }

        if (isBanner != false && ReferenceEquals(_nativeRow, row))
        {
            Unmount(row);
            _nativeRow = null;
        }

        if (isBanner is not bool banner)
        {
            return;
        }

        ref ContentView? slot = ref (banner ? ref _bannerRow : ref _nativeRow);
        if (!ReferenceEquals(slot, row))
        {
            Unmount(slot);
            slot = row;
        }

        Mount(row, banner);
    }

    private void Mount(ContentView? row, bool isBanner)
    {
        if (!_isPageVisible || row is null || row.Content is not null)
        {
            return;
        }

        if (isBanner)
        {
            VkBannerView banner = new() { Margin = bannerMargin };
            banner.SetBinding(VkBannerView.IsEligibleProperty, new Binding(bannerEligibility) { Source = source });
            banner.AdLoadedChanged += (_, _) => row.IsVisible = banner.IsAdLoaded;
            row.Content = banner;
            row.IsVisible = banner.IsAdLoaded;
        }
        else
        {
            VkNativeView native = new();
            native.SetBinding(VkNativeView.IsEligibleProperty, new Binding(nativeEligibility) { Source = source });
            native.PropertyChanged += (_, args) =>
            {
                if (args.PropertyName == nameof(VkNativeView.IsAdLoaded))
                {
                    row.IsVisible = native.IsAdLoaded;
                }
            };
            row.Content = native;
            row.IsVisible = native.IsAdLoaded;
        }
    }

    private static void Unmount(ContentView? row)
    {
        if (row is not null)
        {
            row.Content?.Handler?.DisconnectHandler();
            row.Content = null;
            row.IsVisible = false;
        }
    }
}
#endif
