using System.Collections.Concurrent;

namespace HtmlForgeX;

/// <summary>
/// Internal state and runtime information for a Document instance.
/// Handles library tracking, error collection, and ID generation.
/// </summary>
internal class DocumentState {

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


    /// <summary>
    /// Generates a pseudo random identifier with a prefix.
    /// </summary>
    /// <param name="preText">Prefix for the identifier.</param>
    /// <param name="length">Length of the random part.</param>
    /// <returns>Generated identifier.</returns>
    public string GenerateRandomId(string preText, int length = IdGenerator.DefaultRandomIdLength) {
        return IdGenerator.GenerateRandomId(preText, length);
    }
}