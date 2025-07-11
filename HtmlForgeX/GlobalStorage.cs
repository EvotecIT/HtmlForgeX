using System;
using System.Collections.Concurrent;

namespace HtmlForgeX;

/// <summary>
/// Provides application wide storage for configuration and state.
/// </summary>
internal static class GlobalStorage {
    internal const int DefaultRandomIdLength = 8;
    /// <summary>Gets or sets the current theme mode.</summary>
    internal static ThemeMode ThemeMode { get; set; } = ThemeMode.Light;
    /// <summary>Gets or sets the library mode.</summary>
    internal static LibraryMode LibraryMode { get; set; } = LibraryMode.Online;
    /// <summary>Collection of libraries used by the document.</summary>
    internal static ConcurrentDictionary<Libraries, byte> Libraries { get; } = new();
    /// <summary>Collection of processing errors.</summary>
    internal static ConcurrentBag<string> Errors { get; } = new();
    /// <summary>Output path for generated files.</summary>
    internal static string Path { get; set; } = "";
    /// <summary>Location for CSS resources.</summary>
    internal static string StylePath { get; set; } = "";
    /// <summary>Location for script resources.</summary>
    internal static string ScriptPath { get; set; } = "";
    private static readonly Random RandomGenerator = new();

    /// <summary>
    /// Generates a pseudo random identifier with a prefix.
    /// </summary>
    /// <param name="preText">Prefix for the identifier.</param>
    /// <returns>Generated identifier.</returns>
    internal static string GenerateRandomId(string preText, int length = DefaultRandomIdLength) {
        if (string.IsNullOrWhiteSpace(preText)) {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(preText));
        }

        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        lock (RandomGenerator) {
            var randomId = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[RandomGenerator.Next(s.Length)]).ToArray());
            return $"{preText}-{randomId}";
        }
    }
}