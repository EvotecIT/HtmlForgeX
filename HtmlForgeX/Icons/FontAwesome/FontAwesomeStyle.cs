namespace HtmlForgeX;

/// <summary>
/// FontAwesome icon styles/weights
/// </summary>
public enum FontAwesomeStyle {
    /// <summary>
    /// Solid icons (fas) - filled icons, default style
    /// </summary>
    Solid,

    /// <summary>
    /// Regular icons (far) - outlined icons
    /// </summary>
    Regular,

    /// <summary>
    /// Light icons (fal) - thinner outlined icons (Pro only)
    /// </summary>
    Light,

    /// <summary>
    /// Duotone icons (fad) - two-tone icons (Pro only)
    /// </summary>
    Duotone,

    /// <summary>
    /// Brands icons (fab) - brand/logo icons
    /// </summary>
    Brands,

    /// <summary>
    /// Thin icons (fat) - very thin icons (Pro only)
    /// </summary>
    Thin
}

/// <summary>
/// Extension methods for FontAwesome styles
/// </summary>
public static class FontAwesomeStyleExtensions {
    /// <summary>
    /// Gets the CSS class prefix for the FontAwesome style
    /// </summary>
    public static string GetClassPrefix(this FontAwesomeStyle style) {
        return style switch {
            FontAwesomeStyle.Solid => "fas",
            FontAwesomeStyle.Regular => "far",
            FontAwesomeStyle.Light => "fal",
            FontAwesomeStyle.Duotone => "fad",
            FontAwesomeStyle.Brands => "fab",
            FontAwesomeStyle.Thin => "fat",
            _ => "fas"
        };
    }

    /// <summary>
    /// Gets the font family name for vis.js usage
    /// </summary>
    public static string GetFontFamily(this FontAwesomeStyle style) {
        return style switch {
            FontAwesomeStyle.Brands => "Font Awesome 6 Brands",
            _ => "Font Awesome 6 Free"
        };
    }
}