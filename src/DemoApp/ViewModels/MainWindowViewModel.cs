using CommunityToolkit.Mvvm.Input;
using DemoApp.Factories;
using MvvmRouting;

namespace DemoApp.ViewModels;

public class MainWindowViewModel : ViewModelBase, IHostViewModel
{
    private ITextPageFactory _textPageFactory;
    private IListPageFactory _listPageFactory;

    public Router Router { get; } = new();

    public RelayCommand GoToTextPage { get; }
    public RelayCommand GoToListPage { get; }

    public MainWindowViewModel() : this(null!, null!)
    { }

    public MainWindowViewModel(ITextPageFactory textPageFactory, IListPageFactory listPageFactory)
    {
        _textPageFactory = textPageFactory;
        _listPageFactory = listPageFactory;

        GoToTextPage = new RelayCommand(() => Router.Navigate(_textPageFactory.Get(this, "Title", "Navigated from Main Window!")));
        GoToListPage = new RelayCommand(() => Router.Navigate(_listPageFactory.Get(this)));

        GoToTextPage.Execute(null);
    }
}
