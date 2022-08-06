using Avalonia.Platform;
using Moq;
using Xunit;

namespace MvvmRouting.Avalonia.Tests;

public class ActivatableWindowTests
{
    private readonly ActivatableWindow _window = new(Mock.Of<IWindowImpl>());

    [Fact]
    public void ActivationLogic_Works()
    {
        var firstDataContext = new TestViewModel();
        var secondDataContext = new TestViewModel();

        // DataContext should not be activated yet, as control is not attached to a logical tree yet
        _window.DataContext = firstDataContext;

        Assert.Equal(0, firstDataContext.ActivationCount);
        Assert.Equal(0, firstDataContext.DeactivationCount);

        // Opening the window should activate the DataContext
        _window.Show();

        Assert.Equal(1, firstDataContext.ActivationCount);
        Assert.Equal(0, firstDataContext.DeactivationCount);

        // Changing the DataContext should deactivate the old one and activate the new one
        _window.DataContext = secondDataContext;

        Assert.Equal(1, firstDataContext.ActivationCount);
        Assert.Equal(1, firstDataContext.DeactivationCount);

        Assert.Equal(1, secondDataContext.ActivationCount);
        Assert.Equal(0, secondDataContext.DeactivationCount);

        // Closing the window should deactivate the DataContext
        _window.Close();

        Assert.Equal(1, firstDataContext.ActivationCount);
        Assert.Equal(1, firstDataContext.DeactivationCount);

        Assert.Equal(1, secondDataContext.ActivationCount);
        Assert.Equal(1, secondDataContext.DeactivationCount);
    }
}
