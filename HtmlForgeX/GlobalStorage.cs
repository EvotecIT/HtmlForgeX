namespace HtmlForgeX;

/// <summary>
/// Provides helpers for generating identifiers.
/// </summary>
internal static class GlobalStorage {

    /// <summary>
    /// Generates a pseudo random identifier with a prefix.
    /// </summary>
    /// <param name="preText">Prefix for the identifier.</param>
    /// <param name="length">Length of the random section.</param>
    /// <returns>Generated identifier.</returns>
    internal static string GenerateRandomId(string preText, int length = IdGenerator.DefaultRandomIdLength) {
        return IdGenerator.GenerateRandomId(preText, length);
    }
}