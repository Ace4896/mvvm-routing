using DemoApp.Services;
using System.Collections.Generic;

namespace DemoApp.Avalonia.Services;

public class DummyDataAccess : IDataAccess
{
    public List<string> GetData()
    {
        return new()
        {
            "This list of data...",
            "... is from the DummyDataAccess class"
        };
    }
}
