namespace HtmlForgeX.Tests;

/// <summary>
/// Shared utilities for test classes
/// </summary>
public static class TestUtilities {
    /// <summary>
    /// Gets a framework-specific temporary path to avoid conflicts between net472 and net8.0 test runs
    /// </summary>
    public static string GetFrameworkSpecificTempPath() {
        return TempPath.Get();
    }
}