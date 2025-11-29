namespace Evently.Gateway.OpenTelemetry;


[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1515:Consider making public types internal", Justification = "Base class needs to be public for test inheritance across test assemblies")]

public static class DiagnosticsConfig
{
    public const string ServiceName = "Evently.Gateway";
}
