namespace HtmlForgeX;

/// <summary>
/// Describes text alignment classes.
/// </summary>
public enum TextAlignment {
    /// <summary>
    /// Aligns text to the center.
    /// </summary>
    Center,
    /// <summary>
    /// Aligns text to the left.
    /// </summary>
    Left,
    /// <summary>
    /// Aligns text to the right.
    /// </summary>
    Right
}

/// <summary>
/// Extension helpers for <see cref="TextAlignment"/> values.
/// </summary>
public static class TextAlignmentExtensions {
    /// <summary>
    /// Converts the <see cref="TextAlignment"/> value to a CSS class string.
    /// </summary>
    public static string ToClassString(this TextAlignment alignment) {
        return alignment switch {
            TextAlignment.Center => "text-center",
            TextAlignment.Left => "text-left",
            TextAlignment.Right => "text-right",
            _ => throw new ArgumentOutOfRangeException(nameof(alignment), alignment, null)
        };
    }
}