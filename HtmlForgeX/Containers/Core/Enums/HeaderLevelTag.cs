namespace HtmlForgeX;

/// <summary>
/// HTML heading level tags.
/// </summary>
public enum HeaderLevelTag {
    /// <summary>&lt;h1&gt; element.</summary>
    H1,
    H2,
    H3,
    H4,
    H5,
    H6
}

/// <summary>
/// Extension methods for the <see cref="HeaderLevelTag"/> enum.
/// </summary>
public static class HeaderLevelTagExtensions {
    public static string EnumToString(this HeaderLevelTag tag) {
        return tag.ToString().ToLower();
    }
}