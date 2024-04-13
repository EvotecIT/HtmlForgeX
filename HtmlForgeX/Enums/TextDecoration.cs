using System.ComponentModel;

namespace HtmlForgeX;

public enum TextDecoration {
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
    public static string ToCssString(this TextDecoration value) {
        return value switch {
            TextDecoration.None => "none",
            TextDecoration.LineThrough => "line-through",
            TextDecoration.Overline => "overline",
            TextDecoration.Underline => "underline",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        };
    }
}
