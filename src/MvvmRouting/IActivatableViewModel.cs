namespace MvvmRouting;

/// <summary>
/// Interface for a ViewModel that can be activated when it's view loads in and deactivated when the view is detached.
/// </summary>
public interface IActivatableViewModel
{
    /// <summary>
    /// The ViewModel's associated <see cref="Activator"/>.
    /// </summary>
    public Activator Activator { get; }

    /// <summary>
    /// Activates this ViewModel (if not activated already).
    /// </summary>
    public void OnActivation();

    /// <summary>
    /// Deactivates this ViewModel (if it's inactive).
    /// </summary>
    public void OnDeactivation();
}
