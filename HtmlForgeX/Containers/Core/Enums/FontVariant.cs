namespace HtmlForgeX;

/// <summary>
/// CSS font-variant values.
/// </summary>
public enum FontVariant {
    Normal = 1,
    SmallCaps
}

public static class FontVariantExtensions {
    /// <summary>
    /// Converts the variant to its CSS string.
    /// </summary>
    public static string EnumToString(this FontVariant value) {
        return value switch {
            FontVariant.Normal => "normal",
            FontVariant.SmallCaps => "small-caps",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        };
    }
}
