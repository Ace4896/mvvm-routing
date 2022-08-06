using CommunityToolkit.Mvvm.Input;
using DemoApp.Factories;
using MvvmRouting;

namespace DemoApp.ViewModels;

public class TextPageViewModel : PageViewModelBase
{
    private IListPageFactory _listPageFactory;

    public string Title { get; }
    public string Description { get; }

    public RelayCommand GoToListPage { get; }

    // NOTE: Parameterless constructor is intended for designer
    public TextPageViewModel() : this(null, null!, "Title", "Description")
    { }

    public TextPageViewModel(
        IHostViewModel? hostViewModel,
        IListPageFactory listPageFactory,
        string title, string description) : base(hostViewModel)
    {
        _listPageFactory = listPageFactory;

        Title = title;
        Description = description;

        GoToListPage = new RelayCommand(() => Navigate(_listPageFactory.Get(HostViewModel)));
    }
}
