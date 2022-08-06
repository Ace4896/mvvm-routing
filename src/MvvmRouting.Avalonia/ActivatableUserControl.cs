using Avalonia;
using Avalonia.Controls;
using System.Diagnostics;

namespace MvvmRouting.Avalonia;

/// <summary>
/// Extension of <see cref="UserControl"/> which can (de)activate it's DataContext if it's an <see cref="IActivatableViewModel"/>.
/// </summary>
public class ActivatableUserControl : UserControl
{
    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        Debug.WriteLine($"{nameof(ActivatableUserControl)}: Attached to visual tree; activating DataContext and setting up OnPropertyChanged...");
        PropertyChanged += OnDataContextChanged;
        ActivateDataContext(DataContext);

        base.OnAttachedToVisualTree(e);
    }

    protected override void OnDetachedFromVisualTree(VisualTreeAttachmentEventArgs e)
    {
        Debug.WriteLine($"{nameof(ActivatableUserControl)}: Detached from visual tree; deactivating DataContext...");
        PropertyChanged -= OnDataContextChanged;
        DeactivateDataContext(DataContext);

        base.OnDetachedFromVisualTree(e);
    }

    private void OnDataContextChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
    {
        if (e.Property.Name != nameof(DataContext))
        {
            return;
        }

        Debug.WriteLine($"{nameof(ActivatableUserControl)}: DataContext changed, deactivating old value and activating new value...");
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
