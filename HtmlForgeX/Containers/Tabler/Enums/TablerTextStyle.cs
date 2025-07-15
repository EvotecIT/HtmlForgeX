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
    Truncate,
    /// <summary>
    /// Render the text in monospace font.
    /// </summary>
    Monospace,
    /// <summary>
    /// Render the text in primary color.
    /// </summary>
    Primary,
    /// <summary>
    /// Render the text in success color.
    /// </summary>
    Success
}

/// <summary>
/// Extension methods for <see cref="TablerTextStyle"/> values.
/// </summary>
public static class TextStyleExtensions {
    /// <summary>
    /// Converts the style enum value to the corresponding CSS class.
    /// </summary>
    public static string EnumToString(this TablerTextStyle style) {
        return style switch {
            TablerTextStyle.Muted => "text-muted",
            TablerTextStyle.Truncate => "text-truncate",
            TablerTextStyle.Monospace => "font-monospace",
            TablerTextStyle.Primary => "text-primary",
            TablerTextStyle.Success => "text-success",
            _ => "text-" + style.ToString().ToLower()
        };
    }
}
