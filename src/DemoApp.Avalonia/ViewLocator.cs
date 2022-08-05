using Avalonia.Controls;
using Avalonia.Controls.Templates;
using DemoApp.ViewModels;
using System;
using System.Collections.Generic;

namespace DemoApp.Avalonia;

public class ViewLocator : IDataTemplate
{
    private static readonly Dictionary<Type, Func<IControl>> _viewModelMappings = new()
    { };

    public IControl Build(object data)
    {
        Type type = data.GetType();
        if (_viewModelMappings.TryGetValue(type, out Func<IControl>? viewFactory))
        {
            return viewFactory();
        }

        return new TextBlock { Text = $"Could not find ViewModel mapping for '{type}'" };
    }

    public bool Match(object data)
    {
        return data is ViewModelBase;
    }
}