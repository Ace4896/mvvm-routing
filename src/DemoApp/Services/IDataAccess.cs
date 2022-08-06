using System.Collections.Generic;

namespace DemoApp.Services;

/// <summary>
/// Interface for retrieving data (e.g. from a database).
/// This can then be injected into a ViewModel later.
/// </summary>
public interface IDataAccess
{
    public List<string> GetData();
}
