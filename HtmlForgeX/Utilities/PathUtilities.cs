using System;
using System.IO;
using System.Runtime.InteropServices;

namespace HtmlForgeX;

internal static class PathUtilities {
    public static void Validate(string path) {
        if (string.IsNullOrWhiteSpace(path)) {
            throw new ArgumentException("Path cannot be null or whitespace.", nameof(path));
        }

        if (path.IndexOfAny(Path.GetInvalidPathChars()) >= 0) {
            throw new ArgumentException("Path contains invalid characters.", nameof(path));
        }

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
            var trimmed = path.StartsWith("\\\\?\\") ? path.Substring(4) : path;
            var firstColon = trimmed.IndexOf(':');
            if ((firstColon >= 0 && firstColon != 1) || trimmed.IndexOf(':', firstColon + 1) >= 0) {
                throw new ArgumentException("Path contains invalid colon characters.", nameof(path));
            }
        }

        // UNC paths start with two directory separators. Ensure they have at least
        // a server and share specified before treating them as valid.
        if (path.StartsWith("\\") || path.StartsWith("//")) {
            var unc = path.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            if (unc.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Length < 2) {
                throw new ArgumentException("UNC path must include a server and share name.", nameof(path));
            }
        }
    }
}