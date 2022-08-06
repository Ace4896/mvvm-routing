using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DemoApp.Avalonia.Services;
using DemoApp.Avalonia.Views;
using DemoApp.Factories;
using DemoApp.Services;
using DemoApp.ViewModels;
using LightInject;
using MvvmRouting;

namespace DemoApp.Avalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        ServiceContainer container = SetupServiceContainer();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = container.GetInstance<MainWindowViewModel>(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private ServiceContainer SetupServiceContainer()
    {
        ServiceContainer container = new();

        // Register services
        container.Register<IDataAccess, DummyDataAccess>(new PerContainerLifetime());

        // Register ViewModels
        container.Register<MainWindowViewModel>();

        container.Register<IHostViewModel?, string, string, TextPageViewModel>(
            (factory, host, title, description) => new TextPageViewModel(host, factory.GetInstance<IListPageFactory>(), title, description)
        );

        container.Register<IHostViewModel?, ListPageViewModel>(
            (factory, host) => new(host, factory.GetInstance<IDataAccess>(), factory.GetInstance<ITextPageFactory>())
        );

        // Register ViewModel factories
        container.Register<IListPageFactory, ListPageFactory>(new PerContainerLifetime());
        container.Register<ITextPageFactory, TextPageFactory>(new PerContainerLifetime());

        container.Compile();
        return container;
    }
}