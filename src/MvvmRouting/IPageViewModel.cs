namespace MvvmRouting;

/// <summary>
/// Interface for a ViewModel that can be hosted within a <see cref="IHostViewModel"/> via a <see cref="Router"/>.
/// </summary>
public interface IPageViewModel
{
    public IHostViewModel? HostViewModel { get; }
}
