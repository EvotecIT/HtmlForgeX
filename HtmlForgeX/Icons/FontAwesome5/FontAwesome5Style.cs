namespace HtmlForgeX;

/// <summary>
/// FontAwesome 5 icon style
/// </summary>
public enum FontAwesome5Style {
    /// <summary>Solid style (fas)</summary>
    Solid,
    /// <summary>Regular style (far)</summary>
    Regular,
    /// <summary>Brands style (fab)</summary>
    Brands
}

/// <summary>
/// Extension methods for FontAwesome5Style enum
/// </summary>
public static class FontAwesome5StyleExtensions {
    /// <summary>
    /// Gets the CSS class prefix for the style
    /// </summary>
    public static string GetClassPrefix(this FontAwesome5Style style) {
        return style switch {
            FontAwesome5Style.Solid => "fas",
            FontAwesome5Style.Regular => "far",
            FontAwesome5Style.Brands => "fab",
            _ => "fas"
        };
    }
}