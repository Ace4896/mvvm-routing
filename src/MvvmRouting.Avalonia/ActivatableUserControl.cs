using Avalonia;
using Avalonia.Controls;
using Avalonia.LogicalTree;
using System.Diagnostics;

namespace MvvmRouting.Avalonia;

/// <summary>
/// Extension of <see cref="UserControl"/> which can (de)activate it's DataContext if it's an <see cref="IActivatableViewModel"/>.
/// </summary>
public class ActivatableUserControl : UserControl
{
    protected override void OnAttachedToLogicalTree(LogicalTreeAttachmentEventArgs e)
    {
        Debug.WriteLine($"{nameof(ActivatableUserControl)}: Attached to logical tree; activating DataContext and setting up OnPropertyChanged...");
        PropertyChanged += OnDataContextChanged;
        ActivateDataContext(DataContext);

        base.OnAttachedToLogicalTree(e);
    }

    protected override void OnDetachedFromLogicalTree(LogicalTreeAttachmentEventArgs e)
    {
        Debug.WriteLine($"{nameof(ActivatableUserControl)}: Detached from logical tree; deactivating DataContext...");
        PropertyChanged -= OnDataContextChanged;
        DeactivateDataContext(DataContext);

        base.OnDetachedFromLogicalTree(e);
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
