namespace Evently.IntegrationTests.Abstractions;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1515:Consider making public types internal", Justification = "Base class needs to be public for test inheritance across test assemblies")]

[CollectionDefinition(nameof(IntegrationTestCollection))]
public sealed class IntegrationTestCollection : ICollectionFixture<IntegrationTestWebAppFactory>;
