using CommunityToolkit.Mvvm.Input;
using DemoApp.Factories;
using DemoApp.Services;
using MvvmRouting;
using System.Collections.Generic;

namespace DemoApp.ViewModels;

public class ListPageViewModel : PageViewModelBase
{
    private ITextPageFactory _textPageFactory;

    public List<string> Items { get; }

    public RelayCommand GoToTextPage { get; }

    // NOTE: Parameterless constructor is just for designer
    public ListPageViewModel() : this(null, null, null!)
    { }

    public ListPageViewModel(
        IHostViewModel? hostViewModel,
        IDataAccess? dataAccess,
        ITextPageFactory textPageFactory
    ) : base(hostViewModel)
    {
        _textPageFactory = textPageFactory;

        GoToTextPage = new RelayCommand(() => Navigate(_textPageFactory.Get(HostViewModel, "Title", "Navigated from List Page!")));

        if (dataAccess == null)
        {
            Items = new()
            {
                "No IDataAccess implementation...",
                "... was provided...",
                "... so these are some default items"
            };
        }
        else
        {
            Items = dataAccess.GetData();
        }
    }
}
