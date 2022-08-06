using CommunityToolkit.Mvvm.Input;
using MvvmRouting;

namespace DemoApp.ViewModels;

public class TextPageViewModel : PageViewModelBase
{
    public string Title { get; }
    public string Description { get; }

    public RelayCommand GoToListPage { get; }

    // NOTE: Parameterless constructor is intended for designer
    public TextPageViewModel() : this(null, "Title", "Description")
    { }

    public TextPageViewModel(IHostViewModel? hostViewModel, string title, string description) : base(hostViewModel)
    {
        Title = title;
        Description = description;

        GoToListPage = new RelayCommand(() => Navigate(new ListPageViewModel(HostViewModel)));
    }
}
