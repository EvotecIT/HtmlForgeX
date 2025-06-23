namespace HtmlForgeX;

/// <summary>
/// Describes text alignment classes.
/// </summary>
public enum TextAlignment {
    Center,
    Left,
    Right
}

public static class TextAlignmentExtensions {
    public static string ToClassString(this TextAlignment alignment) {
        return alignment switch {
            TextAlignment.Center => "text-center",
            TextAlignment.Left => "text-left",
            TextAlignment.Right => "text-right",
            _ => throw new ArgumentOutOfRangeException(nameof(alignment), alignment, null)
        };
    }
}