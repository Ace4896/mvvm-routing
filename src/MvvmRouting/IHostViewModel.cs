namespace MvvmRouting;

/// <summary>
/// Interface for a ViewModel that can host an <see cref="IPageViewModel"/> as a sub-ViewModel.
/// </summary>
public interface IHostViewModel
{
    /// <summary>
    /// The router which contains the current routing state.
    /// </summary>
    public Router Router { get; }
}
