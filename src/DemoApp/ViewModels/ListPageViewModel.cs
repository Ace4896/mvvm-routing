using CommunityToolkit.Mvvm.Input;
using MvvmRouting;

namespace DemoApp.ViewModels;

public class ListPageViewModel : PageViewModelBase
{
    public string[] Items { get; } = new[]
    {
        "Item 1",
        "Item 2",
        "Item 3"
    };

    public RelayCommand GoToTextPage { get; }

    // NOTE: Parameterless constructor is just for designer
    public ListPageViewModel() : this(null)
    { }

    public ListPageViewModel(IHostViewModel? hostViewModel) : base(hostViewModel)
    {
        GoToTextPage = new RelayCommand(() => Navigate(new TextPageViewModel(HostViewModel, "Title", "Navigated from List Page!")));
    }
}
