namespace HtmlForgeX;

/// <summary>
/// CSS font-variant values.
/// </summary>
public enum FontVariant {
    /// <summary>Normal variant.</summary>
    Normal = 1,

    /// <summary>Small caps variant.</summary>
    SmallCaps
}

/// <summary>
/// Extension methods for the <see cref="FontVariant"/> enum.
/// </summary>
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
