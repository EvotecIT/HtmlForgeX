namespace HtmlForgeX;

/// <summary>
/// Specifies available tag sizes.
/// </summary>
public enum TablerTagSize {
    /// <summary>Default tag size.</summary>
    Normal,

    /// <summary>Small tag size.</summary>
    Small,

    /// <summary>Large tag size.</summary>
    Large
}

/// <summary>
/// Extension helpers for <see cref="TablerTagSize"/>.
/// </summary>
public static class TablerTagSizeExtensions {
    /// <summary>
    /// Converts a size value to the corresponding CSS class.
    /// </summary>
    /// <param name="size">Value to convert.</param>
    /// <returns>CSS class name or empty string.</returns>
    public static string EnumToString(this TablerTagSize size) {
        return size switch {
            TablerTagSize.Small => "tag-sm",
            TablerTagSize.Large => "tag-lg",
            _ => string.Empty
        };
    }
}