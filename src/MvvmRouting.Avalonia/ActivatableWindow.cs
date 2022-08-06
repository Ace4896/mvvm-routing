﻿using Avalonia;
using Avalonia.Controls;
using System;
using System.Diagnostics;

namespace MvvmRouting.Avalonia;

/// <summary>
/// Extension of <see cref="Window"/> which can (de)activate it's DataContext if it's an <see cref="IActivatableViewModel"/>.
/// </summary>
public class ActivatableWindow : Window
{
    protected override void OnOpened(EventArgs e)
    {
        Debug.WriteLine($"{nameof(ActivatableWindow)}: Window opened; activating DataContext and setting up OnPropertyChanged...");
        PropertyChanged += OnDataContextChanged;
        ActivateDataContext(DataContext);

        base.OnOpened(e);
    }

    protected override void OnClosed(EventArgs e)
    {
        Debug.WriteLine($"{nameof(ActivatableWindow)}: Window closed; deactivating DataContext...");
        PropertyChanged -= OnDataContextChanged;
        DeactivateDataContext(DataContext);

        base.OnClosed(e);
    }

    private void OnDataContextChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
    {
        if (e.Property.Name != nameof(DataContext))
        {
            return;
        }

        Debug.WriteLine($"{nameof(ActivatableWindow)}: DataContext changed, deactivating old value and activating new value...");
        DeactivateDataContext(e.OldValue);
        ActivateDataContext(e.NewValue);
    }

    private static void ActivateDataContext(object? dataContext)
    {
        if (dataContext is IActivatableViewModel activatableViewModel)
        {
            activatableViewModel.Activator.Activate();
        }
    }

    private static void DeactivateDataContext(object? dataContext)
    {
        if (dataContext is IActivatableViewModel activatableViewModel)
        {
            activatableViewModel.Activator.Deactivate();
        }
    }
}
