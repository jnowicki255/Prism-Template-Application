using PTA.TestBase;
using Xunit;

namespace PTA.Repository.Tests.Infrastucture
{
    /// <summary>
    /// Empty class to satisfy XUnit framework.
    /// </summary>
    [CollectionDefinition(TestsCollections.DatabaseTests)]
    public class DatabaseTestFixtureCollection : ICollectionFixture<DatabaseTestFixture>
    { }
}
