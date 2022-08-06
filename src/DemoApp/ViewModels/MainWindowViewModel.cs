using CommunityToolkit.Mvvm.Input;
using MvvmRouting;

namespace DemoApp.ViewModels;

public class MainWindowViewModel : ViewModelBase, IHostViewModel
{
    public Router Router { get; } = new();

    public RelayCommand GoToTextPage { get; }
    public RelayCommand GoToListPage { get; }

    public MainWindowViewModel()
    {
        GoToTextPage = new RelayCommand(() => Router.Navigate(new TextPageViewModel(this, "Title", "Navigated from Main Window!")));
        GoToListPage = new RelayCommand(() => Router.Navigate(new ListPageViewModel(this)));

        GoToTextPage.Execute(null);
    }
}
