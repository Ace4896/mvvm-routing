using CommunityToolkit.Mvvm.Input;
using DemoApp.Factories;
using DemoApp.Services;
using MvvmRouting;
using System.Collections.Generic;

namespace DemoApp.ViewModels;

public class ListPageViewModel : PageViewModelBase, IActivatableViewModel
{
    private readonly ITextPageFactory _textPageFactory;

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

        Activator = new(this);

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

    #region IActivatableViewModel

    public Activator Activator { get; }

    public void OnActivation()
    {
        // Extend the list with more data
        Items.Add("Here's another item that was added by IActivatableViewModel.Activate!");
    }

    public void OnDeactivation()
    { }

    #endregion
}
