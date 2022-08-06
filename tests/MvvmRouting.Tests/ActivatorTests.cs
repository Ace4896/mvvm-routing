using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MvvmRouting.Tests;

public class ActivatorTests
{
    private class ActivatableViewModel : IActivatableViewModel
    {
        public Activator Activator { get; }

        public int ActivationCount = 0;
        public int DeactivationCount = 0;

        public ActivatableViewModel()
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

    [Fact]
    public void Activation_Deactivation_Works()
    {
        var viewModel = new ActivatableViewModel();

        // Should be deactivated by default
        Assert.False(viewModel.Activator.Activated);
        Assert.Equal(0, viewModel.ActivationCount);
        Assert.Equal(0, viewModel.DeactivationCount);

        // Activate the ViewModel
        viewModel.Activator.Activate();

        Assert.True(viewModel.Activator.Activated);
        Assert.Equal(1, viewModel.ActivationCount);
        Assert.Equal(0, viewModel.DeactivationCount);

        // Deactivate the ViewModel
        viewModel.Activator.Deactivate();

        Assert.False(viewModel.Activator.Activated);
        Assert.Equal(1, viewModel.ActivationCount);
        Assert.Equal(1, viewModel.DeactivationCount);
    }

    [Fact]
    public void Activate_OnlyCallsWhenDeactivated()
    {
        var viewModel = new ActivatableViewModel();

        // Should be deactivated by default
        Assert.False(viewModel.Activator.Activated);
        Assert.Equal(0, viewModel.ActivationCount);
        Assert.Equal(0, viewModel.DeactivationCount);

        // Activate the ViewModel
        viewModel.Activator.Activate();

        Assert.True(viewModel.Activator.Activated);
        Assert.Equal(1, viewModel.ActivationCount);
        Assert.Equal(0, viewModel.DeactivationCount);

        // Attempt to re-activate the ViewModel; shouldn't call OnActivation anymore
        viewModel.Activator.Activate();

        Assert.True(viewModel.Activator.Activated);
        Assert.Equal(1, viewModel.ActivationCount);
        Assert.Equal(0, viewModel.DeactivationCount);
    }

    [Fact]
    public void Deactivate_OnlyCallsWhenActivated()
    {
        var viewModel = new ActivatableViewModel();

        // Should be deactivated by default
        Assert.False(viewModel.Activator.Activated);
        Assert.Equal(0, viewModel.ActivationCount);
        Assert.Equal(0, viewModel.DeactivationCount);

        // Activate the ViewModel
        viewModel.Activator.Activate();

        Assert.True(viewModel.Activator.Activated);
        Assert.Equal(1, viewModel.ActivationCount);
        Assert.Equal(0, viewModel.DeactivationCount);

        // Deactivate the ViewModel
        viewModel.Activator.Deactivate();

        Assert.False(viewModel.Activator.Activated);
        Assert.Equal(1, viewModel.ActivationCount);
        Assert.Equal(1, viewModel.DeactivationCount);

        // Attempt to re-deactivate the ViewModel; shouldn't call OnDeactivation anymore
        viewModel.Activator.Deactivate();

        Assert.False(viewModel.Activator.Activated);
        Assert.Equal(1, viewModel.ActivationCount);
        Assert.Equal(1, viewModel.DeactivationCount);
    }
}
