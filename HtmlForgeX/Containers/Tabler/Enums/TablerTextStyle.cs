namespace HtmlForgeX;

/// <summary>
/// Defines additional text style utilities.
/// </summary>
public enum TablerTextStyle {
    /// <summary>
    /// Render the text in a muted color.
    /// </summary>
    Muted,
    /// <summary>
    /// Truncate the text and add an ellipsis when it overflows.
    /// </summary>
    Truncate
    // Add more options here as needed
}

/// <summary>
/// Extension methods for <see cref="TablerTextStyle"/> values.
/// </summary>
public static class TextStyleExtensions {
    /// <summary>
    /// Converts the style enum value to the corresponding CSS class.
    /// </summary>
    public static string EnumToString(this TablerTextStyle style) {
        return "text-" + style.ToString().ToLower();
    }
}
