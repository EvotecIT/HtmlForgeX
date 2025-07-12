namespace HtmlForgeX.Tests;

/// <summary>
/// Shared utilities for test classes
/// </summary>
public static class TestUtilities {
    /// <summary>
    /// Gets a framework-specific temporary path to avoid conflicts between net472 and net8.0 test runs
    /// </summary>
    public static string GetFrameworkSpecificTempPath() {
        var frameworkId =
#if NET472
            "net472";
#elif NET8_0
            "net8.0";
#else
            "unknown";
#endif
        var tempPath = Path.Combine(Path.GetTempPath(), "HtmlForgeX_Tests", frameworkId);
        if (!Directory.Exists(tempPath)) {
            try {
                Directory.CreateDirectory(tempPath);
            } catch (Exception ex) {
                Document._logger.WriteError($"Failed to create directory '{tempPath}'. {ex.Message}");
            }
        }
        return tempPath;
    }
}