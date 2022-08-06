namespace MvvmRouting.Avalonia.Tests;

public class TestViewModel : IActivatableViewModel
{
    public Activator Activator { get; }

    public int ActivationCount { get; set; } = 0;
    public int DeactivationCount { get; set; } = 0;

    public TestViewModel()
    {
        Activator = new(this);
    }

    public void OnActivation()
    {
        ActivationCount++;
    }

    public void OnDeactivation()
    {
        DeactivationCount++;
    }
}
