using Xunit;

namespace MvvmRouting.Tests;

public class RouterTests
{
    private class HostViewModel : IHostViewModel
    {
        public Router Router { get; } = new();
    }

    private class PageViewModel : IPageViewModel
    {
        public IHostViewModel? HostViewModel { get; }

        public PageViewModel(IHostViewModel? hostViewModel)
        {
            HostViewModel = hostViewModel;
        }
    }

    [Fact]
    public void Navigate_ChangesViewModel_RaisesPropertyChanged()
    {
        HostViewModel hostViewModel = new();
        IPageViewModel? propertyChangedViewModel = null;

        hostViewModel.Router.PropertyChanged += (_, args) =>
        {
            if (args.PropertyName == nameof(Router.CurrentViewModel))
            {
                propertyChangedViewModel = hostViewModel.Router.CurrentViewModel;
            }
        };

        // Initial ViewModel should be null
        Assert.Null(hostViewModel.Router.CurrentViewModel);

        // Navigate to a new page
        PageViewModel firstPage = new(hostViewModel);
        hostViewModel.Router.Navigate(firstPage);

        Assert.Equal(firstPage, hostViewModel.Router.CurrentViewModel);
        Assert.Equal(firstPage, propertyChangedViewModel);

        // Then to another page
        PageViewModel secondPage = new(hostViewModel);
        hostViewModel.Router.Navigate(secondPage);

        Assert.Equal(secondPage, hostViewModel.Router.CurrentViewModel);
        Assert.Equal(secondPage, propertyChangedViewModel);
    }
}
