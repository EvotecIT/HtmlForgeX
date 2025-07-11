using System;
using System.Collections.Concurrent;

namespace HtmlForgeX;

/// <summary>
/// Configuration class for Document instances.
/// Manages state, libraries, and settings for document generation.
/// </summary>
public class DocumentConfiguration {
    /// <summary>
    /// Gets or sets the library mode for this document.
    /// </summary>
    public LibraryMode LibraryMode { get; set; } = LibraryMode.Online;

    /// <summary>
    /// Gets or sets the theme mode for this document.
    /// </summary>
    public ThemeMode ThemeMode { get; set; } = ThemeMode.Light;

    /// <summary>
    /// Gets or sets the file path for this document.
    /// </summary>
    public string Path { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the style path for this document.
    /// </summary>
    public string StylePath { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the script path for this document.
    /// </summary>
    public string ScriptPath { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets whether deferred scripts are enabled.
    /// </summary>
    public bool EnableDeferredScripts { get; set; } = false;

    /// <summary>
    /// Gets or sets whether dark mode support is enabled.
    /// </summary>
    public bool DarkModeSupport { get; set; } = true;

    /// <summary>
    /// Collection of libraries registered for this document.
    /// </summary>
    public ConcurrentDictionary<Libraries, int> Libraries { get; } = new();

    /// <summary>
    /// Collection of errors that occurred during document generation.
    /// </summary>
    public List<string> Errors { get; } = new();

    /// <summary>
    /// Email-specific configuration.
    /// </summary>
    public EmailConfiguration Email { get; } = new();

    /// <summary>
    /// Image-specific configuration.
    /// </summary>
    public ImageConfiguration Images { get; } = new();

    /// <summary>
    /// Layout-specific configuration.
    /// </summary>
    /// <param name="preText">Prefix for the identifier.</param>
    /// <param name="length">Length of the random part.</param>
    /// <returns>Generated identifier.</returns>
    public string GenerateRandomId(string preText, int length = DefaultRandomIdLength) {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        lock (_randomGenerator) {
            var randomId = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_randomGenerator.Next(s.Length)]).ToArray());
            return $"{preText}-{randomId}";
        }
    }
}