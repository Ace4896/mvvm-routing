# MVVM Routing

Testing ground for ViewModel-first routing with the MVVM pattern. 

## Requirements

- .NET 6
- [Avalonia Requirements](https://docs.avaloniaui.net/https://docs.avaloniaui.net/)

## Project Layout

The main logic can be found in these two projects:

- `MvvmRouting`: Contains the main classes that allow the routing implementation to work.
- `MvvmRouting.Avalonia`: Avalonia-specific controls that interact with the classes `MvvmRouting`.

There is a demo application showing how you would use these classes:

- `DemoApp`: Contains the ViewModels for the demo application.
- `DemoApp.Avalonia`: Avalonia frontend for the demo application.
