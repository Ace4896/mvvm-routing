using DemoApp.ViewModels;
using MvvmRouting;
using System;

namespace DemoApp.Factories;

public interface IListPageFactory
{
    ListPageViewModel Get(IHostViewModel? hostViewModel);
}

public class ListPageFactory : IListPageFactory
{
    private readonly Func<IHostViewModel?, ListPageViewModel> _factory;

    public ListPageFactory(Func<IHostViewModel?, ListPageViewModel> factory)
    {
        _factory = factory;
    }

    public ListPageViewModel Get(IHostViewModel? hostViewModel)
    {
        return _factory(hostViewModel);
    }
}
