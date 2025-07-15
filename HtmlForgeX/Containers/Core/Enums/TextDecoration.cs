using System.ComponentModel;

namespace HtmlForgeX;

/// <summary>
/// Text decoration values.
/// </summary>
public enum TextDecoration {
    /// <summary>No decoration.</summary>
    [Description("none")]
    None = 1,

    /// <summary>Specifies <c>line-through</c>.</summary>
    [Description("line-through")]
    LineThrough,

    /// <summary>Specifies <c>overline</c>.</summary>
    [Description("overline")]
    Overline,

    /// <summary>Specifies <c>underline</c>.</summary>
    [Description("underline")]
    Underline
}

/// <summary>
/// Extension methods for the <see cref="TextDecoration"/> enum.
/// </summary>
public static class TextDecorationExtensions {
    /// <summary>
    /// Converts the text decoration to its CSS string value.
    /// </summary>
    /// <param name="value">Decoration value.</param>
    /// <returns>CSS representation of the decoration.</returns>
    public static string EnumToString(this TextDecoration value) {
        return value switch {
            TextDecoration.None => "none",
            TextDecoration.LineThrough => "line-through",
            TextDecoration.Overline => "overline",
            TextDecoration.Underline => "underline",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        };
    }
}
