using System;
using System.IO;

namespace HtmlForgeX;

internal static class TempPath {
    /// <summary>
    /// Returns a temporary path unique to the current framework.
    /// </summary>
    public static string Get() {
        var frameworkId =
#if NET472
            "net472";
#elif NET8_0
            "net8.0";
#elif NET9_0
            "net9.0";
#else
            "unknown";
#endif
        var tempPath = Path.Combine(Path.GetTempPath(), "HtmlForgeX", frameworkId);
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