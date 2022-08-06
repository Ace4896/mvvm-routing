using CommunityToolkit.Mvvm.ComponentModel;

namespace MvvmRouting;

/// <summary>
/// A router that tracks which <see cref="IPageViewModel"/> is currently being displayed.
/// </summary>
public class Router : ObservableObject
{
    private IPageViewModel? _currentViewModel;

    /// <summary>
    /// The current ViewModel being displayed. In XAML, this is the part that requires binding.
    /// </summary>
    public IPageViewModel? CurrentViewModel
    {
        get => _currentViewModel;
        set => SetProperty(ref _currentViewModel, value);
    }

    /// <summary>
    /// Navigates to the specified <see cref="IPageViewModel"/>.
    /// </summary>
    /// <param name="nextViewModel">The <see cref="IPageViewModel"/> to navigate to.</param>
    public void Navigate(IPageViewModel? nextViewModel) => CurrentViewModel = nextViewModel;
}
