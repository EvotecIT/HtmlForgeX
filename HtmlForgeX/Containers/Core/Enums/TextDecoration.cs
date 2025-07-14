using System.ComponentModel;

namespace HtmlForgeX;

/// <summary>
/// Text decoration values.
/// </summary>
public enum TextDecoration {
    /// <summary>No decoration.</summary>
    [Description("none")]
    None = 1,

    [Description("line-through")]
    LineThrough,

    [Description("overline")]
    Overline,

    [Description("underline")]
    Underline
}

public static class TextDecorationExtensions {
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
