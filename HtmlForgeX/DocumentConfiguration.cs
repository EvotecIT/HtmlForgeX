using System;
using System.Collections.Concurrent;

namespace HtmlForgeX;

/// <summary>
/// Configuration and state for a Document instance, replacing the static GlobalStorage.
/// </summary>
public class DocumentConfiguration {
    internal const int DefaultRandomIdLength = 8;

    /// <summary>
    /// Gets or sets the theme mode for the document.
    /// </summary>
    public ThemeMode ThemeMode { get; set; } = ThemeMode.System;

    /// <summary>
    /// Gets or sets the library mode for the document.
    /// </summary>
    public LibraryMode LibraryMode { get; set; } = LibraryMode.Online;

    /// <summary>
    /// Gets or sets whether to enable deferred script execution to prevent timing issues.
    /// When enabled, component scripts will wait for all libraries to load before executing.
    /// </summary>
    public bool EnableDeferredScripts { get; set; } = false;

    /// <summary>
    /// Thread-safe collection of libraries used by the document.
    /// </summary>
    public ConcurrentDictionary<Libraries, byte> Libraries { get; } = new();

    /// <summary>
    /// Thread-safe collection of errors encountered during document processing.
    /// </summary>
    public ConcurrentBag<string> Errors { get; } = new();

    /// <summary>
    /// Gets or sets the path for saving documents and related files.
    /// </summary>
    public string Path { get; set; } = System.IO.Path.GetTempPath();

    /// <summary>Location for CSS resources.</summary>
    public string StylePath { get; set; } = "";

    /// <summary>Location for script resources.</summary>
    public string ScriptPath { get; set; } = "";

    private readonly Random _randomGenerator = new();

    /// <summary>
    /// Generates a pseudo random identifier with a prefix.
    /// </summary>
    /// <param name="preText">Prefix for the identifier.</param>
    /// <param name="length">Length of the random part.</param>
    /// <returns>Generated identifier.</returns>
    public string GenerateRandomId(string preText, int length = DefaultRandomIdLength) {
        if (string.IsNullOrWhiteSpace(preText)) {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(preText));
        }

        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        lock (_randomGenerator) {
            var randomId = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_randomGenerator.Next(s.Length)]).ToArray());
            return $"{preText}-{randomId}";
        }
    }
}