using CommunityToolkit.Mvvm.Input;
using DemoApp.Factories;
using MvvmRouting;

namespace DemoApp.ViewModels;

public class MainWindowViewModel : ViewModelBase, IActivatableViewModel, IHostViewModel
{
    private readonly ITextPageFactory _textPageFactory;
    private readonly IListPageFactory _listPageFactory;

    public Activator Activator { get; }
    public Router Router { get; } = new();

    public RelayCommand GoToTextPage { get; }
    public RelayCommand GoToListPage { get; }

    public MainWindowViewModel() : this(null!, null!)
    { }

    public MainWindowViewModel(ITextPageFactory textPageFactory, IListPageFactory listPageFactory)
    {
        _textPageFactory = textPageFactory;
        _listPageFactory = listPageFactory;

        Activator = new(this);

        GoToTextPage = new RelayCommand(() => Router.Navigate(_textPageFactory.Get(this, "Title", "Navigated from Main Window!")));
        GoToListPage = new RelayCommand(() => Router.Navigate(_listPageFactory.Get(this)));
    }

    #region IActivatableViewModel

    public void OnActivation()
    {
        GoToTextPage.Execute(null);
    }

    public void OnDeactivation()
    { }

    #endregion
}
