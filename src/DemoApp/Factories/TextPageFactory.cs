using DemoApp.ViewModels;
using MvvmRouting;
using System;

namespace DemoApp.Factories;

public interface ITextPageFactory
{
    TextPageViewModel Get(IHostViewModel? hostViewModel, string title, string description);
}

public class TextPageFactory : ITextPageFactory
{
    private readonly Func<IHostViewModel?, string, string, TextPageViewModel> _factory;

    public TextPageFactory(Func<IHostViewModel?, string, string, TextPageViewModel> factory)
    {
        _factory = factory;
    }

    public TextPageViewModel Get(IHostViewModel? hostViewModel, string title, string description)
    {
        return _factory(hostViewModel, title, description);
    }
}
