using Avalonia.Controls;
using Avalonia.Platform;
using Moq;
using Xunit;

namespace MvvmRouting.Avalonia.Tests;

public class ActivatableUserControlTests
{
    private readonly ActivatableUserControl _control = new();
    private readonly WindowBase _container = new(Mock.Of<IWindowImpl>());

    [Fact]
    public void ActivationLogic_Works()
    {
        var firstDataContext = new TestViewModel();
        var secondDataContext = new TestViewModel();

        // DataContext should not be activated yet, as control is not attached to a logical tree yet
        _control.DataContext = firstDataContext;

        Assert.Equal(0, firstDataContext.ActivationCount);
        Assert.Equal(0, firstDataContext.DeactivationCount);

        // Attaching to a logical tree should activate the DataContext
        _container.Content = _control;

        Assert.Equal(1, firstDataContext.ActivationCount);
        Assert.Equal(0, firstDataContext.DeactivationCount);

        // Changing the DataContext should deactivate the old one and activate the new one
        _control.DataContext = secondDataContext;

        Assert.Equal(1, firstDataContext.ActivationCount);
        Assert.Equal(1, firstDataContext.DeactivationCount);

        Assert.Equal(1, secondDataContext.ActivationCount);
        Assert.Equal(0, secondDataContext.DeactivationCount);

        // Detacthing from a logical tree should deactivate the DataContext
        _container.Content = null;

        Assert.Equal(1, firstDataContext.ActivationCount);
        Assert.Equal(1, firstDataContext.DeactivationCount);

        Assert.Equal(1, secondDataContext.ActivationCount);
        Assert.Equal(1, secondDataContext.DeactivationCount);
    }
}
