using MvvmRouting;

namespace DemoApp.ViewModels;

/// <summary>
/// Extension of <see cref="ViewModelBase"/> which implements the <see cref="IPageViewModel"/> interface.
/// </summary>
public abstract class PageViewModelBase : ViewModelBase, IPageViewModel
{
    public IHostViewModel? HostViewModel { get; }

    protected PageViewModelBase(IHostViewModel? hostViewModel)
    {
        HostViewModel = hostViewModel;
    }

    /// <summary>
    /// Shortcut for calling <see cref="Router.Navigate(IPageViewModel?)"/>.
    /// </summary>
    /// <param name="nextViewModel">The <see cref="IPageViewModel"/> to navigate to.</param>
    protected void Navigate(IPageViewModel? nextViewModel) => HostViewModel?.Router.Navigate(nextViewModel);
}
