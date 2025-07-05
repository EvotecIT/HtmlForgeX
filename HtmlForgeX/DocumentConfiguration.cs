using System.Collections.Concurrent;

namespace HtmlForgeX;

/// <summary>
/// Configuration and state for a Document instance, replacing the static GlobalStorage.
/// </summary>
public class DocumentConfiguration {
    internal const int DefaultRandomIdLength = 8;

    /// <summary>Gets or sets the current theme mode.</summary>
    public ThemeMode ThemeMode { get; set; } = ThemeMode.Light;

    /// <summary>Gets or sets the library mode.</summary>
    public LibraryMode LibraryMode { get; set; } = LibraryMode.Online;

    /// <summary>Collection of libraries used by the document.</summary>
    public ConcurrentDictionary<Libraries, byte> Libraries { get; } = new();

    /// <summary>Collection of processing errors.</summary>
    public ConcurrentBag<string> Errors { get; } = new();

    /// <summary>Output path for generated files.</summary>
    public string Path { get; set; } = "";

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
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        lock (_randomGenerator) {
            var randomId = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_randomGenerator.Next(s.Length)]).ToArray());
            return $"{preText}-{randomId}";
        }
    }
}