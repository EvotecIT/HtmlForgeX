using System;
using System.IO;

namespace HtmlForgeX;

internal static class PathUtilities {
    public static void Validate(string path) {
        if (string.IsNullOrWhiteSpace(path)) {
            throw new ArgumentException("Path cannot be null or whitespace.", nameof(path));
        }

        if (path.IndexOfAny(Path.GetInvalidPathChars()) >= 0) {
            throw new ArgumentException("Path contains invalid characters.", nameof(path));
        }
    }
}
