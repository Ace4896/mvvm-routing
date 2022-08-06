namespace MvvmRouting;

/// <summary>
/// Holds a ViewModel's activation state, and handles ViewModel activation/deactivation.
/// </summary>
public class Activator
{
    private readonly IActivatableViewModel _viewModel;

    public bool Activated { get; private set; }

    public Activator(IActivatableViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    /// <summary>
    /// Activates the associated ViewModel.
    /// </summary>
    public void Activate()
    {
        if (Activated)
        {
            return;
        }

        _viewModel.OnActivation();
        Activated = true;
    }

    /// <summary>
    /// Deactivates the associated ViewModel.
    /// </summary>
    public void Deactivate()
    {
        if (!Activated)
        {
            return;
        }

        _viewModel.OnDeactivation();
        Activated = false;
    }
}
