namespace HtmlForgeX;

/// <summary>
/// HTML heading level tags.
/// </summary>
public enum HeaderLevelTag {
    /// <summary>&lt;h1&gt; element.</summary>
    H1,
    /// <summary>&lt;h2&gt; element.</summary>
    H2,

    /// <summary>&lt;h3&gt; element.</summary>
    H3,

    /// <summary>&lt;h4&gt; element.</summary>
    H4,

    /// <summary>&lt;h5&gt; element.</summary>
    H5,

    /// <summary>&lt;h6&gt; element.</summary>
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