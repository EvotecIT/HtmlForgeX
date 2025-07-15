namespace HtmlForgeX;

/// <summary>
/// Specifies horizontal rule text alignment options.
/// </summary>
public enum HrTextAlignment {
    /// <summary>
    /// Center the text within the horizontal rule.
    /// </summary>
    Center,
    /// <summary>
    /// Left-align the text within the horizontal rule.
    /// </summary>
    Left,
    /// <summary>
    /// Right-align the text within the horizontal rule.
    /// </summary>
    Right
}

/// <summary>
/// Extension methods for <see cref="HrTextAlignment"/> values.
/// </summary>
public static class HrTextAlignmentExtensions {
    /// <summary>
    /// Converts the <see cref="HrTextAlignment"/> value to a CSS class string.
    /// </summary>
    public static string ToClassString(this HrTextAlignment alignment) {
        return alignment switch {
            HrTextAlignment.Center => "",
            HrTextAlignment.Left => "hr-text-left",
            HrTextAlignment.Right => "hr-text-right",
            _ => throw new ArgumentOutOfRangeException(nameof(alignment), alignment, null)
        };
    }
}
